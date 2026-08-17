using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DG.Tweening;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Characters;

public class EX_Boss_Colossus : EnemyControllerBoss_TerrainBreaker
{
	private enum Colossus_Mode_Types
	{
		SETUP,
		ASLEEP,
		ROAMING,
		ENRAGED,
		POSITIONING,
		WINDUP,
		CHARGING,
		LEAVING_MAP
	}

	private const string AsleepAnimationName = "Asleep";

	private const string MovingAnimName = "Moving";

	private Vector2 _roamingTargetPosition;

	private int currentLocationOfInterest;

	private float awakenThresholdPercentage = 0.9f;

	private float enragedThresholdPercentage = 0.75f;

	private float _aggroDuration = 30f;

	private float _aggroTimer;

	private float awakenThresholdHP;

	private float enragedThresholdHP;

	private Colossus_Mode_Types Colossus_Mode;

	private Vector2 _chargeStartingPosition;

	private Vector2 _chargeEndingLocation;

	private Camera _mainCamera;

	private float _cameraOrthographicSizeX;

	private float _cameraOrthographicSizeY;

	private float chargeMechanicInterval = 2000f;

	private float chargeActivationDelay = 1000f;

	private float chargeActiveDuration = 750f;

	private Timer _chargerMechanicTimer;

	private Timer _chargeDelayTimer;

	private Timer _chargeFinishTimer;

	private float chargeSpeedModifier = 10f;

	private Vector2 chargeDirection;

	private SpriteTrail trail;

	private float flashRepeatingInterval = 250f;

	private Timer _warningFlashTimer;

	private bool _toggleWarningColour;

	private PhaserSprite _exclamationMark;

	private MultiTargetTween _warningTween;

	private List<Sprite> _asleepSprites;

	private List<Sprite> _mainSprites;

	private CoherenceSync _sync;

	public bool IsLeavingMap
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = Colossus_Mode - 7;
			return obj == null;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		CoherenceSync component = GetComponent<CoherenceSync>();
		_sync = component;
		Camera main = Camera.main;
		_mainCamera = main;
		float cameraOrthographicSizeX = (float)CameraExtensions.OrthographicBounds(_mainCamera).m_Extents * 2f;
		_cameraOrthographicSizeX = cameraOrthographicSizeX;
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v9 (UnityEngine.Bounds)+10]");
		float cameraOrthographicSizeY = 0f * 2f;
		_cameraOrthographicSizeY = cameraOrthographicSizeY;
		int zeroPad = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("EX_17COLOSSUS_ASLEEP_i0", 1, 1, "enemies2025", zeroPad);
		_asleepSprites = animationFrames;
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("EX_17COLOSSUS_i0", 1, 8, "enemies2025", zeroPad);
		_mainSprites = animationFrames2;
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote = false)
	{
		//IL_0119: Expected I4, but got O
		//IL_0149: Expected I, but got O
		//IL_0166: Expected O, but got I
		//IL_01e6: Expected O, but got I4
		//IL_01a2: Expected O, but got I
		//IL_01f8: Expected I4, but got O
		//IL_01d8: Expected O, but got I4
		((EnemyControllerBoss)this).InitEnemy(enemyType, asRemote);
		CreateBlackEmitter();
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		Colossus_Mode = Colossus_Mode_Types.SETUP;
		SetupLocationOfInterest();
		bool shouldLoop = default(bool);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_SpriteAnimation.AddAnimation("Asleep", _asleepSprites, 1, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
		_SpriteAnimation.AddAnimation("Moving", _mainSprites, 8, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
		Colossus_Mode = Colossus_Mode_Types.ASLEEP;
		_SpriteAnimation.SetAnimation("Asleep");
		trail.enabled = false;
		float num = awakenThresholdPercentage * _maxHp;
		BaseBody baseBody = body;
		float num2 = enragedThresholdPercentage * _maxHp;
		awakenThresholdHP = num;
		enragedThresholdHP = num2;
		baseBody._immovable = true;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		Colossus_Mode_Types colossus_Mode_Types = (Colossus_Mode_Types)stage._fancyBg;
		if ((object)stage._fancyBg == null)
		{
			return;
		}
		nint num3 = (nint)typeof(BackgroundMazerella);
		int value__ = ((Colossus_Mode_Types*)(int)colossus_Mode_Types)->value__;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundMazerella>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r9_v6 (System.Int32)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundMazerella>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r9_v6 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v22+FFFFFFF8+v250 @ rax_v14*8]");
			if (0 == (nint)typeof(BackgroundMazerella))
			{
				obj3 = 1;
				goto IL_023a;
			}
		}
		obj3 = 0;
		goto IL_023a;
		IL_023a:
		bool flag = obj3 == null;
		Colossus_Mode_Types colossus_Mode_Types2 = Colossus_Mode_Types.SETUP;
		if (!flag)
		{
			colossus_Mode_Types2 = (Colossus_Mode_Types)stage._fancyBg;
		}
		if (colossus_Mode_Types2 == Colossus_Mode_Types.SETUP)
		{
		}
	}

	private unsafe void SetupLocationOfInterest()
	{
		//IL_00ff->IL018b: Incompatible stack heights: 1 vs 0
		//IL_0148->IL018b: Incompatible stack heights: 1 vs 0
		//IL_017c->IL018b: Incompatible stack heights: 1 vs 0
		//IL_020a->IL01be: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null && (object)stage._tilingTileset != null)
			{
				List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("ColossusTarget");
				if (scriptsFromName == null || scriptsFromName._size <= 0)
				{
					return;
				}
				bool flag = scriptsFromName._size <= 0;
				SuperObject[] items = scriptsFromName._items;
				if (scriptsFromName._items != null)
				{
					if (items.Length <= 0)
					{
						throw new IndexOutOfRangeException();
					}
					if ((object)items[0] != null)
					{
						Transform transform = items[0].transform;
						if ((object)transform != null)
						{
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector2 ret;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
							_roamingTargetPosition = ret;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		//IL_02dd: Expected O, but got I4
		//IL_0141: Expected O, but got I4
		//IL_025f: Expected O, but got I8
		//IL_0279: Expected O, but got I8
		//IL_032b: Expected F4, but got I
		//IL_0346: Invalid comparison between F4 and I
		//IL_0358->IL0229: Incompatible stack heights: 1 vs 0
		//IL_0229->IL0229: Incompatible stack heights: 1 vs 0
		if (((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		base.UpdateDepth();
		if (((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField)
		{
			return;
		}
		if (Colossus_Mode == Colossus_Mode_Types.ASLEEP)
		{
			float num = awakenThresholdHP;
			if (!(awakenThresholdHP > _hp))
			{
				return;
			}
			Action action = SetRoaming;
			bool flag = _sync.SendCommand(action, MessageTarget.All);
			bool flag2 = false;
		}
		OnUpdate();
		base.UpdateSpawnDamageZones();
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			base.UpdateDepth();
			if (!((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField)
			{
				UpdateTileDestructionList();
			}
		}
		bool flag3 = Colossus_Mode != Colossus_Mode_Types.ROAMING;
		Action<float> action2 = (Action<float>)1;
		if (!flag3)
		{
			float num = enragedThresholdHP;
			bool flag4 = !(enragedThresholdHP > _hp);
			action2 = (Action<float>)1;
			if (!flag4)
			{
				Colossus_Mode = Colossus_Mode_Types.ENRAGED;
				Action onComplete = PositioningBehaviour;
				float num2 = chargeMechanicInterval * 0.001f;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer chargerMechanicTimer = Timers.Register(num2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_chargerMechanicTimer = chargerMechanicTimer;
				bool flag2 = false;
				action2 = null;
				num = num2;
			}
		}
		if (Colossus_Mode == Colossus_Mode_Types.POSITIONING)
		{
			Transform transform = base.transform;
			bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EX_Boss_Colossus)+44C]");
			float num = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EX_Boss_Colossus)+44C]");
			if (0.1f > 0f)
			{
				Colossus_Mode = Colossus_Mode_Types.WINDUP;
				WindUpBehaviour();
			}
		}
		Colossus_Mode_Types colossus_Mode = Colossus_Mode;
		if (Colossus_Mode <= Colossus_Mode_Types.LEAVING_MAP)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rdx_v18+768708C+v228 @ rax_v22 (VampireSurvivors.Objects.Characters.EX_Boss_Colossus+Colossus_Mode_Types)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v231 @ rcx_v25 (should have been resolved before IL gen)");
		}
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
		throw ex;
	}

	public void SetRoaming()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5FD7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Colossus_Mode = Colossus_Mode_Types.ROAMING;
		_SpriteAnimation.SetAnimation("Moving");
	}

	public void SetLeavingMap()
	{
		Colossus_Mode = Colossus_Mode_Types.LEAVING_MAP;
	}

	public override void OnGetDamaged(HitVfxType showHitVfx, bool hasKb = true)
	{
		PlayVFXFlash(showHitVfx);
		_receivingDamage = hasKb;
		_aggroTimer = 0f;
	}

	protected override void UpdateTileDestructionList()
	{
		if (Colossus_Mode != Colossus_Mode_Types.SETUP)
		{
			base.UpdateTileDestructionList();
		}
	}

	private bool CheckHasReachedBottomOfMap()
	{
		//IL_0064: Invalid comparison between F4 and I
		//IL_008b: Invalid comparison between F4 and I4
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EX_Boss_Colossus)+424]");
		bool flag2 = 0.1f < 0f;
		float num = 0.1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EX_Boss_Colossus)+424]");
		float num2 = num - 0f;
		bool flag3 = num2 == 0f;
		bool flag4 = !flag2;
		bool flag5 = !flag3;
		return flag5 & flag4;
	}

	private void ChargingMovementBehaviour()
	{
		//IL_0012: Expected O, but got F4
		float num = GameManager.EnemySpeed * ((EnemyController)this)._003CSpeed_003Ek__BackingField;
		float num2 = num * chargeSpeedModifier;
		float num3 = num2 / 100f;
		float num4 = (float)chargeDirection * num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EX_Boss_Colossus)+498]");
		float num5 = 0f * num3;
		BaseBody baseBody = body;
		baseBody._velocity = (float2)num4;
	}

	private unsafe void StandardMovementBehaviour(Vector2 targetPosition, float speedModification = 1f)
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0057: Expected O, but got F4
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdi_v1 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
		Vector2 currentDirection = (Vector2)((object)targetPosition - (object)ret);
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		Vector2 vector = (Vector2)(this + 480);
		_currentDirection = currentDirection;
		((Vector2*)vector)->Normalize();
		float num2;
		if (_receivingDamage)
		{
			float num = ((EnemyController)this)._003CKnockBack_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj4 = num ^ 0;
			num2 = (float)obj4 * _damageKb;
		}
		else
		{
			num2 = 1f;
		}
		float num3 = GameManager.EnemySpeed * ((EnemyController)this)._003CSpeed_003Ek__BackingField;
		float num4 = num3 / 100f;
		float num5 = num4 * num2;
		float num6 = num5 * ((EnemyController)this)._003CSlow_003Ek__BackingField;
		float num7 = num6 * speedModification;
		float num8 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EX_Boss_Colossus)+1E4]");
		float num9 = num8 * 0f;
		float num10 = num7 * (float)_currentDirection;
		BaseBody baseBody = body;
		baseBody._velocity = (float2)num10;
	}

	private void PositioningBehaviour()
	{
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected F4, but got Unknown
		//IL_01b9: Expected O, but got I4
		//IL_01d1: Expected O, but got I4
		//IL_01da: Expected O, but got I4
		//IL_00e4->IL0089: Incompatible stack heights: 1 vs 0
		RetargetIfNecessary();
		Transform targetTransform = ((EnemyController)this)._targetTransform;
		if ((object)((EnemyController)this)._targetTransform != null)
		{
			bool flag = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
			Transform enemyRenderer = (Transform)(object)_EnemyRenderer;
			if ((object)_EnemyRenderer != null)
			{
				bool flag2 = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
				Renderer.get_bounds_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, out Bounds _);
				object obj = default(object);
				float num = (float)obj * 2f;
				float num2 = _cameraOrthographicSizeX * 0.3f;
				float num3 = num * 0.5f;
				float num4 = num2 - num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float minInclusive = num4 ^ 0;
				float num5 = UnityEngine.Random.Range(minInclusive, num4);
				float num6 = _cameraOrthographicSizeY * 0.5f;
				float num7 = num5 + (float)ret;
				object obj2 = UnityEngine.Random.RandomRangeInt(0, 1);
				bool flag3 = obj2 == null;
				object obj3 = 1104;
				object obj4 = 1096;
				object obj5 = default(object);
				if (!flag3)
				{
					float num8 = (float)obj5 - num6;
					float num9 = (float)obj5 + num6;
				}
				else
				{
					float num8 = (float)obj5 + num6;
					float num9 = (float)obj5 - num6;
				}
				Colossus_Mode = Colossus_Mode_Types.POSITIONING;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void WindUpBehaviour()
	{
		//IL_025b: Expected O, but got I4
		//IL_02a1: Expected F4, but got I4
		//IL_02b2: Expected O, but got I4
		//IL_02bb: Expected O, but got I4
		//IL_0172: Expected O, but got I4
		//IL_017f: Expected F4, but got I4
		//IL_0190: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		//IL_05a1->IL040f: Incompatible stack heights: 1 vs 0
		//IL_04ed->IL040f: Incompatible stack heights: 1 vs 0
		//IL_05f6->IL040f: Incompatible stack heights: 2 vs 0
		//IL_020b->IL040f: Incompatible stack heights: 2 vs 0
		//IL_0243->IL040f: Incompatible stack heights: 2 vs 0
		//IL_0542->IL040f: Incompatible stack heights: 2 vs 0
		//IL_0277->IL040f: Incompatible stack heights: 2 vs 0
		//IL_012f->IL040f: Incompatible stack heights: 2 vs 0
		//IL_0158->IL040f: Incompatible stack heights: 2 vs 0
		//IL_02f7->IL040f: Incompatible stack heights: 2 vs 0
		//IL_0323->IL040f: Incompatible stack heights: 2 vs 0
		//IL_0392->IL040f: Incompatible stack heights: 2 vs 0
		//IL_0370->IL0370: Incompatible stack heights: 3 vs 2
		Action onComplete = ChargeAtPlayer;
		float duration = chargeActivationDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer chargeDelayTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_chargeDelayTimer = chargeDelayTimer;
		Action onComplete2 = ToggleWarningTint;
		float duration2 = flashRepeatingInterval * 0.001f;
		Timer warningFlashTimer = Timers.Register(duration2, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_warningFlashTimer = warningFlashTimer;
		PhaserSprite exclamationMark = _exclamationMark;
		bool num;
		Vector3 ret;
		bool num2;
		Vector3 ret2;
		Vector2 vector3 = default(Vector2);
		if ((object)_exclamationMark != null && ((UnityEngine.Object)exclamationMark).m_CachedPtr != (IntPtr)0)
		{
			object cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rdi_v19 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				num = flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rdi_v19 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				object cachedTransform2 = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rdi_v20 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					num2 = flag2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rdi_v20 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret2);
					if ((object)_EnemyRenderer != null)
					{
						Vector2 vector = _EnemyRenderer.size;
						object obj2 = default(object);
						object obj3 = default(object);
						object obj = obj2 + obj3;
						if ((object)_exclamationMark != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
							if ((object)_exclamationMark != null)
							{
								PhaserSprite phaserSprite = _exclamationMark.setScale(0f, (float?)(object)0);
								float num3 = 0f;
								Vector2 vector2 = vector3;
								object obj4 = 0;
								float? num4 = (float?)(object)0;
								goto IL_02c0;
							}
						}
					}
				}
			}
		}
		else
		{
			PhaserWorld instance = PhaserWorld.Instance;
			object cachedTransform3 = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdi_v17 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				num = flag3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdi_v17 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret2);
				object cachedTransform4 = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rdi_v18 (System.Object)+10]");
					bool flag4 = (nint)0 == 0;
					num2 = flag4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rdi_v18 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					if ((object)_EnemyRenderer != null)
					{
						Vector2 vector4 = _EnemyRenderer.size;
						if ((object)instance != null)
						{
							PhaserSprite phaserSprite2 = instance.AddPhaserSprite(vector3, "UI", "ExclamationMark");
							if ((object)phaserSprite2 != null)
							{
								PhaserSprite phaserSprite3 = phaserSprite2.setScale(0f, (float?)(object)0);
								if ((object)phaserSprite3 != null)
								{
									PhaserSprite exclamationMark2 = phaserSprite3.setDepth(9000);
									_exclamationMark = exclamationMark2;
									float num3 = 0f;
									Vector2 vector2 = vector3;
									object obj4 = 0;
									float? num4 = (float?)(object)0;
									goto IL_02c0;
								}
							}
						}
					}
				}
			}
		}
		goto IL_040f;
		IL_040f:
		throw new NullReferenceException();
		IL_02c0:
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_exclamationMark != null)
		{
			Transform transform = _exclamationMark.transform;
			if (array != null)
			{
				if ((object)transform != null)
				{
					object obj5 = array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj6 = default(object);
					bool flag5 = obj6 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					_ = 1128792064;
					_ = 1;
					TweenCallback tweenCallback = delegate
					{
						PhaserSprite phaserSprite4 = _exclamationMark.setVisible(visible: true);
					};
					TweenCallback tweenCallback2 = delegate
					{
						//IL_003e: Expected I, but got O
						//IL_00b0: Expected O, but got I4
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						Transform transform2 = _exclamationMark.transform;
						if ((object)transform2 != null)
						{
							nint num5 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj7 = default(object);
							if (obj7 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						tweenConfig2.targets = array2;
						tweenConfig2.duration = 200f;
						tweenConfig2.delay = 200f;
						tweenConfig2.scale = (float?)(object)1;
						TweenCallback onComplete3 = delegate
						{
							PhaserSprite phaserSprite4 = _exclamationMark.setVisible(visible: false);
						};
						tweenConfig2.onComplete = onComplete3;
						MultiTargetTween warningTween2 = Tweens.Add(tweenConfig2);
						_warningTween = warningTween2;
					};
					MultiTargetTween warningTween = Tweens.Add(tweenConfig);
					_warningTween = warningTween;
					return;
				}
			}
		}
		goto IL_040f;
	}

	private unsafe void ChargeAtPlayer()
	{
		//IL_0033: Expected O, but got Ref
		//IL_019f: Expected O, but got I
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected O, but got Unknown
		if (_warningFlashTimer != null)
		{
			_warningFlashTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,0Ch\"");
		Vector3 ret = default(Vector3);
		RenderingExtensions.SetTint(_EnemyRenderer, (Color?)(object)(&ret));
		if ((object)trail != null)
		{
			trail.Reset();
			if ((object)trail != null)
			{
				trail.enabled = true;
				SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out ret);
					Vector2 vector = (Vector2)((object)_chargeEndingLocation - (object)ret);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EX_Boss_Colossus)+454]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					object obj = num - 0;
					Vector2 vector2 = (Vector2)(this + 1172);
					chargeDirection = vector;
					((Vector2*)vector2)->Normalize();
					Action onComplete = RestartMovement;
					float duration = chargeActiveDuration * 0.001f;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer chargeFinishTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_chargeFinishTimer = chargeFinishTimer;
					Colossus_Mode = Colossus_Mode_Types.CHARGING;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void RestartMovement()
	{
		Colossus_Mode = Colossus_Mode_Types.ENRAGED;
		Action onComplete = PositioningBehaviour;
		float duration = chargeMechanicInterval * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer chargerMechanicTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_chargerMechanicTimer = chargerMechanicTimer;
		trail.Reset();
		trail.enabled = false;
	}

	private unsafe void ToggleWarningTint()
	{
		//IL_0019: Expected O, but got Ref
		if (_toggleWarningColour)
		{
		}
		object obj = default(object);
		RenderingExtensions.SetTint(_EnemyRenderer, (Color?)(object)(&obj));
		bool toggleWarningColour = !_toggleWarningColour;
		_toggleWarningColour = toggleWarningColour;
	}

	private Vector2 AdjustedMarkPositionY(float x, float y)
	{
		if ((object)_EnemyRenderer != null)
		{
			Vector2 vector = _EnemyRenderer.size;
			Vector2 result = default(Vector2);
			return result;
		}
		return (Vector2)new NullReferenceException();
	}

	public override void Despawn()
	{
		base.Despawn();
		if ((object)_exclamationMark != null)
		{
			PhaserSprite phaserSprite = _exclamationMark.setVisible(visible: false);
		}
		if (_chargerMechanicTimer != null)
		{
			_chargerMechanicTimer.Cancel();
		}
		if (_chargeDelayTimer != null)
		{
			_chargeDelayTimer.Cancel();
		}
		if (_chargeFinishTimer != null)
		{
			_chargeFinishTimer.Cancel();
		}
		if (_warningFlashTimer != null)
		{
			_warningFlashTimer.Cancel();
		}
		if (_warningTween != null)
		{
			_warningTween.Kill();
		}
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		}
		PhaserSprite exclamationMark = _exclamationMark;
		if ((object)_exclamationMark != null && ((UnityEngine.Object)exclamationMark).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj = _exclamationMark.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
			_exclamationMark = null;
		}
	}

	public EX_Boss_Colossus()
	{
		List<int2> tilesToEat = new List<int2>();
		base._tilesToEat = tilesToEat;
		base._currentTilesBeingEaten = new List<int2>();
		((EnemyControllerBoss)this)._002Ector();
	}

	private void _003CWindUpBehaviour_003Eb__48_0()
	{
		PhaserSprite phaserSprite = _exclamationMark.setVisible(visible: true);
	}

	private void _003CWindUpBehaviour_003Eb__48_1()
	{
		//IL_003e: Expected I, but got O
		//IL_00b0: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = _exclamationMark.transform;
		if ((object)transform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.delay = 200f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _exclamationMark.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween warningTween = Tweens.Add(tweenConfig);
		_warningTween = warningTween;
	}

	private void _003CWindUpBehaviour_003Eb__48_2()
	{
		PhaserSprite phaserSprite = _exclamationMark.setVisible(visible: false);
	}
}
