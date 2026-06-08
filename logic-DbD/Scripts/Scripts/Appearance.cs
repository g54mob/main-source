public class Appearance
{
	public int age;

	public string eyeColor;

	public Appearance(int age)
		: this(age, null)
	{
	}

	public Appearance(int age, string eyeColor)
	{
		this.age = age;
		this.eyeColor = eyeColor;
	}

	public override string ToString()
	{
		if (eyeColor == null)
		{
			return $"{age}, NULL";
		}
		return $"{age}, '{eyeColor}'";
	}
}
