using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal abstract class IfopOwSfYdrbloGdOuzFvDlPApLh<T, TRaw, TUpdate> : AwuBBoPdDwXozjZnASzYlJZAwvD where T : class, global::ohjCRaNdZyNtQMEVoWzrnLnKGkg<TRaw, TUpdate>, new() where TRaw : struct where TUpdate : struct, hqppqxEFMrkdOneNLCGrQSVQngm
{
	private UpIWgjOYkyIbyJoZcoYTmWTdEeb biALizRVoLnfTIOWuMqlXIlfqYi;

	private readonly Dictionary<string, CqlbPHbVrICVdDzHPpjVHSNLJlR> lESlcYkcMoCJaCAKauFaZPEEaKtd = new Dictionary<string, CqlbPHbVrICVdDzHPpjVHSNLJlR>();

	private static readonly TUpdate[] sfaEFxgJBuDaxCSzinvMYjVBqmyZ = new TUpdate[0];

	protected IfopOwSfYdrbloGdOuzFvDlPApLh(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	protected IfopOwSfYdrbloGdOuzFvDlPApLh(DirectInput directInput, Guid deviceGuid)
		: base(directInput, deviceGuid)
	{
		UpIWgjOYkyIbyJoZcoYTmWTdEeb upIWgjOYkyIbyJoZcoYTmWTdEeb = WinEhszLRYAupHxXgTPqpbgrayO();
		cakHBlbkHQdFSKzMzxtgvEIcTdy(upIWgjOYkyIbyJoZcoYTmWTdEeb);
	}

	public unsafe TUpdate[] ZNQGmupcWbvbvBnGjLbllBmhwZG()
	{
		TUpdate[] result = sfaEFxgJBuDaxCSzinvMYjVBqmyZ;
		int num = QiyhMeApbloIAQYCjGAvUEQIhAz.THBpTsDJKmVwufYBxLzZkiSYLgH<cSQcecGXeAnOjmYlufCMErooqWof>();
		int num2 = -1;
		PbeUvSJGXOtpmiyNDLKkGylgcx(num, IntPtr.Zero, ref num2, 1);
		if (num2 == 0)
		{
			return result;
		}
		cSQcecGXeAnOjmYlufCMErooqWof* ptr = stackalloc cSQcecGXeAnOjmYlufCMErooqWof[num2];
		PbeUvSJGXOtpmiyNDLKkGylgcx(num, (IntPtr)ptr, ref num2, 0);
		if (num2 == 0)
		{
			return result;
		}
		result = new TUpdate[num2];
		for (int i = 0; i < num2; i++)
		{
			result[i] = new TUpdate
			{
				RawOffset = ptr[i].hjBppRkfXtnYcuOOIniKzsiloNt,
				Value = ptr[i].qUOmbTETUXuKZoTqSzcKuTsxCRK,
				Timestamp = ptr[i].tLkcCJSJRXufqFqKczJZAESORbu,
				Sequence = ptr[i].BDdolUCFfVwLHUlthnbyhVSaGrT
			};
		}
		return result;
	}

	public void yqeNqBsXzabfJkPcTUdPXlXHRpJ(T P_0)
	{
		dBAjkoHBoFgyxqAazfpYYAufWOSd(ref P_0);
	}

	public T dBAjkoHBoFgyxqAazfpYYAufWOSd()
	{
		T result = new T();
		dBAjkoHBoFgyxqAazfpYYAufWOSd(ref result);
		return result;
	}

	public unsafe void dBAjkoHBoFgyxqAazfpYYAufWOSd(ref T P_0)
	{
		int num = QiyhMeApbloIAQYCjGAvUEQIhAz.THBpTsDJKmVwufYBxLzZkiSYLgH<TRaw>();
		byte* ptr = stackalloc byte[(int)(uint)(num * 2)];
		HjJsdhOliTAhxLoxpfgaeCjsiQc(num, (IntPtr)ptr);
		P_0.MarshalFrom((IntPtr)ptr);
	}

	public KuQxCBzznSLnNWYiaqXOToEkUKh dlDUHVUMNXtBbCtdvMANTYzTeNl(string P_0)
	{
		return yTWfAXCSklQxvzjuwVILjJycuNL(vkskZfFdXreXGDQYOIUBcCsVUkgv(P_0).Offset, hKAnPVmBPxNYWbiiXJNENasKdtGe.coZcBxRviboCxRoHYbnRLWqHgc);
	}

	public TtPKeNIuOLUvayaUGHacnDQkjXB QbygBDZApdiMVFmyDlzSGsEjiOuq(string P_0)
	{
		return new TtPKeNIuOLUvayaUGHacnDQkjXB(this, vkskZfFdXreXGDQYOIUBcCsVUkgv(P_0).Offset, hKAnPVmBPxNYWbiiXJNENasKdtGe.coZcBxRviboCxRoHYbnRLWqHgc);
	}

	private CqlbPHbVrICVdDzHPpjVHSNLJlR vkskZfFdXreXGDQYOIUBcCsVUkgv(string P_0)
	{
		CqlbPHbVrICVdDzHPpjVHSNLJlR value;
		if (!lESlcYkcMoCJaCAKauFaZPEEaKtd.TryGetValue(P_0, out value))
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid name [{0}]. Must be in [{1}]", new object[2]
			{
				P_0,
				QiyhMeApbloIAQYCjGAvUEQIhAz.JCYHSQHxbTyAHuDpgTGImGXDewF(";", lESlcYkcMoCJaCAKauFaZPEEaKtd.Keys)
			}));
		}
		return value;
	}

	private UpIWgjOYkyIbyJoZcoYTmWTdEeb WinEhszLRYAupHxXgTPqpbgrayO()
	{
		if (biALizRVoLnfTIOWuMqlXIlfqYi == null)
		{
			if (typeof(IDataFormatProvider).IsAssignableFrom(typeof(TRaw)))
			{
				IDataFormatProvider dataFormatProvider = (IDataFormatProvider)(object)default(TRaw);
				biALizRVoLnfTIOWuMqlXIlfqYi = new UpIWgjOYkyIbyJoZcoYTmWTdEeb(dataFormatProvider.Flags)
				{
					fcUgsJEhpqEhkDbQnIYjZCBVQJTD = QiyhMeApbloIAQYCjGAvUEQIhAz.THBpTsDJKmVwufYBxLzZkiSYLgH<TRaw>(),
					ObjectsFormat = dataFormatProvider.ObjectsFormat
				};
			}
			else
			{
				object[] customAttributes = typeof(TRaw).GetCustomAttributes(typeof(DataFormatAttribute), false);
				if (customAttributes.Length != 1)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The structure [{0}] must be marked with DataFormatAttribute or provide a IDataFormatProvider", new object[1] { typeof(TRaw).FullName }));
				}
				biALizRVoLnfTIOWuMqlXIlfqYi = new UpIWgjOYkyIbyJoZcoYTmWTdEeb(((DataFormatAttribute)customAttributes[0]).Flags)
				{
					fcUgsJEhpqEhkDbQnIYjZCBVQJTD = QiyhMeApbloIAQYCjGAvUEQIhAz.THBpTsDJKmVwufYBxLzZkiSYLgH<TRaw>()
				};
				List<CqlbPHbVrICVdDzHPpjVHSNLJlR> list = new List<CqlbPHbVrICVdDzHPpjVHSNLJlR>();
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
							CqlbPHbVrICVdDzHPpjVHSNLJlR cqlbPHbVrICVdDzHPpjVHSNLJlR = new CqlbPHbVrICVdDzHPpjVHSNLJlR(string.IsNullOrEmpty(dataObjectFormatAttribute2.Guid) ? Guid.Empty : new Guid(dataObjectFormatAttribute2.Guid), num3, dataObjectFormatAttribute2.TypeFlags, dataObjectFormatAttribute2.Flags, dataObjectFormatAttribute2.InstanceNumber);
							string text = (string.IsNullOrEmpty(dataObjectFormatAttribute2.Name) ? fieldInfo.Name : dataObjectFormatAttribute2.Name);
							text = ((num4 == 1) ? text : (text + num6));
							cqlbPHbVrICVdDzHPpjVHSNLJlR.Name = text;
							list.Add(cqlbPHbVrICVdDzHPpjVHSNLJlR);
							num3 += num5;
							num6++;
						}
					}
				}
				biALizRVoLnfTIOWuMqlXIlfqYi.ObjectsFormat = list.ToArray();
			}
			for (int m = 0; m < biALizRVoLnfTIOWuMqlXIlfqYi.ObjectsFormat.Length; m++)
			{
				CqlbPHbVrICVdDzHPpjVHSNLJlR cqlbPHbVrICVdDzHPpjVHSNLJlR2 = biALizRVoLnfTIOWuMqlXIlfqYi.ObjectsFormat[m];
				if (lESlcYkcMoCJaCAKauFaZPEEaKtd.ContainsKey(cqlbPHbVrICVdDzHPpjVHSNLJlR2.Name))
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Incorrect field name [{0}]. Field name must be unique", new object[1] { cqlbPHbVrICVdDzHPpjVHSNLJlR2.Name }));
				}
				lESlcYkcMoCJaCAKauFaZPEEaKtd.Add(cqlbPHbVrICVdDzHPpjVHSNLJlR2.Name, cqlbPHbVrICVdDzHPpjVHSNLJlR2);
			}
		}
		return biALizRVoLnfTIOWuMqlXIlfqYi;
	}

	private unsafe void YOXjmuBVwjGlElmNfyWEhaxydRJ(UpIWgjOYkyIbyJoZcoYTmWTdEeb P_0)
	{
		UpIWgjOYkyIbyJoZcoYTmWTdEeb.YhgBNYGjPBzPFQlbdRkMfWeBjPGz yhgBNYGjPBzPFQlbdRkMfWeBjPGz = default(UpIWgjOYkyIbyJoZcoYTmWTdEeb.YhgBNYGjPBzPFQlbdRkMfWeBjPGz);
		P_0.HcrwktGifgIdRsltvHRKdCoBbCuB(ref yhgBNYGjPBzPFQlbdRkMfWeBjPGz);
		string name = typeof(TRaw).Name;
		Console.WriteLine("{0}.dwSize     {1}", name, yhgBNYGjPBzPFQlbdRkMfWeBjPGz.SgJtVUqCMXXZWFYoZOePEhSyhZe);
		Console.WriteLine("{0}.dwObjSize  {1}", name, yhgBNYGjPBzPFQlbdRkMfWeBjPGz.QnhhmGrfrlskSphJiRjiTrZBHaf);
		Console.WriteLine("{0}.dwFlags    {1} ({2})", name, (int)yhgBNYGjPBzPFQlbdRkMfWeBjPGz.rgNOkrpmhiGBrLTBaaLZBGFVYBc, yhgBNYGjPBzPFQlbdRkMfWeBjPGz.rgNOkrpmhiGBrLTBaaLZBGFVYBc);
		Console.WriteLine("{0}.dwDataSize {1}", name, yhgBNYGjPBzPFQlbdRkMfWeBjPGz.fcUgsJEhpqEhkDbQnIYjZCBVQJTD);
		Console.WriteLine("{0}.dwNumObjs  {1}", name, yhgBNYGjPBzPFQlbdRkMfWeBjPGz.zECnNALaDTVisVXTVnxQiPDQprg);
		Console.WriteLine("{4,32};{0,38};{1,8},{2,8};{3,8}", "Guid", "Offset", "Type", "Flags", "Name");
		CqlbPHbVrICVdDzHPpjVHSNLJlR.LTjmoNgqLTongzWaRXEjYomTZus* ptr = (CqlbPHbVrICVdDzHPpjVHSNLJlR.LTjmoNgqLTongzWaRXEjYomTZus*)(void*)yhgBNYGjPBzPFQlbdRkMfWeBjPGz.fqfFREhpqGjoEqRffsNFJBXpdAM;
		for (int i = 0; i < yhgBNYGjPBzPFQlbdRkMfWeBjPGz.zECnNALaDTVisVXTVnxQiPDQprg; i++)
		{
			CqlbPHbVrICVdDzHPpjVHSNLJlR.LTjmoNgqLTongzWaRXEjYomTZus lTjmoNgqLTongzWaRXEjYomTZus = ptr[i];
			string text = ((lTjmoNgqLTongzWaRXEjYomTZus.eebZVswKHODlKiMeVNJWkWWFXceV == IntPtr.Zero) ? "" : ((Guid*)(void*)lTjmoNgqLTongzWaRXEjYomTZus.eebZVswKHODlKiMeVNJWkWWFXceV)->ToString());
			Console.WriteLine("{5,32};{0,38};{1,8},{2:X8};{3:X8} ({4})", text, lTjmoNgqLTongzWaRXEjYomTZus.hjBppRkfXtnYcuOOIniKzsiloNt, lTjmoNgqLTongzWaRXEjYomTZus.PFyVjnGpmOklNfqHTmcjHyNFdUs, (int)lTjmoNgqLTongzWaRXEjYomTZus.rgNOkrpmhiGBrLTBaaLZBGFVYBc, lTjmoNgqLTongzWaRXEjYomTZus.rgNOkrpmhiGBrLTBaaLZBGFVYBc, P_0.ObjectsFormat[i].Name);
		}
		Console.WriteLine();
	}
}
