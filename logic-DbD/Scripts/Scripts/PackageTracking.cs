public class PackageTracking
{
	public string address;

	public string status;

	public string type;

	public PackageTracking(string type, string address, string status)
	{
		this.type = type;
		this.address = address;
		this.status = status;
	}

	public override string ToString()
	{
		return "'" + type + "', '" + address + "', '" + status + "'";
	}

	public static PackageTracking BuildFromRow(string[] row)
	{
		string text = row[0];
		string obj = row[1];
		string text2 = row[2];
		return new PackageTracking(obj, text2, text);
	}
}
