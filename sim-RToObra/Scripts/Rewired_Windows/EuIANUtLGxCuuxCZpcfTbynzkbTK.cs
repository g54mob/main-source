using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal abstract class EuIANUtLGxCuuxCZpcfTbynzkbTK<T, TRaw, TUpdate> : KDSdOMJuVoDYcvyddREYpsBebitH where T : class, global::kmHpGQwmXoEcVBHxRtFhghtsGww<TRaw, TUpdate>, new() where TRaw : struct where TUpdate : struct, ljBboFKnVnZvPrifuYUjgBZmjtqF
{
	private CXapDFhmxomnOYbONILulZuHwjO lRaBtBmnmVfkMfDoFUgjnIhVeWoB;

	private readonly Dictionary<string, QELlYlIyrAiPoGgdcEfDIQBxfJVy> viqiasBlIwsMbJziVtJaMWYiOTt = new Dictionary<string, QELlYlIyrAiPoGgdcEfDIQBxfJVy>();

	private static readonly TUpdate[] cpCOjNyJNohZgBDBKhQOgkPQkSk = new TUpdate[0];

	protected EuIANUtLGxCuuxCZpcfTbynzkbTK(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	protected EuIANUtLGxCuuxCZpcfTbynzkbTK(DirectInput directInput, Guid deviceGuid)
		: base(directInput, deviceGuid)
	{
		CXapDFhmxomnOYbONILulZuHwjO cXapDFhmxomnOYbONILulZuHwjO = CjHIDWOOPOYPyOtxRHtgaEaXjyY();
		kuSCIBeQTShyRNXaYYpwraQOJFkM(cXapDFhmxomnOYbONILulZuHwjO);
	}

	public unsafe TUpdate[] PpzXRYFWeKKaiaANdwJzclRSPuT()
	{
		TUpdate[] result = cpCOjNyJNohZgBDBKhQOgkPQkSk;
		int num = WISJwItoxlmpVJIyUeIxBJGahMp.XMvgwMGgZmqMvpsoWuNJPriqSDB<abqpjGkkkSDWsTPTFCBWsccYHQc>();
		int num2 = -1;
		HRBzdVpULTQVqhoIcsBEjNQPCclF(num, IntPtr.Zero, ref num2, 1);
		if (num2 == 0)
		{
			return result;
		}
		abqpjGkkkSDWsTPTFCBWsccYHQc* ptr = stackalloc abqpjGkkkSDWsTPTFCBWsccYHQc[num2];
		HRBzdVpULTQVqhoIcsBEjNQPCclF(num, (IntPtr)ptr, ref num2, 0);
		if (num2 == 0)
		{
			return result;
		}
		result = new TUpdate[num2];
		for (int i = 0; i < num2; i++)
		{
			result[i] = new TUpdate
			{
				RawOffset = ptr[i].hlnAktRuJhzkjrZorFzKwMoDRqv,
				Value = ptr[i].qCmvlLxcVUaxPDpvXtvsPlXAJOVt,
				Timestamp = ptr[i].rmWSzhneVZcvlStEXcbVANSwDVgJ,
				Sequence = ptr[i].BRXgtsvWdBGKETBZIlluegOCfvN
			};
		}
		return result;
	}

	public void ehCWKYDEXcWiwffbkCGneErfjPbB(T P_0)
	{
		xMyhUWueyTteqTQQKpHARcqPAoY(ref P_0);
	}

	public T xMyhUWueyTteqTQQKpHARcqPAoY()
	{
		T result = new T();
		xMyhUWueyTteqTQQKpHARcqPAoY(ref result);
		return result;
	}

	public unsafe void xMyhUWueyTteqTQQKpHARcqPAoY(ref T P_0)
	{
		int num = WISJwItoxlmpVJIyUeIxBJGahMp.XMvgwMGgZmqMvpsoWuNJPriqSDB<TRaw>();
		byte* ptr = stackalloc byte[(int)(uint)(num * 2)];
		NJpAeLjhmFVgkWlVMWvsxqzIbmk(num, (IntPtr)ptr);
		P_0.MarshalFrom((IntPtr)ptr);
	}

	public CwPulMNvQcCYLBIDFFYYMQMiYz nMvKHxbeJPEimfLRSBGNnIbzhqbM(string P_0)
	{
		return sfcBOntoinudwyKFJCULsuKWTCF(viQKEHeMJjSzFZqQxAcLJGwvoLy(P_0).Offset, dJadMxLMHphTVwSIgVVAONiiJrA.wsWXCtIkFuGgJgefqtKhTCFQIDcX);
	}

	public RTrTFjpNkRBJbjUYxpDqgHPCezD UwCUkjkOhvFsKnKQwrlSllYSYNc(string P_0)
	{
		return new RTrTFjpNkRBJbjUYxpDqgHPCezD(this, viQKEHeMJjSzFZqQxAcLJGwvoLy(P_0).Offset, dJadMxLMHphTVwSIgVVAONiiJrA.wsWXCtIkFuGgJgefqtKhTCFQIDcX);
	}

	private QELlYlIyrAiPoGgdcEfDIQBxfJVy viQKEHeMJjSzFZqQxAcLJGwvoLy(string P_0)
	{
		QELlYlIyrAiPoGgdcEfDIQBxfJVy value;
		if (!viqiasBlIwsMbJziVtJaMWYiOTt.TryGetValue(P_0, out value))
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid name [{0}]. Must be in [{1}]", P_0, WISJwItoxlmpVJIyUeIxBJGahMp.TkivIiwenPObKhVpNcJOpmJrSiH(";", viqiasBlIwsMbJziVtJaMWYiOTt.Keys)));
		}
		return value;
	}

	private CXapDFhmxomnOYbONILulZuHwjO CjHIDWOOPOYPyOtxRHtgaEaXjyY()
	{
		if (lRaBtBmnmVfkMfDoFUgjnIhVeWoB == null)
		{
			if (typeof(IDataFormatProvider).IsAssignableFrom(typeof(TRaw)))
			{
				IDataFormatProvider dataFormatProvider = (IDataFormatProvider)(object)default(TRaw);
				lRaBtBmnmVfkMfDoFUgjnIhVeWoB = new CXapDFhmxomnOYbONILulZuHwjO(dataFormatProvider.Flags)
				{
					rrotJhvUrwqPbiAeUWvpTADfTUB = WISJwItoxlmpVJIyUeIxBJGahMp.XMvgwMGgZmqMvpsoWuNJPriqSDB<TRaw>(),
					ObjectsFormat = dataFormatProvider.ObjectsFormat
				};
			}
			else
			{
				object[] customAttributes = typeof(TRaw).GetCustomAttributes(typeof(DataFormatAttribute), false);
				if (customAttributes.Length != 1)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The structure [{0}] must be marked with DataFormatAttribute or provide a IDataFormatProvider", typeof(TRaw).FullName));
				}
				lRaBtBmnmVfkMfDoFUgjnIhVeWoB = new CXapDFhmxomnOYbONILulZuHwjO(((DataFormatAttribute)customAttributes[0]).Flags)
				{
					rrotJhvUrwqPbiAeUWvpTADfTUB = WISJwItoxlmpVJIyUeIxBJGahMp.XMvgwMGgZmqMvpsoWuNJPriqSDB<TRaw>()
				};
				List<QELlYlIyrAiPoGgdcEfDIQBxfJVy> list = new List<QELlYlIyrAiPoGgdcEfDIQBxfJVy>();
				FieldInfo[] fields = typeof(TRaw).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					object[] customAttributes2 = fieldInfo.GetCustomAttributes(typeof(DataObjectFormatAttribute), false);
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
						throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Field [{0}] has incompatible size [{1}] and number of DataObjectAttributes [{2}]", fieldInfo.Name, (double)num2 / (double)num4, num4));
					}
					int num6 = 0;
					for (int k = 0; k < customAttributes2.Length; k++)
					{
						DataObjectFormatAttribute dataObjectFormatAttribute2 = (DataObjectFormatAttribute)customAttributes2[k];
						num4 = ((dataObjectFormatAttribute2.ArrayCount == 0) ? 1 : dataObjectFormatAttribute2.ArrayCount);
						for (int l = 0; l < num4; l++)
						{
							QELlYlIyrAiPoGgdcEfDIQBxfJVy qELlYlIyrAiPoGgdcEfDIQBxfJVy = new QELlYlIyrAiPoGgdcEfDIQBxfJVy(string.IsNullOrEmpty(dataObjectFormatAttribute2.Guid) ? Guid.Empty : new Guid(dataObjectFormatAttribute2.Guid), num3, dataObjectFormatAttribute2.TypeFlags, dataObjectFormatAttribute2.Flags, dataObjectFormatAttribute2.InstanceNumber);
							string text = (string.IsNullOrEmpty(dataObjectFormatAttribute2.Name) ? fieldInfo.Name : dataObjectFormatAttribute2.Name);
							text = ((num4 == 1) ? text : (text + num6));
							qELlYlIyrAiPoGgdcEfDIQBxfJVy.Name = text;
							list.Add(qELlYlIyrAiPoGgdcEfDIQBxfJVy);
							num3 += num5;
							num6++;
						}
					}
				}
				lRaBtBmnmVfkMfDoFUgjnIhVeWoB.ObjectsFormat = list.ToArray();
			}
			for (int m = 0; m < lRaBtBmnmVfkMfDoFUgjnIhVeWoB.ObjectsFormat.Length; m++)
			{
				QELlYlIyrAiPoGgdcEfDIQBxfJVy qELlYlIyrAiPoGgdcEfDIQBxfJVy2 = lRaBtBmnmVfkMfDoFUgjnIhVeWoB.ObjectsFormat[m];
				if (viqiasBlIwsMbJziVtJaMWYiOTt.ContainsKey(qELlYlIyrAiPoGgdcEfDIQBxfJVy2.Name))
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Incorrect field name [{0}]. Field name must be unique", qELlYlIyrAiPoGgdcEfDIQBxfJVy2.Name));
				}
				viqiasBlIwsMbJziVtJaMWYiOTt.Add(qELlYlIyrAiPoGgdcEfDIQBxfJVy2.Name, qELlYlIyrAiPoGgdcEfDIQBxfJVy2);
			}
		}
		return lRaBtBmnmVfkMfDoFUgjnIhVeWoB;
	}

	private unsafe void AExTgQyqazRTRotlCPgEspbAcpHc(CXapDFhmxomnOYbONILulZuHwjO P_0)
	{
		CXapDFhmxomnOYbONILulZuHwjO.YVEZZMEhFBfmreSdHWDtaJXqJxD yVEZZMEhFBfmreSdHWDtaJXqJxD = default(CXapDFhmxomnOYbONILulZuHwjO.YVEZZMEhFBfmreSdHWDtaJXqJxD);
		P_0.JVJzDWbbNgeMEjFGYZSGyscvUey(ref yVEZZMEhFBfmreSdHWDtaJXqJxD);
		string name = typeof(TRaw).Name;
		Console.WriteLine("{0}.dwSize     {1}", name, yVEZZMEhFBfmreSdHWDtaJXqJxD.URbjicLEKLuQBOXogMwFHYSSvns);
		Console.WriteLine("{0}.dwObjSize  {1}", name, yVEZZMEhFBfmreSdHWDtaJXqJxD.GFJhweAUfvrtLXwXZhVuhSzpPJjs);
		Console.WriteLine("{0}.dwFlags    {1} ({2})", name, (int)yVEZZMEhFBfmreSdHWDtaJXqJxD.pShanBKDpoPUyQsbLLJHCsXlpFm, yVEZZMEhFBfmreSdHWDtaJXqJxD.pShanBKDpoPUyQsbLLJHCsXlpFm);
		Console.WriteLine("{0}.dwDataSize {1}", name, yVEZZMEhFBfmreSdHWDtaJXqJxD.rrotJhvUrwqPbiAeUWvpTADfTUB);
		Console.WriteLine("{0}.dwNumObjs  {1}", name, yVEZZMEhFBfmreSdHWDtaJXqJxD.vPcdKkkQDFAflOztwCdSzVDuPto);
		Console.WriteLine("{4,32};{0,38};{1,8},{2,8};{3,8}", "Guid", "Offset", "Type", "Flags", "Name");
		QELlYlIyrAiPoGgdcEfDIQBxfJVy.qTmCLSYbupNoULyNUyEQXiWYjsW* ptr = (QELlYlIyrAiPoGgdcEfDIQBxfJVy.qTmCLSYbupNoULyNUyEQXiWYjsW*)(void*)yVEZZMEhFBfmreSdHWDtaJXqJxD.rdBiYiCOqQNkLfMZSJoLEEJVtfU;
		for (int i = 0; i < yVEZZMEhFBfmreSdHWDtaJXqJxD.vPcdKkkQDFAflOztwCdSzVDuPto; i++)
		{
			QELlYlIyrAiPoGgdcEfDIQBxfJVy.qTmCLSYbupNoULyNUyEQXiWYjsW qTmCLSYbupNoULyNUyEQXiWYjsW = ptr[i];
			string text = ((qTmCLSYbupNoULyNUyEQXiWYjsW.ajVUMnTJdGqBVHCyaBIOTYApikH == IntPtr.Zero) ? "" : ((Guid*)(void*)qTmCLSYbupNoULyNUyEQXiWYjsW.ajVUMnTJdGqBVHCyaBIOTYApikH)->ToString());
			Console.WriteLine("{5,32};{0,38};{1,8},{2:X8};{3:X8} ({4})", text, qTmCLSYbupNoULyNUyEQXiWYjsW.hlnAktRuJhzkjrZorFzKwMoDRqv, qTmCLSYbupNoULyNUyEQXiWYjsW.XRAgRlviNYwGByvwryzeCXzsCcj, (int)qTmCLSYbupNoULyNUyEQXiWYjsW.pShanBKDpoPUyQsbLLJHCsXlpFm, qTmCLSYbupNoULyNUyEQXiWYjsW.pShanBKDpoPUyQsbLLJHCsXlpFm, P_0.ObjectsFormat[i].Name);
		}
		Console.WriteLine();
	}
}
