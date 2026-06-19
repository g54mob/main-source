using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class lqlEvreCeUBEyXYsREUygCSBBDAs : nUFVjDQgulHcSkqjanrIKQIVBcJO
{
	private readonly Dictionary<Guid, maUQVIwwcWHFQRLsJnGZiMhxTwNu> uujkEIgtsZgXgZWpraKMcFpKYnuM = new Dictionary<Guid, maUQVIwwcWHFQRLsJnGZiMhxTwNu>();

	private static readonly Dictionary<Type, List<Type>> wpXiFNHkeGnrOqidlopeRacJdphO = new Dictionary<Type, List<Type>>();

	private IntPtr pUzxnOCXxzAUzGHUOTfxozfYEhNj;

	[CompilerGenerated]
	private IntPtr[] oYDierPRlWBUutIpiCOjeCJQWMWk;

	public IntPtr[] yjPLdFnkmEilNtETJhpKfgwweWlr
	{
		[CompilerGenerated]
		get
		{
			return oYDierPRlWBUutIpiCOjeCJQWMWk;
		}
		[CompilerGenerated]
		private set
		{
			oYDierPRlWBUutIpiCOjeCJQWMWk = array;
		}
	}

	public void DauixeGyuoGnfayLpHRkRkahsmyS(OoSlEvNijyXWSRDrosRXWoOMMObY P_0)
	{
		P_0.DyYFhntRqZybWJEtBwmtLoktRNVf = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (wpXiFNHkeGnrOqidlopeRacJdphO)
		{
			if (!wpXiFNHkeGnrOqidlopeRacJdphO.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				wpXiFNHkeGnrOqidlopeRacJdphO.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					if (TssDjpCupDnFyJFBikuHAyDFEgRQB.AvhmyxyIFeiLOqKsbHNGVTjFpmAi(type2) == null)
					{
						value.Remove(type2);
						continue;
					}
					Type[] interfaces2 = type2.GetInterfaces();
					foreach (Type item in interfaces2)
					{
						value.Remove(item);
					}
				}
			}
		}
		maUQVIwwcWHFQRLsJnGZiMhxTwNu maUQVIwwcWHFQRLsJnGZiMhxTwNu2 = null;
		foreach (Type item2 in value)
		{
			maUQVIwwcWHFQRLsJnGZiMhxTwNu maUQVIwwcWHFQRLsJnGZiMhxTwNu3 = (maUQVIwwcWHFQRLsJnGZiMhxTwNu)Activator.CreateInstance(TssDjpCupDnFyJFBikuHAyDFEgRQB.AvhmyxyIFeiLOqKsbHNGVTjFpmAi(item2).ozfsHIVVvYvpdkKXGofGpJCrcgkm);
			maUQVIwwcWHFQRLsJnGZiMhxTwNu3.WMPfEkOhSjTKbIrBiJcOKkGozpTx(P_0);
			if (maUQVIwwcWHFQRLsJnGZiMhxTwNu2 == null)
			{
				maUQVIwwcWHFQRLsJnGZiMhxTwNu2 = maUQVIwwcWHFQRLsJnGZiMhxTwNu3;
				uujkEIgtsZgXgZWpraKMcFpKYnuM.Add(MbHJNmfWVtPrZYOeqjwQiTLjzKHPA.rTgWOheazCNxsPYDwUzDWuQzdBE, maUQVIwwcWHFQRLsJnGZiMhxTwNu2);
			}
			uujkEIgtsZgXgZWpraKMcFpKYnuM.Add(VRhfcElUYIDhtSYXXbsQDsFMgObb.CUyAkLJQkYDNVHpWkzgMnFUoXATqA(item2), maUQVIwwcWHFQRLsJnGZiMhxTwNu3);
			Type[] array = item2.GetInterfaces();
			foreach (Type type3 in array)
			{
				if (TssDjpCupDnFyJFBikuHAyDFEgRQB.AvhmyxyIFeiLOqKsbHNGVTjFpmAi(type3) != null)
				{
					uujkEIgtsZgXgZWpraKMcFpKYnuM.Add(VRhfcElUYIDhtSYXXbsQDsFMgObb.CUyAkLJQkYDNVHpWkzgMnFUoXATqA(type3), maUQVIwwcWHFQRLsJnGZiMhxTwNu3);
				}
			}
		}
	}

	internal IntPtr FwMBllPPNRXueNRQpdrcJPqpQMeiA(Type P_0)
	{
		return HJeViIAiBKcZVoPFaLVyuMLNKxtv(VRhfcElUYIDhtSYXXbsQDsFMgObb.CUyAkLJQkYDNVHpWkzgMnFUoXATqA(P_0));
	}

	internal IntPtr HJeViIAiBKcZVoPFaLVyuMLNKxtv(Guid P_0)
	{
		return gVhcRytMXfRYDplNpwgwrqUmhTXR(P_0)?.NyNAWzgABNADwGOukARROJWSWCZo ?? IntPtr.Zero;
	}

	internal maUQVIwwcWHFQRLsJnGZiMhxTwNu gVhcRytMXfRYDplNpwgwrqUmhTXR(Guid P_0)
	{
		uujkEIgtsZgXgZWpraKMcFpKYnuM.TryGetValue(P_0, out var value);
		return value;
	}

	protected virtual void ffULMSOHZOTxWedpdEaREBTGMBvf(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (maUQVIwwcWHFQRLsJnGZiMhxTwNu value in uujkEIgtsZgXgZWpraKMcFpKYnuM.Values)
		{
			value.Dispose();
		}
		uujkEIgtsZgXgZWpraKMcFpKYnuM.Clear();
		if (pUzxnOCXxzAUzGHUOTfxozfYEhNj != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(pUzxnOCXxzAUzGHUOTfxozfYEhNj);
			pUzxnOCXxzAUzGHUOTfxozfYEhNj = IntPtr.Zero;
		}
	}
}
