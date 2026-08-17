using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Ice0_Projectile : Projectile
{
	private List<string> _frames;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _scaleTween2;

	protected unsafe override void Awake()
	{
		//IL_007e: Expected O, but got F4
		//IL_0056: Expected O, but got Ref
		//IL_008c: Expected O, but got F4
		base.Awake();
		string spriteName = Extensions.PickRnd(_frames);
		Sprite sprite = SpriteManager.GetSprite(spriteName, "ThosePeople");
		_renderer.sprite = sprite;
		object obj = UnityEngine.Random.value;
		Transform transform = _renderer.transform;
		object obj2 = default(object);
		transform.localEulerAngles = (Vector3)(&obj2);
		object obj3 = UnityEngine.Random.value;
		object obj5 = default(object);
		object obj4 = obj5 + obj5;
		float speed = (float)obj4 + 3f;
		_speed = speed;
		ArcadeSprite arcadeSprite = setDepth(3);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0046: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_009e: Expected O, but got I8
		//IL_00c2: Expected O, but got F4
		//IL_0121: Expected I, but got O
		//IL_0185: Expected O, but got I4
		//IL_01ff: Expected I, but got O
		//IL_0271: Expected O, but got I4
		//IL_028c: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite sprite = _sprite;
		float num = _weapon.PArea();
		object obj = default(object);
		float radius = (float)obj * 10f;
		BaseBody baseBody = sprite.body.setCircle(radius, (float?)(object)0, (float?)(object)0);
		ArcadeSprite arcadeSprite = setScale(0.35f, (float?)(object)0);
		_isCullable = false;
		bool flag = _indexInWeapon == 0;
		object obj2 = 1;
		if (!flag)
		{
			obj2 = 4294967295L;
		}
		float num2 = GameManager.ProjectileSpeed * _speed;
		ArcadeSprite sprite2 = _sprite;
		float num3 = num2 * (float)obj2;
		BaseBody baseBody2 = sprite2.body;
		baseBody2._velocity = (float2)num3;
		_ = 0;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num4 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 100f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			if (_scaleTween2 != null)
			{
				_scaleTween2.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.delay = 1000f;
				tweenConfig2.duration = 200f;
				tweenConfig2.scale = (float?)(object)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Ice0_Projectile>)+370]");
				TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
				nint num6 = (nint)this;
				tweenConfig2.onComplete = onComplete;
				MultiTargetTween scaleTween2 = Tweens.Add(tweenConfig2);
				_scaleTween2 = scaleTween2;
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			bool flag = TryFreeze(other);
		}
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_scaleTween2 != null)
		{
			_scaleTween2.Kill();
		}
		base.Despawn();
	}

	public TP_Ice0_Projectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Ice27");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Ice28");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Ice29");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Ice30");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_frames = list;
		base._002Ector();
	}
}
