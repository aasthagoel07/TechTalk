LoginApp.controller("ARegisterController", [$scope, $http, function ($scope, $http) {
    $scope.isMatch = false;
    $scope.passMatch = function () {
        if ($scope.a.Password != $scope.a.Confirm_Password) {
            $scope.isMatch = true;
        }
        else $scope.isMatch = false;
    };
    $scope.add = function () {
        var a = $scope.a;
        var config = {
            headers: {
                'Content-Type': 'application/json'
            }
        };
        $http.post('/api/Register', a, config).then(function (successResponse) {
            alert("Registered");
        }, function (error) {
            alert("Unsuccessfull");
        });
    };

}]);
