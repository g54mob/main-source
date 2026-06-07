using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MonsterScript_Boss_Desert : ABossStageScript
{
	public enum eState
	{
		IDLE = 0,
		MOVE = 1,
		ATTACK = 2
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public bool isTutorialFinished;

		internal void _003CCR_Intro_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_BossHitBack_003Ed__55 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public MonsterScript_Boss_Desert _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		private UI_CinematicBorder _003Cui_CinematicBorder_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_BossHitBack_003Ed__55(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_GameSpeedLerp_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float curSpeed;

		public float targetSpeed;

		public float duration;

		private float _003Ct_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_GameSpeedLerp_003Ed__58(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_Intro_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Desert _003C_003E4__this;

		private _003C_003Ec__DisplayClass44_0 _003C_003E8__1;

		private UI_CinematicBorder _003Cui_CinematicBorder_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_Intro_003Ed__44(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_LerpCamera_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Easing.Type easingType;

		public float duration;

		public Vector3 startPos;

		public Vector3 targetPos;

		public float startFOV;

		public float targetFOV;

		private float _003Ctime_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_LerpCamera_003Ed__45(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_Outro_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_Outro_003Ed__59(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_Round_AttackPlayer_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Desert _003C_003E4__this;

		private Obj_FireSource _003CflameSource_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_Round_AttackPlayer_003Ed__46(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_SwapTerrainToSnow_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Desert _003C_003E4__this;

		private float _003Ct_003E5__2;

		private float _003Ctime_003E5__3;

		private float _003Cduration_003E5__4;

		private Material _003Cmaterial_003E5__5;

		private float _003CstartIntensity_003E5__6;

		private Vector2 _003CheightRangeStart_003E5__7;

		private Vector2 _003CheightRangeEnd_003E5__8;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_SwapTerrainToSnow_003Ed__57(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_SwitchToWinterScene_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Desert _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

		private Color _003ClightColorStart_003E5__4;

		private Color _003ClightColorEnd_003E5__5;

		private float _003ClightIntensityStart_003E5__6;

		private float _003ClightIntensityEnd_003E5__7;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCR_SwitchToWinterScene_003Ed__56(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private List<Obj_BossTrainCart> list_TrainCarts;

	[SerializeField]
	private List<Obj_Chest> list_StartingChests;

	[SerializeField]
	private List<Obj_BossTrainCartLayout> list_trainCartLayouts;

	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private float attackRange;

	[SerializeField]
	private GameSceneReferenceHandler sceneReferenceHandler;

	[SerializeField]
	private List<Obj_MovingSceneObject> list_MovingEnvironmentObjects_Desert;

	[SerializeField]
	private List<ParticleSystem> list_EnvironmentParticles_Desert;

	[SerializeField]
	private List<ParticleSystem> list_EnvironmentParticles_Winter;

	[SerializeField]
	private Renderer renderer_Terrain;

	[SerializeField]
	private Material material_Terrain_Desert;

	[SerializeField]
	private Material material_Terrain_Winter;

	[SerializeField]
	private Material material_SceneFog_Winter;

	[SerializeField]
	private Material mat_RenderFeatureSceneFog;

	[SerializeField]
	private EnvSceneSettingData envSceneSettingData_Winter;

	[SerializeField]
	private Light light_Desert;

	[SerializeField]
	private Light light_Winter;

	[SerializeField]
	private Renderer renderer_Terrain_WinterTransition;

	[SerializeField]
	private eState state;

	private int currentTrainCartIndex;

	[SerializeField]
	private Monster_Boss_02 monster_boss;

	private Obj_BossTrainCannon currentCannon;

	private GameSceneReferenceHandler gameSceneReferenceHandler;

	private int hardModeArmorCount;

	private List<int> list_bossWalkedThroughtCartIndex;

	private Coroutine currentBossActionCoroutine;

	private int curWaveMonsterCount;

	private int curWaveIndex;

	private int totalWaveCount;

	private int roundIndex;

	private int killedMonsterCountThisWave;

	private bool isWinter;

	private Vector3 cameraOriginOffset;

	private void OnValidate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGameSettingChanged()
	{
	}

	private void OnInitializeEnvSceneBindings(GameSceneReferenceHandler refHandler)
	{
	}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void UpdateMovingBackgroundSetting()
	{
	}

	private void OnRoundStart(int round, int totalRound)
	{
	}

	private void OnBattleStart()
	{
	}

	private void OnBattleEnd()
	{
	}

	private void OnMonsterKilled(AMonsterBase monster)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Intro_003Ed__44))]
	public override IEnumerator CR_Intro()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_LerpCamera_003Ed__45))]
	private IEnumerator CR_LerpCamera(Vector3 startPos, Vector3 targetPos, float startFOV, float targetFOV, float duration, Easing.Type easingType)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Round_AttackPlayer_003Ed__46))]
	private IEnumerator CR_Round_AttackPlayer()
	{
		return null;
	}

	private void TriggerAnimation(string key)
	{
	}

	private void SetCannonChargeRate(float rate, float lerpDuration)
	{
	}

	private void Update()
	{
	}

	private void TriggerBossAnimation(string key)
	{
	}

	private void ShootBoss(float delay)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_BossHitBack_003Ed__55))]
	private IEnumerator CR_BossHitBack(float delay)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_SwitchToWinterScene_003Ed__56))]
	private IEnumerator CR_SwitchToWinterScene()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_SwapTerrainToSnow_003Ed__57))]
	private IEnumerator CR_SwapTerrainToSnow()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_GameSpeedLerp_003Ed__58))]
	private IEnumerator CR_GameSpeedLerp(float curSpeed, float targetSpeed, float duration)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Outro_003Ed__59))]
	public override IEnumerator CR_Outro()
	{
		return null;
	}
}
