using System;

namespace Motorways.Audio
{
	public class Attribute
	{
		private enum ValueType
		{
			BOOLEAN = 0,
			INTEGER = 1,
			INTEGER_ARRAY = 2,
			FLOAT = 3,
			FLOAT_ARRAY = 4,
			STRING = 5,
			STRING_ARRAY = 6
		}

		private ValueType type;

		private object val;

		public bool GetBool(AudioLoadout loadout = null)
		{
			if (type == ValueType.BOOLEAN)
			{
				return (bool)val;
			}
			if (type == ValueType.STRING && loadout != null)
			{
				Attribute constant = loadout.GetConstant(GetString());
				if (constant != null)
				{
					return constant.GetBool();
				}
			}
			Diagnostics.FailAssert("GetFloat() failed for attribute {0}.", this);
			return false;
		}

		public int GetInt(AudioLoadout loadout = null)
		{
			if (type == ValueType.INTEGER)
			{
				return (int)val;
			}
			if (type == ValueType.STRING && loadout != null)
			{
				Attribute constant = loadout.GetConstant(GetString());
				if (constant != null)
				{
					return constant.GetInt();
				}
			}
			Diagnostics.FailAssert("GetInt() failed for attribute {0}.", this);
			return 0;
		}

		public int[] GetIntArray(AudioLoadout loadout = null)
		{
			if (type == ValueType.INTEGER_ARRAY)
			{
				return val as int[];
			}
			if (type == ValueType.INTEGER)
			{
				return new int[1] { GetInt() };
			}
			if (type == ValueType.STRING && loadout != null)
			{
				Attribute constant = loadout.GetConstant(GetString());
				if (constant != null)
				{
					return constant.GetIntArray();
				}
			}
			Diagnostics.FailAssert("GetIntArray() failed for attribute {0}.", this);
			return null;
		}

		public float GetFloat(AudioLoadout loadout = null)
		{
			if (type == ValueType.FLOAT)
			{
				return (float)val;
			}
			if (type == ValueType.INTEGER)
			{
				return GetInt();
			}
			if (type == ValueType.STRING && loadout != null)
			{
				Attribute constant = loadout.GetConstant(GetString());
				if (constant != null)
				{
					return constant.GetFloat();
				}
			}
			Diagnostics.FailAssert("GetFloat() failed for attribute {0}.", this);
			return 0f;
		}

		public float[] GetFloatArray(AudioLoadout loadout = null)
		{
			if (type == ValueType.FLOAT_ARRAY)
			{
				return val as float[];
			}
			if (type == ValueType.FLOAT)
			{
				return new float[1] { GetFloat() };
			}
			if (type == ValueType.INTEGER_ARRAY)
			{
				int[] array = val as int[];
				float[] array2 = new float[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = array[i];
				}
				return array2;
			}
			if (type == ValueType.INTEGER)
			{
				return new float[1] { GetInt() };
			}
			if (type == ValueType.STRING && loadout != null)
			{
				Attribute constant = loadout.GetConstant(GetString());
				if (constant != null)
				{
					return constant.GetFloatArray();
				}
			}
			Diagnostics.FailAssert("GetFloatArray() failed for attribute {0}.", this);
			return null;
		}

		public string GetString(AudioLoadout loadout = null)
		{
			if (type == ValueType.STRING)
			{
				if (loadout != null)
				{
					Attribute constant = loadout.GetConstant(GetString());
					if (constant != null)
					{
						return constant.GetString();
					}
				}
				return val as string;
			}
			Diagnostics.FailAssert("GetString() failed for attribute {0}.", this);
			return null;
		}

		public string[] GetStringArray(AudioLoadout loadout = null)
		{
			if (type == ValueType.STRING_ARRAY)
			{
				return val as string[];
			}
			if (type == ValueType.STRING)
			{
				if (loadout != null)
				{
					Attribute constant = loadout.GetConstant(GetString());
					if (constant != null)
					{
						return constant.GetStringArray();
					}
				}
				return new string[1] { GetString() };
			}
			Diagnostics.FailAssert("GetFloat() failed for attribute {0}.", this);
			return null;
		}

		public override string ToString()
		{
			return $"[Attribute Type={type}, Value={val}]";
		}

		public static Attribute FromJSON(object jsonAttribute)
		{
			if (jsonAttribute == null)
			{
				return null;
			}
			Attribute attribute = new Attribute();
			if (jsonAttribute is bool)
			{
				attribute.type = ValueType.BOOLEAN;
				attribute.val = (bool)jsonAttribute;
			}
			else if (jsonAttribute is long)
			{
				attribute.type = ValueType.INTEGER;
				attribute.val = Convert.ToInt32((long)jsonAttribute);
			}
			else if (jsonAttribute is string)
			{
				attribute.type = ValueType.STRING;
				attribute.val = string.Copy(jsonAttribute as string);
			}
			else if (jsonAttribute is JSON.Array)
			{
				JSON.Array array = jsonAttribute as JSON.Array;
				if (array.Count <= 0)
				{
					return null;
				}
				if (array[0] is string)
				{
					attribute.type = ValueType.STRING_ARRAY;
					string[] array2 = new string[array.Count];
					for (int i = 0; i < array.Count; i++)
					{
						array2[i] = array.GetString(i);
					}
					attribute.val = array2;
				}
				else
				{
					attribute.type = ValueType.INTEGER_ARRAY;
					for (int j = 0; j < array.Count; j++)
					{
						if (!(array[j] is long))
						{
							attribute.type = ValueType.FLOAT_ARRAY;
							break;
						}
					}
					if (attribute.type == ValueType.INTEGER_ARRAY)
					{
						int[] array3 = new int[array.Count];
						for (int k = 0; k < array.Count; k++)
						{
							array3[k] = array.GetInt(k);
						}
						attribute.val = array3;
					}
					else
					{
						float[] array4 = new float[array.Count];
						for (int l = 0; l < array.Count; l++)
						{
							array4[l] = array.GetFloat(l);
						}
						attribute.val = array4;
					}
				}
			}
			else
			{
				try
				{
					attribute.type = ValueType.FLOAT;
					attribute.val = Convert.ToSingle(jsonAttribute);
				}
				catch
				{
					return null;
				}
			}
			return attribute;
		}
	}
}
