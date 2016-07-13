using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using efcoretest;

namespace Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //all the questions inheriting FieldValue should be included
            mb.Entity<LikeTypeSmile>().Property(p => p.Smile).HasColumnName("Smile");
            mb.Entity<LikeTypeFrown>().Property(p => p.Frown).HasColumnName("Frown");

            mb.Entity<LikeType>().HasDiscriminator<LikeTypeEnum>("MyLikeType")
                                            .HasValue<LikeTypeSmile>(LikeTypeEnum.Smile)
                                            .HasValue<LikeTypeFrown>(LikeTypeEnum.Frown);


            // setup the self-refernce within FieldDefinition to indicate which fields can be multi-value and which field is the key
            mb.Entity<Blog>().HasKey(x => x.Id);

            mb.Entity<Blog>().HasOne(x => x.FirstSeriesKey)
                                        .WithMany()
                                        .HasForeignKey(z => z.FirstSeriesKeyId);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }


    }



    public class Blog : IId
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }

        public int? Something { get; set; }

        public Blog FirstSeriesKey { get; set; }
        public int? FirstSeriesKeyId { get; set; }

    }

    public class Post : IId
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<Like> Likes { get; set; }

        // if this id is not specified then when you query Context.Posts.Blog.Id the query fails with Null Reference Exception
        //public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class Like : IId
    {
        public int Id { get; set; }
        public bool Liked { get; set; }

        public List<LikeType> LikeTypes { get; set;}
    }

    public abstract class LikeType : IId
    {
        public int Id { get; set; }

        public LikeTypeEnum MyLikeType { get; set; }

    }

    public class LikeTypeSmile : LikeType {
        public string Smile { get; set; }
    }

    public class LikeTypeFrown : LikeType {
        public string Frown { get; set; }

    }

}