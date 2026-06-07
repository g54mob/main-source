using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal sealed class bOkYhrAZvLuDrbKeuEpFihavppE
{
	private const string QbFEFYJiBYKaNkRyGDmKdGHJfGSm = "Unknown";

	private static readonly object XyGfyibBkQaiJpibDPpNClyiCToV = new object();

	private static readonly List<Type> isGPdXCXaqQrRtvmhNrQcOEncPoc = new List<Type>();

	private static readonly Dictionary<cTKAHZacuViBRtnMbZwDuEpUfDCh, bOkYhrAZvLuDrbKeuEpFihavppE> yYAvtHDFYFcbSLoqSkbsnDQrzBS = new Dictionary<cTKAHZacuViBRtnMbZwDuEpUfDCh, bOkYhrAZvLuDrbKeuEpFihavppE>();

	[CompilerGenerated]
	private cTKAHZacuViBRtnMbZwDuEpUfDCh PmAffnovEiUOXWHdMGfxANRddAvi;

	[CompilerGenerated]
	private string VJZLcMaSIWHhpRFIZEZuAzkzpUME;

	[CompilerGenerated]
	private string rAQwmgQGRKUWkMavedHNUANiWdM;

	[CompilerGenerated]
	private string SerQXafkEvlZhImzIcntCJZZoCu;

	[CompilerGenerated]
	private string kpZyxMFxHURtiiTDYQIAkjLrcEhi;

	public cTKAHZacuViBRtnMbZwDuEpUfDCh Result
	{
		[CompilerGenerated]
		get
		{
			return PmAffnovEiUOXWHdMGfxANRddAvi;
		}
		[CompilerGenerated]
		private set
		{
			PmAffnovEiUOXWHdMGfxANRddAvi = value;
		}
	}

	public int Code => Result.Code;

	public string Module
	{
		[CompilerGenerated]
		get
		{
			return VJZLcMaSIWHhpRFIZEZuAzkzpUME;
		}
		[CompilerGenerated]
		private set
		{
			VJZLcMaSIWHhpRFIZEZuAzkzpUME = value;
		}
	}

	public string NativeApiCode
	{
		[CompilerGenerated]
		get
		{
			return rAQwmgQGRKUWkMavedHNUANiWdM;
		}
		[CompilerGenerated]
		private set
		{
			rAQwmgQGRKUWkMavedHNUANiWdM = value;
		}
	}

	public string ApiCode
	{
		[CompilerGenerated]
		get
		{
			return SerQXafkEvlZhImzIcntCJZZoCu;
		}
		[CompilerGenerated]
		private set
		{
			SerQXafkEvlZhImzIcntCJZZoCu = value;
		}
	}

	public string Description
	{
		[CompilerGenerated]
		get
		{
			return kpZyxMFxHURtiiTDYQIAkjLrcEhi;
		}
		[CompilerGenerated]
		set
		{
			kpZyxMFxHURtiiTDYQIAkjLrcEhi = value;
		}
	}

	public bOkYhrAZvLuDrbKeuEpFihavppE(cTKAHZacuViBRtnMbZwDuEpUfDCh code, string module, string nativeApiCode, string apiCode, string description = null)
	{
		Result = code;
		Module = module;
		NativeApiCode = nativeApiCode;
		ApiCode = apiCode;
		Description = description;
	}

	public bool sDUAvZTXlEIwugPidIgHPcnkQFr(bOkYhrAZvLuDrbKeuEpFihavppE P_0)
	{
		if (object.ReferenceEquals(null, P_0))
		{
			return false;
		}
		if (object.ReferenceEquals(this, P_0))
		{
			return true;
		}
		return P_0.Result.Equals(Result);
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if ((object)obj.GetType() != typeof(bOkYhrAZvLuDrbKeuEpFihavppE))
		{
			return false;
		}
		return sDUAvZTXlEIwugPidIgHPcnkQFr((bOkYhrAZvLuDrbKeuEpFihavppE)obj);
	}

	public override int GetHashCode()
	{
		return Result.GetHashCode();
	}

	public override string ToString()
	{
		return $"HRESULT: [0x{Result.Code:X}], Module: [{Module}], ApiCode: [{NativeApiCode}/{ApiCode}], Message: {Description}";
	}

	public static implicit operator cTKAHZacuViBRtnMbZwDuEpUfDCh(bOkYhrAZvLuDrbKeuEpFihavppE result)
	{
		return result.Result;
	}

	public static explicit operator int(bOkYhrAZvLuDrbKeuEpFihavppE result)
	{
		return result.Result.Code;
	}

	public static explicit operator uint(bOkYhrAZvLuDrbKeuEpFihavppE result)
	{
		return (uint)result.Result.Code;
	}

	public static bool operator ==(bOkYhrAZvLuDrbKeuEpFihavppE left, cTKAHZacuViBRtnMbZwDuEpUfDCh right)
	{
		if (left == null)
		{
			return false;
		}
		return left.Result.Code == right.Code;
	}

	public static bool operator !=(bOkYhrAZvLuDrbKeuEpFihavppE left, cTKAHZacuViBRtnMbZwDuEpUfDCh right)
	{
		if (left == null)
		{
			return false;
		}
		return left.Result.Code != right.Code;
	}

	public static void yzPQYAmObHtdcifUBxDaUPRSYHh(Type P_0)
	{
		lock (XyGfyibBkQaiJpibDPpNClyiCToV)
		{
			if (!isGPdXCXaqQrRtvmhNrQcOEncPoc.Contains(P_0))
			{
				isGPdXCXaqQrRtvmhNrQcOEncPoc.Add(P_0);
			}
		}
	}

	public static bOkYhrAZvLuDrbKeuEpFihavppE PYgQmrazoUqWjrASzZcCXOaxeza(cTKAHZacuViBRtnMbZwDuEpUfDCh P_0)
	{
		bOkYhrAZvLuDrbKeuEpFihavppE value;
		lock (XyGfyibBkQaiJpibDPpNClyiCToV)
		{
			if (isGPdXCXaqQrRtvmhNrQcOEncPoc.Count > 0)
			{
				foreach (Type item in isGPdXCXaqQrRtvmhNrQcOEncPoc)
				{
					pbirfSUEGcqFDKpvhWuGrlTIJLa(item);
				}
				isGPdXCXaqQrRtvmhNrQcOEncPoc.Clear();
			}
			if (!yYAvtHDFYFcbSLoqSkbsnDQrzBS.TryGetValue(P_0, out value))
			{
				value = new bOkYhrAZvLuDrbKeuEpFihavppE(P_0, "Unknown", "Unknown", "Unknown");
			}
			if (value.Description == null)
			{
				string text = vVWqYqZEekPfEjbkQjHaFgyYIHM(P_0.Code);
				value.Description = text ?? "Unknown";
			}
		}
		return value;
	}

	private static void pbirfSUEGcqFDKpvhWuGrlTIJLa(Type P_0)
	{
		FieldInfo[] fields = P_0.GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if ((object)fieldInfo.FieldType == typeof(bOkYhrAZvLuDrbKeuEpFihavppE))
			{
				bOkYhrAZvLuDrbKeuEpFihavppE bOkYhrAZvLuDrbKeuEpFihavppE2 = (bOkYhrAZvLuDrbKeuEpFihavppE)fieldInfo.GetValue(null);
				if (!yYAvtHDFYFcbSLoqSkbsnDQrzBS.ContainsKey(bOkYhrAZvLuDrbKeuEpFihavppE2.Result))
				{
					yYAvtHDFYFcbSLoqSkbsnDQrzBS.Add(bOkYhrAZvLuDrbKeuEpFihavppE2.Result, bOkYhrAZvLuDrbKeuEpFihavppE2);
				}
			}
		}
	}

	private static string vVWqYqZEekPfEjbkQjHaFgyYIHM(int P_0)
	{
		IntPtr zero = IntPtr.Zero;
		grlPGQZjDlQfYofyJqJfHpbXfmD(4864, IntPtr.Zero, P_0, 0, ref zero, 0, IntPtr.Zero);
		string result = Marshal.PtrToStringUni(zero);
		Marshal.FreeHGlobal(zero);
		return result;
	}

	[DllImport("kernel32.dll", EntryPoint = "FormatMessageW")]
	private static extern uint grlPGQZjDlQfYofyJqJfHpbXfmD(int P_0, IntPtr P_1, int P_2, int P_3, ref IntPtr P_4, int P_5, IntPtr P_6);
}
