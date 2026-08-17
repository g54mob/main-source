using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Items;

public class PickupCartGoal : NetworkPickup
{
	private Timer _selfCleanTimer;

	private MultiTargetTween _tween1;

	private bool AlreadyTaken;

	private void Construct(GameSessionData gameSessionData)
	{
		_gameSessionData = gameSessionData;
	}

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
		((Pickup)this)._003CDespawnInteadOfResetPosition_003Ek__BackingField = true;
	}

	public override void SetData(ItemType itemType)
	{
		base.SetData(itemType);
		OnRecycle();
	}

	public override void UpdateDepth()
	{
		//IL_000f: Expected I4, but got I8
		ArcadeSprite arcadeSprite = setDepth(-1998);
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	private void OnRecycle()
	{
		//IL_0175: Expected I4, but got I8
		//IL_0185: Expected O, but got I4
		//IL_01b8->IL0114: Incompatible stack heights: 1 vs 0
		if ((object)_spriteAnimation != null)
		{
			_spriteAnimation.CleanAnimations();
			bool flag = default(bool);
			List<Sprite> animation = SpriteManager.GetAnimation("chequered", 0, 1, "items", flag);
			if ((object)_spriteAnimation != null)
			{
				bool startRandomFrame = default(bool);
				Action onComplete = default(Action);
				bool autoSetAnimation = default(bool);
				_spriteAnimation.AddAnimation("idle", animation, 10, flag, startRandomFrame, onComplete, autoSetAnimation);
				if ((object)_spriteAnimation != null)
				{
					_spriteAnimation.SetAnimation("idle");
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_itemRenderer, 0.75f);
					object itemRenderer = _itemRenderer;
					if ((object)_itemRenderer != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rsi_v5 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rsi_v5 (System.Object)+10]");
						Renderer.set_sortingOrder_Injected((IntPtr)0, -1998);
						ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
						BaseBody baseBody = body;
						AlreadyTaken = false;
						if (body != null)
						{
							body.Reset(baseBody._world, this);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
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
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField && !AlreadyTaken)
		{
			AlreadyTaken = true;
			GameManager core = GM.Core;
			Stage stage = core._stage;
			BackgroundManager fancyBg = stage._fancyBg;
			if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
			{
				GameManager core2 = GM.Core;
				Stage stage2 = core2._stage;
				stage2._fancyBg.OnItemTriggered(ItemType.CART_GOAL, this, _targetPlayer);
			}
			base.AddToRunPickups();
			base.SetHasSeenItem();
			TakenTween();
		}
	}

	private void TakenTween()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_itemRenderer != null)
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
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween1 = tween;
	}

	private void TryTrigger()
	{
		GameManager core = GM.Core;
		Stage stage = core._stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			stage2._fancyBg.OnItemTriggered(ItemType.CART_GOAL, this, _targetPlayer);
		}
	}

	private void _003CTakenTween_003Eb__11_0()
	{
		if (!_taken)
		{
			((Pickup)this).GetTaken();
			_taken = true;
		}
	}
}
