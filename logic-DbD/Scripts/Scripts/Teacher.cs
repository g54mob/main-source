public class Teacher : Person
{
	private int dateJoined;

	private int dateOfBirth;

	private string eyeColor;

	private int height;

	private int weight;

	public Teacher(string firstName, string lastName, int dateJoined, int dateOfBirth, string eyeColor, int height, int weight)
		: base(firstName, lastName)
	{
		this.dateJoined = dateJoined;
		this.dateOfBirth = dateOfBirth;
		this.eyeColor = eyeColor;
		this.height = height;
		this.weight = weight;
	}

	public override string ToString()
	{
		return $"{base.ToString()}, {dateJoined}, {dateOfBirth}, '{eyeColor}', {height}, {weight}";
	}
}
