using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors;

public class FB_SpreadProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("SpreadshotRed", "firstBlood");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0015: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0060: Expected F4, but got O
		//IL_006d: Invalid comparison between O and F4
		//IL_0140: Expected I, but got O
		//IL_01a4: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
		float num = _weapon.PArea();
		ArcadeSprite arcadeSprite2 = setScale((float)float6, (float?)(object)0);
		float alpha;
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)5f))
		{
			float num2 = (float)float6 - 1f;
			float num3 = num2 / 5f;
			float num4 = 1f - num3;
			float num5 = num4 * 0.65f;
			alpha = num5 + 0.35f;
		}
		else
		{
			alpha = 0.35f;
		}
		ArcadeSprite arcadeSprite3 = setAlpha(alpha);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num6 = (nint)array;
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
		tweenConfig.duration = 50f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	public override void InternalUpdate()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0057: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0172: Expected O, but got F4
		//IL_00b9: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		bool flag = _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE);
		bool flag2 = !flag;
		object obj2 = 0;
		Vector2 vector = (Vector2)19;
		if (!flag2)
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 vector2 = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(vector2);
			obj2 = 0;
			vector = vector2;
		}
		if (_bounces <= 0)
		{
			if (--_penetrating <= 0)
			{
				base.Despawn();
			}
			return;
		}
		int bounces = _bounces - 1;
		_bounces = bounces;
		BaseBody baseBody = body;
		float num = (float)baseBody._velocity * -1f;
		baseBody._velocity = (float2)num;
		BaseBody baseBody2 = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v9 (BaseBody)+74]");
		float num2 = 0f * -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
