using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Dark2_Projectile : TP_Light1_Projectile
{
	private TrailRenderer _trail;

	private int _gravityFrameCounter;

	public override float BodyRadius => 32f;

	public override float Scale => 0.5f;

	public override float Depth => 1f;

	public override bool HasOrbiters => true;

	public override int InvertMotion
	{
		get
		{
			//IL_000a: Expected I4, but got I8
			return -1;
		}
	}

	public override void MakeSpriteAnimation()
	{
		GameObject gameObject = _renderer.gameObject;
		SpriteAnimation spriteAnimator = gameObject.AddComponent<SpriteAnimation>();
		_spriteAnimator = spriteAnimator;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Umbra", 25, 47, "ThosePeople", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimator.AddAnimation("loop", animationFrames, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		GameObject gameObject2 = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite glowSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", "corridor_light");
		_glowSprite = glowSprite;
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_glowSprite, 0.5f);
		PhaserSprite phaserSprite2 = _glowSprite.setAlpha(0.65f);
		PhaserSprite phaserSprite3 = _glowSprite.setTint(0u);
		PhaserSprite phaserSprite4 = _glowSprite.setVisible(visible: false);
	}

	protected override void InitAlpha()
	{
		//IL_0018: Invalid comparison between F4 and O
		//IL_0041: Invalid comparison between O and F4
		float num = _weapon.PArea();
		object obj = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float num2 = 1f;
		if (!flag)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f))
			{
				float num3 = (float)obj - 1f;
				float num4 = num3 * 0.3f;
				float num5 = num4 * 0.5f;
				num2 = 1f - num5;
			}
			else
			{
				num2 = 0.7f;
			}
		}
		ArcadeSprite arcadeSprite = setAlpha(num2);
		float alpha = num2 * 0.65f;
		PhaserSprite phaserSprite = _glowSprite.setAlpha(alpha);
		if (!(0.7f < num2))
		{
			ArcadeSprite arcadeSprite2 = setDepth(0);
		}
		TP_Light1_Weapon trueWeapon = _trueWeapon;
		trueWeapon._003CProjScaledAlpha_003Ek__BackingField = num2;
	}

	protected override void PlayFiringSfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_VolUmbra, soundConfig, 50f, 1, time);
	}

	public void createGravityWell(float2 pos, float radius)
	{
		//IL_0037: Expected O, but got I4
		//IL_0058: Expected O, but got I4
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_010d: Invalid comparison between F4 and I4
		//IL_016b: Invalid comparison between F4 and O
		//IL_021a: Expected O, but got F4
		//IL_0192: Expected F4, but got O
		GameManager core = GM.Core;
		List<EnemyController> enemiesInCircle = core._stage.GetEnemiesInCircle(pos, radius);
		object obj = 0;
		float2 float5 = pos;
		float num = radius;
		float2 float6 = pos;
		object obj2 = 0;
		object obj3 = default(object);
		object obj4 = default(object);
		float2 float8 = default(float2);
		while (true)
		{
			if ((nint)obj2 >= enemiesInCircle._size)
			{
				return;
			}
			if ((nint)obj >= enemiesInCircle._size)
			{
				break;
			}
			EnemyController[] items = enemiesInCircle._items;
			ArcadeSprite arcadeSprite = items[obj];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdi_v4 (ArcadeSprite)+260]");
			if ((nint)0 == 0)
			{
				float2 float7 = arcadeSprite.position;
				num = (float)pos - (float)float7;
				float6 = obj3 - obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001870C49DCh\"");
				if (num == 0f)
				{
					bool flag = (object)float6 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001870C49DCh\"");
					if (flag)
					{
						goto IL_0197;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850046E0");
				float deltaTime = PauseSystem.DeltaTime;
				bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)deltaTime) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float8);
				float num2 = deltaTime;
				if (!flag2)
				{
					num2 = (float)float8;
				}
				float2 float9 = arcadeSprite.position;
				float num3 = num / (float)float8;
				float num4 = (float)float6 / (float)float8;
				num = num3 * num2;
				float6 = (float2)(num4 * num2);
				object obj5 = obj4 + (object)float6;
				arcadeSprite.position = float8;
				float5 = float8;
			}
			goto IL_0197;
			IL_0197:
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public TP_Dark2_Projectile()
	{
		base._flipNum = 1f;
		((Projectile)this)._002Ector();
	}
}
