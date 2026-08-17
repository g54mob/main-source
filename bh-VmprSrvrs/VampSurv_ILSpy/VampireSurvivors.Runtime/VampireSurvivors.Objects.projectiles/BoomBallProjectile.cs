using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BoomBallProjectile : Projectile
{
	private bool alreadyRecycled;

	private bool alreadyGenerated;

	private bool IsExploding;

	private BallState State;

	private float maximizedTimer;

	private Flower2Weapon trueWeapon;

	private bool isFrozen;

	private float SpeedX;

	private float SpeedY;

	private float Radius;

	private float ExplodingSpeed;

	private float MAXRADIUS;

	private float MAXTIMER;

	private float OffsetX;

	private float OffsetY;

	private float MoveSpeed;

	private MultiTargetTween splashTweenIn;

	private MultiTargetTween splashTweenOut;

	private MultiTargetTween finalTweenOut;

	private List<uint> tints;

	private MultiTargetTween enterTween;

	private MultiTargetTween flowerTweenIn;

	private PhaserSprite sprSplash;

	private PhaserSprite sprFlower;

	private PhaserSprite _GroundFx;

	private PhaserSprite displaySprite;

	public HashSet<IDamageable> objectsHit => _objectsHit;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0594: Expected O, but got I4
		//IL_0022: Expected I, but got O
		//IL_002a: Expected I, but got O
		//IL_003a: Expected O, but got I
		//IL_00ba: Expected O, but got I4
		//IL_000f: Expected O, but got I4
		//IL_05ee: Expected O, but got I4
		//IL_0076: Expected O, but got I
		//IL_00ac: Expected O, but got I4
		//IL_0611: Expected F4, but got O
		//IL_01c2: Expected O, but got I4
		//IL_020b: Expected I4, but got I8
		//IL_0652: Expected O, but got I4
		//IL_066e: Expected O, but got F4
		//IL_02ec: Expected O, but got Ref
		//IL_02ff: Expected O, but got I4
		//IL_0366: Expected O, but got I4
		//IL_037e: Expected O, but got Ref
		//IL_037e: Expected I4, but got O
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Expected O, but got Unknown
		//IL_04c4->IL067d: Incompatible stack heights: 2 vs 0
		//IL_0567->IL05fd: Incompatible stack heights: 2 vs 0
		BulletPool pool2 = default(BulletPool);
		base.InitProjectile(pool2, weapon, index);
		_isCullable = false;
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
		float? num;
		if ((object)weapon == null)
		{
			num = (float?)(object)0;
			goto IL_05b8;
		}
		nint num2 = (nint)typeof(Flower2Weapon);
		nint num3 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.Flower2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r8_v56 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.Flower2Weapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r8_v56 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v128+FFFFFFF8+v82 @ rax_v123*8]");
			if (0 == (nint)typeof(Flower2Weapon))
			{
				obj3 = 1;
				goto IL_05c7;
			}
		}
		obj3 = 0;
		goto IL_05c7;
		IL_05c7:
		bool flag = obj3 == null;
		pool2 = (BulletPool)(object)typeof(Flower2Weapon);
		num = (float?)(object)0;
		if (!flag)
		{
			pool2 = (BulletPool)(object)typeof(Flower2Weapon);
			num = (float?)weapon;
		}
		goto IL_05b8;
		IL_05b8:
		trueWeapon = (Flower2Weapon)num;
		if (alreadyRecycled)
		{
			return;
		}
		alreadyRecycled = true;
		if (!alreadyGenerated)
		{
			MakeProfusionSprites();
			uint[] array = new uint[3] { 7721456u, 3248332u, 1002625u };
			BlendMode[] array2 = new BlendMode[3];
			_ = 1;
			_ = 2;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.circle(s_scene.add, pos, 16, 16777215u);
			PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0.5f, (float?)(object)0);
			PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.1f);
			PhaserSprite phaserSprite4 = phaserSprite3.setVisible(visible: false);
			PhaserSprite phaserSprite5 = phaserSprite4.setDepth(-1999);
			int num5 = _indexInWeapon % array2.Length;
			PhaserSprite phaserSprite6 = phaserSprite5.setBlendMode((BlendMode)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[num5]));
			GameObject gameObject = phaserSprite6.gameObject;
			((UnityEngine.Object)gameObject).SetName("boomcircle");
			_GroundFx = phaserSprite6;
			object obj4 = UnityEngine.Random.RandomRangeInt(0, array.Length);
			PhaserSprite phaserSprite7 = _GroundFx.setTint(array[obj4]);
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			float2 float6 = base.position;
			PhaserSprite phaserSprite8 = RenderingExtensions.sprite(s_scene2.add, pos, "vfx", "leaf0000.png");
			object obj5 = UnityEngine.Random.value;
			Transform transform = phaserSprite8.transform;
			object obj6 = default(object);
			transform.localEulerAngles = (Vector3)(&obj6);
			PhaserSprite phaserSprite9 = phaserSprite8.setScale(0.65f, (float?)(object)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A570");
			uint tint = default(uint);
			PhaserSprite phaserSprite10 = phaserSprite9.setTint(tint);
			PhaserSprite phaserSprite11 = phaserSprite10.setBlendMode(BlendMode.Add);
			displaySprite = phaserSprite11;
			List<string> list = new List<string>();
			float? num6 = (float?)(object)0;
			do
			{
				string text = System.Number.FormatInt32((int)num6, (ReadOnlySpan<char>)(&obj6), null);
				object obj7 = "0";
				bool flag2 = "0" == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rbp_v13+10]");
				bool flag3 = (nint)0 != 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rbp_v13+14]");
				string text2 = text.PadLeft(4, '\0');
				string item = "leaf" + text2;
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)item);
				}
				else
				{
					int num7 = list._size + 1;
					list._size = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				num6 = (float?)(object)((_003F?)num6 + 1);
			}
			while ((nint)num6 < 20);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(list, "vfx");
			PhaserSprite phaserSprite12 = displaySprite;
			bool shouldLoop = default(bool);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			phaserSprite12._spriteAnimation.AddAnimation("spin", animationFrames, 60, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
			PhaserSprite phaserSprite13 = displaySprite;
			phaserSprite13._spriteAnimation.SetAnimation("spin");
			PhaserSprite phaserSprite14 = displaySprite.setVisible(visible: false);
			alreadyGenerated = true;
		}
		float2 float7 = base.position;
		OffsetX = (float)float7;
		float2 float8 = base.position;
		float offsetY = default(float);
		OffsetY = offsetY;
		Reset();
	}

	public void Reset()
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_01f1: Expected O, but got F4
		//IL_022a: Expected O, but got F4
		//IL_00ea: Expected O, but got I4
		//IL_0166: Expected I, but got O
		//IL_01c6: Expected O, but got I4
		//IL_0189->IL0189: Incompatible stack heights: 1 vs 0
		BaseBody baseBody = body.setCircle(2f, (float?)(object)0, (float?)(object)0);
		BaseBody baseBody2 = body;
		baseBody2._checkCollision = (ArcadeBodyCollision)0;
		Radius = 8f;
		State = BallState.Bouncing;
		IsExploding = false;
		MAXTIMER = 750f;
		PhaserSprite phaserSprite = _GroundFx.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _GroundFx.setAlpha(0.1f);
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float num2 = (SpeedX = num * MoveSpeed);
		object obj3 = UnityEngine.Random.value;
		float num3 = num2 - 0.5f;
		Flower2Weapon flower2Weapon = trueWeapon;
		float speedY = num3 * MoveSpeed;
		SpeedY = speedY;
		Group obj4 = flower2Weapon._activeBalls.add(this);
		PhaserSprite phaserSprite3 = displaySprite.setVisible(visible: true);
		PhaserSprite phaserSprite4 = displaySprite.setScale(0f, (float?)(object)0);
		if (enterTween != null)
		{
			enterTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)displaySprite != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			bool flag = obj5 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		enterTween = multiTargetTween;
	}

	public override void InternalUpdate()
	{
		//IL_03d7: Expected O, but got I4
		//IL_002f: Expected O, but got I4
		//IL_0406: Expected O, but got I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_0316: Invalid comparison between O and F4
		//IL_0166: Expected O, but got I4
		//IL_00c7: Invalid comparison between I4 and F4
		//IL_033a: Invalid comparison between F4 and O
		bool flag = State == BallState.Bouncing;
		Flower2Weapon flower2Weapon;
		float num10;
		if (!flag)
		{
			object obj = State - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						float deltaTime = PauseSystem.DeltaTime;
						float num = deltaTime * ExplodingSpeed;
						float num2 = num * 1000f;
						if (0f > (Radius -= num2))
						{
							State = BallState.Finished;
						}
					}
				}
				else
				{
					float deltaTime2 = PauseSystem.DeltaTime;
					float num3 = deltaTime2 * 1000f;
					if ((maximizedTimer = num3 + maximizedTimer) > MAXTIMER)
					{
						StopAnim();
						BaseBody baseBody = body;
						baseBody._checkCollision = (ArcadeBodyCollision)0;
						State = BallState.Collapsing;
					}
				}
			}
			else
			{
				float deltaTime3 = PauseSystem.DeltaTime;
				float num4 = deltaTime3 * ExplodingSpeed;
				float num5 = num4 * 1000f;
				if (!((Radius = num5 + Radius) < MAXRADIUS))
				{
					State = BallState.Maximized;
				}
				CheckOverlap();
			}
		}
		else if (!isFrozen)
		{
			Weapon weapon = _weapon;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			Weapon weapon2 = _weapon;
			float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
			float deltaTime4 = PauseSystem.DeltaTime;
			float num6 = deltaTime4 * SpeedX;
			float num7 = num6 * 1000f;
			float offsetX = num7 + OffsetX;
			OffsetX = offsetX;
			float deltaTime5 = PauseSystem.DeltaTime;
			flower2Weapon = trueWeapon;
			float num8 = deltaTime5 * SpeedY;
			object obj3 = float5 + OffsetX;
			float num9 = num8 * 1000f;
			object obj4 = default(object);
			num10 = (float)obj4 - (OffsetY = num9 + OffsetY);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)flower2Weapon.WORLD_RIGHT))
			{
				float wORLD_LEFT = flower2Weapon.WORLD_LEFT;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)wORLD_LEFT) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					goto IL_0353;
				}
			}
			float speedX = SpeedX * -1f;
			SpeedX = speedX;
			goto IL_0353;
		}
		goto IL_03b6;
		IL_0353:
		if (!(num10 < flower2Weapon.WORLD_BOTTOM) || !(flower2Weapon.WORLD_TOP < num10))
		{
			float speedY = SpeedY * -1f;
			SpeedY = speedY;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float7 = default(float2);
		base.position = float7;
		goto IL_03b6;
		IL_03b6:
		float xScale = Radius * 0.5f;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		float xScale2 = Radius * 0.0625f;
		PhaserSprite phaserSprite = _GroundFx.setScale(xScale2, (float?)(object)0);
	}

	public void CheckOverlap()
	{
		//IL_0039: Expected F4, but got O
		//IL_0046: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_00ea: Expected I, but got O
		//IL_00f2: Expected I, but got O
		//IL_0102: Expected O, but got I
		//IL_0182: Expected O, but got I4
		//IL_013e: Expected O, but got I
		//IL_0174: Expected O, but got I4
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		float2 float5 = base.position;
		float2 float6 = base.position;
		float radius = Radius * 0.01f;
		float y = default(float);
		bool includeDynamic = default(bool);
		bool includeStatic = default(bool);
		Group specificGroup = default(Group);
		List<BaseBody> list = ArcadePhysics.s_instance.OverlapCirc((float)float5, y, radius, includeDynamic, includeStatic, specificGroup);
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 >= list._size)
			{
				return;
			}
			if ((nint)obj >= list._size)
			{
				break;
			}
			BaseBody[] items = list._items;
			BaseBody baseBody = items[obj];
			BoomBallProjectile boomBallProjectile = (BoomBallProjectile)baseBody._gameObject;
			BoomBallProjectile boomBallProjectile2;
			if ((object)baseBody._gameObject == null)
			{
				boomBallProjectile2 = null;
				goto IL_025e;
			}
			nint num = (nint)typeof(BoomBallProjectile);
			nint num2 = (nint)boomBallProjectile;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoomBallProjectile>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoomBallProjectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoomBallProjectile>)+130]");
			object obj5;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.BoomBallProjectile>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v33+FFFFFFF8+v305 @ rax_v29*8]");
				if (0 == (nint)typeof(BoomBallProjectile))
				{
					obj5 = 1;
					goto IL_0236;
				}
			}
			obj5 = 0;
			goto IL_0236;
			IL_0236:
			bool flag = obj5 == null;
			boomBallProjectile2 = null;
			if (!flag)
			{
				boomBallProjectile2 = (BoomBallProjectile)baseBody._gameObject;
			}
			goto IL_025e;
			IL_025e:
			if ((object)boomBallProjectile2 != null && ((UnityEngine.Object)boomBallProjectile2).m_CachedPtr != (IntPtr)0 && !boomBallProjectile2.IsExploding)
			{
				boomBallProjectile2.Detonate();
			}
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public void Detonate()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0312: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_033a: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_01c1: Expected O, but got I
		//IL_0386: Expected O, but got I4
		//IL_01e7: Expected O, but got I
		//IL_0203: Expected O, but got I4
		//IL_0278: Expected O, but got I4
		List<SfxType> list = new List<SfxType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v7+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)54);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 54;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v9+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)55);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 55;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdx_v11+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)56);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 56;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		System.Int32Enum int32Enum = (System.Int32Enum)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v13 (System.Int32Enum)+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)57);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj7 = (nint)0 + (nint)1;
			_ = 57;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		object obj8 = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		bool flag = (nint)obj8 >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj9 = 0;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
		{
			Volume = (float?)(object)1,
			Rate = 1f
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v21+20+v116 @ rax_v20*4]");
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.None, soundConfig, 500f, 1, time);
		Flower2Weapon flower2Weapon = trueWeapon;
		flower2Weapon._activeBalls.remove(this);
		BaseBody baseBody = body;
		baseBody._checkCollision = (ArcadeBodyCollision)15;
		State = BallState.Expanding;
		IsExploding = true;
		PlayAnim();
		PhaserSprite phaserSprite = displaySprite.setVisible(visible: false);
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite2 = _GroundFx.setVisible(visible: true);
	}

	public override void Despawn()
	{
		//IL_001a: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		base.Despawn();
		State = BallState.Bouncing;
		alreadyRecycled = false;
		PhaserSprite phaserSprite = displaySprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _GroundFx.setScale(0f, (float?)(object)0);
		if (enterTween != null)
		{
			enterTween.Kill();
		}
		if (flowerTweenIn != null)
		{
			flowerTweenIn.Kill();
		}
		if (splashTweenIn != null)
		{
			splashTweenIn.Kill();
		}
		if (splashTweenOut != null)
		{
			splashTweenOut.Kill();
		}
		if (finalTweenOut != null)
		{
			finalTweenOut.Kill();
		}
		PhaserSprite phaserSprite3 = sprSplash;
		if ((object)sprSplash != null && ((UnityEngine.Object)phaserSprite3).m_CachedPtr != (IntPtr)0)
		{
			Radius = 0.01f;
			PhaserSprite phaserSprite4 = sprSplash.setVisible(visible: false);
		}
		PhaserSprite phaserSprite5 = sprFlower;
		if ((object)sprFlower != null && ((UnityEngine.Object)phaserSprite5).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite6 = sprFlower.setVisible(visible: false);
		}
	}

	public unsafe void MakeProfusionSprites()
	{
		//IL_0018: Expected O, but got Ref
		//IL_0084: Expected O, but got I4
		//IL_0175: Expected O, but got I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Expected O, but got Unknown
		//IL_0468: Expected I, but got O
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Expected I, but got Unknown
		//IL_0483: Expected O, but got I
		//IL_015f: Expected O, but got I4
		//IL_0101: Expected O, but got I
		//IL_013f: Expected O, but got I4
		//IL_02a0: Expected O, but got I4
		//IL_04ee: Expected O, but got I4
		//IL_0391: Expected O, but got I4
		//IL_0517: Expected O, but got F4
		//IL_03a3: Invalid comparison between O and F4
		//IL_03dc: Expected I4, but got I8
		//IL_0238->IL04b6: Incompatible stack heights: 1 vs 0
		List<string> list = new List<string>();
		int num = 0;
		object obj = default(object);
		do
		{
			string text = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj), null);
			object obj2 = "0";
			string text3;
			if ("0" != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdi_v2+10]");
				bool flag = (nint)0 != 1;
				object obj3 = 2 - text._stringLength;
				if ((nint)obj3 > 0)
				{
					string text2 = string.FastAllocateString(2);
					object obj4 = text2 + 20;
					if ((nint)obj3 > 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"rep stosw\"");
					}
					int num2 = text._stringLength + text._stringLength;
					object obj5 = obj3 * 2;
					byte* ptr = (byte*)(nint)(obj4 + obj5);
					byte* ptr2 = (byte*)(nint)(text + 20);
					object obj6 = (object)(ptr - (nuint)ptr2);
					object obj8;
					if ((nint)obj6 >= num2)
					{
						object obj7 = (object)(ptr2 - (nuint)ptr);
						if ((nint)obj7 >= num2)
						{
							Buffer.Memcpy(ptr, ptr2, num2);
							text3 = text2;
							obj8 = 0;
							goto IL_049f;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					text3 = text2;
					obj8 = 0;
				}
				else
				{
					text3 = text;
					object obj8 = 0;
				}
				goto IL_049f;
			}
			ArgumentNullException ex = new ArgumentNullException("value");
			throw ex;
			IL_049f:
			string item = "fl" + text3;
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)item);
			}
			else
			{
				int num3 = list._size + 1;
				list._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
		}
		while (num < 88);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		float2 float5 = base.position;
		Vector2 vector = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, vector, "anima", "FlexSplash_01");
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
		PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)1);
		sprSplash = phaserSprite3;
		int num4 = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("FlexSplash_", 1, 8, "anima", num4);
		PhaserSprite phaserSprite4 = sprSplash;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		phaserSprite4._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num4 != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		float2 float6 = base.position;
		object obj9 = UnityEngine.Random.RandomRangeInt(0, list._size);
		bool flag2 = (nint)obj9 >= list._size;
		PhaserSprite phaserSprite5 = RenderingExtensions.sprite(spriteName: list._items[obj9], behaviour: s_scene2.add, pos: vector, textureName: "vfx");
		PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0f);
		PhaserSprite phaserSprite7 = phaserSprite6.setOrigin(0.5f, (float?)(object)1);
		object obj10 = UnityEngine.Random.value;
		bool flag3 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
		bool flag4 = !flag3;
		PhaserSprite phaserSprite8 = phaserSprite7.setFlipX(flag4);
		PhaserSprite phaserSprite9 = phaserSprite8.setDepth(-1998);
		sprFlower = phaserSprite9;
	}

	public void PlayAnim()
	{
		//IL_01da: Expected O, but got I4
		//IL_020f: Expected O, but got I4
		//IL_0273: Expected I, but got O
		//IL_0530: Expected O, but got I4
		//IL_054c: Expected O, but got I4
		//IL_0362: Expected I, but got O
		//IL_03c7: Expected O, but got I4
		//IL_03e3: Expected O, but got I4
		//IL_0470: Expected I, but got O
		//IL_04c6: Expected O, but got I4
		PhaserSprite phaserSprite = sprSplash;
		phaserSprite._spriteAnimation.SetAnimation("idle");
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float7 = base.position;
		Weapon weapon = _weapon;
		float2 float8 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		object obj = default(object);
		object obj2 = default(object);
		float num = (float)obj - (float)obj2;
		PhaserSprite phaserSprite2 = sprSplash.setDepth(num);
		float2 float9 = base.position;
		Weapon weapon2 = _weapon;
		float2 float10 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
		object obj3 = obj - obj2;
		float num2 = (float)obj3 + 1f;
		PhaserSprite phaserSprite3 = sprFlower.setDepth(num2);
		PhaserSprite phaserSprite4 = sprSplash.setVisible(visible: true);
		PhaserSprite phaserSprite5 = sprFlower.setVisible(visible: true);
		if (flowerTweenIn != null)
		{
			flowerTweenIn.Kill();
		}
		if (splashTweenIn != null)
		{
			splashTweenIn.Kill();
		}
		if (splashTweenOut != null)
		{
			splashTweenOut.Kill();
		}
		PhaserSprite phaserSprite6 = sprFlower.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite7 = phaserSprite6.setAlpha(0f);
		PhaserSprite phaserSprite8 = sprSplash.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite9 = phaserSprite8.setAlpha(0f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)sprSplash != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		float num4 = trueWeapon.PArea();
		float num5 = default(float);
		bool flag = 2f > num5;
		float num6 = 2f;
		if (!flag)
		{
			num6 = num5;
		}
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		splashTweenIn = multiTargetTween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)sprFlower != null)
		{
			nint num7 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		float num8 = trueWeapon.PArea();
		tweenConfig2.scale = (float?)(object)1;
		tweenConfig2.duration = 250f;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_002c: Expected I, but got O
			//IL_0090: Expected O, but got I4
			TweenConfig tweenConfig4 = new TweenConfig();
			object[] array4 = new object[1];
			if ((object)sprFlower != null)
			{
				nint num10 = (nint)array4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj7 = default(object);
				if (obj7 == null)
				{
					ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
					throw ex4;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig4.targets = array4;
			tweenConfig4.duration = 250f;
			tweenConfig4.scale = (float?)(object)1;
			TweenCallback onComplete2 = delegate
			{
				//IL_0014: Expected I4, but got I8
				PhaserSprite phaserSprite10 = sprFlower.setDepth(-1998);
			};
			tweenConfig4.onComplete = onComplete2;
			TweenCallback onStop = delegate
			{
				//IL_0014: Expected I4, but got I8
				PhaserSprite phaserSprite10 = sprFlower.setDepth(-1998);
			};
			tweenConfig4.onStop = onStop;
			MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
			flowerTweenIn = multiTargetTween4;
		};
		tweenConfig2.onComplete = onComplete;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		flowerTweenIn = multiTargetTween2;
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)sprSplash != null)
		{
			nint num9 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.alpha = (float?)(object)1;
		tweenConfig3.delay = 500f;
		tweenConfig3.duration = 250f;
		MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
		splashTweenOut = multiTargetTween3;
	}

	public void StopAnim()
	{
		//IL_011e: Expected I, but got O
		//IL_0176: Expected I, but got O
		//IL_01ce: Expected I, but got O
		//IL_0240: Expected O, but got I4
		Radius = 0f;
		PhaserSprite phaserSprite = displaySprite.setVisible(visible: false);
		if (flowerTweenIn != null)
		{
			flowerTweenIn.Kill();
		}
		if (splashTweenIn != null)
		{
			splashTweenIn.Kill();
		}
		if (splashTweenOut != null)
		{
			splashTweenOut.Kill();
		}
		if (finalTweenOut != null)
		{
			finalTweenOut.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[3];
		if ((object)sprFlower != null)
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
		if ((object)sprSplash != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_GroundFx != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.delay = 250f;
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		finalTweenOut = multiTargetTween;
	}

	public BoomBallProjectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_024a: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0272: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_029a: Expected O, but got I
		//IL_01c0: Expected O, but got I
		Radius = 8f;
		ExplodingSpeed = 0.116f;
		MAXRADIUS = 60f;
		MAXTIMER = 4500f;
		MoveSpeed = 0.001f;
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(16746632u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16746632;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(8978312u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 8978312;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(8978312u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 8978312;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(16777096u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 16777096;
		}
		tints = list;
		base._002Ector();
	}

	private void _003CPlayAnim_003Eb__35_0()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)sprFlower != null)
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
		tweenConfig.duration = 250f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_0014: Expected I4, but got I8
			PhaserSprite phaserSprite = sprFlower.setDepth(-1998);
		};
		tweenConfig.onComplete = onComplete;
		TweenCallback onStop = delegate
		{
			//IL_0014: Expected I4, but got I8
			PhaserSprite phaserSprite = sprFlower.setDepth(-1998);
		};
		tweenConfig.onStop = onStop;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		flowerTweenIn = multiTargetTween;
	}

	private void _003CPlayAnim_003Eb__35_1()
	{
		//IL_0014: Expected I4, but got I8
		PhaserSprite phaserSprite = sprFlower.setDepth(-1998);
	}

	private void _003CPlayAnim_003Eb__35_2()
	{
		//IL_0014: Expected I4, but got I8
		PhaserSprite phaserSprite = sprFlower.setDepth(-1998);
	}

	private void _003CStopAnim_003Eb__36_0()
	{
		Despawn();
	}
}
