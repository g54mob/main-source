using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class OrdealRewardWindow : BaseRewardWindow
	{
		[SerializeField]
		private OrdealRewardChoiceButton _button;

		private List<eOrdealWisdom> _selectionIds;

		private string _blessingText;

		private string _curseText;

		protected override bool SkipOk => false;

		public override void Init(eUpgradePack pack, int desinatedChoice = -1, List<int> desinatedRewards = null, bool enableReload = true, Action reloadAction = null)
		{
		}

		public override void CreateReward(UnityAction selectedAction = null)
		{
		}

		private List<MstOrdealWisdomDataEntities> SelectionOrdealKnowledge(MstUpgradePackEntities mstPack, int choiceCount)
		{
			return null;
		}

		private void SkippedAction()
		{
		}
	}
}
