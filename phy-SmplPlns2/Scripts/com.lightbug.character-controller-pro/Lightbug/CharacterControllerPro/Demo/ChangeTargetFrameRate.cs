using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class ChangeTargetFrameRate : MonoBehaviour
	{
		public void SetTargetFrameRate(int targetFrameRate)
		{
			if (targetFrameRate >= 0 || targetFrameRate == -1)
			{
				QualitySettings.vSyncCount = 0;
				Application.targetFrameRate = targetFrameRate;
			}
		}

		public void UseFullVSync()
		{
			QualitySettings.vSyncCount = 1;
		}

		public void UseHalfVSync()
		{
			QualitySettings.vSyncCount = 2;
		}
	}
}
