using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_SpearProjectile_Triumvirate : EME_SpearProjectile
{
	protected override float ScaleMultiplier => 0.4f;

	protected override float InitialSpeed => 8f;

	protected override float DecelRate
	{
		get
		{
			//IL_0006: Expected F4, but got I4
			return 0f;
		}
	}

	protected override bool UsesPortalVFX => true;

	protected override string GetSpearSpriteName(WeaponType weapon)
	{
		//IL_00b0: Expected O, but got I4
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4A88]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4A88]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj = (int)weapon >> 31;
		object obj2 = weapon + obj;
		object obj3 = obj2 * 2;
		object obj4 = obj2 + obj3;
		object obj5 = _indexInWeapon - obj4;
		if (!flag)
		{
			object obj6 = obj5 - 1;
			if (flag)
			{
				return "EME_Spear_Feather2";
			}
			if ((nint)obj6 == 1)
			{
				return "EME_Spear_Lohengrin2";
			}
		}
		return "EME_Spear_Glaive2";
	}

	protected override void SetupTrail()
	{
		TrailRenderer lineTrail = _LineTrail;
		if ((object)_LineTrail != null && ((UnityEngine.Object)lineTrail).m_CachedPtr != (IntPtr)0)
		{
			string text = _spearSpriteName + "_TrailTriumvirate2";
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			float num = _area * 0.3f;
			_LineTrail.time = 0.6f;
			_LineTrail.startWidth = num;
			_LineTrail.endWidth = num;
			Sprite sprite = default(Sprite);
			RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_LineTrail, sprite, true);
			Material material = ((Renderer)_LineTrail).GetMaterial();
			RenderingExtensions.SetAlpha(material, 1f);
			_LineTrail.Clear();
			_LineTrail.emitting = true;
			TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_LineTrail);
		}
	}

	protected override void PlaySfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_divinelancer, soundConfig, 200f, 1, time);
	}
}
