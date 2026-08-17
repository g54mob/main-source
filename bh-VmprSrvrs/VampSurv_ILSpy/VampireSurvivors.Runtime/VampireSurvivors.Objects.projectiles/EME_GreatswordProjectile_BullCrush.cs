using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_GreatswordProjectile_BullCrush : EME_GreatswordProjectile
{
	private ParticleSystem _SlashVFX;

	private const float VFXScale = 0.5f;

	private const float VFXRotationZ = -20f;

	private const float SwordRotationZ = 165f;

	private Vector3 _defaultSwordSpriteRotation;

	private float2 _bodySize;

	private float2 _bodyOffset;

	private Tween _scaleTween2;

	protected override void DoGlimmerAttack()
	{
		//IL_0037: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_008c: Expected F4, but got O
		//IL_00f7: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		BaseBody baseBody = body;
		baseBody._enable = true;
		_bodySize = (float2)1065353216;
		_ = 1092616192;
		BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
		_bodyOffset = (float2)0;
		_ = 1113325568;
		BaseBody baseBody3 = body.setOffset((float)_bodyOffset, (float?)(object)1);
		PlaySlashVFX();
		RotateSwordSprite();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_bullcrush, soundConfig, 200f, 3, time);
		StartDespawn();
	}

	public override void InternalUpdate()
	{
		//IL_010c: Invalid comparison between F4 and I
		//IL_022e: Expected O, but got F4
		//IL_0152: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		//IL_0133: Expected F4, but got I
		//IL_0283: Invalid comparison between F4 and I
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_01c6: Expected O, but got I4
		//IL_01c6: Expected F4, but got O
		//IL_01e5: Invalid comparison between I and F4
		//IL_01ab: Expected F4, but got I
		if (!_hasLanded)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 6.25f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile_BullCrush)+FC]");
			float num2 = 0f - num;
			ArcadeSprite sprite = _sprite;
			BaseBody baseBody = sprite.body;
			baseBody._velocity = _velocity;
		}
		if (!_hasLanded)
		{
			return;
		}
		BaseBody baseBody2 = body;
		if (baseBody2._enable)
		{
			float deltaTime2 = PauseSystem.DeltaTime;
			float num3 = deltaTime2 * 600f;
			float num4 = num3 * 0.5f;
			float num5 = num4 + (float)_bodySize;
			float num6 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10D48]");
			if (num6 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10D48]");
				num5 = 0f;
			}
			_bodySize = (float2)num5;
			BaseBody baseBody3 = body.setSize((float?)(object)1, (float?)(object)1);
			if (_isFlipped)
			{
				float2 bodySize = _bodySize;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float2 bodyOffset = (float2)(bodySize ^ 0);
				_bodyOffset = bodyOffset;
			}
			float deltaTime3 = PauseSystem.DeltaTime;
			float num7 = deltaTime3 * 600f;
			float num8 = num7 * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile_BullCrush)+158]");
			float num9 = 0f - num8;
			float num10 = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F8]");
			if (num10 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F8]");
				num9 = 0f;
			}
			BaseBody baseBody4 = body.setOffset((float)_bodyOffset, (float?)(object)1);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871E04CEh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile_BullCrush)+158]");
			if (0f == -60f)
			{
				BaseBody baseBody5 = body;
				baseBody5._enable = false;
			}
		}
	}

	private unsafe void PlaySlashVFX()
	{
		//IL_0119: Expected O, but got Ref
		//IL_0151->IL018b: Incompatible stack heights: 1 vs 0
		ParticleSystem slashVFX = _SlashVFX;
		if ((object)_SlashVFX == null || ((UnityEngine.Object)slashVFX).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (_scaleTween2 != null)
		{
			TweenExtensions.Kill(_scaleTween2);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, 1.5f, 0.125f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			_scaleTween2 = tweenerCore;
			if ((object)_SlashVFX != null)
			{
				Transform transform = _SlashVFX.transform;
				if ((object)transform != null)
				{
					Vector3 value = default(Vector3);
					transform.eulerAngles = (Vector3)(&value);
					Transform transform2 = _SlashVFX.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rax_v27 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rax_v27 (UnityEngine.Transform)+10]");
					Transform.set_localScale_Injected((IntPtr)0, ref value);
					_SlashVFX.Play(withChildren: true);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetBodyForSlash()
	{
		//IL_0037: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_005c: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_008c: Expected O, but got I4
		//IL_008c: Expected F4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		BaseBody baseBody = body;
		baseBody._enable = true;
		_bodySize = (float2)1065353216;
		_ = 1092616192;
		BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
		_bodyOffset = (float2)0;
		_ = 1113325568;
		BaseBody baseBody3 = body.setOffset((float)_bodyOffset, (float?)(object)1);
	}

	private void UpdateBodyForSlash()
	{
		//IL_0080: Invalid comparison between F4 and I
		//IL_01bb: Expected O, but got F4
		//IL_00c6: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_00a7: Expected F4, but got I
		//IL_0210: Invalid comparison between F4 and I
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_013a: Expected O, but got I4
		//IL_013a: Expected F4, but got O
		//IL_0159: Invalid comparison between I and F4
		//IL_011f: Expected F4, but got I
		if (!_hasLanded)
		{
			return;
		}
		BaseBody baseBody = body;
		if (baseBody._enable)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 600f;
			float num2 = num * 0.5f;
			float num3 = num2 + (float)_bodySize;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10D48]");
			if (num4 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10D48]");
				num3 = 0f;
			}
			_bodySize = (float2)num3;
			BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
			if (_isFlipped)
			{
				float2 bodySize = _bodySize;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float2 bodyOffset = (float2)(bodySize ^ 0);
				_bodyOffset = bodyOffset;
			}
			float deltaTime2 = PauseSystem.DeltaTime;
			float num5 = deltaTime2 * 600f;
			float num6 = num5 * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile_BullCrush)+158]");
			float num7 = 0f - num6;
			float num8 = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F8]");
			if (num8 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A116F8]");
				num7 = 0f;
			}
			BaseBody baseBody3 = body.setOffset((float)_bodyOffset, (float?)(object)1);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001871E0B83h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EME_GreatswordProjectile_BullCrush)+158]");
			if (0f == -60f)
			{
				BaseBody baseBody4 = body;
				baseBody4._enable = false;
			}
		}
	}

	private unsafe void RotateSwordSprite()
	{
		//IL_007c: Expected O, but got F4
		//IL_00e0: Expected O, but got Ref
		SpriteRenderer swordSprite = _SwordSprite;
		if ((object)_SwordSprite != null && ((UnityEngine.Object)swordSprite).m_CachedPtr != (IntPtr)0)
		{
			_SwordSprite.sprite = _swordSpriteFull;
		}
		Transform transform = _SwordSprite.transform;
		Vector3 eulerAngles = transform.eulerAngles;
		_defaultSwordSpriteRotation = (Vector3)eulerAngles.x;
		_ = eulerAngles.z;
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		Transform target = _SwordSprite.transform;
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> t = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj), 0.1f);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_angleTween = tweenerCore;
	}

	private void PlaySlashSfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_bullcrush, soundConfig, 200f, 3, time);
	}

	public unsafe override void Despawn()
	{
		//IL_0026: Expected O, but got Ref
		Transform transform = _SwordSprite.transform;
		object obj = default(object);
		transform.eulerAngles = (Vector3)(&obj);
		ParticleSystem slashVFX = _SlashVFX;
		if ((object)_SlashVFX != null && ((UnityEngine.Object)slashVFX).m_CachedPtr != (IntPtr)0)
		{
			_SlashVFX.Clear(withChildren: true);
		}
		if (_scaleTween2 != null)
		{
			TweenExtensions.Kill(_scaleTween2);
		}
		base.Despawn();
	}
}
