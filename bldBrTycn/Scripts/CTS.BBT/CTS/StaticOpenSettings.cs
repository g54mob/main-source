using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Static Behaviours/Open Settings")]
	public class StaticOpenSettings : ScriptableObject
	{
		public void OpenSettings()
		{
			if (CTSSingleton<SettingsInterface>.TryGetInstance(out var outInstance))
			{
				outInstance.Open();
			}
		}

		public void CloseSettings()
		{
			if (CTSSingleton<SettingsInterface>.TryGetInstance(out var outInstance))
			{
				outInstance.Close();
			}
		}
	}
}
