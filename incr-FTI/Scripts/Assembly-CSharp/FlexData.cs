using System;
using System.Collections.Generic;
using FullSerializer;
using UnityEngine;

public class FlexData
{
	private object _value;

	public bool IsNull => _value == null;

	public Type ValueType => _value.GetType();

	public FlexData()
	{
		_value = null;
	}

	public FlexData(bool boolean)
	{
		_value = boolean;
	}

	public FlexData(float f)
	{
		_value = f;
	}

	public FlexData(int i)
	{
		_value = i;
	}

	public FlexData(string str)
	{
		_value = str;
	}

	public FlexData(Dictionary<string, FlexData> dict)
	{
		_value = dict;
	}

	public FlexData(List<FlexData> list)
	{
		_value = list;
	}

	public bool TryAsString(out string s)
	{
		if (_value is string text)
		{
			s = text;
			return true;
		}
		s = null;
		return false;
	}

	public bool TryAsInt(out int i)
	{
		if (_value is int num)
		{
			i = num;
			return true;
		}
		i = 0;
		return false;
	}

	public bool TryAsBool(out bool b)
	{
		if (_value is bool flag)
		{
			b = flag;
			return true;
		}
		b = false;
		return false;
	}

	public bool TryAsFloat(out float f)
	{
		if (_value is float num)
		{
			f = num;
			return true;
		}
		f = 0f;
		return false;
	}

	public bool TryAsList(out List<FlexData> l)
	{
		if (_value is List<FlexData> list)
		{
			l = list;
			return true;
		}
		l = null;
		return false;
	}

	public bool TryAsDictionary(out Dictionary<string, FlexData> d)
	{
		if (_value is Dictionary<string, FlexData> dictionary)
		{
			d = dictionary;
			return true;
		}
		d = null;
		return false;
	}

	public fsData Serialized()
	{
		if (_value == null)
		{
			return new fsData();
		}
		if (TryAsBool(out var b))
		{
			return new fsData(b);
		}
		if (TryAsInt(out var i))
		{
			return new fsData(i);
		}
		if (TryAsFloat(out var f))
		{
			return new fsData(f);
		}
		if (TryAsString(out var s))
		{
			return new fsData(s);
		}
		if (TryAsList(out var l))
		{
			List<fsData> list = new List<fsData>();
			foreach (FlexData item in l)
			{
				list.Add(item.Serialized());
			}
			return new fsData(list);
		}
		if (TryAsDictionary(out var d))
		{
			Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
			foreach (KeyValuePair<string, FlexData> item2 in d)
			{
				dictionary[item2.Key] = item2.Value.Serialized();
			}
			return new fsData(dictionary);
		}
		Debug.LogError("Unable to store flexData type: " + this);
		return new fsData();
	}

	public static FlexData Deserialized(fsData sourceData)
	{
		if (sourceData.IsNull)
		{
			return new FlexData();
		}
		if (sourceData.TryAsInt(out var i))
		{
			return new FlexData(i);
		}
		if (sourceData.TryAsString(out var s))
		{
			return new FlexData(s);
		}
		if (sourceData.TryAsBool(out var b))
		{
			return new FlexData(b);
		}
		if (sourceData.TryAsDouble(out var f))
		{
			return new FlexData((float)f);
		}
		if (sourceData.IsList)
		{
			List<FlexData> list = new List<FlexData>();
			foreach (fsData @as in sourceData.AsList)
			{
				list.Add(Deserialized(@as));
			}
			return new FlexData(list);
		}
		if (sourceData.IsDictionary)
		{
			Dictionary<string, FlexData> dictionary = new Dictionary<string, FlexData>();
			foreach (KeyValuePair<string, fsData> item in sourceData.AsDictionary)
			{
				dictionary[item.Key] = Deserialized(item.Value);
			}
			return new FlexData(dictionary);
		}
		Debug.LogError("Unable to deserialize to flexData. fsData type: " + sourceData.Type);
		return null;
	}

	public override string ToString()
	{
		if (_value != null)
		{
			return _value.GetType()?.ToString() + ":" + _value;
		}
		return "NULL";
	}
}
