using System.Collections.Generic;
using NSMedieval.State;

namespace NSMedieval.UI
{
	public class InfoPanelEnemyBody : InfoPanelCreatureBody
	{
		public HumanoidInstance Humanoid { get; }

		public InfoPanelEnemyBody(HumanoidInstance humanoid, List<InfoPanelStat> stats = null, List<string> infos = null)
			: base(stats, infos)
		{
			Humanoid = humanoid;
		}
	}
}
