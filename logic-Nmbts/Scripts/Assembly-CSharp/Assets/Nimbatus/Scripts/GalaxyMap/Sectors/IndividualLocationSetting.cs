using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.TravelEvents;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Sectors
{
	public class IndividualLocationSetting
	{
		public bool IsSpecialLocation;

		public bool CustomTheme;

		[ShowIf("CustomTheme", true)]
		public NimbatusPlanetTheme Theme;

		public bool CustomMission;

		[ShowIf("CustomMission", true)]
		public NimbatusMission Mission;

		public bool CustomRewards;

		[ShowIf("CustomRewards", true)]
		public List<TravelEventConsequence> Rewards;
	}
}
