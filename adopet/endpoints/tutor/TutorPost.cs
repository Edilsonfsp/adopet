using adopet.domain.tutor;
using adopet.infra.data;

namespace adopet.endpoints.tutor;

public class TutorPost
{

    public static string Template => "/tutors";

    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };

    public static Delegate Handle => Action;

    public static IResult Action(TutorRequest tutorRequest, ApplicationDbContext context)
    {

        var tutor = new Tutor
        {

            Name = tutorRequest.Name,
            Email = tutorRequest.Email,
            Password = tutorRequest.Password

				};
        context.Tutors.Add(tutor);
        context.SaveChanges();
        return Results.Created($"{Template}/{tutor.Id}", tutor.Id);
    }

}
