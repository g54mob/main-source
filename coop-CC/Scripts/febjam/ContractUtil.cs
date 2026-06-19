public static class ContractUtil
{
	public static int GetOutboundMaxNumberOfFrames(ContractShift.Outbound[] outbound)
	{
		Timer timer = default(Timer);
		for (int i = 0; i < outbound.Length; i++)
		{
			timer.AddToTimer(outbound[i].secondsFromPrevious);
		}
		return timer.GetFramesRemaining();
	}

	public static int GetTruckCount(ContractShift.Outbound[] outbound)
	{
		int num = 0;
		for (int i = 0; i < outbound.Length; i++)
		{
			num += outbound[i].bayCount;
		}
		return num;
	}
}
