using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class zhfPNWSRlKRFPvTawRzkutbfsyG : xSHRGmoevrIxtWOdFoYGCWpzcJB
{
	private readonly Dictionary<Guid, iOSaYhIovYBYpfiucOzLiKYFEPX> qiQiyRzVNvQxSzahoXASELDCIlmB = new Dictionary<Guid, iOSaYhIovYBYpfiucOzLiKYFEPX>();

	private static readonly Dictionary<Type, List<Type>> EvyZQBmSnorrlCdMsUTyTPiratH = new Dictionary<Type, List<Type>>();

	private IntPtr xKMyDPRDQWOQduxuvHeXEXRJiOu;

	[CompilerGenerated]
	private IntPtr[] YmRvDlxxSiLinphEhCvjYWGsYik;

	public IntPtr[] Guids
	{
		[CompilerGenerated]
		get
		{
			return YmRvDlxxSiLinphEhCvjYWGsYik;
		}
		[CompilerGenerated]
		private set
		{
			YmRvDlxxSiLinphEhCvjYWGsYik = value;
		}
	}

	public void BVmTKMsAVVqdkfwNjSwlgNFzTsh(UjWdPKrIisWRvtOtTtqXWszemnj P_0)
	{
		P_0.Shadow = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (EvyZQBmSnorrlCdMsUTyTPiratH)
		{
			if (!EvyZQBmSnorrlCdMsUTyTPiratH.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				EvyZQBmSnorrlCdMsUTyTPiratH.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					PXswZWAwFNIhJrjZJVhTagsuPZR pXswZWAwFNIhJrjZJVhTagsuPZR = PXswZWAwFNIhJrjZJVhTagsuPZR.IzmYoCantdlEDbvheGAmRxNbwRb(type2);
					if (pXswZWAwFNIhJrjZJVhTagsuPZR == null)
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
		iOSaYhIovYBYpfiucOzLiKYFEPX iOSaYhIovYBYpfiucOzLiKYFEPX2 = null;
		foreach (Type item2 in value)
		{
			PXswZWAwFNIhJrjZJVhTagsuPZR pXswZWAwFNIhJrjZJVhTagsuPZR2 = PXswZWAwFNIhJrjZJVhTagsuPZR.IzmYoCantdlEDbvheGAmRxNbwRb(item2);
			iOSaYhIovYBYpfiucOzLiKYFEPX iOSaYhIovYBYpfiucOzLiKYFEPX3 = (iOSaYhIovYBYpfiucOzLiKYFEPX)Activator.CreateInstance(pXswZWAwFNIhJrjZJVhTagsuPZR2.Type);
			iOSaYhIovYBYpfiucOzLiKYFEPX3.BVmTKMsAVVqdkfwNjSwlgNFzTsh(P_0);
			if (iOSaYhIovYBYpfiucOzLiKYFEPX2 == null)
			{
				iOSaYhIovYBYpfiucOzLiKYFEPX2 = iOSaYhIovYBYpfiucOzLiKYFEPX3;
				qiQiyRzVNvQxSzahoXASELDCIlmB.Add(GwRCdDVnMlcbisRiTXyMToiJxJP.NZAUcxSPDbaOkQBtuRztHciqezQ, iOSaYhIovYBYpfiucOzLiKYFEPX2);
			}
			qiQiyRzVNvQxSzahoXASELDCIlmB.Add(JOFzuBXkNUfGEywCsKAgVeZrrPQ.xIzFKzBrScusgIgzonXSDEIBBjBl(item2), iOSaYhIovYBYpfiucOzLiKYFEPX3);
			Type[] interfaces3 = item2.GetInterfaces();
			Type[] array3 = interfaces3;
			foreach (Type type3 in array3)
			{
				PXswZWAwFNIhJrjZJVhTagsuPZR pXswZWAwFNIhJrjZJVhTagsuPZR3 = PXswZWAwFNIhJrjZJVhTagsuPZR.IzmYoCantdlEDbvheGAmRxNbwRb(type3);
				if (pXswZWAwFNIhJrjZJVhTagsuPZR3 != null)
				{
					qiQiyRzVNvQxSzahoXASELDCIlmB.Add(JOFzuBXkNUfGEywCsKAgVeZrrPQ.xIzFKzBrScusgIgzonXSDEIBBjBl(type3), iOSaYhIovYBYpfiucOzLiKYFEPX3);
				}
			}
		}
	}

	internal IntPtr PYgQmrazoUqWjrASzZcCXOaxeza(Type P_0)
	{
		return PYgQmrazoUqWjrASzZcCXOaxeza(JOFzuBXkNUfGEywCsKAgVeZrrPQ.xIzFKzBrScusgIgzonXSDEIBBjBl(P_0));
	}

	internal IntPtr PYgQmrazoUqWjrASzZcCXOaxeza(Guid P_0)
	{
		return KldRLZzHdlIkGJfdHORAwJxVxqOh(P_0)?.NativePointer ?? IntPtr.Zero;
	}

	internal iOSaYhIovYBYpfiucOzLiKYFEPX KldRLZzHdlIkGJfdHORAwJxVxqOh(Guid P_0)
	{
		qiQiyRzVNvQxSzahoXASELDCIlmB.TryGetValue(P_0, out var value);
		return value;
	}

	protected override void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (iOSaYhIovYBYpfiucOzLiKYFEPX value in qiQiyRzVNvQxSzahoXASELDCIlmB.Values)
		{
			value.Dispose();
		}
		qiQiyRzVNvQxSzahoXASELDCIlmB.Clear();
		if (xKMyDPRDQWOQduxuvHeXEXRJiOu != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(xKMyDPRDQWOQduxuvHeXEXRJiOu);
			xKMyDPRDQWOQduxuvHeXEXRJiOu = IntPtr.Zero;
		}
	}
}
