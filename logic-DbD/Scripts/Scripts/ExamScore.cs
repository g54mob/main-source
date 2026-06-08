public class ExamScore
{
	public string studentId;

	public int score;

	public ExamScore(string studentId, int score)
	{
		this.studentId = studentId;
		this.score = score;
	}

	public override string ToString()
	{
		return $"'{studentId}', {score}";
	}

	public static ExamScore BuildFromRow(string[] row)
	{
		string obj = row[0];
		int num = int.Parse(row[1]);
		return new ExamScore(obj, num);
	}
}
