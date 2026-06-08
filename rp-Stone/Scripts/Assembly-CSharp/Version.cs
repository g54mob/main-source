using System;
using SafeTypes;
using UnityEngine;

public struct Version
{
	private SafeInt _major;

	private SafeInt _minor;

	private SafeInt _revision;

	public int major => _major.GetValue();

	public int minor => _minor.GetValue();

	public int revision => _revision.GetValue();

	public Version(int major, int minor, int revision)
	{
		_major = new SafeInt(major);
		_minor = new SafeInt(minor);
		_revision = new SafeInt(revision);
	}

	public override string ToString()
	{
		return major + "." + minor + "." + revision;
	}

	public static Version FromString(string str)
	{
		Version result = default(Version);
		if (!string.IsNullOrEmpty(str))
		{
			string[] array = str.Split(new char[1] { '.' });
			if (array.Length == 3)
			{
				try
				{
					result._major = new SafeInt(Utils.ParseInt(array[0]));
					result._minor = new SafeInt(Utils.ParseInt(array[1]));
					result._revision = new SafeInt(Utils.ParseInt(array[2]));
				}
				catch (Exception ex)
				{
					Utils.LogError(ex.StackTrace);
				}
			}
		}
		return result;
	}

	public int ToNumber()
	{
		return major * 10000 + minor * 100 + revision;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		Version version = (Version)obj;
		if (major == version.major && minor == version.minor)
		{
			return revision == version.revision;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return major * 1000000 + minor * 1000 + revision;
	}

	public static bool operator ==(Version v1, Version v2)
	{
		if (v1.major == v2.major && v1.minor == v2.minor)
		{
			return v1.revision == v2.revision;
		}
		return false;
	}

	public static bool operator !=(Version v1, Version v2)
	{
		if (v1.major == v2.major && v1.minor == v2.minor)
		{
			return v1.revision != v2.revision;
		}
		return true;
	}

	public static bool operator <(Version v1, Version v2)
	{
		if (v1.major < v2.major)
		{
			return true;
		}
		if (v1.major == v2.major && v1.minor < v2.minor)
		{
			return true;
		}
		if (v1.major == v2.major && v1.minor == v2.minor && v1.revision < v2.revision)
		{
			return true;
		}
		return false;
	}

	public static bool operator >(Version v1, Version v2)
	{
		if (v1.major > v2.major)
		{
			return true;
		}
		if (v1.major == v2.major && v1.minor > v2.minor)
		{
			return true;
		}
		if (v1.major == v2.major && v1.minor == v2.minor && v1.revision > v2.revision)
		{
			return true;
		}
		return false;
	}

	public static bool operator <=(Version v1, Version v2)
	{
		if (!(v1 < v2))
		{
			return v1 == v2;
		}
		return true;
	}

	public static bool operator >=(Version v1, Version v2)
	{
		if (!(v1 > v2))
		{
			return v1 == v2;
		}
		return true;
	}

	public static void Test()
	{
		Version version = new Version(10, 5, 99);
		Version version2 = new Version(10, 5, 99);
		Version version3 = new Version(10, 5, 100);
		Version version4 = new Version(10, 6, 0);
		Version version5 = new Version(9, 0, 0);
		Version version6 = new Version(11, 0, 0);
		Debug.Log("Testing Version struct");
		Version version7 = version;
		Debug.Log("v1 = " + version7.ToString());
		version7 = version2;
		Debug.Log("v2 = " + version7.ToString());
		version7 = version3;
		Debug.Log("v3 = " + version7.ToString());
		version7 = version4;
		Debug.Log("v4 = " + version7.ToString());
		version7 = version5;
		Debug.Log("v5 = " + version7.ToString());
		bool condition = version == version2;
		version7 = version;
		string text = version7.ToString();
		version7 = version2;
		int num = 1 & (_test(condition, text + " == " + version7.ToString()) ? 1 : 0);
		bool condition2 = version != version3;
		version7 = version;
		string text2 = version7.ToString();
		version7 = version3;
		int num2 = num & (_test(condition2, text2 + " != " + version7.ToString()) ? 1 : 0);
		bool condition3 = version3 > version;
		version7 = version3;
		string text3 = version7.ToString();
		version7 = version;
		int num3 = num2 & (_test(condition3, text3 + " > " + version7.ToString()) ? 1 : 0);
		bool condition4 = version < version3;
		version7 = version;
		string text4 = version7.ToString();
		version7 = version3;
		int num4 = num3 & (_test(condition4, text4 + " < " + version7.ToString()) ? 1 : 0);
		bool condition5 = version < version4;
		version7 = version;
		string text5 = version7.ToString();
		version7 = version4;
		int num5 = num4 & (_test(condition5, text5 + " < " + version7.ToString()) ? 1 : 0);
		bool condition6 = version > version5;
		version7 = version;
		string text6 = version7.ToString();
		version7 = version5;
		int num6 = num5 & (_test(condition6, text6 + " > " + version7.ToString()) ? 1 : 0);
		bool condition7 = version < version6;
		version7 = version;
		string text7 = version7.ToString();
		version7 = version6;
		if (((uint)num6 & (_test(condition7, text7 + " < " + version7.ToString()) ? 1u : 0u) & (_test(version.ToString() == FromString(version.ToString()).ToString(), "Serialize and Parse") ? 1u : 0u)) != 0)
		{
			Debug.Log("Passed");
		}
		else
		{
			Debug.LogError("Failed");
		}
	}

	private static bool _test(bool condition, string message)
	{
		if (condition)
		{
			Debug.Log(message);
		}
		else
		{
			Debug.LogWarning(message);
		}
		return condition;
	}
}
