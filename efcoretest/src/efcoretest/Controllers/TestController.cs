using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace efcoretest.Controllers
{
    [Route("api/[controller]")]
    [Produces("text/html")]
    public class TestController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            

            return @"   <html>
<head>
<script src='https://ajax.googleapis.com/ajax/libs/angularjs/1.5.7/angular.js' ></script>
    <script>


                      (function(angular) {
  'use strict';
angular.module('httpExample', [])
  .controller('FetchController', ['$scope', '$http', '$templateCache',
    function($scope, $http, $templateCache) {
      $scope.method = 'Get';
      
      $scope.fetch = function() {
        $scope.code = null;
        $scope.response = null;
        $scope.url = url;

        for (var i = 1; i< 100; i++) {
            var url = '/api/Values/?param=' + i;

            $http({method: $scope.method, url: url, cache: false,data: null,transformResponse: [], headers: { 'Content-Type': 'application/json; charset=UTF-8' }}).
              then(function(response) {
                $scope.status += '\n' + response.status;
                //$scope.data += '\n' + response.data;
              }, function(response) {
                //$scope.data += '\n' + response.data || '\n' + 'Request failed';
                $scope.status += '\n' + response.status;
            });            
        }




      };

      $scope.updateModel = function(method, url)
    {
        $scope.method = method;
        $scope.url = url;
    };
}]);
})(window.angular);

                        </script>
</head>
<body ng-app=""httpExample"">
  <div ng-controller=""FetchController"">
  <select ng-model=""method"" aria-label=""Request method"">
    <option>GET</option>
  </select>
  <input type=""text"" ng-model=""url"" size=""80"" aria-label=""URL"" />
  <button id=""fetchbtn"" ng-click=""fetch();"">fetch LOTS</button><br>

  <pre>http status code: {{status}}</pre>
  <pre>http response data: {{data}}</pre>
</div>
</body>
                        </html>
                        ";
        }
    }
}
