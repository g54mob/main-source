public class Price
{
	public int date;

	public int time;

	public double price;

	public Price(int date, int time, double price)
	{
		this.date = date;
		this.time = time;
		this.price = price;
	}

	public override string ToString()
	{
		return $"{date}, {time}, {price}";
	}

	public static Price BuildFromRow(string[] row)
	{
		int num = int.Parse(row[0]);
		int num2 = int.Parse(row[1]);
		double num3 = double.Parse(row[2]);
		return new Price(num, num2, num3);
	}
}
