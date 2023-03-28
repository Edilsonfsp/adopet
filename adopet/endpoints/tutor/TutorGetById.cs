using adopet.infra.data;
using Microsoft.AspNetCore.Mvc;

namespace adopet.endpoints.tutor;

public class TutorGetById
{

  public static string Template => "/tutors/{id}";

  public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

  public static Delegate Handle => Action;

  public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
  {

    var tutor = context.Tutors.FirstOrDefault(t => t.Id == id);
    if (tutor == null)
      return Results.NotFound();

    var response = new TutorResponse
    {
        Id = tutor.Id,
        Name = tutor.Name
    };

    return Results.Ok(response);
  }
}
