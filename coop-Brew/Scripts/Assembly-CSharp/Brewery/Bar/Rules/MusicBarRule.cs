using UnityEngine;

namespace Brewery.Bar.Rules
{
	[CreateAssetMenu(fileName = "MusicBarRule", menuName = "Brewery/Bar Rules/Music Rule")]
	public class MusicBarRule : BarRuleBase
	{
		private static readonly string[] NoMusicKeys;

		private const string FailNoMusic = "NO_MUSIC";

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
	}
}
