using UnityEngine;

public static class NoseModInfo
{
	private static float AA_Min = 0.7f;

	private static float AA_Max = 0.6f;

	public static float GetModAMin()
	{
		return AA_Min;
	}

	public static float GetModAMax()
	{
		return AA_Max;
	}

	public static void ApplyModA(GameObject noseHolder, float modValue)
	{
		ApplyModAA(noseHolder, modValue);
	}

	private static void ApplyModAA(GameObject noseHolder, float modValue)
	{
		float x = noseHolder.transform.lossyScale.x;
		noseHolder.transform.localScale += modValue * noseHolder.transform.localScale;
		float x2 = noseHolder.transform.lossyScale.x;
		noseHolder.transform.localPosition += noseHolder.transform.right * (x - x2) / 4f;
		noseHolder.transform.localPosition += noseHolder.transform.up * (x - x2) / 4f;
	}
}
