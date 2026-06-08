using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal abstract class DtJCTxOcSBVMTaTFeosDsSLBrcl<T, TRaw, TUpdate> : RCZsZvPYtEDdVbOzkBoGsXkQwZP where T : class, global::hUKGPbfBxUOZywKzQaehXkEGSiKp<TRaw, TUpdate>, new() where TRaw : struct where TUpdate : struct, sICszkYwpNiWijkjbVFpRqgCSlS
{
	private NHdgEyEPCUHJEJnxCZEJpXefukZ iIzkyiFSmvFrdUqKGffvQUlfUaC;

	private readonly Dictionary<string, VjKFPEKdDkroLkRlnsoDdGmPeHpW> uQnYpXmloYgnOiCmKFKuWClGEEBe = new Dictionary<string, VjKFPEKdDkroLkRlnsoDdGmPeHpW>();

	private static readonly TUpdate[] ztZVksNVpUQPNWjPTkCQgXmmasE = new TUpdate[0];

	protected DtJCTxOcSBVMTaTFeosDsSLBrcl(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	protected DtJCTxOcSBVMTaTFeosDsSLBrcl(DirectInput directInput, Guid deviceGuid)
		: base(directInput, deviceGuid)
	{
		NHdgEyEPCUHJEJnxCZEJpXefukZ nHdgEyEPCUHJEJnxCZEJpXefukZ = ZhATGdhXrgcqJDnpEeOqcVFzVam();
		ftPlNidshyeFiUNiTwsmmoxsRNA(nHdgEyEPCUHJEJnxCZEJpXefukZ);
	}

	public unsafe TUpdate[] AqqgSzgbMaCBPdjZaKOzSeqgZujj()
	{
		TUpdate[] result = ztZVksNVpUQPNWjPTkCQgXmmasE;
		int num = XhNUbpKnHPBQaARiBNUpPFpGECJ.MNwplfZetGrtOlzgThGDriPKjRnh<lllukdZXSaaBJKYJUVqQoOVoGPU>();
		int num2 = -1;
		EICiacQfptwsBaKYtmAArlzlQoV(num, IntPtr.Zero, ref num2, 1);
		if (num2 == 0)
		{
			return result;
		}
		lllukdZXSaaBJKYJUVqQoOVoGPU* ptr = stackalloc lllukdZXSaaBJKYJUVqQoOVoGPU[num2];
		EICiacQfptwsBaKYtmAArlzlQoV(num, (IntPtr)ptr, ref num2, 0);
		if (num2 == 0)
		{
			return result;
		}
		result = new TUpdate[num2];
		for (int i = 0; i < num2; i++)
		{
			result[i] = new TUpdate
			{
				RawOffset = ptr[i].udsPlCkQjZnJYoduwmqSePFhHcD,
				Value = ptr[i].zcrLsgWlluAxuaCfKiqkzQcyEEv,
				Timestamp = ptr[i].ceVIkQSVxpiYENPYImxNPzjWLIS,
				Sequence = ptr[i].OPWvmPAXHxnFtUkRDqKyqJlqzjp
			};
		}
		return result;
	}

	public void zWBKFnkRdYQHNgNlrfRthQWDABBS(T P_0)
	{
		wvtaajTOSlQMPQbGRpyYDdBpUuk(ref P_0);
	}

	public T wvtaajTOSlQMPQbGRpyYDdBpUuk()
	{
		T result = new T();
		wvtaajTOSlQMPQbGRpyYDdBpUuk(ref result);
		return result;
	}

	public unsafe void wvtaajTOSlQMPQbGRpyYDdBpUuk(ref T P_0)
	{
		int num = XhNUbpKnHPBQaARiBNUpPFpGECJ.MNwplfZetGrtOlzgThGDriPKjRnh<TRaw>();
		byte* ptr = stackalloc byte[(int)(uint)(num * 2)];
		KPifQcCQWrTeZLhPBodqvaKmbaK(num, (IntPtr)ptr);
		IntPtr intPtr = (IntPtr)ptr;
		P_0.wybJdAhTpvWqyyOomZLOcLcMQJK(intPtr);
	}

	public JgrAyYzRNsNStAtAQACKYutyEqZ iriwWCOJvhiNRMHHXKBLWwWTTiP(string P_0)
	{
		return fizbKWEQYNwRZdFGCGLBBsDaNFxD(oyNNmuLxNTnmmKyTyDVAPHgRgGJ(P_0).Offset, yKxVdKmfrVqwclUOjOxOGeBGvJa.tGTgHGncpGSLqjBffcZvIHakzFY);
	}

	public ORqiSSKNKjmkImAOkgGuHouqZrvv ZLpDEfDJRKejQeMpikGxxrqGWEJ(string P_0)
	{
		return new ORqiSSKNKjmkImAOkgGuHouqZrvv(this, oyNNmuLxNTnmmKyTyDVAPHgRgGJ(P_0).Offset, yKxVdKmfrVqwclUOjOxOGeBGvJa.tGTgHGncpGSLqjBffcZvIHakzFY);
	}

	private VjKFPEKdDkroLkRlnsoDdGmPeHpW oyNNmuLxNTnmmKyTyDVAPHgRgGJ(string P_0)
	{
		if (!uQnYpXmloYgnOiCmKFKuWClGEEBe.TryGetValue(P_0, out var value))
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid name [{0}]. Must be in [{1}]", new object[2]
			{
				P_0,
				XhNUbpKnHPBQaARiBNUpPFpGECJ.KPhjBJDiNhyYzqyhMKgYdCkZDgj(";", uQnYpXmloYgnOiCmKFKuWClGEEBe.Keys)
			}));
		}
		return value;
	}

	private NHdgEyEPCUHJEJnxCZEJpXefukZ ZhATGdhXrgcqJDnpEeOqcVFzVam()
	{
		if (iIzkyiFSmvFrdUqKGffvQUlfUaC == null)
		{
			if (typeof(IDataFormatProvider).IsAssignableFrom(typeof(TRaw)))
			{
				IDataFormatProvider dataFormatProvider = (IDataFormatProvider)(object)default(TRaw);
				iIzkyiFSmvFrdUqKGffvQUlfUaC = new NHdgEyEPCUHJEJnxCZEJpXefukZ(dataFormatProvider.Flags)
				{
					ihzsSYSJIANMfliVGXdPBmBKJbN = XhNUbpKnHPBQaARiBNUpPFpGECJ.MNwplfZetGrtOlzgThGDriPKjRnh<TRaw>(),
					ObjectsFormat = dataFormatProvider.ObjectsFormat
				};
			}
			else
			{
				object[] customAttributes = typeof(TRaw).GetCustomAttributes(typeof(DataFormatAttribute), inherit: false);
				if (customAttributes.Length != 1)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The structure [{0}] must be marked with DataFormatAttribute or provide a IDataFormatProvider", new object[1] { typeof(TRaw).FullName }));
				}
				iIzkyiFSmvFrdUqKGffvQUlfUaC = new NHdgEyEPCUHJEJnxCZEJpXefukZ(((DataFormatAttribute)customAttributes[0]).Flags)
				{
					ihzsSYSJIANMfliVGXdPBmBKJbN = XhNUbpKnHPBQaARiBNUpPFpGECJ.MNwplfZetGrtOlzgThGDriPKjRnh<TRaw>()
				};
				List<VjKFPEKdDkroLkRlnsoDdGmPeHpW> list = new List<VjKFPEKdDkroLkRlnsoDdGmPeHpW>();
				FieldInfo[] fields = typeof(TRaw).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					object[] customAttributes2 = fieldInfo.GetCustomAttributes(typeof(DataObjectFormatAttribute), inherit: false);
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
						DataObjectFormatAttribute dataObjectFormatAttribute = (DataObjectFormatAttribute)customAttributes2[j];
						num4 += ((dataObjectFormatAttribute.ArrayCount == 0) ? 1 : dataObjectFormatAttribute.ArrayCount);
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
						DataObjectFormatAttribute dataObjectFormatAttribute2 = (DataObjectFormatAttribute)customAttributes2[k];
						num4 = ((dataObjectFormatAttribute2.ArrayCount == 0) ? 1 : dataObjectFormatAttribute2.ArrayCount);
						for (int l = 0; l < num4; l++)
						{
							VjKFPEKdDkroLkRlnsoDdGmPeHpW vjKFPEKdDkroLkRlnsoDdGmPeHpW = new VjKFPEKdDkroLkRlnsoDdGmPeHpW(string.IsNullOrEmpty(dataObjectFormatAttribute2.Guid) ? Guid.Empty : new Guid(dataObjectFormatAttribute2.Guid), num3, dataObjectFormatAttribute2.TypeFlags, dataObjectFormatAttribute2.Flags, dataObjectFormatAttribute2.InstanceNumber);
							string text = (string.IsNullOrEmpty(dataObjectFormatAttribute2.Name) ? fieldInfo.Name : dataObjectFormatAttribute2.Name);
							text = ((num4 == 1) ? text : (text + num6));
							vjKFPEKdDkroLkRlnsoDdGmPeHpW.Name = text;
							list.Add(vjKFPEKdDkroLkRlnsoDdGmPeHpW);
							num3 += num5;
							num6++;
						}
					}
				}
				iIzkyiFSmvFrdUqKGffvQUlfUaC.ObjectsFormat = list.ToArray();
			}
			for (int m = 0; m < iIzkyiFSmvFrdUqKGffvQUlfUaC.ObjectsFormat.Length; m++)
			{
				VjKFPEKdDkroLkRlnsoDdGmPeHpW vjKFPEKdDkroLkRlnsoDdGmPeHpW2 = iIzkyiFSmvFrdUqKGffvQUlfUaC.ObjectsFormat[m];
				if (uQnYpXmloYgnOiCmKFKuWClGEEBe.ContainsKey(vjKFPEKdDkroLkRlnsoDdGmPeHpW2.Name))
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Incorrect field name [{0}]. Field name must be unique", new object[1] { vjKFPEKdDkroLkRlnsoDdGmPeHpW2.Name }));
				}
				uQnYpXmloYgnOiCmKFKuWClGEEBe.Add(vjKFPEKdDkroLkRlnsoDdGmPeHpW2.Name, vjKFPEKdDkroLkRlnsoDdGmPeHpW2);
			}
		}
		return iIzkyiFSmvFrdUqKGffvQUlfUaC;
	}

	private unsafe void RccehtIXOTFmcunfPUpKbsQylnde(NHdgEyEPCUHJEJnxCZEJpXefukZ P_0)
	{
		NHdgEyEPCUHJEJnxCZEJpXefukZ.tJjAQIKqfgvlrvavdXIbNgNQNIjI tJjAQIKqfgvlrvavdXIbNgNQNIjI = default(NHdgEyEPCUHJEJnxCZEJpXefukZ.tJjAQIKqfgvlrvavdXIbNgNQNIjI);
		P_0.MqUkfoKMJIDnrkqFTUMSmSTDSPE(ref tJjAQIKqfgvlrvavdXIbNgNQNIjI);
		string name = typeof(TRaw).Name;
		Console.WriteLine("{0}.dwSize     {1}", name, tJjAQIKqfgvlrvavdXIbNgNQNIjI.TLeVbTkHqlErgCNobbLVWJbiKpUB);
		Console.WriteLine("{0}.dwObjSize  {1}", name, tJjAQIKqfgvlrvavdXIbNgNQNIjI.DbSofPbUNTrWgfqJSGEcQKWRsLH);
		Console.WriteLine("{0}.dwFlags    {1} ({2})", name, (int)tJjAQIKqfgvlrvavdXIbNgNQNIjI.kukmWglJDUvMDZhbIGzDAcBZJRG, tJjAQIKqfgvlrvavdXIbNgNQNIjI.kukmWglJDUvMDZhbIGzDAcBZJRG);
		Console.WriteLine("{0}.dwDataSize {1}", name, tJjAQIKqfgvlrvavdXIbNgNQNIjI.ihzsSYSJIANMfliVGXdPBmBKJbN);
		Console.WriteLine("{0}.dwNumObjs  {1}", name, tJjAQIKqfgvlrvavdXIbNgNQNIjI.qevXdTNbjnSgYNUdtyLEvceSbvE);
		Console.WriteLine("{4,32};{0,38};{1,8},{2,8};{3,8}", "Guid", "Offset", "Type", "Flags", "Name");
		VjKFPEKdDkroLkRlnsoDdGmPeHpW.tjxRjQTYPGEYOIeJdmdovMOQaBZ* ptr = (VjKFPEKdDkroLkRlnsoDdGmPeHpW.tjxRjQTYPGEYOIeJdmdovMOQaBZ*)(void*)tJjAQIKqfgvlrvavdXIbNgNQNIjI.iVCzZRhAEoANssqFZunPUegjdniF;
		for (int i = 0; i < tJjAQIKqfgvlrvavdXIbNgNQNIjI.qevXdTNbjnSgYNUdtyLEvceSbvE; i++)
		{
			VjKFPEKdDkroLkRlnsoDdGmPeHpW.tjxRjQTYPGEYOIeJdmdovMOQaBZ tjxRjQTYPGEYOIeJdmdovMOQaBZ = ptr[i];
			string text = ((tjxRjQTYPGEYOIeJdmdovMOQaBZ.hkEPZjsoluJReScMpGlSNgtNGwY == IntPtr.Zero) ? "" : ((Guid*)(void*)tjxRjQTYPGEYOIeJdmdovMOQaBZ.hkEPZjsoluJReScMpGlSNgtNGwY)->ToString());
			Console.WriteLine("{5,32};{0,38};{1,8},{2:X8};{3:X8} ({4})", text, tjxRjQTYPGEYOIeJdmdovMOQaBZ.udsPlCkQjZnJYoduwmqSePFhHcD, tjxRjQTYPGEYOIeJdmdovMOQaBZ.YTPnvkUhAkJQzxOddhUvMmmVSrU, (int)tjxRjQTYPGEYOIeJdmdovMOQaBZ.kukmWglJDUvMDZhbIGzDAcBZJRG, tjxRjQTYPGEYOIeJdmdovMOQaBZ.kukmWglJDUvMDZhbIGzDAcBZJRG, P_0.ObjectsFormat[i].Name);
		}
		Console.WriteLine();
	}
}
