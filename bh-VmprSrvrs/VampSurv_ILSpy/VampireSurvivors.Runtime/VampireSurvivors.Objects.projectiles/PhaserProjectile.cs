using System;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class PhaserProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public float alphaMul;

		public PhaserProjectile _003C_003E4__this;

		internal void _003CInitProjectile_003Eb__0()
		{
			PhaserProjectile phaserProjectile = _003C_003E4__this;
			float alpha = alphaMul * 0.65f;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(phaserProjectile._whiteSprite, alpha);
			PhaserProjectile phaserProjectile2 = _003C_003E4__this;
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(phaserProjectile2._whiteSprite, phaserProjectile2.heigthScale, phaserProjectile2.whiteScale);
			ArcadeSprite arcadeSprite = _003C_003E4__this.setAlpha(alpha);
			PhaserProjectile phaserProjectile3 = _003C_003E4__this;
			BaseBody body = phaserProjectile3.body;
			body._enable = true;
			_003C_003E4__this.SetSelfColor();
			_003C_003E4__this.SetSelfScale();
		}

		internal void _003CInitProjectile_003Eb__1()
		{
			PhaserProjectile phaserProjectile = _003C_003E4__this;
			BaseBody body = phaserProjectile.body;
			body._enable = false;
		}

		internal void _003CInitProjectile_003Eb__2()
		{
			_003C_003E4__this.Despawn();
		}
	}

	private SpriteRenderer _whiteSprite;

	private bool _alreadyRecycled;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _scaleTween;

	private PhaserWeapon _trueWeapon;

	private Transform _cachedSpriteTransform;

	protected float _screenScale = 100f;

	protected float _scaleDuration = 200f;

	protected float _projectileScale = 36f;

	protected float heigthScale = 0.35f;

	protected float whiteScale = 0.65f;

	protected uint[] _colors = new uint[4] { 16711680u, 16776960u, 255u, 16711935u };

	protected override void Awake()
	{
		base.Awake();
		_alreadyRecycled = false;
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_renderer).SetMaterial(material);
		float num = heigthScale * 0.65f;
		whiteScale = num;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_whiteSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_whiteSprite, heigthScale, whiteScale);
		Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_whiteSprite).SetMaterial(material2);
		Transform cachedSpriteTransform = _whiteSprite.transform;
		_cachedSpriteTransform = cachedSpriteTransform;
		Setuppo();
	}

	protected virtual void Setuppo()
	{
		_screenScale = 100f;
		_scaleDuration = 200f;
		_projectileScale = 18f;
		heigthScale = 0.35f;
		whiteScale = 0.65f;
		_colors = new uint[4] { 16711680u, 16776960u, 255u, 16711935u };
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0097: Expected I, but got O
		//IL_009f: Expected I4, but got O
		//IL_00af: Expected O, but got I
		//IL_012f: Expected O, but got I4
		//IL_00eb: Expected O, but got I
		//IL_0121: Expected O, but got I4
		//IL_023e: Invalid comparison between I4 and F4
		//IL_0285: Expected O, but got I4
		//IL_01f2: Expected O, but got I4
		//IL_030a: Expected I, but got O
		//IL_0380: Expected O, but got I4
		//IL_0434: Expected I, but got O
		//IL_048c: Expected I, but got O
		//IL_04e2: Expected O, but got I4
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals12._003C_003E4__this = this;
		int index2 = default(int);
		base.InitProjectile(pool, weapon, index2);
		if (_alreadyRecycled)
		{
			return;
		}
		Weapon weapon2 = _weapon;
		_alreadyRecycled = true;
		PhaserWeapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_0585;
		}
		nint num = (nint)typeof(PhaserWeapon);
		index2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ r8_v55 (Il2CppClass<VampireSurvivors.Objects.Weapons.PhaserWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v7 (System.Int32)+130]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ r8_v55 (Il2CppClass<VampireSurvivors.Objects.Weapons.PhaserWeapon>)+130]");
		object obj3;
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v7 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rax_v120+FFFFFFF8+v507 @ rax_v115*8]");
			if (0 == (nint)typeof(PhaserWeapon))
			{
				obj3 = 1;
				goto IL_0594;
			}
		}
		obj3 = 0;
		goto IL_0594;
		IL_0585:
		_trueWeapon = trueWeapon;
		float num3 = weapon.PAmount();
		CS_0024_003C_003E8__locals12.alphaMul = 1f;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int num4;
		int num5 = default(int);
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			_whiteSprite.enabled = true;
			Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
			((Renderer)_renderer).SetMaterial(material);
			num4 = num5;
			object obj4 = 0;
		}
		else
		{
			_whiteSprite.enabled = false;
			CS_0024_003C_003E8__locals12.alphaMul = 0.5f;
			num4 = _indexInWeapon;
			float num6 = (float)num5 * 0.5f;
			bool flag = (float)_indexInWeapon > num6;
			BlendMode blendMode = BlendMode.Screen;
			if (!flag)
			{
				blendMode = BlendMode.Normal;
			}
			SpriteRenderer spriteRenderer = RenderingExtensions.SetBlendMode(_renderer, blendMode);
			object obj4 = 0;
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			nint num7 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		float num8 = _trueWeapon.PArea();
		float num9 = (float)num4 * _projectileScale;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.duration = _scaleDuration;
		TweenCallback onStart = delegate
		{
			PhaserProjectile phaserProjectile = CS_0024_003C_003E8__locals12._003C_003E4__this;
			float alpha = CS_0024_003C_003E8__locals12.alphaMul * 0.65f;
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(phaserProjectile._whiteSprite, alpha);
			PhaserProjectile phaserProjectile2 = CS_0024_003C_003E8__locals12._003C_003E4__this;
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(phaserProjectile2._whiteSprite, phaserProjectile2.heigthScale, phaserProjectile2.whiteScale);
			ArcadeSprite arcadeSprite = CS_0024_003C_003E8__locals12._003C_003E4__this.setAlpha(alpha);
			PhaserProjectile phaserProjectile3 = CS_0024_003C_003E8__locals12._003C_003E4__this;
			BaseBody baseBody = phaserProjectile3.body;
			baseBody._enable = true;
			CS_0024_003C_003E8__locals12._003C_003E4__this.SetSelfColor();
			CS_0024_003C_003E8__locals12._003C_003E4__this.SetSelfScale();
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		nint num10 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj6 = default(object);
		if (obj6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_whiteSprite != null)
			{
				nint num11 = (nint)array2;
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
			tweenConfig2.alpha = (float?)(object)1;
			tweenConfig2.delay = _scaleDuration;
			tweenConfig2.duration = 100f;
			TweenCallback onStart2 = delegate
			{
				PhaserProjectile phaserProjectile = CS_0024_003C_003E8__locals12._003C_003E4__this;
				BaseBody baseBody = phaserProjectile.body;
				baseBody._enable = false;
			};
			tweenConfig2.onStart = onStart2;
			TweenCallback onComplete = delegate
			{
				CS_0024_003C_003E8__locals12._003C_003E4__this.Despawn();
			};
			tweenConfig2.onComplete = onComplete;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
			_alphaTween = alphaTween;
			return;
		}
		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
		throw ex3;
		IL_0594:
		bool flag2 = obj3 == null;
		trueWeapon = null;
		if (!flag2)
		{
			trueWeapon = (PhaserWeapon)_weapon;
		}
		goto IL_0585;
	}

	public virtual void SetSelfColor()
	{
		uint[] colors = _colors;
		int num = _indexInWeapon % colors.Length;
		ArcadeSprite arcadeSprite = setTint(colors[num]);
	}

	public virtual void SetSelfScale()
	{
		//IL_0011: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(heigthScale, (float?)(object)0);
	}

	public override void Despawn()
	{
		//IL_0064: Expected O, but got I4
		base.Despawn();
		BaseBody baseBody = body;
		baseBody._enable = false;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_whiteSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_whiteSprite, 0f);
		ArcadeSprite arcadeSprite = setAlpha(0f);
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		_alreadyRecycled = false;
	}

	public override void InternalUpdate()
	{
		//IL_0029->IL004c: Incompatible stack heights: 1 vs 0
		Transform cachedSpriteTransform = _cachedSpriteTransform;
		if ((object)_cachedSpriteTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr, ref value);
			int num = base.depth;
			if ((object)_whiteSprite != null)
			{
				int sortingOrder = num - 1;
				_whiteSprite.sortingOrder = sortingOrder;
				return;
			}
		}
		throw new NullReferenceException();
	}
}
