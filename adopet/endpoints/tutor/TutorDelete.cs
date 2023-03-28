using adopet.infra.data;
using Microsoft.AspNetCore.Mvc;

namespace adopet.endpoints.tutor;

public class TutorDelete
{

  public static string Template => "/tutors/{id}";

  public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };

  public static Delegate Handle => Action;

  public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
  {

    var tutor = context.Tutors.Where(t => t.Id == id).FirstOrDefault();

    if (tutor == null)
        return Results.NotFound();

    context.Remove(tutor);

    context.SaveChanges();

    return Results.Ok();
  }

}
