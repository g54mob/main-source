using System;
using System.Collections.Generic;
using Kitchen.Layouts;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "LayoutProfile", menuName = "Kitchen/Layout Profile", order = 1)]
	public class LayoutProfile : LocalisedGameDataObject<BasicInfo>, IUpgrade
	{
		public LayoutGraph Graph;

		public int MaximumTables = 3;

		public List<GameDataObject> RequiredAppliances;

		public GameDataObject Table;

		public GameDataObject Counter;

		public Appliance ExternalBin;

		public Appliance WallPiece;

		public Appliance InternalWallPiece;

		public Appliance StreetPiece;

		public Season FixedRunSeason;

		[NonSerialized]
		[HideInInspector]
		public string Name = "New Layout";

		[NonSerialized]
		[HideInInspector]
		public string Description = "A new layout type for your restaurants!";

		int IUpgrade.MaximumUpgradeCount => 1;

		string IUpgrade.UpgradeName => Name;

		string IUpgrade.UpgradeDescription => Description;

		int IUpgrade.ID => ID;

		protected override void InitialiseDefaults()
		{
			RequiredAppliances = new List<GameDataObject>();
		}

		public override bool Localise(Locale locale, StringSubstitutor subs)
		{
			if (Info == null)
			{
				return false;
			}
			BasicInfo basicInfo = Info.Get(locale);
			if (basicInfo == null)
			{
				return false;
			}
			Name = subs.Parse(basicInfo.Name);
			Description = subs.Parse(basicInfo.Description);
			return true;
		}
	}
}
