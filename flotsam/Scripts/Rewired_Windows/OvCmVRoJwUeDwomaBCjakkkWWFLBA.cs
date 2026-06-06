using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class OvCmVRoJwUeDwomaBCjakkkWWFLBA : GsoNMxEFcdzlUTEdwbKScUmOFyGnA
{
	private readonly Dictionary<Guid, ZnbOigmcaWfMUkLqZAdXixNwjqSIA> LCGRuwupgVYLecIdtdrUuKVJhDrH = new Dictionary<Guid, ZnbOigmcaWfMUkLqZAdXixNwjqSIA>();

	private static readonly Dictionary<Type, List<Type>> LyebrxeXoMriSsRftOVgjDUIUhoAA = new Dictionary<Type, List<Type>>();

	private IntPtr OSMPiaYAldSNrtgYEdihkUVVXCKV;

	[CompilerGenerated]
	private IntPtr[] LZoKzPFKxAoYgSqbasjvqkbHUKHu;

	public IntPtr[] ZpmGQpergKPtJLQRBNAIzjIjoGyBb
	{
		[CompilerGenerated]
		get
		{
			return LZoKzPFKxAoYgSqbasjvqkbHUKHu;
		}
		[CompilerGenerated]
		private set
		{
			LZoKzPFKxAoYgSqbasjvqkbHUKHu = lZoKzPFKxAoYgSqbasjvqkbHUKHu;
		}
	}

	public void aYVsAKMegayxdFILbKskPiUwYipv(txfTVBNIrejVWwElagqNkOgVlMqGb P_0)
	{
		P_0.iCpwQTjkXFmpIemrFGVnRxKsNPCR = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (LyebrxeXoMriSsRftOVgjDUIUhoAA)
		{
			if (!LyebrxeXoMriSsRftOVgjDUIUhoAA.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				LyebrxeXoMriSsRftOVgjDUIUhoAA.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					if (kkLevLsxsPSAogCFwRhXkdzHykQI.fcUgfTenXyshMJxqnikERfTYKxBs(type2) == null)
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
		ZnbOigmcaWfMUkLqZAdXixNwjqSIA znbOigmcaWfMUkLqZAdXixNwjqSIA = null;
		foreach (Type item2 in value)
		{
			ZnbOigmcaWfMUkLqZAdXixNwjqSIA znbOigmcaWfMUkLqZAdXixNwjqSIA2 = (ZnbOigmcaWfMUkLqZAdXixNwjqSIA)Activator.CreateInstance(kkLevLsxsPSAogCFwRhXkdzHykQI.fcUgfTenXyshMJxqnikERfTYKxBs(item2).LaKMnwJkpAksfPoEIGVUArewmeteb);
			znbOigmcaWfMUkLqZAdXixNwjqSIA2.hWiRTIOOIdLPdbERuThEEqmfjCWi(P_0);
			if (znbOigmcaWfMUkLqZAdXixNwjqSIA == null)
			{
				znbOigmcaWfMUkLqZAdXixNwjqSIA = znbOigmcaWfMUkLqZAdXixNwjqSIA2;
				LCGRuwupgVYLecIdtdrUuKVJhDrH.Add(dJmAWSpFHvwuXbuUgNDQNkrcSRQh.MlwXdinGqfOPrNFRLrXtPxmHfSML, znbOigmcaWfMUkLqZAdXixNwjqSIA);
			}
			LCGRuwupgVYLecIdtdrUuKVJhDrH.Add(qxcVmGprUKQYlnqWDgYoPbSYiwBQ.lQRpGbZgoYGbVQkAuPkMHjujMrKk(item2), znbOigmcaWfMUkLqZAdXixNwjqSIA2);
			Type[] array = item2.GetInterfaces();
			foreach (Type type3 in array)
			{
				if (kkLevLsxsPSAogCFwRhXkdzHykQI.fcUgfTenXyshMJxqnikERfTYKxBs(type3) != null)
				{
					LCGRuwupgVYLecIdtdrUuKVJhDrH.Add(qxcVmGprUKQYlnqWDgYoPbSYiwBQ.lQRpGbZgoYGbVQkAuPkMHjujMrKk(type3), znbOigmcaWfMUkLqZAdXixNwjqSIA2);
				}
			}
		}
	}

	internal IntPtr cCbNiZBNNXIxqwVUngQuBLUyTOjt(Type P_0)
	{
		return gFRQOiGzHGJAJBKDsBqsgYzMftyX(qxcVmGprUKQYlnqWDgYoPbSYiwBQ.lQRpGbZgoYGbVQkAuPkMHjujMrKk(P_0));
	}

	internal IntPtr gFRQOiGzHGJAJBKDsBqsgYzMftyX(Guid P_0)
	{
		return BhMNCIpkDhRBLApZtFXqfCgzRDCU(P_0)?.cOaLXRsqVRuSojLsgpkROlcJOCEr ?? IntPtr.Zero;
	}

	internal ZnbOigmcaWfMUkLqZAdXixNwjqSIA BhMNCIpkDhRBLApZtFXqfCgzRDCU(Guid P_0)
	{
		LCGRuwupgVYLecIdtdrUuKVJhDrH.TryGetValue(P_0, out var value);
		return value;
	}

	protected virtual void KJnaIyGQXGNWSkLptspLNKlXyEoIA(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (ZnbOigmcaWfMUkLqZAdXixNwjqSIA value in LCGRuwupgVYLecIdtdrUuKVJhDrH.Values)
		{
			value.Dispose();
		}
		LCGRuwupgVYLecIdtdrUuKVJhDrH.Clear();
		if (OSMPiaYAldSNrtgYEdihkUVVXCKV != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(OSMPiaYAldSNrtgYEdihkUVVXCKV);
			OSMPiaYAldSNrtgYEdihkUVVXCKV = IntPtr.Zero;
		}
	}
}
