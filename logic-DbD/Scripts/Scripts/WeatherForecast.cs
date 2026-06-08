public class WeatherForecast
{
	public int date;

	public string forecast;

	public int fahrenheit;

	public WeatherForecast(int date, string forecast, int fahrenheit)
	{
		this.date = date;
		this.forecast = forecast;
		this.fahrenheit = fahrenheit;
	}

	public override string ToString()
	{
		return $"{date}, '{forecast}', {fahrenheit}";
	}

	public static WeatherForecast BuildFromRow(string[] row)
	{
		int num = int.Parse(row[0]);
		string text = row[1];
		int num2 = int.Parse(row[2]);
		return new WeatherForecast(num, text, num2);
	}
}
