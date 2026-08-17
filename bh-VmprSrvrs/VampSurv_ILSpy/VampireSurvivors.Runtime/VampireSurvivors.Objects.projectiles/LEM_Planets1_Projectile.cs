using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LEM_Planets1_Projectile : Projectile
{
	private LEM_Planets1_Weapon _trueWeapon;

	private LEM_Planets1_Weapon.PlanetData _planetData;

	private PhaserSprite _planetSprite;

	private PhaserSprite _negativePlanetSprite;

	private float _angle;

	private float _areaMultiplierMultiplier;

	private float _speedMultiplier;

	private bool _wasMovingRight;

	private Tween _scaleTween;

	private Tween _speedTween;

	private Tween _negativeAlphaTween;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private float SpeedModifier
	{
		get
		{
			int num;
			if (_indexInWeapon <= 0)
			{
				if (_indexInWeapon != 0)
				{
					goto IL_0081;
				}
				num = 3;
			}
			else
			{
				num = _indexInWeapon - 1;
				if (_indexInWeapon > 3)
				{
					goto IL_0081;
				}
			}
			goto IL_0090;
			IL_0090:
			float num2 = _weapon.PSpeed();
			float num3 = (float)num * 3f;
			float num4 = num3 + 90f;
			object obj = default(object);
			float num5 = num4 * (float)obj;
			return num5 * _speedMultiplier;
			IL_0081:
			num = _indexInWeapon;
			goto IL_0090;
		}
	}

	private float XOrbitModifier
	{
		get
		{
			//IL_0098: Expected I, but got O
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_00d5: Expected O, but got I4
			int num;
			if (_indexInWeapon <= 0)
			{
				if (_indexInWeapon != 0)
				{
					goto IL_0081;
				}
				num = 3;
			}
			else
			{
				num = _indexInWeapon - 1;
				if (_indexInWeapon > 3)
				{
					goto IL_0081;
				}
			}
			goto IL_00f1;
			IL_00f1:
			Weapon weapon = _weapon;
			nint num2 = (nint)weapon;
			float num3 = weapon.PArea();
			object obj = default(object);
			object obj2;
			if (0 <= (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm1,xmm0\"");
				obj2 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
				obj2 = obj;
			}
			object obj3 = obj2 * _areaMultiplierMultiplier;
			float num4 = (float)num * 0.1f;
			float num5 = num4 + 0.25f;
			return num5 * (float)obj3;
			IL_0081:
			num = _indexInWeapon;
			goto IL_00f1;
		}
	}

	private float YOrbitModifier
	{
		get
		{
			//IL_0098: Expected I, but got O
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_00d5: Expected O, but got I4
			int num;
			if (_indexInWeapon <= 0)
			{
				if (_indexInWeapon != 0)
				{
					goto IL_0081;
				}
				num = 3;
			}
			else
			{
				num = _indexInWeapon - 1;
				if (_indexInWeapon > 3)
				{
					goto IL_0081;
				}
			}
			goto IL_00f1;
			IL_00f1:
			Weapon weapon = _weapon;
			nint num2 = (nint)weapon;
			float num3 = weapon.PArea();
			object obj = default(object);
			object obj2;
			if (0 <= (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm2,xmm0\"");
				obj2 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
				obj2 = obj;
			}
			object obj3 = obj2 * _areaMultiplierMultiplier;
			float num4 = (float)num * 0.06f;
			return num4 * (float)obj3;
			IL_0081:
			num = _indexInWeapon;
			goto IL_00f1;
		}
	}

	private bool IsMovingRight
	{
		get
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected O, but got Unknown
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,dword ptr [rcx+130h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
			IntPtr intPtr = default(IntPtr);
			object obj2 = default(object);
			object obj = (nint)intPtr + obj2;
			object obj3 = obj >> 8;
			object obj4 = obj3 >> 31;
			object obj5 = obj3 + obj4;
			object obj6 = obj5 * 360;
			object obj7 = obj2 - obj6;
			object obj8 = obj7 - 180;
			object obj9 = obj7 ^ 0xB4;
			object obj10 = obj7 ^ obj8;
			object obj11 = obj9 & obj10;
			bool flag = (nint)obj11 < 0;
			bool flag2 = (nint)obj8 < 0;
			bool flag3 = obj8 == null;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
	}

	private float AreaMultiplier
	{
		get
		{
			//IL_0017: Expected I, but got O
			Weapon weapon = _weapon;
			nint num = (nint)weapon;
			float num2 = weapon.PArea();
			object obj = default(object);
			if (0 <= (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
				return (float)obj * _areaMultiplierMultiplier;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			return (float)obj * _areaMultiplierMultiplier;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		GenerateParticleSystem();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite planetSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "WhiteDot");
			_planetSprite = planetSprite;
			SpriteTextures.SpriteTexturesBase spriteTexturesBase2 = SpriteTextures.Base;
			if (spriteTexturesBase2.Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				GameObject gameObject2 = base.gameObject;
				PhaserSprite negativePlanetSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", "WhiteDot");
				_negativePlanetSprite = negativePlanetSprite;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0567: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0118: Expected O, but got I
		//IL_012d: Expected O, but got I4
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_014e: Expected O, but got I
		//IL_0209: Expected O, but got I
		//IL_0230: Expected O, but got I4
		//IL_0230: Expected O, but got I4
		//IL_0230: Expected F4, but got I
		//IL_0244: Expected O, but got I
		//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Expected O, but got Unknown
		//IL_060c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Expected O, but got Unknown
		//IL_02d8: Expected O, but got I
		//IL_02d8: Expected O, but got I
		//IL_0312: Expected O, but got I4
		//IL_0312: Expected F4, but got I
		//IL_02a5: Expected O, but got I8
		//IL_0364: Expected O, but got I
		//IL_0364: Expected O, but got I
		//IL_039e: Expected O, but got I4
		//IL_039e: Expected F4, but got I
		//IL_03ea: Expected O, but got I4
		//IL_040d: Expected O, but got I4
		//IL_0450: Expected I, but got O
		//IL_0467: Invalid comparison between I4 and F4
		//IL_0434: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0540;
		}
		nint num = (nint)typeof(LEM_Planets1_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v39 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v39 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v83+FFFFFFF8+v70 @ rax_v78*8]");
			if (0 == (nint)typeof(LEM_Planets1_Weapon))
			{
				obj3 = 1;
				goto IL_054f;
			}
		}
		obj3 = 0;
		goto IL_054f;
		IL_054f:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0540;
		IL_0540:
		_trueWeapon = (LEM_Planets1_Weapon)trueWeapon;
		LEM_Planets1_Weapon trueWeapon2 = _trueWeapon;
		List<LEM_Planets1_Weapon.PlanetData> list = trueWeapon2._003CPlanetList_003Ek__BackingField;
		int indexInWeapon = _indexInWeapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
		if ((nint)indexInWeapon < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+10]");
			object obj4 = 0;
			object obj5 = _indexInWeapon * 8;
			object obj6 = _indexInWeapon + obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdx_v9+20+v653 @ rcx_v13*8]");
			_planetData = (LEM_Planets1_Weapon.PlanetData)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdx_v9+30+v653 @ rcx_v13*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdx_v9+40+v653 @ rcx_v13*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdx_v9+50+v653 @ rcx_v13*8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rdx_v9+60+v653 @ rcx_v13*8]");
			_ = 0;
			LEM_Planets1_Weapon trueWeapon3 = _trueWeapon;
			_isCullable = false;
			Transform transform = base.transform;
			transform.SetParent(trueWeapon3._PlanetContainer, worldPositionStays: true);
			BaseBody baseBody = body;
			_areaMultiplierMultiplier = 1f;
			_speedMultiplier = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+114]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj7 = num4 ^ 0;
			BaseBody baseBody2 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+114]");
			BaseBody baseBody3 = baseBody2.setCircle(0f, (float?)(object)1, (float?)(object)1);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj8 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				baseBody = (BaseBody)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v819 @ rax_v24 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
			_angle = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
			object obj9 = (object)baseBody + (object)baseBody;
			object obj10 = obj9 >> 8;
			object obj11 = obj10 >> 31;
			object obj12 = obj10 + obj11;
			object obj13 = obj12 * 360;
			object obj14 = (object)baseBody - obj13;
			object obj15 = obj14 - 180;
			object obj16 = obj14 ^ 0xB4;
			object obj17 = obj14 ^ obj15;
			object obj18 = obj16 & obj17;
			bool flag2 = (nint)obj18 < 0;
			bool flag3 = (nint)obj15 < 0;
			bool flag4 = obj15 == null;
			bool flag5 = flag3 == flag2;
			bool flag6 = !flag4;
			bool wasMovingRight = flag6 & flag5;
			_wasMovingRight = wasMovingRight;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4B0A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			PhaserSprite planetSprite = _planetSprite;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+E0]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+E8]");
			PhaserSprite phaserSprite = planetSprite.setFrame((string)num5, (string)0);
			PhaserSprite phaserSprite2 = phaserSprite.setAlpha(1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+110]");
			PhaserSprite phaserSprite3 = phaserSprite2.setScale(0f, (float?)(object)0);
			GameObject gameObject = phaserSprite3.gameObject;
			((UnityEngine.Object)gameObject).SetName((string)_planetData);
			PhaserSprite negativePlanetSprite = _negativePlanetSprite;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+F0]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+E8]");
			PhaserSprite phaserSprite4 = negativePlanetSprite.setFrame((string)num6, (string)0);
			PhaserSprite phaserSprite5 = phaserSprite4.setAlpha(0f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+110]");
			PhaserSprite phaserSprite6 = phaserSprite5.setScale(0f, (float?)(object)0);
			string text = (string)_planetData + "_Negative";
			GameObject gameObject2 = phaserSprite6.gameObject;
			((UnityEngine.Object)gameObject2).SetName(text);
			ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
			bool flag7 = _scaleTween == null;
			float? num7 = (float?)(object)0;
			if (!flag7)
			{
				TweenExtensions.Kill(_scaleTween);
				num7 = (float?)(object)0;
			}
			Weapon weapon3 = _weapon;
			nint num8 = (nint)weapon3;
			float num9 = weapon3.PArea();
			if (!(0f > 1f))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			}
			float endValue = 1f * _areaMultiplierMultiplier;
			TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.25f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_scaleTween = scaleTween;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void InitPosition()
	{
		//IL_0010: Expected O, but got I
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_0076: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		LEM_Planets1_Projectile lEM_Planets1_Projectile = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			lEM_Planets1_Projectile = (LEM_Planets1_Projectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v46 @ rax_v2 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		_angle = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		IntPtr intPtr = default(IntPtr);
		object obj2 = (nint)intPtr + lEM_Planets1_Projectile;
		object obj3 = obj2 >> 8;
		object obj4 = obj3 >> 31;
		object obj5 = obj3 + obj4;
		object obj6 = obj5 * 360;
		object obj7 = (object)lEM_Planets1_Projectile - obj6;
		object obj8 = obj7 - 180;
		object obj9 = obj7 ^ 0xB4;
		object obj10 = obj7 ^ obj8;
		object obj11 = obj9 & obj10;
		bool flag2 = (nint)obj11 < 0;
		bool flag3 = (nint)obj8 < 0;
		bool flag4 = obj8 == null;
		bool flag5 = flag3 == flag2;
		bool flag6 = !flag4;
		bool wasMovingRight = flag6 & flag5;
		_wasMovingRight = wasMovingRight;
	}

	private void InitSprites()
	{
		//IL_0056: Expected O, but got I
		//IL_0056: Expected O, but got I
		//IL_0090: Expected O, but got I4
		//IL_0090: Expected F4, but got I
		//IL_00e2: Expected O, but got I
		//IL_00e2: Expected O, but got I
		//IL_011c: Expected O, but got I4
		//IL_011c: Expected F4, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4B0A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite planetSprite = _planetSprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+E0]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+E8]");
		PhaserSprite phaserSprite = planetSprite.setFrame((string)num, (string)0);
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+110]");
		PhaserSprite phaserSprite3 = phaserSprite2.setScale(0f, (float?)(object)0);
		GameObject gameObject = phaserSprite3.gameObject;
		((UnityEngine.Object)gameObject).SetName((string)_planetData);
		PhaserSprite negativePlanetSprite = _negativePlanetSprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+F0]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+E8]");
		PhaserSprite phaserSprite4 = negativePlanetSprite.setFrame((string)num2, (string)0);
		PhaserSprite phaserSprite5 = phaserSprite4.setAlpha(0f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+110]");
		PhaserSprite phaserSprite6 = phaserSprite5.setScale(0f, (float?)(object)0);
		string text = (string)_planetData + "_Negative";
		GameObject gameObject2 = phaserSprite6.gameObject;
		((UnityEngine.Object)gameObject2).SetName(text);
	}

	private void TweenIn()
	{
		//IL_0010: Expected O, but got I4
		//IL_002e: Expected O, but got I4
		//IL_0071: Expected I, but got O
		//IL_0055: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		bool flag = _scaleTween == null;
		float? num = (float?)(object)0;
		if (!flag)
		{
			TweenExtensions.Kill(_scaleTween);
			num = (float?)(object)0;
		}
		Weapon weapon = _weapon;
		nint num2 = (nint)weapon;
		float num3 = weapon.PArea();
		object obj = default(object);
		if (0 <= (nint)obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		float endValue = (float)obj * _areaMultiplierMultiplier;
		TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.25f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = scaleTween;
	}

	private int GetModifiedIndex()
	{
		int num = _indexInWeapon;
		if (_indexInWeapon <= 0)
		{
			if (num == 0)
			{
				return 3;
			}
		}
		else if (_indexInWeapon <= 3)
		{
			num--;
		}
		return num;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0017: Expected I, but got O
		//IL_007f: Expected O, but got I4
		//IL_00ff: Expected O, but got Ref
		//IL_0394: Expected O, but got I
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_0402: Expected O, but got I4
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02e7: Expected I4, but got O
		//IL_02f5: Expected O, but got I4
		//IL_0206: Expected O, but got I4
		//IL_0221: Expected I4, but got O
		//IL_022f: Expected O, but got I4
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		Weapon weapon = _weapon;
		nint num = (nint)weapon;
		float num2 = weapon.PArea();
		object obj = default(object);
		if (0 <= (nint)obj)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		float xScale = (float)obj * _areaMultiplierMultiplier;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		UpdatePosition();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v5 (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+118]");
		if ((nint)0 == 0)
		{
			float num3 = _angle * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		}
		Transform transform = _cachedTransform.transform;
		object obj2 = default(object);
		transform.localEulerAngles = (Vector3)(&obj2);
		int num4;
		if (_indexInWeapon <= 0)
		{
			if (_indexInWeapon != 0)
			{
				goto IL_0180;
			}
			num4 = 3;
		}
		else
		{
			num4 = _indexInWeapon - 1;
			if (_indexInWeapon > 3)
			{
				goto IL_0180;
			}
		}
		goto IL_035b;
		IL_035b:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,dword ptr [rbx+130h]\"");
		int num5 = num4 + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		int num6 = -num5;
		object obj3 = (nint)(&obj2) >> 8;
		object obj4 = obj3 >> 31;
		object obj5 = obj3 + obj4;
		object obj6 = obj5 * 360;
		object obj7 = 0 - obj6;
		if ((nint)obj7 <= 180)
		{
			num6 = num5;
		}
		PhaserSprite phaserSprite = _planetSprite.setDepth(num6);
		PhaserSprite phaserSprite2 = _negativePlanetSprite;
		int num7 = num6 + 1;
		PhaserSprite phaserSprite3 = _negativePlanetSprite.setDepth(num7);
		bool flag = !_wasMovingRight;
		object obj8 = 0;
		bool wasMovingRight;
		int num8;
		object obj11;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,dword ptr [rbx+130h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
			object obj9 = num7 >> 8;
			object obj10 = obj9 >> 31;
			num7 = (int)(obj9 + obj10);
			phaserSprite2 = (PhaserSprite)(num7 * 360);
			obj8 = 0 - phaserSprite2;
			if ((nint)obj8 > 180)
			{
				goto IL_034f;
			}
			wasMovingRight = !_wasMovingRight;
			bool flag2 = _wasMovingRight;
			obj11 = obj8;
			num8 = num7;
			if (flag2)
			{
				goto IL_0410;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rbx+130h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj12 = num7 + phaserSprite2;
		object obj13 = obj12 >> 8;
		object obj14 = obj13 >> 31;
		num8 = (int)(obj13 + obj14);
		object obj15 = num8 * 360;
		object obj16 = (object)phaserSprite2 - obj15;
		if ((nint)obj16 <= 180)
		{
			goto IL_034f;
		}
		wasMovingRight = !_wasMovingRight;
		obj11 = obj8;
		goto IL_0410;
		IL_0410:
		_wasMovingRight = wasMovingRight;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		goto IL_034f;
		IL_0180:
		num4 = _indexInWeapon;
		goto IL_035b;
		IL_034f:
		UpdatePfx();
	}

	private void UpdatePosition()
	{
		//IL_006b: Expected I, but got O
		//IL_02ba: Expected I, but got O
		//IL_0149: Expected I, but got O
		//IL_0161: Invalid comparison between I4 and F4
		//IL_0215: Expected I, but got O
		//IL_022d: Invalid comparison between I4 and F4
		if (_indexInWeapon <= 0)
		{
			if (_indexInWeapon != 0)
			{
			}
		}
		else if (_indexInWeapon > 3)
		{
			goto IL_0063;
		}
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			goto IL_0063;
		}
		goto IL_027c;
		IL_0141:
		Weapon weapon2 = default(Weapon);
		nint num = (nint)weapon2;
		float num2 = _weapon.PArea();
		float num3;
		if (!(0f > num3))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		if (_indexInWeapon <= 0)
		{
			if (_indexInWeapon != 0)
			{
			}
		}
		else if (_indexInWeapon <= 3)
		{
		}
		Weapon weapon3 = _weapon;
		if ((object)_weapon != null)
		{
			nint num4 = (nint)weapon3;
			float num5 = _weapon.PArea();
			if (!(0f > num3))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			}
			object cachedTransform = _cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdi_v7 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdi_v7 (System.Object)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected((IntPtr)0, ref value);
			return;
		}
		goto IL_027c;
		IL_027c:
		throw new NullReferenceException();
		IL_0063:
		nint num6 = (nint)weapon;
		float num7 = _weapon.PSpeed();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm6,esi\"");
		float num8 = 0f * 3f;
		float num9 = num8 + 90f;
		object obj = default(object);
		float num10 = num9 * (float)obj;
		float num11 = num10 * _speedMultiplier;
		float deltaTime = PauseSystem.DeltaTime;
		float num12 = deltaTime * num11;
		float num13 = num12 + _angle;
		_angle = num13;
		nint num14 = (nint)typeof(Vector2);
		num3 = _angle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		if (_indexInWeapon <= 0)
		{
			if (_indexInWeapon != 0)
			{
			}
		}
		else if (_indexInWeapon > 3)
		{
			goto IL_0141;
		}
		weapon2 = _weapon;
		if ((object)_weapon != null)
		{
			goto IL_0141;
		}
		goto IL_027c;
	}

	private unsafe void UpdateRotation()
	{
		//IL_0071: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v1 (VampireSurvivors.Objects.Projectiles.LEM_Planets1_Projectile)+118]");
		if ((nint)0 == 0)
		{
			float num = _angle * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		}
		Transform transform = _cachedTransform.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void UpdateDepth()
	{
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		int num;
		if (_indexInWeapon <= 0)
		{
			if (_indexInWeapon != 0)
			{
				goto IL_0081;
			}
			num = 3;
		}
		else
		{
			num = _indexInWeapon - 1;
			if (_indexInWeapon > 3)
			{
				goto IL_0081;
			}
		}
		goto IL_00d7;
		IL_00d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,dword ptr [rbx+130h]\"");
		int num2 = num + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		IntPtr intPtr = default(IntPtr);
		object obj2 = default(object);
		object obj = (nint)intPtr + obj2;
		int num3 = -num2;
		object obj3 = obj >> 8;
		object obj4 = obj3 >> 31;
		object obj5 = obj3 + obj4;
		object obj6 = obj5 * 360;
		object obj7 = obj2 - obj6;
		if ((nint)obj7 <= 180)
		{
			num3 = num2;
		}
		PhaserSprite phaserSprite = _planetSprite.setDepth(num3);
		int num4 = num3 + 1;
		PhaserSprite phaserSprite2 = _negativePlanetSprite.setDepth(num4);
		return;
		IL_0081:
		num = _indexInWeapon;
		goto IL_00d7;
	}

	private void UpdateHitBox()
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_0114: Expected I, but got O
		//IL_0122: Expected O, but got I
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_004f: Expected I, but got O
		//IL_005d: Expected O, but got I
		bool flag = !_wasMovingRight;
		LEM_Planets1_Projectile lEM_Planets1_Projectile = this;
		nint num = default(nint);
		object obj2 = default(object);
		bool wasMovingRight;
		nint num2;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,dword ptr [rbx+130h]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
			object obj = num + obj2;
			object obj3 = obj >> 8;
			object obj4 = obj3 >> 31;
			num = (nint)(obj3 + obj4);
			lEM_Planets1_Projectile = (LEM_Planets1_Projectile)(num * 360);
			obj2 -= (object)lEM_Planets1_Projectile;
			if ((nint)obj2 > 180)
			{
				return;
			}
			wasMovingRight = !_wasMovingRight;
			bool flag2 = _wasMovingRight;
			object obj5 = obj2;
			num2 = num;
			if (flag2)
			{
				goto IL_019d;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rbx+130h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj6 = num + lEM_Planets1_Projectile;
		object obj7 = obj6 >> 8;
		object obj8 = obj7 >> 31;
		num2 = (nint)(obj7 + obj8);
		object obj9 = num2 * 360;
		object obj10 = (object)lEM_Planets1_Projectile - obj9;
		if ((nint)obj10 > 180)
		{
			wasMovingRight = !_wasMovingRight;
			object obj5 = obj2;
			goto IL_019d;
		}
		return;
		IL_019d:
		_wasMovingRight = wasMovingRight;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private unsafe void UpdatePfx()
	{
		//IL_000d: Expected I, but got O
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0088: Invalid comparison between F4 and I
		//IL_00af: Expected F4, but got I
		//IL_0148: Expected O, but got Ref
		//IL_0157: Expected O, but got Ref
		//IL_0179: Expected I4, but got O
		//IL_027e: Expected O, but got I4
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected I4, but got Unknown
		//IL_02bd: Expected I4, but got I8
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			nint num = (nint)weapon;
			float num2 = _weapon.PArea();
			if (0 <= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			}
			object obj = 0 * _areaMultiplierMultiplier;
			float num3 = (float)obj * 0.35f;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A101F0]");
			if (num4 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A101F0]");
				num3 = 0f;
			}
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(num3, 0f);
			LEM_Planets1_Weapon trueWeapon = _trueWeapon;
			if ((object)_trueWeapon != null)
			{
				bool flag = trueWeapon._003CIsNegative_003Ek__BackingField;
				uint tint = 0u;
				if (!flag)
				{
					tint = 16777215u;
				}
				if ((object)_pfx != null)
				{
					Transform transform = _pfx.transform;
					if ((object)transform != null)
					{
						object obj2 = default(object);
						transform.localEulerAngles = (Vector3)(&obj2);
						object obj3 = default(object);
						RenderingExtensions.SetScale(_pfx, (ParticleSystem.MinMaxCurve)(&obj3));
						ParticleSystem particleSystem = RenderingExtensions.SetTint(_pfx, tint);
						uint num5 = (uint)(int)_planetSprite;
						if ((object)_planetSprite != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v6 (System.UInt32)+28]");
							uint num6 = 0u;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v6 (System.UInt32)+28]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rbx_v7 (System.UInt32)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rbx_v7 (System.UInt32)+10]");
								object obj4 = Renderer.get_sortingOrder_Injected((IntPtr)0);
								int num7 = obj4 - 1;
								RenderingExtensions.SetDepth(_pfx, num7);
								float2 float5 = base.position;
								Vector2 pos = default(Vector2);
								RenderingExtensions.EmitParticleAt(_pfx, pos, -1);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetNegative(bool enable)
	{
		//IL_002e: Expected F4, but got I4
		float endValue;
		float endValue2;
		float endValue3;
		if (enable)
		{
			endValue = 1f;
			endValue2 = 2f;
			endValue3 = 1.4f;
		}
		else
		{
			endValue = 0f;
			endValue2 = 1f;
			endValue3 = 1f;
		}
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((LEM_Planets1_Projectile)(object)dOSetter)._003CSetNegative_003Eb__35_1(x);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, endValue3, 0.25f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
		if (_speedTween != null)
		{
			TweenExtensions.Kill(_speedTween);
		}
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((LEM_Planets1_Projectile)(object)dOSetter2)._003CSetNegative_003Eb__35_3(x);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, dOSetter2, endValue2, 0.25f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_speedTween = tweenerCore2;
		if (_negativeAlphaTween != null)
		{
			TweenExtensions.Kill(_negativeAlphaTween);
		}
		PhaserSprite negativePlanetSprite = _negativePlanetSprite;
		TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(negativePlanetSprite._spriteRenderer, endValue, 0.25f);
		if (tweenerCore3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_negativeAlphaTween = tweenerCore3;
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_01a3: Expected O, but got Ref
		//IL_01b8: Expected native int or pointer, but got O
		//IL_03ec: Expected O, but got I
		//IL_01f0: Expected O, but got Ref
		//IL_0217: Expected O, but got I
		//IL_0231: Expected native int or pointer, but got O
		//IL_024b: Expected O, but got I
		//IL_026b: Expected O, but got Ref
		//IL_0280: Expected native int or pointer, but got O
		//IL_029a: Expected O, but got I
		//IL_02ba: Expected O, but got Ref
		//IL_02d4: Expected native int or pointer, but got O
		//IL_0426: Expected O, but got I
		//IL_045c: Expected O, but got I
		//IL_04d6: Expected O, but got Ref
		//IL_04c8->IL03d0: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager pfxManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+77]");
			pfxManager = (ParticleEmitterManager)0;
		}
		else
		{
			pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_pfxManager = pfxManager;
		ParticleSystem pfx = _pfx;
		if ((object)_pfx != null && ((UnityEngine.Object)pfx).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"blurredSharpStar");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-79]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-69]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-59]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-39]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-9]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+7]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(400f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-79]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-69]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.75f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+17]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+27]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-31]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-11]");
		_ = 0;
		particleSystemConfig._on = false;
		Transform parent = base.transform;
		ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
		_pfx = pfx2;
		_ = _pfx;
		_ = _pfx;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1330 @ rax_v52 (should have been resolved before IL gen)");
		Transform transform = _pfx.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		if (_speedTween != null)
		{
			TweenExtensions.Kill(_speedTween);
		}
		if (_negativeAlphaTween != null)
		{
			TweenExtensions.Kill(_negativeAlphaTween);
		}
		base.Despawn();
	}

	private float _003CSetNegative_003Eb__35_0()
	{
		return _areaMultiplierMultiplier;
	}

	private void _003CSetNegative_003Eb__35_1(float x)
	{
		_areaMultiplierMultiplier = x;
	}

	private float _003CSetNegative_003Eb__35_2()
	{
		return _speedMultiplier;
	}

	private void _003CSetNegative_003Eb__35_3(float x)
	{
		_speedMultiplier = x;
	}
}
