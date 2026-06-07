using System;
using System.Collections.Generic;
using UnityEngine;

public class MotorwaysStringKey : StringKey
{
	protected StringId id;

	protected Dictionary<string, string> parameters;

	protected int count;

	protected bool isPlural;

	public MotorwaysStringKey()
	{
	}

	public MotorwaysStringKey(StringId newId, Dictionary<StringParameterId, string> newParameters = null)
	{
		BasicInit(newId, newParameters);
	}

	public MotorwaysStringKey(StringId newId, int newCount, Dictionary<StringParameterId, string> newParameters = null)
	{
		IntInit(newId, newCount, newParameters);
	}

	public MotorwaysStringKey(StringId newId, float newCount, Dictionary<StringParameterId, string> newParameters = null)
	{
		FloatInit(newId, newCount, newParameters);
	}

	public void BasicInit(StringId newId, Dictionary<StringParameterId, string> newParameters = null)
	{
		id = newId;
		parameters = ConvertToStringDictionary(newParameters);
		count = 0;
		isPlural = false;
	}

	public void IntInit(StringId newId, int newCount, Dictionary<StringParameterId, string> newParameters = null)
	{
		id = newId;
		parameters = ConvertToStringDictionary(newParameters);
		count = newCount;
		isPlural = true;
	}

	public void FloatInit(StringId newId, float newCount, Dictionary<StringParameterId, string> newParameters = null)
	{
		id = newId;
		parameters = ConvertToStringDictionary(newParameters);
		if ((float)count < 1f)
		{
			count = Mathf.FloorToInt(newCount);
		}
		else if ((float)count > 1f)
		{
			count = Mathf.CeilToInt(newCount);
		}
		else
		{
			count = 1;
		}
		isPlural = true;
	}

	public override void InitWithStringId(StringId stringId)
	{
		BasicInit(stringId);
	}

	public override void InitWithStringId(StringId stringId, int newCount, Dictionary<string, string> newParameters = null)
	{
		IntInit(stringId, newCount, ConvertToEnumDictionary(newParameters));
	}

	public override void InitWithStringId(StringId stringId, float newCount, Dictionary<string, string> newParameters = null)
	{
		FloatInit(stringId, newCount, ConvertToEnumDictionary(newParameters));
	}

	public override void InitWithString(string stringKey)
	{
		StringId result = StringId.None;
		if (Enum.TryParse<StringId>(stringKey, out result) && result != StringId.None)
		{
			InitWithStringId(result);
		}
	}

	public override void InitWithString(string stringKey, int newCount, Dictionary<string, string> newParameters = null)
	{
		StringId result = StringId.None;
		if (Enum.TryParse<StringId>(stringKey, out result) && result != StringId.None)
		{
			InitWithStringId(result, newCount, newParameters);
		}
	}

	public override void InitWithString(string stringKey, float newCount, Dictionary<string, string> newParameters = null)
	{
		StringId result = StringId.None;
		if (Enum.TryParse<StringId>(stringKey, out result) && result != StringId.None)
		{
			InitWithStringId(result, newCount, newParameters);
		}
	}

	public override void InitWithNonLocalizedString(string nonLocalizedString)
	{
		InitWithStringId(StringId.PassThroughString, 0, new Dictionary<string, string> { { "PassThroughString", nonLocalizedString } });
	}

	public override void Reset()
	{
		id = StringId.None;
		parameters = null;
		count = 0;
		isPlural = false;
	}

	public static implicit operator MotorwaysStringKey(StringId id)
	{
		return new MotorwaysStringKey(id);
	}

	private static Dictionary<string, string> ConvertToStringDictionary(Dictionary<StringParameterId, string> originalParameters)
	{
		if (originalParameters == null)
		{
			return null;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (KeyValuePair<StringParameterId, string> originalParameter in originalParameters)
		{
			dictionary.Add(originalParameter.Key.ToString(), originalParameter.Value);
		}
		return dictionary;
	}

	private static Dictionary<StringParameterId, string> ConvertToEnumDictionary(Dictionary<string, string> originalParameters)
	{
		if (originalParameters == null)
		{
			return null;
		}
		Dictionary<StringParameterId, string> dictionary = new Dictionary<StringParameterId, string>();
		foreach (KeyValuePair<string, string> originalParameter in originalParameters)
		{
			StringParameterId result = StringParameterId.None;
			if (Diagnostics.Verify(Enum.TryParse<StringParameterId>(originalParameter.Key, out result) && result != StringParameterId.None, "Could not convert {0} into a string parameter id", originalParameter.Key))
			{
				dictionary.Add(result, originalParameter.Value);
			}
		}
		return dictionary;
	}

	public override bool Equals(StringKey other)
	{
		if (other is MotorwaysStringKey && (object)other != null)
		{
			MotorwaysStringKey motorwaysStringKey = other as MotorwaysStringKey;
			if (!id.Equals(motorwaysStringKey.id))
			{
				return false;
			}
			if ((parameters != null || motorwaysStringKey.parameters != null) && !parameters.Equals(motorwaysStringKey.parameters))
			{
				return false;
			}
			if (count != motorwaysStringKey.count)
			{
				return false;
			}
			if (isPlural != motorwaysStringKey.isPlural)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public override int GetCount()
	{
		return count;
	}

	public override int GetHashCode()
	{
		int num = id.GetHashCode() ^ count.GetHashCode() ^ isPlural.GetHashCode();
		if (parameters != null)
		{
			num ^= parameters.GetHashCode();
		}
		return num;
	}

	public override Dictionary<string, string> GetParameters()
	{
		return parameters;
	}

	public override string GetStringId()
	{
		return id.ToString();
	}

	public override bool IsPlural()
	{
		return isPlural;
	}
}
