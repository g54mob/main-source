using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX;

internal class gmwbVFwVVbYwAOUYGJvhsoowZxj : whSGMljKVQaOqipJrvAXBUmGuWoe
{
	private readonly Dictionary<Guid, dDFAwakRIfhZuEMJAlIIyVPSACy> fJTTwGVDzQlEZSyRSOSTOMIFimJC = new Dictionary<Guid, dDFAwakRIfhZuEMJAlIIyVPSACy>();

	private static readonly Dictionary<Type, List<Type>> TwnBUJKxkNWdqnPBEYrOTfQaIpK = new Dictionary<Type, List<Type>>();

	private IntPtr qCLcEIxynvlccHWhDNpOKImCrcL;

	[CompilerGenerated]
	private IntPtr[] FLCEHcJViHDLwKHqJwnsGOBznvX;

	public IntPtr[] Guids
	{
		[CompilerGenerated]
		get
		{
			return FLCEHcJViHDLwKHqJwnsGOBznvX;
		}
		[CompilerGenerated]
		private set
		{
			FLCEHcJViHDLwKHqJwnsGOBznvX = value;
		}
	}

	public void OXxfSVQgpwyQzMSlFTkamYYmQrW(JEVDpHBHSPadiMQJjgeUMgqxoVU P_0)
	{
		P_0.Shadow = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (TwnBUJKxkNWdqnPBEYrOTfQaIpK)
		{
			if (!TwnBUJKxkNWdqnPBEYrOTfQaIpK.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				TwnBUJKxkNWdqnPBEYrOTfQaIpK.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					ShadowAttribute shadowAttribute = ShadowAttribute.Get(type2);
					if (shadowAttribute == null)
					{
						value.Remove(type2);
						continue;
					}
					Type[] interfaces2 = type2.GetInterfaces();
					Type[] array2 = interfaces2;
					foreach (Type item in array2)
					{
						value.Remove(item);
					}
				}
			}
		}
		dDFAwakRIfhZuEMJAlIIyVPSACy dDFAwakRIfhZuEMJAlIIyVPSACy2 = null;
		foreach (Type item2 in value)
		{
			ShadowAttribute shadowAttribute2 = ShadowAttribute.Get(item2);
			dDFAwakRIfhZuEMJAlIIyVPSACy dDFAwakRIfhZuEMJAlIIyVPSACy3 = (dDFAwakRIfhZuEMJAlIIyVPSACy)Activator.CreateInstance(shadowAttribute2.Type);
			dDFAwakRIfhZuEMJAlIIyVPSACy3.OXxfSVQgpwyQzMSlFTkamYYmQrW(P_0);
			if (dDFAwakRIfhZuEMJAlIIyVPSACy2 == null)
			{
				dDFAwakRIfhZuEMJAlIIyVPSACy2 = dDFAwakRIfhZuEMJAlIIyVPSACy3;
				fJTTwGVDzQlEZSyRSOSTOMIFimJC.Add(BAiMOpdqIqBrDXEAdTHnBfiCokc.IsPfoeivlSuxhnsHEJvuHPtffwv, dDFAwakRIfhZuEMJAlIIyVPSACy2);
			}
			fJTTwGVDzQlEZSyRSOSTOMIFimJC.Add(WISJwItoxlmpVJIyUeIxBJGahMp.olyRIoVpgHEVfeBJYQNNEQFQUwmo(item2), dDFAwakRIfhZuEMJAlIIyVPSACy3);
			Type[] interfaces3 = item2.GetInterfaces();
			Type[] array3 = interfaces3;
			foreach (Type type3 in array3)
			{
				ShadowAttribute shadowAttribute3 = ShadowAttribute.Get(type3);
				if (shadowAttribute3 != null)
				{
					fJTTwGVDzQlEZSyRSOSTOMIFimJC.Add(WISJwItoxlmpVJIyUeIxBJGahMp.olyRIoVpgHEVfeBJYQNNEQFQUwmo(type3), dDFAwakRIfhZuEMJAlIIyVPSACy3);
				}
			}
		}
	}

	internal IntPtr SahEcyAYIxyfuYacDzqDNNvmCaR(Type P_0)
	{
		return SahEcyAYIxyfuYacDzqDNNvmCaR(WISJwItoxlmpVJIyUeIxBJGahMp.olyRIoVpgHEVfeBJYQNNEQFQUwmo(P_0));
	}

	internal IntPtr SahEcyAYIxyfuYacDzqDNNvmCaR(Guid P_0)
	{
		dDFAwakRIfhZuEMJAlIIyVPSACy dDFAwakRIfhZuEMJAlIIyVPSACy2 = JjoGRGdDBKzLHQSFbsVDtXyMvnpt(P_0);
		if (dDFAwakRIfhZuEMJAlIIyVPSACy2 != null)
		{
			return dDFAwakRIfhZuEMJAlIIyVPSACy2.NativePointer;
		}
		return IntPtr.Zero;
	}

	internal dDFAwakRIfhZuEMJAlIIyVPSACy JjoGRGdDBKzLHQSFbsVDtXyMvnpt(Guid P_0)
	{
		dDFAwakRIfhZuEMJAlIIyVPSACy value;
		fJTTwGVDzQlEZSyRSOSTOMIFimJC.TryGetValue(P_0, out value);
		return value;
	}

	protected override void Dispose(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (dDFAwakRIfhZuEMJAlIIyVPSACy value in fJTTwGVDzQlEZSyRSOSTOMIFimJC.Values)
		{
			value.Dispose();
		}
		fJTTwGVDzQlEZSyRSOSTOMIFimJC.Clear();
		if (qCLcEIxynvlccHWhDNpOKImCrcL != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(qCLcEIxynvlccHWhDNpOKImCrcL);
			qCLcEIxynvlccHWhDNpOKImCrcL = IntPtr.Zero;
		}
	}
}
