app.controller('ProductListCtrl', ['$scope', 'ProductsFactory', 'ProductFactory', '$location',
function ($scope, ProductsFactory, ProductFactory, $location) {
    $scope.editProduct = function (productId) {
        $location.path('/product-detail/' + productId);
    };

    $scope.deleteProduct = function (productId) {
        var result = confirm('Esta seugro?');
        if (result == true) {
            ProductFactory.delete({ id: productId });
            $scope.products = ProductsFactory.query();
        }
    };

    $scope.createNewProduct = function () {
        $location.path('/product-creation');
    };

    $scope.products = ProductsFactory.query();
}]);

app.controller('ProductDetailCtrl', ['$scope', '$routeParams', 'ProductsFactory', 'ProductFactory', '$location',
    function ($scope, $routeParams, ProductsFactory, ProductFactory, $location) {
        $scope.updateProduct = function () {
            ProductFactory.update($scope.product);
            $scope.products = ProductsFactory.query();
            $location.path('/product-list');
        };

        $scope.cancel = function () {
            $location.path('/product-list');
        };

        $scope.product = ProductFactory.show({ id: $routeParams.id });
    }]);

app.controller('ProductCreationCtrl', ['$scope', 'ProductsFactory', '$location',
    function ($scope, ProductsFactory, $location) {
        $scope.createNewProduct = function () {
            ProductsFactory.create($scope.product);
            $scope.products = ProductsFactory.query();
            $location.path('/product-list');
        }
    }]);