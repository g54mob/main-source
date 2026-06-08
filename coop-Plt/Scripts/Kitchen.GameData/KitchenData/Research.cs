using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Research", menuName = "Kitchen/Research")]
	public class Research : LocalisedGameDataObject<ResearchLocalisation>
	{
		public int RequiredResearch;

		public List<IUpgrade> Rewards;

		[HideInInspector]
		public List<Research> EnablesResearchOf;

		[HideInInspector]
		public List<Research> RequiresForResearch;

		protected override void InitialiseDefaults()
		{
			RequiredResearch = 1;
			EnablesResearchOf = new List<Research>();
			RequiresForResearch = new List<Research>();
			Rewards = new List<IUpgrade>();
		}

		public override void SetupForGame()
		{
			if (EnablesResearchOf == null)
			{
				EnablesResearchOf = new List<Research>();
			}
			if (RequiresForResearch == null)
			{
				RequiresForResearch = new List<Research>();
			}
			EnablesResearchOf.Clear();
			RequiresForResearch.Clear();
			if (Rewards == null)
			{
				Rewards = new List<IUpgrade>();
			}
		}
	}
}
