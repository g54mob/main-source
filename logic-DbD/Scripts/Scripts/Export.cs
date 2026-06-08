public class Export
{
	public string export;

	public string category;

	public int export_worth;

	public int year;

	public Export(string export, string category, int export_worth, int year)
	{
		this.export = export;
		this.category = category;
		this.export_worth = export_worth;
		this.year = year;
	}

	public override string ToString()
	{
		return $"'{export}', '{category}', {year}, {export_worth}";
	}
}
