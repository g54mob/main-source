using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_ShaftOrb_Projectile : TP_Light1_Projectile
{
	private List<SfxType> _sfx;

	public override bool HasOrbiters => true;

	public override int InvertMotion
	{
		get
		{
			//IL_001c: Expected O, but got F4
			//IL_0025: Invalid comparison between O and F4
			//IL_003b: Expected I4, but got I8
			object obj = UnityEngine.Random.value;
			object obj2 = default(object);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
			int result = -1;
			if (!flag)
			{
				result = 1;
			}
			return result;
		}
	}

	public override void MakeSpriteAnimation()
	{
		_speed = 1f;
		GameObject gameObject = _renderer.gameObject;
		SpriteAnimation spriteAnimator = gameObject.AddComponent<SpriteAnimation>();
		_spriteAnimator = spriteAnimator;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_ShaftOrb_", 1, 8, "ThosePeople", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimator.AddAnimation("loop", animationFrames, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		GameObject gameObject2 = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite glowSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", "corridor_light");
		_glowSprite = glowSprite;
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_glowSprite, 0.25f);
		PhaserSprite phaserSprite2 = _glowSprite.setAlpha(0.15f);
		PhaserSprite phaserSprite3 = _glowSprite.setTint(2642144u);
		PhaserSprite phaserSprite4 = _glowSprite.setVisible(visible: false);
	}

	protected override void PlayFiringSfx()
	{
		//IL_0059: Expected O, but got F4
		//IL_0087: Expected O, but got I4
		SfxType sfxType = Extensions.PickRnd(_sfx);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num - 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 250f, 1, time);
	}

	public TP_ShaftOrb_Projectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_013f: Expected O, but got I
		//IL_00ec: Expected O, but got I
		List<SfxType> list = new List<SfxType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)325);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 325;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)322);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 322;
		}
		_sfx = list;
		base._flipNum = 1f;
		((Projectile)this)._002Ector();
	}
}
