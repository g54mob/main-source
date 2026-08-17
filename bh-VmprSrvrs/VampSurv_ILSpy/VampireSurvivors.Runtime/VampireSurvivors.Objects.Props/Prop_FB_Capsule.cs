using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Props;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Props;

public class Prop_FB_Capsule : Destructible
{
	private float2 _startingPosition;

	private float _repeats;

	private float _repeated;

	private float _life;

	private float _travelDuration;

	private bool _hasFired;

	private static WeightedStore WEIGHTEDSTORE;

	private float StartingX;

	private float FinishingXOffset;

	private float OffsetFromPlayerY;

	private float WaveMaxHeight;

	private float _oscillations;

	private float _accumulatedTime;

	public override void Init(PropType destructibleType)
	{
		//IL_01d2: Expected O, but got I4
		base.Init(destructibleType);
		_hasFired = false;
		base._003CIgnoreForcedMovement_003Ek__BackingField = true;
		if (WEIGHTEDSTORE == null)
		{
			GameManager core = GM.Core;
			ItemType[] items = new ItemType[3]
			{
				ItemType.FB_BARRIER,
				ItemType.FB_GRENADE,
				ItemType.FB_RAPIDFIRE
			};
			WeightedStore wEIGHTEDSTORE = core._lootManager.ExportCustomLootTable(items);
			WEIGHTEDSTORE = wEIGHTEDSTORE;
		}
		_repeated = 0f;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float offsetFromPlayerY = renderer.height * 0.25f;
			OffsetFromPlayerY = offsetFromPlayerY;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				float num = renderer2.screenWidth * 0.5f;
				float num2 = num + num;
				float startingX = num + 0.32f;
				float finishingXOffset = num2 + 0.64f;
				StartingX = startingX;
				FinishingXOffset = finishingXOffset;
				GameObject gameObject = base.gameObject;
				((UnityEngine.Object)gameObject).SetName("FB_CAPSULE pickup");
				_accumulatedTime = 0f;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer3 = s_scene3._renderer;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v18 (PhaserScene+Renderer)+38]");
					_ = 0;
					_startingPosition = renderer3.screenCenter;
					ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
					UpdatePosition();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override bool CanEmitLight()
	{
		return false;
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_005c: Invalid comparison between I4 and F4
		if (!CameraExtensions.IsObjectVisible(_mainCamera, _destructibleRenderer) || _isDead)
		{
			return;
		}
		if (!(0f < (_hp -= value)))
		{
			_isDead = true;
			if (!_coherenceSync.HasStateAuthority)
			{
				Action action = base.DestroyDestructible;
				bool flag = _coherenceSync.SendCommand(action, MessageTarget.AuthorityOnly);
			}
			else
			{
				OnDestroyed();
			}
		}
		OnGetDamaged(showHitVfx);
	}

	protected override void SetupAnimations()
	{
		_spriteAnimation.CleanAnimations();
		PropData propData = _propData;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(propData._003CframeName_003Ek__BackingField, 1, 4, propData._003CtextureName_003Ek__BackingField, num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("Idle", animationFrames, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	protected override void OnDestroyed()
	{
		if (!_hasFired)
		{
			_hasFired = true;
			_playerOptions.IncreaseDestroyedPropCount(_destructibleType);
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 37 Invalid \"Jump target not found in method: 0x186FEBCF0\"");
		}
	}

	protected void CustomLoot()
	{
		//IL_039c->IL02b4: Incompatible stack heights: 1 vs 0
		//IL_02b4->IL02e2: Incompatible stack heights: 1 vs 0
		//IL_034e->IL02b4: Incompatible stack heights: 1 vs 0
		//IL_0267->IL02e2: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._lootManager != null)
		{
			ItemType itemFromExportedTable = core._lootManager.GetItemFromExportedTable(WEIGHTEDSTORE);
			Action<Pickup> action = delegate(Pickup spawned)
			{
				if ((object)spawned != null && ((UnityEngine.Object)spawned).m_CachedPtr != (IntPtr)0)
				{
					float2 float5 = base.position;
					bool includeFollowers = default(bool);
					VampireSurvivors.Objects.Characters.CharacterController closestPlayer = GM.Core.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
					spawned._targetPlayer = closestPlayer;
					spawned.GoToPlayer = true;
					spawned.Time = 1f;
				}
			};
			Vector2 pos = default(Vector2);
			Vector3 ret;
			switch (itemFromExportedTable)
			{
			default:
			{
				Transform transform3 = base.transform;
				if ((object)transform3 == null)
				{
					break;
				}
				Vector3 vector2 = transform3.position;
				if ((object)GM.Core != null)
				{
					float value = default(float);
					ItemType relicType = default(ItemType);
					bool shouldCallValidatePickups = default(bool);
					bool isRemote = default(bool);
					Pickup pickup = GM.Core.MakePickup(pos, itemFromExportedTable, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
					if ((object)pickup == null || ((UnityEngine.Object)pickup).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					if (action != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v294 @ rax_v18 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
						return;
					}
				}
				break;
			}
			case ItemType.GEM:
			{
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					Vector3 vector = transform2.position;
					if ((object)GM.Core != null)
					{
						GM.Core.MakeGem(pos, 1f, action);
						return;
					}
				}
				break;
			}
			case ItemType.COINBAG1:
			{
				Transform transform4 = base.transform;
				if ((object)transform4 != null)
				{
					bool flag2 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
					if ((object)GM.Core != null)
					{
						GM.Core.MakeRedCoinBag(pos, 0f, action);
						return;
					}
				}
				break;
			}
			case ItemType.COIN:
			{
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
					if ((object)GM.Core != null)
					{
						GM.Core.MakeCoin(pos, 0f, action);
						return;
					}
				}
				break;
			}
			case ItemType.VOID:
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void UpdatePosition()
	{
		float num = _oscillations * _life;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float2 float5 = default(float2);
		base.position = float5;
	}

	protected override void OnUpdate()
	{
		//IL_00ff: Invalid comparison between F4 and O
		base.OnUpdate();
		if (PauseSystem._paused || _hasFired)
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float life = (_accumulatedTime = num + _accumulatedTime) / _travelDuration;
		_life = life;
		UpdatePosition();
		float2 float5 = base.position;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num2 = renderer2.screenWidth * 0.5f;
		float num3 = num2 + 0.2f;
		float num4 = (float)renderer.screenCenter - num3;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5))
		{
			float num5 = ++_repeated;
			if (_repeats < num5)
			{
				base.Despawn();
				return;
			}
			_accumulatedTime = 0f;
			_life = 0f;
			PhaserScene phaserScene = GM.Core.scene;
			PhaserScene.Renderer renderer3 = phaserScene._renderer;
			_startingPosition = renderer3.screenCenter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v22 (PhaserScene+Renderer)+38]");
			_ = 0;
		}
	}

	public Prop_FB_Capsule()
	{
		//IL_006d: Expected I, but got O
		_repeats = 1f;
		_travelDuration = 10000f;
		OffsetFromPlayerY = 2f;
		WaveMaxHeight = 0.25f;
		_oscillations = 10f;
		_hp = 1f;
		base._maxHp = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CCustomLoot_003Eb__18_0(Pickup spawned)
	{
		if ((object)spawned != null && ((UnityEngine.Object)spawned).m_CachedPtr != (IntPtr)0)
		{
			float2 float5 = base.position;
			bool includeFollowers = default(bool);
			VampireSurvivors.Objects.Characters.CharacterController closestPlayer = GM.Core.GetClosestPlayer(float5, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
			spawned._targetPlayer = closestPlayer;
			spawned.GoToPlayer = true;
			spawned.Time = 1f;
		}
	}
}
