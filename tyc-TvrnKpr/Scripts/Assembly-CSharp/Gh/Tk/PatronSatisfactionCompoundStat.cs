using System;

namespace Gh.Tk
{
	public class PatronSatisfactionCompoundStat : SatisfactionStatBase
	{
		private PatienceStat _patienceStat;

		private PatienceStat PatienceStat => null;

		protected PatronSatisfactionCompoundStat()
		{
		}

		public PatronSatisfactionCompoundStat(Patron owner)
		{
		}

		private IDisposable ReplaceBaseDictionary(bool includeTooltips = false)
		{
			return null;
		}

		public override void Update()
		{
		}

		private void UpdateBaseEmotionalState()
		{
		}

		public override TooltipData GenerateTooltipData()
		{
			return null;
		}

		internal override void DisableTracking()
		{
		}
	}
}
