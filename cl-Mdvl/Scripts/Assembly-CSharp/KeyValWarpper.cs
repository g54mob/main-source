using System;
using UnityEngine;

[Serializable]
public struct KeyValWarpper
{
	[SerializeField]
	private string key;

	[SerializeField]
	private bool val;

	public string Key => key;

	public bool Val => val;

	public void SetKey(string str)
	{
		key = str;
	}

	public void SetVal(bool value)
	{
		val = value;
	}
}
