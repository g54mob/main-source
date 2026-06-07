using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

internal abstract class ewUFdcSGLgEgnEaXASPVSzhAnjCTA<_0001, _0002, _0003> : kZQcBsLKjzMknzpiGkWSlHLNgYsC where _0001 : class, global::OrHwbcLeGnuUMEEhugPpfSlTHslx<_0002, _0003>, new() where _0002 : struct where _0003 : struct, DhDYgvQAvejvEpjQZunhCDEVnfbC
{
	private elccTxhIzxJmmXBfiDcDegBagioqc jrmdcIxXAHIIvyQZaSatmLHKfzVhA;

	private readonly Dictionary<string, uDPgwXblkXDutFExDPCNNyLAHSUh> VuAYKMWTHAhsFSiTVFaaERNCjHXwA = new Dictionary<string, uDPgwXblkXDutFExDPCNNyLAHSUh>();

	private static readonly _0003[] QjQplztqjKNrezveoEyShtgdwJvN = new _0003[0];

	protected ewUFdcSGLgEgnEaXASPVSzhAnjCTA(SBstrsiLWYqpWzQLDLNlmFTmzMXs P_0, Guid P_1)
		: base(P_0, P_1)
	{
		elccTxhIzxJmmXBfiDcDegBagioqc elccTxhIzxJmmXBfiDcDegBagioqc2 = EKJTYPtcWkQvjAenbYXzrvQbqBOT();
		ZwapCpzhgyttAdqzteExbQVXfNjbb(elccTxhIzxJmmXBfiDcDegBagioqc2);
	}

	public void DwxLMppFmgahDoHtkOqSqDGJeGvG(_0001 P_0)
	{
		qwHbtfMitdnaiISCYZdKuweSfLzc(ref P_0);
	}

	public _0001 bPZUHuZuxAsJVKdtPWqoMRZZnVi()
	{
		_0001 result = new _0001();
		qwHbtfMitdnaiISCYZdKuweSfLzc(ref result);
		return result;
	}

	public unsafe void qwHbtfMitdnaiISCYZdKuweSfLzc(ref _0001 P_0)
	{
		int num = ehSEMeSdgiGvGKoctLujYIMHUCqW.xsRmeyarCKpTSClbbwreBteSuIZB<_0002>();
		byte* ptr = stackalloc byte[(int)(uint)(num * 2)];
		NiPamEEFXhsPTWtzjfAToBohiMMz(num, (IntPtr)ptr);
		IntPtr intPtr = (IntPtr)ptr;
		P_0.RUdgMKxdOkjPDhPzAGOxQqcJWfKe(intPtr);
	}

	private elccTxhIzxJmmXBfiDcDegBagioqc EKJTYPtcWkQvjAenbYXzrvQbqBOT()
	{
		if (jrmdcIxXAHIIvyQZaSatmLHKfzVhA == null)
		{
			if (typeof(utoFZEgVxKkrrdSuCmVJgPEpYjsO).IsAssignableFrom(typeof(_0002)))
			{
				utoFZEgVxKkrrdSuCmVJgPEpYjsO utoFZEgVxKkrrdSuCmVJgPEpYjsO2 = (utoFZEgVxKkrrdSuCmVJgPEpYjsO)(object)new _0002();
				jrmdcIxXAHIIvyQZaSatmLHKfzVhA = new elccTxhIzxJmmXBfiDcDegBagioqc(utoFZEgVxKkrrdSuCmVJgPEpYjsO2.XqkjeMMiZQMjWXBZoKTSGSAMyihL)
				{
					ojqvnypOyKGJUsaQpdLitDcsosVi = ehSEMeSdgiGvGKoctLujYIMHUCqW.xsRmeyarCKpTSClbbwreBteSuIZB<_0002>(),
					hgNhvsXVPatfOdMTJzvoYrnouHhh = utoFZEgVxKkrrdSuCmVJgPEpYjsO2.sPKDlRxWWKCDKAZKhITYlWSbCTsCb
				};
			}
			else
			{
				object[] customAttributes = typeof(_0002).GetCustomAttributes(typeof(sTDFAtFtZgpWxoyrtFgIciKiDtxuA), inherit: false);
				if (customAttributes.Length != 1)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The structure [{0}] must be marked with DataFormatAttribute or provide a IDataFormatProvider", typeof(_0002).FullName));
				}
				jrmdcIxXAHIIvyQZaSatmLHKfzVhA = new elccTxhIzxJmmXBfiDcDegBagioqc(((sTDFAtFtZgpWxoyrtFgIciKiDtxuA)customAttributes[0]).DCvSsnvqtCGSXkLjVsNdrWOoguHLA)
				{
					ojqvnypOyKGJUsaQpdLitDcsosVi = ehSEMeSdgiGvGKoctLujYIMHUCqW.xsRmeyarCKpTSClbbwreBteSuIZB<_0002>()
				};
				List<uDPgwXblkXDutFExDPCNNyLAHSUh> list = new List<uDPgwXblkXDutFExDPCNNyLAHSUh>();
				FieldInfo[] fields = typeof(_0002).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					object[] customAttributes2 = fieldInfo.GetCustomAttributes(typeof(lVVHGBwQrHAtgtEHhiHokIaFoSFZA), inherit: false);
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
						lVVHGBwQrHAtgtEHhiHokIaFoSFZA lVVHGBwQrHAtgtEHhiHokIaFoSFZA2 = (lVVHGBwQrHAtgtEHhiHokIaFoSFZA)customAttributes2[j];
						num4 += ((lVVHGBwQrHAtgtEHhiHokIaFoSFZA2.zmNCoNDHHqfyXjpOJCOhImrMknuX == 0) ? 1 : lVVHGBwQrHAtgtEHhiHokIaFoSFZA2.zmNCoNDHHqfyXjpOJCOhImrMknuX);
					}
					int num5 = num2 / num4;
					if (num5 * num4 != num2)
					{
						throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Field [{0}] has incompatible size [{1}] and number of DataObjectAttributes [{2}]", fieldInfo.Name, (double)num2 / (double)num4, num4));
					}
					int num6 = 0;
					for (int k = 0; k < customAttributes2.Length; k++)
					{
						lVVHGBwQrHAtgtEHhiHokIaFoSFZA lVVHGBwQrHAtgtEHhiHokIaFoSFZA3 = (lVVHGBwQrHAtgtEHhiHokIaFoSFZA)customAttributes2[k];
						num4 = ((lVVHGBwQrHAtgtEHhiHokIaFoSFZA3.zmNCoNDHHqfyXjpOJCOhImrMknuX == 0) ? 1 : lVVHGBwQrHAtgtEHhiHokIaFoSFZA3.zmNCoNDHHqfyXjpOJCOhImrMknuX);
						for (int l = 0; l < num4; l++)
						{
							uDPgwXblkXDutFExDPCNNyLAHSUh uDPgwXblkXDutFExDPCNNyLAHSUh2 = new uDPgwXblkXDutFExDPCNNyLAHSUh(string.IsNullOrEmpty(lVVHGBwQrHAtgtEHhiHokIaFoSFZA3.VughwriiEnjcSvMOcEMPKeliwWaeA) ? Guid.Empty : new Guid(lVVHGBwQrHAtgtEHhiHokIaFoSFZA3.VughwriiEnjcSvMOcEMPKeliwWaeA), num3, lVVHGBwQrHAtgtEHhiHokIaFoSFZA3.OPXRiCLYOCiHYIXqZKVAjMNzumZk, lVVHGBwQrHAtgtEHhiHokIaFoSFZA3.VSRsQZVtIWNQonNYcVTeimJNPakr, lVVHGBwQrHAtgtEHhiHokIaFoSFZA3.GmfAbJinZBQSrCdEaRZpHVKpxoGIB);
							string text = (string.IsNullOrEmpty(lVVHGBwQrHAtgtEHhiHokIaFoSFZA3.xIMSkMKfbpghiSDkFoPbjyFUopPm) ? fieldInfo.Name : lVVHGBwQrHAtgtEHhiHokIaFoSFZA3.xIMSkMKfbpghiSDkFoPbjyFUopPm);
							text = ((num4 == 1) ? text : (text + num6));
							uDPgwXblkXDutFExDPCNNyLAHSUh2.CPvHFfPTqJQTGAorbbXrBwEvsNBwA = text;
							list.Add(uDPgwXblkXDutFExDPCNNyLAHSUh2);
							num3 += num5;
							num6++;
						}
					}
				}
				jrmdcIxXAHIIvyQZaSatmLHKfzVhA.hgNhvsXVPatfOdMTJzvoYrnouHhh = list.ToArray();
			}
			for (int m = 0; m < jrmdcIxXAHIIvyQZaSatmLHKfzVhA.hgNhvsXVPatfOdMTJzvoYrnouHhh.Length; m++)
			{
				uDPgwXblkXDutFExDPCNNyLAHSUh uDPgwXblkXDutFExDPCNNyLAHSUh3 = jrmdcIxXAHIIvyQZaSatmLHKfzVhA.hgNhvsXVPatfOdMTJzvoYrnouHhh[m];
				if (VuAYKMWTHAhsFSiTVFaaERNCjHXwA.ContainsKey(uDPgwXblkXDutFExDPCNNyLAHSUh3.CPvHFfPTqJQTGAorbbXrBwEvsNBwA))
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Incorrect field name [{0}]. Field name must be unique", uDPgwXblkXDutFExDPCNNyLAHSUh3.CPvHFfPTqJQTGAorbbXrBwEvsNBwA));
				}
				VuAYKMWTHAhsFSiTVFaaERNCjHXwA.Add(uDPgwXblkXDutFExDPCNNyLAHSUh3.CPvHFfPTqJQTGAorbbXrBwEvsNBwA, uDPgwXblkXDutFExDPCNNyLAHSUh3);
			}
		}
		return jrmdcIxXAHIIvyQZaSatmLHKfzVhA;
	}
}
