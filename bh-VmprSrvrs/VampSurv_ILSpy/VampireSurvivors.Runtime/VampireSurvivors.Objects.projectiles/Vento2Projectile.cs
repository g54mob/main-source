using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
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
using Zenject;

namespace VampireSurvivors.Objects.Projectiles;

public class Vento2Projectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private SpriteAnimation _anims;

	private PhaserSprite _ghost1;

	private PhaserSprite _ghost2;

	private float _previousPArea;

	private float _previousPDuration;

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
		//IL_0008: Expected O, but got Ref
		//IL_13d0: Expected O, but got Ref
		//IL_1425: Expected O, but got I4
		//IL_015a: Expected O, but got I
		//IL_04ec: Expected F4, but got O
		//IL_045c: Invalid comparison between O and F4
		//IL_048d: Expected O, but got I4
		//IL_01d8: Expected O, but got I
		//IL_04af: Expected O, but got I4
		//IL_0559: Expected I, but got O
		//IL_076a: Expected F4, but got O
		//IL_06ec: Invalid comparison between O and F4
		//IL_0632: Expected O, but got I
		//IL_027e: Expected O, but got I
		//IL_07ca: Expected I, but got O
		//IL_0686: Expected O, but got I4
		//IL_0821: Expected I, but got O
		//IL_0b6a: Expected O, but got I
		//IL_0b6a: Expected F4, but got I4
		//IL_0b82: Expected I4, but got I8
		//IL_1512: Expected O, but got I4
		//IL_0bb0: Expected O, but got I4
		//IL_0bb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbe: Expected O, but got Unknown
		//IL_0bc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcc: Expected I4, but got Unknown
		//IL_0c04: Expected O, but got I
		//IL_0c28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2d: Expected O, but got Unknown
		//IL_0c37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3c: Expected O, but got Unknown
		//IL_0a6e: Invalid comparison between I and F4
		//IL_0a99: Invalid comparison between F4 and I4
		//IL_0cb0: Expected O, but got I
		//IL_0cb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbb: Expected O, but got Unknown
		//IL_0cc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc9: Expected O, but got Unknown
		//IL_0ced: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf2: Expected O, but got Unknown
		//IL_0d30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d35: Expected O, but got Unknown
		//IL_0d6f: Expected O, but got Ref
		//IL_0ea2: Expected O, but got I8
		//IL_0eb8: Expected O, but got I4
		//IL_0fcd: Expected O, but got I4
		//IL_0fda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdf: Expected O, but got Unknown
		//IL_0ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffa: Expected I4, but got Unknown
		//IL_104c: Expected O, but got I
		//IL_109a: Expected F4, but got I4
		//IL_1147: Expected O, but got I
		//IL_1147: Expected F4, but got O
		//IL_11f4: Expected O, but got I
		//IL_11f4: Expected F4, but got O
		//IL_15fe: Expected O, but got Ref
		//IL_1655: Expected O, but got Ref
		//IL_16ac: Expected O, but got Ref
		//IL_16be: Expected I, but got O
		//IL_0076->IL1356: Incompatible stack heights: 1 vs 0
		//IL_00a2->IL1356: Incompatible stack heights: 1 vs 0
		//IL_1452->IL1356: Incompatible stack heights: 1 vs 0
		//IL_0103->IL1356: Incompatible stack heights: 1 vs 0
		//IL_04ce->IL1356: Incompatible stack heights: 1 vs 0
		//IL_0434->IL1356: Incompatible stack heights: 1 vs 0
		//IL_01b9->IL1356: Incompatible stack heights: 1 vs 0
		//IL_052f->IL1356: Incompatible stack heights: 1 vs 0
		//IL_01f4->IL1356: Incompatible stack heights: 1 vs 0
		//IL_059e->IL1356: Incompatible stack heights: 1 vs 0
		//IL_074c->IL1356: Incompatible stack heights: 1 vs 0
		//IL_057c->IL057c: Incompatible stack heights: 2 vs 1
		//IL_06c4->IL1356: Incompatible stack heights: 1 vs 0
		//IL_05cf->IL1356: Incompatible stack heights: 1 vs 0
		//IL_079e->IL1356: Incompatible stack heights: 1 vs 0
		//IL_025f->IL1356: Incompatible stack heights: 1 vs 0
		//IL_029a->IL1356: Incompatible stack heights: 1 vs 0
		//IL_065c->IL1356: Incompatible stack heights: 1 vs 0
		//IL_080f->IL1356: Incompatible stack heights: 1 vs 0
		//IL_092f->IL1356: Incompatible stack heights: 1 vs 0
		//IL_07ed->IL07ed: Incompatible stack heights: 2 vs 1
		//IL_02c9->IL1356: Incompatible stack heights: 1 vs 0
		//IL_095e->IL1356: Incompatible stack heights: 1 vs 0
		//IL_085f->IL1356: Incompatible stack heights: 1 vs 0
		//IL_0313->IL1356: Incompatible stack heights: 1 vs 0
		//IL_1496->IL1356: Incompatible stack heights: 1 vs 0
		//IL_0335->IL1356: Incompatible stack heights: 1 vs 0
		//IL_0ae4->IL1356: Incompatible stack heights: 1 vs 0
		//IL_08e5->IL1356: Incompatible stack heights: 1 vs 0
		//IL_038a->IL1356: Incompatible stack heights: 1 vs 0
		//IL_14f1->IL1356: Incompatible stack heights: 1 vs 0
		//IL_0b1c->IL1356: Incompatible stack heights: 1 vs 0
		//IL_03ac->IL1356: Incompatible stack heights: 1 vs 0
		//IL_0be9->IL1356: Incompatible stack heights: 1 vs 0
		//IL_0a1b->IL1356: Incompatible stack heights: 1 vs 0
		//IL_0a3d->IL1356: Incompatible stack heights: 1 vs 0
		//IL_0c95->IL1356: Incompatible stack heights: 2 vs 0
		//IL_0d57->IL1356: Incompatible stack heights: 3 vs 0
		//IL_0db0->IL1356: Incompatible stack heights: 3 vs 0
		//IL_0f29->IL1356: Incompatible stack heights: 3 vs 0
		//IL_0dfe->IL1356: Incompatible stack heights: 3 vs 0
		//IL_0f4b->IL1356: Incompatible stack heights: 3 vs 0
		//IL_0e32->IL1356: Incompatible stack heights: 3 vs 0
		//IL_15c7->IL1356: Incompatible stack heights: 3 vs 0
		//IL_0e61->IL1356: Incompatible stack heights: 3 vs 0
		//IL_0f91->IL1356: Incompatible stack heights: 3 vs 0
		//IL_0e90->IL1356: Incompatible stack heights: 3 vs 0
		//IL_0fb5->IL1356: Incompatible stack heights: 3 vs 0
		//IL_15a0->IL1356: Incompatible stack heights: 3 vs 0
		//IL_0eda->IL1356: Incompatible stack heights: 3 vs 0
		//IL_10c2->IL1356: Incompatible stack heights: 3 vs 0
		//IL_10f1->IL1356: Incompatible stack heights: 3 vs 0
		//IL_1122->IL1356: Incompatible stack heights: 3 vs 0
		//IL_116f->IL1356: Incompatible stack heights: 3 vs 0
		//IL_119e->IL1356: Incompatible stack heights: 3 vs 0
		//IL_11cf->IL1356: Incompatible stack heights: 3 vs 0
		//IL_1212->IL1356: Incompatible stack heights: 3 vs 0
		//IL_1240->IL1356: Incompatible stack heights: 3 vs 0
		//IL_127b->IL1356: Incompatible stack heights: 3 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		Transform cachedTransform = _cachedTransform;
		int num;
		bool flag3;
		Vector2 vector = default(Vector2);
		if ((object)_cachedTransform != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj3);
			Transform anims = (Transform)(object)_anims;
			int num2 = default(int);
			if ((object)_anims != null)
			{
				bool flag2 = ((UnityEngine.Object)anims).m_CachedPtr != (IntPtr)0;
				num = 1;
				flag3 = (byte)num2 != 0;
				if (flag2)
				{
					goto IL_1415;
				}
			}
			if ((object)_renderer != null)
			{
				GameObject gameObject = _renderer.gameObject;
				if ((object)gameObject != null)
				{
					SpriteAnimation anims2 = gameObject.AddComponent<SpriteAnimation>();
					_anims = anims2;
					List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("petal", 1, 5, "vfx", num2);
					if ((object)_anims != null)
					{
						bool startRandomFrame = default(bool);
						Action onComplete = default(Action);
						bool autoSetAnimation = default(bool);
						_anims.AddAnimation("strike", animationFrames, 60, (byte)num2 != 0, startRandomFrame, onComplete, autoSetAnimation);
						_ = 0;
						_ = 1056964608;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
						ArcadeSprite arcadeSprite = setOrigin(0f, (float?)(object)0);
						ArcadeSprite arcadeSprite2 = setTint(1114129u);
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(this, vector, "vfx", "petal5");
						_ = 0;
						_ = 1056964608;
						_ = 1;
						if ((object)phaserSprite != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
							PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0f, (float?)(object)0);
							if ((object)phaserSprite2 != null)
							{
								PhaserSprite ghost = phaserSprite2.setTint(16711680u);
								_ghost1 = ghost;
								flag3 = (byte)num2 != 0;
								GameObject gameObject2 = base.gameObject;
								PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "vfx", "petal5");
								_ = 0;
								_ = 1056964608;
								_ = 1;
								if ((object)phaserSprite3 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
									PhaserSprite phaserSprite4 = phaserSprite3.setOrigin(0f, (float?)(object)0);
									if ((object)phaserSprite4 != null)
									{
										PhaserSprite phaserSprite5 = phaserSprite4.setTint(6684774u);
										if ((object)phaserSprite5 != null)
										{
											PhaserSprite ghost2 = phaserSprite5.setBlendMode(BlendMode.Add);
											_ghost2 = ghost2;
											PhaserSprite ghost3 = _ghost1;
											if ((object)_ghost1 != null && (object)ghost3._spriteAnimation != null)
											{
												ghost3._spriteAnimation.AddAnimation("strike", animationFrames, 60, (byte)num2 != 0, startRandomFrame, onComplete, autoSetAnimation);
												PhaserSprite ghost4 = _ghost2;
												if ((object)_ghost2 != null && (object)ghost4._spriteAnimation != null)
												{
													ghost4._spriteAnimation.AddAnimation("strike", animationFrames, 60, (byte)num2 != 0, startRandomFrame, onComplete, autoSetAnimation);
													num = 1;
													goto IL_1415;
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
		}
		goto IL_1356;
		IL_1415:
		ArcadeSprite arcadeSprite3 = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite4 = setAlpha(0.5f);
		if ((object)_anims != null)
		{
			_anims.SetAnimation("strike");
			if (_scaleTween != null)
			{
				if ((object)_weapon == null)
				{
					goto IL_1356;
				}
				float num3 = _weapon.PArea();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187301807h\"");
				if ((object)vector == (object)_previousPArea)
				{
					bool flag4 = _scaleTween == null;
					object obj4 = 0;
					if (!flag4)
					{
						_scaleTween.Restart();
						obj4 = 0;
					}
					goto IL_068b;
				}
			}
			if ((object)_weapon != null)
			{
				float num4 = _weapon.PArea();
				_previousPArea = (float)vector;
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[num];
				Transform transform = base.transform;
				if (array != null)
				{
					if ((object)transform != null)
					{
						nint num5 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj5 = default(object);
						bool flag5 = obj5 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						if ((object)_weapon != null)
						{
							_ = 0;
							float num6 = _weapon.PArea();
							tweenConfig.duration = 200f;
							tweenConfig.yoyo = true;
							tweenConfig.ease = (Ease)num;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
							tweenConfig.scale = (float?)(object)0;
							MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
							if (multiTargetTween != null)
							{
								MultiTargetTween scaleTween = multiTargetTween.SetAutoKill(autoKill: false);
								_scaleTween = scaleTween;
								object obj4 = 0;
								goto IL_068b;
							}
						}
					}
				}
			}
		}
		goto IL_1356;
		IL_068b:
		if (_alphaTween != null)
		{
			if ((object)_weapon == null)
			{
				goto IL_1356;
			}
			float num7 = _weapon.PDuration();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187301A1Bh\"");
			if ((object)vector == (object)_previousPDuration)
			{
				if (_alphaTween != null)
				{
					_alphaTween.Restart();
				}
				goto IL_090b;
			}
		}
		if ((object)_weapon != null)
		{
			float num8 = _weapon.PDuration();
			_previousPDuration = (float)vector;
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[num];
			if (array2 != null)
			{
				if ((object)_renderer != null)
				{
					nint num9 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj6 = default(object);
					bool flag6 = obj6 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig2 != null)
				{
					((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
					_ = 0;
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
					_ = 0;
					if ((object)_weapon != null)
					{
						float num10 = _weapon.PDuration();
						((MonoBehaviour)(object)tweenConfig2).m_CancellationTokenSource = (CancellationTokenSource)vector;
						((GameMonoBehaviour)(object)tweenConfig2)._onPauseSent = (byte)num != 0;
						_ = 1120403456;
						TweenCallback signalBus = delegate
						{
							Despawn();
						};
						((Equipment)(object)tweenConfig2)._signalBus = (SignalBus)(object)signalBus;
						MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
						if (multiTargetTween2 != null)
						{
							MultiTargetTween alphaTween = multiTargetTween2.SetAutoKill(autoKill: false);
							_alphaTween = alphaTween;
							goto IL_090b;
						}
					}
				}
			}
		}
		goto IL_1356;
		IL_1356:
		throw new NullReferenceException();
		IL_090b:
		Weapon weapon2 = _weapon;
		bool flag8;
		bool flag18;
		if ((object)_weapon != null)
		{
			Transform transform2 = (Transform)(object)((Equipment)weapon2)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				bool flag7 = !weapon2.IsHoming;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdi_v20 (UnityEngine.Transform)+242]");
				flag8 = false;
				if (!flag7)
				{
					Weapon weapon3 = (Weapon)(object)base.AimForNearestEnemy(rotate: false);
					bool flag9 = (object)weapon3 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdi_v20 (UnityEngine.Transform)+242]");
					flag8 = false;
					if (!flag9)
					{
						bool flag10 = ((UnityEngine.Object)weapon3).m_CachedPtr == (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdi_v20 (UnityEngine.Transform)+242]");
						flag8 = false;
						if (!flag10)
						{
							Vector3 vector2 = ((Transform)(object)weapon3).position;
							Weapon weapon4 = _weapon;
							if ((object)_weapon == null || (object)((Equipment)weapon4)._003COwner_003Ek__BackingField == null)
							{
								goto IL_1356;
							}
							float2 float5 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
							bool flag11 = 0f < vector2.x;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
							float num11 = 0f - vector2.x;
							bool flag12 = num11 == 0f;
							bool flag13 = !flag11;
							bool flag14 = !flag12;
							flag8 = flag14 & flag13;
						}
					}
				}
				ArcadeSprite arcadeSprite5 = setFlipX(flag8);
				Weapon weapon5 = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
				{
					BaseBody baseBody = default(BaseBody);
					if (flag8)
					{
						baseBody = body;
						if (body == null)
						{
							goto IL_1356;
						}
					}
					ArcadeTransform arcadeTransform = baseBody._transform;
					if (baseBody._transform != null)
					{
						_ = 0;
						bool flag15 = !flag8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rcx_v45 (ArcadeTransform)+78]");
						_ = 0;
						bool flag16 = !flag15;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
						ArcadeSprite arcadeSprite6 = setOrigin(flag16 ? 1 : 0, (float?)(object)0);
						int num12 = (int)(_indexInWeapon & 0x80000001L);
						if ((flag8 ? 1 : 0) < (false ? 1 : 0))
						{
							object obj7 = num12 - 1;
							object obj8 = obj7 | -2;
							num12 = obj8 + 1;
						}
						bool flag17 = !flag8;
						object obj9 = num12 - (flag17 ? 1 : 0);
						flag18 = obj9 == null;
						ArcadeSprite arcadeSprite7 = setFlipY(flag18);
						float[] array3 = new float[13]
						{
							0f, 5f, -5f, 1.5f, -2.5f, 10f, -10f, 7.5f, -7.5f, 15f,
							-15f, 12.5f, -12.5f
						};
						if (array3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
							object obj10 = (nint)0 >> 2;
							object obj11 = obj10 >> 31;
							object obj12 = obj10 + obj11;
							object obj13 = obj12 * 13;
							object obj14 = _indexInWeapon - obj13;
							CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)(object)array3).m_CancellationTokenSource;
							bool flag19 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14) >= System.Runtime.CompilerServices.Unsafe.As<CancellationTokenSource, UIntPtr>(ref cancellationTokenSource);
							float[] array4 = new float[13]
							{
								0f, 5f, -5f, 1.5f, -2.5f, 10f, -10f, 7.5f, -7.5f, 15f,
								-15f, 12.5f, -12.5f
							};
							if (array4 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
								object obj15 = (nint)0 >> 31;
								object obj16 = 0 + obj15;
								object obj17 = obj16 * 2;
								object obj18 = obj16 + obj17;
								object obj19 = obj18 + obj18;
								object obj20 = _indexInWeapon - obj19;
								CancellationTokenSource cancellationTokenSource2 = ((MonoBehaviour)(object)array4).m_CancellationTokenSource;
								bool flag20 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj20) >= System.Runtime.CompilerServices.Unsafe.As<CancellationTokenSource, UIntPtr>(ref cancellationTokenSource2);
								float num13 = array4[obj20];
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
								object obj21 = num13 ^ 0;
								Transform transform3 = base.transform;
								if ((object)transform3 != null)
								{
									Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
									transform3.localEulerAngles = localEulerAngles;
									Weapon weapon6 = _weapon;
									_speed = 1f;
									if ((object)_weapon != null)
									{
										if (weapon6.IsHoming)
										{
											goto IL_0f05;
										}
										Weapon weapon7 = (Weapon)(object)body;
										if (body != null)
										{
											float projectileSpeed = ProjectileSpeed;
											Weapon weapon8 = _weapon;
											if ((object)_weapon != null)
											{
												VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon8)._003COwner_003Ek__BackingField;
												if ((object)((Equipment)weapon8)._003COwner_003Ek__BackingField != null)
												{
													BaseBody baseBody2 = characterController.body;
													if (characterController.body != null)
													{
														BulletPool bulletPool = (BulletPool)4294967295L;
														if (!flag8)
														{
															bulletPool = (BulletPool)num;
														}
														object obj22 = (object)bulletPool * (object)vector;
														GameManager gameMan = (GameManager)(object)(obj22 + (object)baseBody2._velocity);
														weapon7._gameMan = gameMan;
														Weapon weapon9 = _weapon;
														if ((object)_weapon != null && (object)((Equipment)weapon9)._003COwner_003Ek__BackingField != null)
														{
															float2 float6 = ((Equipment)weapon9)._003COwner_003Ek__BackingField.position;
															base.position = vector;
															goto IL_0f05;
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
				}
			}
		}
		goto IL_1356;
		IL_0f05:
		Weapon weapon10 = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon10)._003COwner_003Ek__BackingField != null)
		{
			int num14 = ((Equipment)weapon10)._003COwner_003Ek__BackingField.Depth;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null && (object)_renderer != null)
				{
					object obj23 = renderer.pixelHeight >> 31;
					object obj24 = renderer.pixelHeight - obj23;
					object obj25 = obj24 >> 1;
					int sortingOrder = num14 + obj25;
					_renderer.sortingOrder = sortingOrder;
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					_ = 0;
					_ = 1065353216;
					_ = 1;
					soundConfig.Rate = 1f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
					soundConfig.Volume = (float?)(object)0;
					soundConfig.Rate = 2f;
					float detune = (float)_indexInWeapon * 100f;
					soundConfig.Detune = detune;
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Whip, soundConfig, 0f, 10, flag3 ? 1 : 0);
					BaseBody baseBody3 = body;
					if (body != null)
					{
						ArcadeTransform arcadeTransform2 = baseBody3._transform;
						if (baseBody3._transform != null)
						{
							_ = 0;
							_ = 1056964608;
							_ = 1;
							if ((object)_ghost1 != null)
							{
								PhaserSprite ghost5 = _ghost1;
								float2 obj26 = arcadeTransform2._origin;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
								PhaserSprite phaserSprite6 = ghost5.setOrigin((float)obj26, (float?)(object)0);
								BaseBody baseBody4 = body;
								if (body != null)
								{
									ArcadeTransform arcadeTransform3 = baseBody4._transform;
									if (baseBody4._transform != null)
									{
										_ = 0;
										_ = 1056964608;
										_ = 1;
										if ((object)_ghost2 != null)
										{
											PhaserSprite ghost6 = _ghost2;
											float2 obj27 = arcadeTransform3._origin;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
											PhaserSprite phaserSprite7 = ghost6.setOrigin((float)obj27, (float?)(object)0);
											if ((object)_ghost1 != null)
											{
												Transform transform4 = _ghost1.transform;
												if ((object)_ghost2 != null)
												{
													Transform transform5 = _ghost2.transform;
													Transform transform6 = base.transform;
													if ((object)transform6 != null)
													{
														_ = 0;
														bool flag21 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
														object obj28 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
														Transform.get_rotation_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out *(Quaternion*)obj28);
														bool flag22 = (object)transform5 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
														_ = 0;
														bool flag23 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
														object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
														Transform.set_rotation_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Quaternion*)obj29);
														bool flag24 = (object)transform4 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
														_ = 0;
														bool flag25 = ((EventEmitter)(object)transform4).callbacks == null;
														object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
														Transform.set_rotation_Injected((IntPtr)((EventEmitter)(object)transform4).callbacks, ref *(Quaternion*)obj30);
														bool flag26 = (object)_ghost1 == null;
														PhaserSprite phaserSprite8 = _ghost1.setFlipX(flag8);
														bool flag27 = (object)_ghost2 == null;
														PhaserSprite phaserSprite9 = _ghost2.setFlipX(flag8);
														bool flag28 = (object)_ghost1 == null;
														PhaserSprite phaserSprite10 = _ghost1.setFlipY(flag18);
														bool flag29 = (object)_ghost2 == null;
														PhaserSprite phaserSprite11 = _ghost2.setFlipY(flag18);
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
			}
		}
		goto IL_1356;
	}

	public override void InternalUpdate()
	{
		//IL_013c->IL00eb: Incompatible stack heights: 1 vs 0
		//IL_007c->IL00eb: Incompatible stack heights: 1 vs 0
		//IL_0195->IL00eb: Incompatible stack heights: 2 vs 0
		if ((object)_ghost1 != null)
		{
			Transform transform = _ghost1.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				if ((object)_ghost2 != null)
				{
					Transform transform2 = _ghost2.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Vector3 value2 = default(Vector3);
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
						Transform renderer = (Transform)(object)_renderer;
						if ((object)_renderer != null)
						{
							bool flag3 = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
							SpriteRenderer.get_color_Injected(((UnityEngine.Object)renderer).m_CachedPtr, out Color ret);
							bool flag4 = (object)_ghost1 == null;
							float alpha = default(float);
							PhaserSprite phaserSprite = _ghost1.setAlpha(alpha);
							Vento2Projectile renderer2 = (Vento2Projectile)(object)_renderer;
							bool flag5 = (object)_renderer == null;
							bool flag6 = ((UnityEngine.Object)renderer2).m_CachedPtr == (IntPtr)0;
							SpriteRenderer.get_color_Injected(((UnityEngine.Object)renderer2).m_CachedPtr, out ret);
							bool flag7 = (object)_ghost2 == null;
							PhaserSprite phaserSprite2 = _ghost2.setAlpha(alpha);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		PhaserSprite ghost = _ghost1;
		if ((object)_ghost1 != null && ((UnityEngine.Object)ghost).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _ghost1.setAlpha(0f);
		}
		PhaserSprite ghost2 = _ghost2;
		if ((object)_ghost2 != null && ((UnityEngine.Object)ghost2).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite2 = _ghost2.setAlpha(0f);
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__9_0()
	{
		Despawn();
	}
}
