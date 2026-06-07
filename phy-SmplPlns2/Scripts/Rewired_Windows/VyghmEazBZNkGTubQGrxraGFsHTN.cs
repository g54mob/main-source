using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class VyghmEazBZNkGTubQGrxraGFsHTN : BoWDhsOlRuuSewMsxfGDRjABgwGbA
{
	private readonly Dictionary<Guid, AQFnijkWHNrZqHVnChgGlanhcgGV> YAwFwrcTVSGdUDBcyTvVtRvUGjlt = new Dictionary<Guid, AQFnijkWHNrZqHVnChgGlanhcgGV>();

	private static readonly Dictionary<Type, List<Type>> KAGYAqVkBJAHykkiqpJlWAuXcdebA = new Dictionary<Type, List<Type>>();

	private IntPtr PouFFvKqOuAsZWuZTZeytcpOeMWIA;

	[CompilerGenerated]
	private IntPtr[] IDKPCEFMGTgtGvAalTxkfAVOVGHy;

	public IntPtr[] QKUWbipkJNSXvxwCKErDemikGnaH
	{
		[CompilerGenerated]
		get
		{
			return IDKPCEFMGTgtGvAalTxkfAVOVGHy;
		}
		[CompilerGenerated]
		private set
		{
			IDKPCEFMGTgtGvAalTxkfAVOVGHy = iDKPCEFMGTgtGvAalTxkfAVOVGHy;
		}
	}

	public void pBraFBGTTdGDZsqUkaixMdqnqirW(mtNcaKVQQjgkmRbmzgRSHcUSQywh P_0)
	{
		P_0.bbFIjAntcShEgINaEWFofKexFZYgb = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (KAGYAqVkBJAHykkiqpJlWAuXcdebA)
		{
			if (!KAGYAqVkBJAHykkiqpJlWAuXcdebA.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				KAGYAqVkBJAHykkiqpJlWAuXcdebA.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					if (hFtBUHwCFYxSLNEjhJfIrXUEuTED.mZmqGAaqwvVMugMhumuHUJtJDvLHA(type2) == null)
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
		AQFnijkWHNrZqHVnChgGlanhcgGV aQFnijkWHNrZqHVnChgGlanhcgGV = null;
		foreach (Type item2 in value)
		{
			AQFnijkWHNrZqHVnChgGlanhcgGV aQFnijkWHNrZqHVnChgGlanhcgGV2 = (AQFnijkWHNrZqHVnChgGlanhcgGV)Activator.CreateInstance(hFtBUHwCFYxSLNEjhJfIrXUEuTED.mZmqGAaqwvVMugMhumuHUJtJDvLHA(item2).EeipOhVjORMBBeBVZOLNijWzMalw);
			aQFnijkWHNrZqHVnChgGlanhcgGV2.iTEarVAyvuycXQXMlFYBPhUqlFKl(P_0);
			if (aQFnijkWHNrZqHVnChgGlanhcgGV == null)
			{
				aQFnijkWHNrZqHVnChgGlanhcgGV = aQFnijkWHNrZqHVnChgGlanhcgGV2;
				YAwFwrcTVSGdUDBcyTvVtRvUGjlt.Add(yHCBzHlEqidFlhCjzMFNlQHvOWSY.LpUaCvhhBeccRaqOBULsqWGwWlWnB, aQFnijkWHNrZqHVnChgGlanhcgGV);
			}
			YAwFwrcTVSGdUDBcyTvVtRvUGjlt.Add(luYaFPaftNInTWGPWfCvgYuDUqDyA.ibLCaFPZPldpHvHDpPZoCKbwMDSe(item2), aQFnijkWHNrZqHVnChgGlanhcgGV2);
			Type[] array = item2.GetInterfaces();
			foreach (Type type3 in array)
			{
				if (hFtBUHwCFYxSLNEjhJfIrXUEuTED.mZmqGAaqwvVMugMhumuHUJtJDvLHA(type3) != null)
				{
					YAwFwrcTVSGdUDBcyTvVtRvUGjlt.Add(luYaFPaftNInTWGPWfCvgYuDUqDyA.ibLCaFPZPldpHvHDpPZoCKbwMDSe(type3), aQFnijkWHNrZqHVnChgGlanhcgGV2);
				}
			}
		}
	}

	internal IntPtr pzFILUFGqMLCOLXDwLCrGCetqEdW(Type P_0)
	{
		return vHbErlUVwLltnaXUjqkpbNZJvheU(luYaFPaftNInTWGPWfCvgYuDUqDyA.ibLCaFPZPldpHvHDpPZoCKbwMDSe(P_0));
	}

	internal IntPtr vHbErlUVwLltnaXUjqkpbNZJvheU(Guid P_0)
	{
		return MDoljRdhwoeqfivYcZZjhoMkkNMkA(P_0)?.fREGeAsscSanGSwlvHwWDQIMIYWO ?? IntPtr.Zero;
	}

	internal AQFnijkWHNrZqHVnChgGlanhcgGV MDoljRdhwoeqfivYcZZjhoMkkNMkA(Guid P_0)
	{
		YAwFwrcTVSGdUDBcyTvVtRvUGjlt.TryGetValue(P_0, out var value);
		return value;
	}

	protected virtual void FGPXpxQHyZBtciBuwflSKZJOdEygb(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (AQFnijkWHNrZqHVnChgGlanhcgGV value in YAwFwrcTVSGdUDBcyTvVtRvUGjlt.Values)
		{
			value.Dispose();
		}
		YAwFwrcTVSGdUDBcyTvVtRvUGjlt.Clear();
		if (PouFFvKqOuAsZWuZTZeytcpOeMWIA != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(PouFFvKqOuAsZWuZTZeytcpOeMWIA);
			PouFFvKqOuAsZWuZTZeytcpOeMWIA = IntPtr.Zero;
		}
	}
}
