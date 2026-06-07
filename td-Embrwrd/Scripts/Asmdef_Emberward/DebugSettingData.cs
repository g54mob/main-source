using System;
using UnityEngine;

[Serializable]
public class DebugSettingData
{
	[SerializeField]
	private eDebugKey key;

	[SerializeField]
	private string prefix;

	[SerializeField]
	private Color color;

	[SerializeField]
	private string colorHex;

	[SerializeField]
	private bool isEnabled;

	public eDebugKey Key
	{
		get
		{
			return default(eDebugKey);
		}
		set
		{
		}
	}

	public string Prefix
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Color Color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public string ColorHex => null;

	public bool IsEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private string CalculateColorHex(Color _color)
	{
		return null;
	}
}
