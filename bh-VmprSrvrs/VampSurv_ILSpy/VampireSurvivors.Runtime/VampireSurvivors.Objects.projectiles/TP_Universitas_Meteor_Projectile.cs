using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Universitas_Meteor_Projectile : Projectile
{
	private float _radius = 10f;

	private PhaserSprite _animatedSprite;

	private Tween _radiusTween;

	private float startingScale;

	private MultiTargetTween _alphaTween;

	protected override void Awake()
	{
		//IL_00d8: Expected O, but got I4
		//IL_00d8: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "VFX_Rock_0000");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("VFX_Rock_", 0, 47, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.SetAnimation("loop");
		PhaserSprite animatedSprite4 = _animatedSprite;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(animatedSprite4._spriteRenderer, 16777198u);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0301: Expected O, but got I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_006a: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0337: Expected O, but got F4
		//IL_0124: Expected O, but got I4
		//IL_03c4: Expected O, but got F4
		//IL_03f3: Expected O, but got I4
		//IL_01dd->IL02cd: Incompatible stack heights: 1 vs 0
		//IL_024e->IL02cd: Incompatible stack heights: 1 vs 0
		//IL_022c->IL022c: Incompatible stack heights: 2 vs 1
		base.InitProjectile(pool, weapon, index);
		_speed = 2.5f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		ArcadeSprite sprite = _sprite;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			float radius = _radius;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = radius ^ 0;
			if (sprite.body != null)
			{
				BaseBody baseBody2 = sprite.body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
				if ((object)_animatedSprite != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
					object obj2 = (object)baseBody >> 31;
					object obj3 = (object)baseBody + obj2;
					object obj4 = obj3 * 2;
					object obj5 = obj3 + obj4;
					object obj6 = obj5 + obj5;
					object obj7 = _indexInWeapon - obj6;
					bool visible = obj7 == null;
					PhaserSprite phaserSprite = _animatedSprite.setVisible(visible);
					object obj8 = UnityEngine.Random.value;
					float num = (float)obj * 1.5f;
					float xScale = (startingScale = num + 0.1f);
					if ((object)_animatedSprite != null)
					{
						PhaserSprite phaserSprite2 = _animatedSprite.setScale(xScale, (float?)(object)0);
						if ((object)_animatedSprite != null)
						{
							Transform transform = _animatedSprite.transform;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rax_v34 (UnityEngine.Transform)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rax_v34 (UnityEngine.Transform)+10]");
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected((IntPtr)0, ref value);
							PhaserSprite phaserSprite3 = _animatedSprite.setAlpha(0.15f);
							if (_alphaTween != null)
							{
								_alphaTween.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							if (array != null)
							{
								if ((object)_animatedSprite != null)
								{
									object obj9 = array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj10 = default(object);
									bool flag2 = obj10 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									_ = 1120403456;
									_ = 1120403456;
									_ = 1;
									MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
									_alphaTween = alphaTween;
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
									{
										Rate = 1f
									};
									object obj11 = UnityEngine.Random.value;
									float num2 = (float)Vector3.zeroVector - 0.5f;
									float detune = num2 * 200f;
									soundConfig.Volume = (float?)(object)1;
									soundConfig.Detune = detune;
									float time = default(float);
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hit, soundConfig, 200f, 3, time);
									return;
								}
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
		//IL_0168: Expected O, but got I4
		BaseBody baseBody = body;
		float num3;
		float num4;
		if ((nint)baseBody._velocity <= 0)
		{
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			Vector3 localEulerAngles = cachedTrans.localEulerAngles;
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 1000f;
			float num2 = num * 0.01f;
			num3 = localEulerAngles.z - num2;
			num4 = 1000f;
		}
		else
		{
			Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
			Vector3 localEulerAngles2 = cachedTrans2.localEulerAngles;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num5 = deltaTime2 * 1000f;
			float num6 = num5 * 0.01f;
			num3 = num6 + localEulerAngles2.z;
			num4 = 1000f;
		}
		base.angle = num3;
		float num7 = _animatedSprite.scale;
		float deltaTime3 = PauseSystem.DeltaTime;
		float num8 = deltaTime3 * num4;
		float num9 = num8 * 0.005f;
		float xScale = num9 + num7;
		PhaserSprite phaserSprite = _animatedSprite.setScale(xScale, (float?)(object)0);
	}

	public override void Despawn()
	{
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Despawn();
	}
}
