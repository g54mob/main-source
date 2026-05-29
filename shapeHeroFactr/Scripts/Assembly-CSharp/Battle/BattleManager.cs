using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Libs;
using SaveData;
using SceneFocus;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using UI;
using UnityEngine;

namespace Battle
{
	public class BattleManager : SingletonMonoBehaviour<BattleManager>
	{
		[Serializable]
		public struct FocusCameraInfo
		{
			public eCameraPosLabel label;

			public List<ePhase> phases;

			public TransitionCameraInfo cameraInfo;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass69_0
		{
			public bool arriveBattleScene;

			public bool closeWaveRewardDialog;

			internal void _003CStartWaveResultSequence_003Eb__0()
			{
			}

			internal bool _003CStartWaveResultSequence_003Eb__2()
			{
				return false;
			}

			internal void _003CStartWaveResultSequence_003Eb__1()
			{
			}

			internal bool _003CStartWaveResultSequence_003Eb__3()
			{
				return false;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CStartWaveResultSequence_003Ed__69 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public BattleManager _003C_003E4__this;

			private _003C_003Ec__DisplayClass69_0 _003C_003E8__1;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Label("街の位置")]
		public Transform town;

		public float fadeDuration;

		[SerializeField]
		private List<Transform> _spriteFadeCluster;

		public SpriteNo damagePrefab;

		public float unitAnimationThreshold;

		[Header("ONでMstUnitDataでUnitのステータスを上書きする（プレイ中のみ）")]
		public bool isOverWriteUnitData;

		public GameObject displayRange;

		public List<FocusCameraInfo> focusCameraInfos;

		public Canvas battleCanvas;

		public AvatorTalkCanvas avatarTalkCanvas;

		public SkipCanvas skipCanvas;

		[Header("Wave終了後の波動設定")]
		[SerializeField]
		private int withdrawalCount;

		[SerializeField]
		private float withdrawalRadius;

		[SerializeField]
		private SpriteMask battleFieldSpriteMask;

		public static readonly string defaultUnitPrefabAddres;

		public static readonly string defaultMiraclePrefabAddress;

		public static readonly string defaultEnemyPrefabAddres;

		public static readonly string defaultEnemyClusterPrefabAddres;

		public static BattleContext Bc;

		public static WaveInfoData Wid;

		public static Transform townTf;

		public static bool IsOpennigSequence;

		private InputActionController input;

		private float delayTimeForStartBGM;

		private float screenshotCameraAddPosY;

		private float screenshotCameraBaseOrthoSize;

		private float screenshotCameraOrthoSizeMaxX;

		private float screenshotCameraOrthoSizeMaxY;

		private float fieldRectBaseWidth;

		private float fieldRectBaseHeight;

		private int beforeCountdownTime;

		private CancellationTokenSource _cancelsource;

		private bool finishInitOvertimePerWave;

		private Action<float, float, bool> changeResolution;

		public static int ScreenShotWidth;

		public static int ScreenShotHeight;

		public static readonly int ManagedSequenceId;

		private Sequence startWaveSewuence;

		private Sequence _moveLastBattleSequence;

		private static bool _isPlayTrialFinishMovie;

		public static eDialog inTheMiddleDialog;

		private List<MstScoreRecordEntities> _calcRecordDelivery;

		private Dictionary<eLuggage, List<(eScoreRecord, int)>> _luggageScoreCache;

		public static bool IsPauseOrDialog => false;

		public static bool IsPlayTrialFinishMovie
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event Action DestroyBattleSceneProcess
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public FocusCameraInfo GetCameraInfo(eCameraPosLabel label)
		{
			return default(FocusCameraInfo);
		}

		public FocusCameraInfo GetCameraInfo(ePhase phase)
		{
			return default(FocusCameraInfo);
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Init()
		{
		}

		private void SyncTime()
		{
		}

		private void InputShortCut()
		{
		}

		private void BattleTimeUpdate()
		{
		}

		public static Sequence CreateManagedSequene(GameObject link = null)
		{
			return null;
		}

		public static Tween CreateManagedTween(Tween tween)
		{
			return null;
		}

		private void CoundDownTimer()
		{
		}

		private bool OverTimeCounterProcess()
		{
			return false;
		}

		private void ResetOverTime()
		{
		}

		private void OpeningSeauence(ref Sequence sequence, TransitionCameraInfo toCamera)
		{
		}

		public void LoadPhase()
		{
		}

		public void PlayWaveStartBGM()
		{
		}

		public void StartSelectSequence(bool isLoad = false)
		{
		}

		public void FinishSelectSequence()
		{
		}

		public void StartWaveSequence(bool isLoad = false)
		{
		}

		public void WaitSkipStartWaveSequence()
		{
		}

		public void SkipStartWaveSequence()
		{
		}

		private void SkipSequence(Sequence sequence, bool withCallback = true)
		{
		}

		public void StartWave()
		{
		}

		public void ClearWave()
		{
		}

		[AsyncStateMachine(typeof(_003CStartWaveResultSequence_003Ed__69))]
		public void StartWaveResultSequence()
		{
		}

		public void AddStageDataProcess(eStageDivision addDivision)
		{
		}

		private Sequence MoveLastBattle(bool enterLastBattle = false)
		{
			return null;
		}

		public void WaitSkipMoveLastBattleSequence()
		{
		}

		public void SkipMoveLastBattleSequence()
		{
		}

		private void PlayEnding()
		{
		}

		public Sequence WaveClearDestroyProcess(eEnemy ignoreEnemy = eEnemy.None)
		{
			return null;
		}

		public Sequence GetDestroyFromNearlySequence(List<BaseEnemy> destroyTarget)
		{
			return null;
		}

		public int GetProgressTime(ePhase phase)
		{
			return 0;
		}

		public void StartWaveBGM(float? overrideDelayTime = null)
		{
		}

		public void StartWait(bool isLoad = false)
		{
		}

		private void UpdateSwitchNextTime()
		{
		}

		public (eEnemy, bool) IsSpecialWave(eEnemyType checkType)
		{
			return default((eEnemy, bool));
		}

		public void HealLongThink(int healCount)
		{
		}

		private void CountUpManufacture()
		{
		}

		public void ClearDivisionProcess(eStageDivision clearDivision)
		{
		}

		public void GameClearSaveProcess()
		{
		}

		public void GameOverSaveProcess(bool isDiacard = false)
		{
		}

		private void CheckNeedFreeControl(bool isDiacard)
		{
		}

		public void SetScreenShotCamera(CaptureScreenCamera captureCamera = null)
		{
		}

		private float GetScreenShotCameraOrthographicSize()
		{
			return 0f;
		}

		private Texture2D GetScreenShot(int newWidth = 0, int newHeight = 0)
		{
			return null;
		}

		private void AddKnowledgePoint()
		{
		}

		public void CheckPermanentUnlock()
		{
		}

		public void OpenShortCutList()
		{
		}

		private void CheckTrialFinish()
		{
		}

		private void InitCamera()
		{
		}

		private void ChangeResolutionBattle()
		{
		}

		public void ControllNoticeToFactory(SceneFocusManager.MoveFactoryOperation operation)
		{
		}

		public void ControllNoticeToBattle(SceneFocusManager.MoveFactoryOperation operation)
		{
		}

		public void CreateProcessingNotice(eMessageId messageId, eDialog returnDialog)
		{
		}

		public void RegisterScore(eChallengeId challengeId, eWriterId writerId)
		{
		}

		public JDictionary<eScoreRecord, ScoreDetailModel> GetAllScoreAmount()
		{
			return null;
		}

		public void CalcFinishScore()
		{
		}

		public int CalcScoreKind(MstScoreRecordEntities recordData)
		{
			return 0;
		}

		public int CalcDeliveryLuggage(eLuggage luggage)
		{
			return 0;
		}

		public int CalcScoreKind(MstScoreRecordEntities recordData, eLuggage luggage)
		{
			return 0;
		}

		private int GetRemainHpScore(MstScoreRecordEntities record)
		{
			return 0;
		}

		private int GetLuggageRankScore(MstScoreRecordEntities record)
		{
			return 0;
		}

		private int GetMorePointScore(MstScoreRecordEntities record)
		{
			return 0;
		}

		private int GetMoreLevelScore(MstScoreRecordEntities record)
		{
			return 0;
		}

		private int GetAllBossEeliminatedScore(MstScoreRecordEntities record)
		{
			return 0;
		}

		private int GetNoDamageScore(MstScoreRecordEntities record)
		{
			return 0;
		}

		private int GetClearWaveScore(MstScoreRecordEntities record)
		{
			return 0;
		}

		private int GetClearEnemyTypeScore(MstScoreRecordEntities record)
		{
			return 0;
		}

		public int GetEasterLuggageScore(MstScoreRecordEntities record, eLuggage luggage)
		{
			return 0;
		}

		public void SetDebugUnit(Dictionary<eLuggage, DebugBattleDialog.DebugHeroParam> unitSetting)
		{
		}

		public void SetDebugEnemy(Dictionary<eEnemy, MstEnemyLevelEntities> enemySetting)
		{
		}

		public void EndressBattle()
		{
		}

		private new void OnDestroy()
		{
		}
	}
}
