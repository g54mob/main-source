using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator
{
	[Settings("UI/Tooltips", Scope.Project)]
	public class TooltipSettings : CustomSettings<TooltipSettings>
	{
		[Header("Prefabs")]
		[SerializeField]
		private GameObject m_tooltipCanvas;

		[SerializeField]
		private GameObject m_tooltipLayout;

		[SerializeField]
		private GameObject m_tooltipPrefab;

		[Header("Parameters")]
		[SerializeField]
		[Range(0f, 2f)]
		private float m_triggerDuration = 0.5f;

		public static GameObject TooltipCanvas => CustomSettings<TooltipSettings>.I.m_tooltipCanvas;

		public static GameObject TooltipLayout => CustomSettings<TooltipSettings>.I.m_tooltipLayout;

		public static GameObject TooltipPrefab => CustomSettings<TooltipSettings>.I.m_tooltipPrefab;

		public static float TriggerDuration => CustomSettings<TooltipSettings>.I.m_triggerDuration;
	}
}
