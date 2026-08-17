using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class GattiScratchProjectile : Projectile
{
	private FrameConfig[] _configs;

	private GattiWeapon _trueWeapon;

	private MultiTargetTween _entryTween;

	private MultiTargetTween _exitTween;

	private int _cfgIndex;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0687: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0139: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		//IL_0171: Expected O, but got I4
		//IL_0291: Expected O, but got I
		//IL_0300: Expected O, but got I4
		//IL_03c1: Expected O, but got I
		//IL_048a: Expected I, but got O
		//IL_050d: Expected O, but got I4
		//IL_0577: Expected I, but got O
		//IL_05e9: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0660;
		}
		nint num = (nint)typeof(GattiWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v59 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v47 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v59 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v47 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v99+FFFFFFF8+v71 @ rax_v94*8]");
			if (0 == (nint)typeof(GattiWeapon))
			{
				obj3 = 1;
				goto IL_066f;
			}
		}
		obj3 = 0;
		goto IL_066f;
		IL_066f:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_0660;
		IL_0660:
		_trueWeapon = (GattiWeapon)trueWeapon;
		if (_exitTween != null)
		{
			_exitTween.Kill();
		}
		if (_entryTween != null)
		{
			_entryTween.Kill();
		}
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(64f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite3 = setAlpha(1f);
		FrameConfig[] configs = _configs;
		int cfgIndex = _cfgIndex + 1;
		_cfgIndex = cfgIndex;
		int num4 = _cfgIndex % configs.Length;
		Weapon weapon2 = _weapon;
		FrameConfig frameConfig = configs[num4];
		Weapon weapon3 = _weapon;
		List<float> critChancesArray = weapon2._critChancesArray;
		int critIndex = weapon3._critIndex + 1;
		weapon3._critIndex = critIndex;
		Weapon weapon4 = _weapon;
		List<float> critChancesArray2 = weapon4._critChancesArray;
		int critIndex2 = weapon3._critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ r9_v10 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num5 = (int)((nint)critIndex2 % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ r8_v14 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num5 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ r8_v14 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rcx_v22+18]");
			bool flag2 = (nint)num5 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
			bool flag3 = !flag2;
			ArcadeSprite arcadeSprite4 = setFlipX(flag3);
			ArcadeSprite arcadeSprite5 = setFrame(frameConfig.frame);
			ArcadeSprite arcadeSprite6 = setOrigin(frameConfig.originX, (float?)(object)1);
			Weapon weapon5 = _weapon;
			Weapon weapon6 = _weapon;
			List<float> critChancesArray3 = weapon5._critChancesArray;
			int critIndex3 = weapon6._critIndex + 1;
			weapon6._critIndex = critIndex3;
			Weapon weapon7 = _weapon;
			List<float> critChancesArray4 = weapon7._critChancesArray;
			int critIndex4 = weapon6._critIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ r9_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num6 = (int)((nint)critIndex4 % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ r8_v19 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num6 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ r8_v19 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rcx_v28+20+v365 @ rdx_v23 (System.Int32)*4]");
				float num7 = 0f * 180f;
				base.angle = num7;
				float2 float5 = base.position;
				float plusMinus = _trueWeapon.GetPlusMinus();
				float num8 = plusMinus * 0.24f;
				float num9 = num8 + frameConfig.originY;
				float2 float6 = default(float2);
				base.position = float6;
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					nint num10 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj6 = default(object);
					if (obj6 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig.targets = array;
				float num11 = _weapon.PArea();
				float num12 = num9 * 0.5f;
				tweenConfig.duration = 120f;
				tweenConfig.scale = (float?)(object)1;
				MultiTargetTween entryTween = Tweens.Add(tweenConfig);
				_entryTween = entryTween;
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				if ((object)_renderer != null)
				{
					nint num13 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj7 = default(object);
					if (obj7 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.delay = 120f;
				tweenConfig2.duration = 100f;
				tweenConfig2.alpha = (float?)(object)1;
				TweenCallback onComplete = delegate
				{
					base.Despawn();
				};
				tweenConfig2.onComplete = onComplete;
				MultiTargetTween exitTween = Tweens.Add(tweenConfig2);
				_exitTween = exitTween;
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
	}

	private void _003CInitProjectile_003Eb__6_0()
	{
		base.Despawn();
	}
}
