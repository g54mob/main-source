public class Person
{
	public string firstName;

	public string lastName;

	public Person(string firstName, string lastName)
	{
		this.firstName = firstName;
		this.lastName = lastName;
	}

	public override string ToString()
	{
		return "'" + firstName + "', '" + lastName + "'";
	}

	public static Person BuildFromRow(string[] row)
	{
		string obj = row[0];
		string text = row[1];
		return new Person(obj, text);
	}
}
