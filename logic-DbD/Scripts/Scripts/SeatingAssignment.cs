public class SeatingAssignment
{
	public string studentId;

	public char row;

	public int column;

	public SeatingAssignment(string studentId, char row, int column)
	{
		this.studentId = studentId;
		this.row = row;
		this.column = column;
	}

	public override string ToString()
	{
		return $"'{studentId}', '{row}', {column}";
	}

	public static SeatingAssignment BuildFromRow(string[] row)
	{
		string obj = row[0];
		char c = char.Parse(row[1]);
		int num = int.Parse(row[2]);
		return new SeatingAssignment(obj, c, num);
	}
}
