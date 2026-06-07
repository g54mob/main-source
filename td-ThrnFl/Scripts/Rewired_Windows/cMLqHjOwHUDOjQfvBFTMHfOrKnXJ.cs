using System;
using Rewired.Utils.Classes.Data;

internal class cMLqHjOwHUDOjQfvBFTMHfOrKnXJ : QTwvMqRjxXBwLOoUpuezGnwheUbM
{
	public readonly float[] VNYkooeoXLtNVzxyiQWNaRkcrEnm;

	public double HOIJXMKMCQxvlOgYSQfWflNBTDbf;

	public readonly int WOztpLQlIpHKxzhjAokRaILGmKWK;

	private readonly byte[] iwVLFefOUdhnTAgVfksrjkDBJMGAb;

	private readonly int wpeWPPiEmbqpEosRafpLjQmvRdqh;

	private readonly int uBvrUDLgilvWZENrkPXfZbbmqdXX;

	private readonly Action<byte[], float[]> GfXfAhwBtuGlZmtlVUbEeohSxckI;

	public cMLqHjOwHUDOjQfvBFTMHfOrKnXJ(byte P_0, HIDInfo P_1, int P_2, Action<byte[], float[]> P_3)
		: base(P_0, P_1)
	{
		WOztpLQlIpHKxzhjAokRaILGmKWK = P_2;
		GfXfAhwBtuGlZmtlVUbEeohSxckI = P_3;
		wpeWPPiEmbqpEosRafpLjQmvRdqh = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		uBvrUDLgilvWZENrkPXfZbbmqdXX = P_1.dataIndex;
		iwVLFefOUdhnTAgVfksrjkDBJMGAb = new byte[wpeWPPiEmbqpEosRafpLjQmvRdqh];
		VNYkooeoXLtNVzxyiQWNaRkcrEnm = new float[P_2];
	}

	public virtual void YGoXRAASaFeOHAtwJaRvJmHBqadeb(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == ojLWWKRknmirMQCCbmKCWZUFqDzy)
		{
			HOIJXMKMCQxvlOgYSQfWflNBTDbf = P_1;
			for (int i = 0; i < wpeWPPiEmbqpEosRafpLjQmvRdqh; i++)
			{
				iwVLFefOUdhnTAgVfksrjkDBJMGAb[i] = P_0[uBvrUDLgilvWZENrkPXfZbbmqdXX + i];
			}
			if (GfXfAhwBtuGlZmtlVUbEeohSxckI != null)
			{
				GfXfAhwBtuGlZmtlVUbEeohSxckI(iwVLFefOUdhnTAgVfksrjkDBJMGAb, VNYkooeoXLtNVzxyiQWNaRkcrEnm);
			}
		}
	}

	public void oWvJZedbLbblABUwpnzICoTgyCDrB(float[] P_0, double P_1)
	{
		HOIJXMKMCQxvlOgYSQfWflNBTDbf = P_1;
		for (int i = 0; i < WOztpLQlIpHKxzhjAokRaILGmKWK; i++)
		{
			VNYkooeoXLtNVzxyiQWNaRkcrEnm[i] = P_0[i];
		}
	}
}
