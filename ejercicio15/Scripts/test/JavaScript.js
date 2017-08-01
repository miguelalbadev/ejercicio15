describe("A suite", function () {
    it("contains spec with an expectation", function () {
        expect(true).toBe(true);
    });

    
});

describe("Another suite with GET", function () {
    var resultado;
    it("prueba petición GET", function (done) {
        
        $.get("api/values/3", function (data) {
            resultado = data;
            done();
        });
    });

    afterEach(function (done) {
        expect(resultado).toBe("value");
        done();
    }, 1000);

});

describe("Another suite with GET all", function () {
    var resultado;
    it("prueba petición GET all", function (done) {

        $.get("api/values", function (data) {
            resultado = data;
            done();
        });
    });

    afterEach(function (done) {
        
        //var miArray =  ["valueMio", "valueOtro"];
        expect(resultado[0]).toBe("valueMio");
        expect(resultado[1]).toBe("valueOtro");
        done();
    }, 1000);

});

describe("Another suite with POST", function () {
    var resultado;
    it("prueba petición POST", function (done) {

        $.post("api/values", function (data) {
            resultado = data;
            done();
        });
    });

    afterEach(function (done) {
        expect(resultado).toBe(resultado);
        done();
    }, 1000);

});

describe("Another suite with PUT", function () {
    var resultado;
    it("prueba petición PUT", function (done) {

        $.ajax({
            url: 'api/values/5',
            type: 'PUT',
            success: function (data) {
                resultado = data;
                done();
            }
        });
    });

    afterEach(function (done) {
        expect(resultado).toBe(resultado);
        done();
    }, 1000);

});

describe("Another suite with DELETE", function () {
    var resultado;
    it("prueba petición DELETE", function (done) {

        $.ajax({
            url: 'api/values/5',
            type: 'DELETE',
            success: function (data) {
                resultado = data;
                done();
            }
        });
    });

    afterEach(function (done) {
        expect(resultado).toBe(resultado);
        done();
    }, 1000);

});

