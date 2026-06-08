public class Movie
{
	public string title;

	public string director;

	public string genre;

	public int year;

	public string month;

	public string rating;

	public int reviews;

	public Movie(string title, string director, string genre, int year, string month, double rating, int reviews)
	{
		this.title = title;
		this.director = director;
		this.genre = genre;
		this.year = year;
		this.month = month;
		this.rating = rating.ToString("N1");
		this.reviews = reviews;
	}

	public override string ToString()
	{
		return $"'{title}', '{director}', '{genre}', {year}, '{month}', {rating}, {reviews}";
	}

	public static Movie BuildFromRow(string[] row)
	{
		string obj = row[0];
		string text = row[1];
		string text2 = row[2];
		int num = int.Parse(row[3]);
		string text3 = row[4];
		double num2 = double.Parse(row[5]);
		int num3 = int.Parse(row[6]);
		return new Movie(obj, text, text2, num, text3, num2, num3);
	}
}
