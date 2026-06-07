using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class QmdCQZTheSNlgMohMwANBOMBTfg : global::ohjCRaNdZyNtQMEVoWzrnLnKGkg<xGybIxclQvTiMZjopXCqpWihnuJ, RryiXLNEqnrrVJXCpnreQZryxLA>
{
	private static readonly List<Key> OhXpukkPtYCioeTNntDodiurScL;

	[CompilerGenerated]
	private List<Key> iVcaXxUzAZtpbuGLHXQYyBLoQPW;

	public List<Key> AllKeys
	{
		get
		{
			return OhXpukkPtYCioeTNntDodiurScL;
		}
	}

	public List<Key> PressedKeys
	{
		[CompilerGenerated]
		get
		{
			return iVcaXxUzAZtpbuGLHXQYyBLoQPW;
		}
		[CompilerGenerated]
		private set
		{
			iVcaXxUzAZtpbuGLHXQYyBLoQPW = value;
		}
	}

	static QmdCQZTheSNlgMohMwANBOMBTfg()
	{
		OhXpukkPtYCioeTNntDodiurScL = new List<Key>(256);
		foreach (object value in Enum.GetValues(typeof(Key)))
		{
			OhXpukkPtYCioeTNntDodiurScL.Add((Key)value);
		}
	}

	public QmdCQZTheSNlgMohMwANBOMBTfg()
	{
		PressedKeys = new List<Key>(16);
	}

	public bool YQPfhXiFSqFEuUcRSsEdvVCCCEp(Key P_0)
	{
		return PressedKeys.Contains(P_0);
	}

	public void Update(RryiXLNEqnrrVJXCpnreQZryxLA P_0)
	{
		if (P_0.Key != Key.Unknown)
		{
			bool flag = YQPfhXiFSqFEuUcRSsEdvVCCCEp(P_0.Key);
			if (P_0.IsPressed && !flag)
			{
				PressedKeys.Add(P_0.Key);
			}
			else if (P_0.IsReleased && flag)
			{
				PressedKeys.Remove(P_0.Key);
			}
		}
	}

	public unsafe void MarshalFrom(IntPtr P_0)
	{
		PressedKeys.Clear();
		xGybIxclQvTiMZjopXCqpWihnuJ* ptr = (xGybIxclQvTiMZjopXCqpWihnuJ*)(void*)P_0;
		RryiXLNEqnrrVJXCpnreQZryxLA rryiXLNEqnrrVJXCpnreQZryxLA = default(RryiXLNEqnrrVJXCpnreQZryxLA);
		byte* ptr2 = &ptr->CwikwLRjHDXJRAUCVnpXgPBjpNU.GLOsQhCDAdwoDeIibWqPAViRmlu;
		for (int i = 0; i < 256; i++)
		{
			rryiXLNEqnrrVJXCpnreQZryxLA.xoDhYRyoootuTZfiMKWIQWSrgWJ = i;
			rryiXLNEqnrrVJXCpnreQZryxLA.NZRLUDiCvWuxMAkrOrrwreCYVVb = ptr2[i];
			if (rryiXLNEqnrrVJXCpnreQZryxLA.IsPressed)
			{
				PressedKeys.Add(rryiXLNEqnrrVJXCpnreQZryxLA.Key);
			}
		}
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "PressedKeys: {0}", new object[1] { QiyhMeApbloIAQYCjGAvUEQIhAz.JCYHSQHxbTyAHuDpgTGImGXDewF(",", PressedKeys) });
	}
}
