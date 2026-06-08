public class ExamplePerson : Person
{
	private int age;

	public ExamplePerson(string firstName, string lastName, int age)
		: base(firstName, lastName)
	{
		this.age = age;
	}

	public override string ToString()
	{
		return $"\"{firstName}\", \"{lastName}\", {age}";
	}
}
