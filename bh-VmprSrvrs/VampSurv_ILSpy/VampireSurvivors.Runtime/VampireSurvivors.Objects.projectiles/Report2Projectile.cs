using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.projectiles;

public class Report2Projectile : ReportProjectile
{
	protected override bool followPlayerFacing => true;

	protected override void InitVisuals()
	{
		List<Sprite> frames = new List<Sprite>();
		Sprite sprite = SpriteManager.GetSprite("SoundWaves01", "vfx");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
		Sprite sprite2 = SpriteManager.GetSprite("SoundWaves02", "vfx");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
		Sprite sprite3 = SpriteManager.GetSprite("SoundWaves03", "vfx");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
		Sprite sprite4 = SpriteManager.GetSprite("SoundWaves04", "vfx");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
		Sprite sprite5 = SpriteManager.GetSprite("SoundWaves05", "vfx");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
		bool shouldLoop = default(bool);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anim.AddAnimation("idle", frames, 16, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
	}

	public Report2Projectile()
	{
		//IL_0017: Expected O, but got I4
		offset = (float2)0;
		_ = 1045220557;
		((Projectile)this)._002Ector();
	}
}
