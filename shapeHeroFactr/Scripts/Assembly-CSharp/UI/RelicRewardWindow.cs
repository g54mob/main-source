using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class RelicRewardWindow : BaseRewardWindow
	{
		[SerializeField]
		private RelicRewardChoiceButton _button;

		public override void CreateReward(UnityAction selectedAction = null)
		{
		}

		public static List<MstRelicDataEntities> SelectionRelic(MstUpgradePackEntities mstPack, int choiceCount)
		{
			return null;
		}

		public static List<MstRelicDataEntities> SelectionRelicWithResearch(MstUpgradePackEntities mstPack, int choiceCount)
		{
			return null;
		}

		private static int GetBuffPlusRarity(MstRelicRarityDataEntities rarityData)
		{
			return 0;
		}

		public static bool CustomFilter(MstRelicDataEntities data)
		{
			return false;
		}
	}
}
