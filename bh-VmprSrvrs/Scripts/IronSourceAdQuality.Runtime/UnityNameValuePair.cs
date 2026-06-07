public class UnityNameValuePair<V> : UnityKeyValuePair<string, V>
{
	public string name;

	public override string Key
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public UnityNameValuePair()
	{
	}

	public UnityNameValuePair(string key, V value)
	{
	}
}
