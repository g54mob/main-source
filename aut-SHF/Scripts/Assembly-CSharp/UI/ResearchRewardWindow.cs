using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class ResearchRewardWindow : BaseRewardWindow
	{
		[SerializeField]
		private ResearchRewardChoiceButton _button;

		private List<eResearchCategory> _prevData;

		protected override bool SkipOk => false;

		public override void CreateReward(UnityAction selectedAction = null)
		{
		}

		public static List<MstResearchCategoryEntities> SelectionResearch(MstUpgradePackEntities mstPack, eWriterId writerId)
		{
			return null;
		}

		public static List<MstResearchCategoryEntities> GetPoolByWriter(eWriterId id)
		{
			return null;
		}

		public bool CustomFilter(MstResearchCategoryEntities data)
		{
			return false;
		}
	}
}
