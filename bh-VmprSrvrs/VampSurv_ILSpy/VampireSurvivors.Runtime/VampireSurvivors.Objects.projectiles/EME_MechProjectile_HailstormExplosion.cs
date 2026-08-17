using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_MechProjectile_HailstormExplosion : Projectile
{
	private SpriteRenderer _GroundVFX;

	private const float Radius = 60f;

	private const float VFXScale = 0.8f;

	private Tween _tween;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00ba: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_0432: Expected O, but got F4
		//IL_046e: Expected O, but got I4
		//IL_0408->IL0310: Incompatible stack heights: 4 vs 0
		base.InitProjectile(pool, weapon, index);
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F66D]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Sprite sprite = SpriteManager.GetSprite("circle", "vfx");
			if ((object)_GroundVFX != null)
			{
				_GroundVFX.sprite = sprite;
				ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
				if (body != null)
				{
					BaseBody baseBody = body.setCircle(60f, (float?)(object)1, (float?)(object)1);
					BaseBody baseBody2 = body;
					if (body != null)
					{
						baseBody2._enable = false;
						_isCullable = false;
						if ((object)_GroundVFX != null)
						{
							Transform transform = _GroundVFX.transform;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rax_v39 (UnityEngine.Transform)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rax_v39 (UnityEngine.Transform)+10]");
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected((IntPtr)0, ref value);
							Transform transform2 = _GroundVFX.transform;
							bool flag2 = (object)transform2 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ rax_v47 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ rax_v47 (UnityEngine.Transform)+10]");
							float value2 = default(float);
							Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value2));
							SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundVFX, 1f);
							bool flag4 = (object)_weapon == null;
							float num = _weapon.PArea();
							if (_tween != null)
							{
								TweenExtensions.Kill(_tween);
							}
							Transform target = base.transform;
							float num2 = default(float);
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, num2, 0.125f);
							TweenCallback tweenCallback = FadeOut;
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1178 @ rax_v59 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 == 0)
								{
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore != null)
							{
								_tween = tweenerCore;
								SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
								soundConfig.Rate = 1f;
								object obj = UnityEngine.Random.value;
								float num3 = num2 - 0.5f;
								soundConfig.Rate = 1f;
								float detune = num3 * 300f;
								soundConfig.Volume = (float?)(object)1;
								soundConfig.Detune = detune;
								float time = default(float);
								PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_artificialhailstorm, soundConfig, 200f, 3, time);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private void FadeOut()
	{
		//IL_0053: Expected I, but got O
		if (_tween != null)
		{
			TweenExtensions.Kill(_tween);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_GroundVFX, 0f, 0.25f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_MechProjectile_HailstormExplosion>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_tween = tweenerCore;
	}

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got F4
		//IL_0087: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		soundConfig.Rate = 1f;
		float detune = num * 300f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_artificialhailstorm, soundConfig, 200f, 3, time);
	}

	public override void Despawn()
	{
		if (_tween != null)
		{
			TweenExtensions.Kill(_tween);
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}
}
