using System.Collections.Generic;
using NSMedieval.State;

namespace NSMedieval.UI
{
	public class InfoPanelWorkerBody : InfoPanelCreatureBody
	{
		public HumanoidInstance Humanoid { get; }

		public int IconId { get; }

		public InfoPanelWorkerBody(int iconId, HumanoidInstance humanoid, List<InfoPanelStat> stats, List<string> infos)
			: base(stats, infos)
		{
			IconId = iconId;
			Humanoid = humanoid;
		}
	}
}
