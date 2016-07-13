using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efcoretest
{
    public static class Seeder
    {

        public static void Seed(BloggingContext ctx) {
            // the 'first' blog in a series of blogs
            Blog first = new Blog();
            first.Url = $"http://www.google.com/?s=999999";
            ctx.Blogs.Add(first);

            for (int i = 1; i <= 250; i++)
            {

                Blog b = new Blog();
                b.FirstSeriesKey = first;
                b.Url = $"http://www.google.com/?s={i}";
                b.Posts = new List<Post>();


                Post p = new Post();
                p.Title = $"Primary Post Title {i}";
                p.Content = $"Primary Post Content {i}";
                p.Likes = new List<Like>();
                b.Posts.Add(p);

                if (i % 1 == 0)
                {
                    Like l = new Models.Like();
                    l.Liked = true;
                    l.LikeTypes = new List<LikeType>();
                    l.LikeTypes.Add(new LikeTypeFrown());
                    l.LikeTypes.Add(new LikeTypeSmile());
                    p.Likes.Add(l);
                    Like ll = new Models.Like();
                    ll.Liked = false;
                    ll.LikeTypes = new List<LikeType>();
                    ll.LikeTypes.Add(new LikeTypeFrown());
                    ll.LikeTypes.Add(new LikeTypeSmile());
                    p.Likes.Add(ll);
                }


                Post s = new Post();
                s.Title = $"Secondary Post Title {i}";
                s.Content = $"Secondary Post Content {i}";
                s.Likes = new List<Like>();
                b.Posts.Add(s);

                Like lll = new Models.Like();
                lll.Liked = true;
                lll.LikeTypes = new List<LikeType>();
                lll.LikeTypes.Add(new LikeTypeFrown());
                lll.LikeTypes.Add(new LikeTypeSmile());
                s.Likes.Add(lll);

                Like llll = new Models.Like();
                llll.Liked = false;
                llll.LikeTypes = new List<LikeType>();
                if (i % 6 == 0)
                {
                    llll.LikeTypes.Add(new LikeTypeFrown());
                    llll.LikeTypes.Add(new LikeTypeSmile());
                    s.Likes.Add(llll);
                }
                ctx.Blogs.Add(b);

            }
            ctx.SaveChanges();
        }



    }
}
