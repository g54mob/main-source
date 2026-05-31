using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Static Behaviours/Open Report")]
	public class StaticOpenReport : ScriptableObject
	{
		public void OpenReportUI()
		{
			if (CTSSingleton<ReportInterface>.TryGetInstance(out var outInstance))
			{
				outInstance.Open();
			}
		}

		public void CloseReportUI()
		{
			if (CTSSingleton<ReportInterface>.TryGetInstance(out var outInstance))
			{
				outInstance.Close();
			}
		}
	}
}
