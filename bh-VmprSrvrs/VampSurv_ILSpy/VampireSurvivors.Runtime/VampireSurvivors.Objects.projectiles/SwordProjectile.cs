using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class SwordProjectile : Projectile
{
	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private float _previousArea;

	private float _detuneMul;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("slash_sword", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public void SetDetune(float value = 0f)
	{
		_detuneMul = value;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_067f: Expected O, but got I4
		//IL_005e: Expected I, but got O
		//IL_00f5: Expected O, but got I4
		//IL_014d: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		//IL_036c: Expected I, but got O
		//IL_01e1: Expected O, but got I4
		//IL_03da: Expected O, but got I4
		//IL_03e8: Expected O, but got I4
		//IL_022c: Expected I, but got O
		//IL_02c8: Expected O, but got I4
		//IL_02ed: Expected F4, but got I4
		//IL_02f6: Expected O, but got I4
		//IL_04ae: Expected I4, but got I8
		//IL_053d: Expected O, but got I4
		//IL_04e1: Expected O, but got I4
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Expected O, but got Unknown
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Expected I4, but got Unknown
		//IL_0510: Expected O, but got I4
		//IL_0749: Expected I, but got O
		//IL_0576: Expected O, but got I
		//IL_057c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Expected O, but got Unknown
		//IL_07b8: Expected I, but got O
		//IL_07cc: Expected I4, but got I8
		//IL_07f6: Expected O, but got I4
		//IL_05ef: Expected O, but got I4
		//IL_060f: Expected O, but got I4
		//IL_05b0: Expected O, but got I4
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected O, but got Unknown
		//IL_05c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Expected I4, but got Unknown
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		if ((object)weapon != null)
		{
			float num = weapon.PArea();
			float num2 = default(float);
			_previousArea = num2;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					float num4 = weapon.PArea();
					tweenConfig.duration = 100f;
					tweenConfig.ease = Ease.Linear;
					tweenConfig.scale = (float?)(object)1;
					MultiTargetTween tween = Tweens.Add(tweenConfig);
					_tween = tween;
					ArcadeSprite arcadeSprite2 = setAlpha(1f);
					bool flag = _tween == null;
					float num5 = 1f;
					SwordProjectile swordProjectile = null;
					object obj2 = 0;
					if (!flag)
					{
						float num6 = weapon.PArea();
						bool flag2 = _previousArea == num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018703F35Eh\"");
						num5 = 1f;
						swordProjectile = null;
						obj2 = 0;
						if (!flag2)
						{
							if (_tween != null)
							{
								_tween.Kill();
								ArcadeSprite arcadeSprite3 = setScale(0f, (float?)(object)0);
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								if (array2 != null)
								{
									nint num7 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj3 = default(object);
									if (obj3 == null)
									{
										ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
										throw ex2;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig2 != null)
									{
										tweenConfig2.targets = array2;
										swordProjectile = this;
										float num8 = weapon.PArea();
										tweenConfig2.duration = 100f;
										tweenConfig2.ease = Ease.Linear;
										tweenConfig2.scale = (float?)(object)1;
										MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
										_tween = tween2;
										num5 = 0f;
										obj2 = 0;
										goto IL_02fb;
									}
								}
							}
							goto IL_0651;
						}
					}
					goto IL_02fb;
				}
			}
		}
		goto IL_0651;
		IL_02fb:
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		Delegate[] array3 = (Delegate[])new object[1];
		if (array3 != null)
		{
			nint num9 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig3 != null)
			{
				((EventEmitter)(object)tweenConfig3).callbacks = array3;
				((Group)(object)tweenConfig3).children = (HashSet<PhaserGameObject>)1120403456;
				((Group)(object)tweenConfig3).childrenToRemove = (HashSet<PhaserGameObject>)1;
				_ = 1120403456;
				_ = 1;
				TweenCallback pool2 = delegate
				{
					base.Despawn();
				};
				((BulletPool)(object)tweenConfig3)._pool = (ObjectPool)(object)pool2;
				MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
				_tween2 = tween3;
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					bool flag3 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX;
					int num10 = (int)(_indexInWeapon & 0x80000001L);
					if ((nint)((Equipment)weapon2)._003COwner_003Ek__BackingField < 0)
					{
						object obj5 = num10 - 1;
						object obj6 = obj5 | -2;
						num10 = obj6 + 1;
					}
					bool flag5;
					if (flag3)
					{
						object obj7 = num10 - 1;
						bool flag4 = obj7 == null;
						flag5 = !flag4;
					}
					else
					{
						object obj8 = num10 - 1;
						bool flag6 = obj8 == null;
						flag5 = flag6;
					}
					BulletPool cachedTransform = (BulletPool)(object)_cachedTransform;
					if ((object)_cachedTransform != null)
					{
						bool flag7 = ((EventEmitter)cachedTransform).callbacks == null;
						Transform.get_position_Injected((IntPtr)((EventEmitter)cachedTransform).callbacks, out Vector3 _);
						if (flag5)
						{
						}
						BulletPool cachedTransform2 = (BulletPool)(object)_cachedTransform;
						bool flag8 = (object)_cachedTransform == null;
						bool flag9 = ((EventEmitter)cachedTransform2).callbacks == null;
						object obj9 = (nint)0 ^ (nint)0;
						object obj10 = 0 & obj9;
						bool flag10 = (nint)obj10 < 0;
						bool flag11 = (nint)0 < (nint)0;
						Vector3 value = default(Vector3);
						Transform.set_position_Injected((IntPtr)((EventEmitter)cachedTransform2).callbacks, ref value);
						int num11 = (int)(_indexInWeapon & 0x80000001L);
						if (flag11 != flag10)
						{
							object obj11 = num11 - 1;
							object obj12 = obj11 | -2;
							num11 = obj12 + 1;
						}
						object obj13 = num11 - 1;
						bool flag12 = obj13 == null;
						ArcadeSprite arcadeSprite4 = setFlipY(flag12);
						ArcadeSprite arcadeSprite5 = setFlipX(flag5);
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
						{
							Rate = 1f
						};
						object obj14 = _indexInWeapon * -100;
						float num12 = _detuneMul * 400f;
						soundConfig.Volume = (float?)(object)1;
						float detune = num12 + (float)obj14;
						soundConfig.Detune = detune;
						float time = default(float);
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack1, soundConfig, 0f, 10, time);
						return;
					}
				}
			}
		}
		goto IL_0651;
		IL_0651:
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__6_0()
	{
		base.Despawn();
	}
}
