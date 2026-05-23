using System;
using System.Collections.Generic;
using DG.Tweening;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using Spine;
using Spine.Unity;
using UI;
using UnityEngine;
using UnityEngine.Rendering;

namespace Battle
{
	public class DecorationCtrl : SingletonMonoBehaviour<DecorationCtrl>
	{
		[Serializable]
		public class StageGimmick
		{
			public eStageDivision division;

			public BaseStageGimmick gimmick;

			public int cloudNumber;
		}

		[Serializable]
		public struct CloudDeco
		{
			public GameObject allCloud;

			public GameObject rightCloud;

			public GameObject leftCloud;
		}

		public ParticleSystem gateAuraEffect;

		public ParticleSystem blueCircleEffect;

		public ParticleSystem redCircleEffect;

		public ParticleSystem waveClearEffect;

		public ParticleSystem phoenixEffect;

		[SerializeField]
		private GameObject _woodGroup;

		[SerializeField]
		private SkeletonAnimation _gateSpine;

		[SerializeField]
		private GameObject symbolPen;

		[SerializeField]
		private SpriteRenderer symbolCircle;

		[SerializeField]
		private ParticleSystem damageEffect;

		[SerializeField]
		private GameObject _cloudGroup;

		[SerializeField]
		private GameObject _rightCloudGroup;

		[SerializeField]
		private GameObject _leftCloudGroup;

		[Label("待機時雲横移動最少幅")]
		[SerializeField]
		private float _cloudMinMoveValueX;

		[Label("待機時雲横移動最大幅")]
		[SerializeField]
		private float _cloudMaxMoveValueX;

		[Label("待機時雲1往復時間")]
		[SerializeField]
		private float _cloudYoyoTime;

		[Label("フェーズ変更時横移動幅")]
		[SerializeField]
		private float _cloudChangePhaseMoveValueX;

		[SerializeField]
		private List<StageGimmick> _stageDecoGroup;

		[Header("通常クリアの演出")]
		[SerializeField]
		private StageGimmick _normalClearGimmick;

		[Header("ラストステージ前の演出")]
		[SerializeField]
		private StageGimmick _enterLastStageGimmick;

		[SerializeField]
		private SpriteRenderer _darkMask;

		[SerializeField]
		private BossEliminationUI bossElimination;

		[SerializeField]
		private HitEffect overtimeDamageEffect;

		public GameObject pseudoRadialBlur;

		private DG.Tweening.Sequence _gateDamageSequence;

		private SpriteRenderer[] _cloudSprites;

		private Spine.AnimationState _gateAnimeState;

		private const string GATE_IDLE = "Idling";

		private const string GATE_ENTRY = "Appear";

		private Vector3 _rightCloudStartPos;

		private Vector3 _leftCloudStartPos;

		private SortingGroup[] _scalingDecoPoints;

		private BaseStageGimmick _mainDeco;

		private eStageDivision _nowStageDivision;

		private Vector3[] _decorationScaleCache;

		private GateSettings _gateInfo;

		private ParticleSystem _gateEffect;

		private string _playGateAnimation;

		public BaseStageGimmick GetNowStageGimmick => null;

		private void Awake()
		{
		}

		public void Init()
		{
		}

		public StageGimmick GetStageGimmickSetting(eStageDivision division)
		{
			return null;
		}

		public void ReplacementStageDeco(eStageDivision division, bool changeCloud = true)
		{
		}

		public void ReplacementStageDeco(StageGimmick stageSetting, bool changeCloud = true)
		{
		}

		private void ResetDecoScale()
		{
		}

		private void ChangeStageDeco(StageGimmick gimmickSetting, bool changeCloud = true)
		{
		}

		public DG.Tweening.Sequence EntryGate(int hp, int maxHp)
		{
			return null;
		}

		public DG.Tweening.Sequence ExitGate(int hp, int maxHp)
		{
			return null;
		}

		private GateSettings.HpGateStr GetGateState(int currentHp, int maxHp)
		{
			return default(GateSettings.HpGateStr);
		}

		public void UpdateGateAnimation(int currentHp, int maxHp, bool on = true)
		{
		}

		public void DamageEffect(Vector3 hitPosition)
		{
		}

		public DG.Tweening.Sequence EntryCloud()
		{
			return null;
		}

		public void ExitCloud(ref DG.Tweening.Sequence sequence)
		{
		}

		public void ExitCloud(bool isImmediate = false)
		{
		}

		public void StartCloudWait()
		{
		}

		public DG.Tweening.Sequence EntryDecorations()
		{
			return null;
		}

		public DG.Tweening.Sequence ExitDecorations(float duration = 0.6f)
		{
			return null;
		}

		public void PlayClearWaveEffect()
		{
		}

		public void PlayPhoenixEffect()
		{
		}

		public DG.Tweening.Sequence PlayStageGimmick(bool isBoss = false)
		{
			return null;
		}

		public DG.Tweening.Sequence PreMoveBattleGimmick(bool isBoss = false)
		{
			return null;
		}

		public void ChangeClearGimmick(bool isEnterLastStage)
		{
		}

		public DG.Tweening.Sequence PlayClearGimmick(bool isEnterLastStage)
		{
			return null;
		}

		public DG.Tweening.Sequence EnterDarkness()
		{
			return null;
		}

		public DG.Tweening.Sequence ExitDarkness(float duration = 1f)
		{
			return null;
		}

		public DG.Tweening.Sequence BossEliminationAnimation(eEnemy enemy)
		{
			return null;
		}

		public void EnterOvertimeDamageEffect()
		{
		}
	}
}
