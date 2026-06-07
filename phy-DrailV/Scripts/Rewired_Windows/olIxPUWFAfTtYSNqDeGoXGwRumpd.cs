using System;
using Rewired.Utils.Classes.Data;

internal class olIxPUWFAfTtYSNqDeGoXGwRumpd : YszNVDBZreQueMHaxAPTEUkXgqRz
{
	public readonly float[] QGEPzKgIedvthGPliWOduwXNjWui;

	public double YxFdZozJytryXOxcRaQAmySLFHVc;

	public readonly int QCOFsGxIkxDEmAbTaixfrCMMvZhd;

	private readonly byte[] QtXcZTickhBwGLYIAJbqpdfWpmzB;

	private readonly int NFBfIavLmQumHiFjQGXsgfhnLmUeA;

	private readonly int LMvFEAtZBwQRlFfEWyZfAAUImHJg;

	private readonly Action<byte[], float[]> zovEYMDwzpRetqGCitWoSXfGWxUAA;

	public olIxPUWFAfTtYSNqDeGoXGwRumpd(byte P_0, HIDInfo P_1, int P_2, Action<byte[], float[]> P_3)
		: base(P_0, P_1)
	{
		QCOFsGxIkxDEmAbTaixfrCMMvZhd = P_2;
		zovEYMDwzpRetqGCitWoSXfGWxUAA = P_3;
		NFBfIavLmQumHiFjQGXsgfhnLmUeA = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		LMvFEAtZBwQRlFfEWyZfAAUImHJg = P_1.dataIndex;
		QtXcZTickhBwGLYIAJbqpdfWpmzB = new byte[NFBfIavLmQumHiFjQGXsgfhnLmUeA];
		QGEPzKgIedvthGPliWOduwXNjWui = new float[P_2];
	}

	public override void trsfRiBFSIjLrLMemKcGjgULCoSi(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == UQBUMeskXtetUCCacGGybviytBzpA)
		{
			YxFdZozJytryXOxcRaQAmySLFHVc = P_1;
			for (int i = 0; i < NFBfIavLmQumHiFjQGXsgfhnLmUeA; i++)
			{
				QtXcZTickhBwGLYIAJbqpdfWpmzB[i] = P_0[LMvFEAtZBwQRlFfEWyZfAAUImHJg + i];
			}
			if (zovEYMDwzpRetqGCitWoSXfGWxUAA != null)
			{
				zovEYMDwzpRetqGCitWoSXfGWxUAA(QtXcZTickhBwGLYIAJbqpdfWpmzB, QGEPzKgIedvthGPliWOduwXNjWui);
			}
		}
	}

	public void YIgPiAURoRMNKnmhgmMVyzRrGlUJ(float[] P_0, double P_1)
	{
		YxFdZozJytryXOxcRaQAmySLFHVc = P_1;
		for (int i = 0; i < QCOFsGxIkxDEmAbTaixfrCMMvZhd; i++)
		{
			QGEPzKgIedvthGPliWOduwXNjWui[i] = P_0[i];
		}
	}
}
