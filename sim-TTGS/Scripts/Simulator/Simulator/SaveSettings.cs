using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator
{
	[Settings("General/Save", Scope.Project)]
	public class SaveSettings : CustomSettings<SaveSettings>
	{
		[Header("New Saves")]
		[SerializeField]
		private int m_maxAutoSaveCount = 10;

		[Header("Auto saves")]
		[SerializeField]
		private bool m_autoSaveOnCheckout = true;

		[SerializeField]
		private bool m_autoSavePeriodically = true;

		public static int MaxAutoSaveCount => CustomSettings<SaveSettings>.I.m_maxAutoSaveCount;

		public static bool AutoSaveOnCheckout => CustomSettings<SaveSettings>.I.m_autoSaveOnCheckout;

		public static bool AutoSavePeriodically => CustomSettings<SaveSettings>.I.m_autoSavePeriodically;
	}
}
