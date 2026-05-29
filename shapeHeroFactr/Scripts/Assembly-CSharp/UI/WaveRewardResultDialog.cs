using System;
using System.Collections.Generic;
using DG.Tweening;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class WaveRewardResultDialog : BaseDialog
	{
		public enum AdditionalReward
		{
			None = 0,
			ClearNamed = 10,
			ClearBoss = 20,
			EliminatedNamed = 30,
			EliminatedBoss = 40,
			RelicEffect = 50,
			LuggageEffect = 60,
			Other = 100
		}

		public struct AdditionalRewardData
		{
			public AdditionalReward rewardType;

			public string sourceIconPath;

			public string rewardName;

			public string rewardIconPath;

			public string rewardValue;

			public AdditionalRewardData(AdditionalReward reward, string sourceIconPath = "", string rewardName = "", string rewardIconPath = "", string rewardValue = "")
			{
				rewardType = default(AdditionalReward);
				this.sourceIconPath = null;
				this.rewardName = null;
				this.rewardIconPath = null;
				this.rewardValue = null;
			}
		}

		[SerializeField]
		private TMP_Text _getManaText;

		[SerializeField]
		private TMP_Text _getKeenText;

		[SerializeField]
		private TMP_Text _getExpText;

		[SerializeField]
		private GameObject _manaRewardRow;

		[SerializeField]
		private GameObject _keenRewardRow;

		[SerializeField]
		private GameObject _expRewardRow;

		[SerializeField]
		private RectTransform _additionalRewardContent;

		[SerializeField]
		private AdditionalRewardRow _additionalRewardRowPrefab;

		[SerializeField]
		private RectTransform _damageContent;

		[SerializeField]
		private ResultLuggageBar _luggageBarPrefab;

		[SerializeField]
		private Button _endlessButton;

		[SerializeField]
		private TMP_Text _nextText;

		[SerializeField]
		private Button _nextButton;

		[Header("Animation")]
		[SerializeField]
		private SkeletonGraphicController _waveClearCutin;

		[SerializeField]
		private GameObject _cursor;

		private Sequence _displaySequence;

		private int _getExp;

		private int _getKeen;

		private int _getMaterial;

		private int _getGreenResearch;

		private int _getRedResearch;

		private int _getRemovePickaxe;

		private List<eUpgradePack> _rewardList;

		private UnityAction _callback;

		private List<AdditionalRewardData> _addRewardDatas;

		private UnityAction GetRewardAction;

		private UISetting _uiSetting;

		private ResultLuggageBar[] _luggageBars;

		private Animator _animator;

		private float _openClipLength;

		private bool _isOpened;

		private const string OpenParamName = "Open";

		private readonly int OpenParamHash;

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		private void WaveRewardResultSetting()
		{
		}

		private void CheckClearNamed(MstBattleInfoDataEntities data, int loopCount = 1)
		{
		}

		private void CheckClearBoss(MstBattleInfoDataEntities data)
		{
		}

		private int GetLoopCount()
		{
			return 0;
		}

		private void AddTargetPoint(ePointType type, int add)
		{
		}

		private void AdditionalPointReward(List<RewardSetting.AdditionalPoint> additionalPoints, AdditionalReward rewardType, string sourceIcon, string rewardName)
		{
		}

		private void CheckBuffBonus()
		{
		}

		private int AddBuffRewardPoint(ePlayerBuff buffType, ePointType point, Func<int, int> calcFunc = null)
		{
			return 0;
		}

		private void GetAdditionalCommonRecord(eArchiveCategory categoryId, string sourceId, string rewardIconPath, string rewardValue = "")
		{
		}

		private void CreateAdditionalReward(AdditionalRewardData data)
		{
		}

		private void ResetContent()
		{
		}

		public void OnClickOk(eStageDivision addStageDivision = eStageDivision.None, bool finishRun = false)
		{
		}

		public override void Back()
		{
		}

		public override void PushEscape()
		{
		}

		public override void SetInFront()
		{
		}

		public void StartWaveClearCutin()
		{
		}

		public void StopWaveClearCutin()
		{
		}
	}
}
