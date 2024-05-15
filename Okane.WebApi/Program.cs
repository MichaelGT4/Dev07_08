using Okane.Application;
using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Retrieve;
using Okane.Application.Expenses.Update;
using Okane.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOkane();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/expenses", (CreateExpenseHandler handler, CreateExpenseRequest request) =>
        handler.Handle(request).ToResult())
    .WithOpenApi();

app.MapPut("/expenses", (UpdateExpenseHandler handler, UpdateExpenseRequest request) =>
        handler.Handle(request).ToResult())
    .WithOpenApi();

app.MapGet("/expenses", (RetrieveExpensesHandler handler) =>
        handler.Handle())
    .WithOpenApi();

app.MapGet("/expenses/{id}", (GetExpenseByIdHandler handler, int id) => 
        handler.Handle(id).ToResult())
    .WithOpenApi();

app.Run();