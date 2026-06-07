using System.Collections.Generic;
using Battle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class DebugBattleDialog : BaseDialog
	{
		public class DebugHeroParam
		{
			public double span;

			public int level;

			public double rapTime;

			public bool SallyOk => false;

			public DebugHeroParam(double span, int level)
			{
			}
		}

		[Header("コンテンツ")]
		[SerializeField]
		private RectTransform[] heroRect;

		[SerializeField]
		private ScrollRect heroScrollRect;

		[SerializeField]
		private RectTransform enemyContent;

		[SerializeField]
		private RectTransform ascensionDescContent;

		[Header("プレファブ元")]
		[SerializeField]
		private DebugBattleHeroNode heroNode;

		[SerializeField]
		private DebugBattleEnemyNode enemyNode;

		[SerializeField]
		private TMP_Text ascensionDescPrefab;

		[Header("インフォメーション")]
		[SerializeField]
		private TMP_Text waveText;

		[SerializeField]
		private TMP_Text ascensionText;

		[Header("ボタン")]
		[SerializeField]
		private Button startButton;

		[Header("オプション")]
		[SerializeField]
		private Toggle endress;

		[SerializeField]
		private Toggle invincible;

		[SerializeField]
		private Toggle immortal;

		[SerializeField]
		private Toggle enabledHero;

		[SerializeField]
		private Toggle enabledEnemy;

		[SerializeField]
		private TMP_InputField difficulyRate;

		[SerializeField]
		private Toggle enabledDisplayMyHp;

		[SerializeField]
		private Toggle enabledDisplayBattleHp;

		[SerializeField]
		private Toggle enabledGridLine;

		[SerializeField]
		private Toggle enabledDisplayDetailLog;

		[SerializeField]
		private Toggle enabledHpMaxStart;

		[SerializeField]
		private Toggle enabledIntoOrdealBuff;

		[Header("ドロップダウン")]
		[SerializeField]
		private TMP_Dropdown ascensionSelect;

		[SerializeField]
		private TMP_Dropdown waveSelect;

		[SerializeField]
		private TMP_Dropdown waveGroupSelect;

		[Header("その他")]
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private List<eLuggage> ignoreDisplayLuggage;

		private Dictionary<eEnemy, DebugBattleEnemyNode> _enemyNodes;

		private float _difficultyRate;

		private List<DebugBattleHeroNode> _heroNodes;

		private int _lastSettingEnemyWave;

		private List<MstBattleInfoDataEntities> _infoDataList;

		private List<eWaveGroup> _waveGroupList;

		private eWaveGroup _defaultWaveGroup;

		public static bool EnabledDisplayMyHp;

		public static bool EnabledDisplayBattleHp;

		public static bool EnabledGridLine;

		public static bool EnabledDisplayDetailLog;

		public static bool DebugInvincibleGate;

		public static bool EnabledIntoOrdealBuff;

		public Dictionary<eLuggage, DebugHeroParam> _unitSettingDict { get; private set; }

		public Dictionary<eEnemy, MstEnemyLevelEntities> _enemyLevelDict { get; private set; }

		public override void Init()
		{
		}

		private void Update()
		{
		}

		public override void Open()
		{
		}

		private void SetWaveText()
		{
		}

		private void CreateAscensionOption(int maxLevel)
		{
		}

		private void CreateWaveOption(eWaveGroup waveGroup)
		{
		}

		private DebugBattleHeroNode CreateHeroNode(int idx)
		{
			return null;
		}

		private DebugBattleEnemyNode CreateEnemyNode()
		{
			return null;
		}

		public override void Back()
		{
		}

		public override void SetInFront()
		{
		}

		public void OnStart()
		{
		}

		public void OnResetHeroParam()
		{
		}

		public void OnFetchHeroData()
		{
		}

		public void OnResetNowWaveParam()
		{
		}

		public void OnChangeAscension(int value)
		{
		}

		private void ApplyBuffAll(eEnemyBuff buff, float value, eEnemyType targetType)
		{
		}

		private void ResetBuffAll(bool withClearPlayerBuff = true)
		{
		}

		public void OnChangeSelectWave(int value)
		{
		}

		public void OnChangeSelectWaveGroup(int value)
		{
		}

		public void OnChangeEndress(bool value)
		{
		}

		public void OnChangeInvincibleGate(bool value)
		{
		}

		public void OnPressTab(int value)
		{
		}

		public void OnTransparentDialog()
		{
		}

		public void OnChangeDifficltyValue()
		{
		}

		public void OnChangeDisplayHp(bool value)
		{
		}

		public void OnChangeDisplayBattleHp(bool value)
		{
		}

		public void OnChangeDisplayGridLine(bool value)
		{
		}

		public void OnChangeDisplayDetailLog(bool value)
		{
		}

		public void OnChangeEnabledIntoOrdealBuff(bool value)
		{
		}

		private LastBoss SearchLastBoss()
		{
			return null;
		}

		private void OnDestroy()
		{
		}
	}
}
