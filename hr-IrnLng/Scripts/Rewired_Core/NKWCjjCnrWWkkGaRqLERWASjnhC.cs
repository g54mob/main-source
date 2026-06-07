using UnityEngine;

internal static class NKWCjjCnrWWkkGaRqLERWASjnhC
{
	private static int rGbfWlgwbFhdKMrGmzhpeEGTJatr;

	private static int jZIrWyBTDMYPCOWflxuDUQgsNSP;

	private static double[] qJUBZCipzVrMaIiHkGRYyTcQIYWK;

	private static int FHVbxUhruDYJFGswvnHldoOhjZvZ;

	private static double keFELsVMecEoMVNboZMOBfCoSle;

	private static int CpqCcyVvXVLoeLadhJdtGWIBGsE;

	public static double smoothDeltaTime => keFELsVMecEoMVNboZMOBfCoSle;

	public static int framesToSmooth
	{
		get
		{
			return rGbfWlgwbFhdKMrGmzhpeEGTJatr;
		}
		set
		{
			if (value <= 0)
			{
				value = 1;
			}
			if (value != rGbfWlgwbFhdKMrGmzhpeEGTJatr)
			{
				rGbfWlgwbFhdKMrGmzhpeEGTJatr = value;
				agvWMBoHtblzmgSmVloJbsDkfGk();
			}
		}
	}

	static NKWCjjCnrWWkkGaRqLERWASjnhC()
	{
		rGbfWlgwbFhdKMrGmzhpeEGTJatr = 30;
		agvWMBoHtblzmgSmVloJbsDkfGk();
	}

	public static void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
	{
		int frameCount = Time.frameCount;
		if (CpqCcyVvXVLoeLadhJdtGWIBGsE < frameCount)
		{
			qJUBZCipzVrMaIiHkGRYyTcQIYWK[jZIrWyBTDMYPCOWflxuDUQgsNSP] = Time.deltaTime;
			if (FHVbxUhruDYJFGswvnHldoOhjZvZ < rGbfWlgwbFhdKMrGmzhpeEGTJatr)
			{
				FHVbxUhruDYJFGswvnHldoOhjZvZ++;
			}
			double num = 0.0;
			for (int i = 0; i < FHVbxUhruDYJFGswvnHldoOhjZvZ; i++)
			{
				num += qJUBZCipzVrMaIiHkGRYyTcQIYWK[i];
			}
			keFELsVMecEoMVNboZMOBfCoSle = num / (double)FHVbxUhruDYJFGswvnHldoOhjZvZ;
			jZIrWyBTDMYPCOWflxuDUQgsNSP++;
			if (jZIrWyBTDMYPCOWflxuDUQgsNSP >= rGbfWlgwbFhdKMrGmzhpeEGTJatr)
			{
				jZIrWyBTDMYPCOWflxuDUQgsNSP = 0;
			}
			CpqCcyVvXVLoeLadhJdtGWIBGsE = frameCount;
		}
	}

	public static void agvWMBoHtblzmgSmVloJbsDkfGk()
	{
		if (qJUBZCipzVrMaIiHkGRYyTcQIYWK == null || qJUBZCipzVrMaIiHkGRYyTcQIYWK.Length != rGbfWlgwbFhdKMrGmzhpeEGTJatr)
		{
			qJUBZCipzVrMaIiHkGRYyTcQIYWK = new double[rGbfWlgwbFhdKMrGmzhpeEGTJatr];
		}
		FHVbxUhruDYJFGswvnHldoOhjZvZ = 0;
		jZIrWyBTDMYPCOWflxuDUQgsNSP = 0;
		CpqCcyVvXVLoeLadhJdtGWIBGsE = 0;
	}
}
