public class GlassesIndoors
{
	public string test_subject;

	public int age;

	public int glasses_indoors_chance;

	public GlassesIndoors(string test_subject, int age, int glasses_indoors_chance)
	{
		this.test_subject = test_subject;
		this.age = age;
		this.glasses_indoors_chance = glasses_indoors_chance;
	}

	public override string ToString()
	{
		return $"'{test_subject}', {age}, {glasses_indoors_chance}";
	}
}
