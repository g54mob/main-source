public class Attendee : Person
{
	private string id;

	public Attendee(int id, string firstName, string lastName)
		: base(firstName, lastName)
	{
		this.id = id.ToString("D5");
	}

	public override string ToString()
	{
		return "'" + id + "', " + base.ToString();
	}
}
