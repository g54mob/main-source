using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

internal abstract class EmEkcjGzMbruDdyZWiMYReqTcWJl<_0001, _0002, _0003> : ISbVfPZowObHcIhOBnZNbQAnllH where _0001 : class, global::mNLtEtZlRquxmNkhogAkLBuOHton<_0002, _0003>, new() where _0002 : struct where _0003 : struct, dNBFyAEHhznkjajxPBeTuQJGesjc
{
	private EzmgIeiCkurwWOvxefDMjYYlEvbKA BnyrmRlaTCEUBpCPoTFeQjSZSaON;

	private readonly Dictionary<string, IYLraAdszSDAPSIzXqwKbSQFEnXJ> tQUuXZQCQXUivXIRLEXripOHhUQYA = new Dictionary<string, IYLraAdszSDAPSIzXqwKbSQFEnXJ>();

	private static readonly _0003[] uaOrumzngFybGocsaNDBJnvosSsv = new _0003[0];

	protected EmEkcjGzMbruDdyZWiMYReqTcWJl(IntPtr P_0)
		: base(P_0)
	{
	}

	protected EmEkcjGzMbruDdyZWiMYReqTcWJl(kHulolaiHHHtqEyPXwgoOKOviJQAb P_0, Guid P_1)
		: base(P_0, P_1)
	{
		EzmgIeiCkurwWOvxefDMjYYlEvbKA ezmgIeiCkurwWOvxefDMjYYlEvbKA = oyNzJQhRLpIbRPntrxagVPDoVCNr();
		hKmPFarMrzijkwMfhFhikoOMKMmrA(ezmgIeiCkurwWOvxefDMjYYlEvbKA);
	}

	public unsafe _0003[] ZwGNrMbBAZGOOghsRjrXDxhErXKHb()
	{
		_0003[] result = uaOrumzngFybGocsaNDBJnvosSsv;
		int num = UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<ewwySfPEyQPDJDmVmNRTTTdmSDwS>();
		int num2 = -1;
		EJXtUsFMJSlCIgKyzOkStoQBACyo(num, IntPtr.Zero, ref num2, 1);
		if (num2 == 0)
		{
			return result;
		}
		ewwySfPEyQPDJDmVmNRTTTdmSDwS* ptr = stackalloc ewwySfPEyQPDJDmVmNRTTTdmSDwS[num2];
		EJXtUsFMJSlCIgKyzOkStoQBACyo(num, (IntPtr)ptr, ref num2, 0);
		if (num2 == 0)
		{
			return result;
		}
		result = new _0003[num2];
		for (int i = 0; i < num2; i++)
		{
			result[i] = new _0003
			{
				QdEuvnwtAqILcXsylNWVudraSzZP = ptr[i].yBGnAdztiipkCtNaKYbFXeaiCItr,
				yStSikhrVJPuOgRweMbNoAiCQSdX = ptr[i].EsMpQkFJkHElyhwosIHAViQNqyooA,
				uCgesVFqkIgQfIOmIPpCoxLHXatx = ptr[i].hcmqJydvwZNpIDnFEJWxVDZLmSsk,
				eIrvGlCZeJCRmSDFhozkPOCmyHFE = ptr[i].cRrmLVTrIUojOOLEkipAtdvmVTaN
			};
		}
		return result;
	}

	public void xhpUNyvcGlsepdtZqnUZGcYGrPoj(_0001 P_0)
	{
		CFLmqsSrisjUzXAEzmZpApLSqwPA(ref P_0);
	}

	public _0001 DUJUaMkruaChpArrretnAMeQAhSF()
	{
		_0001 result = new _0001();
		CFLmqsSrisjUzXAEzmZpApLSqwPA(ref result);
		return result;
	}

	public unsafe void CFLmqsSrisjUzXAEzmZpApLSqwPA(ref _0001 P_0)
	{
		int num = UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<_0002>();
		byte* ptr = stackalloc byte[(int)(uint)(num * 2)];
		vyXAvHGTKuJJpXYntgzUAYpwBiFi(num, (IntPtr)ptr);
		_0001 val = P_0;
		val.lgdzNVvGaffjnyZHAbpLgnxIVFLj((IntPtr)ptr);
	}

	public IAgdmKbxxCierJHKqWSFAjDwBDjEb vESDjycjtoNDuOotxeDgERcbCdIhA(string P_0)
	{
		return snahqDdsjwRPStulmKlSOlqfCDQY(rlzNyEqfOxGiQyOdwOeXpLDbYqxm(P_0).LSidZOyUswdpZasMadZeNuLDTNpj, ftmHdGsvBxqBasuAJPENxulYJcKQ.Byoffset);
	}

	public HmbqIWQgnLRhAlJEEGJfVGMeFmLS zELebFYrEKaQDpBOzFuaADOvnNgd(string P_0)
	{
		return new HmbqIWQgnLRhAlJEEGJfVGMeFmLS(this, rlzNyEqfOxGiQyOdwOeXpLDbYqxm(P_0).LSidZOyUswdpZasMadZeNuLDTNpj, ftmHdGsvBxqBasuAJPENxulYJcKQ.Byoffset);
	}

	private IYLraAdszSDAPSIzXqwKbSQFEnXJ rlzNyEqfOxGiQyOdwOeXpLDbYqxm(string P_0)
	{
		if (!tQUuXZQCQXUivXIRLEXripOHhUQYA.TryGetValue(P_0, out var value))
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid name [{0}]. Must be in [{1}]", P_0, UzSdPpQstdjpcZsalnZeqrJQhDdn.TlSCiyfScTmbWdejohfWpTGRPizP(";", tQUuXZQCQXUivXIRLEXripOHhUQYA.Keys)));
		}
		return value;
	}

	private EzmgIeiCkurwWOvxefDMjYYlEvbKA oyNzJQhRLpIbRPntrxagVPDoVCNr()
	{
		if (BnyrmRlaTCEUBpCPoTFeQjSZSaON == null)
		{
			if (typeof(GOkkGJsyeTpfLwkmGZsWCyZidwnr).IsAssignableFrom(typeof(_0002)))
			{
				GOkkGJsyeTpfLwkmGZsWCyZidwnr gOkkGJsyeTpfLwkmGZsWCyZidwnr = (GOkkGJsyeTpfLwkmGZsWCyZidwnr)(object)new _0002();
				BnyrmRlaTCEUBpCPoTFeQjSZSaON = new EzmgIeiCkurwWOvxefDMjYYlEvbKA(gOkkGJsyeTpfLwkmGZsWCyZidwnr.lnsogNAIGVCnyMIXyfxNooBTvvej)
				{
					MVguSzhmhBQKilPAfQefRLzlvYQi = UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<_0002>(),
					DvXqpvNBCntFeqICXGKhelyvFlqFA = gOkkGJsyeTpfLwkmGZsWCyZidwnr.OWEEsCBjZJqDkMCEfImRDgXhcAxYb
				};
			}
			else
			{
				object[] customAttributes = typeof(_0002).GetCustomAttributes(typeof(QqPaDwajGjTYBNhptdHZWYHnRkiAA), inherit: false);
				if (customAttributes.Length != 1)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The structure [{0}] must be marked with DataFormatAttribute or provide a IDataFormatProvider", typeof(_0002).FullName));
				}
				BnyrmRlaTCEUBpCPoTFeQjSZSaON = new EzmgIeiCkurwWOvxefDMjYYlEvbKA(((QqPaDwajGjTYBNhptdHZWYHnRkiAA)customAttributes[0]).lEtLnihnuDRGrENbJIssAiNvJdKHb)
				{
					MVguSzhmhBQKilPAfQefRLzlvYQi = UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<_0002>()
				};
				List<IYLraAdszSDAPSIzXqwKbSQFEnXJ> list = new List<IYLraAdszSDAPSIzXqwKbSQFEnXJ>();
				FieldInfo[] fields = typeof(_0002).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					object[] customAttributes2 = fieldInfo.GetCustomAttributes(typeof(TJZhBIousApdIuMJnjezbwhMtFKxA), inherit: false);
					if (customAttributes2.Length == 0)
					{
						continue;
					}
					int num = Marshal.OffsetOf(typeof(_0002), fieldInfo.Name).ToInt32();
					int num2 = Marshal.SizeOf(fieldInfo.FieldType);
					int num3 = num;
					int num4 = 0;
					for (int j = 0; j < customAttributes2.Length; j++)
					{
						TJZhBIousApdIuMJnjezbwhMtFKxA tJZhBIousApdIuMJnjezbwhMtFKxA = (TJZhBIousApdIuMJnjezbwhMtFKxA)customAttributes2[j];
						num4 += ((tJZhBIousApdIuMJnjezbwhMtFKxA.DRZdPYLpSpMsncrEZbleeQmLRcfQ == 0) ? 1 : tJZhBIousApdIuMJnjezbwhMtFKxA.DRZdPYLpSpMsncrEZbleeQmLRcfQ);
					}
					int num5 = num2 / num4;
					if (num5 * num4 != num2)
					{
						throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Field [{0}] has incompatible size [{1}] and number of DataObjectAttributes [{2}]", fieldInfo.Name, (double)num2 / (double)num4, num4));
					}
					int num6 = 0;
					for (int k = 0; k < customAttributes2.Length; k++)
					{
						TJZhBIousApdIuMJnjezbwhMtFKxA tJZhBIousApdIuMJnjezbwhMtFKxA2 = (TJZhBIousApdIuMJnjezbwhMtFKxA)customAttributes2[k];
						num4 = ((tJZhBIousApdIuMJnjezbwhMtFKxA2.DRZdPYLpSpMsncrEZbleeQmLRcfQ == 0) ? 1 : tJZhBIousApdIuMJnjezbwhMtFKxA2.DRZdPYLpSpMsncrEZbleeQmLRcfQ);
						for (int l = 0; l < num4; l++)
						{
							IYLraAdszSDAPSIzXqwKbSQFEnXJ iYLraAdszSDAPSIzXqwKbSQFEnXJ = new IYLraAdszSDAPSIzXqwKbSQFEnXJ(string.IsNullOrEmpty(tJZhBIousApdIuMJnjezbwhMtFKxA2.pNuglaqZFugskucIodlCcCgjzJhBA) ? Guid.Empty : new Guid(tJZhBIousApdIuMJnjezbwhMtFKxA2.pNuglaqZFugskucIodlCcCgjzJhBA), num3, tJZhBIousApdIuMJnjezbwhMtFKxA2.uoLbEBTkJVfcubZuTflVmVIobrSCb, tJZhBIousApdIuMJnjezbwhMtFKxA2.xsHyPYJVJDLKEcPAszwpCtOYpXlm, tJZhBIousApdIuMJnjezbwhMtFKxA2.mAfhaGkzIYFIVDiCPAictjNetjBjA);
							string text = (string.IsNullOrEmpty(tJZhBIousApdIuMJnjezbwhMtFKxA2.XMOJJUCiotgEnXgTgZmJNWTPbSiA) ? fieldInfo.Name : tJZhBIousApdIuMJnjezbwhMtFKxA2.XMOJJUCiotgEnXgTgZmJNWTPbSiA);
							text = ((num4 == 1) ? text : (text + num6));
							iYLraAdszSDAPSIzXqwKbSQFEnXJ.yszhCeNRbUIJcTsblcseiIVakKCYA = text;
							list.Add(iYLraAdszSDAPSIzXqwKbSQFEnXJ);
							num3 += num5;
							num6++;
						}
					}
				}
				BnyrmRlaTCEUBpCPoTFeQjSZSaON.DvXqpvNBCntFeqICXGKhelyvFlqFA = list.ToArray();
			}
			for (int m = 0; m < BnyrmRlaTCEUBpCPoTFeQjSZSaON.DvXqpvNBCntFeqICXGKhelyvFlqFA.Length; m++)
			{
				IYLraAdszSDAPSIzXqwKbSQFEnXJ iYLraAdszSDAPSIzXqwKbSQFEnXJ2 = BnyrmRlaTCEUBpCPoTFeQjSZSaON.DvXqpvNBCntFeqICXGKhelyvFlqFA[m];
				if (tQUuXZQCQXUivXIRLEXripOHhUQYA.ContainsKey(iYLraAdszSDAPSIzXqwKbSQFEnXJ2.yszhCeNRbUIJcTsblcseiIVakKCYA))
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Incorrect field name [{0}]. Field name must be unique", iYLraAdszSDAPSIzXqwKbSQFEnXJ2.yszhCeNRbUIJcTsblcseiIVakKCYA));
				}
				tQUuXZQCQXUivXIRLEXripOHhUQYA.Add(iYLraAdszSDAPSIzXqwKbSQFEnXJ2.yszhCeNRbUIJcTsblcseiIVakKCYA, iYLraAdszSDAPSIzXqwKbSQFEnXJ2);
			}
		}
		return BnyrmRlaTCEUBpCPoTFeQjSZSaON;
	}

	private unsafe void whjbEWVnpaRQzNzKFSJCTVybGKXn(EzmgIeiCkurwWOvxefDMjYYlEvbKA P_0)
	{
		EzmgIeiCkurwWOvxefDMjYYlEvbKA.uGcpFohrgBuVhzHMFfQXhhenkwXIA uGcpFohrgBuVhzHMFfQXhhenkwXIA = default(EzmgIeiCkurwWOvxefDMjYYlEvbKA.uGcpFohrgBuVhzHMFfQXhhenkwXIA);
		P_0.KXdzeUjHtMUmCkdhokMaqLHsJTEE(ref uGcpFohrgBuVhzHMFfQXhhenkwXIA);
		string name = typeof(_0002).Name;
		Console.WriteLine("{0}.dwSize     {1}", name, uGcpFohrgBuVhzHMFfQXhhenkwXIA.KHudejwNqUbuDNRFYkWxLqXBJuBV);
		Console.WriteLine("{0}.dwObjSize  {1}", name, uGcpFohrgBuVhzHMFfQXhhenkwXIA.aVrPAHlLpfPJSrJyrLLPoRiDbkmW);
		Console.WriteLine("{0}.dwFlags    {1} ({2})", name, (int)uGcpFohrgBuVhzHMFfQXhhenkwXIA.YUQVTfrxlqSlJEbziXyVmYABdNmH, uGcpFohrgBuVhzHMFfQXhhenkwXIA.YUQVTfrxlqSlJEbziXyVmYABdNmH);
		Console.WriteLine("{0}.dwDataSize {1}", name, uGcpFohrgBuVhzHMFfQXhhenkwXIA.sEiWXITXJRokRFIqQcVnTcfSojRR);
		Console.WriteLine("{0}.dwNumObjs  {1}", name, uGcpFohrgBuVhzHMFfQXhhenkwXIA.rtZurzOxBAcVRwJexIwedflJUGYc);
		Console.WriteLine("{4,32};{0,38};{1,8},{2,8};{3,8}", "Guid", "Offset", "Type", "Flags", "Name");
		IYLraAdszSDAPSIzXqwKbSQFEnXJ.tFCAoXREEudqfeYnTlvPuDmgOzWp* ptr = (IYLraAdszSDAPSIzXqwKbSQFEnXJ.tFCAoXREEudqfeYnTlvPuDmgOzWp*)(void*)uGcpFohrgBuVhzHMFfQXhhenkwXIA.XroZXLQwTViuhtURbQBmvRdZcqcv;
		for (int i = 0; i < uGcpFohrgBuVhzHMFfQXhhenkwXIA.rtZurzOxBAcVRwJexIwedflJUGYc; i++)
		{
			IYLraAdszSDAPSIzXqwKbSQFEnXJ.tFCAoXREEudqfeYnTlvPuDmgOzWp tFCAoXREEudqfeYnTlvPuDmgOzWp = ptr[i];
			string text = ((tFCAoXREEudqfeYnTlvPuDmgOzWp.zoUzkVLRNRUtYCTdFkxsWHjqbvZd == IntPtr.Zero) ? "" : ((Guid*)(void*)tFCAoXREEudqfeYnTlvPuDmgOzWp.zoUzkVLRNRUtYCTdFkxsWHjqbvZd)->ToString());
			Console.WriteLine("{5,32};{0,38};{1,8},{2:X8};{3:X8} ({4})", text, tFCAoXREEudqfeYnTlvPuDmgOzWp.uigDiXewhtWUasVeepdiZvfoKUMyA, tFCAoXREEudqfeYnTlvPuDmgOzWp.ijODLdwhDTTwSkMKEbJFTVnscuSX, (int)tFCAoXREEudqfeYnTlvPuDmgOzWp.ZVyGoNjruHsVyKhAESPQoqoOCMNdb, tFCAoXREEudqfeYnTlvPuDmgOzWp.ZVyGoNjruHsVyKhAESPQoqoOCMNdb, P_0.DvXqpvNBCntFeqICXGKhelyvFlqFA[i].yszhCeNRbUIJcTsblcseiIVakKCYA);
		}
		Console.WriteLine();
	}
}
