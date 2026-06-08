public class Suspect : Person
{
	private int number;

	private string occupation;

	public Suspect(int number, string firstName, string lastName, string occupation)
		: base(firstName, lastName)
	{
		this.number = number;
		this.occupation = occupation;
	}

	public override string ToString()
	{
		return $"{number}, {base.ToString()}, '{occupation}'";
	}
}
