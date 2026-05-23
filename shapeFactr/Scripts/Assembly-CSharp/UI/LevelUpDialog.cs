using System;
using System.Collections.Generic;
using Audio;
using InputControl;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using TMPro;
using UnityEngine;

namespace UI
{
	public class LevelUpDialog : BaseDialog
	{
		[Serializable]
		public struct LevelupInfo
		{
			public eLevelUpRewardType type;

			[Tooltip("ここに設定したステージでは表示されない")]
			public List<eStageId> ignoreStage;

			public eUpgradeId normalId;

			public eUpgradeId rareId;

			public LevelUpRewardChoiceButton button;
		}

		public enum eLevelUpRewardType
		{
			None = 0,
			Circle = 1,
			Triangle = 2,
			Square = 3,
			Mana = 4,
			Research = 5
		}

		[Header("レベルアップ概要")]
		[SerializeField]
		private GameObject lvupOverview;

		[SerializeField]
		private LevelUpRewardCategory categoryButtonPrefab;

		[SerializeField]
		private RectTransform categoryButtonContent;

		[SerializeField]
		private TMP_Text prevLvText;

		[SerializeField]
		private TMP_Text nextLvText;

		[SerializeField]
		private TMP_Text researchPointText;

		[SerializeField]
		private TMP_Text keenText;

		[SerializeField]
		private TMP_Text manaIncreasePrev;

		[SerializeField]
		private TMP_Text manaIncreaseNext;

		[Header("レベルアップ報酬選択")]
		[SerializeField]
		private GameObject lvupChoiceView;

		[SerializeField]
		private LevelupInfo[] levelUpInfos;

		[SerializeField]
		private PlaySEElement seElement;

		[SerializeField]
		private CursorUIGroup dummyGroup;

		[SerializeField]
		private GameObject cursorParent;

		private RewardSetting _rewardSetting;

		private int _rareCount;

		private bool _allRare;

		private bool isSelected;

		private bool delayed;

		private int _choiceCount;

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		private void ResetLevelUpContent()
		{
		}

		private void ResetChoiceView()
		{
		}

		private void CreateOverview()
		{
		}

		public void ChangeView()
		{
		}

		public override void SetInFront()
		{
		}

		public override void Back()
		{
		}

		public override void PushEscape()
		{
		}

		public override void PlayCloseSound()
		{
		}
	}
}
