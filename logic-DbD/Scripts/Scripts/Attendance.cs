public class Attendance
{
	public string studentId;

	public string date;

	public Attendance(string studentId, string date)
	{
		this.studentId = studentId;
		this.date = date;
	}

	public override string ToString()
	{
		return "'" + studentId + "', '" + date + "'";
	}

	public static Attendance BuildFromRow(string[] row)
	{
		string obj = row[0];
		string text = row[1];
		return new Attendance(obj, text);
	}
}
