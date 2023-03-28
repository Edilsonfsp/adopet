using adopet.infra.data;

namespace adopet.endpoints.tutor;

public class TutorGetAll
{

    public static string Template => "/tutors";

    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };

    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {

        var tutors = context.Tutors.ToList();
        var response = tutors.Select(t => new TutorResponse
        {
            Id = t.Id,
            Name = t.Name
        });

        return Results.Ok(response);
    }

}
