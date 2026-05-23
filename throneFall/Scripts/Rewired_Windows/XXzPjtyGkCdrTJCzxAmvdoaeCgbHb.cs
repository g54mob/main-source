using System;
using Rewired.Utils.Classes.Data;

internal class XXzPjtyGkCdrTJCzxAmvdoaeCgbHb : QTwvMqRjxXBwLOoUpuezGnwheUbM
{
	public enum ZkCpJQOmLqtNuDYOxVOwbJigFkaN
	{
		Default = 0,
		Custom = 1
	}

	public int xuQSQygsnwTbqkppyCFMCtpRUdlJA;

	public double CZdUcasfzPhTPGsFoDmvGARWkonK;

	public readonly int XZAwVYNOViCbGDLjMDydFaJCsYOJc;

	public readonly int wBaGczqpAxHLeUTaHPISBuwfuyjA;

	public readonly ZkCpJQOmLqtNuDYOxVOwbJigFkaN CBKjvLFkdGYEXLmRpEWSeAbeeqVmA;

	private Func<int, int> QvwFulAyLRcyCoDRSgDgrzMuMCkuA;

	public XXzPjtyGkCdrTJCzxAmvdoaeCgbHb(byte P_0, HIDInfo P_1, ZkCpJQOmLqtNuDYOxVOwbJigFkaN P_2)
		: base(P_0, P_1)
	{
		CBKjvLFkdGYEXLmRpEWSeAbeeqVmA = P_2;
		XZAwVYNOViCbGDLjMDydFaJCsYOJc = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		wBaGczqpAxHLeUTaHPISBuwfuyjA = P_1.dataIndex;
	}

	public XXzPjtyGkCdrTJCzxAmvdoaeCgbHb(byte P_0, HIDInfo P_1, Func<int, int> P_2)
		: this(P_0, P_1, ZkCpJQOmLqtNuDYOxVOwbJigFkaN.Custom)
	{
		QvwFulAyLRcyCoDRSgDgrzMuMCkuA = P_2;
	}

	public virtual void cQtMqpFsxaEiQJQMCBelVDMELSnf(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != ojLWWKRknmirMQCCbmKCWZUFqDzy)
		{
			return;
		}
		CZdUcasfzPhTPGsFoDmvGARWkonK = P_1;
		if (XZAwVYNOViCbGDLjMDydFaJCsYOJc == 1)
		{
			xuQSQygsnwTbqkppyCFMCtpRUdlJA = P_0[wBaGczqpAxHLeUTaHPISBuwfuyjA];
		}
		else
		{
			xuQSQygsnwTbqkppyCFMCtpRUdlJA = 0;
			for (int i = 0; i < XZAwVYNOViCbGDLjMDydFaJCsYOJc; i++)
			{
				xuQSQygsnwTbqkppyCFMCtpRUdlJA |= P_0[wBaGczqpAxHLeUTaHPISBuwfuyjA + i] << 8 * i;
			}
		}
		if (CBKjvLFkdGYEXLmRpEWSeAbeeqVmA == ZkCpJQOmLqtNuDYOxVOwbJigFkaN.Custom && QvwFulAyLRcyCoDRSgDgrzMuMCkuA != null)
		{
			xuQSQygsnwTbqkppyCFMCtpRUdlJA = QvwFulAyLRcyCoDRSgDgrzMuMCkuA(xuQSQygsnwTbqkppyCFMCtpRUdlJA);
		}
	}
}
