using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Items;

public class PickupCartAccel : NetworkPickup
{
	private Timer _selfCleanTimer;

	private void Construct(GameSessionData gameSessionData)
	{
		_gameSessionData = gameSessionData;
	}

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
		((Pickup)this)._003CDespawnInteadOfResetPosition_003Ek__BackingField = true;
	}

	public override void SetData(ItemType itemType)
	{
		base.SetData(itemType);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x18732A200\"");
	}

	private void OnRecycle()
	{
		//IL_0115: Expected I4, but got O
		//IL_0115: Expected O, but got I4
		_spriteAnimation.CleanAnimations();
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("_Accel", 1, 4, "items", flag);
		bool flag2 = default(bool);
		Action action = default(Action);
		bool flag3 = default(bool);
		_spriteAnimation.AddAnimation("idle", animation, 10, flag, flag2, action, flag3);
		_spriteAnimation.SetAnimation("idle");
		BaseBody baseBody = body;
		body.Reset(baseBody._world, this);
		if (_selfCleanTimer != null)
		{
			_selfCleanTimer.Cancel();
		}
		Action onComplete = SelfClean;
		Timer selfCleanTimer = Timers.Register(60.000004f, onComplete, null, isLooped: true, flag, (MonoBehaviour)flag2, (int)action, flag3 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
		_selfCleanTimer = selfCleanTimer;
		bool flag4 = GM.Core.IsStageVisuallyInverted();
		ArcadeSprite arcadeSprite = setFlipX(flag4);
	}

	private void SelfClean()
	{
		//IL_010c: Expected O, but got I4
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					Vector3 vector = ret;
					Rect containmentScreenRect = stage._containmentScreenRect;
					if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector) >= System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentScreenRect))
					{
						object obj2 = default(object);
						object obj = obj2 + (object)stage._containmentScreenRect;
						object obj3 = default(object);
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
						{
							object obj4 = obj2 + obj2;
							bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
							object obj5 = obj4 - obj3;
							bool flag3 = obj5 == null;
							bool flag4 = !flag2;
							bool flag5 = !flag3;
							object obj6 = flag5 & flag4;
							if (obj6 != null)
							{
								return;
							}
						}
					}
					if (_selfCleanTimer != null)
					{
						_selfCleanTimer.Cancel();
					}
					Despawn();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void GetTaken()
	{
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			BackgroundManager fancyBg = stage._fancyBg;
			if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
			{
				GameManager core2 = GM.Core;
				Stage stage2 = core2._stage;
				stage2._fancyBg.OnItemTriggered(ItemType.CART_ACCEL, this, _targetPlayer);
			}
			base.AddToRunPickups();
			base.SetHasSeenItem();
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
		}
	}

	private void TryAccelerate()
	{
		GameManager core = GM.Core;
		Stage stage = core._stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			stage2._fancyBg.OnItemTriggered(ItemType.CART_ACCEL, this, _targetPlayer);
		}
	}

	public override void UpdateDepth()
	{
		//IL_000f: Expected I4, but got I8
		ArcadeSprite arcadeSprite = setDepth(-1998);
	}
}
