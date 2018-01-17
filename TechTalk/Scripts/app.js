var LoginApp = angular.module("TechTalk", [])
//LoginApp.config(['$routeProvider', function ($routeProvider) {
//    $routeProvider
//    .when('/')
//}]);
LoginApp.controller("ALoginController", ['$scope','$window','$http', function ($scope,$window, $http) {
    $scope.username = '';
    $scope.password = '';
    $scope.responseMessage = '';
    $scope.isSubmitButtonDisabled = false;

    $scope.loginSubmit = function () {

        var userdata = {
            Username: $scope.username,
            Password: $scope.password
        };

        var config = {
            headers: {
                'Content-Type': 'application/json'
            }
        };

        $http.post('/api/Login/LoginCheck', userdata, config).then(function (successResponse) {
           
            $scope.isSubmitButtonDisabled = true;
            $window.location.href = '../View/adminPortal.html'
            alert("Login Successfull");
        }, function (errorResponse) {
          
            $scope.responseMessage = 'Email or Password is incorrect';
        });
    }
}]);
