using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

internal abstract class PaDVcLLSsWVKrCgzJHzOwEwqmeu<T, TRaw, TUpdate> : VVTlERCTnXczpBxPFhWZauWjerS where T : class, global::vnUBANiQfJIVAasLhjdkZgyRflNB<TRaw, TUpdate>, new() where TRaw : struct where TUpdate : struct, qpYpeINzxEGLIPgRGaGoXOSzeyBH
{
	private ZOzlYUTkIJNegfDBzGSMpXQYzKA aCblpCOIWcVzXsOIdqSqQoLQFJB;

	private readonly Dictionary<string, TPUCCgksXxnsvDrPMuvUHGYaEMum> iJtTcbxSwZvfssjMhGVhdCFlIFAb = new Dictionary<string, TPUCCgksXxnsvDrPMuvUHGYaEMum>();

	private static readonly TUpdate[] vaPfMSYYfVIMfyjbgCvDGsQTJnTG = new TUpdate[0];

	protected PaDVcLLSsWVKrCgzJHzOwEwqmeu(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	protected PaDVcLLSsWVKrCgzJHzOwEwqmeu(hhwTHKlniCMKoBzWDzyznYMwDzW directInput, Guid deviceGuid)
		: base(directInput, deviceGuid)
	{
		ZOzlYUTkIJNegfDBzGSMpXQYzKA zOzlYUTkIJNegfDBzGSMpXQYzKA = LOSXBPemvdsglvdFhPTbenvWhbn();
		baDSYAmRnniJSyhQmtxtwBRZMtL(zOzlYUTkIJNegfDBzGSMpXQYzKA);
	}

	public unsafe TUpdate[] CJmINFfPGtbRlcZjBCLqBeWNztqs()
	{
		TUpdate[] result = vaPfMSYYfVIMfyjbgCvDGsQTJnTG;
		int num = JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<hstBnNSzYjggdqGlzgWLqylVSTB>();
		int num2 = -1;
		WcKKhMRtzcuvlYdqGjTBxJLSDbCD(num, IntPtr.Zero, ref num2, 1);
		if (num2 == 0)
		{
			return result;
		}
		hstBnNSzYjggdqGlzgWLqylVSTB* ptr = stackalloc hstBnNSzYjggdqGlzgWLqylVSTB[num2];
		WcKKhMRtzcuvlYdqGjTBxJLSDbCD(num, (IntPtr)ptr, ref num2, 0);
		if (num2 == 0)
		{
			return result;
		}
		result = new TUpdate[num2];
		for (int i = 0; i < num2; i++)
		{
			result[i] = new TUpdate
			{
				RawOffset = ptr[i].cJyNeilCnUdRmKWIRHhHHebKNpEt,
				Value = ptr[i].nvzezGVBdfISGGHTlahzHbKLnPuh,
				Timestamp = ptr[i].aKJgxyJwfeSwchZuzdmIPzXzWzT,
				Sequence = ptr[i].KWSoIjFDNyjUXgpjcbcvqJFNaCc
			};
		}
		return result;
	}

	public void nPPFSRhCjNULnUJXWJMcGBiunWI(T P_0)
	{
		eBxlwDCIOedWxmHmoDvPZNlEMHf(ref P_0);
	}

	public T eBxlwDCIOedWxmHmoDvPZNlEMHf()
	{
		T result = new T();
		eBxlwDCIOedWxmHmoDvPZNlEMHf(ref result);
		return result;
	}

	public unsafe void eBxlwDCIOedWxmHmoDvPZNlEMHf(ref T P_0)
	{
		int num = JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<TRaw>();
		byte* ptr = stackalloc byte[(int)(uint)(num * 2)];
		YieiUITQIcLmhpdUyfbbxqjPbvD(num, (IntPtr)ptr);
		IntPtr intPtr = (IntPtr)ptr;
		P_0.aRreqoecxmLuIAlYVRIPwMKrCMT(intPtr);
	}

	public HMxBjwmUHlBNPuNunDJFOGXNgBM aluYLqDMdwPvroDdykYUALsijtY(string P_0)
	{
		return norZssPeUIgVxBPefqSCsWjHtKe(mENIGJAnsKvGHoAhZQYCLzEupiF(P_0).Offset, aEpEqotJzKigATcsGBsJWqvbanl.vaLIAioTxFkBKJiJCCQkeSQLwEZa);
	}

	public MyaFNoPCAihyegOoXfLlzoIPbqqx LvBWeyYBwUgqTOquAnVVhBmTFeB(string P_0)
	{
		return new MyaFNoPCAihyegOoXfLlzoIPbqqx(this, mENIGJAnsKvGHoAhZQYCLzEupiF(P_0).Offset, aEpEqotJzKigATcsGBsJWqvbanl.vaLIAioTxFkBKJiJCCQkeSQLwEZa);
	}

	private TPUCCgksXxnsvDrPMuvUHGYaEMum mENIGJAnsKvGHoAhZQYCLzEupiF(string P_0)
	{
		if (!iJtTcbxSwZvfssjMhGVhdCFlIFAb.TryGetValue(P_0, out var value))
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid name [{0}]. Must be in [{1}]", new object[2]
			{
				P_0,
				JOFzuBXkNUfGEywCsKAgVeZrrPQ.OIlEUrSiFgjSFdEJhLLHCtYsqjmh(";", iJtTcbxSwZvfssjMhGVhdCFlIFAb.Keys)
			}));
		}
		return value;
	}

	private ZOzlYUTkIJNegfDBzGSMpXQYzKA LOSXBPemvdsglvdFhPTbenvWhbn()
	{
		if (aCblpCOIWcVzXsOIdqSqQoLQFJB == null)
		{
			if (typeof(FXpbqntGCmAwnHgSXxOWzYJJyPO).IsAssignableFrom(typeof(TRaw)))
			{
				FXpbqntGCmAwnHgSXxOWzYJJyPO fXpbqntGCmAwnHgSXxOWzYJJyPO = (FXpbqntGCmAwnHgSXxOWzYJJyPO)(object)default(TRaw);
				aCblpCOIWcVzXsOIdqSqQoLQFJB = new ZOzlYUTkIJNegfDBzGSMpXQYzKA(fXpbqntGCmAwnHgSXxOWzYJJyPO.Flags)
				{
					eWxhbyRJEJBxoPGkeUikLAJgMYg = JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<TRaw>(),
					ObjectsFormat = fXpbqntGCmAwnHgSXxOWzYJJyPO.ObjectsFormat
				};
			}
			else
			{
				object[] customAttributes = typeof(TRaw).GetCustomAttributes(typeof(RKWutUoCqAxmbOvZeWzZlPmCapH), inherit: false);
				if (customAttributes.Length != 1)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The structure [{0}] must be marked with DataFormatAttribute or provide a IDataFormatProvider", new object[1] { typeof(TRaw).FullName }));
				}
				aCblpCOIWcVzXsOIdqSqQoLQFJB = new ZOzlYUTkIJNegfDBzGSMpXQYzKA(((RKWutUoCqAxmbOvZeWzZlPmCapH)customAttributes[0]).wbmxfUinNZtnthzDdPSUImGyMjT)
				{
					eWxhbyRJEJBxoPGkeUikLAJgMYg = JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<TRaw>()
				};
				List<TPUCCgksXxnsvDrPMuvUHGYaEMum> list = new List<TPUCCgksXxnsvDrPMuvUHGYaEMum>();
				FieldInfo[] fields = typeof(TRaw).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					object[] customAttributes2 = fieldInfo.GetCustomAttributes(typeof(EBEcFoxOQjUZkVlTojjnLzfpHQb), inherit: false);
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
						EBEcFoxOQjUZkVlTojjnLzfpHQb eBEcFoxOQjUZkVlTojjnLzfpHQb = (EBEcFoxOQjUZkVlTojjnLzfpHQb)customAttributes2[j];
						num4 += ((eBEcFoxOQjUZkVlTojjnLzfpHQb.kCsOdKDrXKWwFJozrDPKgLafRGD == 0) ? 1 : eBEcFoxOQjUZkVlTojjnLzfpHQb.kCsOdKDrXKWwFJozrDPKgLafRGD);
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
						EBEcFoxOQjUZkVlTojjnLzfpHQb eBEcFoxOQjUZkVlTojjnLzfpHQb2 = (EBEcFoxOQjUZkVlTojjnLzfpHQb)customAttributes2[k];
						num4 = ((eBEcFoxOQjUZkVlTojjnLzfpHQb2.kCsOdKDrXKWwFJozrDPKgLafRGD == 0) ? 1 : eBEcFoxOQjUZkVlTojjnLzfpHQb2.kCsOdKDrXKWwFJozrDPKgLafRGD);
						for (int l = 0; l < num4; l++)
						{
							TPUCCgksXxnsvDrPMuvUHGYaEMum tPUCCgksXxnsvDrPMuvUHGYaEMum = new TPUCCgksXxnsvDrPMuvUHGYaEMum(string.IsNullOrEmpty(eBEcFoxOQjUZkVlTojjnLzfpHQb2.sYsgBUbIeCqiDecxLLTsFJMgrgyP) ? Guid.Empty : new Guid(eBEcFoxOQjUZkVlTojjnLzfpHQb2.sYsgBUbIeCqiDecxLLTsFJMgrgyP), num3, eBEcFoxOQjUZkVlTojjnLzfpHQb2.OJEPRQuqoFhmyaveIKijJUjyxaI, eBEcFoxOQjUZkVlTojjnLzfpHQb2.wbmxfUinNZtnthzDdPSUImGyMjT, eBEcFoxOQjUZkVlTojjnLzfpHQb2.TkJqTVVWshNgUpSxjpbcHWRVRI);
							string text = (string.IsNullOrEmpty(eBEcFoxOQjUZkVlTojjnLzfpHQb2.eSyoLcYBIxjmWMHxuXBSshckPNq) ? fieldInfo.Name : eBEcFoxOQjUZkVlTojjnLzfpHQb2.eSyoLcYBIxjmWMHxuXBSshckPNq);
							text = ((num4 == 1) ? text : (text + num6));
							tPUCCgksXxnsvDrPMuvUHGYaEMum.Name = text;
							list.Add(tPUCCgksXxnsvDrPMuvUHGYaEMum);
							num3 += num5;
							num6++;
						}
					}
				}
				aCblpCOIWcVzXsOIdqSqQoLQFJB.ObjectsFormat = list.ToArray();
			}
			for (int m = 0; m < aCblpCOIWcVzXsOIdqSqQoLQFJB.ObjectsFormat.Length; m++)
			{
				TPUCCgksXxnsvDrPMuvUHGYaEMum tPUCCgksXxnsvDrPMuvUHGYaEMum2 = aCblpCOIWcVzXsOIdqSqQoLQFJB.ObjectsFormat[m];
				if (iJtTcbxSwZvfssjMhGVhdCFlIFAb.ContainsKey(tPUCCgksXxnsvDrPMuvUHGYaEMum2.Name))
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Incorrect field name [{0}]. Field name must be unique", new object[1] { tPUCCgksXxnsvDrPMuvUHGYaEMum2.Name }));
				}
				iJtTcbxSwZvfssjMhGVhdCFlIFAb.Add(tPUCCgksXxnsvDrPMuvUHGYaEMum2.Name, tPUCCgksXxnsvDrPMuvUHGYaEMum2);
			}
		}
		return aCblpCOIWcVzXsOIdqSqQoLQFJB;
	}

	private unsafe void TVcEuTGMEQduACTZbemPdocVZmcb(ZOzlYUTkIJNegfDBzGSMpXQYzKA P_0)
	{
		ZOzlYUTkIJNegfDBzGSMpXQYzKA.FIGVzaumQTlNsBCQEbMVZqDRBge fIGVzaumQTlNsBCQEbMVZqDRBge = default(ZOzlYUTkIJNegfDBzGSMpXQYzKA.FIGVzaumQTlNsBCQEbMVZqDRBge);
		P_0.IxSdeKJbNNiZPCGfuTHHyPvyjTN(ref fIGVzaumQTlNsBCQEbMVZqDRBge);
		string name = typeof(TRaw).Name;
		Console.WriteLine("{0}.dwSize     {1}", name, fIGVzaumQTlNsBCQEbMVZqDRBge.LFmyulvhyawdMpwOAdWQXdZXmuB);
		Console.WriteLine("{0}.dwObjSize  {1}", name, fIGVzaumQTlNsBCQEbMVZqDRBge.VUMokzaIHENMAVXbtEHdWjoqjIKD);
		Console.WriteLine("{0}.dwFlags    {1} ({2})", name, (int)fIGVzaumQTlNsBCQEbMVZqDRBge.wbmxfUinNZtnthzDdPSUImGyMjT, fIGVzaumQTlNsBCQEbMVZqDRBge.wbmxfUinNZtnthzDdPSUImGyMjT);
		Console.WriteLine("{0}.dwDataSize {1}", name, fIGVzaumQTlNsBCQEbMVZqDRBge.eWxhbyRJEJBxoPGkeUikLAJgMYg);
		Console.WriteLine("{0}.dwNumObjs  {1}", name, fIGVzaumQTlNsBCQEbMVZqDRBge.iytQDfEvUiACgrcNMrnNpDAfsSL);
		Console.WriteLine("{4,32};{0,38};{1,8},{2,8};{3,8}", "Guid", "Offset", "Type", "Flags", "Name");
		TPUCCgksXxnsvDrPMuvUHGYaEMum.IoJPqjUeXlbSxnAQmROuoCsJBKg* ptr = (TPUCCgksXxnsvDrPMuvUHGYaEMum.IoJPqjUeXlbSxnAQmROuoCsJBKg*)(void*)fIGVzaumQTlNsBCQEbMVZqDRBge.mOCTSbikWbhJUIhziaeEDCYKPebC;
		for (int i = 0; i < fIGVzaumQTlNsBCQEbMVZqDRBge.iytQDfEvUiACgrcNMrnNpDAfsSL; i++)
		{
			TPUCCgksXxnsvDrPMuvUHGYaEMum.IoJPqjUeXlbSxnAQmROuoCsJBKg ioJPqjUeXlbSxnAQmROuoCsJBKg = ptr[i];
			string text = ((ioJPqjUeXlbSxnAQmROuoCsJBKg.vCWOALfLdxLhUahqKaNTTEDswvH == IntPtr.Zero) ? "" : ((Guid*)(void*)ioJPqjUeXlbSxnAQmROuoCsJBKg.vCWOALfLdxLhUahqKaNTTEDswvH)->ToString());
			Console.WriteLine("{5,32};{0,38};{1,8},{2:X8};{3:X8} ({4})", text, ioJPqjUeXlbSxnAQmROuoCsJBKg.cJyNeilCnUdRmKWIRHhHHebKNpEt, ioJPqjUeXlbSxnAQmROuoCsJBKg.UANajORgEjGJZDtTWdmqYjUulHF, (int)ioJPqjUeXlbSxnAQmROuoCsJBKg.wbmxfUinNZtnthzDdPSUImGyMjT, ioJPqjUeXlbSxnAQmROuoCsJBKg.wbmxfUinNZtnthzDdPSUImGyMjT, P_0.ObjectsFormat[i].Name);
		}
		Console.WriteLine();
	}
}
