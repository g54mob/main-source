using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_MetalClawProjectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public FB_MetalClawProjectile _003C_003E4__this;

		public float2 finishOffset;

		public TweenCallback _003C_003E9__2;

		internal void _003CInitProjectile_003Eb__0()
		{
			FB_MetalClawProjectile fB_MetalClawProjectile = _003C_003E4__this;
			PhaserSprite phaserSprite = fB_MetalClawProjectile._displaySprite.setVisible(visible: false);
			_003C_003E4__this.Despawn();
		}

		internal void _003CInitProjectile_003Eb__1()
		{
			//IL_008d: Expected I, but got O
			FB_MetalClawProjectile fB_MetalClawProjectile = _003C_003E4__this;
			if (fB_MetalClawProjectile._tweenOffSetOut != null)
			{
				fB_MetalClawProjectile._tweenOffSetOut.Kill();
			}
			FB_MetalClawProjectile fB_MetalClawProjectile2 = _003C_003E4__this;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_003C_003E4__this != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"offsetX", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"offsetY", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 100f;
			TweenCallback onComplete = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				onComplete = (_003C_003E9__2 = delegate
				{
					FB_MetalClawProjectile fB_MetalClawProjectile3 = _003C_003E4__this;
					BaseBody body = fB_MetalClawProjectile3.body;
					body._enable = false;
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween tweenOffSetOut = Tweens.Add(tweenConfig);
			fB_MetalClawProjectile2._tweenOffSetOut = tweenOffSetOut;
		}

		internal void _003CInitProjectile_003Eb__2()
		{
			FB_MetalClawProjectile fB_MetalClawProjectile = _003C_003E4__this;
			BaseBody body = fB_MetalClawProjectile.body;
			body._enable = false;
		}
	}

	private MultiTargetTween _tweenOffSetIn;

	private MultiTargetTween _tweenOffSetOut;

	private float _previousArea;

	private float _detuneMul;

	private float2 startOffsetRight;

	private float2 finishOffsetRight;

	private float2 startOffsetLeft;

	private float2 finishOffsetLeft;

	public float offsetX;

	public float offsetY;

	private float _areaScale;

	private float _hitboxRadius;

	private PhaserSprite _displaySprite;

	public void SetDetune(float value = 0f)
	{
		_detuneMul = value;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_008c: Expected I4, but got I8
		//IL_0161: Expected O, but got I4
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected I4, but got Unknown
		//IL_00bf: Expected O, but got I4
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected I4, but got Unknown
		//IL_0844: Expected I4, but got I8
		//IL_00ee: Expected O, but got I4
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected I4, but got Unknown
		//IL_0214: Expected I4, but got I8
		//IL_01d1: Expected O, but got I4
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected I4, but got Unknown
		//IL_08b1: Expected O, but got I4
		//IL_086e: Expected O, but got I4
		//IL_0877: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Expected O, but got Unknown
		//IL_0885: Unknown result type (might be due to invalid IL or missing references)
		//IL_088a: Expected O, but got Unknown
		//IL_0242: Expected O, but got I4
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected I4, but got Unknown
		//IL_02b6: Expected F4, but got I
		//IL_02d0: Expected O, but got I
		//IL_08f3: Expected O, but got F4
		//IL_027d: Expected F4, but got I
		//IL_0297: Expected O, but got I
		//IL_091e: Expected F4, but got O
		//IL_02e5: Expected F4, but got I
		//IL_0379: Expected O, but got I4
		//IL_0379: Expected O, but got I4
		//IL_03e0: Expected F4, but got O
		//IL_041e: Expected O, but got F4
		//IL_045a: Expected O, but got F4
		//IL_0538: Expected I, but got O
		//IL_04b2: Expected O, but got I4
		//IL_04b2: Expected I4, but got O
		//IL_04cb: Expected F4, but got O
		//IL_0676: Expected O, but got I4
		//IL_0696: Expected O, but got I4
		//IL_077a: Expected O, but got Ref
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals11._003C_003E4__this = this;
		base.InitProjectile(pool, weapon, index);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		int num = (int)(_indexInWeapon & 0x80000001L);
		if ((nint)((Equipment)weapon2)._003COwner_003Ek__BackingField < 0)
		{
			object obj = num - 1;
			object obj2 = obj | -2;
			num = obj2 + 1;
		}
		bool flag;
		bool flag2;
		bool flag4;
		if (characterController._isFlipped)
		{
			object obj3 = num - 1;
			int num2 = num ^ 1;
			int num3 = num ^ obj3;
			int num4 = num2 & num3;
			flag = num4 < 0;
			flag2 = (nint)obj3 < 0;
			bool flag3 = obj3 == null;
			flag4 = !flag3;
		}
		else
		{
			object obj4 = num - 1;
			int num5 = num ^ 1;
			int num6 = num ^ obj4;
			int num7 = num5 & num6;
			flag = num7 < 0;
			flag2 = (nint)obj4 < 0;
			bool flag5 = obj4 == null;
			flag4 = flag5;
		}
		int num8 = (int)(_indexInWeapon & 0x80000003L);
		if (flag2 != flag)
		{
			object obj5 = num8 - 1;
			object obj6 = obj5 | -4;
			num8 = obj6 + 1;
		}
		bool flag6;
		if (num8 == 2)
		{
			flag6 = true;
		}
		else
		{
			int num9 = (int)(_indexInWeapon & 0x80000003L);
			if (num8 < 2)
			{
				object obj7 = num9 - 1;
				object obj8 = obj7 | -4;
				num9 = obj8 + 1;
			}
			object obj9 = num9 - 3;
			bool flag7 = obj9 == null;
			flag6 = flag7;
		}
		object obj10 = (flag4 ? 1 : 0) ^ 1;
		object obj11 = obj10 * 2;
		object obj12 = obj11 - 1;
		float2 float5;
		float num10;
		float2 finishOffset;
		if (flag4)
		{
			float5 = startOffsetLeft;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_MetalClawProjectile)+FC]");
			num10 = 0f;
			finishOffset = finishOffsetLeft;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_MetalClawProjectile)+104]");
			object obj13 = 0;
		}
		else
		{
			float5 = startOffsetRight;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_MetalClawProjectile)+EC]");
			num10 = 0f;
			finishOffset = finishOffsetRight;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.FB_MetalClawProjectile)+F4]");
			object obj13 = 0;
		}
		CS_0024_003C_003E8__locals11.finishOffset = finishOffset;
		float2 float6 = base.position;
		float num11 = default(float);
		base.position = (float2)num11;
		bool flag8 = !flag6;
		float num12 = num10;
		if (!flag8)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v2 (VampireSurvivors.Objects.Projectiles.FB_MetalClawProjectile+<>c__DisplayClass14_0)+1C]");
			num12 = 0f;
		}
		offsetX = (float)float5;
		offsetY = num12;
		float num13 = weapon.PArea();
		float num14 = (float)obj12 * 0.25f;
		float num15 = (_areaScale = num14 + 1f);
		float num16 = offsetY - _hitboxRadius;
		float num17 = num16 * num15;
		float radius = num15 * _hitboxRadius;
		BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		PhaserSprite displaySprite = _displaySprite;
		float time;
		string text = default(string);
		int num18;
		if ((object)_displaySprite != null)
		{
			bool flag9 = ((UnityEngine.Object)displaySprite).m_CachedPtr != (IntPtr)0;
			num18 = 1;
			time = (float)text;
			if (flag9)
			{
				goto IL_04d0;
			}
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		float2 float7 = base.position;
		PhaserSprite displaySprite2 = RenderingExtensions.sprite(s_scene.add, (Vector2)num11, "firstBlood", "Clawarm-F1");
		_displaySprite = displaySprite2;
		int num19 = default(int);
		bool flag10 = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Clawarm-F", 1, 5, (Vector2)num11, text, num19, flag10);
		PhaserSprite displaySprite3 = _displaySprite;
		Action action = delegate
		{
			FB_MetalClawProjectile fB_MetalClawProjectile = CS_0024_003C_003E8__locals11._003C_003E4__this;
			PhaserSprite phaserSprite5 = fB_MetalClawProjectile._displaySprite.setVisible(visible: false);
			CS_0024_003C_003E8__locals11._003C_003E4__this.Despawn();
		};
		bool autoSetAnimation = default(bool);
		displaySprite3._spriteAnimation.AddAnimation("claw", animationFrames, 20, (byte)(int)text != 0, (byte)num19 != 0, (Action)flag10, autoSetAnimation);
		num17 = num11;
		num18 = 20;
		time = (float)text;
		goto IL_04d0;
		IL_04d0:
		ArcadeSprite arcadeSprite3 = setAlpha(1f);
		if (_tweenOffSetIn != null)
		{
			_tweenOffSetIn.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num20 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj14 = default(object);
		if (obj14 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag11 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"offsetX", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			bool flag12 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"offsetY", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 10f;
			TweenCallback onComplete = delegate
			{
				//IL_008d: Expected I, but got O
				FB_MetalClawProjectile fB_MetalClawProjectile = CS_0024_003C_003E8__locals11._003C_003E4__this;
				if (fB_MetalClawProjectile._tweenOffSetOut != null)
				{
					fB_MetalClawProjectile._tweenOffSetOut.Kill();
				}
				FB_MetalClawProjectile fB_MetalClawProjectile2 = CS_0024_003C_003E8__locals11._003C_003E4__this;
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				if ((object)CS_0024_003C_003E8__locals11._003C_003E4__this != null)
				{
					nint num26 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj16 = default(object);
					if (obj16 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value3 = default(object);
				bool flag13 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"offsetX", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value4 = default(object);
				bool flag14 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"offsetY", value4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig2.custom = dictionary2;
				tweenConfig2.duration = 100f;
				TweenCallback onComplete2 = CS_0024_003C_003E8__locals11._003C_003E9__2;
				if (CS_0024_003C_003E8__locals11._003C_003E9__2 == null)
				{
					onComplete2 = (CS_0024_003C_003E8__locals11._003C_003E9__2 = delegate
					{
						FB_MetalClawProjectile fB_MetalClawProjectile3 = CS_0024_003C_003E8__locals11._003C_003E4__this;
						BaseBody baseBody3 = fB_MetalClawProjectile3.body;
						baseBody3._enable = false;
					});
				}
				tweenConfig2.onComplete = onComplete2;
				MultiTargetTween tweenOffSetOut = Tweens.Add(tweenConfig2);
				fB_MetalClawProjectile2._tweenOffSetOut = tweenOffSetOut;
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween tweenOffSetIn = Tweens.Add(tweenConfig);
			_tweenOffSetIn = tweenOffSetIn;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			object obj15 = _indexInWeapon * -100;
			float num21 = _detuneMul * 400f;
			soundConfig.Volume = (float?)(object)1;
			float detune = num21 + (float)obj15;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack1, soundConfig, 0f, 10, time);
			float2 float8 = base.position;
			float num22 = _areaScale * 0.16f;
			float num23 = 1.0653532E+09f + num22;
			float num24 = (float)obj12 * 0.32f;
			float num25 = num24 * _areaScale;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			Vector3 localEulerAngles = cachedTrans.localEulerAngles;
			Transform transform = _displaySprite.transform;
			float2 float9 = default(float2);
			transform.localEulerAngles = (Vector3)(&float9);
			PhaserSprite displaySprite4 = _displaySprite;
			displaySprite4._spriteAnimation.SetAnimation("claw");
			PhaserSprite phaserSprite = _displaySprite.setVisible(visible: true);
			PhaserSprite phaserSprite2 = _displaySprite.setFlipX(flag4);
			PhaserSprite phaserSprite3 = _displaySprite.setFlipY(flag6);
			PhaserSprite phaserSprite4 = RenderingExtensions.SetScale(_displaySprite, _areaScale);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void InternalUpdate()
	{
		//IL_003d: Expected O, but got I4
		float num = offsetX - _hitboxRadius;
		float x = num * _areaScale;
		BaseBody baseBody = body.setOffset(x, (float?)(object)1);
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_tweenOffSetIn != null)
		{
			_tweenOffSetIn.Kill();
		}
		if (_tweenOffSetOut != null)
		{
			_tweenOffSetOut.Kill();
		}
	}

	public FB_MetalClawProjectile()
	{
		//IL_0021: Expected O, but got I4
		//IL_002c: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_0056: Expected O, but got I8
		_ = 3259498496L;
		startOffsetRight = (float2)0;
		startOffsetLeft = (float2)0;
		_ = 0;
		finishOffsetRight = (float2)1112014848;
		_ = 3259498496L;
		finishOffsetLeft = (float2)3259498496L;
		_areaScale = 1f;
		_hitboxRadius = 24f;
		base._002Ector();
	}
}
