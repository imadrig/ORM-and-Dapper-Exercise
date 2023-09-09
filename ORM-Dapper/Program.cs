
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;


    var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

    string connString = config.GetConnectionString("DefaultConnection");

    IDbConnection conn = new MySqlConnection(connString);


    var departmentRepo = new DapperDepartmentRepository(conn);

    departmentRepo.InsertDepartment("New Department");

    var departments = departmentRepo.GetAllDepartments();

    foreach (var department in departments)
    {
        Console.WriteLine(department.DepartmentID);
        Console.WriteLine(department.Name);
    }

    var repo = new DapperProductRepository(conn);
    var products = repo.GetAllProducts();

    repo.CreateProduct("newProduct", 20, 1);

    foreach (var product in products)
    {
        Console.WriteLine($"{product.ProductID} {product.Name}" );
    }

    
