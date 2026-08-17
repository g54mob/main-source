using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SwordBrothers_Firing_Projectile : Projectile
{
	private MultiTargetTween _alphaTween;

	private bool lockOnOwner = true;

	private PhaserSprite _displaySprite;

	protected override void Awake()
	{
		//IL_00cf: Expected O, but got I4
		//IL_01eb->IL0184: Incompatible stack heights: 1 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Brothers01");
				if ((object)phaserSprite != null)
				{
					PhaserSprite displaySprite = phaserSprite.setOrigin(0.5f, (float?)(object)1);
					_displaySprite = displaySprite;
					if ((object)_displaySprite != null)
					{
						PhaserSprite phaserSprite2 = _displaySprite.setBlendMode(BlendMode.Screen);
						if ((object)_displaySprite != null)
						{
							Transform transform = _displaySprite.transform;
							if ((object)transform != null)
							{
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
								if ((object)_displaySprite != null)
								{
									PhaserSprite phaserSprite3 = _displaySprite.setAlpha(0f);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_008d: Expected O, but got I4
		//IL_008d: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_00d8: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		_speed = 5f;
		PhaserSprite phaserSprite = _displaySprite.setBlendMode(BlendMode.Normal);
		Weapon weapon2 = _weapon;
		float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
		base.position = float5;
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		lockOnOwner = true;
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(20f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _displaySprite.setAlpha(0.35f);
		PhaserSprite phaserSprite3 = _displaySprite.setScale(1f, (float?)(object)0);
	}

	public override void InternalUpdate()
	{
		if (lockOnOwner)
		{
			Weapon weapon = _weapon;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			base.position = float5;
			float2 float6 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		}
	}

	public void SetSwordAngle(float angleValue)
	{
		base.angle = angleValue;
		_displaySprite.angle = angleValue;
	}

	public void ShootOff()
	{
		//IL_008e: Expected O, but got F4
		//IL_010b: Expected I, but got O
		//IL_016f: Expected O, but got I4
		//IL_017d: Expected O, but got I4
		lockOnOwner = false;
		_isCullable = true;
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		float num = cachedTrans.localEulerAngles.z * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num2 = num * 12f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		ArcadeSprite sprite = _sprite;
		float num3 = num * 12f;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num2;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
		{
			nint num4 = (nint)array;
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
		tweenConfig.duration = 125f;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	public override void Despawn()
	{
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		PhaserSprite phaserSprite = _displaySprite.setAlpha(0f);
		base.Despawn();
	}
}
