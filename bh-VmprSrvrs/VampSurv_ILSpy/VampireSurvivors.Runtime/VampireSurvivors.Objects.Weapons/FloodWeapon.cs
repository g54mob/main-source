using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class FloodWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int localIndex;

		public FloodWeapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_00c2: Expected O, but got I4
			//IL_006f->IL008b: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					if ((object)_003C_003E4__this != null)
					{
						_003C_003E4__this.DamageBelow(localIndex);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	public float VerticalOffset;

	private Blitter _blitter;

	private float _elapsed;

	private float _gravity;

	private float _wave1Alpha = 0.35f;

	private List<Bob> _wave1Group;

	private Tween _waveTween;

	private float _blitterWidth;

	private float _blitterHeight;

	private PhaserSprite _displaySprite;

	private PhaserSprite _damageSprite;

	private PhaserSprite _edgeSprite1;

	private PhaserSprite _edgeSprite2;

	private MultiTargetTween _alphaTween;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00bc: Expected I4, but got O
		//IL_01f6: Expected O, but got I
		//IL_01f6: Expected O, but got I
		//IL_0256: Expected O, but got I
		//IL_032f: Expected O, but got I
		//IL_0410: Expected O, but got I
		//IL_0410: Expected O, but got I
		//IL_0470: Expected O, but got I
		//IL_057c: Expected O, but got I
		//IL_065d: Expected O, but got I
		//IL_065d: Expected O, but got I
		//IL_06bd: Expected O, but got I
		//IL_0785: Expected O, but got I
		//IL_0866: Expected O, but got I
		//IL_0866: Expected O, but got I
		//IL_08ac: Expected O, but got I
		//IL_0926: Expected O, but got I
		//IL_0bb8: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitWeapon(characterController, weaponType);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					float blitterWidth = renderer.width + 0.02f;
					_blitterWidth = blitterWidth;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer2 = s_scene2._renderer;
							if (s_scene2._renderer != null)
							{
								WeaponType weaponType2 = (WeaponType)_blitter;
								_blitterHeight = renderer2.height;
								if ((object)_blitter != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rdi_v6 (VampireSurvivors.Data.WeaponType)+10]");
									if ((nint)0 != 0)
									{
										if ((object)_blitter != null)
										{
											GameObject gameObject = _blitter.gameObject;
											if ((object)gameObject != null)
											{
												gameObject.SetActive(value: true);
												goto IL_0bce;
											}
										}
										goto IL_09ea;
									}
								}
								MakeBlitter();
								goto IL_0bce;
							}
						}
					}
				}
			}
		}
		goto IL_09ea;
		IL_0bce:
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_ = 0;
			GameObject gameObject2 = base.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
			Vector2 pos = default(Vector2);
			PhaserSprite displaySprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, (string)num, (string)0);
			_displaySprite = displaySprite;
			_ = 0;
			_ = 0;
			_ = 1;
			if ((object)_displaySprite != null)
			{
				PhaserSprite displaySprite2 = _displaySprite;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
				PhaserSprite phaserSprite = displaySprite2.setOrigin(0.5f, (float?)(object)0);
				if ((object)_displaySprite != null)
				{
					PhaserSprite phaserSprite2 = _displaySprite.setAlpha(0.2f);
					if ((object)_displaySprite != null)
					{
						PhaserSprite phaserSprite3 = _displaySprite.setTint(15658751u);
						_ = 0;
						float num2 = _blitterHeight * 100f;
						_ = 1;
						if ((object)_displaySprite != null)
						{
							float xScale = _blitterWidth * 100f;
							PhaserSprite displaySprite3 = _displaySprite;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
							PhaserSprite phaserSprite4 = displaySprite3.setScale(xScale, (float?)(object)0);
							if ((object)_displaySprite != null)
							{
								GameObject gameObject3 = _displaySprite.gameObject;
								if ((object)gameObject3 != null)
								{
									((UnityEngine.Object)gameObject3).SetName("FLOOD SPRITE");
									SpriteTextures.SpriteTexturesBase spriteTexturesBase2 = SpriteTextures.Base;
									if (SpriteTextures.Base != null && spriteTexturesBase2.Vfx != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										_ = 0;
										GameObject gameObject4 = base.gameObject;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
										nint num3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
										PhaserSprite damageSprite = RenderingExtensions.AddPhaserSprite(gameObject4, pos, (string)num3, (string)0);
										_damageSprite = damageSprite;
										_ = 0;
										_ = 0;
										_ = 1;
										if ((object)_damageSprite != null)
										{
											PhaserSprite damageSprite2 = _damageSprite;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
											PhaserSprite phaserSprite5 = damageSprite2.setOrigin(0.5f, (float?)(object)0);
											if ((object)_damageSprite != null)
											{
												PhaserSprite phaserSprite6 = _damageSprite.setAlpha(0f);
												if ((object)_damageSprite != null)
												{
													PhaserSprite phaserSprite7 = _damageSprite.setTint(15658751u);
													if ((object)_damageSprite != null)
													{
														PhaserSprite phaserSprite8 = _damageSprite.setBlendMode(BlendMode.Add);
														_ = 0;
														float num4 = _blitterHeight * 100f;
														_ = 1;
														if ((object)_damageSprite != null)
														{
															float xScale2 = _blitterWidth * 100f;
															PhaserSprite damageSprite3 = _damageSprite;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
															PhaserSprite phaserSprite9 = damageSprite3.setScale(xScale2, (float?)(object)0);
															if ((object)_damageSprite != null)
															{
																GameObject gameObject5 = _damageSprite.gameObject;
																if ((object)gameObject5 != null)
																{
																	((UnityEngine.Object)gameObject5).SetName("FLOOD SPRITE ADD");
																	SpriteTextures.SpriteTexturesBase spriteTexturesBase3 = SpriteTextures.Base;
																	if (SpriteTextures.Base != null && spriteTexturesBase3.Vfx != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
																		if ((nint)0 == 0)
																		{
																			_ = 1;
																		}
																		_ = 0;
																		GameObject gameObject6 = base.gameObject;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
																		nint num5 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
																		PhaserSprite edgeSprite = RenderingExtensions.AddPhaserSprite(gameObject6, pos, (string)num5, (string)0);
																		_edgeSprite1 = edgeSprite;
																		_ = 0;
																		_ = 0;
																		_ = 1;
																		if ((object)_edgeSprite1 != null)
																		{
																			PhaserSprite edgeSprite2 = _edgeSprite1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
																			PhaserSprite phaserSprite10 = edgeSprite2.setOrigin(0.5f, (float?)(object)0);
																			if ((object)_edgeSprite1 != null)
																			{
																				PhaserSprite phaserSprite11 = _edgeSprite1.setAlpha(0.75f);
																				if ((object)_edgeSprite1 != null)
																				{
																					PhaserSprite phaserSprite12 = _edgeSprite1.setTint(49407u);
																					_ = 0;
																					float num6 = _blitterHeight * 100f;
																					_ = 1;
																					if ((object)_edgeSprite1 != null)
																					{
																						PhaserSprite edgeSprite3 = _edgeSprite1;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
																						PhaserSprite phaserSprite13 = edgeSprite3.setScale(1f, (float?)(object)0);
																						if ((object)_edgeSprite1 != null)
																						{
																							GameObject gameObject7 = _edgeSprite1.gameObject;
																							if ((object)gameObject7 != null)
																							{
																								((UnityEngine.Object)gameObject7).SetName("FLOOD SPRITE EDGE LEFT");
																								SpriteTextures.SpriteTexturesBase spriteTexturesBase4 = SpriteTextures.Base;
																								if (SpriteTextures.Base != null && spriteTexturesBase4.Vfx != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
																									if ((nint)0 == 0)
																									{
																										_ = 1;
																									}
																									_ = 0;
																									GameObject gameObject8 = base.gameObject;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-11]");
																									nint num7 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
																									PhaserSprite edgeSprite4 = RenderingExtensions.AddPhaserSprite(gameObject8, pos, (string)num7, (string)0);
																									_edgeSprite2 = edgeSprite4;
																									_ = 0;
																									_ = 0;
																									_ = 1;
																									PhaserSprite edgeSprite5 = _edgeSprite2;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
																									PhaserSprite phaserSprite14 = edgeSprite5.setOrigin(0.5f, (float?)(object)0);
																									PhaserSprite phaserSprite15 = _edgeSprite2.setAlpha(0.75f);
																									PhaserSprite phaserSprite16 = _edgeSprite2.setTint(49407u);
																									_ = 0;
																									float num8 = _blitterHeight * 100f;
																									_ = 1;
																									PhaserSprite edgeSprite6 = _edgeSprite2;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
																									PhaserSprite phaserSprite17 = edgeSprite6.setScale(1f, (float?)(object)0);
																									GameObject gameObject9 = _edgeSprite2.gameObject;
																									((UnityEngine.Object)gameObject9).SetName("FLOOD SPRITE EDGE RIGHT");
																									PhaserSprite phaserSprite18 = _displaySprite.setVisible(visible: true);
																									PhaserSprite phaserSprite19 = _damageSprite.setVisible(visible: true);
																									PhaserSprite phaserSprite20 = _edgeSprite1.setVisible(visible: true);
																									PhaserSprite phaserSprite21 = _edgeSprite2.setVisible(visible: true);
																									UpdateVerticalOffset();
																									Transform transform = _blitter.transform;
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ rax_v115 (UnityEngine.Transform)+10]");
																									bool flag = (nint)0 == 0;
																									object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ rax_v115 (UnityEngine.Transform)+10]");
																									Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj3);
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
		goto IL_09ea;
		IL_09ea:
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_0222: Invalid comparison between O and F4
		//IL_00d9: Invalid comparison between F4 and I4
		//IL_01d5: Invalid comparison between F4 and I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.height * 0.5f;
		if (VerticalOffset > num)
		{
			return;
		}
		DamageBelow(0);
		float num2 = base.PAmount();
		if (num > 1f)
		{
			float num3 = base.PAmount();
			if (num > 1f)
			{
				int num4 = 1;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					num = (float)num4 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if (!(num > 0f))
					{
						DamageBelow(num4);
					}
					else
					{
						_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass15_0();
						CS_0024_003C_003E8__locals7._003C_003E4__this = this;
						CS_0024_003C_003E8__locals7.localIndex = num4;
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_00c2: Expected O, but got I4
							//IL_006f->IL008b: Incompatible stack heights: 1 vs 0
							if ((object)CS_0024_003C_003E8__locals7._003C_003E4__this != null)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals7._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj2 == null)
									{
										return;
									}
									if ((object)CS_0024_003C_003E8__locals7._003C_003E4__this != null)
									{
										CS_0024_003C_003E8__locals7._003C_003E4__this.DamageBelow(CS_0024_003C_003E8__locals7.localIndex);
										return;
									}
								}
							}
							throw new NullReferenceException();
						};
						float num5 = (float)num4 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						num = num5 * 0.001f;
						Timer lastShotTimer = Timers.Register(num, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					num4++;
					float num6 = base.PAmount();
				}
				while (num > (float)num4);
			}
		}
		float num7 = base.PInterval();
		float num8 = _lastFiringInterval - num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num8 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num9 = base.PInterval();
			_lastFiringInterval = num;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private void DamageBelow(int index)
	{
		//IL_005e: Expected I, but got O
		//IL_00d0: Expected O, but got I4
		//IL_0173: Expected O, but got I4
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Expected O, but got Unknown
		//IL_02b0: Invalid comparison between F4 and I4
		//IL_02be: Invalid comparison between F4 and O
		//IL_0335: Invalid comparison between F4 and I4
		//IL_0343: Invalid comparison between O and F4
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_damageSprite != null)
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
		tweenConfig.duration = 100f;
		tweenConfig.yoyo = true;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserSprite phaserSprite = _damageSprite.setAlpha(0f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		bool flag = (nint)stage._spawnedEnemies < 0;
		object obj2 = spawnedEnemies._size - 1;
		if (flag)
		{
			return;
		}
		object obj5 = default(object);
		while (true)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
			if ((nint)obj2 >= spawnedEnemies2._size)
			{
				break;
			}
			EnemyController[] items = spawnedEnemies2._items;
			float2 position = items[obj2].position;
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			object obj3 = 1048576000 + VerticalOffset;
			object obj4 = obj5 - obj3;
			bool flag2 = (nint)obj4 < 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				float2 position3 = items[obj2].position;
				float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				float num2 = _blitterWidth * 0.5f;
				float num3 = (float)position4 - num2;
				float num4 = num3 - (float)position3;
				flag2 = num4 < 0f;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position3))
				{
					float2 position5 = items[obj2].position;
					float2 position6 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					float num5 = _blitterWidth * 0.5f;
					float num6 = num5 + (float)position6;
					float num7 = (float)position5 - num6;
					flag2 = num7 < 0f;
					if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
					{
						base.DealDamage(items[obj2]);
						core = (GameManager)(object)items[obj2];
					}
				}
			}
			obj2--;
			if (!flag2)
			{
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private bool IsInFloodZone(EnemyController enemyController)
	{
		//IL_018d: Expected I4, but got O
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_00e7: Invalid comparison between F4 and O
		//IL_015f: Invalid comparison between O and F4
		if ((object)enemyController != null)
		{
			float2 position = enemyController.position;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				object obj2 = default(object);
				object obj = obj2 + VerticalOffset;
				object obj3 = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
				{
					float2 position3 = enemyController.position;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
					{
						goto IL_017f;
					}
					float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					float num = _blitterWidth * 0.5f;
					float num2 = (float)position4 - num;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position3))
					{
						float2 position5 = enemyController.position;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
						{
							goto IL_017f;
						}
						float2 position6 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						float num3 = _blitterWidth * 0.5f;
						float num4 = num3 + (float)position6;
						if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4))
						{
							return true;
						}
					}
				}
				return false;
			}
		}
		goto IL_017f;
		IL_017f:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void MakeBlitter()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0119: Expected O, but got I
		//IL_0119: Expected O, but got I
		//IL_01e7: Expected O, but got I
		//IL_01e7: Expected O, but got I
		//IL_029d: Expected O, but got I
		//IL_029d: Expected O, but got I
		//IL_0d92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d97: Expected I4, but got Unknown
		//IL_0dd1: Expected F4, but got I
		//IL_0df7: Expected O, but got I4
		//IL_0e77: Expected O, but got I4
		//IL_0e80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e85: Expected O, but got Unknown
		//IL_0437: Expected O, but got I
		//IL_0e05: Expected O, but got F4
		//IL_0e30: Expected O, but got F4
		//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a7: Expected O, but got Unknown
		//IL_0665: Expected I4, but got O
		//IL_06d4: Expected F4, but got I
		//IL_06ef: Expected O, but got I4
		//IL_0f41: Expected O, but got I4
		//IL_0f4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4f: Expected O, but got Unknown
		//IL_0766: Expected O, but got I
		//IL_0ecc: Expected O, but got F4
		//IL_0ef7: Expected O, but got F4
		//IL_082b: Expected O, but got I
		//IL_0852: Expected O, but got I
		//IL_0879: Expected O, but got I
		//IL_08b2: Expected O, but got I
		//IL_08bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c0: Expected O, but got Unknown
		//IL_099c: Expected O, but got I
		//IL_099c: Expected O, but got I
		//IL_09b0: Expected F4, but got I
		//IL_09cb: Expected O, but got I4
		//IL_09eb: Expected O, but got I
		//IL_0fd3: Expected O, but got F4
		//IL_0ffe: Expected O, but got F4
		//IL_0ab0: Expected O, but got I
		//IL_0ad7: Expected O, but got I
		//IL_0afe: Expected O, but got I
		//IL_0b37: Expected O, but got I
		//IL_0b40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b45: Expected O, but got Unknown
		//IL_0ebe->IL0cdf: Incompatible stack heights: 1 vs 0
		//IL_03ef->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_040e->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0453->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0e22->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0e4d->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_04eb->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_05ca->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0619->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0f88->IL0cdf: Incompatible stack heights: 1 vs 0
		//IL_071e->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_073d->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0782->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0ee9->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0f17->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0810->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0faf->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0938->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_103d->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0a07->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0ff0->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_101e->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_0a95->IL0cef: Incompatible stack heights: 1 vs 0
		//IL_10d5->IL0cef: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = obj2 - 95;
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			string text = ((UnityEngine.Object)gameObject).GetName();
			string blitterName = text + " - Blitter";
			if ((object)GM.Core != null)
			{
				Vector2 pos = default(Vector2);
				Blitter blitter = GM.Core.CreateBlitter(pos, blitterName);
				_blitter = blitter;
				List<Sprite> list = new List<Sprite>();
				SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
				if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F802]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
					Sprite sprite = SpriteManager.GetSprite((string)num, (string)0);
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						SpriteTextures.SpriteTexturesBase spriteTexturesBase2 = SpriteTextures.Base;
						if (SpriteTextures.Base != null && spriteTexturesBase2.Vfx != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F803]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
							Sprite sprite2 = SpriteManager.GetSprite((string)num2, (string)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
							SpriteTextures.SpriteTexturesBase spriteTexturesBase3 = SpriteTextures.Base;
							if (SpriteTextures.Base != null && spriteTexturesBase3.Vfx != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F806]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-51]");
								Sprite sprite3 = SpriteManager.GetSprite((string)num3, (string)0);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
								if (list._size <= 0)
								{
									goto IL_0cdf;
								}
								Sprite[] items = list._items;
								if (list._items != null && (object)items[0] != null)
								{
									Texture2D texture = items[0].texture;
									if ((object)_blitter != null)
									{
										_blitter.SetAtlasTexture(texture);
										if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
										{
											Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
											if ((object)transform != null)
											{
												_ = 0;
												_ = 0;
												bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
												int num4 = obj - 89;
												Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)num4);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-55]");
												float num5 = 0f - 0.12f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
												float num6 = 0f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
												_ = 0;
												_wave1Alpha = 0.35f;
												object obj3 = 0;
												while (true)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul esi\"");
													int num7 = num4 >> 31;
													object obj4 = num4 + num7;
													object obj5 = obj4 * 2;
													object obj6 = obj4 + obj5;
													object obj7 = obj3 - obj6;
													if ((nint)obj7 >= list._size)
													{
														break;
													}
													Sprite[] items2 = list._items;
													if (list._items != null && (object)_blitter != null)
													{
														Blitter blitter2 = _blitter;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
														Bob bob = blitter2.CreateBob((Vector2)0, items2[obj7]);
														if (bob != null)
														{
															BobData bobData = bob._bobData;
															object obj8 = UnityEngine.Random.value;
															if (bob._bobData != null)
															{
																float num8 = num6 - 0.5f;
																float num9 = (bobData._003CVx_003Ek__BackingField = num8 * 0.075f);
																object obj9 = UnityEngine.Random.value;
																if (bob._bobData != null)
																{
																	float num10 = num9 - 0.5f;
																	float num11 = num10 * 0.05f;
																	BobData bobData2 = bob._bobData;
																	if (bob._bobData != null)
																	{
																		bobData2._003CBounce_003Ek__BackingField = 1f;
																		BobVertexData[] vertexData = bob.vertexData;
																		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
																		_ = bob._bobData;
																		BobVertexData[] vertexData2 = bob.vertexData;
																		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
																		_ = bob._bobData;
																		BobVertexData[] vertexData3 = bob.vertexData;
																		num6 = _wave1Alpha * 255f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
																		_ = bob._bobData;
																		BobVertexData[] vertexData4 = bob.vertexData;
																		float num12 = _wave1Alpha * 255f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
																		_ = bob._bobData;
																		List<object> wave1Group = (List<object>)(object)_wave1Group;
																		if (_wave1Group != null)
																		{
																			int version = wave1Group._version + 1;
																			wave1Group._version = version;
																			object[] items3 = wave1Group._items;
																			if (wave1Group._items != null)
																			{
																				num4 = wave1Group._size;
																				if (wave1Group._size >= items3.Length)
																				{
																					((List<object>)(object)_wave1Group).AddWithResize((object)bob);
																					num4 = (int)bob;
																				}
																				else
																				{
																					int size = wave1Group._size + 1;
																					wave1Group._size = size;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				}
																				obj3++;
																				if ((nint)obj3 < 400)
																				{
																					continue;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
																				float num13 = 0f;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
																				_ = 0;
																				object obj10 = 0;
																				while (true)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul esi\"");
																					int num14 = num4 >> 31;
																					object obj11 = num4 + num14;
																					object obj12 = obj11 * 2;
																					object obj13 = obj11 + obj12;
																					object obj14 = obj10 - obj13;
																					if ((nint)obj14 >= list._size)
																					{
																						break;
																					}
																					Sprite[] items4 = list._items;
																					if (list._items != null && (object)_blitter != null)
																					{
																						Blitter blitter3 = _blitter;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
																						Bob bob2 = blitter3.CreateBob((Vector2)0, items4[obj14]);
																						if (bob2 != null)
																						{
																							BobData bobData3 = bob2._bobData;
																							object obj15 = UnityEngine.Random.value;
																							if (bob2._bobData != null)
																							{
																								float num15 = num13 - 0.5f;
																								float num16 = (bobData3._003CVx_003Ek__BackingField = num15 * 0.075f);
																								object obj16 = UnityEngine.Random.value;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v106 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																								if ((nint)0 != 0)
																								{
																									float num17 = num16 - 0.5f;
																									float num18 = num17 * 0.05f;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v106 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																									if ((nint)0 != 0)
																									{
																										_ = 1065353216;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v106 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																										object obj17 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v106 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																										_ = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v106 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																										object obj18 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v106 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																										_ = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v106 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																										object obj19 = 0;
																										num12 = _wave1Alpha * 255f;
																										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v106 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																										_ = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v106 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																										object obj20 = 0;
																										obj10++;
																										num13 = _wave1Alpha * 255f;
																										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v106 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																										_ = 0;
																										bool flag2 = (nint)obj10 < 400;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
																										num4 = 0;
																										if (flag2)
																										{
																											continue;
																										}
																										SpriteTextures.SpriteTexturesBase spriteTexturesBase4 = SpriteTextures.Base;
																										if (SpriteTextures.Base != null && spriteTexturesBase4.Vfx != null)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F609]");
																											if ((nint)0 == 0)
																											{
																												_ = 1;
																											}
																											_ = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
																											nint num19 = 0;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-41]");
																											Sprite sprite4 = SpriteManager.GetSprite((string)num19, (string)0);
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
																											float num20 = 0f;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
																											_ = 0;
																											object obj21 = 0;
																											while ((object)_blitter != null)
																											{
																												Blitter blitter4 = _blitter;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
																												Bob bob3 = blitter4.CreateBob((Vector2)0, sprite4);
																												if (bob3 == null)
																												{
																													break;
																												}
																												BobData bobData4 = bob3._bobData;
																												object obj22 = UnityEngine.Random.value;
																												if (bob3._bobData == null)
																												{
																													break;
																												}
																												float num21 = num20 - 0.5f;
																												float num22 = (bobData4._003CVx_003Ek__BackingField = num21 * 0.075f);
																												object obj23 = UnityEngine.Random.value;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v127 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																												if ((nint)0 == 0)
																												{
																													break;
																												}
																												float num23 = num22 - 0.5f;
																												float num24 = num23 * 0.05f;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v127 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																												if ((nint)0 == 0)
																												{
																													break;
																												}
																												_ = 1065353216;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v127 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																												object obj24 = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v127 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																												_ = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v127 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																												object obj25 = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v127 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																												_ = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v127 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																												object obj26 = 0;
																												num12 = _wave1Alpha * 255f;
																												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v127 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																												_ = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v127 (VampireSurvivors.Graphics.Blitters.Bob)+28]");
																												object obj27 = 0;
																												obj21++;
																												num20 = _wave1Alpha * 255f;
																												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v127 (VampireSurvivors.Graphics.Blitters.Bob)+30]");
																												_ = 0;
																												if ((nint)obj21 < 400)
																												{
																													continue;
																												}
																												DOGetter<float> getter = null;
																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
																												DOSetter<float> dOSetter = null;
																												((FloodWeapon)(object)dOSetter)._003CMakeBlitter_003Eb__18_1(num12);
																												TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.1f, 2f);
																												if (tweenerCore != null)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2609 @ rax_v140 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																													if ((nint)0 != 0)
																													{
																														_ = 4;
																														_ = 0;
																													}
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2609 @ rax_v140 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																													if ((nint)0 != 0)
																													{
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2609 @ rax_v140 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
																														if ((nint)0 == 0)
																														{
																															_ = 4294967295L;
																															_ = 1;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2609 @ rax_v140 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
																															if ((nint)0 == 0)
																															{
																																_ = 2139095040;
																															}
																														}
																													}
																												}
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																												if ((nint)0 == 0)
																												{
																													_ = 1;
																												}
																												if (tweenerCore == null)
																												{
																													break;
																												}
																												_waveTween = tweenerCore;
																												return;
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																					goto IL_0cef;
																				}
																				break;
																			}
																		}
																	}
																}
															}
														}
													}
													goto IL_0cef;
												}
												goto IL_0cdf;
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
		goto IL_0cef;
		IL_0cdf:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0cef;
		IL_0cef:
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		//IL_0102->IL00b0: Incompatible stack heights: 1 vs 0
		//IL_0096->IL00b0: Incompatible stack heights: 1 vs 0
		UpdateBlitter();
		Blitter blitter = _blitter;
		if ((object)_blitter != null)
		{
			Blitter meshRenderer = (Blitter)(object)blitter._meshRenderer;
			if ((object)blitter._meshRenderer != null)
			{
				bool flag = ((UnityEngine.Object)meshRenderer).m_CachedPtr == (IntPtr)0;
				Renderer.set_sortingOrder_Injected(((UnityEngine.Object)meshRenderer).m_CachedPtr, 3000);
				if ((object)_displaySprite != null)
				{
					PhaserSprite phaserSprite = _displaySprite.setDepth(2999);
					if ((object)_damageSprite != null)
					{
						PhaserSprite phaserSprite2 = _damageSprite.setDepth(2998);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void UpdateVerticalOffset()
	{
		//IL_0149->IL00f8: Incompatible stack heights: 1 vs 0
		//IL_007c->IL00f8: Incompatible stack heights: 1 vs 0
		//IL_0198->IL00f8: Incompatible stack heights: 2 vs 0
		//IL_00b3->IL00f8: Incompatible stack heights: 2 vs 0
		//IL_01e7->IL00f8: Incompatible stack heights: 3 vs 0
		//IL_00e9->IL00f8: Incompatible stack heights: 3 vs 0
		if ((object)_displaySprite != null)
		{
			Transform transform = _displaySprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				if ((object)_damageSprite != null)
				{
					Transform transform2 = _damageSprite.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Vector3 value2 = default(Vector3);
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
						if ((object)_edgeSprite1 != null)
						{
							Transform transform3 = _edgeSprite1.transform;
							if ((object)transform3 != null)
							{
								bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Vector3 value3 = default(Vector3);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value3);
								if ((object)_edgeSprite2 != null)
								{
									Transform transform4 = _edgeSprite2.transform;
									if ((object)transform4 != null)
									{
										bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										Vector3 value4 = default(Vector3);
										Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value4);
										return;
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

	private void UpdateBlitter()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0062: Expected O, but got I4
		//IL_0270: Expected O, but got I4
		//IL_0279: Expected O, but got I4
		float num = _blitterWidth * 0.5f;
		float num2 = _blitterHeight * 0.5f;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		object obj2 = default(object);
		object obj = obj2 + VerticalOffset;
		List<Bob>.Enumerator enumerator = default(List<Bob>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj3 = 0;
			throw new NullReferenceException();
		}
		List<Bob>.Enumerator enumerator2 = default(List<Bob>.Enumerator);
		if (enumerator2.MoveNext())
		{
			object obj4 = 0;
			object obj5 = 0;
			throw new NullReferenceException();
		}
	}

	public override void Cleanup()
	{
		base.Cleanup();
		GameObject gameObject = _blitter.gameObject;
		gameObject.SetActive(value: false);
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _damageSprite.setVisible(visible: false);
	}

	public FloodWeapon()
	{
		List<Bob> wave1Group = new List<Bob>();
		_wave1Group = wave1Group;
		base._002Ector();
	}

	private void _003CDamageBelow_003Eb__16_0()
	{
		PhaserSprite phaserSprite = _damageSprite.setAlpha(0f);
	}

	private float _003CMakeBlitter_003Eb__18_0()
	{
		return _wave1Alpha;
	}

	private void _003CMakeBlitter_003Eb__18_1(float val)
	{
		_wave1Alpha = val;
	}
}
