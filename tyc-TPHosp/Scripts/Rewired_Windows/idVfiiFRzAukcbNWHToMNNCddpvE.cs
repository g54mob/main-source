using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal sealed class idVfiiFRzAukcbNWHToMNNCddpvE
{
	private const string HfuhJQrneXykSzqphUfldmOyMYb = "Unknown";

	private static readonly object YihAIdCGqLoriShBeBuoSDEbFhu = new object();

	private static readonly List<Type> lzpHkOJWSvfJgPiiQRPlHTfcVqy = new List<Type>();

	private static readonly Dictionary<llpFqWliQEfHkPmCCWtyJDAPdFG, idVfiiFRzAukcbNWHToMNNCddpvE> fmxVLUELdOBatdDsvrIPMJoyztG = new Dictionary<llpFqWliQEfHkPmCCWtyJDAPdFG, idVfiiFRzAukcbNWHToMNNCddpvE>();

	[CompilerGenerated]
	private llpFqWliQEfHkPmCCWtyJDAPdFG SVtHIynzmrUNoqjpvEZAjTyqdCd;

	[CompilerGenerated]
	private string SQeIeFhSkDdmObHUmFzVQARqBUGE;

	[CompilerGenerated]
	private string kSdrQjTRdXDIVecbDNhebDstVdS;

	[CompilerGenerated]
	private string JrIncnqZmaxjUgOblYMOfpuUPyi;

	[CompilerGenerated]
	private string zueFNHCafBbMZCvTbsddNQgqMOv;

	public llpFqWliQEfHkPmCCWtyJDAPdFG Result
	{
		[CompilerGenerated]
		get
		{
			return SVtHIynzmrUNoqjpvEZAjTyqdCd;
		}
		[CompilerGenerated]
		private set
		{
			SVtHIynzmrUNoqjpvEZAjTyqdCd = value;
		}
	}

	public int Code => Result.Code;

	public string Module
	{
		[CompilerGenerated]
		get
		{
			return SQeIeFhSkDdmObHUmFzVQARqBUGE;
		}
		[CompilerGenerated]
		private set
		{
			SQeIeFhSkDdmObHUmFzVQARqBUGE = value;
		}
	}

	public string NativeApiCode
	{
		[CompilerGenerated]
		get
		{
			return kSdrQjTRdXDIVecbDNhebDstVdS;
		}
		[CompilerGenerated]
		private set
		{
			kSdrQjTRdXDIVecbDNhebDstVdS = value;
		}
	}

	public string ApiCode
	{
		[CompilerGenerated]
		get
		{
			return JrIncnqZmaxjUgOblYMOfpuUPyi;
		}
		[CompilerGenerated]
		private set
		{
			JrIncnqZmaxjUgOblYMOfpuUPyi = value;
		}
	}

	public string Description
	{
		[CompilerGenerated]
		get
		{
			return zueFNHCafBbMZCvTbsddNQgqMOv;
		}
		[CompilerGenerated]
		set
		{
			zueFNHCafBbMZCvTbsddNQgqMOv = value;
		}
	}

	public idVfiiFRzAukcbNWHToMNNCddpvE(llpFqWliQEfHkPmCCWtyJDAPdFG code, string module, string nativeApiCode, string apiCode, string description = null)
	{
		Result = code;
		Module = module;
		NativeApiCode = nativeApiCode;
		ApiCode = apiCode;
		Description = description;
	}

	public bool lpfGDOSkHRGqZKIqCGEaicWfABrw(idVfiiFRzAukcbNWHToMNNCddpvE P_0)
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
		if ((object)obj.GetType() != typeof(idVfiiFRzAukcbNWHToMNNCddpvE))
		{
			return false;
		}
		return lpfGDOSkHRGqZKIqCGEaicWfABrw((idVfiiFRzAukcbNWHToMNNCddpvE)obj);
	}

	public override int GetHashCode()
	{
		return Result.GetHashCode();
	}

	public override string ToString()
	{
		return $"HRESULT: [0x{Result.Code:X}], Module: [{Module}], ApiCode: [{NativeApiCode}/{ApiCode}], Message: {Description}";
	}

	public static implicit operator llpFqWliQEfHkPmCCWtyJDAPdFG(idVfiiFRzAukcbNWHToMNNCddpvE result)
	{
		return result.Result;
	}

	public static explicit operator int(idVfiiFRzAukcbNWHToMNNCddpvE result)
	{
		return result.Result.Code;
	}

	public static explicit operator uint(idVfiiFRzAukcbNWHToMNNCddpvE result)
	{
		return (uint)result.Result.Code;
	}

	public static bool operator ==(idVfiiFRzAukcbNWHToMNNCddpvE left, llpFqWliQEfHkPmCCWtyJDAPdFG right)
	{
		if (left == null)
		{
			return false;
		}
		return left.Result.Code == right.Code;
	}

	public static bool operator !=(idVfiiFRzAukcbNWHToMNNCddpvE left, llpFqWliQEfHkPmCCWtyJDAPdFG right)
	{
		if (left == null)
		{
			return false;
		}
		return left.Result.Code != right.Code;
	}

	public static void dukxwPlcqOelPhKYiKZXDdsLYIdW(Type P_0)
	{
		lock (YihAIdCGqLoriShBeBuoSDEbFhu)
		{
			if (!lzpHkOJWSvfJgPiiQRPlHTfcVqy.Contains(P_0))
			{
				lzpHkOJWSvfJgPiiQRPlHTfcVqy.Add(P_0);
			}
		}
	}

	public static idVfiiFRzAukcbNWHToMNNCddpvE SnXWYarLWHAxUNNKUUfbiwNydPi(llpFqWliQEfHkPmCCWtyJDAPdFG P_0)
	{
		idVfiiFRzAukcbNWHToMNNCddpvE value;
		lock (YihAIdCGqLoriShBeBuoSDEbFhu)
		{
			if (lzpHkOJWSvfJgPiiQRPlHTfcVqy.Count > 0)
			{
				foreach (Type item in lzpHkOJWSvfJgPiiQRPlHTfcVqy)
				{
					uoRVPFZtitauwaZfSSizSKcNAVw(item);
				}
				lzpHkOJWSvfJgPiiQRPlHTfcVqy.Clear();
			}
			if (!fmxVLUELdOBatdDsvrIPMJoyztG.TryGetValue(P_0, out value))
			{
				value = new idVfiiFRzAukcbNWHToMNNCddpvE(P_0, "Unknown", "Unknown", "Unknown");
			}
			if (value.Description == null)
			{
				string text = eshGMTEUmfQBzFVxnFDTokZHGCYs(P_0.Code);
				value.Description = text ?? "Unknown";
			}
		}
		return value;
	}

	private static void uoRVPFZtitauwaZfSSizSKcNAVw(Type P_0)
	{
		FieldInfo[] fields = P_0.GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if ((object)fieldInfo.FieldType == typeof(idVfiiFRzAukcbNWHToMNNCddpvE))
			{
				idVfiiFRzAukcbNWHToMNNCddpvE idVfiiFRzAukcbNWHToMNNCddpvE2 = (idVfiiFRzAukcbNWHToMNNCddpvE)fieldInfo.GetValue(null);
				if (!fmxVLUELdOBatdDsvrIPMJoyztG.ContainsKey(idVfiiFRzAukcbNWHToMNNCddpvE2.Result))
				{
					fmxVLUELdOBatdDsvrIPMJoyztG.Add(idVfiiFRzAukcbNWHToMNNCddpvE2.Result, idVfiiFRzAukcbNWHToMNNCddpvE2);
				}
			}
		}
	}

	private static string eshGMTEUmfQBzFVxnFDTokZHGCYs(int P_0)
	{
		IntPtr zero = IntPtr.Zero;
		rnGFzVaYXkEMhQAektEObiGIJrXa(4864, IntPtr.Zero, P_0, 0, ref zero, 0, IntPtr.Zero);
		string result = Marshal.PtrToStringUni(zero);
		Marshal.FreeHGlobal(zero);
		return result;
	}

	[DllImport("kernel32.dll", EntryPoint = "FormatMessageW")]
	private static extern uint rnGFzVaYXkEMhQAektEObiGIJrXa(int P_0, IntPtr P_1, int P_2, int P_3, ref IntPtr P_4, int P_5, IntPtr P_6);
}
