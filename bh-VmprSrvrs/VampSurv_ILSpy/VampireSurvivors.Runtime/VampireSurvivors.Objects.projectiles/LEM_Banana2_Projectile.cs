using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Projectiles;

public class LEM_Banana2_Projectile : LEM_Banana1_Projectile
{
	protected override float Radius => 14f;

	protected unsafe override SpriteTextureData BananaSprite
	{
		get
		{
			//IL_0063: Expected native int or pointer, but got O
			SpriteTextures.SpriteTexturesLemon lemon = SpriteTextures.Lemon;
			if (SpriteTextures.Lemon != null && lemon.LEM_Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E4F]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				SpriteTextureData spriteTextureData = default(SpriteTextureData);
				System.Runtime.CompilerServices.Unsafe.Write(&((SpriteTextureData*)(nint)spriteTextureData)->Sprite, "LEM_VFX_Cavendish");
				return spriteTextureData;
			}
			return (SpriteTextureData)new NullReferenceException();
		}
	}

	protected unsafe override SpriteTextureData TrailSprite
	{
		get
		{
			//IL_0063: Expected native int or pointer, but got O
			SpriteTextures.SpriteTexturesLemon lemon = SpriteTextures.Lemon;
			if (SpriteTextures.Lemon != null && lemon.LEM_Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E50]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				SpriteTextureData spriteTextureData = default(SpriteTextureData);
				System.Runtime.CompilerServices.Unsafe.Write(&((SpriteTextureData*)(nint)spriteTextureData)->Sprite, "LEM_VFX_Cavendish_Trail");
				return spriteTextureData;
			}
			return (SpriteTextureData)new NullReferenceException();
		}
	}

	protected override float BananaSpriteScale => 0.35f;

	protected override float LaunchAngleOffset => (float)_indexInWeapon * 7.5f;

	protected override void AimInDirection(Vector2 playerDir)
	{
		//IL_0014: Expected I4, but got I8
		//IL_0116: Expected F4, but got O
		//IL_0093: Expected I, but got O
		//IL_00a2: Expected I, but got O
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_003e: Expected O, but got I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected I4, but got Unknown
		int num = (int)(_indexInWeapon & 0x80000001L);
		object obj = default(object);
		object obj2 = default(object);
		if (obj != obj2)
		{
			object obj3 = num - 1;
			object obj4 = obj3 | -2;
			num = obj4 + 1;
		}
		float num3 = default(float);
		Vector2 vector = default(Vector2);
		while (true)
		{
			bool flag = num != 1;
			float num2 = num3;
			float num4 = (float)playerDir;
			if (!flag)
			{
				num4 = (float)playerDir * -1f;
				num2 = num3 * -1f;
				SetFlipFromPlayerDirection(vector);
			}
			nint num5 = (nint)this;
			float launchAngleOffset = LaunchAngleOffset;
			nint num6 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			float num7 = num2 * 57.29578f;
			object obj5 = _flipSign * vector;
			float num8 = num7 + (float)obj5;
			float num9 = num8 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v78 @ rbx_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Banana2_Projectile>)+418] (should have been resolved before IL gen)");
		}
	}

	protected override void PlayThrowSfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = (float)_indexInWeapon * 100f;
		float detune = num - 300f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_banana_throw2, soundConfig, 200f, 10, time);
	}

	public LEM_Banana2_Projectile()
	{
		//IL_0017: Expected O, but got I4
		RotationDegRange = (float2)1135869952;
		_ = 1144258560;
		((Projectile)this)._002Ector();
	}
}
