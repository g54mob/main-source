using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("UI/HUD", Scope.Project)]
	public class HUDSettings : CustomSettings<HUDSettings>
	{
		[Header("Hold Interaction")]
		[SerializeField]
		private float m_holdInteractionFadeInDuration = 0.25f;

		[SerializeField]
		private float m_holdInteractionFadeOutDuration = 0.25f;

		public static float HoldInteractionFadeInDuration => CustomSettings<HUDSettings>.I.m_holdInteractionFadeInDuration;

		public static float HoldInteractionFadeOutDuration => CustomSettings<HUDSettings>.I.m_holdInteractionFadeOutDuration;
	}
}
