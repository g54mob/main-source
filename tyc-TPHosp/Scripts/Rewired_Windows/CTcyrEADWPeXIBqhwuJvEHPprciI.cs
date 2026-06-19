using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

internal abstract class CTcyrEADWPeXIBqhwuJvEHPprciI<T, TRaw, TUpdate> : IjkegEPrDSfSQxHJscncTBxwdrY where T : class, global::slgsKTDRGmBruGFKLTFOPLqJxXF<TRaw, TUpdate>, new() where TRaw : struct where TUpdate : struct, nDrEgNGnTRWwjtbFlemJsFzwuXR
{
	private OBGtZTCXiKwDVJYTQAavOZxNbIC xVWwRXXoqtXtsAcUGcERjKHZXFN;

	private readonly Dictionary<string, GazyhpdlSwyAWHHvxFhJfxUxIyK> jqYEpqsWlCjlRCKRCpmOvkMeFQM = new Dictionary<string, GazyhpdlSwyAWHHvxFhJfxUxIyK>();

	private static readonly TUpdate[] iQwjaTNvNGhSKEqrVdRoRnpWhpB = new TUpdate[0];

	protected CTcyrEADWPeXIBqhwuJvEHPprciI(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	protected CTcyrEADWPeXIBqhwuJvEHPprciI(qlIBtAfuFtdSnDfdAlXLqIlaFZjt directInput, Guid deviceGuid)
		: base(directInput, deviceGuid)
	{
		OBGtZTCXiKwDVJYTQAavOZxNbIC oBGtZTCXiKwDVJYTQAavOZxNbIC = OvlbOGvZsisFYJaBGbkEXMAFvWr();
		eOgmCPhGFikZdOFYBWPODWcMKGH(oBGtZTCXiKwDVJYTQAavOZxNbIC);
	}

	public unsafe TUpdate[] XyFAnWmnaonXApOdaUnTFsbAQxq()
	{
		TUpdate[] result = iQwjaTNvNGhSKEqrVdRoRnpWhpB;
		int num = QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<mdImBCFyowBgSYIvIsqqBkGUcTH>();
		int num2 = -1;
		FrjNuDQFVlcyAapcnJhsQjeFDdS(num, IntPtr.Zero, ref num2, 1);
		if (num2 == 0)
		{
			return result;
		}
		mdImBCFyowBgSYIvIsqqBkGUcTH* ptr = stackalloc mdImBCFyowBgSYIvIsqqBkGUcTH[num2];
		FrjNuDQFVlcyAapcnJhsQjeFDdS(num, (IntPtr)ptr, ref num2, 0);
		if (num2 == 0)
		{
			return result;
		}
		result = new TUpdate[num2];
		for (int i = 0; i < num2; i++)
		{
			result[i] = new TUpdate
			{
				RawOffset = ptr[i].vWDCHhwuXPHeHeeYshRgNHYNPtE,
				Value = ptr[i].gkSLMNIyLcKlncULGDGOWrfGLDs,
				Timestamp = ptr[i].dAyaFpGlJjBSXNqyATXvcywclAN,
				Sequence = ptr[i].PrpzCcSRdjhxaHAtJMXYBVkWMeqb
			};
		}
		return result;
	}

	public void oFkohWofHCkHIodLpLmPneXvDUSB(T P_0)
	{
		hLSGVQNOyzELOWjeFiJiwuWDSHd(ref P_0);
	}

	public T hLSGVQNOyzELOWjeFiJiwuWDSHd()
	{
		T result = new T();
		hLSGVQNOyzELOWjeFiJiwuWDSHd(ref result);
		return result;
	}

	public unsafe void hLSGVQNOyzELOWjeFiJiwuWDSHd(ref T P_0)
	{
		int num = QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<TRaw>();
		byte* ptr = stackalloc byte[(int)(uint)(num * 2)];
		VWNtYPEHghLFAXEpDpLGAjLUCjR(num, (IntPtr)ptr);
		IntPtr intPtr = (IntPtr)ptr;
		P_0.jgUKJdlhVlbmjmcGcqukHIxicKDF(intPtr);
	}

	public QFSOxzhPpyaLqYMwQgtmifgAXZG vXDndfWaNvLTWQbtRwgpnABdbtA(string P_0)
	{
		return aEUHfvKCmTCLKBlgUaqfmRAYaGqP(dZaAeNdPNRmrdGAOegqxJsEdhbNS(P_0).Offset, jzYvqdeZPTOwnnDgtSlmjPWqvod.sqcAafdpPUdHnnrFnigZhitKTGP);
	}

	public VHVhSvSempGgLauqsaxEJZxYows MrigwnaBfBSwgfkcinJaqYiASNVr(string P_0)
	{
		return new VHVhSvSempGgLauqsaxEJZxYows(this, dZaAeNdPNRmrdGAOegqxJsEdhbNS(P_0).Offset, jzYvqdeZPTOwnnDgtSlmjPWqvod.sqcAafdpPUdHnnrFnigZhitKTGP);
	}

	private GazyhpdlSwyAWHHvxFhJfxUxIyK dZaAeNdPNRmrdGAOegqxJsEdhbNS(string P_0)
	{
		if (!jqYEpqsWlCjlRCKRCpmOvkMeFQM.TryGetValue(P_0, out var value))
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid name [{0}]. Must be in [{1}]", new object[2]
			{
				P_0,
				QvyMHYIdbHWMtWGQBjyLybggaNAi.TrOgnwDXldYAiczZEbzuYfkxxbo(";", jqYEpqsWlCjlRCKRCpmOvkMeFQM.Keys)
			}));
		}
		return value;
	}

	private OBGtZTCXiKwDVJYTQAavOZxNbIC OvlbOGvZsisFYJaBGbkEXMAFvWr()
	{
		if (xVWwRXXoqtXtsAcUGcERjKHZXFN == null)
		{
			if (typeof(ArWXVeyDolAYMGpQocHdFGwMWoMY).IsAssignableFrom(typeof(TRaw)))
			{
				ArWXVeyDolAYMGpQocHdFGwMWoMY arWXVeyDolAYMGpQocHdFGwMWoMY = (ArWXVeyDolAYMGpQocHdFGwMWoMY)(object)default(TRaw);
				xVWwRXXoqtXtsAcUGcERjKHZXFN = new OBGtZTCXiKwDVJYTQAavOZxNbIC(arWXVeyDolAYMGpQocHdFGwMWoMY.Flags)
				{
					vrUgZnbMlYERXMlYNGcJMwxzdSsC = QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<TRaw>(),
					ObjectsFormat = arWXVeyDolAYMGpQocHdFGwMWoMY.ObjectsFormat
				};
			}
			else
			{
				object[] customAttributes = typeof(TRaw).GetCustomAttributes(typeof(UwpMYDtwWFghIwjNBneiQSoVdeV), inherit: false);
				if (customAttributes.Length != 1)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The structure [{0}] must be marked with DataFormatAttribute or provide a IDataFormatProvider", new object[1] { typeof(TRaw).FullName }));
				}
				xVWwRXXoqtXtsAcUGcERjKHZXFN = new OBGtZTCXiKwDVJYTQAavOZxNbIC(((UwpMYDtwWFghIwjNBneiQSoVdeV)customAttributes[0]).tUBXRZljfAUzITeLSNnlnxnnsCR)
				{
					vrUgZnbMlYERXMlYNGcJMwxzdSsC = QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<TRaw>()
				};
				List<GazyhpdlSwyAWHHvxFhJfxUxIyK> list = new List<GazyhpdlSwyAWHHvxFhJfxUxIyK>();
				FieldInfo[] fields = typeof(TRaw).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					object[] customAttributes2 = fieldInfo.GetCustomAttributes(typeof(LOnVCleNikbYBjDvPvBQatIolNl), inherit: false);
					if (customAttributes2.Length <= 0)
					{
						continue;
					}
					int num = Marshal.OffsetOf(typeof(TRaw), fieldInfo.Name).ToInt32();
					int num2 = Marshal.SizeOf(fieldInfo.FieldType);
					int num3 = num;
					int num4 = 0;
					for (int j = 0; j < customAttributes2.Length; j++)
					{
						LOnVCleNikbYBjDvPvBQatIolNl lOnVCleNikbYBjDvPvBQatIolNl = (LOnVCleNikbYBjDvPvBQatIolNl)customAttributes2[j];
						num4 += ((lOnVCleNikbYBjDvPvBQatIolNl.bSDCkwASJRmYJttcAShmUPauoJVA == 0) ? 1 : lOnVCleNikbYBjDvPvBQatIolNl.bSDCkwASJRmYJttcAShmUPauoJVA);
					}
					int num5 = num2 / num4;
					if (num5 * num4 != num2)
					{
						throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Field [{0}] has incompatible size [{1}] and number of DataObjectAttributes [{2}]", new object[3]
						{
							fieldInfo.Name,
							(double)num2 / (double)num4,
							num4
						}));
					}
					int num6 = 0;
					for (int k = 0; k < customAttributes2.Length; k++)
					{
						LOnVCleNikbYBjDvPvBQatIolNl lOnVCleNikbYBjDvPvBQatIolNl2 = (LOnVCleNikbYBjDvPvBQatIolNl)customAttributes2[k];
						num4 = ((lOnVCleNikbYBjDvPvBQatIolNl2.bSDCkwASJRmYJttcAShmUPauoJVA == 0) ? 1 : lOnVCleNikbYBjDvPvBQatIolNl2.bSDCkwASJRmYJttcAShmUPauoJVA);
						for (int l = 0; l < num4; l++)
						{
							GazyhpdlSwyAWHHvxFhJfxUxIyK gazyhpdlSwyAWHHvxFhJfxUxIyK = new GazyhpdlSwyAWHHvxFhJfxUxIyK(string.IsNullOrEmpty(lOnVCleNikbYBjDvPvBQatIolNl2.lkVvBRJSCRwvsYtaixyHqlcbyyy) ? Guid.Empty : new Guid(lOnVCleNikbYBjDvPvBQatIolNl2.lkVvBRJSCRwvsYtaixyHqlcbyyy), num3, lOnVCleNikbYBjDvPvBQatIolNl2.ZWptxVfEACgzTXmabCFSwnArmMI, lOnVCleNikbYBjDvPvBQatIolNl2.tUBXRZljfAUzITeLSNnlnxnnsCR, lOnVCleNikbYBjDvPvBQatIolNl2.SVZaUOQukleBHJyOWdFUyPfKSLYe);
							string text = (string.IsNullOrEmpty(lOnVCleNikbYBjDvPvBQatIolNl2.riVgOMKRfcmnDvgPBFvqnRIvZXZS) ? fieldInfo.Name : lOnVCleNikbYBjDvPvBQatIolNl2.riVgOMKRfcmnDvgPBFvqnRIvZXZS);
							text = ((num4 == 1) ? text : (text + num6));
							gazyhpdlSwyAWHHvxFhJfxUxIyK.Name = text;
							list.Add(gazyhpdlSwyAWHHvxFhJfxUxIyK);
							num3 += num5;
							num6++;
						}
					}
				}
				xVWwRXXoqtXtsAcUGcERjKHZXFN.ObjectsFormat = list.ToArray();
			}
			for (int m = 0; m < xVWwRXXoqtXtsAcUGcERjKHZXFN.ObjectsFormat.Length; m++)
			{
				GazyhpdlSwyAWHHvxFhJfxUxIyK gazyhpdlSwyAWHHvxFhJfxUxIyK2 = xVWwRXXoqtXtsAcUGcERjKHZXFN.ObjectsFormat[m];
				if (jqYEpqsWlCjlRCKRCpmOvkMeFQM.ContainsKey(gazyhpdlSwyAWHHvxFhJfxUxIyK2.Name))
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Incorrect field name [{0}]. Field name must be unique", new object[1] { gazyhpdlSwyAWHHvxFhJfxUxIyK2.Name }));
				}
				jqYEpqsWlCjlRCKRCpmOvkMeFQM.Add(gazyhpdlSwyAWHHvxFhJfxUxIyK2.Name, gazyhpdlSwyAWHHvxFhJfxUxIyK2);
			}
		}
		return xVWwRXXoqtXtsAcUGcERjKHZXFN;
	}

	private unsafe void QZTUOOBcCRizYvXsLEajNZOKeiy(OBGtZTCXiKwDVJYTQAavOZxNbIC P_0)
	{
		OBGtZTCXiKwDVJYTQAavOZxNbIC.rXfToIxWQnakavZPjILcvhMzeIR rXfToIxWQnakavZPjILcvhMzeIR = default(OBGtZTCXiKwDVJYTQAavOZxNbIC.rXfToIxWQnakavZPjILcvhMzeIR);
		P_0.ZOrqRDWidYwRgwHrRQtkXoMvWTT(ref rXfToIxWQnakavZPjILcvhMzeIR);
		string name = typeof(TRaw).Name;
		Console.WriteLine("{0}.dwSize     {1}", name, rXfToIxWQnakavZPjILcvhMzeIR.MSHCgcyCMthFnRTIrchleRuEuVD);
		Console.WriteLine("{0}.dwObjSize  {1}", name, rXfToIxWQnakavZPjILcvhMzeIR.KBbGBspYhDWnjxjpYxVWvPLnWAK);
		Console.WriteLine("{0}.dwFlags    {1} ({2})", name, (int)rXfToIxWQnakavZPjILcvhMzeIR.tUBXRZljfAUzITeLSNnlnxnnsCR, rXfToIxWQnakavZPjILcvhMzeIR.tUBXRZljfAUzITeLSNnlnxnnsCR);
		Console.WriteLine("{0}.dwDataSize {1}", name, rXfToIxWQnakavZPjILcvhMzeIR.vrUgZnbMlYERXMlYNGcJMwxzdSsC);
		Console.WriteLine("{0}.dwNumObjs  {1}", name, rXfToIxWQnakavZPjILcvhMzeIR.vSAVskJYDpWGXJmVpYVqAftyqqD);
		Console.WriteLine("{4,32};{0,38};{1,8},{2,8};{3,8}", "Guid", "Offset", "Type", "Flags", "Name");
		GazyhpdlSwyAWHHvxFhJfxUxIyK.XUDBgejCLzumWUcAUSWIgjbILcW* ptr = (GazyhpdlSwyAWHHvxFhJfxUxIyK.XUDBgejCLzumWUcAUSWIgjbILcW*)(void*)rXfToIxWQnakavZPjILcvhMzeIR.dBjaoahuQsNlpijaJYiplCrPaWv;
		for (int i = 0; i < rXfToIxWQnakavZPjILcvhMzeIR.vSAVskJYDpWGXJmVpYVqAftyqqD; i++)
		{
			GazyhpdlSwyAWHHvxFhJfxUxIyK.XUDBgejCLzumWUcAUSWIgjbILcW xUDBgejCLzumWUcAUSWIgjbILcW = ptr[i];
			string text = ((xUDBgejCLzumWUcAUSWIgjbILcW.cPhmyGiaJwPLbYhynVnyaxeflvN == IntPtr.Zero) ? "" : ((Guid*)(void*)xUDBgejCLzumWUcAUSWIgjbILcW.cPhmyGiaJwPLbYhynVnyaxeflvN)->ToString());
			Console.WriteLine("{5,32};{0,38};{1,8},{2:X8};{3:X8} ({4})", text, xUDBgejCLzumWUcAUSWIgjbILcW.vWDCHhwuXPHeHeeYshRgNHYNPtE, xUDBgejCLzumWUcAUSWIgjbILcW.HSgsKXENkcvZsdtDvNAJblnfTHZ, (int)xUDBgejCLzumWUcAUSWIgjbILcW.tUBXRZljfAUzITeLSNnlnxnnsCR, xUDBgejCLzumWUcAUSWIgjbILcW.tUBXRZljfAUzITeLSNnlnxnnsCR, P_0.ObjectsFormat[i].Name);
		}
		Console.WriteLine();
	}
}
