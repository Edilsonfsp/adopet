using adopet.infra.data;
using Microsoft.AspNetCore.Mvc;

namespace adopet.endpoints.tutor;

public class TutorPut
{

    public static string Template => "/tutors/{id}";

    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };

    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, TutorRequest tutorRequest, ApplicationDbContext context)
    {

        var tutor = context.Tutors.Where(t => t.Id == id).FirstOrDefault();
        if (tutor == null)
            return Results.NotFound();

        tutor.Name = tutorRequest.Name;

        context.SaveChanges();

        return Results.Ok(tutor.Name);
    }

}
