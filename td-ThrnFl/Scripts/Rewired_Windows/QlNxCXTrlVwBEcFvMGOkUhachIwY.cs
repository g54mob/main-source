using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class QlNxCXTrlVwBEcFvMGOkUhachIwY : YaficjjcbebAyTusfKjCqxiqEvdq
{
	private readonly Dictionary<Guid, DeyfmwNUpNcdcgevEUIZIIFKEdvu> ZQFNdiBGxImvEkuqmHMKUpDzveYR = new Dictionary<Guid, DeyfmwNUpNcdcgevEUIZIIFKEdvu>();

	private static readonly Dictionary<Type, List<Type>> FfOTlaDrVUZsVvygAkwvrOgDiBq = new Dictionary<Type, List<Type>>();

	private IntPtr AZZYGermuqiNJnmNVFhfEHNhNedL;

	[CompilerGenerated]
	private IntPtr[] HqtbNXwBcRPlKQdmhTWvAFphmLuW;

	public IntPtr[] XvvahXWdxHSzcYUcYfgMBYgNZPRD
	{
		[CompilerGenerated]
		get
		{
			return HqtbNXwBcRPlKQdmhTWvAFphmLuW;
		}
		[CompilerGenerated]
		private set
		{
			HqtbNXwBcRPlKQdmhTWvAFphmLuW = hqtbNXwBcRPlKQdmhTWvAFphmLuW;
		}
	}

	public void qrMQOAnWbndLDNvOuCHkfnGKflSkA(bkoJnPgJsdhsouQyfcFPIuslpRXdb P_0)
	{
		P_0.ihwqaZQGGKMtmuBcCgMnhvAYMNzk = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (FfOTlaDrVUZsVvygAkwvrOgDiBq)
		{
			if (!FfOTlaDrVUZsVvygAkwvrOgDiBq.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				FfOTlaDrVUZsVvygAkwvrOgDiBq.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					if (oVWxIDFOqYRfAszIptyJEjllahdw.jMBANPNVQxwUqLkzgOPGvXHqhsiu(type2) == null)
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
		DeyfmwNUpNcdcgevEUIZIIFKEdvu deyfmwNUpNcdcgevEUIZIIFKEdvu = null;
		foreach (Type item2 in value)
		{
			DeyfmwNUpNcdcgevEUIZIIFKEdvu deyfmwNUpNcdcgevEUIZIIFKEdvu2 = (DeyfmwNUpNcdcgevEUIZIIFKEdvu)Activator.CreateInstance(oVWxIDFOqYRfAszIptyJEjllahdw.jMBANPNVQxwUqLkzgOPGvXHqhsiu(item2).RpVBZmmDyVERBANPLvqMXXcEzfWx);
			deyfmwNUpNcdcgevEUIZIIFKEdvu2.xkbqdGnPZaLmXtYYpoxCohwDgwtr(P_0);
			if (deyfmwNUpNcdcgevEUIZIIFKEdvu == null)
			{
				deyfmwNUpNcdcgevEUIZIIFKEdvu = deyfmwNUpNcdcgevEUIZIIFKEdvu2;
				ZQFNdiBGxImvEkuqmHMKUpDzveYR.Add(nWdnoMMGWepPnfVznKoGjYzUqDnq.GwxZeyQdjgeeXRjOAeUbzhadoAxl, deyfmwNUpNcdcgevEUIZIIFKEdvu);
			}
			ZQFNdiBGxImvEkuqmHMKUpDzveYR.Add(qEhGRKCBLVdeTteVGclkbvGuEbqQ.bGCXVpolhJDrpQFPxBcYedsBnHvXA(item2), deyfmwNUpNcdcgevEUIZIIFKEdvu2);
			Type[] array = item2.GetInterfaces();
			foreach (Type type3 in array)
			{
				if (oVWxIDFOqYRfAszIptyJEjllahdw.jMBANPNVQxwUqLkzgOPGvXHqhsiu(type3) != null)
				{
					ZQFNdiBGxImvEkuqmHMKUpDzveYR.Add(qEhGRKCBLVdeTteVGclkbvGuEbqQ.bGCXVpolhJDrpQFPxBcYedsBnHvXA(type3), deyfmwNUpNcdcgevEUIZIIFKEdvu2);
				}
			}
		}
	}

	internal IntPtr kmuGRJavCAWnScyHqdmcdVMEVXCG(Type P_0)
	{
		return uRCcOqruWFvDnPXQlVheAHnkiUZL(qEhGRKCBLVdeTteVGclkbvGuEbqQ.bGCXVpolhJDrpQFPxBcYedsBnHvXA(P_0));
	}

	internal IntPtr uRCcOqruWFvDnPXQlVheAHnkiUZL(Guid P_0)
	{
		return ZMJsrIItMqwvxAEIoiPyRayHEczf(P_0)?.odpdeHVpSKtJOjaxhiXZmqovsVjq ?? IntPtr.Zero;
	}

	internal DeyfmwNUpNcdcgevEUIZIIFKEdvu ZMJsrIItMqwvxAEIoiPyRayHEczf(Guid P_0)
	{
		ZQFNdiBGxImvEkuqmHMKUpDzveYR.TryGetValue(P_0, out var value);
		return value;
	}

	protected virtual void MeLesFdONPzwHLywmAZbcndlDJqB(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (DeyfmwNUpNcdcgevEUIZIIFKEdvu value in ZQFNdiBGxImvEkuqmHMKUpDzveYR.Values)
		{
			value.Dispose();
		}
		ZQFNdiBGxImvEkuqmHMKUpDzveYR.Clear();
		if (AZZYGermuqiNJnmNVFhfEHNhNedL != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(AZZYGermuqiNJnmNVFhfEHNhNedL);
			AZZYGermuqiNJnmNVFhfEHNhNedL = IntPtr.Zero;
		}
	}
}
