public class Student : Person
{
	public string studentId;

	public Student(string firstName, string lastName, string studentId)
		: base(firstName, lastName)
	{
		this.studentId = studentId;
	}

	public override string ToString()
	{
		return "'" + studentId + "', " + base.ToString();
	}

	public new static Student BuildFromRow(string[] row)
	{
		string obj = row[0];
		string text = row[1];
		string text2 = row[2];
		return new Student(obj, text, text2);
	}
}
