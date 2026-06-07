using UnityEngine;

public class Impatient
{
	private const int BU = 1;

	private const int BD = 2;

	private const int BL = 4;

	private const int BR = 8;

	private static int tapIndex;

	private static int[] tapButtons = new int[7] { 8, 8, 4, 4, 1, 4, 8 };

	private static float tapStartTime;

	private static int lastCheckFrame;

	private static string lastCheckContext;

	public static bool WantSkip(string context)
	{
		bool result = false;
		if (context == lastCheckContext && Time.frameCount <= lastCheckFrame + 3 && RInput.GetButtonWhileMuted(11) && RInput.GetButtonWhileMuted(39) && (tapIndex == 0 || Time.realtimeSinceStartup < tapStartTime + 2.5f))
		{
			if (tapIndex >= tapButtons.Length)
			{
				result = true;
			}
			else
			{
				int num = (RInput.GetButtonDownWhileMuted(31) ? 1 : 0) | (RInput.GetButtonDownWhileMuted(32) ? 2 : 0) | (RInput.GetButtonDownWhileMuted(33) ? 4 : 0) | (RInput.GetButtonDownWhileMuted(40) ? 8 : 0);
				if (num != 0)
				{
					if (tapButtons[tapIndex] == num)
					{
						if (tapIndex == 0)
						{
							tapStartTime = Time.realtimeSinceStartup;
						}
						tapIndex++;
						result = tapIndex >= tapButtons.Length;
					}
					else
					{
						tapIndex = 0;
					}
				}
			}
		}
		else
		{
			tapIndex = 0;
		}
		lastCheckContext = context;
		lastCheckFrame = Time.frameCount;
		return result;
	}
}
