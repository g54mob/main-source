using TMPro;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	public class TMPPlayModeChecker : MonoBehaviour
	{
		private void OnEnable()
		{
			if (Application.isPlaying && !TMPInstalled())
			{
				Debug.LogError("TextMeshPro Essentials is required. Stopping Play Mode.");
			}
		}

		private static bool TMPInstalled()
		{
			return TMP_Settings.instance != null;
		}
	}
}
