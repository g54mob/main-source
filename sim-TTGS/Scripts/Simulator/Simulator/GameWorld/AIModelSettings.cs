using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("AI/Models", Scope.Project)]
	public class AIModelSettings : CustomSettings<AIModelSettings>
	{
		[Header("Walking")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_minimumWalkVelocity = 0.5f;

		[SerializeField]
		[Range(0f, 3f)]
		private float m_walkingAnimationSpeedMultiplier = 0.25f;

		[SerializeField]
		[Range(1f, 10f)]
		private int m_shouldWalkSamplesCount = 5;

		[Header("Take Product")]
		[SerializeField]
		private float m_takeProductAnimDuration;

		[Header("Payment")]
		[SerializeField]
		private float m_showCashAnimDuration;

		[Header("Sit")]
		[SerializeField]
		private float m_manSitOffset = -0.2f;

		[SerializeField]
		private float m_manSitOffsetDuration = 0.5f;

		[SerializeField]
		private float m_manStandOffsetDuration = 0.1f;

		[Header("Painting")]
		[SerializeField]
		private int m_paintingLayerIndex;

		[SerializeField]
		private float m_paintingLayerWeight;

		[SerializeField]
		private float m_paintingAnimTransiDuration;

		[SerializeField]
		private AnimationCurve m_paintingAnimTransiCurve;

		[Header("Playing")]
		[SerializeField]
		private int m_playingLayerIndex;

		[SerializeField]
		private float m_playingAnimTransiDuration;

		[SerializeField]
		private AnimationCurve m_playingAnimTransiCurve;

		public static float MinimumWalkVelocity => CustomSettings<AIModelSettings>.I.m_minimumWalkVelocity;

		public static float WalkingAnimationSpeedMultiplier => CustomSettings<AIModelSettings>.I.m_walkingAnimationSpeedMultiplier;

		public static int ShouldWalkSamplesCount => CustomSettings<AIModelSettings>.I.m_shouldWalkSamplesCount;

		public static float TakeProductAnimDuration => CustomSettings<AIModelSettings>.I.m_takeProductAnimDuration;

		public static float ShowCashAnimDuration => CustomSettings<AIModelSettings>.I.m_showCashAnimDuration;

		public static float ManSitOffset => CustomSettings<AIModelSettings>.I.m_manSitOffset;

		public static float ManSitOffsetDuration => CustomSettings<AIModelSettings>.I.m_manSitOffsetDuration;

		public static float ManStandOffsetDuration => CustomSettings<AIModelSettings>.I.m_manStandOffsetDuration;

		public static int PaintingLayerIndex => CustomSettings<AIModelSettings>.I.m_paintingLayerIndex;

		public static float PaintingLayerWeight => CustomSettings<AIModelSettings>.I.m_paintingLayerWeight;

		public static float PaintingAnimTransitionDuration => CustomSettings<AIModelSettings>.I.m_paintingAnimTransiDuration;

		public static AnimationCurve PaintingAnimTransitionCurve => CustomSettings<AIModelSettings>.I.m_paintingAnimTransiCurve;

		public static int PlayingLayerIndex => CustomSettings<AIModelSettings>.I.m_playingLayerIndex;

		public static float PlayingAnimTransitionDuration => CustomSettings<AIModelSettings>.I.m_playingAnimTransiDuration;

		public static AnimationCurve PlayingAnimTransitionCurve => CustomSettings<AIModelSettings>.I.m_playingAnimTransiCurve;
	}
}
