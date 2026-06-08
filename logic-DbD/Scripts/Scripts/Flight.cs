public class Flight
{
	public int date;

	public int time;

	public string departing;

	public string arriving;

	public int flight_number;

	public Flight(int date, int time, string departing, string arriving, int flight_number)
	{
		this.date = date;
		this.time = time;
		this.departing = departing;
		this.arriving = arriving;
		this.flight_number = flight_number;
	}

	public override string ToString()
	{
		return $"{date}, {time}, '{departing}', '{arriving}', {flight_number}";
	}

	public static Flight BuildFromRow(string[] row)
	{
		int num = int.Parse(row[0]);
		int num2 = int.Parse(row[1]);
		string text = row[2];
		string text2 = row[3];
		int num3 = int.Parse(row[4]);
		return new Flight(num, num2, text, text2, num3);
	}
}
