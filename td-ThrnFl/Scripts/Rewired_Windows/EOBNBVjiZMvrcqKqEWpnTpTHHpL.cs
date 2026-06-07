using Rewired.Utils;

internal class EOBNBVjiZMvrcqKqEWpnTpTHHpL : gxqibZyiwnudhYDptqPAsALaIiWFA
{
	public readonly int UauPhDuIfNvMgFievgBSGxZwujXj;

	public readonly int vZzKGHzNDsezEKiIroWzUJOTciPj;

	public readonly int DDImlWsfenbNbXYSELOzfUgmQIrh;

	public readonly int aUvzfvhRVgKVGfRyktfQRFwqQyyK;

	public readonly int MEhWSTzErmbRLmBPJZNGSHeQATUj;

	public readonly int gcceaVedianiOlCGfgIeseRyofXw;

	public readonly uint oXBuGeFpwFOnbAxRfuDCrwmTsSNK;

	public readonly uint JkPCnWFsWhNbuEyKaEDsXQvWgkDrA;

	public readonly int jgDvlYNxaVurYiaNKbwvZLLjtmTA;

	private readonly int vPxMWClnIuSKeafNCwAztnLqYKHF;

	public uint wmMWAGixZqokwDalFhlbufZQgLdfA;

	public int aMHlueZuoZfcddqKwRQpWBksFIID
	{
		get
		{
			if (wmMWAGixZqokwDalFhlbufZQgLdfA < UauPhDuIfNvMgFievgBSGxZwujXj || wmMWAGixZqokwDalFhlbufZQgLdfA > vZzKGHzNDsezEKiIroWzUJOTciPj)
			{
				return -1;
			}
			int num = (int)((wmMWAGixZqokwDalFhlbufZQgLdfA - UauPhDuIfNvMgFievgBSGxZwujXj) / vPxMWClnIuSKeafNCwAztnLqYKHF * 4500);
			if (num >= 36000)
			{
				num = 0;
			}
			return num;
		}
	}

	public EOBNBVjiZMvrcqKqEWpnTpTHHpL(byte P_0, ushort P_1, ushort P_2, int P_3, int P_4, int P_5, int P_6, int P_7, int P_8, uint P_9, uint P_10, int P_11)
		: base(P_0, P_1, P_2, P_3, P_4)
	{
		UauPhDuIfNvMgFievgBSGxZwujXj = P_5;
		vZzKGHzNDsezEKiIroWzUJOTciPj = P_6;
		oXBuGeFpwFOnbAxRfuDCrwmTsSNK = P_9;
		JkPCnWFsWhNbuEyKaEDsXQvWgkDrA = P_10;
		jgDvlYNxaVurYiaNKbwvZLLjtmTA = P_11;
		DDImlWsfenbNbXYSELOzfUgmQIrh = P_5 - 1;
		if (DDImlWsfenbNbXYSELOzfUgmQIrh < 0)
		{
			DDImlWsfenbNbXYSELOzfUgmQIrh = P_6 + 1;
		}
		gcceaVedianiOlCGfgIeseRyofXw = -1;
		int num = P_6 - P_5 + 1;
		vPxMWClnIuSKeafNCwAztnLqYKHF = MathTools.Clamp(num / 8, 1, int.MaxValue);
		dcXLHSiMrHUPYVAwOYZxDbLXXAAk();
	}

	public virtual void xHPCKvTvqzjhiEZzRMtwtOOUbPpz()
	{
		wmMWAGixZqokwDalFhlbufZQgLdfA = (uint)DDImlWsfenbNbXYSELOzfUgmQIrh;
	}
}
