using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Items;

public class Pickup_FB_Grenade : NetworkPickup
{
	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	public override void SetData(ItemType itemType)
	{
		base.SetData(itemType);
		OnRecycle();
	}

	protected virtual void OnRecycle()
	{
		_spriteAnimation.CleanAnimations();
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("fb_grenade", 1, 3, _textureName, num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animationFrames, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	public override void GetTaken()
	{
		if (!((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			DamageAllEnemies(100f);
			base.AddToRunPickups();
			base.SetHasSeenItem();
			if (!_taken)
			{
				((Pickup)this).GetTaken();
				_taken = true;
			}
		}
	}

	public unsafe void DamageAllEnemies(float value)
	{
		//IL_0119: Expected F4, but got I4
		//IL_0090: Expected O, but got Ref
		//IL_010a: Expected F4, but got I4
		//IL_032d: Expected O, but got I4
		//IL_0352: Expected O, but got F4
		//IL_031f: Expected O, but got I4
		//IL_0110->IL03a1: Incompatible stack heights: 1 vs 0
		//IL_025b->IL0417: Incompatible stack heights: 6 vs 5
		//IL_0450->IL0455: Incompatible stack heights: 5 vs 0
		//IL_0358->IL0455: Incompatible stack heights: 5 vs 0
		PlayerOptionsData config = _playerOptions.Config;
		Component ret;
		float num;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			Camera main = Camera.main;
			Transform transform = main.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			ObjectPool pool = HeroVfxManager.GetPool(HeroVfxType.FB_GrenadeVfx);
			GrenadeVFX objectComponent = pool.GetObjectComponent<GrenadeVFX>((Vector3)(&ret));
			Transform transform2 = objectComponent.transform;
			Transform parent = transform2.parent;
			objectComponent._originalParent = parent;
			Transform transform3 = objectComponent.transform;
			transform3.SetParent(transform, worldPositionStays: true);
			objectComponent.Play();
			num = 0f;
		}
		else
		{
			num = 0f;
		}
		bool flag2 = value > num;
		float num2 = value;
		if (!flag2)
		{
			num2 = 1f;
		}
		GameManager core = GM.Core;
		PhysicsGroup enemies = core.Enemies;
		HashSet<object>.Enumerator children = (HashSet<object>.Enumerator)((Group)enemies).children;
		Component component = null;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		object obj2 = default(object);
		HashSet<object>.Enumerator enumerator2 = default(HashSet<object>.Enumerator);
		while (enumerator.MoveNext())
		{
			EnemyController component2 = ((Component)null).GetComponent<EnemyController>();
			GameManager core2 = GM.Core;
			bool flag3 = (object)GM.Core == null;
			Stage stage = core2._stage;
			bool flag4 = (object)core2._stage == null;
			bool flag5 = (object)component2 == null;
			Transform cachedTrans = ((ArcadeSprite)component2).CachedTrans;
			bool flag6 = (object)cachedTrans == null;
			bool flag7 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			object obj;
			if (component2.body != null)
			{
				BaseBody baseBody = component2.body;
				ArcadeTransform arcadeTransform = baseBody._transform;
				bool flag8 = baseBody._transform == null;
				arcadeTransform.position = (float2)ret;
				obj = obj2;
				component = ret;
			}
			else
			{
				obj = obj2;
				component = ret;
			}
			Component component3 = component;
			Rect containmentExactRect = stage._containmentExactRect;
			object obj4;
			if (System.Runtime.CompilerServices.Unsafe.As<Component, UIntPtr>(ref component3) >= System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentExactRect))
			{
				children = (HashSet<object>.Enumerator)((object)enumerator2 + (object)stage._containmentExactRect);
				if (System.Runtime.CompilerServices.Unsafe.As<HashSet<object>.Enumerator, UIntPtr>(ref children) > System.Runtime.CompilerServices.Unsafe.As<Component, UIntPtr>(ref component))
				{
					bool flag9 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<HashSet<object>.Enumerator, UIntPtr>(ref enumerator2);
					children = enumerator2;
					if (!flag9)
					{
						children = (HashSet<object>.Enumerator)((object)enumerator2 + (object)enumerator2);
						bool flag10 = System.Runtime.CompilerServices.Unsafe.As<HashSet<object>.Enumerator, UIntPtr>(ref children) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
						object obj3 = (object)children - obj;
						bool flag11 = obj3 == null;
						bool flag12 = !flag10;
						bool flag13 = !flag11;
						obj4 = flag13 & flag12;
						goto IL_0438;
					}
				}
			}
			obj4 = 0;
			goto IL_0438;
			IL_0438:
			if (obj4 != null)
			{
				component2.GetDamaged(num2, HitVfxType.Fire, num, WeaponType.VOID, hasKb: false);
				component = (Component)num2;
			}
		}
	}
}
