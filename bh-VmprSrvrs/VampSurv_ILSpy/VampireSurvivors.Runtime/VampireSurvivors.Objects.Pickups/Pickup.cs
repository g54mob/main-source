using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects.Pickups;

public class Pickup : BasePoolableSpriteBehaviour, IDamageable
{
	protected SignalBus _signalBus;

	protected PlayerOptions _playerOptions;

	protected DataManager _dataManager;

	protected GameSessionData _gameSessionData;

	protected GameManager _gameManager;

	protected SpriteRenderer _itemRenderer;

	public SpriteAnimation _spriteAnimation;

	protected Camera _mainCamera;

	private Vector2 _currentDirection;

	private const float Radius = 10f;

	private const float DefaultSpeed = 250f;

	public VampireSurvivors.Objects.Characters.CharacterController _targetPlayer;

	private static int _fps = 60;

	private static double _frameTime;

	private double _frameTimeMS;

	private double _elapsed;

	protected string _frameName;

	protected string _textureName;

	public bool _ShowAboveAll;

	protected bool _doOnlineDespawn;

	public bool HasMapTokenData;

	public string MapTokenFrameName;

	public string MapTokenTexture;

	private bool _003CIsStagePickup_003Ek__BackingField;

	private string _003CSpriteName_003Ek__BackingField;

	private ItemType _003CPickupType_003Ek__BackingField;

	private float _003CValue_003Ek__BackingField;

	private float _003CResRosary_003Ek__BackingField;

	public float Time;

	private float? _003CLoopedSpawnX_003Ek__BackingField;

	private MultiTargetTween _vacuumTween;

	private float _003CSpeed_003Ek__BackingField;

	private float _003CFeverMS_003Ek__BackingField;

	private bool _goToPlayer;

	private bool _disableDespawn;

	public bool IsInLavatrix;

	protected Tween lavatrixTween;

	private bool _003CIgnoreMadGroove_003Ek__BackingField;

	private bool _003CDisableGet_003Ek__BackingField;

	private Action<Pickup> _003CPickupCallback_003Ek__BackingField;

	private bool _003CIsStationary_003Ek__BackingField;

	private bool _003CIgnoreForcedMovement_003Ek__BackingField;

	private bool _003CDespawnInteadOfResetPosition_003Ek__BackingField;

	private bool _003CAutoSafeXY_003Ek__BackingField;

	public int SyncedPickupType
	{
		get
		{
			return (int)_003CPickupType_003Ek__BackingField;
		}
		set
		{
			_003CPickupType_003Ek__BackingField = (ItemType)value;
		}
	}

	public bool IsStagePickup
	{
		get
		{
			return _003CIsStagePickup_003Ek__BackingField;
		}
		set
		{
			_003CIsStagePickup_003Ek__BackingField = value;
		}
	}

	public string SpriteName
	{
		get
		{
			return _003CSpriteName_003Ek__BackingField;
		}
		set
		{
			_003CSpriteName_003Ek__BackingField = value;
		}
	}

	public ItemType PickupType
	{
		get
		{
			return _003CPickupType_003Ek__BackingField;
		}
		protected set
		{
			_003CPickupType_003Ek__BackingField = value;
		}
	}

	public float Value
	{
		get
		{
			return _003CValue_003Ek__BackingField;
		}
		set
		{
			_003CValue_003Ek__BackingField = value;
		}
	}

	public float ResRosary
	{
		get
		{
			return _003CResRosary_003Ek__BackingField;
		}
		set
		{
			_003CResRosary_003Ek__BackingField = value;
		}
	}

	public float? LoopedSpawnX
	{
		get
		{
			return _003CLoopedSpawnX_003Ek__BackingField;
		}
		set
		{
			_003CLoopedSpawnX_003Ek__BackingField = value;
		}
	}

	public float Speed
	{
		get
		{
			return _003CSpeed_003Ek__BackingField;
		}
		set
		{
			_003CSpeed_003Ek__BackingField = value;
		}
	}

	public float FeverMS
	{
		get
		{
			return _003CFeverMS_003Ek__BackingField;
		}
		set
		{
			_003CFeverMS_003Ek__BackingField = value;
		}
	}

	public bool GoToPlayer
	{
		get
		{
			return _goToPlayer;
		}
		set
		{
			_goToPlayer = value;
			if (value)
			{
				PhysicsManager sInstance = PhysicsManager._sInstance;
				Group obj = sInstance._goToPlayerPickupGroup.add(this);
				PhysicsManager sInstance2 = PhysicsManager._sInstance;
				sInstance2._pickupGroup.remove(this);
			}
		}
	}

	public bool IgnoreMadGroove
	{
		get
		{
			return _003CIgnoreMadGroove_003Ek__BackingField;
		}
		set
		{
			_003CIgnoreMadGroove_003Ek__BackingField = value;
		}
	}

	public bool DisableGet
	{
		get
		{
			return _003CDisableGet_003Ek__BackingField;
		}
		set
		{
			_003CDisableGet_003Ek__BackingField = value;
		}
	}

	public Action<Pickup> PickupCallback
	{
		get
		{
			return _003CPickupCallback_003Ek__BackingField;
		}
		set
		{
			_003CPickupCallback_003Ek__BackingField = value;
		}
	}

	public int Depth
	{
		get
		{
			SpriteRenderer itemRenderer = _itemRenderer;
			bool flag = ((UnityEngine.Object)itemRenderer).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
	}

	public bool IsStationary
	{
		get
		{
			return _003CIsStationary_003Ek__BackingField;
		}
		set
		{
			_003CIsStationary_003Ek__BackingField = value;
		}
	}

	public bool IgnoreForcedMovement
	{
		get
		{
			return _003CIgnoreForcedMovement_003Ek__BackingField;
		}
		set
		{
			_003CIgnoreForcedMovement_003Ek__BackingField = value;
		}
	}

	public bool DespawnInteadOfResetPosition
	{
		get
		{
			return _003CDespawnInteadOfResetPosition_003Ek__BackingField;
		}
		set
		{
			_003CDespawnInteadOfResetPosition_003Ek__BackingField = value;
		}
	}

	public bool AutoSafeXY
	{
		get
		{
			return _003CAutoSafeXY_003Ek__BackingField;
		}
		set
		{
			_003CAutoSafeXY_003Ek__BackingField = value;
		}
	}

	public VampireSurvivors.Objects.Characters.CharacterController TargetPlayer
	{
		get
		{
			return _targetPlayer;
		}
		set
		{
			_targetPlayer = value;
		}
	}

	public bool DoOnlineDespawn => _doOnlineDespawn;

	public virtual void StopFloat()
	{
	}

	public virtual bool CanCharacterCollectPickup(CharacterType characterType)
	{
		return true;
	}

	private void Construct(SignalBus signalBus, PlayerOptions playerOptions, DataManager dataManager, GameSessionData gameSessionData, GameManager gameManager)
	{
		_signalBus = signalBus;
		_playerOptions = playerOptions;
		_dataManager = dataManager;
		GameSessionData gameSessionData2 = default(GameSessionData);
		_gameSessionData = gameSessionData2;
		GameManager gameManager2 = default(GameManager);
		_gameManager = gameManager2;
	}

	protected virtual void Awake()
	{
		Camera main = Camera.main;
		_mainCamera = main;
		InitRenderer();
	}

	protected virtual void Start()
	{
		//IL_0113: Expected I, but got O
		//IL_0085: Expected O, but got I4
		//IL_0085: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0147: Expected O, but got I
		Action<UISignals.ToggleGuidesSignal> action = null;
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003DC0");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ToggleGuidesSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.ToggleGuidesSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v12 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
		if ((object)_targetPlayer == null || ((UnityEngine.Object)targetPlayer).m_CachedPtr == (IntPtr)0)
		{
			GameSessionData gameSessionData = _gameSessionData;
			_targetPlayer = gameSessionData._activeCharacter;
		}
	}

	protected override void OnDestroy()
	{
		//IL_0073: Expected I, but got O
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Action<UISignals.ToggleGuidesSignal> token = null;
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003DC0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._gameObject = null;
		}
	}

	public virtual void SetData(ItemType itemType)
	{
		//IL_00f9: Expected O, but got I
		//IL_0127: Expected O, but got I
		//IL_0139: Expected F4, but got I
		//IL_014b: Expected F4, but got I
		//IL_0183: Expected O, but got I4
		//IL_01a7: Expected O, but got I4
		//IL_01a7: Expected O, but got I4
		//IL_0110: Expected O, but got I
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		Factory add = physics.add;
		PhaserGameObject phaserGameObject = add._world.enableBody(this);
		PhysicsManager sInstance = PhysicsManager._sInstance;
		Group obj = sInstance._pickupGroup.add(this);
		DataManager dataManager = _dataManager;
		_003CSpeed_003Ek__BackingField = 250f;
		IsInLavatrix = false;
		_003CPickupType_003Ek__BackingField = itemType;
		int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).FindEntry((System.Int32Enum)itemType);
		if (num >= 0)
		{
			DataManager dataManager2 = _dataManager;
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)_003CPickupType_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v19 (System.Object)+38]");
			_frameName = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v19 (System.Object)+30]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v19 (System.Object)+30]");
				_textureName = (string)0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v19 (System.Object)+38]");
			SetFrame((string)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v19 (System.Object)+4C]");
			_003CValue_003Ek__BackingField = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v19 (System.Object)+58]");
			_003CFeverMS_003Ek__BackingField = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v19 (System.Object)+80]");
			_ShowAboveAll = false;
			_goToPlayer = false;
			_003CResRosary_003Ek__BackingField = 0f;
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			BaseBody baseBody = body.setCircle(10f, (float?)(object)0, (float?)(object)0);
			ArcadeSprite arcadeSprite2 = setVisible(visible: true);
			GameManager core = GM.Core;
			Stage stage = core._stage;
			BackgroundManager fancyBg = stage._fancyBg;
			if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
			{
				GameManager core2 = GM.Core;
				Stage stage2 = core2._stage;
				stage2._fancyBg.InitPickupForLoopingStage(this);
			}
			_003CAutoSafeXY_003Ek__BackingField = false;
		}
	}

	public virtual void InternalUpdate()
	{
		//IL_01f5: Expected I, but got O
		//IL_0205: Expected O, but got I
		//IL_012a: Expected O, but got I
		//IL_00e9: Expected O, but got I4
		//IL_014f: Expected O, but got I
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+350]");
		object obj = 0;
		UpdateDepth();
		float deltaTime = PauseSystem.DeltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [188A109F8h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		_elapsed = 0.0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4E0E]");
		if ((nint)0 > (nint)0)
		{
			return;
		}
		bool flag = !_goToPlayer;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,xmm0\"");
		_elapsed = 0.0;
		if (!flag && !_003CIsStationary_003Ek__BackingField)
		{
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			if ((object)_targetPlayer != null && ((UnityEngine.Object)targetPlayer).m_CachedPtr != (IntPtr)0)
			{
				VampireSurvivors.Objects.Characters.CharacterController targetPlayer2 = _targetPlayer;
				if (!targetPlayer2._isDead)
				{
					bool isDisconnectedFromOnlinePlay = targetPlayer2.IsDisconnectedFromOnlinePlay;
					obj = 0;
					if (!isDisconnectedFromOnlinePlay)
					{
						GoToThePlayer();
						return;
					}
				}
				_goToPlayer = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ rax_v21+30]");
				Group obj2 = ((Group)0).add(this);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rax_v23+38]");
				((Group)0).remove(this);
				return;
			}
		}
		if (!_003CAutoSafeXY_003Ek__BackingField)
		{
			return;
		}
		float2 float5 = SafeXYWrapped();
		float2 float6 = base.cachedPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187322B13h\"");
		if ((object)float5 == (object)float6)
		{
			float2 float7 = base.cachedPosition;
			object obj3 = default(object);
			bool flag2 = obj3 == obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187322B13h\"");
			if (flag2)
			{
				return;
			}
		}
		float2 float8 = default(float2);
		base.position = float8;
	}

	public virtual void UpdateDepth()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		if (_ShowAboveAll)
		{
			num = 1990;
		}
		ArcadeSprite arcadeSprite = setDepth(num);
	}

	public virtual bool Vacuum(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0212: Expected I4, but got O
		//IL_00b2: Expected I, but got O
		if (!_goToPlayer && !_003CIsStationary_003Ek__BackingField)
		{
			_targetPlayer = player;
			Time = -1f;
			if (_vacuumTween != null)
			{
				_vacuumTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					if (dictionary != null)
					{
						object value = default(object);
						bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"Time", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						tweenConfig.custom = dictionary;
						tweenConfig.duration = 500f;
						tweenConfig.ease = Ease.Linear;
						MultiTargetTween vacuumTween = Tweens.Add(tweenConfig);
						_vacuumTween = vacuumTween;
						GoToPlayer = true;
						return true;
					}
				}
			}
			NullReferenceException ex2 = new NullReferenceException();
			return (byte)(int)ex2 != 0;
		}
		return false;
	}

	public virtual void Despawn()
	{
		if (lavatrixTween != null)
		{
			TweenExtensions.Kill(lavatrixTween);
		}
		RemovePhysics();
		GameObject gameObject = base.gameObject;
		if (gameObject.TryGetComponent<CoherenceSync>(out var component))
		{
			GameManager core = GM.Core;
			if (core._multiplayer.IsOnlineMultiplayer && (nint)component._003CEntityState_003Ek__BackingField > 0 && _doOnlineDespawn)
			{
				return;
			}
		}
		PickupManager.ReturnPickup(this);
	}

	public void SetFrame(string spriteName)
	{
		if (spriteName != null && spriteName._stringLength > 0)
		{
			Sprite sprite = SpriteManager.GetSprite(spriteName, _textureName);
			ArcadeSprite arcadeSprite = setFrame(sprite);
			_003CSpriteName_003Ek__BackingField = spriteName;
		}
	}

	public virtual void GetTaken()
	{
		if (!_003CDisableGet_003Ek__BackingField && !_disableDespawn)
		{
			PhysicsManager sInstance = PhysicsManager._sInstance;
			sInstance._pickupGroup.remove(this);
			PhysicsManager sInstance2 = PhysicsManager._sInstance;
			sInstance2._goToPlayerPickupGroup.remove(this);
			_targetPlayer.OnPickupCollected(this);
			_doOnlineDespawn = true;
			Despawn();
			TrackItemPickup();
			Action<Pickup> action = _003CPickupCallback_003Ek__BackingField;
			if (_003CPickupCallback_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v37 @ rax_v18 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public void ForceDisableDespawn()
	{
		_disableDespawn = true;
	}

	public virtual void DisposeAsTaken()
	{
		PhysicsManager sInstance = PhysicsManager._sInstance;
		sInstance._pickupGroup.remove(this);
		Transform transform = base.transform;
		GameObject gameObject = transform.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
		Despawn();
	}

	public void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
	}

	public void OnGetDamaged(HitVfxType hitVfxType, bool hasKb = true)
	{
	}

	public bool IsUnitDead()
	{
		return false;
	}

	public float MaxHp()
	{
		return 100f;
	}

	public float CurrentHealth()
	{
		return 100f;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public unsafe void GoToLowestHealthPlayer()
	{
		//IL_0262: Expected I, but got O
		//IL_00a0: Expected I, but got O
		//IL_00ce: Expected O, but got I
		//IL_0103: Expected O, but got I
		//IL_0148: Expected O, but got Ref
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v4 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			int playerCount = core._multiplayer.GetPlayerCount();
			if (playerCount <= 1 && !core._multiplayer.IsOnlineMultiplayer)
			{
				goto IL_023c;
			}
			num2 = (nint)GM.Core;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v5 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v5 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+E0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rsi_v6+10]");
					VampireSurvivors.Objects.Characters.CharacterController targetPlayer = (VampireSurvivors.Objects.Characters.CharacterController)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v5 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+298]");
					if ((nint)0 != 0)
					{
						float num3 = 1f;
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
						if (enumerator.MoveNext())
						{
							VampireSurvivors.Objects.Characters.CharacterController characterController = null;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
							throw new NullReferenceException();
						}
						_targetPlayer = targetPlayer;
						goto IL_023c;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_023c:
		GoToPlayer = true;
	}

	protected void RemovePhysics()
	{
		//IL_0099: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		PhysicsManager sInstance = PhysicsManager._sInstance;
		sInstance._pickupGroup.remove(this);
		PhysicsManager sInstance2 = PhysicsManager._sInstance;
		sInstance2._goToPlayerPickupGroup.remove(this);
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
			BaseBody baseBody2 = body;
			baseBody2._velocity = (float2)0;
			body.destroy();
			body = null;
		}
		_003CLoopedSpawnX_003Ek__BackingField = (float?)(object)0;
		if (_vacuumTween != null)
		{
			_vacuumTween.Kill();
		}
	}

	protected void OnSpriteChanged(string oldSprite, string newSprite)
	{
		if (newSprite != null && newSprite._stringLength > 0)
		{
			SetFrame(newSprite);
		}
	}

	private void InitRenderer()
	{
		//IL_0150->IL00d8: Incompatible stack heights: 1 vs 0
		//IL_004e->IL00d8: Incompatible stack heights: 1 vs 0
		//IL_008a->IL00d8: Incompatible stack heights: 1 vs 0
		//IL_00b6->IL00d8: Incompatible stack heights: 1 vs 0
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			if ((object)this != null)
			{
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, pos, null, null);
				if ((object)spriteRenderer != null)
				{
					((UnityEngine.Object)spriteRenderer).SetName("Item");
					_itemRenderer = spriteRenderer;
					if ((object)_itemRenderer != null)
					{
						GameObject gameObject2 = _itemRenderer.gameObject;
						if ((object)gameObject2 != null)
						{
							SpriteAnimation spriteAnimation = gameObject2.AddComponent<SpriteAnimation>();
							_spriteAnimation = spriteAnimation;
							((ArcadeSprite)this)._spriteRenderer = _itemRenderer;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected void InitPhysics()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		Factory add = physics.add;
		PhaserGameObject phaserGameObject = add._world.enableBody(this);
		PhysicsManager sInstance = PhysicsManager._sInstance;
		Group obj = sInstance._pickupGroup.add(this);
	}

	protected virtual void SetHasSeenItem()
	{
		SetHasSeenItem(_003CPickupType_003Ek__BackingField);
	}

	protected virtual void SetHasSeenItem(ItemType itemType)
	{
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
		object obj = default(object);
		if (obj == null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
		}
	}

	protected virtual void AddToRunPickups()
	{
		//IL_004e: Expected O, but got I
		//IL_005e: Expected O, but got I
		//IL_00b5: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)config._003CRunPickups_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r9_v3+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)_003CPickupType_003Ek__BackingField);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj3 = (nint)0 + (nint)1;
		_ = _003CPickupType_003Ek__BackingField;
	}

	protected virtual void AddToRunPickups(ItemType itemType)
	{
		//IL_004e: Expected O, but got I
		//IL_00a3: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)config._003CRunPickups_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)itemType);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v5 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	protected float2 SafeXY()
	{
		//IL_0256: Expected I, but got O
		GameManager core = GM.Core;
		object obj;
		Vector2 vector = default(Vector2);
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				float2 playerPosition = gameSessionData._activeCharacter.position;
				float2 float5 = base.position;
				GameManager gameManager = _gameManager;
				if ((object)_gameManager != null)
				{
					Stage stage = gameManager._stage;
					if ((object)gameManager._stage != null)
					{
						BackgroundManager fancyBg = stage._fancyBg;
						bool flag = (object)stage._fancyBg == null;
						object obj2 = default(object);
						obj = obj2;
						if (!flag)
						{
							bool flag2 = ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0;
							obj = obj2;
							if (!flag2)
							{
								GameManager gameManager2 = _gameManager;
								if ((object)_gameManager != null)
								{
									Stage stage2 = gameManager2._stage;
									if ((object)gameManager2._stage != null && (object)stage2._fancyBg != null)
									{
										bool flag3 = stage2._fancyBg.HasExtraSafeXYLogic();
										bool flag4 = !flag3;
										obj = obj2;
										if (flag4)
										{
											goto IL_03b4;
										}
										GameManager gameManager3 = _gameManager;
										if ((object)_gameManager != null)
										{
											Stage stage3 = gameManager3._stage;
											if ((object)gameManager3._stage != null)
											{
												BackgroundManager fancyBg2 = stage3._fancyBg;
												if ((object)stage3._fancyBg != null)
												{
													nint num = (nint)fancyBg2;
													float2 float6 = stage3._fancyBg.ExtraSafeXY(vector, playerPosition);
													obj = obj2;
													goto IL_03b4;
												}
											}
										}
									}
								}
								goto IL_0350;
							}
						}
						goto IL_03b4;
					}
				}
			}
		}
		goto IL_0350;
		IL_03b4:
		GameManager gameManager4 = _gameManager;
		if ((object)_gameManager != null)
		{
			Stage stage4 = gameManager4._stage;
			if ((object)gameManager4._stage != null)
			{
				if (stage4._hasTileSet)
				{
					if ((object)stage4._tilingTileset == null)
					{
						goto IL_0350;
					}
					if (stage4._tilingTileset.IsPointWithinCollisionLayer(vector))
					{
						object obj4 = default(object);
						object obj3 = obj4 - obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
						return vector;
					}
				}
				return vector;
			}
		}
		goto IL_0350;
		IL_0350:
		return (float2)new NullReferenceException();
	}

	protected float2 SafeXYWrapped()
	{
		//IL_0256: Expected I, but got O
		GameManager core = GM.Core;
		object obj;
		Vector2 vector = default(Vector2);
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				float2 playerPosition = gameSessionData._activeCharacter.position;
				float2 float5 = base.position;
				GameManager gameManager = _gameManager;
				if ((object)_gameManager != null)
				{
					Stage stage = gameManager._stage;
					if ((object)gameManager._stage != null)
					{
						BackgroundManager fancyBg = stage._fancyBg;
						bool flag = (object)stage._fancyBg == null;
						object obj2 = default(object);
						obj = obj2;
						if (!flag)
						{
							bool flag2 = ((UnityEngine.Object)fancyBg).m_CachedPtr == (IntPtr)0;
							obj = obj2;
							if (!flag2)
							{
								GameManager gameManager2 = _gameManager;
								if ((object)_gameManager != null)
								{
									Stage stage2 = gameManager2._stage;
									if ((object)gameManager2._stage != null && (object)stage2._fancyBg != null)
									{
										bool flag3 = stage2._fancyBg.HasExtraSafeXYLogic();
										bool flag4 = !flag3;
										obj = obj2;
										if (flag4)
										{
											goto IL_03b4;
										}
										GameManager gameManager3 = _gameManager;
										if ((object)_gameManager != null)
										{
											Stage stage3 = gameManager3._stage;
											if ((object)gameManager3._stage != null)
											{
												BackgroundManager fancyBg2 = stage3._fancyBg;
												if ((object)stage3._fancyBg != null)
												{
													nint num = (nint)fancyBg2;
													float2 float6 = stage3._fancyBg.ExtraSafeXY(vector, playerPosition);
													obj = obj2;
													goto IL_03b4;
												}
											}
										}
									}
								}
								goto IL_0350;
							}
						}
						goto IL_03b4;
					}
				}
			}
		}
		goto IL_0350;
		IL_03b4:
		GameManager gameManager4 = _gameManager;
		if ((object)_gameManager != null)
		{
			Stage stage4 = gameManager4._stage;
			if ((object)gameManager4._stage != null)
			{
				if (stage4._hasTileSet)
				{
					if ((object)stage4._tilingTileset == null)
					{
						goto IL_0350;
					}
					if (stage4._tilingTileset.IsPointWithinCollisionLayerWrapped(vector))
					{
						object obj4 = default(object);
						object obj3 = obj4 - obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
						return vector;
					}
				}
				return vector;
			}
		}
		goto IL_0350;
		IL_0350:
		return (float2)new NullReferenceException();
	}

	protected unsafe virtual void GoToThePlayer()
	{
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_007b: Expected O, but got F4
		//IL_0184: Expected I, but got O
		//IL_0189: Expected I, but got O
		//IL_0199: Expected O, but got I
		//IL_01d5: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_0387->IL0275: Incompatible stack heights: 1 vs 0
		//IL_00b2->IL038c: Incompatible stack heights: 1 vs 0
		//IL_00d1->IL038c: Incompatible stack heights: 1 vs 0
		//IL_00fd->IL038c: Incompatible stack heights: 1 vs 0
		//IL_0124->IL0275: Incompatible stack heights: 1 vs 0
		//IL_0146->IL0275: Incompatible stack heights: 1 vs 0
		//IL_0232->IL0275: Incompatible stack heights: 1 vs 0
		//IL_026e->IL038c: Incompatible stack heights: 1 vs 0
		if (body == null)
		{
			return;
		}
		if ((object)_targetPlayer != null)
		{
			float2 float5 = _targetPlayer.position;
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Vector2 vector = (Vector2)(this + 160);
				object obj2 = default(object);
				object obj3 = default(object);
				object obj = obj2 - obj3;
				Vector2 currentDirection = (Vector2)((object)float5 - (object)ret);
				float num = (float)obj + 0.08f;
				_currentDirection = currentDirection;
				((Vector2*)vector)->Normalize();
				float num2 = _003CSpeed_003Ek__BackingField * 0.01f;
				float num3 = num2 * Time;
				float num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Pickups.Pickup)+A4]");
				float num5 = num4 * 0f;
				float num6 = num3 * (float)_currentDirection;
				BaseBody baseBody = body;
				if (body != null)
				{
					baseBody._velocity = (float2)num6;
					if (!(++_003CSpeed_003Ek__BackingField > 65536f) || body == null)
					{
						return;
					}
					BaseBody baseBody2 = body;
					if (!baseBody2._enable)
					{
						return;
					}
					GameManager core = GM.Core;
					if ((object)GM.Core != null && core._multiplayer != null)
					{
						if (core._multiplayer.IsOnlineMultiplayer)
						{
							nint num7 = (nint)typeof(NetworkPickup);
							nint num8 = (nint)this;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v13 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v13 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
							if (num9 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rax_v28+FFFFFFF8+v441 @ rax_v27*8]");
								if (0 == (nint)typeof(NetworkPickup))
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Pickups.Pickup)+148]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Pickups.Pickup)+148]");
									if ((nint)0 == 0)
									{
										goto IL_0275;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v29+160]");
									if ((nint)0 > (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v118 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+438] (should have been resolved before IL gen)");
										return;
									}
								}
							}
						}
						GetTaken();
						return;
					}
				}
			}
		}
		goto IL_0275;
		IL_0275:
		throw new NullReferenceException();
	}

	protected virtual void TrackItemPickup(bool trackRunPickup = true)
	{
		PlayerOptionsData config = _playerOptions.Config;
		_playerOptions.TrackItemPickup(_003CPickupType_003Ek__BackingField, config, trackRunPickup);
	}

	protected virtual void ToggleCursors(UISignals.ToggleGuidesSignal sig)
	{
	}

	public virtual void Bless(float value, HitVfxType hitVFXType = HitVfxType.Prism)
	{
		//IL_002f: Expected I4, but got I8
		float num = value + _003CValue_003Ek__BackingField;
		_003CValue_003Ek__BackingField = num;
		GameManager core = GM.Core;
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		RenderingExtensions.EmitParticleAt(core._pickupVfx, pos, -1);
	}

	public void GiveReward(Action<Pickup> onRewardGiven = null)
	{
	}

	public static Vector2 Spiral2D(Vector2 start, Vector2 center, float t, float turns = 2f, bool clockwise = true)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0117: Invalid comparison between I4 and F4
		object obj = start - center;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		object obj6 = default(object);
		object obj5 = obj6 - 96;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		object obj7 = default(object);
		float num = ((obj7 == null) ? 1f : (-1f));
		float num2 = num * turns;
		float num3 = num2 * (float)Math.PI;
		float num4 = num3 + num3;
		float num5 = num4 * t;
		float num6 = num5 + (float)obj2;
		if (0f > t || t > 1f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Vector2 result = default(Vector2);
		return result;
	}

	public Pickup()
	{
		//IL_0040: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A109F8h]\"");
		_frameTimeMS = _frameTime;
		_textureName = "items";
		_003CPickupType_003Ek__BackingField = ItemType.GEM;
		_003CSpeed_003Ek__BackingField = 250f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rcx_v5 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static Pickup()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,xmm0\"");
		_frameTime = 1.0;
	}
}
