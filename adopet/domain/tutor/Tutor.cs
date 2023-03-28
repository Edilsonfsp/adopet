namespace adopet.domain.tutor;

public class Tutor
{
  public Guid Id { get; set; }
  public string Name { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public string UrlPhoto { get; set; } = "sem foto";
	public string PhoneNumber { get; set; } = "00";
	public string CEP { get; set; } = "00000-00";
	public string AboutMe { get; set; } = "Not informed";

}