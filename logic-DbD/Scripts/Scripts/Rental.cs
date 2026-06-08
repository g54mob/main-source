public class Rental
{
	public int beds;

	public int bathrooms;

	public int monthly_rent;

	public string neighborhood;

	public string vacant;

	public Rental(int beds, int bathrooms, string neighborhood, int monthly_rent, string vacant)
	{
		this.beds = beds;
		this.bathrooms = bathrooms;
		this.neighborhood = neighborhood;
		this.monthly_rent = monthly_rent;
		this.vacant = vacant;
	}

	public override string ToString()
	{
		return $"'{neighborhood}', {beds}, {bathrooms}, {monthly_rent}, '{vacant}'";
	}

	public static Rental BuildFromRow(string[] row)
	{
		string text = row[0];
		int num = int.Parse(row[1]);
		int num2 = int.Parse(row[2]);
		int num3 = int.Parse(row[3]);
		string text2 = row[4];
		return new Rental(num, num2, text, num3, text2);
	}
}
