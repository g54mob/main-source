using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public abstract class BaseRewardWindow : MonoBehaviour
	{
		public RectTransform buttonContent;

		public TMP_Text title;

		[Header("リロード")]
		public GameObject reloadContent;

		public Button reloadButton;

		public GameObject skipContent;

		public GeneralMessageSetter skipMessageSetter;

		public Button skipButton;

		public TMP_Text skipBonusText;

		public TMP_Text reloadText;

		public UnityAction PreSelectAnimation;

		public UnityAction SelectedAction;

		public Action SkipAction;

		public Action ReloadAction;

		public HorizontalLayoutGroup layoutGroup;

		protected MstUpgradePackEntities mstPack;

		protected List<RewardChoiceButton> buttons;

		protected int reloadCount;

		protected bool enableInfiniteReload;

		protected int desinatedChoice;

		protected List<int> desinatedRewards;

		protected eConfirmId _skipConfirmId;

		private readonly List<ePlayerBuff> skipBuffType;

		private List<(ePointType, int)> _skipBonus;

		private int _orverwriteReloadCost;

		public bool IsSelectSequence { get; set; }

		public virtual int GetFreeReloadCount => 0;

		public int ReloadMoney => 0;

		protected virtual bool SkipOk => false;

		public virtual void Init(eUpgradePack pack, int desinatedChoice = -1, List<int> desinatedRewards = null, bool enableReload = true, Action reloadAction = null)
		{
		}

		protected List<T> ChooseItem<T>(List<T> pool, int choiceCount)
		{
			return null;
		}

		public abstract void CreateReward(UnityAction selectedAction = null);

		protected void ChoiceAnimation(ref Sequence sequence)
		{
		}

		public virtual void SetFreeReloadCount(int add)
		{
		}

		protected bool CheckMultipleChoice()
		{
			return false;
		}

		public void UpdateReloadUI()
		{
		}

		public void ReloadReward()
		{
		}

		public void DebugReloadReward()
		{
		}

		private void CheckReloadButton(bool enableReload = true)
		{
		}

		protected void ResetButtons()
		{
		}

		protected bool CheckNoPool(IList chooseReward)
		{
			return false;
		}

		protected void AdjustmentLayoutSpace(int choiceCount)
		{
		}

		protected virtual void OffButtonUI()
		{
		}

		protected bool AddBuffSkipBonus(ref List<(ePointType, int)> skipBonus)
		{
			return false;
		}

		private void GetRewardSkipBonusPoint(List<(ePointType, int)> skipBonus)
		{
		}

		public virtual void OnRightTrigger()
		{
		}

		public virtual void OnLeftTrigger()
		{
		}
	}
}
