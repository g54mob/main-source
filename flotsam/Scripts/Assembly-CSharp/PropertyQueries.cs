public class PropertyQueries
{
	public const string READ_ALL = "SELECT * FROM Property";

	public const string READ_SINGLE = "SELECT * FROM Property where name = \"{0}\"";

	public const string WRITE_SINGLE = "INSERT or REPLACE into Property (name, gathered) values (\"{0}\", {1})";
}
