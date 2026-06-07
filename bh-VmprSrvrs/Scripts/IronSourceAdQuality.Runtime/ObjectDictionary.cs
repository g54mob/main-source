using System;
using System.Collections.Generic;

[Serializable]
public class ObjectDictionary : UnityDictionary<string>
{
	public List<ObjectKvp> values;

	protected override List<UnityKeyValuePair<string, string>> KeyValuePairs
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public new ObjectKvp ConvertUkvp(UnityKeyValuePair<string, string> ukvp)
	{
		return null;
	}

	public UnityKeyValuePair<string, string> ConvertOkvp(ObjectKvp okvp)
	{
		return null;
	}

	protected override void SetKeyValuePair(string k, string v)
	{
	}
}
