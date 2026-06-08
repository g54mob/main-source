public class DatingProfile : Person
{
	public string age;

	public string number;

	public string q1;

	public string q2;

	public string q3;

	public DatingProfile(string firstName, string lastName, string number, int age, string q1, string q2, string q3)
		: base(firstName, lastName)
	{
		this.age = age.ToString();
		this.number = number;
		this.q1 = q1;
		this.q2 = q2;
		this.q3 = q3;
	}

	public override string ToString()
	{
		return base.ToString() + ", '" + number + "', " + age + ", '" + q1 + "', '" + q2 + "', '" + q3 + "'";
	}

	public new static DatingProfile BuildFromRow(string[] row)
	{
		string obj = row[0];
		string text = row[1];
		string text2 = row[2];
		int num = int.Parse(row[3]);
		string text3 = row[4];
		string text4 = row[5];
		string text5 = row[6];
		return new DatingProfile(obj, text, text2, num, text3, text4, text5);
	}
}
