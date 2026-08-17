using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Ice1_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public TP_Ice1_Projectile _003C_003E4__this;

		public float2 offset;

		internal void _003CInitProjectile_003Eb__0()
		{
			Vector2 vector = default(Vector2);
			_003C_003E4__this.Attack(vector);
		}
	}

	private float _radius = 16f;

	private PhaserSprite _animatedSprite;

	private Tween _radiusTween;

	private PhaserSprite _staticSprite;

	private MultiTargetTween _alphaTween;

	protected override void Awake()
	{
		//IL_0228: Expected O, but got I4
		//IL_0228: Expected I4, but got O
		//IL_031f->IL0298: Incompatible stack heights: 1 vs 0
		//IL_01d5->IL0298: Incompatible stack heights: 1 vs 0
		//IL_01f7->IL0298: Incompatible stack heights: 1 vs 0
		//IL_0242->IL0298: Incompatible stack heights: 1 vs 0
		//IL_0275->IL0298: Incompatible stack heights: 1 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				PhaserWorld instance = PhaserWorld.Instance;
				if ((object)instance != null)
				{
					Vector2 vector = default(Vector2);
					PhaserSprite staticSprite = instance.AddPhaserSprite(vector, "ThosePeople", "TP_VFX_Ice08");
					_staticSprite = staticSprite;
					if ((object)_staticSprite != null)
					{
						PhaserSprite phaserSprite = _staticSprite.setAlpha(0f);
						if ((object)_staticSprite != null)
						{
							PhaserSprite phaserSprite2 = _staticSprite.setVisible(visible: false);
							if ((object)_staticSprite != null)
							{
								Transform transform = _staticSprite.transform;
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
								PhaserWorld instance2 = PhaserWorld.Instance;
								if ((object)instance2 != null)
								{
									PhaserSprite animatedSprite = instance2.AddPhaserSprite(vector, "ThosePeople", "TP_VFX_Ice01");
									_animatedSprite = animatedSprite;
									string text = default(string);
									int num = default(int);
									bool flag2 = default(bool);
									List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Ice", 1, 6, vector, text, num, flag2);
									PhaserSprite animatedSprite2 = _animatedSprite;
									if ((object)_animatedSprite != null && (object)animatedSprite2._spriteAnimation != null)
									{
										bool autoSetAnimation = default(bool);
										animatedSprite2._spriteAnimation.AddAnimation("explode", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag2, autoSetAnimation);
										if ((object)_animatedSprite != null)
										{
											PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: false);
											if ((object)_animatedSprite != null)
											{
												Transform transform2 = _animatedSprite.transform;
												bool flag3 = (object)transform2 == null;
												bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
												Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
												return;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0041: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		//IL_012f: Expected I4, but got I8
		//IL_03ea: Expected O, but got I4
		//IL_0406: Expected I4, but got I8
		//IL_015c: Expected O, but got I4
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected I4, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected I4, but got Unknown
		//IL_01f9: Expected O, but got I4
		//IL_0259: Expected O, but got I4
		//IL_02ee: Expected I, but got O
		//IL_0344: Expected O, but got I4
		//IL_0360: Expected O, but got I4
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals3._003C_003E4__this = this;
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		Weapon weapon2 = _weapon;
		float num = weapon2.PArea();
		float2 float5 = base.position;
		Weapon weapon3 = _weapon;
		float2 float6 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
		bool flag = (byte)(float5 < float6) != 0;
		object obj = float5 - float6;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj2 = flag4 & flag3;
		int num2 = (int)(_indexInWeapon & 0x80000001L);
		if (float5 < float6 != 0)
		{
			object obj3 = num2 - 1;
			object obj4 = obj3 | -2;
			num2 = obj4 + 1;
		}
		float num3 = _radius * 0.039f;
		object obj5 = default(object);
		float num4 = num3 * (float)obj5;
		CS_0024_003C_003E8__locals3.offset = (float2)0;
		bool flag5 = num2 == 1;
		bool flag6 = true;
		if (!flag5)
		{
			flag6 = true;
		}
		float num5 = (float)(flag6 ? 1 : 0) * num4;
		float2 float7 = base.position;
		float2 float8 = default(float2);
		base.position = float8;
		float2 float9 = base.position;
		PhaserSprite phaserSprite = _staticSprite.setPosition(float9);
		float2 float10 = base.position;
		PhaserSprite phaserSprite2 = _animatedSprite.setPosition(float10);
		bool flag7 = (byte)(obj2 ^ 1) != 0;
		PhaserSprite phaserSprite3 = _animatedSprite.setFlipX(flag7);
		object obj6 = num2 - 1;
		bool flag8 = obj6 == null;
		bool flag9 = !flag8;
		PhaserSprite phaserSprite4 = _animatedSprite.setFlipY(flag9);
		PhaserSprite phaserSprite5 = _staticSprite.setAlpha(0f);
		PhaserSprite phaserSprite6 = _staticSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite7 = _staticSprite.setVisible(visible: true);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_staticSprite != null)
		{
			nint num6 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.duration = 300f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Vector2 offset = default(Vector2);
			CS_0024_003C_003E8__locals3._003C_003E4__this.Attack(offset);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	private void CopyPosition()
	{
		float2 float5 = base.position;
		PhaserSprite phaserSprite = _staticSprite.setPosition(float5);
		float2 float6 = base.position;
		PhaserSprite phaserSprite2 = _animatedSprite.setPosition(float6);
	}

	private void Attack(Vector2 offset)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_006c: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_015b: Expected O, but got I4
		//IL_01b8: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = true;
		float num = _weapon.PArea();
		float num3 = default(float);
		float num2 = num3 * _radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = num2 ^ 0;
		BaseBody baseBody2 = body.setCircle(num2, (float?)(object)1, (float?)(object)1);
		Transform target = base.transform;
		float2 float5 = base.position;
		object obj2 = default(object);
		float endValue = (float)obj - (float)obj2;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMoveY(target, endValue, 0.3f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenCallback tweenCallback = StartDespawn;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v11 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 != 0)
		{
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 50f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_javelin, soundConfig, 30f, 1, time);
		PhaserSprite phaserSprite = _animatedSprite.setScale(num3, (float?)(object)0);
		PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(0.65f);
		PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: true);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("explode");
	}

	private void StartDespawn()
	{
		//IL_005e: Expected I, but got O
		//IL_00b6: Expected I, but got O
		//IL_011a: Expected O, but got I4
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_staticSprite != null)
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
		if ((object)_animatedSprite != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
			PhaserSprite phaserSprite2 = _staticSprite.setVisible(visible: false);
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	public override void Despawn()
	{
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _staticSprite.setVisible(visible: false);
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}

	private void _003CStartDespawn_003Eb__9_0()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _staticSprite.setVisible(visible: false);
		Despawn();
	}
}
