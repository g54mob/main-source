using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX;

internal class uIUGPlDgBlthVDXefxRhzAiUrij : cmmTIRbfTUTdtkqdISXVDgTWEci
{
	private readonly Dictionary<Guid, jwzGTEgJThlahTtazxrQriNiTCg> hjhxgmqboSVeYJdonWoZJCcdeQP = new Dictionary<Guid, jwzGTEgJThlahTtazxrQriNiTCg>();

	private static readonly Dictionary<Type, List<Type>> ZUXDKntXyHEJreLtlfUIgGCEZxGl = new Dictionary<Type, List<Type>>();

	private IntPtr eJlwpmORchFmfAKeeTPIZwEgcdR;

	[CompilerGenerated]
	private IntPtr[] JMsOXUoMaZIobXMSwfiaZeHNetD;

	public IntPtr[] Guids
	{
		[CompilerGenerated]
		get
		{
			return JMsOXUoMaZIobXMSwfiaZeHNetD;
		}
		[CompilerGenerated]
		private set
		{
			JMsOXUoMaZIobXMSwfiaZeHNetD = value;
		}
	}

	public void GVPNrpnUrcRcuBVNsoUmnQYWdWW(VJvDCfEiULZhxmTbSdcYPJiPZwU P_0)
	{
		P_0.Shadow = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (ZUXDKntXyHEJreLtlfUIgGCEZxGl)
		{
			if (!ZUXDKntXyHEJreLtlfUIgGCEZxGl.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				ZUXDKntXyHEJreLtlfUIgGCEZxGl.Add(type, value);
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
		jwzGTEgJThlahTtazxrQriNiTCg jwzGTEgJThlahTtazxrQriNiTCg2 = null;
		foreach (Type item2 in value)
		{
			ShadowAttribute shadowAttribute2 = ShadowAttribute.Get(item2);
			jwzGTEgJThlahTtazxrQriNiTCg jwzGTEgJThlahTtazxrQriNiTCg3 = (jwzGTEgJThlahTtazxrQriNiTCg)Activator.CreateInstance(shadowAttribute2.Type);
			jwzGTEgJThlahTtazxrQriNiTCg3.GVPNrpnUrcRcuBVNsoUmnQYWdWW(P_0);
			if (jwzGTEgJThlahTtazxrQriNiTCg2 == null)
			{
				jwzGTEgJThlahTtazxrQriNiTCg2 = jwzGTEgJThlahTtazxrQriNiTCg3;
				hjhxgmqboSVeYJdonWoZJCcdeQP.Add(FwuzHcULcISWeGfsMgRDAmleAcc.OUpnBKDilEcqokAbrIlkhWvNrglR, jwzGTEgJThlahTtazxrQriNiTCg2);
			}
			hjhxgmqboSVeYJdonWoZJCcdeQP.Add(QiyhMeApbloIAQYCjGAvUEQIhAz.eJGRPSwwoFMekYKtfHcXZcReBes(item2), jwzGTEgJThlahTtazxrQriNiTCg3);
			Type[] interfaces3 = item2.GetInterfaces();
			Type[] array3 = interfaces3;
			foreach (Type type3 in array3)
			{
				ShadowAttribute shadowAttribute3 = ShadowAttribute.Get(type3);
				if (shadowAttribute3 != null)
				{
					hjhxgmqboSVeYJdonWoZJCcdeQP.Add(QiyhMeApbloIAQYCjGAvUEQIhAz.eJGRPSwwoFMekYKtfHcXZcReBes(type3), jwzGTEgJThlahTtazxrQriNiTCg3);
				}
			}
		}
	}

	internal IntPtr QYDfLSnALpsGfPExecRVCpKKeSN(Type P_0)
	{
		return QYDfLSnALpsGfPExecRVCpKKeSN(QiyhMeApbloIAQYCjGAvUEQIhAz.eJGRPSwwoFMekYKtfHcXZcReBes(P_0));
	}

	internal IntPtr QYDfLSnALpsGfPExecRVCpKKeSN(Guid P_0)
	{
		jwzGTEgJThlahTtazxrQriNiTCg jwzGTEgJThlahTtazxrQriNiTCg2 = ZfIOhawRxGSAGZcpAROPEComjvb(P_0);
		if (jwzGTEgJThlahTtazxrQriNiTCg2 != null)
		{
			return jwzGTEgJThlahTtazxrQriNiTCg2.NativePointer;
		}
		return IntPtr.Zero;
	}

	internal jwzGTEgJThlahTtazxrQriNiTCg ZfIOhawRxGSAGZcpAROPEComjvb(Guid P_0)
	{
		jwzGTEgJThlahTtazxrQriNiTCg value;
		hjhxgmqboSVeYJdonWoZJCcdeQP.TryGetValue(P_0, out value);
		return value;
	}

	protected override void Dispose(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (jwzGTEgJThlahTtazxrQriNiTCg value in hjhxgmqboSVeYJdonWoZJCcdeQP.Values)
		{
			value.Dispose();
		}
		hjhxgmqboSVeYJdonWoZJCcdeQP.Clear();
		if (eJlwpmORchFmfAKeeTPIZwEgcdR != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(eJlwpmORchFmfAKeeTPIZwEgcdR);
			eJlwpmORchFmfAKeeTPIZwEgcdR = IntPtr.Zero;
		}
	}
}
