using System;
using UnityEngine;
using UnityEngine.UI;

public class Versioning : MonoBehaviour
{
	public enum VersionType
	{
		PreAlpha = 0,
		Alpha = 1,
		Beta = 2,
		Release = 3
	}

	public struct Version
	{
		public readonly string Type;

		public readonly int TypeInt;

		public readonly int Major;

		public readonly int Minor;

		public readonly int Revision;

		public readonly bool Steam;

		public readonly bool Demo;

		public float SortNumber
		{
			get
			{
				return (float)TypeInt + ((float)Major + (float)Minor / 100f / 100f);
			}
		}

		public Version(string t, int m, int mi, int r, bool s, bool d)
		{
			TypeInt = Array.IndexOf(Types, t);
			if (TypeInt < 0)
			{
				TypeInt = 2;
			}
			Type = Types[TypeInt];
			Major = m;
			Minor = mi;
			Revision = r;
			Steam = s;
			Demo = d;
		}

		public Version(VersionType t, int m, int mi, int r)
			: this((int)t, m, mi, r, false, false)
		{
		}

		public Version(VersionType t, int m, int mi, int r, bool s, bool d)
			: this((int)t, m, mi, r, s, d)
		{
		}

		public Version(int t, int m, int mi, int r, bool s, bool d)
		{
			Type = Types[t];
			TypeInt = t;
			Major = m;
			Minor = mi;
			Revision = r;
			Steam = s;
			Demo = d;
		}

		public override string ToString()
		{
			return SimpleVersion();
		}

		public string SimpleVersion()
		{
			return Type + " " + Major + "." + Minor + "." + Revision;
		}

		public static bool operator <(Version v1, Version v2)
		{
			return v1.Before(v2);
		}

		public static bool operator >(Version v1, Version v2)
		{
			return v2 < v1;
		}

		public bool Before(Version v, int order = 3)
		{
			if (TypeInt < v.TypeInt)
			{
				return true;
			}
			if (order > 0 && TypeInt == v.TypeInt && Major < v.Major)
			{
				return true;
			}
			if (order > 1 && TypeInt == v.TypeInt && Major == v.Major && Minor < v.Minor)
			{
				return true;
			}
			if (order > 2 && TypeInt == v.TypeInt && Major == v.Major && Minor == v.Minor && Revision < v.Revision)
			{
				return true;
			}
			return false;
		}

		public bool EqualsSimple(Version v)
		{
			if (TypeInt == v.TypeInt && Major == v.Major && Minor == v.Minor)
			{
				return Revision == v.Revision;
			}
			return false;
		}
	}

	public static readonly string[] Types = new string[4] { "Pre-alpha", "Alpha", "Beta", "Release" };

	public const int Type = 2;

	public const int Major = 1;

	public const int Minor = 8;

	public const int Revision = 41;

	public static bool Demo = false;

	public static bool Steam = true;

	public Text text;

	public static readonly Version CurrentVersion = new Version(2, 1, 8, 41, Steam, Demo);

	public VersionType TypeEnum
	{
		get
		{
			return VersionType.Beta;
		}
	}

	public static string VersionString
	{
		get
		{
			return Types[2] + (Steam ? " Steam" : "") + (Demo ? " Demo" : "") + " " + 1 + "." + 8 + "." + 41 + ", " + GetPlatform();
		}
	}

	public static string NetworkVersionString
	{
		get
		{
			return string.Concat(Types[2] + (Steam ? " Steam" : "") + (Demo ? " Demo" : "") + " " + 1 + "." + 8 + "." + 41, ", ", GetPlatform());
		}
	}

	public static string SimpleVersionString
	{
		get
		{
			return Types[2] + " " + 1 + "." + 8 + "." + 41;
		}
	}

	public static string AlmostExtremelySimpleVersionString
	{
		get
		{
			return Types[2] + 1 + "_" + 8;
		}
	}

	public static string ExtremelySimpleVersionString
	{
		get
		{
			return Types[2] + 1;
		}
	}

	public static string TypeVersionString
	{
		get
		{
			return Types[2];
		}
	}

	public static string SimpleNetworkVersionString
	{
		get
		{
			return SimpleVersionString ?? "";
		}
	}

	public static string GetPlatform()
	{
		return Application.platform.ToString() + "x64";
	}

	private void Start()
	{
		UpdateText();
		Options.LastVersion = SimpleVersionString;
	}

	public static Version DisectVersionString(string v)
	{
		string[] array = v.Split(' ');
		string t = "";
		int major = 0;
		int minor = 0;
		int revision = 0;
		bool d = false;
		bool flag = false;
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			switch (i)
			{
			case 0:
				t = text;
				continue;
			case 1:
				if (text.Equals("Demo"))
				{
					d = true;
					continue;
				}
				if (text.Equals("Steam"))
				{
					flag = true;
					continue;
				}
				DissectVersionNum(text, ref major, ref minor, ref revision);
				break;
			case 2:
				if (flag)
				{
					if (text.Equals("Demo"))
					{
						d = true;
						continue;
					}
					DissectVersionNum(text, ref major, ref minor, ref revision);
				}
				else
				{
					DissectVersionNum(text, ref major, ref minor, ref revision);
				}
				break;
			case 3:
				DissectVersionNum(text, ref major, ref minor, ref revision);
				break;
			default:
				continue;
			}
			break;
		}
		return new Version(t, major, minor, revision, flag, d);
	}

	private static void DissectVersionNum(string t, ref int major, ref int minor, ref int revision)
	{
		t = t.Replace(",", "");
		if (t.Contains("."))
		{
			string[] array = t.Split('.');
			major = Convert.ToInt32(array[0]);
			minor = array[1].ConvertToIntDef(0);
			if (array.Length > 2)
			{
				int num = 0;
				string text = array[2];
				for (int i = 0; i < text.Length && char.IsDigit(text[i]); i++)
				{
					num = i + 1;
				}
				if (num > 0)
				{
					revision = text.Substring(0, num).ConvertToIntDef(0);
				}
			}
		}
		else
		{
			major = Convert.ToInt32(t);
			minor = 0;
		}
	}

	private void UpdateText()
	{
		text.text = NetworkVersionString;
	}
}
