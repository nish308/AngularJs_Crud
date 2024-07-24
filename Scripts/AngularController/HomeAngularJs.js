var app = angular.module("Homeapp", []);

app.controller("HomeController", function ($scope, $http) {
    $scope.btntext = "Save";

    $scope.saveData = function () {
        $scope.btntext = "Please Wait...";

        $http.post('/Home/Add_Record', $scope.register)
            .then(function (response) {
                $scope.btntext = "Save";
                $scope.register = null;
                alert('Data saved successfully');
                console.log(response);
            })
            .catch(function (error) {
                $scope.btntext = "Save";
                alert('Failed to save data');
                console.error('Error:', error);
            });
    };

    $http.get("/Home/Get_Data").then(function (d) {
        $scope.record = d.data;
    }, function (error) {
        alert('Failed');
    });

    $scope.loadrecord = function (id) {
        $http.get("/Home/Get_DataBy_Id?id=" + id).then(function (d) {
            $scope.register = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    };

    $scope.updateData = function () {
        $scope.btntext = "Please Wait...";

        $http.post('/Home/UpdateRecord', $scope.register)
            .then(function (response) {
                $scope.btntext = "Update";
                $scope.record = null;
                alert('Data updated successfully');
                console.log(response);
            })
            .catch(function (error) {
                $scope.btntext = "Update";
                alert('Failed to update data');
                console.error('Error:', error);
            });
    };

    $scope.deleterecord = function (id) {
        $http.get("/Home/DeleteRecord?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Home/Get_Data").then(function (d) {
                $scope.record = d.data;
            }, function (error) {
                alert('Failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
});