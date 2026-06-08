public class Review
{
	public string title;

	public string rating;

	public Review(string title, double rating)
	{
		this.title = title;
		this.rating = rating.ToString("N1");
	}

	public Review(string title, string rating)
	{
		this.title = title;
		this.rating = rating;
	}

	public override string ToString()
	{
		return "'" + title + "', " + rating;
	}

	public static Review BuildFromRow(string[] row)
	{
		string obj = row[0];
		string text = row[1];
		return new Review(obj, text);
	}
}
