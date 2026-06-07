using Cysharp.Text;
using UnityEngine;

public class LocalizeAffixStringHandler : LocalizeStringHandler
{
	[SerializeField]
	private string prefix = string.Empty;

	[SerializeField]
	private string suffix = string.Empty;

	public string Value { get; private set; }

	public string AffixValue => ZString.Format("{0}{1}{2}", prefix, Value, suffix);

	public string Prefix
	{
		get
		{
			return prefix;
		}
		set
		{
			if (!(prefix == value))
			{
				prefix = value;
				ApplyProperty(Value);
			}
		}
	}

	public string Suffix
	{
		get
		{
			return suffix;
		}
		set
		{
			if (!(suffix == value))
			{
				suffix = value;
				ApplyProperty(Value);
			}
		}
	}

	protected override void ApplyProperty(string value)
	{
		Value = value;
		base.ApplyProperty(AffixValue);
	}
}
