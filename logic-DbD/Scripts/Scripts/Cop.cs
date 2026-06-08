public class Cop : Person
{
	public string id;

	public int gunsIssued;

	public int securityLevel;

	public Cop(int id, string firstName, string lastName, int gunsIssued, int securityLevel)
		: base(firstName, lastName)
	{
		this.id = id.ToString("D5");
		this.gunsIssued = gunsIssued;
		this.securityLevel = securityLevel;
	}

	public override string ToString()
	{
		return $"'{id}', {base.ToString()}, '{gunsIssued}', {securityLevel}";
	}
}
