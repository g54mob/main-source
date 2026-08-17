using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class ShadowServantWeapon : Weapon
{
	private PhaserSprite _summonSprite;

	private MultiTargetTween _summonTween;

	private ParticleEmitterManager _particlesManager;

	private GravityWell _well;

	private WeaponType _counterWeaponType = WeaponType.SHADOWSERVANT_COUNTER;

	private ShadowServantCounterWeapon _counterWeapon;

	[NonSerialized]
	public ParticleSystem PfxEmitter;

	[NonSerialized]
	public string BaseSpriteName = "bubbleSphere2.png";

	[NonSerialized]
	public string SnakeSpriteName = "snakeW_i0";

	[NonSerialized]
	public string SnakeDieSpriteName = "snakeW_";

	[NonSerialized]
	public string TrailSpriteName = "BlackTrail.png";

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_014b: Expected O, but got I
		//IL_0410: Expected O, but got Ref
		//IL_042a: Expected native int or pointer, but got O
		//IL_0444: Expected O, but got I
		//IL_0464: Expected O, but got Ref
		//IL_047e: Expected native int or pointer, but got O
		//IL_0498: Expected O, but got I
		//IL_04b8: Expected O, but got Ref
		//IL_04d2: Expected native int or pointer, but got O
		//IL_071c: Expected O, but got I4
		//IL_04ea: Expected O, but got Ref
		//IL_0511: Expected O, but got I
		//IL_0526: Expected native int or pointer, but got O
		//IL_0540: Expected O, but got I
		//IL_0560: Expected O, but got Ref
		//IL_057a: Expected native int or pointer, but got O
		//IL_0739: Expected O, but got I4
		//IL_0592: Expected O, but got Ref
		//IL_05ac: Expected native int or pointer, but got O
		//IL_0763: Expected O, but got I
		//IL_065e: Expected O, but got I
		//IL_0673: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitWeapon(characterController, weaponType);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "vfx", "summon2");
		PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene2._renderer;
			int depth = -renderer.pixelHeight;
			PhaserSprite summonSprite = phaserSprite2.setDepth(depth);
			_summonSprite = summonSprite;
			GameObject gameObject = base.gameObject;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rbx_v6 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			_ = 0;
			ParticleEmitterManager particlesManager;
			if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 200))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C8]");
				particlesManager = (ParticleEmitterManager)0;
			}
			else
			{
				particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
			}
			_particlesManager = particlesManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxGray1");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxGray2");
			}
			else
			{
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version3 = list._version + 1;
			list._version = version3;
			string[] items3 = list._items;
			if (list._size >= items3.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxPurple2");
			}
			else
			{
				int size3 = list._size + 1;
				list._size = size3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version4 = list._version + 1;
			list._version = version4;
			string[] items4 = list._items;
			if (list._size >= items4.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxPurple3");
			}
			else
			{
				int size4 = list._size + 1;
				list._size = size4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(100f, 200f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 2;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C8]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(400f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
			_ = 0;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
			PfxEmitter = pfxEmitter;
			GravityWellConfig gravityWellConfig = new GravityWellConfig();
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C8]");
			gravityWellConfig._y = (float?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C8]");
			gravityWellConfig._x = (float?)(object)0;
			gravityWellConfig._power = 1f;
			gravityWellConfig._epsilon = 50f;
			gravityWellConfig._gravity = 20f;
			GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
			_well = well;
			return;
		}
		throw new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		//IL_01c4: Expected I, but got O
		//IL_01d2: Expected I, but got O
		//IL_01e2: Expected O, but got I
		//IL_0262: Expected O, but got I4
		//IL_021e: Expected O, but got I
		//IL_0254: Expected O, but got I4
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		Weapon weapon;
		Weapon weapon2;
		object obj5;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
				if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
				{
					return;
				}
				GameManager core = GM.Core;
				bool allowDuplicates = default(bool);
				weapon = core._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
				bool flag = (object)weapon == null;
				weapon2 = null;
				if (!flag)
				{
					nint num = (nint)weapon;
					nint num2 = (nint)typeof(ShadowServantCounterWeapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.ShadowServantCounterWeapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.ShadowServantCounterWeapon>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rax_v47+FFFFFFF8+v534 @ rax_v43*8]");
						if (0 == (nint)typeof(ShadowServantCounterWeapon))
						{
							obj5 = 1;
							goto IL_0303;
						}
					}
					obj5 = 0;
					goto IL_0303;
				}
				goto IL_032a;
			}
		}
		goto IL_02c6;
		IL_032a:
		if ((object)weapon2 != null && ((UnityEngine.Object)weapon2).m_CachedPtr != (IntPtr)0)
		{
			_counterWeapon = (ShadowServantCounterWeapon)weapon2;
			while (((Equipment)weapon2)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
			{
				bool flag2 = weapon2.LevelUp();
			}
		}
		goto IL_02c6;
		IL_0303:
		bool flag3 = obj5 == null;
		weapon2 = null;
		if (!flag3)
		{
			weapon2 = weapon;
		}
		goto IL_032a;
		IL_02c6:
		CheckBeginningArcana();
	}

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		ShadowServantCounterWeapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
		SummonAnimation();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		if ((object)_summonSprite != null)
		{
			Transform transform = _summonSprite.transform;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform2 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag4 = (object)_well == null;
					Transform transform3 = _well.transform;
					bool flag5 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
					Transform transform4 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
					bool flag6 = (object)transform4 == null;
					bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
					bool flag8 = (object)transform3 == null;
					bool flag9 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SummonAnimation()
	{
		//IL_001a: Expected O, but got I4
		//IL_00c4: Expected I, but got O
		//IL_0124: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		PhaserSprite phaserSprite = _summonSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: true);
		PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(1f);
		if (_summonTween != null)
		{
			_summonTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_summonSprite != null)
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
		float num2 = base.PArea();
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween summonTween = Tweens.Add(tweenConfig);
		_summonTween = summonTween;
	}
}
