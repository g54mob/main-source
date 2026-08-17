using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class VentoProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private readonly uint[] _color = new uint[3] { 13434879u, 1048575u, 4508927u };

	private SpriteAnimation _anims;

	private float prevArea;

	public override float ProjectileSpeed
	{
		get
		{
			//IL_001d: Invalid comparison between F4 and O
			//IL_0037: Expected F4, but got I4
			float num = _weapon.PSpeed();
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				return 0f;
			}
			float num2 = _weapon.PSpeed();
			float num3 = (float)obj - 1f;
			float num4 = num3 * GameManager.ProjectileSpeed;
			return num4 * _speed;
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0123: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected I4, but got Unknown
		//IL_02a4: Expected O, but got I4
		//IL_02c6: Expected O, but got I4
		//IL_059b: Expected O, but got I4
		//IL_070d: Expected I4, but got O
		//IL_0492: Expected O, but got I4
		//IL_060d: Expected I, but got O
		//IL_0821: Expected O, but got I4
		//IL_0821: Expected F4, but got I4
		//IL_0839: Expected I4, but got I8
		//IL_0d82: Expected O, but got I4
		//IL_0867: Expected O, but got I4
		//IL_0870: Unknown result type (might be due to invalid IL or missing references)
		//IL_0875: Expected O, but got Unknown
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0883: Expected I4, but got Unknown
		//IL_093a: Expected O, but got Ref
		//IL_0a51: Expected I4, but got I8
		//IL_0dc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcd: Expected O, but got Unknown
		//IL_0b8a: Expected O, but got I4
		//IL_0ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba5: Expected I4, but got Unknown
		//IL_0bde: Expected O, but got I4
		//IL_0c2c: Expected F4, but got I4
		//IL_0d38->IL0c31: Incompatible stack heights: 1 vs 0
		//IL_076d->IL0c31: Incompatible stack heights: 1 vs 0
		//IL_07d6->IL0ca5: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		SpriteAnimation anims = _anims;
		if ((object)_anims != null && ((UnityEngine.Object)anims).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0113;
		}
		int num = default(int);
		if ((object)_renderer != null)
		{
			GameObject gameObject = _renderer.gameObject;
			if ((object)gameObject != null)
			{
				SpriteAnimation anims2 = gameObject.AddComponent<SpriteAnimation>();
				_anims = anims2;
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("petal", 1, 5, "vfx", num);
				if ((object)_anims != null)
				{
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					_anims.AddAnimation("strike", animationFrames, 60, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
					goto IL_0113;
				}
			}
		}
		goto IL_0c31;
		IL_0c31:
		throw new NullReferenceException();
		IL_0ca5:
		bool flag;
		ArcadeSprite arcadeSprite = setFlipX(flag);
		if (!flag)
		{
			goto IL_0cc1;
		}
		BaseBody baseBody = body;
		Vector3 ret = default(Vector3);
		if (body != null && baseBody._transform != null)
		{
			bool flag2 = !flag;
			bool flag3 = !flag2;
			ArcadeSprite arcadeSprite2 = setOrigin(flag3 ? 1 : 0, (float?)(object)1);
			int num2 = (int)(_indexInWeapon & 0x80000001L);
			if ((flag ? 1 : 0) < (false ? 1 : 0))
			{
				object obj = num2 - 1;
				object obj2 = obj | -2;
				num2 = obj2 + 1;
			}
			bool flag4 = !flag;
			object obj3 = num2 - (flag4 ? 1 : 0);
			bool flag5 = obj3 == null;
			ArcadeSprite arcadeSprite3 = setFlipY(flag5);
			if (new float[13]
			{
				0f, 5f, -5f, 1.5f, -2.5f, 10f, -10f, 7.5f, -7.5f, 15f,
				-15f, 12.5f, -12.5f
			} != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
				if (new double[13]
				{
					0.0, 5.0, -5.0, 1.5, -2.5, 10.0, -10.0, 7.5, -7.5, 15.0,
					-15.0, 12.5, -12.5
				} != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
					Transform transform = base.transform;
					if ((object)transform != null)
					{
						transform.localEulerAngles = (Vector3)(&ret);
						Weapon weapon2 = _weapon;
						_speed = 1f;
						if ((object)_weapon != null)
						{
							if (weapon2.IsHoming)
							{
								goto IL_0ab0;
							}
							if (body != null)
							{
								float projectileSpeed = ProjectileSpeed;
								Weapon weapon3 = _weapon;
								if ((object)_weapon != null)
								{
									VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
									{
										BaseBody baseBody2 = characterController.body;
										if (characterController.body != null)
										{
											int num3 = -1;
											if (!flag)
											{
												num3 = 1;
											}
											float2 float5 = default(float2);
											object obj4 = num3 * float5;
											object obj5 = obj4 + (object)baseBody2._velocity;
											Weapon weapon4 = _weapon;
											if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
											{
												float2 float6 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.position;
												base.position = float5;
												goto IL_0ab0;
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
		goto IL_0c31;
		IL_0cc1:
		int num4 = default(int);
		if (num4 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1589 @ rax_v90 (System.Int32)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1589 @ rax_v90 (System.Int32)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1589 @ rax_v90 (System.Int32)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				Weapon weapon5 = _weapon;
				if ((object)_weapon == null || (object)((Equipment)weapon5)._003COwner_003Ek__BackingField == null)
				{
					goto IL_0c31;
				}
				float2 float7 = ((Equipment)weapon5)._003COwner_003Ek__BackingField.position;
				bool flag7 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7) < System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret);
				object obj6 = (object)float7 - (object)ret;
				bool flag8 = obj6 == null;
				bool flag9 = !flag7;
				bool flag10 = !flag8;
				flag = flag10 & flag9;
			}
		}
		goto IL_0ca5;
		IL_0676:
		Weapon weapon6 = _weapon;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon6)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon6)._003COwner_003Ek__BackingField != null)
			{
				flag = characterController2._isFlipped;
				if (!weapon6.IsHoming)
				{
					goto IL_0ca5;
				}
				num4 = (int)base.AimForNearestEnemy(rotate: false);
				goto IL_0cc1;
			}
		}
		goto IL_0c31;
		IL_0ab0:
		Weapon weapon7 = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon7)._003COwner_003Ek__BackingField != null)
		{
			int num5 = ((Equipment)weapon7)._003COwner_003Ek__BackingField.Depth;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)_renderer != null)
				{
					int num6 = renderer.pixelHeight >> 31;
					object obj7 = renderer.pixelHeight - num6;
					object obj8 = obj7 >> 1;
					int sortingOrder = num5 + obj8;
					_renderer.sortingOrder = sortingOrder;
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Rate = 1f;
					soundConfig.Volume = (float?)(object)1;
					soundConfig.Rate = 2f;
					float detune = (float)_indexInWeapon * 100f;
					soundConfig.Detune = detune;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Whip, soundConfig, 0f, 10, num);
					return;
				}
			}
		}
		goto IL_0c31;
		IL_0113:
		ArcadeSprite arcadeSprite4 = setOrigin(0f, (float?)(object)1);
		ArcadeSprite arcadeSprite5 = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite6 = setAlpha(0.5f);
		float num9 = default(float);
		if ((object)_anims != null)
		{
			_anims.SetAnimation("strike");
			uint[] color = _color;
			if (_color != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
				object obj9 = (object)"strike" >> 31;
				object obj10 = "strike" + obj9;
				object obj11 = obj10 * 2;
				object obj12 = obj10 + obj11;
				int num7 = index - obj12;
				ArcadeSprite arcadeSprite7 = setTint(color[num7]);
				if (_scaleTween != null)
				{
					if ((object)_weapon == null)
					{
						goto IL_0c31;
					}
					float num8 = _weapon.PArea();
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187302F5Ah\"");
					if (prevArea == num9)
					{
						bool flag11 = _scaleTween == null;
						object obj13 = 0;
						if (!flag11)
						{
							_scaleTween.Restart();
							obj13 = 0;
						}
						goto IL_0497;
					}
				}
				if ((object)_weapon != null)
				{
					float num10 = _weapon.PArea();
					prevArea = num9;
					if (_scaleTween != null)
					{
						_scaleTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					Transform transform2 = base.transform;
					if (array != null)
					{
						if ((object)transform2 != null)
						{
							object obj14 = array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj15 = default(object);
							if (obj15 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null && (object)_weapon != null)
						{
							float num11 = _weapon.PArea();
							_ = 1128792064;
							_ = 1;
							_ = 1;
							_ = 1;
							MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
							if (multiTargetTween != null)
							{
								MultiTargetTween scaleTween = multiTargetTween.SetAutoKill(autoKill: false);
								_scaleTween = scaleTween;
								object obj13 = 0;
								goto IL_0497;
							}
						}
					}
				}
			}
		}
		goto IL_0c31;
		IL_0497:
		if (_alphaTween != null)
		{
			_alphaTween.Restart();
			goto IL_0676;
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if (array2 != null)
		{
			if ((object)_renderer != null)
			{
				int value = ((int*)(&array2))->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj16 = default(object);
				if (obj16 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig2 != null)
			{
				tweenConfig2.targets = array2;
				tweenConfig2.alpha = (float?)(object)1;
				if ((object)_weapon != null)
				{
					float num12 = _weapon.PDuration();
					tweenConfig2.duration = num9;
					tweenConfig2.ease = Ease.Linear;
					tweenConfig2.delay = 100f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ r8_v29 (Il2CppClass<VampireSurvivors.Objects.Projectiles.VentoProjectile>)+370]");
					TweenCallback onComplete2 = new TweenCallback(this, (IntPtr)0);
					nint num13 = (nint)this;
					tweenConfig2.onComplete = onComplete2;
					MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
					if (multiTargetTween2 != null)
					{
						MultiTargetTween alphaTween = multiTargetTween2.SetAutoKill(autoKill: false);
						_alphaTween = alphaTween;
						goto IL_0676;
					}
				}
			}
		}
		goto IL_0c31;
	}
}
