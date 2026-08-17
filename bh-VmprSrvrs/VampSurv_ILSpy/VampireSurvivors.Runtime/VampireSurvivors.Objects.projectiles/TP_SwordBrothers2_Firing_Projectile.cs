using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_SwordBrothers2_Firing_Projectile : Projectile
{
	private const float Radius = 36f;

	private Tween _scaleTween;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_007d: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(36f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 89 Invalid \"Jump target not found in method: 0x18718E090\"");
		throw new NullReferenceException();
	}

	private void ScaleUp()
	{
		//IL_0080: Expected I, but got O
		float num = _weapon.PArea();
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		float endValue = default(float);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SwordBrothers2_Firing_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore;
	}

	public override void Despawn()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		base.Despawn();
	}
}
