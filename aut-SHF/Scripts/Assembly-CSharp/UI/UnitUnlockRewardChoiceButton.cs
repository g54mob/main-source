using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UnitUnlockRewardChoiceButton : RewardChoiceButton
	{
		[Serializable]
		private struct RankSprite
		{
			public eUnitRank rank;

			public Sprite sprite;
		}

		[Serializable]
		private struct ToggleInfo
		{
			public UnitRewardWindow.StatusInfo infoType;

			public GameObject infoObj;
		}

		public Image unlockIcon;

		public RectTransform treeButtonGroup;

		public ChoiceMenuButton treeButton;

		public Image treeButtonEmphasis;

		public Image cautionIcon;

		public GameObject cautionMachineText;

		public GameObject cautionResourceText;

		public Sprite openLockSprite;

		public RectTransform sourceParent;

		public VerticalLayoutGroup sourceParentLayoutGroup;

		public CollectionDetailUnit unitDetailPrefab;

		public StarCounter starCounter;

		public GameObject twoSourceArrow;

		public GameObject threeSourceArrow;

		public Image craftMachineIcon;

		[SerializeField]
		private Button _lankButton;

		[SerializeField]
		private List<RankSprite> _rankSprites;

		[SerializeField]
		private GameObject _upgradePack;

		[SerializeField]
		private Image _beforeLuggageIcon;

		[SerializeField]
		private Image _afterLuggageIcon;

		[SerializeField]
		private TMP_Text _productNeedCount;

		[SerializeField]
		private List<ToggleInfo> _toggleObjs;

		[SerializeField]
		private GameObject _unlockDescGroup;

		[SerializeField]
		private TMP_Text _upgradeDesc;

		[SerializeField]
		private InfoHeroStatus _infoHeroStatus;

		[SerializeField]
		private InfoProduct _infoProduct;

		[SerializeField]
		private List<GameObject> _levelParticles;

		[SerializeField]
		private Image statueIcon;

		[SerializeField]
		private Vector2 existStatueAnchoredPos;

		[SerializeField]
		private RectTransform upgradeUnitContent;

		private eLuggage _luggageCache;

		private Vector3 _initPackIconScale;

		private Vector3 _initTreeButtonScale;

		private Tween _emphasisTween;

		private bool _upgradInfoMode;

		private UnitRewardWindow.StatusInfo _nowDisplayStatus;

		private bool _untilUnlock;

		public override void InitComponent(string archiveId, string iconPath, string name, string desc)
		{
		}

		protected virtual bool IsUnlock(PlayUnlockData unlockData)
		{
			return false;
		}

		private eUnitRank GetUnitLank(PlayUnlockData luggageData)
		{
			return default(eUnitRank);
		}

		private string GetName(PlayUnlockData luggageData)
		{
			return null;
		}

		public override void PlayAnimation(ref Sequence sequence)
		{
		}

		private void InitTreeButton()
		{
		}

		private void OnTreeButtonClick(object ret)
		{
		}

		private void OnTreeButtonFocus(object ret)
		{
		}

		private void OnTreeButtonBlur(object ret)
		{
		}

		public override void CreateDetailDescription(RectTransform parent)
		{
		}

		public CollectionDetailUnit CreateSourceLuggage(eLuggage luggage)
		{
			return null;
		}

		public void OnPushCollection()
		{
		}

		public void UpdateInfoData(UnitRewardWindow.StatusInfo statusInfo)
		{
		}

		public void OnSwitchInfo()
		{
		}

		private void OnDisable()
		{
		}
	}
}
