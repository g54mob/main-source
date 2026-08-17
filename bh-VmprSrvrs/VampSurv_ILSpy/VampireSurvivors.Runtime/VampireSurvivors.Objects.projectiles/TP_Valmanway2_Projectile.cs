using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Events;
using UnityEngine;
using UnityEngine.Rendering;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Valmanway2_Projectile : Projectile
{
	private const float Radius = 36f;

	private const float Speed = 4f;

	private PhaserSprite _slashSprite;

	private PhaserSprite _ghostSprite1;

	private PhaserSprite _ghostSprite2;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _spriteScaleTween;

	private MultiTargetTween _alphaTween;

	protected override void Awake()
	{
		//IL_0064: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_0115: Expected O, but got I
		//IL_0115: Expected O, but got I
		//IL_024b: Expected O, but got I
		//IL_024b: Expected O, but got I
		//IL_028b: Invalid comparison between I4 and F4
		//IL_055f: Invalid comparison between I4 and F4
		//IL_0580: Invalid comparison between I4 and F4
		//IL_05a1: Invalid comparison between I4 and F4
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected I4, but got Unknown
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected I4, but got Unknown
		//IL_0448: Expected O, but got I
		//IL_0448: Expected O, but got I
		//IL_0490: Expected I4, but got I8
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-38]");
		Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
		if (thosepeople.Thosepeople != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1810]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_ = 0;
			GameObject gameObject = base.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-38]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			Vector2 vector = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, (string)num2, (string)0);
			PhaserSprite phaserSprite2 = phaserSprite.setLocalPosition(vector);
			PhaserSprite phaserSprite3 = phaserSprite2.setDepth(2);
			PhaserSprite phaserSprite4 = phaserSprite3.setTint(8388607u);
			PhaserSprite phaserSprite5 = phaserSprite4.setBlendMode(VampireSurvivors.Framework.Particles.BlendMode.Normal);
			GameObject gameObject2 = phaserSprite5.gameObject;
			((UnityEngine.Object)gameObject2).SetName("_slashSprite");
			_slashSprite = phaserSprite5;
			SpriteTextures.SpriteTexturesThosepeople thosepeople2 = SpriteTextures.Thosepeople;
			if (thosepeople2.Thosepeople != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1810]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				_ = 0;
				GameObject gameObject3 = _slashSprite.gameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-38]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
				PhaserSprite phaserSprite6 = RenderingExtensions.AddPhaserSprite(gameObject3, vector, (string)num3, (string)0);
				PhaserSprite phaserSprite7 = phaserSprite6.setLocalPosition(vector);
				PhaserSprite phaserSprite8 = phaserSprite7.setDepth(1);
				if (0f > 255f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rdx,xmm0\"");
				}
				if (0f > 255f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8,xmm0\"");
				}
				if (0f > 255f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rcx,xmm0\"");
				}
				if (0f > 255f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
				}
				int num4 = 0x10000 | typeof(ColorUtils);
				int num5 = num4 << 8;
				uint tint = (uint)(num5 | phaserSprite8);
				PhaserSprite phaserSprite9 = phaserSprite8.setTint(tint);
				PhaserSprite phaserSprite10 = phaserSprite9.setBlendMode(VampireSurvivors.Framework.Particles.BlendMode.Normal);
				GameObject gameObject4 = phaserSprite10.gameObject;
				((UnityEngine.Object)gameObject4).SetName("_ghostSprite1");
				_ghostSprite1 = phaserSprite10;
				SpriteTextures.SpriteTexturesThosepeople thosepeople3 = SpriteTextures.Thosepeople;
				if (thosepeople3.Thosepeople != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1810]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					_ = 0;
					GameObject gameObject5 = _slashSprite.gameObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-38]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
					PhaserSprite phaserSprite11 = RenderingExtensions.AddPhaserSprite(gameObject5, vector, (string)num6, (string)0);
					PhaserSprite phaserSprite12 = phaserSprite11.setLocalPosition(vector);
					PhaserSprite phaserSprite13 = phaserSprite12.setDepth(0);
					PhaserSprite phaserSprite14 = phaserSprite13.setTint(4286545791u);
					PhaserSprite phaserSprite15 = phaserSprite14.setBlendMode(VampireSurvivors.Framework.Particles.BlendMode.Normal);
					GameObject gameObject6 = phaserSprite15.gameObject;
					((UnityEngine.Object)gameObject6).SetName("_ghostSprite2");
					_ghostSprite2 = phaserSprite15;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002a: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_00a3: Expected O, but got Ref
		//IL_0130: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(36f, (float?)(object)1, (float?)(object)1);
		_speed = 4f;
		_isCullable = false;
		SetScaleToArea();
		InitSprites();
		InitBounce();
		Weapon weapon2 = _weapon;
		if (!weapon2.IsHoming)
		{
			object obj = default(object);
			ApplyPlayerFacingVelocity((Vector3)(&obj));
		}
		else
		{
			Transform transform = base.AimForNearestEnemy();
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordSimple, soundConfig, 200f, 10, time);
	}

	private void InitSprites()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0f9a: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0fc9: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_01ca: Expected O, but got I
		//IL_028f: Expected I4, but got I8
		//IL_0303: Expected O, but got I
		//IL_02bf: Expected O, but got I4
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected I4, but got Unknown
		//IL_035d: Expected O, but got I
		//IL_104f: Expected O, but got I
		//IL_03c7: Expected O, but got I
		//IL_1077: Expected O, but got I
		//IL_0431: Expected O, but got I
		//IL_109f: Expected O, but got I
		//IL_049b: Expected O, but got I
		//IL_10c7: Expected O, but got I
		//IL_0505: Expected O, but got I
		//IL_10ef: Expected O, but got I
		//IL_056f: Expected O, but got I
		//IL_1117: Expected O, but got I
		//IL_05d9: Expected O, but got I
		//IL_113f: Expected O, but got I
		//IL_0643: Expected O, but got I
		//IL_067b: Expected O, but got I
		//IL_06d5: Expected O, but got I
		//IL_1176: Expected O, but got I
		//IL_073f: Expected O, but got I
		//IL_119e: Expected O, but got I
		//IL_07a9: Expected O, but got I
		//IL_11c6: Expected O, but got I
		//IL_0813: Expected O, but got I
		//IL_11ee: Expected O, but got I
		//IL_087d: Expected O, but got I
		//IL_1216: Expected O, but got I
		//IL_08e7: Expected O, but got I
		//IL_123e: Expected O, but got I
		//IL_0951: Expected O, but got I
		//IL_09ca: Expected O, but got I
		//IL_09f5: Expected O, but got I
		//IL_0a31: Expected O, but got I
		//IL_0a46: Expected O, but got I
		//IL_12b7: Expected O, but got I
		//IL_0aa7: Expected O, but got I8
		//IL_0ae5: Expected O, but got I8
		//IL_0b3c: Expected O, but got I
		//IL_0ba7: Expected O, but got I8
		//IL_0c57: Expected O, but got I4
		//IL_0c72: Expected I, but got O
		//IL_0d35: Expected I, but got O
		//IL_0d99: Expected O, but got I4
		//IL_0e32: Expected I, but got O
		//IL_0e8a: Expected I, but got O
		//IL_0ee2: Expected I, but got O
		//IL_0f46: Expected O, but got I4
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v21+18]");
		if (num >= 0)
		{
			list.AddWithResize(8388607u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 8388607;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v23+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(8372223u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 8372223;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rdx_v25+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(16773631u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 16773631;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		uint item = 0u;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v28 (System.UInt32)+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(8388559u);
			item = 8388559u;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj7 = (nint)0 + (nint)1;
			_ = 8388559;
		}
		list.Add(item);
		uint tint = default(uint);
		PhaserSprite phaserSprite = _slashSprite.setTint(tint);
		float num5 = (float)_indexInWeapon * 0.03f;
		bool flag = num5 > 0.2f;
		float num6 = 0.2f;
		if (!flag)
		{
			num6 = num5;
		}
		float alpha = 0.5f - num6;
		PhaserSprite phaserSprite2 = _slashSprite.setAlpha(alpha);
		PhaserSprite phaserSprite3 = _ghostSprite1.setAlpha(alpha);
		PhaserSprite phaserSprite4 = _ghostSprite2.setAlpha(alpha);
		int num7 = (int)(_indexInWeapon & 0x80000007L);
		if ((nint)_ghostSprite2 < 0)
		{
			object obj8 = num7 - 1;
			object obj9 = obj8 | -8;
			num7 = obj9 + 1;
		}
		List<bool> list2 = new List<bool>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v31+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize(false);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj11 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdx_v33+18]");
		if (num9 >= 0)
		{
			list2.AddWithResize(true);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj13 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdx_v35+18]");
		if (num10 >= 0)
		{
			list2.AddWithResize(false);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj15 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdx_v37+18]");
		if (num11 >= 0)
		{
			list2.AddWithResize(false);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj17 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rdx_v39+18]");
		if (num12 >= 0)
		{
			list2.AddWithResize(true);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj19 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdx_v41+18]");
		if (num13 >= 0)
		{
			list2.AddWithResize(false);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj21 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rdx_v43+18]");
		if (num14 >= 0)
		{
			list2.AddWithResize(false);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj23 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdx_v45+18]");
		if (num15 >= 0)
		{
			list2.AddWithResize(true);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj25 = (nint)0 + (nint)1;
			_ = 1;
		}
		List<bool> list3 = new List<bool>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v48+18]");
		if (num16 >= 0)
		{
			list3.AddWithResize(false);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj27 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v50+18]");
		if (num17 >= 0)
		{
			list3.AddWithResize(false);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj29 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rdx_v52+18]");
		if (num18 >= 0)
		{
			list3.AddWithResize(true);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj31 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rdx_v54+18]");
		if (num19 >= 0)
		{
			list3.AddWithResize(false);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj33 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rdx_v56+18]");
		if (num20 >= 0)
		{
			list3.AddWithResize(true);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj35 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rdx_v58+18]");
		if (num21 >= 0)
		{
			list3.AddWithResize(false);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj37 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		object obj38 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rdx_v60+18]");
		if (num22 >= 0)
		{
			list3.AddWithResize(true);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj39 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+10]");
		bool flag2 = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v63 (System.Boolean)+18]");
		if (num23 >= 0)
		{
			list3.AddWithResize(false);
			nint num24 = 0;
			flag2 = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 0;
			nint num24 = 0;
		}
		int num25 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+18]");
		if ((nint)num25 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1572 @ rax_v44 (System.Collections.Generic.List`1<System.Boolean>)+10]");
			object obj41 = 0;
			int num26 = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			if ((nint)num26 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v55 (System.Collections.Generic.List`1<System.Boolean>)+10]");
				object obj42 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj43 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj43 == null)
					{
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
					obj42 = 6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2081 @ rax_v69 (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj44 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj44 == null)
					{
						MissingMethodException ex2 = new MissingMethodException();
						throw ex2;
					}
					obj42 = 6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2105 @ rax_v72 (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rsi_v14 (System.Int32)+20+v233 @ rcx_v76]");
				float num27 = (((nint)0 == 0) ? 1.25f : (-1.25f));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rsi_v14 (System.Int32)+20+v2106 @ rcx_v79]");
				bool flag3 = (nint)0 != 0;
				float num28 = 0.25f;
				if (!flag3)
				{
					num28 = 0.65f;
				}
				float yScale = num28 * num27;
				PhaserSprite phaserSprite5 = RenderingExtensions.SetScale(_slashSprite, 1.25f, yScale);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj45 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				bool flag4 = (nint)0 != 0;
				PhaserSprite slashSprite = _slashSprite;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj45 == null)
					{
						MissingMethodException ex3 = new MissingMethodException();
						throw ex3;
					}
					slashSprite = (PhaserSprite)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2173 @ rax_v77 (should have been resolved before IL gen)");
				if (_scaleTween != null)
				{
					_scaleTween.Kill();
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[1];
				PhaserSprite phaserSprite6 = RenderingExtensions.SetScale((PhaserSprite)(object)this, 2000f, yScale);
				if ((object)phaserSprite6 != null)
				{
					PhaserSprite phaserSprite7 = RenderingExtensions.SetScale((PhaserSprite)(object)array, 2000f, yScale);
					tweenConfig.targets = array;
					tweenConfig.duration = 1000f;
					tweenConfig.scale = (float?)(object)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2273 @ r8_v55 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Valmanway2_Projectile>)+370]");
					TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
					nint num29 = (nint)this;
					tweenConfig.onComplete = onComplete;
					MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
					_scaleTween = scaleTween;
					if (_spriteScaleTween != null)
					{
						_spriteScaleTween.Kill();
					}
					TweenConfig tweenConfig2 = new TweenConfig();
					object[] array2 = new object[1];
					Transform transform = _slashSprite.transform;
					if ((object)transform != null)
					{
						nint num30 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj46 = default(object);
						if (obj46 == null)
						{
							ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
							throw ex4;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig2.targets = array2;
					tweenConfig2.duration = 1000f;
					tweenConfig2.scaleX = (float?)(object)1;
					MultiTargetTween spriteScaleTween = Tweens.Add(tweenConfig2);
					_spriteScaleTween = spriteScaleTween;
					if (_alphaTween != null)
					{
						_alphaTween.Kill();
					}
					TweenConfig tweenConfig3 = new TweenConfig();
					object[] array3 = new object[3];
					if ((object)_slashSprite != null)
					{
						nint num31 = (nint)array3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj47 = default(object);
						if (obj47 == null)
						{
							ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
							throw ex5;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if ((object)_ghostSprite1 != null)
					{
						nint num32 = (nint)array3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj48 = default(object);
						if (obj48 == null)
						{
							ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
							throw ex6;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if ((object)_ghostSprite2 != null)
					{
						nint num33 = (nint)array3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj49 = default(object);
						if (obj49 == null)
						{
							ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
							throw ex7;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					tweenConfig3.targets = array3;
					tweenConfig3.duration = 1000f;
					tweenConfig3.alpha = (float?)(object)1;
					MultiTargetTween alphaTween = Tweens.Add(tweenConfig3);
					_alphaTween = alphaTween;
					return;
				}
				ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
				throw ex8;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
	}

	private void InitBounce()
	{
		//IL_0121: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		int num = _weapon.PBounces();
		if (num > 0)
		{
			if (_bounceActivated)
			{
				goto IL_010c;
			}
			_bounceActivated = true;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if ((object)s_scene.physics == null)
			{
				throw new NullReferenceException();
			}
			WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
			setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
			Weapon weapon = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
			BaseBody baseBody = base.body;
			baseBody._onWorldBounds = true;
		}
		if (!_bounceActivated)
		{
			return;
		}
		goto IL_010c;
		IL_010c:
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
	}

	private unsafe void InitAiming()
	{
		//IL_0043: Expected O, but got Ref
		Weapon weapon = _weapon;
		if (!weapon.IsHoming)
		{
			object obj = default(object);
			ApplyPlayerFacingVelocity((Vector3)(&obj));
		}
		else
		{
			Transform transform = base.AimForNearestEnemy();
		}
	}

	private void PlaySfx()
	{
		//IL_005d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordSimple, soundConfig, 200f, 10, time);
	}

	public override void InternalUpdate()
	{
		//IL_007c: Expected F4, but got O
		BaseBody baseBody = body;
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 axis = default(Vector3);
		Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void UpdateRotation()
	{
		//IL_007c: Expected F4, but got O
		BaseBody baseBody = body;
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 axis = default(Vector3);
		Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_spriteScaleTween != null)
		{
			_spriteScaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Despawn();
	}

	private void Bounce(Body body, bool up, bool down, bool left, bool right)
	{
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		if (base.body == body)
		{
			if (_bounces <= 0)
			{
				setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
				return;
			}
			int bounces = _bounces - 1;
			_bounces = bounces;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}
}
