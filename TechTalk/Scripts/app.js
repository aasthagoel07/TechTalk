var LoginApp = angular.module("TechTalk", [])
LoginApp.controller("ALoginController", ['$scope', '$http', '$cookies', '$window', function ($scope, $http, $cookies, $window) {
    $scope.username = '';
    $scope.password = '';
    $scope.responseMessage = '';
    $scope.isSubmitButtonDisabled = false;

    $scope.loginSubmit = function () {

        var userdata = {
            'username': $scope.username,
            'userpass': $scope.password
        };

        var config = {
            headers: {
                'Content-Type': 'application/json'
            }
        };

        $http.post('LoginController/Login', userdata, config).then(function (successResponse) {
            debugger
            $scope.isSubmitButtonDisabled = true;
            $cookies.putObject('user', userdata);
            $window.location.href = 'Views/adminPortal.html'
        }, function (errorResponse) {
            $scope.responseMessage = 'Email or Password is incorrect';
        });
