using UnityEngine;

public class ItemQueries : MonoBehaviour
{
	public const string READ_ALL = "SELECT * FROM Item";

	public const string READ_SINGLE = "SELECT * FROM Item where name = \"{0}\"";

	public const string WRITE_SINGLE = "INSERT or REPLACE into Item (name, pickup_count, use_count, spirit_consumed) values ({0}, {1}, {2}, {3})";
}
