using UnityEngine;

namespace Brewery.Bar.Rules
{
	[CreateAssetMenu(fileName = "LightingBarRule", menuName = "Brewery/Bar Rules/Lighting Rule")]
	public class LightingBarRule : BarRuleBase
	{
		[Header("Time Settings")]
		[Tooltip("Hour when day starts (lights should be off). Default: 6 (6am)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int dayStartHour;

		[Tooltip("Hour when night starts (lights should be on). Default: 22 (10pm)")]
		[Range(0f, 23f)]
		[SerializeField]
		private int nightStartHour;

		private static readonly string[] TooBrightKeys;

		private static readonly string[] TooDarkKeys;

		private const string FailTooBright = "TOO_BRIGHT";

		private const string FailTooDark = "TOO_DARK";

		public override RuleStatus Evaluate(BarRuleContext context)
		{
			return default(RuleStatus);
		}

		public override string GetComplaintMessage(RuleStatus status)
		{
			return null;
		}

		public override string GetStatusMessage(RuleStatus status)
		{
			return null;
		}

		private bool IsDaytimeInternal(BarRuleContext context)
		{
			return false;
		}
	}
}
