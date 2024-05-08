using Microsoft.EntityFrameworkCore;
using ApiBurgerDV.Data;
using ApiBurgerDV.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace ApiBurgerDV.Controllers;

public static class BurgerDvEndpoints
{
    public static void MapBurgerDvEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/BurgerDv").WithTags(nameof(BurgerDv));

        group.MapGet("/", async (ApiBurgerDVContext db) =>
        {
            return await db.BurgerDv.ToListAsync();
        })
        .WithName("GetAllBurgerDvs")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<BurgerDv>, NotFound>> (int id, ApiBurgerDVContext db) =>
        {
            return await db.BurgerDv.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is BurgerDv model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetBurgerDvById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, BurgerDv burgerDv, ApiBurgerDVContext db) =>
        {
            var affected = await db.BurgerDv
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, burgerDv.Id)
                    .SetProperty(m => m.Name, burgerDv.Name)
                    .SetProperty(m => m.WithCheese, burgerDv.WithCheese)
                    .SetProperty(m => m.Precio, burgerDv.Precio)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateBurgerDv")
        .WithOpenApi();

        group.MapPost("/", async (BurgerDv burgerDv, ApiBurgerDVContext db) =>
        {
            db.BurgerDv.Add(burgerDv);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/BurgerDv/{burgerDv.Id}",burgerDv);
        })
        .WithName("CreateBurgerDv")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, ApiBurgerDVContext db) =>
        {
            var affected = await db.BurgerDv
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteBurgerDv")
        .WithOpenApi();
    }
}
