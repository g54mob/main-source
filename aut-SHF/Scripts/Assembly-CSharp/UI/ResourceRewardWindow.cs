using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class ResourceRewardWindow : BaseRewardWindow
	{
		[SerializeField]
		private ResourceRewardChoiceButton _button;

		public override void CreateReward(UnityAction selectedAction = null)
		{
		}

		public static List<(bool, MstMachineDataEntities)> SelectionMachines(MstUpgradePackEntities mstPack, int choiceCount)
		{
			return null;
		}
	}
}
