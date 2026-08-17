using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_GrandCross2_BeamProjectile : Projectile
{
	private PhaserSprite _beamSprite;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private TP_GrandCross2_Weapon _trueWeapon;

	protected override void Awake()
	{
		base.Awake();
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
			if ((object)_renderer != null)
			{
				_renderer.sprite = sprite;
				if ((object)_renderer != null)
				{
					_renderer.enabled = false;
					SpriteTextures.SpriteTexturesBase spriteTexturesBase2 = SpriteTextures.Base;
					if (SpriteTextures.Base != null && spriteTexturesBase2.Vfx != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F82C]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						GameObject gameObject = base.gameObject;
						Vector2 pos = default(Vector2);
						PhaserSprite beamSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "HolyBeamGradient");
						_beamSprite = beamSprite;
						if ((object)_beamSprite != null)
						{
							Transform transform = _beamSprite.transform;
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							PhaserSprite phaserSprite = _beamSprite.setVisible(visible: true);
							PhaserSprite phaserSprite2 = _beamSprite.setAlpha(0f);
							PhaserSprite phaserSprite3 = _beamSprite.setBlendMode(BlendMode.Add);
							PhaserSprite phaserSprite4 = _beamSprite.setDepth(2);
							GameObject gameObject2 = _beamSprite.gameObject;
							((UnityEngine.Object)gameObject2).SetName("GrandCross2Beam");
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002c: Expected I, but got O
		//IL_0034: Expected I, but got O
		//IL_0044: Expected O, but got I
		//IL_00c4: Expected O, but got I4
		//IL_0080: Expected O, but got I
		//IL_00b6: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		//IL_0144: Expected O, but got F4
		//IL_0168: Expected O, but got I4
		//IL_017c: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		TP_GrandCross2_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_01cd;
		}
		nint num = (nint)typeof(TP_GrandCross2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_GrandCross2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_GrandCross2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v23+FFFFFFF8+v69 @ rax_v18*8]");
			if (0 == (nint)typeof(TP_GrandCross2_Weapon))
			{
				obj3 = 1;
				goto IL_01dc;
			}
		}
		obj3 = 0;
		goto IL_01dc;
		IL_01dc:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (TP_GrandCross2_Weapon)_weapon;
		}
		goto IL_01cd;
		IL_01cd:
		_trueWeapon = trueWeapon;
		TP_GrandCross2_Weapon trueWeapon2 = _trueWeapon;
		Rectangle pfxRect = trueWeapon2._pfxRect;
		float num4 = pfxRect._width * 100f;
		BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
		object obj4 = num4 ^ -0f;
		float x = (float)obj4 * 0.5f;
		BaseBody baseBody2 = body.setOffset(x, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)1);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 246 Invalid \"Jump target not found in method: 0x187103A50\"");
		throw new NullReferenceException();
	}

	private void DoTweens()
	{
		//IL_00aa: Expected I, but got O
		//IL_011c: Expected O, but got I4
		//IL_0137: Expected I, but got O
		//IL_0202: Expected I, but got O
		//IL_0282: Expected O, but got I4
		PhaserSprite phaserSprite = _beamSprite.setAlpha(0f);
		PhaserSprite phaserSprite2 = _beamSprite.setTint(16777215u);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.ease = Ease.OutSine;
		tweenConfig.scaleX = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GrandCross2_BeamProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		int numActiveBeams = GetNumActiveBeams();
		float num3 = (float)numActiveBeams + 1f;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_beamSprite != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 250f;
		tweenConfig2.ease = Ease.OutSine;
		tweenConfig2.yoyo = true;
		tweenConfig2.alpha = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
		_alphaTween = alphaTween;
	}

	private int GetNumActiveBeams()
	{
		Weapon weapon = _weapon;
		int result = 0;
		List<Projectile>.Enumerator enumerator = default(List<Projectile>.Enumerator);
		if (enumerator.MoveNext())
		{
			TP_GrandCross2_BeamProjectile tP_GrandCross2_BeamProjectile = null;
			TP_GrandCross2_BeamProjectile tP_GrandCross2_BeamProjectile2 = null;
			throw new NullReferenceException();
		}
		return result;
	}

	public override void InternalUpdate()
	{
		//IL_002d: Expected O, but got I4
		//IL_002d: Expected F4, but got O
		float2 beamScale = _trueWeapon.BeamScale;
		PhaserSprite phaserSprite = _beamSprite.setScale((float)beamScale, (float?)(object)1);
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
	}

	private void UpdateBeamSprite()
	{
		//IL_002d: Expected O, but got I4
		//IL_002d: Expected F4, but got O
		float2 beamScale = _trueWeapon.BeamScale;
		PhaserSprite phaserSprite = _beamSprite.setScale((float)beamScale, (float?)(object)1);
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		base.position = float5;
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Despawn();
	}
}
