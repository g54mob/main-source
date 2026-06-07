using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class AtcaRydQnJORPYrBJlLMQMLZgqUbA : MrEUOKZGxwGprvYYmmmawcJDWRFN
{
	private readonly Dictionary<Guid, DyPpCHzzjNgMpKeBBzFjSPgpNvDK> DTZkMhWnTifyAMEWJyHyysnyjcgi = new Dictionary<Guid, DyPpCHzzjNgMpKeBBzFjSPgpNvDK>();

	private static readonly Dictionary<Type, List<Type>> jobvNgNYQvMpldbURTkrlbnBPirx = new Dictionary<Type, List<Type>>();

	private IntPtr WQHfahkmMDiWdANBOrzzhqfzAuiFb;

	[CompilerGenerated]
	private IntPtr[] pOIXNBCYudiftYbbONNgwqbIuDwC;

	public IntPtr[] BOfrsLFxjgRLzToZMyfzgwAySNHc
	{
		[CompilerGenerated]
		get
		{
			return pOIXNBCYudiftYbbONNgwqbIuDwC;
		}
		[CompilerGenerated]
		private set
		{
			pOIXNBCYudiftYbbONNgwqbIuDwC = array;
		}
	}

	public void qPhGjuHRNEfrkMynCGIBKdbFaOxF(xQLmLqOkyxmFpIYGyTSzgNJWCdnJA P_0)
	{
		P_0.PBFcBpaZlYplICQGyUiUcXZXlrKD = this;
		Type type = P_0.GetType();
		List<Type> value;
		lock (jobvNgNYQvMpldbURTkrlbnBPirx)
		{
			if (!jobvNgNYQvMpldbURTkrlbnBPirx.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				jobvNgNYQvMpldbURTkrlbnBPirx.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					if (gPvceyazwGaQXlOwoYjjMXWIbJRKA.jBeadTndiITwAWHVgGNrnfDNGje(type2) == null)
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
		DyPpCHzzjNgMpKeBBzFjSPgpNvDK dyPpCHzzjNgMpKeBBzFjSPgpNvDK = null;
		foreach (Type item2 in value)
		{
			DyPpCHzzjNgMpKeBBzFjSPgpNvDK dyPpCHzzjNgMpKeBBzFjSPgpNvDK2 = (DyPpCHzzjNgMpKeBBzFjSPgpNvDK)Activator.CreateInstance(gPvceyazwGaQXlOwoYjjMXWIbJRKA.jBeadTndiITwAWHVgGNrnfDNGje(item2).fIOegccOCicVLevenXOIwaeUcNZY);
			dyPpCHzzjNgMpKeBBzFjSPgpNvDK2.qPhGjuHRNEfrkMynCGIBKdbFaOxF(P_0);
			if (dyPpCHzzjNgMpKeBBzFjSPgpNvDK == null)
			{
				dyPpCHzzjNgMpKeBBzFjSPgpNvDK = dyPpCHzzjNgMpKeBBzFjSPgpNvDK2;
				DTZkMhWnTifyAMEWJyHyysnyjcgi.Add(vCYkItmiEieyyLvPugbwilIfPdRrA.eBTcDDpHuwUtilYaFZlXxASCnQGe, dyPpCHzzjNgMpKeBBzFjSPgpNvDK);
			}
			DTZkMhWnTifyAMEWJyHyysnyjcgi.Add(qUbotaSLZASADLtRbuWjzvVhFURA.KDoWHLWCCjugqVGQZGzwmhkpsfVv(item2), dyPpCHzzjNgMpKeBBzFjSPgpNvDK2);
			Type[] array = item2.GetInterfaces();
			foreach (Type type3 in array)
			{
				if (gPvceyazwGaQXlOwoYjjMXWIbJRKA.jBeadTndiITwAWHVgGNrnfDNGje(type3) != null)
				{
					DTZkMhWnTifyAMEWJyHyysnyjcgi.Add(qUbotaSLZASADLtRbuWjzvVhFURA.KDoWHLWCCjugqVGQZGzwmhkpsfVv(type3), dyPpCHzzjNgMpKeBBzFjSPgpNvDK2);
				}
			}
		}
	}

	internal IntPtr gEzagBPCcPcKrMibSzWifLQHhrwV(Type P_0)
	{
		return gEzagBPCcPcKrMibSzWifLQHhrwV(qUbotaSLZASADLtRbuWjzvVhFURA.KDoWHLWCCjugqVGQZGzwmhkpsfVv(P_0));
	}

	internal IntPtr gEzagBPCcPcKrMibSzWifLQHhrwV(Guid P_0)
	{
		return tpaRqlUBxuAuOCAIairsghBhFuGwA(P_0)?.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA ?? IntPtr.Zero;
	}

	internal DyPpCHzzjNgMpKeBBzFjSPgpNvDK tpaRqlUBxuAuOCAIairsghBhFuGwA(Guid P_0)
	{
		DTZkMhWnTifyAMEWJyHyysnyjcgi.TryGetValue(P_0, out var value);
		return value;
	}

	protected override void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (DyPpCHzzjNgMpKeBBzFjSPgpNvDK value in DTZkMhWnTifyAMEWJyHyysnyjcgi.Values)
		{
			value.Dispose();
		}
		DTZkMhWnTifyAMEWJyHyysnyjcgi.Clear();
		if (WQHfahkmMDiWdANBOrzzhqfzAuiFb != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(WQHfahkmMDiWdANBOrzzhqfzAuiFb);
			WQHfahkmMDiWdANBOrzzhqfzAuiFb = IntPtr.Zero;
		}
	}
}
