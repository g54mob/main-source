using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_SpearProjectile_DivineLancer : EME_SpearProjectile
{
	protected override float ScaleMultiplier => 0.5f;

	protected override float InitialSpeed => 12f;

	protected override bool UsesPortalVFX => true;

	protected override float PortalVFXScale => 1.25f;

	protected override void SetupTrail()
	{
		TrailRenderer lineTrail = _LineTrail;
		if ((object)_LineTrail != null && ((UnityEngine.Object)lineTrail).m_CachedPtr != (IntPtr)0)
		{
			string text = _spearSpriteName + "_TrailDivineLancer2";
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
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_divinelancer, soundConfig, 200f, 5, time);
	}
}
