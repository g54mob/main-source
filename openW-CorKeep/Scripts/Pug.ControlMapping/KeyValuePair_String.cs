using System;
using UnityEngine;

[Serializable]
public class KeyValuePair_String
{
	[field: SerializeField]
	public string Key { get; private set; }

	[field: SerializeField]
	public string Value { get; private set; }
}
