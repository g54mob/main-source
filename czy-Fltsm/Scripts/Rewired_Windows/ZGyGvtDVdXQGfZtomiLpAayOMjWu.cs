using System;
using Rewired.Utils.Classes.Data;

internal class ZGyGvtDVdXQGfZtomiLpAayOMjWu : OYzieseEeYXDrIqXsZAdwVmBBsCg
{
	public enum TzVdXGtIUpcQYNPLwxTsTFyItaLf
	{
		Default = 0,
		Custom = 1
	}

	public int xGZwsoDqpfYKMgehxgyYFnnjsKXc;

	public double MSiwasLOmQIEdfIYbZidMePiklOab;

	public readonly int XhTzmUsCOdGOwLKgVZOpMvRWDopF;

	public readonly int oJQDwugFwLgarfSOHboYPtgyYjVyb;

	public readonly TzVdXGtIUpcQYNPLwxTsTFyItaLf MQJaXLaVaBBfdXREkEnKcqvYMdgT;

	private Func<int, int> WzvADlDAHIZmiLIXTcqVNUeSVdDe;

	public ZGyGvtDVdXQGfZtomiLpAayOMjWu(byte P_0, HIDInfo P_1, TzVdXGtIUpcQYNPLwxTsTFyItaLf P_2)
		: base(P_0, P_1)
	{
		MQJaXLaVaBBfdXREkEnKcqvYMdgT = P_2;
		XhTzmUsCOdGOwLKgVZOpMvRWDopF = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		oJQDwugFwLgarfSOHboYPtgyYjVyb = P_1.dataIndex;
	}

	public ZGyGvtDVdXQGfZtomiLpAayOMjWu(byte P_0, HIDInfo P_1, Func<int, int> P_2)
		: this(P_0, P_1, TzVdXGtIUpcQYNPLwxTsTFyItaLf.Custom)
	{
		WzvADlDAHIZmiLIXTcqVNUeSVdDe = P_2;
	}

	public virtual void qKwtibmPftEbabRDDcwvErGayAAub(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != wVMsnOmodjAbsSEDwjTEwlMnMPQg)
		{
			return;
		}
		MSiwasLOmQIEdfIYbZidMePiklOab = P_1;
		if (XhTzmUsCOdGOwLKgVZOpMvRWDopF == 1)
		{
			xGZwsoDqpfYKMgehxgyYFnnjsKXc = P_0[oJQDwugFwLgarfSOHboYPtgyYjVyb];
		}
		else
		{
			xGZwsoDqpfYKMgehxgyYFnnjsKXc = 0;
			for (int i = 0; i < XhTzmUsCOdGOwLKgVZOpMvRWDopF; i++)
			{
				xGZwsoDqpfYKMgehxgyYFnnjsKXc |= P_0[oJQDwugFwLgarfSOHboYPtgyYjVyb + i] << 8 * i;
			}
		}
		if (MQJaXLaVaBBfdXREkEnKcqvYMdgT == TzVdXGtIUpcQYNPLwxTsTFyItaLf.Custom && WzvADlDAHIZmiLIXTcqVNUeSVdDe != null)
		{
			xGZwsoDqpfYKMgehxgyYFnnjsKXc = WzvADlDAHIZmiLIXTcqVNUeSVdDe(xGZwsoDqpfYKMgehxgyYFnnjsKXc);
		}
	}
}
