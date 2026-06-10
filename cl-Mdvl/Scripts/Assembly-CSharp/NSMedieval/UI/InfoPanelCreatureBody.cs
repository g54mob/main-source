using System.Collections.Generic;

namespace NSMedieval.UI
{
	public class InfoPanelCreatureBody
	{
		public List<InfoPanelStat> Stats { get; }

		public List<string> Infos { get; }

		protected InfoPanelCreatureBody(List<InfoPanelStat> stats, List<string> infos)
		{
			Stats = stats;
			Infos = infos;
		}
	}
}
