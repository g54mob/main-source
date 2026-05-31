using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Static Behaviours/Open Help")]
	public class StaticOpenHelp : ScriptableObject
	{
		public void OpenHelp()
		{
			if (CTSSingleton<UIHelpingGifs>.TryGetInstance(out var outInstance))
			{
				outInstance.Open();
			}
		}

		public void CloseHelp()
		{
			if (CTSSingleton<UIHelpingGifs>.TryGetInstance(out var outInstance))
			{
				outInstance.Close();
			}
		}
	}
}
