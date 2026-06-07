using Brewery.Core;
using UnityEngine;

namespace Brewery.Calendar
{
	[CreateAssetMenu(fileName = "BalancerConstantsOverride", menuName = "Brewery/Calendar/Balancer Constants Override", order = 15)]
	public class BalancerConstantsOverride : ScriptableObject
	{
		private static BalancerConstantsOverride _instance;

		private static bool _loadAttempted;

		[Header("Global Tag Fallback Multipliers")]
		[Tooltip("Applied to a drink's tag when the faction has no opinion on that tag. Sale-side: values > 1 boost, < 1 penalise.")]
		[Min(0f)]
		[SerializeField]
		private float m_LacedMultiplier;

		[Min(0f)]
		[SerializeField]
		private float m_WeedMultiplier;

		[Min(0f)]
		[SerializeField]
		private float m_VulgarMultiplier;

		[Min(0f)]
		[SerializeField]
		private float m_BlessedMultiplier;

		[Min(0f)]
		[SerializeField]
		private float m_SketchyMultiplier;

		[Min(0f)]
		[SerializeField]
		private float m_PremiumMultiplier;

		[Min(0f)]
		[SerializeField]
		private float m_SmoothMultiplier;

		[Min(0f)]
		[SerializeField]
		private float m_StrongMultiplier;

		public static BalancerConstantsOverride Instance => null;

		public float LacedMultiplier => 0f;

		public float WeedMultiplier => 0f;

		public float VulgarMultiplier => 0f;

		public float BlessedMultiplier => 0f;

		public float SketchyMultiplier => 0f;

		public float PremiumMultiplier => 0f;

		public float SmoothMultiplier => 0f;

		public float StrongMultiplier => 0f;

		public static void InvalidateCache()
		{
		}

		public static float Resolve(BrewTag tag)
		{
			return 0f;
		}
	}
}
