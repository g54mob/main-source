using System;

[Serializable]
public sealed class ObjectKvp : UnityNameValuePair<string>
{
	public string value;

	public override string Value
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public ObjectKvp(string key, string value)
	{
	}
}
