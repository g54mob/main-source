using System.Collections.Generic;
using Dhs5.Utility.Settings;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Settings("General/XP", Scope.Project)]
	public class XPSettings : CustomSettings<XPSettings>
	{
		[SerializeField]
		private XPRewardChart<EXPType, ESimulatorXPRewardEvent> m_simulatorChart;

		[SerializeField]
		private XPRewardChart<EXPType, ETabletopXPRewardEvent> m_tabletopChart;

		public static IEnumerable<(int, int)> GetSimulatorRewards(ESimulatorXPRewardEvent e)
		{
			return CustomSettings<XPSettings>.I.m_simulatorChart.GetRewardsForEvent(e);
		}

		public static IEnumerable<(int, int)> GetTabletopRewards(ETabletopXPRewardEvent e)
		{
			return CustomSettings<XPSettings>.I.m_tabletopChart.GetRewardsForEvent(e);
		}
	}
}
