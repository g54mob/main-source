using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class PseudonymTooltipView : WorkerBaseTooltipViewNew
	{
		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			if (base.Humanoid == null)
			{
				return lines;
			}
			if (Repository<PseudonymRepository, Pseudonym>.Instance.GetPseudonym(base.Humanoid.Info.PseudonymId) == null)
			{
				return lines;
			}
			return HumanoidUtils.GetPseudonymTooltipLines(base.Humanoid);
		}
	}
}
