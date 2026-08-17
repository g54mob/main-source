using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Items;

public class PickupTeleporter : PickupGuarded
{
	public int GateIndex;

	private bool _canTeleport = true;

	private bool _canTeleportLocally;

	private string _teleporterKey;

	private float _destinationX;

	private float _destinationY;

	private Tween _glowTween;

	private PickupTeleporter _link;

	protected PhaserSprite _door;

	protected bool _hasDoorAnimation = true;

	public float _triggerDelay = 10000f;

	private bool _teleporting;

	private Action<VampireSurvivors.Objects.Characters.CharacterController> m_OnTeleportStartedAction;

	private Action m_OnTeleportFinishedAction;

	private Action<VampireSurvivors.Objects.Characters.CharacterController> m_OnPlayersTeleported;

	private bool _003CIsAstralSecretDoor_003Ek__BackingField;

	public bool CanTeleport
	{
		get
		{
			return _canTeleport;
		}
		set
		{
			_canTeleport = value;
		}
	}

	public bool CanTeleportLocally
	{
		get
		{
			return _canTeleportLocally;
		}
		set
		{
			_canTeleportLocally = value;
		}
	}

	public GameObject Link
	{
		get
		{
			PickupTeleporter link = _link;
			if ((object)_link != null && ((UnityEngine.Object)link).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_link != null)
				{
					return _link.gameObject;
				}
				return (GameObject)(object)new NullReferenceException();
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				GameManager core = GM.Core;
				Stage stage = core._stage;
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
				{
					PickupTeleporter component = value.GetComponent<PickupTeleporter>();
					LinkTo(component);
					GameManager core2 = GM.Core;
					Stage stage2 = core2._stage;
					TilingTileset tilingTileset2 = stage2._tilingTileset;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4E00");
					return;
				}
			}
			_link = null;
		}
	}

	public bool IsAstralSecretDoor
	{
		get
		{
			return _003CIsAstralSecretDoor_003Ek__BackingField;
		}
		set
		{
			_003CIsAstralSecretDoor_003Ek__BackingField = value;
		}
	}

	public string TeleporterKey
	{
		get
		{
			return _teleporterKey;
		}
		set
		{
			_teleporterKey = value;
		}
	}

	public event Action<VampireSurvivors.Objects.Characters.CharacterController> OnTeleportStartedAction
	{
		add
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 544;
			Delegate obj2 = this.m_OnTeleportStartedAction;
			object obj5 = default(object);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				object obj4;
				if ((object)obj3 == null)
				{
					obj4 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj5 == null;
					obj4 = obj5;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = obj2 == obj;
				Delegate obj6;
				if (obj2 == obj)
				{
					obj = obj4;
					obj6 = obj2;
				}
				else
				{
					obj6 = (Delegate)obj;
				}
				Delegate obj7 = obj2;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj2;
				obj2 = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 544;
			Delegate obj2 = this.m_OnTeleportStartedAction;
			object obj5 = default(object);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				object obj4;
				if ((object)obj3 == null)
				{
					obj4 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj5 == null;
					obj4 = obj5;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = obj2 == obj;
				Delegate obj6;
				if (obj2 == obj)
				{
					obj = obj4;
					obj6 = obj2;
				}
				else
				{
					obj6 = (Delegate)obj;
				}
				Delegate obj7 = obj2;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj2;
				obj2 = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public event Action OnTeleportFinishedAction
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 552;
			Delegate obj2 = this.m_OnTeleportFinishedAction;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 552;
			Delegate obj2 = this.m_OnTeleportFinishedAction;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public event Action<VampireSurvivors.Objects.Characters.CharacterController> OnPlayersTeleported
	{
		add
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 560;
			Delegate obj2 = this.m_OnPlayersTeleported;
			object obj5 = default(object);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				object obj4;
				if ((object)obj3 == null)
				{
					obj4 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj5 == null;
					obj4 = obj5;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = obj2 == obj;
				Delegate obj6;
				if (obj2 == obj)
				{
					obj = obj4;
					obj6 = obj2;
				}
				else
				{
					obj6 = (Delegate)obj;
				}
				Delegate obj7 = obj2;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj2;
				obj2 = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_000e: Expected O, but got I4
			object obj = this + 560;
			Delegate obj2 = this.m_OnPlayersTeleported;
			object obj5 = default(object);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				object obj4;
				if ((object)obj3 == null)
				{
					obj4 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag = obj5 == null;
					obj4 = obj5;
					if (flag)
					{
						break;
					}
				}
				bool flag2 = obj2 == obj;
				Delegate obj6;
				if (obj2 == obj)
				{
					obj = obj4;
					obj6 = obj2;
				}
				else
				{
					obj6 = (Delegate)obj;
				}
				Delegate obj7 = obj2;
				if (!flag2)
				{
					obj7 = obj6;
				}
				bool flag3 = (object)obj7 != obj2;
				obj2 = obj7;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	protected unsafe virtual void OnDrawGizmos()
	{
		//IL_0155->IL00aa: Incompatible stack heights: 4 vs 0
		Transform link = (Transform)(object)_link;
		if ((object)_link != null && ((UnityEngine.Object)link).m_CachedPtr != (IntPtr)0)
		{
			Color value = default(Color);
			Gizmos.set_color_Injected(ref value);
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			bool flag2 = (object)_link == null;
			Transform transform2 = _link.transform;
			bool flag3 = (object)transform2 == null;
			bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
			Vector3 to = default(Vector3);
			Gizmos.DrawLine_Injected(ref *(Vector3*)(&value), ref to);
		}
	}

	public override void SetData(ItemType itemType)
	{
		GenerateSpritesAndAnims();
		((Pickup)this).SetData(itemType);
		((Pickup)this)._003CResRosary_003Ek__BackingField = 1f;
		OnRecycle();
		BaseBody baseBody = body;
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
		baseBody._allowGravity = false;
		_canTeleport = true;
	}

	public void SetTeleportKey(string teleportKey)
	{
		_teleporterKey = teleportKey;
	}

	protected override void OnUpdate()
	{
		//IL_0064: Expected I4, but got I8
		ArcadeSprite arcadeSprite = setDepth(-1993);
		PhaserSprite door = _door;
		if ((object)_door != null && ((UnityEngine.Object)door).m_CachedPtr != (IntPtr)0)
		{
			float2 float5 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		}
	}

	public override void GetTaken()
	{
		if (((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			return;
		}
		if (!_canTeleport)
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				return;
			}
		}
		_canTeleport = false;
		GameManager core2 = GM.Core;
		if (core2._multiplayer.IsOnlineMultiplayer)
		{
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
			if (!targetPlayer._coherenceSync.HasStateAuthority)
			{
				goto IL_013d;
			}
		}
		_canTeleportLocally = false;
		Disable();
		_link.Disable();
		StartTeleport();
		TrackItemPickup();
		goto IL_013d;
		IL_013d:
		Reset();
	}

	public override void GetOnlineTaken()
	{
		GameManager core = GM.Core;
		bool flag;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
			{
				flag = _canTeleportLocally;
				goto IL_00ab;
			}
		}
		flag = _canTeleport;
		goto IL_00ab;
		IL_00ab:
		if (flag)
		{
			base.GetOnlineTaken();
		}
	}

	private bool CheckCanTakeTeleport()
	{
		//IL_0108: Expected I4, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				goto IL_00f3;
			}
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null && core2._playerOptions != null)
			{
				PlayerOptionsData config = core2._playerOptions.Config;
				if (config != null)
				{
					if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
					{
						return _canTeleportLocally;
					}
					goto IL_00f3;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_00f3:
		return _canTeleport;
	}

	protected override void TrackItemPickup(bool trackRunPickup = true)
	{
		PlayerOptions playerOptions = _playerOptions;
		_playerOptions.TrackItemPickup(((Pickup)this)._003CPickupType_003Ek__BackingField, playerOptions._mainGameConfig, trackRunPickup);
	}

	public override void Despawn()
	{
	}

	public void ActuallyDespawn()
	{
		base.Despawn();
	}

	public void LinkTo(PickupTeleporter gate)
	{
		//IL_001c: Expected F4, but got O
		PickupTeleporter pickupTeleporter = default(PickupTeleporter);
		_link = pickupTeleporter;
		float2 float5 = pickupTeleporter.position;
		_destinationX = (float)float5;
		float2 float6 = pickupTeleporter.position;
		object obj = default(object);
		float destinationY = (float)obj - 0.48f;
		_destinationY = destinationY;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CSelectedInverse_003Ek__BackingField)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		if (config2._003CVisuallyInvertStages_003Ek__BackingField)
		{
			GameManager core3 = GM.Core;
			Stage stage = core3._stage;
			StageData stageData = stage._stageData;
			if (stageData._003CallowVisualInversion_003Ek__BackingField)
			{
				float2 float7 = pickupTeleporter.position;
				float destinationY2 = (float)obj + 0.48f;
				_destinationY = destinationY2;
			}
		}
	}

	public void Disable()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		Action onComplete = delegate
		{
			_canTeleport = true;
			BaseBody baseBody2 = body;
			baseBody2._enable = true;
		};
		float duration = _triggerDelay * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void ForceDestination(float x, float y)
	{
		_destinationX = x;
		_destinationY = y;
	}

	protected virtual void OnGateIndexChanged(int oldValue, int newValue)
	{
	}

	protected override void OnRecycle()
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		base.OnRecycle();
		BaseBody baseBody = body.setCircle(12f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
	}

	protected virtual void GenerateSpritesAndAnims()
	{
		//IL_0085: Expected O, but got I4
		//IL_00a0: Expected I4, but got I8
		//IL_01dc: Expected O, but got I4
		PhaserSprite door = _door;
		if ((object)_door != null && ((UnityEngine.Object)door).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "background_Astral", "door01");
		PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0.5f, (float?)(object)1);
		PhaserSprite phaserSprite3 = phaserSprite2.setDepth(-1993);
		GameObject gameObject = phaserSprite3.gameObject;
		((UnityEngine.Object)gameObject).SetName("PickupTeleporter - Door");
		_door = phaserSprite3;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("door", 1, 16, "background_Astral", num);
		PhaserSprite door2 = _door;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		door2._spriteAnimation.AddAnimation("open", animationFrames, 64, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			if (config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
				PhaserSprite phaserSprite4 = _door.setScale(1f, (float?)(object)1);
			}
		}
	}

	protected virtual void DoTeleportAnimation()
	{
		if (_hasDoorAnimation)
		{
			PhaserSprite door = _door;
			door._spriteAnimation.SetAnimation("open");
		}
		GameManager core = GM.Core;
		float2 float5 = _door.position;
		TweenCallback onComplete = OnTeleportFinished;
		Action onYoyo = OnTweenYoyo;
		core._stage.DoTeleportVfx(float5, onComplete, onYoyo);
	}

	private void OnTweenYoyo()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4EDA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite door = _door;
		SpriteAnimation spriteAnimation = door._spriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		PhaserSprite phaserSprite = _door.setFrame("door01", "background_Astral");
		if (_teleporting)
		{
			_teleporting = false;
			return;
		}
		DoTeleport();
		_teleporting = true;
	}

	public override void DisposeAsTaken()
	{
		Tween tween = TweenExtensions.Pause(_glowTween);
		Tween glowTween = _glowTween;
		if (_glowTween != null && glowTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_glowTween);
		}
		PhysicsManager sInstance = PhysicsManager._sInstance;
		sInstance._pickupGroup.remove(this);
		Transform transform = base.transform;
		GameObject gameObject = transform.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
		Despawn();
	}

	public void CleanUpCallbacks()
	{
		this.m_OnTeleportStartedAction = null;
		this.m_OnTeleportFinishedAction = null;
	}

	private void StartTeleport()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			core._003CCanPause_003Ek__BackingField = false;
			DoTeleportAnimation();
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				PhysicsGroup enemies = core2.Enemies;
				if (core2.Enemies != null && ((Group)enemies).children != null)
				{
					HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
					if (enumerator.MoveNext())
					{
						Component component = null;
						throw new NullReferenceException();
					}
					Action<VampireSurvivors.Objects.Characters.CharacterController> onTeleportStartedAction = this.m_OnTeleportStartedAction;
					if (this.m_OnTeleportStartedAction != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v358 @ rax_v20 (System.Action`1<VampireSurvivors.Objects.Characters.CharacterController>)+18] (should have been resolved before IL gen)");
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected void DoTeleport()
	{
		//IL_0034: Expected O, but got F4
		//IL_0278: Expected O, but got I4
		//IL_0228: Expected O, but got I4
		GameManager core = GM.Core;
		float2 float5 = default(float2);
		if ((object)GM.Core != null)
		{
			GM.Core.CheckAllWeaponsForTeleport(float5);
			float2 float6 = SecretCheck((float2)_destinationX, out var secretFound);
			core = GM.Core;
			if ((object)GM.Core != null)
			{
				bool flag = core._multiplayer == null;
				core = (GameManager)(object)core._multiplayer;
				if (!flag)
				{
					if (!core._multiplayer.IsOnlineMultiplayer)
					{
						goto IL_022d;
					}
					bool flag2 = _playerOptions == null;
					core = (GameManager)(object)_playerOptions;
					if (!flag2)
					{
						PlayerOptionsData config = _playerOptions.Config;
						bool flag3 = config == null;
						core = (GameManager)(object)_playerOptions;
						if (!flag3)
						{
							if (!config._003CSelectedOnlineFreeRoam_003Ek__BackingField || secretFound)
							{
								goto IL_022d;
							}
							VampireSurvivors.Objects.Characters.CharacterController targetPlayer = _targetPlayer;
							bool flag4 = (object)_targetPlayer == null;
							core = (GameManager)(object)_playerOptions;
							if (!flag4)
							{
								bool flag5 = (object)targetPlayer._coherenceSync == null;
								core = (GameManager)(object)targetPlayer._coherenceSync;
								if (!flag5)
								{
									bool hasStateAuthority = targetPlayer._coherenceSync.HasStateAuthority;
									bool flag6 = !hasStateAuthority;
									HashSet<PhaserGameObject> hashSet = null;
									float2 float7 = float5;
									if (flag6)
									{
										goto IL_052e;
									}
									bool flag7 = (object)_targetPlayer == null;
									core = (GameManager)(object)_targetPlayer;
									if (!flag7)
									{
										_targetPlayer.position = float5;
										object obj = 0;
										goto IL_027d;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_050d;
		IL_052e:
		Action<VampireSurvivors.Objects.Characters.CharacterController> onPlayersTeleported = this.m_OnPlayersTeleported;
		if (this.m_OnPlayersTeleported != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v835 @ rax_v20 (System.Action`1<VampireSurvivors.Objects.Characters.CharacterController>)+18] (should have been resolved before IL gen)");
		}
		return;
		IL_050d:
		throw new NullReferenceException();
		IL_027d:
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null)
		{
			PhysicsGroup enemies = core2.Enemies;
			if (core2.Enemies != null)
			{
				HashSet<PhaserGameObject> hashSet = ((Group)enemies).children;
				if (((Group)enemies).children != null)
				{
					float2 float7 = (float2)((Group)enemies).children;
					HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
					if (enumerator.MoveNext())
					{
						Component component = null;
						throw new NullReferenceException();
					}
					goto IL_052e;
				}
			}
		}
		goto IL_050d;
		IL_022d:
		core = GM.Core;
		if ((object)GM.Core != null)
		{
			bool focusCameraOnPlayer = default(bool);
			GM.Core.TeleportPlayers(float5, float5, centered: false, focusCameraOnPlayer);
			object obj = 0;
			goto IL_027d;
		}
		goto IL_050d;
	}

	private unsafe float2 SecretCheck(float2 destinationPos, out bool secretFound)
	{
		//IL_021f: Expected O, but got I4
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_0387: Expected I, but got O
		//IL_0394: Expected I, but got O
		//IL_03a4: Expected O, but got I
		//IL_03e0: Expected O, but got I
		ref bool reference = ref *(bool*)null;
		PlayerOptionsData playerOptionsData;
		if (GM.Core.IsStageHost)
		{
			GameManager core = GM.Core;
			PlayerOptions playerOptions = core._playerOptions;
			playerOptionsData = playerOptions._mainGameConfig;
		}
		else
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			playerOptionsData = config;
		}
		if (GM.Core.IsStageHost)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj = default(object);
			if (obj == null)
			{
				goto IL_012f;
			}
		}
		bool isStageHost = GM.Core.IsStageHost;
		float2 result = destinationPos;
		if (!isStageHost)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj2 = default(object);
			bool flag = obj2 != null;
			result = destinationPos;
			if (!flag)
			{
				goto IL_012f;
			}
		}
		goto IL_0443;
		IL_0443:
		return result;
		IL_012f:
		GameManager core3 = GM.Core;
		Stage stage = core3._stage;
		if (stage._stageType != StageType.ASTRALSTAIR)
		{
			GameManager core4 = GM.Core;
			Stage stage2 = core4._stage;
			bool flag2 = stage2._stageType != StageType.ADV_IME_5_Stair;
			result = destinationPos;
			if (flag2)
			{
				goto IL_0443;
			}
		}
		int num = playerOptionsData._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.TELEPORTER);
		bool flag3 = num < 0;
		result = destinationPos;
		if (!flag3)
		{
			int num2 = playerOptionsData._003CPickupCount_003Ek__BackingField.get_Item(ItemType.TELEPORTER);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
			object obj3 = 61 + num2;
			object obj4 = obj3 >> 5;
			object obj5 = obj4 >> 31;
			object obj6 = obj4 + obj5;
			object obj7 = obj6 * 46;
			bool flag4 = num2 != (nint)obj7;
			result = destinationPos;
			if (!flag4)
			{
				GameManager core5 = GM.Core;
				Stage stage3 = core5._stage;
				bool flag5 = stage3._fancyBg;
				bool flag6 = !flag5;
				result = destinationPos;
				if (!flag6)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					if (config2._003CSelectedStage_003Ek__BackingField != StageType.ASTRALSTAIR)
					{
						PlayerOptionsData config3 = _playerOptions.Config;
						bool flag7 = config3._003CSelectedStage_003Ek__BackingField != StageType.ADV_IME_5_Stair;
						result = destinationPos;
						if (flag7)
						{
							goto IL_0443;
						}
					}
					GameManager core6 = GM.Core;
					Stage stage4 = core6._stage;
					BackgroundAstral fancyBg = (BackgroundAstral)stage4._fancyBg;
					nint num3 = (nint)typeof(BackgroundAstral);
					nint num4 = (nint)fancyBg;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundAstral>)+130]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundAstral>)+130]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundAstral>)+130]");
					if (num5 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundAstral>)+C8]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rax_v31+FFFFFFF8+v385 @ rax_v30*8]");
						if (0 == (nint)typeof(BackgroundAstral))
						{
							float2 float5 = fancyBg.MakeDoor46Event(destinationPos, this);
							reference = ref *(bool*)1;
							result = float5;
							goto IL_0443;
						}
					}
					return (float2)new InvalidCastException();
				}
			}
		}
		goto IL_0443;
	}

	protected void OnTeleportFinished()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			PhysicsGroup enemies = core.Enemies;
			if (core.Enemies != null && ((Group)enemies).children != null)
			{
				HashSet<object>.Enumerator children = (HashSet<object>.Enumerator)((Group)enemies).children;
				HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
				if (enumerator.MoveNext())
				{
					Component component = null;
					throw new NullReferenceException();
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					core2._003CCanPause_003Ek__BackingField = true;
					Action onTeleportFinishedAction = this.m_OnTeleportFinishedAction;
					if (this.m_OnTeleportFinishedAction != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v385.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void CheckForWeapons(float2 destinationPos)
	{
		GM.Core.CheckAllWeaponsForTeleport(destinationPos);
	}

	private void _003CDisable_003Eb__48_0()
	{
		_canTeleport = true;
		BaseBody baseBody = body;
		baseBody._enable = true;
	}
}
