using UnityEngine;

public class AndroidManager : MonoBehaviour
{
	private class HapticFeedbackManager
	{
		public bool Execute()
		{
			return false;
		}
	}

	private static HapticFeedbackManager mHapticFeedbackManager;

	public static bool HapticFeedback()
	{
		return false;
	}
}
