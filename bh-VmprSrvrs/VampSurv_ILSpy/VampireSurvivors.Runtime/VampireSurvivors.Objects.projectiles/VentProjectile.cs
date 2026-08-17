using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using Zenject;

namespace VampireSurvivors.Objects.Projectiles;

public class VentProjectile : Projectile
{
	private class VentUsageSlot
	{
		public SpriteRenderer _dummySprite;

		public MultiTargetTween _currentTween;
	}

	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public VentUsageSlot usageSlot;

		public IDamageable other;

		public VentProjectile _003C_003E4__this;

		public float dropRange;

		internal unsafe void _003COnHasHitAnObject_003Eb__0(Pickup pickup)
		{
			//IL_01d9: Expected I, but got O
			//IL_02a9: Expected I, but got O
			//IL_02b1: Expected I, but got O
			//IL_02c1: Expected O, but got I
			//IL_0341: Expected O, but got I4
			//IL_0b40: Expected I, but got O
			//IL_02fd: Expected O, but got I
			//IL_0354: Expected I, but got O
			//IL_0333: Expected O, but got I4
			//IL_0249: Expected I, but got O
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Expected O, but got Unknown
			//IL_06ac: Expected I, but got O
			//IL_06b4: Expected I, but got O
			//IL_06c4: Expected O, but got I
			//IL_0744: Expected O, but got I4
			//IL_0bcc: Expected I, but got O
			//IL_0700: Expected O, but got I
			//IL_075f: Expected I, but got O
			//IL_0736: Expected O, but got I4
			//IL_083f: Expected I, but got O
			//IL_091a: Expected I, but got O
			//IL_059a: Expected I, but got O
			//IL_0624: Expected I, but got O
			//IL_0c75: Expected O, but got I4
			//IL_0cee: Expected O, but got I4
			//IL_0c8f->IL0a7a: Incompatible stack heights: 1 vs 0
			//IL_0a27->IL0a7a: Incompatible stack heights: 1 vs 0
			//IL_0a62->IL0a7a: Incompatible stack heights: 2 vs 0
			_003C_003Ec__DisplayClass22_1 CS_0024_003C_003E8__locals76 = new _003C_003Ec__DisplayClass22_1();
			if (CS_0024_003C_003E8__locals76 != null)
			{
				CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 = this;
				CS_0024_003C_003E8__locals76.pickup = pickup;
				Pickup pickup2 = CS_0024_003C_003E8__locals76.pickup;
				if ((object)CS_0024_003C_003E8__locals76.pickup == null || ((UnityEngine.Object)pickup2).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0136;
				}
				if ((object)CS_0024_003C_003E8__locals76.pickup != null)
				{
					ArcadeSprite arcadeSprite = CS_0024_003C_003E8__locals76.pickup.setVisible(visible: false);
					Pickup pickup3 = CS_0024_003C_003E8__locals76.pickup;
					if ((object)CS_0024_003C_003E8__locals76.pickup != null)
					{
						BaseBody body = pickup3.body;
						if (pickup3.body != null)
						{
							body._enable = false;
							if ((object)CS_0024_003C_003E8__locals76.pickup != null)
							{
								CS_0024_003C_003E8__locals76.pickup.enabled = false;
								goto IL_0136;
							}
						}
					}
				}
			}
			goto IL_0a7a;
			IL_086d:
			object[] array = new object[1];
			VentUsageSlot ventUsageSlot = usageSlot;
			if (usageSlot != null && (object)ventUsageSlot._dummySprite != null)
			{
				Transform transform = ventUsageSlot._dummySprite.transform;
				if (array != null)
				{
					if ((object)transform != null)
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
					CS_0024_003C_003E8__locals76.tweenTargets = array;
					goto IL_095e;
				}
			}
			goto IL_0a7a;
			IL_095e:
			VentUsageSlot ventUsageSlot2 = usageSlot;
			TweenConfig tweenConfig = new TweenConfig();
			if (tweenConfig != null)
			{
				tweenConfig.targets = CS_0024_003C_003E8__locals76.tweenTargets;
				if ((object)_003C_003E4__this != null)
				{
					Transform transform2 = _003C_003E4__this.transform;
					if ((object)transform2 != null)
					{
						bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
						tweenConfig.x = (float?)(object)1;
						if ((object)_003C_003E4__this != null)
						{
							Transform transform3 = _003C_003E4__this.transform;
							if ((object)transform3 != null)
							{
								bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
								tweenConfig.duration = 400f;
								tweenConfig.ease = Ease.InOutCubic;
								tweenConfig.y = (float?)(object)1;
								TweenCallback onComplete = delegate
								{
									//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
									//IL_06a6: Expected O, but got Unknown
									//IL_06d2: Expected F4, but got I
									//IL_04a9: Expected I, but got O
									//IL_076c: Unknown result type (might be due to invalid IL or missing references)
									//IL_0771: Expected O, but got Unknown
									//IL_0945: Unknown result type (might be due to invalid IL or missing references)
									//IL_094a: Expected O, but got Unknown
									//IL_0547: Unknown result type (might be due to invalid IL or missing references)
									//IL_054c: Expected O, but got Unknown
									//IL_07df: Unknown result type (might be due to invalid IL or missing references)
									//IL_07e4: Expected O, but got Unknown
									//IL_0870: Unknown result type (might be due to invalid IL or missing references)
									//IL_0875: Expected O, but got Unknown
									//IL_089a: Invalid comparison between F4 and I
									//IL_08e5: Unknown result type (might be due to invalid IL or missing references)
									//IL_08ea: Expected O, but got Unknown
									//IL_090c: Expected F4, but got I
									//IL_06ec->IL063e: Incompatible stack heights: 1 vs 0
									//IL_00b9->IL063e: Incompatible stack heights: 1 vs 0
									//IL_00db->IL063e: Incompatible stack heights: 1 vs 0
									//IL_0737->IL063e: Incompatible stack heights: 1 vs 0
									//IL_03f5->IL063e: Incompatible stack heights: 1 vs 0
									//IL_0417->IL063e: Incompatible stack heights: 1 vs 0
									//IL_014c->IL063e: Incompatible stack heights: 1 vs 0
									//IL_045c->IL063e: Incompatible stack heights: 1 vs 0
									//IL_017b->IL063e: Incompatible stack heights: 1 vs 0
									//IL_019d->IL063e: Incompatible stack heights: 1 vs 0
									//IL_0495->IL063e: Incompatible stack heights: 1 vs 0
									//IL_01cc->IL063e: Incompatible stack heights: 1 vs 0
									//IL_04d2->IL063e: Incompatible stack heights: 1 vs 0
									//IL_04f4->IL063e: Incompatible stack heights: 1 vs 0
									//IL_07aa->IL0713: Incompatible stack heights: 2 vs 1
									//IL_0523->IL063e: Incompatible stack heights: 1 vs 0
									//IL_01ff->IL063e: Incompatible stack heights: 2 vs 0
									//IL_022e->IL063e: Incompatible stack heights: 2 vs 0
									//IL_0980->IL063e: Incompatible stack heights: 2 vs 0
									//IL_0250->IL063e: Incompatible stack heights: 2 vs 0
									//IL_027f->IL063e: Incompatible stack heights: 2 vs 0
									//IL_0626->IL063e: Incompatible stack heights: 2 vs 0
									//IL_0835->IL063e: Incompatible stack heights: 3 vs 0
									//IL_02b8->IL063e: Incompatible stack heights: 3 vs 0
									//IL_02da->IL063e: Incompatible stack heights: 3 vs 0
									//IL_0309->IL063e: Incompatible stack heights: 3 vs 0
									//IL_08ad->IL0713: Incompatible stack heights: 4 vs 1
									//IL_033c->IL063e: Incompatible stack heights: 4 vs 0
									//IL_036b->IL063e: Incompatible stack heights: 4 vs 0
									//IL_038d->IL063e: Incompatible stack heights: 4 vs 0
									//IL_03bc->IL063e: Incompatible stack heights: 4 vs 0
									//IL_0912->IL0713: Incompatible stack heights: 5 vs 1
									_003C_003Ec__DisplayClass22_0 obj12 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
									object obj14 = default(object);
									if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
									{
										VentUsageSlot ventUsageSlot5 = obj12.usageSlot;
										if (obj12.usageSlot != null && (object)ventUsageSlot5._dummySprite != null)
										{
											Transform transform6 = ventUsageSlot5._dummySprite.transform;
											if ((object)transform6 != null)
											{
												_ = 0;
												_ = 0;
												bool flag6 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
												object obj13 = obj14 - 72;
												Transform.get_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out *(Vector3*)obj13);
												_003C_003Ec__DisplayClass22_0 obj15 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
												float num11 = 0f;
												if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
												{
													VentUsageSlot ventUsageSlot6 = obj15.usageSlot;
													if (obj15.usageSlot != null && (object)ventUsageSlot6._dummySprite != null)
													{
														Sprite sprite = ventUsageSlot6._dummySprite.sprite;
														if ((object)sprite == null || ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0)
														{
															goto IL_0713;
														}
														_003C_003Ec__DisplayClass22_0 obj16 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
														if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
														{
															VentUsageSlot ventUsageSlot7 = obj16.usageSlot;
															if (obj16.usageSlot != null && (object)ventUsageSlot7._dummySprite != null)
															{
																Sprite sprite2 = ventUsageSlot7._dummySprite.sprite;
																if ((object)sprite2 != null)
																{
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v93 (UnityEngine.Sprite)+10]");
																	bool flag7 = (nint)0 == 0;
																	object obj17 = obj14 - 72;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v93 (UnityEngine.Sprite)+10]");
																	Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj17);
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
																	if ((nint)0 <= (nint)0)
																	{
																		goto IL_0713;
																	}
																	_003C_003Ec__DisplayClass22_0 obj18 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
																	if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
																	{
																		VentUsageSlot ventUsageSlot8 = obj18.usageSlot;
																		if (obj18.usageSlot != null && (object)ventUsageSlot8._dummySprite != null)
																		{
																			Sprite sprite3 = ventUsageSlot8._dummySprite.sprite;
																			if ((object)sprite3 != null)
																			{
																				_ = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v99 (UnityEngine.Sprite)+10]");
																				bool flag8 = (nint)0 == 0;
																				object obj19 = obj14 - 72;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v99 (UnityEngine.Sprite)+10]");
																				Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj19);
																				_003C_003Ec__DisplayClass22_0 obj20 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
																				float num12 = 32f;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
																				num11 = num12 / 0f;
																				if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
																				{
																					VentUsageSlot ventUsageSlot9 = obj20.usageSlot;
																					if (obj20.usageSlot != null && (object)ventUsageSlot9._dummySprite != null)
																					{
																						Transform transform7 = ventUsageSlot9._dummySprite.transform;
																						if ((object)transform7 != null)
																						{
																							_ = 0;
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v106 (UnityEngine.Transform)+10]");
																							bool flag9 = (nint)0 == 0;
																							object obj21 = obj14 - 72;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v106 (UnityEngine.Transform)+10]");
																							Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj21);
																							float num13 = num11;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																							if (!(num13 > 0f))
																							{
																								goto IL_0713;
																							}
																							_003C_003Ec__DisplayClass22_0 obj22 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
																							if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
																							{
																								VentUsageSlot ventUsageSlot10 = obj22.usageSlot;
																								if (obj22.usageSlot != null && (object)ventUsageSlot10._dummySprite != null)
																								{
																									Transform transform8 = ventUsageSlot10._dummySprite.transform;
																									if ((object)transform8 != null)
																									{
																										_ = 0;
																										_ = 0;
																										bool flag10 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
																										object obj23 = obj14 - 72;
																										Transform.get_localScale_Injected(((UnityEngine.Object)transform8).m_CachedPtr, out *(Vector3*)obj23);
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																										num11 = 0f;
																										goto IL_0713;
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
									goto IL_063e;
									IL_063e:
									throw new NullReferenceException();
									IL_0713:
									_003C_003Ec__DisplayClass22_0 obj24 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
									{
										VentUsageSlot ventUsageSlot11 = obj24.usageSlot;
										if (obj24.usageSlot != null && (object)obj24._003C_003E4__this != null)
										{
											obj24._003C_003E4__this.UpdateClipping(ventUsageSlot11._dummySprite);
											_003C_003Ec__DisplayClass22_0 obj25 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
											{
												VentUsageSlot ventUsageSlot12 = obj25.usageSlot;
												TweenConfig tweenConfig2 = new TweenConfig();
												if (tweenConfig2 != null)
												{
													((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)CS_0024_003C_003E8__locals76.tweenTargets;
													_003C_003Ec__DisplayClass22_0 obj26 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
													if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null && (object)obj26._003C_003E4__this != null)
													{
														Transform transform9 = obj26._003C_003E4__this.transform;
														if ((object)transform9 != null)
														{
															_ = 0;
															_ = 0;
															bool flag11 = ((UnityEngine.Object)transform9).m_CachedPtr == (IntPtr)0;
															object obj27 = obj14 - 72;
															Transform.get_position_Injected(((UnityEngine.Object)transform9).m_CachedPtr, out *(Vector3*)obj27);
															_003C_003Ec__DisplayClass22_0 obj28 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
															if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-44]");
																object obj29 = 0 - obj28.dropRange;
																_ = 0;
																_ = 1;
																_ = 1137180672;
																_ = 10;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+18]");
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+18]");
																_ = 0;
																TweenCallback tweenCallback = CS_0024_003C_003E8__locals76._003C_003E9__2;
																if (CS_0024_003C_003E8__locals76._003C_003E9__2 == null)
																{
																	tweenCallback = (CS_0024_003C_003E8__locals76._003C_003E9__2 = delegate
																	{
																		//IL_04ae: Expected O, but got I4
																		//IL_04b7: Expected O, but got I4
																		//IL_04e7: Expected I, but got O
																		//IL_0522: Expected I, but got O
																		//IL_0532: Expected O, but got I
																		//IL_056a: Expected O, but got I
																		//IL_05a3: Expected O, but got I
																		//IL_05db: Expected O, but got I
																		//IL_08ac: Unknown result type (might be due to invalid IL or missing references)
																		//IL_08b1: Expected O, but got Unknown
																		//IL_00cc->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_06b0->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_00fb->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_06d2->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_0180->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_07cc->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_01a7->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_01c5->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_07f3->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_01f9->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_0217->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_081a->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_024b->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_0292->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_0841->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_02c6->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_02e4->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_0868->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_0318->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_036a->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_038c->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_03c7->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_03e9->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_0424->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_0446->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_0477->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_04a0->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_0632->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_0661->IL06f3: Incompatible stack heights: 1 vs 0
																		//IL_08be->IL08d8: Incompatible stack heights: 8 vs 1
																		_003C_003Ec__DisplayClass22_0 obj30 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
																		VentProjectile ventProjectile;
																		VentUsageSlot slot;
																		object[] tweenTargets;
																		ArcadeSprite phaserObject;
																		if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
																		{
																			VentUsageSlot ventUsageSlot13 = obj30.usageSlot;
																			if (obj30.usageSlot != null && (object)ventUsageSlot13._dummySprite != null)
																			{
																				Transform transform10 = ventUsageSlot13._dummySprite.transform;
																				bool flag12 = ((UnityEngine.Object)transform10).m_CachedPtr == (IntPtr)0;
																				Vector3 value = default(Vector3);
																				Transform.set_localScale_Injected(((UnityEngine.Object)transform10).m_CachedPtr, ref value);
																				Transform pickup7 = (Transform)(object)CS_0024_003C_003E8__locals76.pickup;
																				if ((object)CS_0024_003C_003E8__locals76.pickup != null && ((UnityEngine.Object)pickup7).m_CachedPtr != (IntPtr)0)
																				{
																					_003C_003Ec__DisplayClass22_0 obj31 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
																					if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
																					{
																						ventProjectile = obj31._003C_003E4__this;
																						if ((object)obj31._003C_003E4__this != null)
																						{
																							slot = obj31.usageSlot;
																							tweenTargets = CS_0024_003C_003E8__locals76.tweenTargets;
																							phaserObject = CS_0024_003C_003E8__locals76.pickup;
																							goto IL_08be;
																						}
																					}
																				}
																				else
																				{
																					Transform character5 = (Transform)(object)CS_0024_003C_003E8__locals76.character;
																					if ((object)CS_0024_003C_003E8__locals76.character != null && ((UnityEngine.Object)character5).m_CachedPtr != (IntPtr)0)
																					{
																						if ((object)GM.Core != null)
																						{
																							PhaserScene s_scene = ArcadePhysics.s_scene;
																							if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
																							{
																								PhaserScene s_scene2 = ArcadePhysics.s_scene;
																								if (ArcadePhysics.s_scene != null)
																								{
																									PhaserScene.Renderer renderer = s_scene2._renderer;
																									if (s_scene2._renderer != null && (object)GM.Core != null)
																									{
																										PhaserScene s_scene3 = ArcadePhysics.s_scene;
																										if (ArcadePhysics.s_scene != null)
																										{
																											PhaserScene.Renderer renderer2 = s_scene3._renderer;
																											if (s_scene3._renderer != null)
																											{
																												float minInclusive = renderer.width ^ -0f;
																												float num14 = UnityEngine.Random.Range(minInclusive, renderer2.width);
																												if ((object)GM.Core != null)
																												{
																													PhaserScene s_scene4 = ArcadePhysics.s_scene;
																													if (ArcadePhysics.s_scene != null)
																													{
																														PhaserScene.Renderer renderer3 = s_scene4._renderer;
																														if (s_scene4._renderer != null && (object)GM.Core != null)
																														{
																															PhaserScene s_scene5 = ArcadePhysics.s_scene;
																															if (ArcadePhysics.s_scene != null)
																															{
																																PhaserScene.Renderer renderer4 = s_scene5._renderer;
																																if (s_scene5._renderer != null)
																																{
																																	float minInclusive2 = renderer3.height ^ -0f;
																																	float num15 = UnityEngine.Random.Range(minInclusive2, renderer4.height);
																																	_003C_003Ec__DisplayClass22_0 obj32 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
																																	if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null && (object)obj32._003C_003E4__this != null)
																																	{
																																		float2 position = default(float2);
																																		obj32._003C_003E4__this.position = position;
																																		_003C_003Ec__DisplayClass22_0 obj33 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
																																		if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null && (object)obj33._003C_003E4__this != null)
																																		{
																																			float2 position2 = obj33._003C_003E4__this.position;
																																			_003C_003Ec__DisplayClass22_0 obj34 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
																																			if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null && (object)obj34._003C_003E4__this != null)
																																			{
																																				float2 position3 = obj34._003C_003E4__this.position;
																																				if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
																																				{
																																					object[] tweenTargets2 = CS_0024_003C_003E8__locals76.tweenTargets;
																																					if (CS_0024_003C_003E8__locals76.tweenTargets != null)
																																					{
																																						object obj35 = 0;
																																						object obj36 = 0;
																																						float2 value2 = default(float2);
																																						while ((nint)obj36 < tweenTargets2.Length)
																																						{
																																							bool flag13 = (nint)obj35 >= tweenTargets2.Length;
																																							nint num16 = (nint)typeof(Transform);
																																							object obj37 = tweenTargets2[obj35];
																																							bool flag14 = tweenTargets2[obj35] == null;
																																							nint num17 = (nint)obj37;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																							object obj38 = 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+130]");
																																							nint num18 = 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																							bool flag15 = num18 < 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+C8]");
																																							object obj39 = 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ rax_v78+FFFFFFF8+v1157 @ rax_v77*8]");
																																							bool flag16 = 0 != (nint)typeof(Transform);
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																							object obj40 = 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+130]");
																																							nint num19 = 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																							bool flag17 = num19 < 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+C8]");
																																							object obj41 = 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1065 @ rax_v80+FFFFFFF8+v1064 @ rax_v79*8]");
																																							bool flag18 = 0 != (nint)typeof(Transform);
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rbx_v16 (System.Object)+10]");
																																							bool flag19 = (nint)0 == 0;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rbx_v16 (System.Object)+10]");
																																							Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value2));
																																							obj35++;
																																							obj36 = obj35;
																																						}
																																						_003C_003Ec__DisplayClass22_0 obj42 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
																																						if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null)
																																						{
																																							ventProjectile = obj42._003C_003E4__this;
																																							if ((object)obj42._003C_003E4__this != null)
																																							{
																																								slot = obj42.usageSlot;
																																								tweenTargets = CS_0024_003C_003E8__locals76.tweenTargets;
																																								phaserObject = CS_0024_003C_003E8__locals76.character;
																																								goto IL_08be;
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
																					else
																					{
																						_003C_003Ec__DisplayClass22_0 obj43 = CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1;
																						if (CS_0024_003C_003E8__locals76.CS_0024_003C_003E8__locals1 != null && (object)obj43._003C_003E4__this != null)
																						{
																							obj43._003C_003E4__this.UseFinished(obj43.usageSlot);
																							return;
																						}
																					}
																				}
																			}
																		}
																		throw new NullReferenceException();
																		IL_08be:
																		ventProjectile.ReturnFromVent(phaserObject, tweenTargets, slot);
																	});
																}
																MultiTargetTween currentTween2 = Tweens.Add(tweenConfig2);
																if (obj25.usageSlot != null)
																{
																	ventUsageSlot12._currentTween = currentTween2;
																	return;
																}
															}
														}
													}
												}
											}
										}
									}
									goto IL_063e;
								};
								tweenConfig.onComplete = onComplete;
								MultiTargetTween currentTween = Tweens.Add(tweenConfig);
								if (usageSlot != null)
								{
									ventUsageSlot2._currentTween = currentTween;
									return;
								}
							}
						}
					}
				}
			}
			goto IL_0a7a;
			IL_0a7a:
			throw new NullReferenceException();
			IL_0b23:
			object obj2;
			bool flag3 = obj2 == null;
			nint num2 = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
			VampireSurvivors.Objects.Characters.CharacterController character = null;
			if (!flag3)
			{
				num2 = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
				character = (VampireSurvivors.Objects.Characters.CharacterController)other;
			}
			goto IL_0b11;
			IL_0be4:
			Pickup pickup4;
			if ((object)pickup4 != null && ((UnityEngine.Object)pickup4).m_CachedPtr != (IntPtr)0)
			{
				string textureName = pickup4._textureName;
				_ = 1;
				if (pickup4._textureName != null && textureName._stringLength != 0)
				{
					if (pickup4._textureName == null)
					{
						goto IL_0a7a;
					}
					if (!((CoherenceSync)(object)pickup4._textureName).HasStateAuthority)
					{
						goto IL_086d;
					}
				}
			}
			num2 = (nint)other;
			if (other != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				goto IL_086d;
			}
			goto IL_0a7a;
			IL_0b11:
			CS_0024_003C_003E8__locals76.character = character;
			Pickup character2 = (Pickup)(object)CS_0024_003C_003E8__locals76.character;
			if ((object)CS_0024_003C_003E8__locals76.character != null && ((UnityEngine.Object)character2).m_CachedPtr != (IntPtr)0)
			{
				if ((object)CS_0024_003C_003E8__locals76.character != null)
				{
					ArcadeSprite arcadeSprite2 = CS_0024_003C_003E8__locals76.character.setVisible(visible: false);
					VampireSurvivors.Objects.Characters.CharacterController character3 = CS_0024_003C_003E8__locals76.character;
					if ((object)CS_0024_003C_003E8__locals76.character != null && (object)character3._spriteTrail != null)
					{
						SpriteTrail spriteTrail = character3._spriteTrail.setVisible(b: false);
						VampireSurvivors.Objects.Characters.CharacterController character4 = CS_0024_003C_003E8__locals76.character;
						if ((object)CS_0024_003C_003E8__locals76.character != null)
						{
							BaseBody body2 = character4.body;
							if (character4.body != null)
							{
								body2._enable = false;
								if ((object)CS_0024_003C_003E8__locals76.character != null)
								{
									CS_0024_003C_003E8__locals76.character.enabled = false;
									object[] array2 = new object[2];
									VentUsageSlot ventUsageSlot3 = usageSlot;
									if (usageSlot != null && (object)ventUsageSlot3._dummySprite != null)
									{
										Transform transform4 = ventUsageSlot3._dummySprite.transform;
										if (array2 != null)
										{
											if ((object)transform4 != null)
											{
												nint num3 = (nint)array2;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj3 = default(object);
												if (obj3 == null)
												{
													ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
													throw ex2;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if ((object)CS_0024_003C_003E8__locals76.character != null)
											{
												Transform transform5 = CS_0024_003C_003E8__locals76.character.transform;
												if ((object)transform5 != null)
												{
													nint num4 = (nint)array2;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj4 = default(object);
													if (obj4 == null)
													{
														ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
														throw ex3;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												CS_0024_003C_003E8__locals76.tweenTargets = array2;
												goto IL_095e;
											}
										}
									}
								}
							}
						}
					}
				}
				goto IL_0a7a;
			}
			Pickup pickup5 = (Pickup)other;
			if (other == null)
			{
				pickup4 = null;
				goto IL_0be4;
			}
			nint num5 = (nint)typeof(EnemyController);
			nint num6 = (nint)pickup5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1490 @ r8_v42 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1491 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1490 @ r8_v42 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
			object obj7;
			if (num7 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1491 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1546 @ rax_v122+FFFFFFF8+v1492 @ rax_v118*8]");
				if (0 == (nint)typeof(EnemyController))
				{
					obj7 = 1;
					goto IL_0ba7;
				}
			}
			obj7 = 0;
			goto IL_0ba7;
			IL_0ae5:
			IDamageable damageable = other;
			if (other == null)
			{
				character = null;
				goto IL_0b11;
			}
			nint num8 = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
			nint num9 = (nint)damageable;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1037 @ r8_v56 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r9_v10 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+130]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1037 @ r8_v56 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
			if (num10 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r9_v10 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+C8]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1135 @ rax_v157+FFFFFFF8+v1039 @ rax_v152*8]");
				if (0 == (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController))
				{
					obj2 = 1;
					goto IL_0b23;
				}
			}
			obj2 = 0;
			goto IL_0b23;
			IL_0136:
			VentUsageSlot ventUsageSlot4 = usageSlot;
			if (usageSlot != null && (object)ventUsageSlot4._dummySprite != null)
			{
				ventUsageSlot4._dummySprite.enabled = true;
				if (other != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496460");
					object obj10 = default(object);
					bool flag4 = (nint)obj10 <= 0;
					num2 = (nint)other;
					if (flag4)
					{
						goto IL_0ae5;
					}
					Pickup pickup6 = (Pickup)(object)_003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Pickup playerOptions = (Pickup)(object)pickup6._playerOptions;
						if (pickup6._playerOptions != null)
						{
							num2 = (nint)other;
							if (other != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496460");
								object obj11 = obj10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rbx_v25 (VampireSurvivors.Objects.Pickups.Pickup)+134]");
								obj10 = obj11 + 0;
								goto IL_0ae5;
							}
						}
					}
				}
			}
			goto IL_0a7a;
			IL_0ba7:
			bool flag5 = obj7 == null;
			num9 = num6;
			num2 = (nint)typeof(EnemyController);
			pickup4 = null;
			if (!flag5)
			{
				num9 = num6;
				num2 = (nint)typeof(EnemyController);
				pickup4 = (Pickup)other;
			}
			goto IL_0be4;
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_1
	{
		public object[] tweenTargets;

		public Pickup pickup;

		public VampireSurvivors.Objects.Characters.CharacterController character;

		public _003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals1;

		public TweenCallback _003C_003E9__2;

		internal unsafe void _003COnHasHitAnObject_003Eb__1()
		{
			//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a6: Expected O, but got Unknown
			//IL_06d2: Expected F4, but got I
			//IL_04a9: Expected I, but got O
			//IL_076c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0771: Expected O, but got Unknown
			//IL_0945: Unknown result type (might be due to invalid IL or missing references)
			//IL_094a: Expected O, but got Unknown
			//IL_0547: Unknown result type (might be due to invalid IL or missing references)
			//IL_054c: Expected O, but got Unknown
			//IL_07df: Unknown result type (might be due to invalid IL or missing references)
			//IL_07e4: Expected O, but got Unknown
			//IL_0870: Unknown result type (might be due to invalid IL or missing references)
			//IL_0875: Expected O, but got Unknown
			//IL_089a: Invalid comparison between F4 and I
			//IL_08e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ea: Expected O, but got Unknown
			//IL_090c: Expected F4, but got I
			//IL_06ec->IL063e: Incompatible stack heights: 1 vs 0
			//IL_00b9->IL063e: Incompatible stack heights: 1 vs 0
			//IL_00db->IL063e: Incompatible stack heights: 1 vs 0
			//IL_0737->IL063e: Incompatible stack heights: 1 vs 0
			//IL_03f5->IL063e: Incompatible stack heights: 1 vs 0
			//IL_0417->IL063e: Incompatible stack heights: 1 vs 0
			//IL_014c->IL063e: Incompatible stack heights: 1 vs 0
			//IL_045c->IL063e: Incompatible stack heights: 1 vs 0
			//IL_017b->IL063e: Incompatible stack heights: 1 vs 0
			//IL_019d->IL063e: Incompatible stack heights: 1 vs 0
			//IL_0495->IL063e: Incompatible stack heights: 1 vs 0
			//IL_01cc->IL063e: Incompatible stack heights: 1 vs 0
			//IL_04d2->IL063e: Incompatible stack heights: 1 vs 0
			//IL_04f4->IL063e: Incompatible stack heights: 1 vs 0
			//IL_07aa->IL0713: Incompatible stack heights: 2 vs 1
			//IL_0523->IL063e: Incompatible stack heights: 1 vs 0
			//IL_01ff->IL063e: Incompatible stack heights: 2 vs 0
			//IL_022e->IL063e: Incompatible stack heights: 2 vs 0
			//IL_0980->IL063e: Incompatible stack heights: 2 vs 0
			//IL_0250->IL063e: Incompatible stack heights: 2 vs 0
			//IL_027f->IL063e: Incompatible stack heights: 2 vs 0
			//IL_0626->IL063e: Incompatible stack heights: 2 vs 0
			//IL_0835->IL063e: Incompatible stack heights: 3 vs 0
			//IL_02b8->IL063e: Incompatible stack heights: 3 vs 0
			//IL_02da->IL063e: Incompatible stack heights: 3 vs 0
			//IL_0309->IL063e: Incompatible stack heights: 3 vs 0
			//IL_08ad->IL0713: Incompatible stack heights: 4 vs 1
			//IL_033c->IL063e: Incompatible stack heights: 4 vs 0
			//IL_036b->IL063e: Incompatible stack heights: 4 vs 0
			//IL_038d->IL063e: Incompatible stack heights: 4 vs 0
			//IL_03bc->IL063e: Incompatible stack heights: 4 vs 0
			//IL_0912->IL0713: Incompatible stack heights: 5 vs 1
			_003C_003Ec__DisplayClass22_0 obj = CS_0024_003C_003E8__locals1;
			object obj3 = default(object);
			if (CS_0024_003C_003E8__locals1 != null)
			{
				VentUsageSlot usageSlot = obj.usageSlot;
				if (obj.usageSlot != null && (object)usageSlot._dummySprite != null)
				{
					Transform transform = usageSlot._dummySprite.transform;
					if ((object)transform != null)
					{
						_ = 0;
						_ = 0;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						object obj2 = obj3 - 72;
						Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj2);
						_003C_003Ec__DisplayClass22_0 obj4 = CS_0024_003C_003E8__locals1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
						float num = 0f;
						if (CS_0024_003C_003E8__locals1 != null)
						{
							VentUsageSlot usageSlot2 = obj4.usageSlot;
							if (obj4.usageSlot != null && (object)usageSlot2._dummySprite != null)
							{
								Sprite sprite = usageSlot2._dummySprite.sprite;
								if ((object)sprite == null || ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0)
								{
									goto IL_0713;
								}
								_003C_003Ec__DisplayClass22_0 obj5 = CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals1 != null)
								{
									VentUsageSlot usageSlot3 = obj5.usageSlot;
									if (obj5.usageSlot != null && (object)usageSlot3._dummySprite != null)
									{
										Sprite sprite2 = usageSlot3._dummySprite.sprite;
										if ((object)sprite2 != null)
										{
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v93 (UnityEngine.Sprite)+10]");
											bool flag2 = (nint)0 == 0;
											object obj6 = obj3 - 72;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v93 (UnityEngine.Sprite)+10]");
											Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj6);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
											if ((nint)0 <= (nint)0)
											{
												goto IL_0713;
											}
											_003C_003Ec__DisplayClass22_0 obj7 = CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals1 != null)
											{
												VentUsageSlot usageSlot4 = obj7.usageSlot;
												if (obj7.usageSlot != null && (object)usageSlot4._dummySprite != null)
												{
													Sprite sprite3 = usageSlot4._dummySprite.sprite;
													if ((object)sprite3 != null)
													{
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v99 (UnityEngine.Sprite)+10]");
														bool flag3 = (nint)0 == 0;
														object obj8 = obj3 - 72;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v99 (UnityEngine.Sprite)+10]");
														Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj8);
														_003C_003Ec__DisplayClass22_0 obj9 = CS_0024_003C_003E8__locals1;
														float num2 = 32f;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
														num = num2 / 0f;
														if (CS_0024_003C_003E8__locals1 != null)
														{
															VentUsageSlot usageSlot5 = obj9.usageSlot;
															if (obj9.usageSlot != null && (object)usageSlot5._dummySprite != null)
															{
																Transform transform2 = usageSlot5._dummySprite.transform;
																if ((object)transform2 != null)
																{
																	_ = 0;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v106 (UnityEngine.Transform)+10]");
																	bool flag4 = (nint)0 == 0;
																	object obj10 = obj3 - 72;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v106 (UnityEngine.Transform)+10]");
																	Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj10);
																	float num3 = num;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																	if (!(num3 > 0f))
																	{
																		goto IL_0713;
																	}
																	_003C_003Ec__DisplayClass22_0 obj11 = CS_0024_003C_003E8__locals1;
																	if (CS_0024_003C_003E8__locals1 != null)
																	{
																		VentUsageSlot usageSlot6 = obj11.usageSlot;
																		if (obj11.usageSlot != null && (object)usageSlot6._dummySprite != null)
																		{
																			Transform transform3 = usageSlot6._dummySprite.transform;
																			if ((object)transform3 != null)
																			{
																				_ = 0;
																				_ = 0;
																				bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																				object obj12 = obj3 - 72;
																				Transform.get_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj12);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																				num = 0f;
																				goto IL_0713;
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
			goto IL_063e;
			IL_063e:
			throw new NullReferenceException();
			IL_0713:
			_003C_003Ec__DisplayClass22_0 obj13 = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				VentUsageSlot usageSlot7 = obj13.usageSlot;
				if (obj13.usageSlot != null && (object)obj13._003C_003E4__this != null)
				{
					obj13._003C_003E4__this.UpdateClipping(usageSlot7._dummySprite);
					_003C_003Ec__DisplayClass22_0 obj14 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						VentUsageSlot usageSlot8 = obj14.usageSlot;
						TweenConfig tweenConfig = new TweenConfig();
						if (tweenConfig != null)
						{
							((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)tweenTargets;
							_003C_003Ec__DisplayClass22_0 obj15 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null && (object)obj15._003C_003E4__this != null)
							{
								Transform transform4 = obj15._003C_003E4__this.transform;
								if ((object)transform4 != null)
								{
									_ = 0;
									_ = 0;
									bool flag6 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
									object obj16 = obj3 - 72;
									Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj16);
									_003C_003Ec__DisplayClass22_0 obj17 = CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals1 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-44]");
										object obj18 = 0 - obj17.dropRange;
										_ = 0;
										_ = 1;
										_ = 1137180672;
										_ = 10;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+18]");
										_ = 0;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+18]");
										_ = 0;
										TweenCallback tweenCallback = _003C_003E9__2;
										if (_003C_003E9__2 == null)
										{
											tweenCallback = (_003C_003E9__2 = delegate
											{
												//IL_04ae: Expected O, but got I4
												//IL_04b7: Expected O, but got I4
												//IL_04e7: Expected I, but got O
												//IL_0522: Expected I, but got O
												//IL_0532: Expected O, but got I
												//IL_056a: Expected O, but got I
												//IL_05a3: Expected O, but got I
												//IL_05db: Expected O, but got I
												//IL_08ac: Unknown result type (might be due to invalid IL or missing references)
												//IL_08b1: Expected O, but got Unknown
												//IL_00cc->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_06b0->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_00fb->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_06d2->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_0180->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_07cc->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_01a7->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_01c5->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_07f3->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_01f9->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_0217->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_081a->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_024b->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_0292->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_0841->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_02c6->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_02e4->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_0868->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_0318->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_036a->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_038c->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_03c7->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_03e9->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_0424->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_0446->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_0477->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_04a0->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_0632->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_0661->IL06f3: Incompatible stack heights: 1 vs 0
												//IL_08be->IL08d8: Incompatible stack heights: 8 vs 1
												_003C_003Ec__DisplayClass22_0 obj19 = CS_0024_003C_003E8__locals1;
												VentProjectile ventProjectile;
												VentUsageSlot usageSlot10;
												object[] array;
												ArcadeSprite phaserObject;
												if (CS_0024_003C_003E8__locals1 != null)
												{
													VentUsageSlot usageSlot9 = obj19.usageSlot;
													if (obj19.usageSlot != null && (object)usageSlot9._dummySprite != null)
													{
														Transform transform5 = usageSlot9._dummySprite.transform;
														bool flag7 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
														Vector3 value = default(Vector3);
														Transform.set_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value);
														Transform transform6 = (Transform)(object)pickup;
														if ((object)pickup != null && ((UnityEngine.Object)transform6).m_CachedPtr != (IntPtr)0)
														{
															_003C_003Ec__DisplayClass22_0 obj20 = CS_0024_003C_003E8__locals1;
															if (CS_0024_003C_003E8__locals1 != null)
															{
																ventProjectile = obj20._003C_003E4__this;
																if ((object)obj20._003C_003E4__this != null)
																{
																	usageSlot10 = obj20.usageSlot;
																	array = tweenTargets;
																	phaserObject = pickup;
																	goto IL_08be;
																}
															}
														}
														else
														{
															Transform transform7 = (Transform)(object)character;
															if ((object)character != null && ((UnityEngine.Object)transform7).m_CachedPtr != (IntPtr)0)
															{
																if ((object)GM.Core != null)
																{
																	PhaserScene s_scene = ArcadePhysics.s_scene;
																	if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
																	{
																		PhaserScene s_scene2 = ArcadePhysics.s_scene;
																		if (ArcadePhysics.s_scene != null)
																		{
																			PhaserScene.Renderer renderer = s_scene2._renderer;
																			if (s_scene2._renderer != null && (object)GM.Core != null)
																			{
																				PhaserScene s_scene3 = ArcadePhysics.s_scene;
																				if (ArcadePhysics.s_scene != null)
																				{
																					PhaserScene.Renderer renderer2 = s_scene3._renderer;
																					if (s_scene3._renderer != null)
																					{
																						float minInclusive = renderer.width ^ -0f;
																						float num4 = UnityEngine.Random.Range(minInclusive, renderer2.width);
																						if ((object)GM.Core != null)
																						{
																							PhaserScene s_scene4 = ArcadePhysics.s_scene;
																							if (ArcadePhysics.s_scene != null)
																							{
																								PhaserScene.Renderer renderer3 = s_scene4._renderer;
																								if (s_scene4._renderer != null && (object)GM.Core != null)
																								{
																									PhaserScene s_scene5 = ArcadePhysics.s_scene;
																									if (ArcadePhysics.s_scene != null)
																									{
																										PhaserScene.Renderer renderer4 = s_scene5._renderer;
																										if (s_scene5._renderer != null)
																										{
																											float minInclusive2 = renderer3.height ^ -0f;
																											float num5 = UnityEngine.Random.Range(minInclusive2, renderer4.height);
																											_003C_003Ec__DisplayClass22_0 obj21 = CS_0024_003C_003E8__locals1;
																											if (CS_0024_003C_003E8__locals1 != null && (object)obj21._003C_003E4__this != null)
																											{
																												float2 position = default(float2);
																												obj21._003C_003E4__this.position = position;
																												_003C_003Ec__DisplayClass22_0 obj22 = CS_0024_003C_003E8__locals1;
																												if (CS_0024_003C_003E8__locals1 != null && (object)obj22._003C_003E4__this != null)
																												{
																													float2 position2 = obj22._003C_003E4__this.position;
																													_003C_003Ec__DisplayClass22_0 obj23 = CS_0024_003C_003E8__locals1;
																													if (CS_0024_003C_003E8__locals1 != null && (object)obj23._003C_003E4__this != null)
																													{
																														float2 position3 = obj23._003C_003E4__this.position;
																														if (CS_0024_003C_003E8__locals1 != null)
																														{
																															object[] array2 = tweenTargets;
																															if (tweenTargets != null)
																															{
																																object obj24 = 0;
																																object obj25 = 0;
																																float2 value2 = default(float2);
																																while ((nint)obj25 < array2.Length)
																																{
																																	bool flag8 = (nint)obj24 >= array2.Length;
																																	nint num6 = (nint)typeof(Transform);
																																	object obj26 = array2[obj24];
																																	bool flag9 = array2[obj24] == null;
																																	nint num7 = (nint)obj26;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																	object obj27 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+130]");
																																	nint num8 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																	bool flag10 = num8 < 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+C8]");
																																	object obj28 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ rax_v78+FFFFFFF8+v1157 @ rax_v77*8]");
																																	bool flag11 = 0 != (nint)typeof(Transform);
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																	object obj29 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+130]");
																																	nint num9 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																	bool flag12 = num9 < 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+C8]");
																																	object obj30 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1065 @ rax_v80+FFFFFFF8+v1064 @ rax_v79*8]");
																																	bool flag13 = 0 != (nint)typeof(Transform);
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rbx_v16 (System.Object)+10]");
																																	bool flag14 = (nint)0 == 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rbx_v16 (System.Object)+10]");
																																	Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value2));
																																	obj24++;
																																	obj25 = obj24;
																																}
																																_003C_003Ec__DisplayClass22_0 obj31 = CS_0024_003C_003E8__locals1;
																																if (CS_0024_003C_003E8__locals1 != null)
																																{
																																	ventProjectile = obj31._003C_003E4__this;
																																	if ((object)obj31._003C_003E4__this != null)
																																	{
																																		usageSlot10 = obj31.usageSlot;
																																		array = tweenTargets;
																																		phaserObject = character;
																																		goto IL_08be;
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
															else
															{
																_003C_003Ec__DisplayClass22_0 obj32 = CS_0024_003C_003E8__locals1;
																if (CS_0024_003C_003E8__locals1 != null && (object)obj32._003C_003E4__this != null)
																{
																	obj32._003C_003E4__this.UseFinished(obj32.usageSlot);
																	return;
																}
															}
														}
													}
												}
												throw new NullReferenceException();
												IL_08be:
												ventProjectile.ReturnFromVent(phaserObject, array, usageSlot10);
											});
										}
										MultiTargetTween currentTween = Tweens.Add(tweenConfig);
										if (obj14.usageSlot != null)
										{
											usageSlot8._currentTween = currentTween;
											return;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_063e;
		}

		internal unsafe void _003COnHasHitAnObject_003Eb__2()
		{
			//IL_04ae: Expected O, but got I4
			//IL_04b7: Expected O, but got I4
			//IL_04e7: Expected I, but got O
			//IL_0522: Expected I, but got O
			//IL_0532: Expected O, but got I
			//IL_056a: Expected O, but got I
			//IL_05a3: Expected O, but got I
			//IL_05db: Expected O, but got I
			//IL_08ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_08b1: Expected O, but got Unknown
			//IL_00cc->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_06b0->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_00fb->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_06d2->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_0180->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_07cc->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_01a7->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_01c5->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_07f3->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_01f9->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_0217->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_081a->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_024b->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_0292->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_0841->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_02c6->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_02e4->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_0868->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_0318->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_036a->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_038c->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_03c7->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_03e9->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_0424->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_0446->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_0477->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_04a0->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_0632->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_0661->IL06f3: Incompatible stack heights: 1 vs 0
			//IL_08be->IL08d8: Incompatible stack heights: 8 vs 1
			_003C_003Ec__DisplayClass22_0 obj = CS_0024_003C_003E8__locals1;
			VentProjectile ventProjectile;
			VentUsageSlot usageSlot2;
			object[] array;
			ArcadeSprite phaserObject;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				VentUsageSlot usageSlot = obj.usageSlot;
				if (obj.usageSlot != null && (object)usageSlot._dummySprite != null)
				{
					Transform transform = usageSlot._dummySprite.transform;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					Transform transform2 = (Transform)(object)pickup;
					if ((object)pickup != null && ((UnityEngine.Object)transform2).m_CachedPtr != (IntPtr)0)
					{
						_003C_003Ec__DisplayClass22_0 obj2 = CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals1 != null)
						{
							ventProjectile = obj2._003C_003E4__this;
							if ((object)obj2._003C_003E4__this != null)
							{
								usageSlot2 = obj2.usageSlot;
								array = tweenTargets;
								phaserObject = pickup;
								goto IL_08be;
							}
						}
					}
					else
					{
						Transform transform3 = (Transform)(object)character;
						if ((object)character != null && ((UnityEngine.Object)transform3).m_CachedPtr != (IntPtr)0)
						{
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
								{
									PhaserScene s_scene2 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										PhaserScene.Renderer renderer = s_scene2._renderer;
										if (s_scene2._renderer != null && (object)GM.Core != null)
										{
											PhaserScene s_scene3 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer2 = s_scene3._renderer;
												if (s_scene3._renderer != null)
												{
													float minInclusive = renderer.width ^ -0f;
													float num = UnityEngine.Random.Range(minInclusive, renderer2.width);
													if ((object)GM.Core != null)
													{
														PhaserScene s_scene4 = ArcadePhysics.s_scene;
														if (ArcadePhysics.s_scene != null)
														{
															PhaserScene.Renderer renderer3 = s_scene4._renderer;
															if (s_scene4._renderer != null && (object)GM.Core != null)
															{
																PhaserScene s_scene5 = ArcadePhysics.s_scene;
																if (ArcadePhysics.s_scene != null)
																{
																	PhaserScene.Renderer renderer4 = s_scene5._renderer;
																	if (s_scene5._renderer != null)
																	{
																		float minInclusive2 = renderer3.height ^ -0f;
																		float num2 = UnityEngine.Random.Range(minInclusive2, renderer4.height);
																		_003C_003Ec__DisplayClass22_0 obj3 = CS_0024_003C_003E8__locals1;
																		if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
																		{
																			float2 position = default(float2);
																			obj3._003C_003E4__this.position = position;
																			_003C_003Ec__DisplayClass22_0 obj4 = CS_0024_003C_003E8__locals1;
																			if (CS_0024_003C_003E8__locals1 != null && (object)obj4._003C_003E4__this != null)
																			{
																				float2 position2 = obj4._003C_003E4__this.position;
																				_003C_003Ec__DisplayClass22_0 obj5 = CS_0024_003C_003E8__locals1;
																				if (CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
																				{
																					float2 position3 = obj5._003C_003E4__this.position;
																					if (CS_0024_003C_003E8__locals1 != null)
																					{
																						object[] array2 = tweenTargets;
																						if (tweenTargets != null)
																						{
																							object obj6 = 0;
																							object obj7 = 0;
																							float2 value2 = default(float2);
																							while ((nint)obj7 < array2.Length)
																							{
																								bool flag2 = (nint)obj6 >= array2.Length;
																								nint num3 = (nint)typeof(Transform);
																								object obj8 = array2[obj6];
																								bool flag3 = array2[obj6] == null;
																								nint num4 = (nint)obj8;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																								object obj9 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+130]");
																								nint num5 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																								bool flag4 = num5 < 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+C8]");
																								object obj10 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ rax_v78+FFFFFFF8+v1157 @ rax_v77*8]");
																								bool flag5 = 0 != (nint)typeof(Transform);
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																								object obj11 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+130]");
																								nint num6 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																								bool flag6 = num6 < 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+C8]");
																								object obj12 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1065 @ rax_v80+FFFFFFF8+v1064 @ rax_v79*8]");
																								bool flag7 = 0 != (nint)typeof(Transform);
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rbx_v16 (System.Object)+10]");
																								bool flag8 = (nint)0 == 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rbx_v16 (System.Object)+10]");
																								Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value2));
																								obj6++;
																								obj7 = obj6;
																							}
																							_003C_003Ec__DisplayClass22_0 obj13 = CS_0024_003C_003E8__locals1;
																							if (CS_0024_003C_003E8__locals1 != null)
																							{
																								ventProjectile = obj13._003C_003E4__this;
																								if ((object)obj13._003C_003E4__this != null)
																								{
																									usageSlot2 = obj13.usageSlot;
																									array = tweenTargets;
																									phaserObject = character;
																									goto IL_08be;
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
						else
						{
							_003C_003Ec__DisplayClass22_0 obj14 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null && (object)obj14._003C_003E4__this != null)
							{
								obj14._003C_003E4__this.UseFinished(obj14.usageSlot);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_08be:
			ventProjectile.ReturnFromVent(phaserObject, array, usageSlot2);
		}
	}

	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public VentProjectile _003C_003E4__this;

		public VentUsageSlot slot;

		public object[] tweenTargets;

		public ArcadeSprite phaserObject;

		public TweenCallback _003C_003E9__1;

		internal void _003CReturnFromVent_003Eb__0()
		{
			//IL_01cd: Expected O, but got I4
			//IL_0147->IL015f: Incompatible stack heights: 1 vs 0
			VentUsageSlot ventUsageSlot = slot;
			if (slot != null && (object)_003C_003E4__this != null)
			{
				_003C_003E4__this.UpdateClipping(ventUsageSlot._dummySprite, -1000f);
				VentUsageSlot ventUsageSlot2 = slot;
				TweenConfig tweenConfig = new TweenConfig();
				if (tweenConfig != null)
				{
					tweenConfig.targets = tweenTargets;
					if ((object)_003C_003E4__this != null)
					{
						Transform transform = _003C_003E4__this.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
							tweenConfig.y = (float?)(object)1;
							tweenConfig.duration = 400f;
							tweenConfig.ease = Ease.OutBounce;
							TweenCallback onComplete = _003C_003E9__1;
							if (_003C_003E9__1 == null)
							{
								onComplete = (_003C_003E9__1 = delegate
								{
									//IL_01bd: Expected I, but got O
									//IL_01c5: Expected I, but got O
									//IL_01d5: Expected O, but got I
									//IL_0255: Expected O, but got I4
									//IL_0211: Expected O, but got I
									//IL_0247: Expected O, but got I4
									//IL_02d5: Expected O, but got I
									//IL_03ed->IL030f: Incompatible stack heights: 7 vs 0
									//IL_02f8->IL030f: Incompatible stack heights: 7 vs 0
									//IL_02ba->IL030f: Incompatible stack heights: 7 vs 0
									object obj3;
									Transform transform4;
									if ((object)phaserObject != null)
									{
										Transform transform2 = phaserObject.transform;
										VentUsageSlot ventUsageSlot3 = slot;
										if (slot != null && (object)ventUsageSlot3._dummySprite != null)
										{
											Transform transform3 = ventUsageSlot3._dummySprite.transform;
											if ((object)transform3 != null)
											{
												bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
												bool flag3 = (object)transform2 == null;
												bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
												Vector3 value = default(Vector3);
												Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
												VentUsageSlot ventUsageSlot4 = slot;
												bool flag5 = slot == null;
												bool flag6 = (object)ventUsageSlot4._dummySprite == null;
												ventUsageSlot4._dummySprite.enabled = false;
												bool flag7 = (object)phaserObject == null;
												ArcadeSprite arcadeSprite = phaserObject.setVisible(visible: true);
												ArcadeSprite arcadeSprite2 = phaserObject;
												bool flag8 = (object)phaserObject == null;
												if (arcadeSprite2.body != null)
												{
													BaseBody body = arcadeSprite2.body;
													body._enable = true;
												}
												if ((object)phaserObject != null)
												{
													phaserObject.enabled = true;
													ArcadeSprite arcadeSprite3 = phaserObject;
													if ((object)phaserObject != null)
													{
														nint num = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
														nint num2 = (nint)arcadeSprite3;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
														object obj = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ r9_v8 (Il2CppClass<ArcadeSprite>)+130]");
														nint num3 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
														if (num3 >= 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ r9_v8 (Il2CppClass<ArcadeSprite>)+C8]");
															object obj2 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rax_v50+FFFFFFF8+v567 @ rax_v46*8]");
															if (0 == (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController))
															{
																obj3 = 1;
																goto IL_03f7;
															}
														}
														obj3 = 0;
														goto IL_03f7;
													}
													transform4 = null;
													goto IL_041e;
												}
											}
										}
									}
									goto IL_030f;
									IL_030f:
									throw new NullReferenceException();
									IL_041e:
									if ((object)transform4 != null && ((UnityEngine.Object)transform4).m_CachedPtr != (IntPtr)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v9 (UnityEngine.Transform)+E0]");
										if ((nint)0 == 0)
										{
											goto IL_030f;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v9 (UnityEngine.Transform)+E0]");
										SpriteTrail spriteTrail = ((SpriteTrail)0).setVisible(b: true);
									}
									if ((object)_003C_003E4__this != null)
									{
										_003C_003E4__this.UseFinished(slot);
										return;
									}
									goto IL_030f;
									IL_03f7:
									bool flag9 = obj3 == null;
									transform4 = null;
									if (!flag9)
									{
										transform4 = (Transform)(object)phaserObject;
									}
									goto IL_041e;
								});
							}
							tweenConfig.onComplete = onComplete;
							MultiTargetTween currentTween = Tweens.Add(tweenConfig);
							if (slot != null)
							{
								ventUsageSlot2._currentTween = currentTween;
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CReturnFromVent_003Eb__1()
		{
			//IL_01bd: Expected I, but got O
			//IL_01c5: Expected I, but got O
			//IL_01d5: Expected O, but got I
			//IL_0255: Expected O, but got I4
			//IL_0211: Expected O, but got I
			//IL_0247: Expected O, but got I4
			//IL_02d5: Expected O, but got I
			//IL_03ed->IL030f: Incompatible stack heights: 7 vs 0
			//IL_02f8->IL030f: Incompatible stack heights: 7 vs 0
			//IL_02ba->IL030f: Incompatible stack heights: 7 vs 0
			Transform transform3;
			object obj3;
			if ((object)phaserObject != null)
			{
				Transform transform = phaserObject.transform;
				VentUsageSlot ventUsageSlot = slot;
				if (slot != null && (object)ventUsageSlot._dummySprite != null)
				{
					Transform transform2 = ventUsageSlot._dummySprite.transform;
					if ((object)transform2 != null)
					{
						bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
						bool flag2 = (object)transform == null;
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						VentUsageSlot ventUsageSlot2 = slot;
						bool flag4 = slot == null;
						bool flag5 = (object)ventUsageSlot2._dummySprite == null;
						ventUsageSlot2._dummySprite.enabled = false;
						bool flag6 = (object)phaserObject == null;
						ArcadeSprite arcadeSprite = phaserObject.setVisible(visible: true);
						ArcadeSprite arcadeSprite2 = phaserObject;
						bool flag7 = (object)phaserObject == null;
						if (arcadeSprite2.body != null)
						{
							BaseBody body = arcadeSprite2.body;
							body._enable = true;
						}
						if ((object)phaserObject != null)
						{
							phaserObject.enabled = true;
							ArcadeSprite arcadeSprite3 = phaserObject;
							if ((object)phaserObject == null)
							{
								transform3 = null;
								goto IL_041e;
							}
							nint num = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
							nint num2 = (nint)arcadeSprite3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ r9_v8 (Il2CppClass<ArcadeSprite>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ r9_v8 (Il2CppClass<ArcadeSprite>)+C8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rax_v50+FFFFFFF8+v567 @ rax_v46*8]");
								if (0 == (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController))
								{
									obj3 = 1;
									goto IL_03f7;
								}
							}
							obj3 = 0;
							goto IL_03f7;
						}
					}
				}
			}
			goto IL_030f;
			IL_030f:
			throw new NullReferenceException();
			IL_041e:
			if ((object)transform3 != null && ((UnityEngine.Object)transform3).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v9 (UnityEngine.Transform)+E0]");
				if ((nint)0 == 0)
				{
					goto IL_030f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v9 (UnityEngine.Transform)+E0]");
				SpriteTrail spriteTrail = ((SpriteTrail)0).setVisible(b: true);
			}
			if ((object)_003C_003E4__this != null)
			{
				_003C_003E4__this.UseFinished(slot);
				return;
			}
			goto IL_030f;
			IL_03f7:
			bool flag8 = obj3 == null;
			transform3 = null;
			if (!flag8)
			{
				transform3 = (Transform)(object)phaserObject;
			}
			goto IL_041e;
		}
	}

	private Material _dummySpriteMaterial;

	private int _uses = 1;

	private float selfScale = 1f;

	private bool _readyForUse;

	protected PhaserSprite _ventSprite;

	protected PhaserSprite _blackHoleSprite;

	private MultiTargetTween _currentTween;

	private List<VentUsageSlot> _usageSlots;

	private int _currentlyAnimatingCount;

	private float _repeatIntervalCounter;

	public bool CanSuckMore
	{
		get
		{
			//IL_004c: Invalid comparison between I4 and F4
			if (_uses > 0 && _readyForUse)
			{
				bool flag = 0f < _repeatIntervalCounter;
				return !flag;
			}
			return false;
		}
	}

	public PhaserSprite VentSprite => _ventSprite;

	protected override void Awake()
	{
		//IL_00c5: Expected I4, but got I8
		//IL_0101: Expected O, but got I4
		//IL_0166: Expected O, but got I4
		//IL_0166: Expected I4, but got O
		//IL_01a1: Expected O, but got I4
		//IL_01a1: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("circle", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		Vector2 vector = default(Vector2);
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("C1_Vent", 0, 0, vector, text, num, flag);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("C1_Vent", 0, 5, vector, text, num, flag);
		PhaserWorld instance = PhaserWorld.Instance;
		PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "vfx", "C1_Vent0000");
		PhaserSprite phaserSprite2 = phaserSprite.setDepth(-1995);
		GameObject gameObject = phaserSprite2.gameObject;
		((UnityEngine.Object)gameObject).SetName("__ventSprite");
		PhaserSprite phaserSprite3 = phaserSprite2.setScale(1f, (float?)(object)0);
		PhaserSprite ventSprite = phaserSprite3.setVisible(visible: false);
		_ventSprite = ventSprite;
		PhaserSprite ventSprite2 = _ventSprite;
		bool autoSetAnimation = default(bool);
		ventSprite2._spriteAnimation.AddAnimation("close", animationFrames2, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite ventSprite3 = _ventSprite;
		ventSprite3._spriteAnimation.AddAnimation("idle", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
	}

	public unsafe override void InternalUpdate()
	{
		//IL_003d: Invalid comparison between I4 and F4
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Expected O, but got Unknown
		//IL_0622: Expected I, but got O
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Expected O, but got Unknown
		//IL_068f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected O, but got Unknown
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_0571: Expected I, but got O
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Expected O, but got Unknown
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Expected O, but got Unknown
		//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Expected O, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Expected O, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected O, but got Unknown
		//IL_0519: Unknown result type (might be due to invalid IL or missing references)
		//IL_051e: Expected O, but got Unknown
		//IL_0526: Invalid comparison between F4 and O
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected O, but got Unknown
		//IL_0366: Expected O, but got I
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_0383: Invalid comparison between F4 and O
		//IL_0395: Expected F4, but got I4
		//IL_01a0: Invalid comparison between F4 and I4
		//IL_00e0: Expected O, but got I
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		if (0f > (_repeatIntervalCounter -= num))
		{
			_repeatIntervalCounter = 0f;
		}
		bool num2;
		object obj2 = default(object);
		bool num6;
		bool num7;
		bool num8;
		bool num9;
		float alpha;
		if (_uses <= 0)
		{
			Transform transform = base.transform;
			Transform transform2 = base.transform;
			if ((object)transform2 == null)
			{
				goto IL_0215;
			}
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			num2 = flag;
			object obj = obj2 - 80;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj);
			nint num3 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rax_v77 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num4 = 0;
			_ = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rax_v78 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
			_ = 0;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num5 = deltaTime2 * 8f;
			object obj3 = obj2 - 64;
			object obj4 = obj2 - 48;
			object obj5 = obj2 - 80;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2E70");
			bool flag2 = (object)transform == null;
			num6 = flag2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rax_v81+8]");
			_ = 0;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			num7 = flag3;
			object obj6 = obj2 - 48;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj6);
			CheckRenderer();
			Transform spriteRenderer = (Transform)(object)((ArcadeSprite)this)._spriteRenderer;
			bool flag4 = (object)((ArcadeSprite)this)._spriteRenderer == null;
			num8 = flag4;
			_ = 0;
			bool flag5 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			num9 = flag5;
			object obj7 = obj2 - 64;
			SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Color*)obj7);
			float deltaTime3 = PauseSystem.DeltaTime;
			float num10 = deltaTime3 * 4f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
			object obj8 = -0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj9 = obj8 & 0;
			bool flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num10) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9);
			float num11 = 0f;
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
				object obj10 = -0;
				float num12 = (((nint)obj10 < 0) ? (-1f) : 1f);
				float num13 = num12 * num10;
				float num14 = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
				num11 = num14 + 0f;
			}
			alpha = num11;
		}
		else
		{
			Transform transform3 = base.transform;
			Transform transform4 = base.transform;
			if ((object)transform4 == null)
			{
				goto IL_0215;
			}
			_ = 0;
			_ = 0;
			bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
			num2 = flag7;
			object obj11 = obj2 - 80;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj11);
			nint num15 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v47 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num16 = 0;
			_ = Vector3.oneVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rax_v48 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
			_ = 0;
			float deltaTime4 = PauseSystem.DeltaTime;
			float num17 = deltaTime4 * 8f;
			object obj12 = obj2 - 48;
			object obj13 = obj2 - 64;
			object obj14 = obj2 - 80;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2E70");
			bool flag8 = (object)transform3 == null;
			num6 = flag8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rax_v51+8]");
			_ = 0;
			bool flag9 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			num7 = flag9;
			object obj15 = obj2 - 48;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj15);
			CheckRenderer();
			Transform spriteRenderer2 = (Transform)(object)((ArcadeSprite)this)._spriteRenderer;
			bool flag10 = (object)((ArcadeSprite)this)._spriteRenderer == null;
			num8 = flag10;
			_ = 0;
			bool flag11 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
			num9 = flag11;
			object obj16 = obj2 - 64;
			SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, out *(Color*)obj16);
			float deltaTime5 = PauseSystem.DeltaTime;
			float num18 = deltaTime5 * 4f;
			float num19 = 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
			float num20 = num19 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj17 = num20 & 0;
			bool flag12 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num18) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj17);
			float num21 = 0.5f;
			if (!flag12)
			{
				float num22 = 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
				float num23 = num22 - 0f;
				if (!(num23 < 0f))
				{
					float num24 = 1f * num18;
					float num25 = num24;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
					float num26 = num25 + 0f;
					alpha = num26;
					goto IL_0554;
				}
				float num27 = -1f * num18;
				float num28 = num27;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-34]");
				num21 = num28 + 0f;
			}
			alpha = num21;
		}
		goto IL_0554;
		IL_0215:
		throw new NullReferenceException();
		IL_0554:
		ArcadeSprite arcadeSprite = setAlpha(alpha);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_010c: Expected O, but got I4
		//IL_010c: Expected O, but got I4
		//IL_0153: Expected O, but got I4
		//IL_0162: Expected I4, but got I8
		//IL_018a: Expected O, but got I4
		//IL_01ce: Expected O, but got I4
		//IL_03e9: Expected I, but got O
		//IL_03fc: Expected O, but got I4
		//IL_040a: Expected O, but got I4
		//IL_04e9->IL0454: Incompatible stack heights: 1 vs 0
		//IL_00b1->IL0454: Incompatible stack heights: 1 vs 0
		//IL_03b9->IL03b9: Incompatible stack heights: 16 vs 15
		base.InitProjectile(pool, weapon, index);
		_uses = index;
		_isCullable = false;
		if ((object)weapon != null)
		{
			float num = weapon.PArea();
			object obj = default(object);
			float num2 = (float)obj * 32f;
			float num3 = weapon.PArea();
			CheckRenderer();
			if ((object)((ArcadeSprite)this)._spriteRenderer != null)
			{
				Transform transform = ((ArcadeSprite)this)._spriteRenderer.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					if ((object)_renderer != null)
					{
						Sprite sprite = _renderer.sprite;
						if ((object)sprite != null)
						{
							bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
							bool flag3 = (object)_renderer == null;
							Sprite sprite2 = _renderer.sprite;
							bool flag4 = (object)sprite2 == null;
							bool flag5 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out ret);
							object obj2 = default(object);
							float num4 = (float)obj2 * 0.5f;
							float num5 = num4 - num2;
							bool flag6 = body == null;
							BaseBody baseBody = body.setCircle(num2, (float?)(object)1, (float?)(object)1);
							BaseBody baseBody2 = body;
							bool flag7 = body == null;
							baseBody2._enable = true;
							setVelocity(0f, (float?)(object)1);
							ArcadeSprite arcadeSprite = setDepth(-1000);
							ArcadeSprite arcadeSprite2 = setAlpha(0f);
							ArcadeSprite arcadeSprite3 = setScale(0f, (float?)(object)0);
							_readyForUse = false;
							bool flag8 = (object)_ventSprite == null;
							PhaserSprite phaserSprite = _ventSprite.setScale(0f, (float?)(object)0);
							bool flag9 = (object)_ventSprite == null;
							PhaserSprite phaserSprite2 = _ventSprite.setAlpha(1f);
							float2 float5 = base.position;
							bool flag10 = (object)_ventSprite == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
							bool flag11 = (object)_ventSprite == null;
							PhaserSprite phaserSprite3 = _ventSprite.setVisible(visible: true);
							int num6 = base.depth;
							bool flag12 = (object)_ventSprite == null;
							int num7 = num6 + 10;
							PhaserSprite phaserSprite4 = _ventSprite.setDepth(num7);
							PhaserSprite ventSprite = _ventSprite;
							bool flag13 = (object)_ventSprite == null;
							bool flag14 = (object)ventSprite._spriteAnimation == null;
							ventSprite._spriteAnimation.SetAnimation("idle");
							if (_currentTween != null)
							{
								_currentTween.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							bool flag15 = array == null;
							if ((object)_ventSprite != null)
							{
								void* value2 = ((IntPtr*)(&array))->m_value;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj3 = default(object);
								bool flag16 = obj3 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							bool flag17 = tweenConfig == null;
							((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
							((MonoBehaviour)(object)tweenConfig).m_CancellationTokenSource = (CancellationTokenSource)1132068864;
							((Weapon)(object)tweenConfig)._gameSessionData = (GameSessionData)1;
							TweenCallback signalBus = Activate;
							((Equipment)(object)tweenConfig)._signalBus = (SignalBus)(object)signalBus;
							MultiTargetTween currentTween = Tweens.Add(tweenConfig);
							_currentTween = currentTween;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Activate()
	{
		_readyForUse = true;
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		OnHasHitAnObject(other);
	}

	private VentUsageSlot CreateNewSlot()
	{
		//IL_0118: Expected I, but got O
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0063: Expected I, but got O
		VentUsageSlot ventUsageSlot = new VentUsageSlot();
		Type[] array = new Type[1];
		nint num = (nint)typeof(SpriteRenderer);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		if (num != 0)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		GameObject gameObject = new GameObject("DummyObject", array);
		SpriteRenderer component = gameObject.GetComponent<SpriteRenderer>();
		((Renderer)component).SetMaterial(_dummySpriteMaterial);
		ventUsageSlot._dummySprite = component;
		return ventUsageSlot;
	}

	public void DoVentHit(IDamageable other)
	{
		OnHasHitAnObject(other);
	}

	protected unsafe override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0063: Invalid comparison between I4 and F4
		//IL_00e4: Expected I, but got O
		//IL_00ec: Expected I, but got O
		//IL_00fc: Expected O, but got I
		//IL_017c: Expected O, but got I4
		//IL_00d1: Expected I, but got I8
		//IL_08a9: Expected I, but got O
		//IL_0138: Expected O, but got I
		//IL_019c: Expected I, but got O
		//IL_016e: Expected O, but got I4
		//IL_07ee: Expected F4, but got I4
		//IL_0845->IL0881: Incompatible stack heights: 20 vs 0
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals79 = new _003C_003Ec__DisplayClass22_0();
		if (CS_0024_003C_003E8__locals79 == null)
		{
			goto IL_0845;
		}
		CS_0024_003C_003E8__locals79.other = other;
		CS_0024_003C_003E8__locals79._003C_003E4__this = this;
		if (_uses <= 0 || !_readyForUse || 0f < _repeatIntervalCounter)
		{
			return;
		}
		IDamageable other2 = CS_0024_003C_003E8__locals79.other;
		ArcadeSprite arcadeSprite;
		nint num;
		if (CS_0024_003C_003E8__locals79.other == null)
		{
			arcadeSprite = null;
			num = unchecked((nint)6603577472L);
			goto IL_08bc;
		}
		nint num2 = (nint)typeof(ArcadeSprite);
		num = (nint)other2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r8_v31 (Il2CppClass<ArcadeSprite>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r9_v13 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r8_v31 (Il2CppClass<ArcadeSprite>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r9_v13 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rax_v122+FFFFFFF8+v727 @ rax_v118*8]");
			if (0 == (nint)typeof(ArcadeSprite))
			{
				obj3 = 1;
				goto IL_0887;
			}
		}
		obj3 = 0;
		goto IL_0887;
		IL_0845:
		throw new NullReferenceException();
		IL_0887:
		bool flag = obj3 == null;
		arcadeSprite = null;
		nint num4 = (nint)typeof(ArcadeSprite);
		if (!flag)
		{
			arcadeSprite = (ArcadeSprite)CS_0024_003C_003E8__locals79.other;
			num4 = (nint)typeof(ArcadeSprite);
		}
		goto IL_08bc;
		IL_08bc:
		if ((object)arcadeSprite == null || ((UnityEngine.Object)arcadeSprite).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			WeaponData currentWeaponData = weapon._currentWeaponData;
			if (weapon._currentWeaponData != null)
			{
				int uses = _uses - 1;
				_uses = uses;
				_repeatIntervalCounter = currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				List<VentUsageSlot> usageSlots = _usageSlots;
				if (_usageSlots != null)
				{
					if (_currentlyAnimatingCount >= usageSlots._size)
					{
						VentUsageSlot ventUsageSlot = CreateNewSlot();
						if (_usageSlots == null)
						{
							goto IL_0845;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD470");
					}
					if (_usageSlots == null)
					{
						return;
					}
					List<VentUsageSlot> usageSlots2 = _usageSlots;
					if (_currentlyAnimatingCount >= usageSlots2._size || _currentlyAnimatingCount < 0)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					VentUsageSlot usageSlot = default(VentUsageSlot);
					CS_0024_003C_003E8__locals79.usageSlot = usageSlot;
					int currentlyAnimatingCount = _currentlyAnimatingCount + 1;
					_currentlyAnimatingCount = currentlyAnimatingCount;
					float2 float5 = arcadeSprite.displaySize;
					VentUsageSlot usageSlot2 = CS_0024_003C_003E8__locals79.usageSlot;
					object obj4 = default(object);
					float dropRange = (float)obj4 + 0.19999999f;
					CS_0024_003C_003E8__locals79.dropRange = dropRange;
					if (CS_0024_003C_003E8__locals79.usageSlot != null && (object)usageSlot2._dummySprite != null)
					{
						Transform transform = usageSlot2._dummySprite.transform;
						Transform transform2 = arcadeSprite.transform;
						if ((object)transform2 != null)
						{
							Vector3 localScale = transform2.localScale;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1509 @ rax_v47 (UnityEngine.Transform)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1509 @ rax_v47 (UnityEngine.Transform)+10]");
							float value = default(float);
							Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value));
							VentUsageSlot usageSlot3 = CS_0024_003C_003E8__locals79.usageSlot;
							arcadeSprite.CheckRenderer();
							Sprite sprite = arcadeSprite._spriteRenderer.sprite;
							usageSlot3._dummySprite.sprite = sprite;
							VentUsageSlot usageSlot4 = CS_0024_003C_003E8__locals79.usageSlot;
							object dummySprite = usageSlot4._dummySprite;
							arcadeSprite.CheckRenderer();
							Color color = arcadeSprite._spriteRenderer.color;
							bool flag3 = (object)usageSlot4._dummySprite == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ r14_v16 (System.Object)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ r14_v16 (System.Object)+10]");
							float value2 = default(float);
							SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value2));
							VentUsageSlot usageSlot5 = CS_0024_003C_003E8__locals79.usageSlot;
							bool flag5 = CS_0024_003C_003E8__locals79.usageSlot == null;
							arcadeSprite.CheckRenderer();
							bool flag6 = (object)arcadeSprite._spriteRenderer == null;
							bool flag7 = arcadeSprite._spriteRenderer.flipX;
							bool flag8 = (object)usageSlot5._dummySprite == null;
							usageSlot5._dummySprite.flipX = flag7;
							VentUsageSlot usageSlot6 = CS_0024_003C_003E8__locals79.usageSlot;
							bool flag9 = CS_0024_003C_003E8__locals79.usageSlot == null;
							bool flag10 = (object)usageSlot6._dummySprite == null;
							usageSlot6._dummySprite.enabled = false;
							VentUsageSlot usageSlot7 = CS_0024_003C_003E8__locals79.usageSlot;
							bool flag11 = CS_0024_003C_003E8__locals79.usageSlot == null;
							int num5 = base.depth;
							bool flag12 = (object)usageSlot7._dummySprite == null;
							int sortingOrder = num5 + 10;
							usageSlot7._dummySprite.sortingOrder = sortingOrder;
							bool flag13 = (object)_ventSprite == null;
							_ventSprite.enabled = true;
							int num6 = base.depth;
							bool flag14 = (object)_ventSprite == null;
							int num7 = num6 + 10;
							PhaserSprite phaserSprite = _ventSprite.setDepth(num7);
							VentUsageSlot usageSlot8 = CS_0024_003C_003E8__locals79.usageSlot;
							bool flag15 = CS_0024_003C_003E8__locals79.usageSlot == null;
							UpdateClipping(usageSlot8._dummySprite, -1000f);
							VentUsageSlot usageSlot9 = CS_0024_003C_003E8__locals79.usageSlot;
							bool flag16 = CS_0024_003C_003E8__locals79.usageSlot == null;
							bool flag17 = (object)usageSlot9._dummySprite == null;
							Transform transform3 = usageSlot9._dummySprite.transform;
							arcadeSprite.CheckRenderer();
							bool flag18 = (object)arcadeSprite._spriteRenderer == null;
							Transform transform4 = arcadeSprite._spriteRenderer.transform;
							bool flag19 = (object)transform4 == null;
							Vector3 vector = transform4.position;
							bool flag20 = (object)transform3 == null;
							bool flag21 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
							Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value));
							float? volume = default(float?);
							float rate = default(float);
							float detune = default(float);
							bool loop = default(bool);
							PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_VentOpen, 0f, 10, 0f, volume, rate, detune, loop, 1f);
							Action<Pickup> onRewardGiven = delegate(Pickup pickup)
							{
								//IL_01d9: Expected I, but got O
								//IL_02a9: Expected I, but got O
								//IL_02b1: Expected I, but got O
								//IL_02c1: Expected O, but got I
								//IL_0341: Expected O, but got I4
								//IL_0b40: Expected I, but got O
								//IL_02fd: Expected O, but got I
								//IL_0354: Expected I, but got O
								//IL_0333: Expected O, but got I4
								//IL_0249: Expected I, but got O
								//IL_0282: Unknown result type (might be due to invalid IL or missing references)
								//IL_0287: Expected O, but got Unknown
								//IL_06ac: Expected I, but got O
								//IL_06b4: Expected I, but got O
								//IL_06c4: Expected O, but got I
								//IL_0744: Expected O, but got I4
								//IL_0bcc: Expected I, but got O
								//IL_0700: Expected O, but got I
								//IL_075f: Expected I, but got O
								//IL_0736: Expected O, but got I4
								//IL_083f: Expected I, but got O
								//IL_091a: Expected I, but got O
								//IL_059a: Expected I, but got O
								//IL_0624: Expected I, but got O
								//IL_0c75: Expected O, but got I4
								//IL_0cee: Expected O, but got I4
								//IL_0c8f->IL0a7a: Incompatible stack heights: 1 vs 0
								//IL_0a27->IL0a7a: Incompatible stack heights: 1 vs 0
								//IL_0a62->IL0a7a: Incompatible stack heights: 2 vs 0
								_003C_003Ec__DisplayClass22_1 CS_0024_003C_003E8__locals128 = new _003C_003Ec__DisplayClass22_1();
								if (CS_0024_003C_003E8__locals128 != null)
								{
									CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals79;
									CS_0024_003C_003E8__locals128.pickup = pickup;
									Pickup pickup2 = CS_0024_003C_003E8__locals128.pickup;
									if ((object)CS_0024_003C_003E8__locals128.pickup == null || ((UnityEngine.Object)pickup2).m_CachedPtr == (IntPtr)0)
									{
										goto IL_0136;
									}
									if ((object)CS_0024_003C_003E8__locals128.pickup != null)
									{
										ArcadeSprite arcadeSprite2 = CS_0024_003C_003E8__locals128.pickup.setVisible(visible: false);
										Pickup pickup3 = CS_0024_003C_003E8__locals128.pickup;
										if ((object)CS_0024_003C_003E8__locals128.pickup != null)
										{
											BaseBody baseBody = pickup3.body;
											if (pickup3.body != null)
											{
												baseBody._enable = false;
												if ((object)CS_0024_003C_003E8__locals128.pickup != null)
												{
													CS_0024_003C_003E8__locals128.pickup.enabled = false;
													goto IL_0136;
												}
											}
										}
									}
								}
								goto IL_0a7a;
								IL_086d:
								object[] array = new object[1];
								VentUsageSlot usageSlot10 = CS_0024_003C_003E8__locals79.usageSlot;
								if (CS_0024_003C_003E8__locals79.usageSlot != null && (object)usageSlot10._dummySprite != null)
								{
									Transform transform5 = usageSlot10._dummySprite.transform;
									if (array != null)
									{
										if ((object)transform5 != null)
										{
											nint num8 = (nint)array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj5 = default(object);
											if (obj5 == null)
											{
												ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
												throw ex;
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										CS_0024_003C_003E8__locals128.tweenTargets = array;
										goto IL_095e;
									}
								}
								goto IL_0a7a;
								IL_095e:
								VentUsageSlot usageSlot11 = CS_0024_003C_003E8__locals79.usageSlot;
								TweenConfig tweenConfig = new TweenConfig();
								if (tweenConfig != null)
								{
									tweenConfig.targets = CS_0024_003C_003E8__locals128.tweenTargets;
									if ((object)CS_0024_003C_003E8__locals79._003C_003E4__this != null)
									{
										Transform transform6 = CS_0024_003C_003E8__locals79._003C_003E4__this.transform;
										if ((object)transform6 != null)
										{
											bool flag23 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
											Transform.get_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out Vector3 ret);
											tweenConfig.x = (float?)(object)1;
											if ((object)CS_0024_003C_003E8__locals79._003C_003E4__this != null)
											{
												Transform transform7 = CS_0024_003C_003E8__locals79._003C_003E4__this.transform;
												if ((object)transform7 != null)
												{
													bool flag24 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
													Transform.get_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, out ret);
													tweenConfig.duration = 400f;
													tweenConfig.ease = Ease.InOutCubic;
													tweenConfig.y = (float?)(object)1;
													TweenCallback onComplete = delegate
													{
														//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
														//IL_06a6: Expected O, but got Unknown
														//IL_06d2: Expected F4, but got I
														//IL_04a9: Expected I, but got O
														//IL_076c: Unknown result type (might be due to invalid IL or missing references)
														//IL_0771: Expected O, but got Unknown
														//IL_0945: Unknown result type (might be due to invalid IL or missing references)
														//IL_094a: Expected O, but got Unknown
														//IL_0547: Unknown result type (might be due to invalid IL or missing references)
														//IL_054c: Expected O, but got Unknown
														//IL_07df: Unknown result type (might be due to invalid IL or missing references)
														//IL_07e4: Expected O, but got Unknown
														//IL_0870: Unknown result type (might be due to invalid IL or missing references)
														//IL_0875: Expected O, but got Unknown
														//IL_089a: Invalid comparison between F4 and I
														//IL_08e5: Unknown result type (might be due to invalid IL or missing references)
														//IL_08ea: Expected O, but got Unknown
														//IL_090c: Expected F4, but got I
														//IL_06ec->IL063e: Incompatible stack heights: 1 vs 0
														//IL_00b9->IL063e: Incompatible stack heights: 1 vs 0
														//IL_00db->IL063e: Incompatible stack heights: 1 vs 0
														//IL_0737->IL063e: Incompatible stack heights: 1 vs 0
														//IL_03f5->IL063e: Incompatible stack heights: 1 vs 0
														//IL_0417->IL063e: Incompatible stack heights: 1 vs 0
														//IL_014c->IL063e: Incompatible stack heights: 1 vs 0
														//IL_045c->IL063e: Incompatible stack heights: 1 vs 0
														//IL_017b->IL063e: Incompatible stack heights: 1 vs 0
														//IL_019d->IL063e: Incompatible stack heights: 1 vs 0
														//IL_0495->IL063e: Incompatible stack heights: 1 vs 0
														//IL_01cc->IL063e: Incompatible stack heights: 1 vs 0
														//IL_04d2->IL063e: Incompatible stack heights: 1 vs 0
														//IL_04f4->IL063e: Incompatible stack heights: 1 vs 0
														//IL_07aa->IL0713: Incompatible stack heights: 2 vs 1
														//IL_0523->IL063e: Incompatible stack heights: 1 vs 0
														//IL_01ff->IL063e: Incompatible stack heights: 2 vs 0
														//IL_022e->IL063e: Incompatible stack heights: 2 vs 0
														//IL_0980->IL063e: Incompatible stack heights: 2 vs 0
														//IL_0250->IL063e: Incompatible stack heights: 2 vs 0
														//IL_027f->IL063e: Incompatible stack heights: 2 vs 0
														//IL_0626->IL063e: Incompatible stack heights: 2 vs 0
														//IL_0835->IL063e: Incompatible stack heights: 3 vs 0
														//IL_02b8->IL063e: Incompatible stack heights: 3 vs 0
														//IL_02da->IL063e: Incompatible stack heights: 3 vs 0
														//IL_0309->IL063e: Incompatible stack heights: 3 vs 0
														//IL_08ad->IL0713: Incompatible stack heights: 4 vs 1
														//IL_033c->IL063e: Incompatible stack heights: 4 vs 0
														//IL_036b->IL063e: Incompatible stack heights: 4 vs 0
														//IL_038d->IL063e: Incompatible stack heights: 4 vs 0
														//IL_03bc->IL063e: Incompatible stack heights: 4 vs 0
														//IL_0912->IL0713: Incompatible stack heights: 5 vs 1
														_003C_003Ec__DisplayClass22_0 obj16 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
														object obj18 = default(object);
														if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
														{
															VentUsageSlot usageSlot14 = obj16.usageSlot;
															if (obj16.usageSlot != null && (object)usageSlot14._dummySprite != null)
															{
																Transform transform10 = usageSlot14._dummySprite.transform;
																if ((object)transform10 != null)
																{
																	_ = 0;
																	_ = 0;
																	bool flag28 = ((UnityEngine.Object)transform10).m_CachedPtr == (IntPtr)0;
																	object obj17 = obj18 - 72;
																	Transform.get_localScale_Injected(((UnityEngine.Object)transform10).m_CachedPtr, out *(Vector3*)obj17);
																	_003C_003Ec__DisplayClass22_0 obj19 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																	float num18 = 0f;
																	if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
																	{
																		VentUsageSlot usageSlot15 = obj19.usageSlot;
																		if (obj19.usageSlot != null && (object)usageSlot15._dummySprite != null)
																		{
																			Sprite sprite2 = usageSlot15._dummySprite.sprite;
																			if ((object)sprite2 == null || ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0)
																			{
																				goto IL_0713;
																			}
																			_003C_003Ec__DisplayClass22_0 obj20 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																			if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
																			{
																				VentUsageSlot usageSlot16 = obj20.usageSlot;
																				if (obj20.usageSlot != null && (object)usageSlot16._dummySprite != null)
																				{
																					Sprite sprite3 = usageSlot16._dummySprite.sprite;
																					if ((object)sprite3 != null)
																					{
																						_ = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v93 (UnityEngine.Sprite)+10]");
																						bool flag29 = (nint)0 == 0;
																						object obj21 = obj18 - 72;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v93 (UnityEngine.Sprite)+10]");
																						Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj21);
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
																						if ((nint)0 <= (nint)0)
																						{
																							goto IL_0713;
																						}
																						_003C_003Ec__DisplayClass22_0 obj22 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																						if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
																						{
																							VentUsageSlot usageSlot17 = obj22.usageSlot;
																							if (obj22.usageSlot != null && (object)usageSlot17._dummySprite != null)
																							{
																								Sprite sprite4 = usageSlot17._dummySprite.sprite;
																								if ((object)sprite4 != null)
																								{
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v99 (UnityEngine.Sprite)+10]");
																									bool flag30 = (nint)0 == 0;
																									object obj23 = obj18 - 72;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v99 (UnityEngine.Sprite)+10]");
																									Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj23);
																									_003C_003Ec__DisplayClass22_0 obj24 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																									float num19 = 32f;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
																									num18 = num19 / 0f;
																									if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
																									{
																										VentUsageSlot usageSlot18 = obj24.usageSlot;
																										if (obj24.usageSlot != null && (object)usageSlot18._dummySprite != null)
																										{
																											Transform transform11 = usageSlot18._dummySprite.transform;
																											if ((object)transform11 != null)
																											{
																												_ = 0;
																												_ = 0;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v106 (UnityEngine.Transform)+10]");
																												bool flag31 = (nint)0 == 0;
																												object obj25 = obj18 - 72;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v106 (UnityEngine.Transform)+10]");
																												Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)obj25);
																												float num20 = num18;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																												if (!(num20 > 0f))
																												{
																													goto IL_0713;
																												}
																												_003C_003Ec__DisplayClass22_0 obj26 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																												if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
																												{
																													VentUsageSlot usageSlot19 = obj26.usageSlot;
																													if (obj26.usageSlot != null && (object)usageSlot19._dummySprite != null)
																													{
																														Transform transform12 = usageSlot19._dummySprite.transform;
																														if ((object)transform12 != null)
																														{
																															_ = 0;
																															_ = 0;
																															bool flag32 = ((UnityEngine.Object)transform12).m_CachedPtr == (IntPtr)0;
																															object obj27 = obj18 - 72;
																															Transform.get_localScale_Injected(((UnityEngine.Object)transform12).m_CachedPtr, out *(Vector3*)obj27);
																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																															num18 = 0f;
																															goto IL_0713;
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
														goto IL_063e;
														IL_063e:
														throw new NullReferenceException();
														IL_0713:
														_003C_003Ec__DisplayClass22_0 obj28 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
														if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
														{
															VentUsageSlot usageSlot20 = obj28.usageSlot;
															if (obj28.usageSlot != null && (object)obj28._003C_003E4__this != null)
															{
																obj28._003C_003E4__this.UpdateClipping(usageSlot20._dummySprite);
																_003C_003Ec__DisplayClass22_0 obj29 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
																{
																	VentUsageSlot usageSlot21 = obj29.usageSlot;
																	TweenConfig tweenConfig2 = new TweenConfig();
																	if (tweenConfig2 != null)
																	{
																		((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)CS_0024_003C_003E8__locals128.tweenTargets;
																		_003C_003Ec__DisplayClass22_0 obj30 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																		if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null && (object)obj30._003C_003E4__this != null)
																		{
																			Transform transform13 = obj30._003C_003E4__this.transform;
																			if ((object)transform13 != null)
																			{
																				_ = 0;
																				_ = 0;
																				bool flag33 = ((UnityEngine.Object)transform13).m_CachedPtr == (IntPtr)0;
																				object obj31 = obj18 - 72;
																				Transform.get_position_Injected(((UnityEngine.Object)transform13).m_CachedPtr, out *(Vector3*)obj31);
																				_003C_003Ec__DisplayClass22_0 obj32 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																				if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-44]");
																					object obj33 = 0 - obj32.dropRange;
																					_ = 0;
																					_ = 1;
																					_ = 1137180672;
																					_ = 10;
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+18]");
																					_ = 0;
																					_ = 1;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+18]");
																					_ = 0;
																					TweenCallback tweenCallback = CS_0024_003C_003E8__locals128._003C_003E9__2;
																					if (CS_0024_003C_003E8__locals128._003C_003E9__2 == null)
																					{
																						tweenCallback = (CS_0024_003C_003E8__locals128._003C_003E9__2 = delegate
																						{
																							//IL_04ae: Expected O, but got I4
																							//IL_04b7: Expected O, but got I4
																							//IL_04e7: Expected I, but got O
																							//IL_0522: Expected I, but got O
																							//IL_0532: Expected O, but got I
																							//IL_056a: Expected O, but got I
																							//IL_05a3: Expected O, but got I
																							//IL_05db: Expected O, but got I
																							//IL_08ac: Unknown result type (might be due to invalid IL or missing references)
																							//IL_08b1: Expected O, but got Unknown
																							//IL_00cc->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_06b0->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_00fb->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_06d2->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_0180->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_07cc->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_01a7->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_01c5->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_07f3->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_01f9->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_0217->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_081a->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_024b->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_0292->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_0841->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_02c6->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_02e4->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_0868->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_0318->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_036a->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_038c->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_03c7->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_03e9->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_0424->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_0446->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_0477->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_04a0->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_0632->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_0661->IL06f3: Incompatible stack heights: 1 vs 0
																							//IL_08be->IL08d8: Incompatible stack heights: 8 vs 1
																							_003C_003Ec__DisplayClass22_0 obj34 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																							VentProjectile ventProjectile;
																							VentUsageSlot usageSlot23;
																							object[] tweenTargets;
																							ArcadeSprite phaserObject;
																							if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
																							{
																								VentUsageSlot usageSlot22 = obj34.usageSlot;
																								if (obj34.usageSlot != null && (object)usageSlot22._dummySprite != null)
																								{
																									Transform transform14 = usageSlot22._dummySprite.transform;
																									bool flag34 = ((UnityEngine.Object)transform14).m_CachedPtr == (IntPtr)0;
																									Vector3 value3 = default(Vector3);
																									Transform.set_localScale_Injected(((UnityEngine.Object)transform14).m_CachedPtr, ref value3);
																									Transform pickup6 = (Transform)(object)CS_0024_003C_003E8__locals128.pickup;
																									if ((object)CS_0024_003C_003E8__locals128.pickup != null && ((UnityEngine.Object)pickup6).m_CachedPtr != (IntPtr)0)
																									{
																										_003C_003Ec__DisplayClass22_0 obj35 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																										if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
																										{
																											ventProjectile = obj35._003C_003E4__this;
																											if ((object)obj35._003C_003E4__this != null)
																											{
																												usageSlot23 = obj35.usageSlot;
																												tweenTargets = CS_0024_003C_003E8__locals128.tweenTargets;
																												phaserObject = CS_0024_003C_003E8__locals128.pickup;
																												goto IL_08be;
																											}
																										}
																									}
																									else
																									{
																										Transform character5 = (Transform)(object)CS_0024_003C_003E8__locals128.character;
																										if ((object)CS_0024_003C_003E8__locals128.character != null && ((UnityEngine.Object)character5).m_CachedPtr != (IntPtr)0)
																										{
																											if ((object)GM.Core != null)
																											{
																												PhaserScene s_scene = ArcadePhysics.s_scene;
																												if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
																												{
																													PhaserScene s_scene2 = ArcadePhysics.s_scene;
																													if (ArcadePhysics.s_scene != null)
																													{
																														PhaserScene.Renderer renderer = s_scene2._renderer;
																														if (s_scene2._renderer != null && (object)GM.Core != null)
																														{
																															PhaserScene s_scene3 = ArcadePhysics.s_scene;
																															if (ArcadePhysics.s_scene != null)
																															{
																																PhaserScene.Renderer renderer2 = s_scene3._renderer;
																																if (s_scene3._renderer != null)
																																{
																																	float minInclusive = renderer.width ^ -0f;
																																	float num21 = UnityEngine.Random.Range(minInclusive, renderer2.width);
																																	if ((object)GM.Core != null)
																																	{
																																		PhaserScene s_scene4 = ArcadePhysics.s_scene;
																																		if (ArcadePhysics.s_scene != null)
																																		{
																																			PhaserScene.Renderer renderer3 = s_scene4._renderer;
																																			if (s_scene4._renderer != null && (object)GM.Core != null)
																																			{
																																				PhaserScene s_scene5 = ArcadePhysics.s_scene;
																																				if (ArcadePhysics.s_scene != null)
																																				{
																																					PhaserScene.Renderer renderer4 = s_scene5._renderer;
																																					if (s_scene5._renderer != null)
																																					{
																																						float minInclusive2 = renderer3.height ^ -0f;
																																						float num22 = UnityEngine.Random.Range(minInclusive2, renderer4.height);
																																						_003C_003Ec__DisplayClass22_0 obj36 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																																						if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null && (object)obj36._003C_003E4__this != null)
																																						{
																																							float2 float6 = default(float2);
																																							obj36._003C_003E4__this.position = float6;
																																							_003C_003Ec__DisplayClass22_0 obj37 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																																							if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null && (object)obj37._003C_003E4__this != null)
																																							{
																																								float2 float7 = obj37._003C_003E4__this.position;
																																								_003C_003Ec__DisplayClass22_0 obj38 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																																								if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null && (object)obj38._003C_003E4__this != null)
																																								{
																																									float2 float8 = obj38._003C_003E4__this.position;
																																									if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
																																									{
																																										object[] tweenTargets2 = CS_0024_003C_003E8__locals128.tweenTargets;
																																										if (CS_0024_003C_003E8__locals128.tweenTargets != null)
																																										{
																																											object obj39 = 0;
																																											object obj40 = 0;
																																											float2 value4 = default(float2);
																																											while ((nint)obj40 < tweenTargets2.Length)
																																											{
																																												bool flag35 = (nint)obj39 >= tweenTargets2.Length;
																																												nint num23 = (nint)typeof(Transform);
																																												object obj41 = tweenTargets2[obj39];
																																												bool flag36 = tweenTargets2[obj39] == null;
																																												nint num24 = (nint)obj41;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																												object obj42 = 0;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+130]");
																																												nint num25 = 0;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																												bool flag37 = num25 < 0;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+C8]");
																																												object obj43 = 0;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ rax_v78+FFFFFFF8+v1157 @ rax_v77*8]");
																																												bool flag38 = 0 != (nint)typeof(Transform);
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																												object obj44 = 0;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+130]");
																																												nint num26 = 0;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v27 (Il2CppClass<UnityEngine.Transform>)+130]");
																																												bool flag39 = num26 < 0;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ r8_v22 (Il2CppClass<System.Object>)+C8]");
																																												object obj45 = 0;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1065 @ rax_v80+FFFFFFF8+v1064 @ rax_v79*8]");
																																												bool flag40 = 0 != (nint)typeof(Transform);
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rbx_v16 (System.Object)+10]");
																																												bool flag41 = (nint)0 == 0;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rbx_v16 (System.Object)+10]");
																																												Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value4));
																																												obj39++;
																																												obj40 = obj39;
																																											}
																																											_003C_003Ec__DisplayClass22_0 obj46 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																																											if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null)
																																											{
																																												ventProjectile = obj46._003C_003E4__this;
																																												if ((object)obj46._003C_003E4__this != null)
																																												{
																																													usageSlot23 = obj46.usageSlot;
																																													tweenTargets = CS_0024_003C_003E8__locals128.tweenTargets;
																																													phaserObject = CS_0024_003C_003E8__locals128.character;
																																													goto IL_08be;
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
																										else
																										{
																											_003C_003Ec__DisplayClass22_0 obj47 = CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1;
																											if (CS_0024_003C_003E8__locals128.CS_0024_003C_003E8__locals1 != null && (object)obj47._003C_003E4__this != null)
																											{
																												obj47._003C_003E4__this.UseFinished(obj47.usageSlot);
																												return;
																											}
																										}
																									}
																								}
																							}
																							throw new NullReferenceException();
																							IL_08be:
																							ventProjectile.ReturnFromVent(phaserObject, tweenTargets, usageSlot23);
																						});
																					}
																					MultiTargetTween currentTween2 = Tweens.Add(tweenConfig2);
																					if (obj29.usageSlot != null)
																					{
																						usageSlot21._currentTween = currentTween2;
																						return;
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
														goto IL_063e;
													};
													tweenConfig.onComplete = onComplete;
													MultiTargetTween currentTween = Tweens.Add(tweenConfig);
													if (CS_0024_003C_003E8__locals79.usageSlot != null)
													{
														usageSlot11._currentTween = currentTween;
														return;
													}
												}
											}
										}
									}
								}
								goto IL_0a7a;
								IL_0a7a:
								throw new NullReferenceException();
								IL_0b23:
								object obj6;
								bool flag25 = obj6 == null;
								nint num9 = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
								VampireSurvivors.Objects.Characters.CharacterController character = null;
								if (!flag25)
								{
									num9 = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
									character = (VampireSurvivors.Objects.Characters.CharacterController)CS_0024_003C_003E8__locals79.other;
								}
								goto IL_0b11;
								IL_0be4:
								Pickup pickup4;
								if ((object)pickup4 != null && ((UnityEngine.Object)pickup4).m_CachedPtr != (IntPtr)0)
								{
									string textureName = pickup4._textureName;
									_ = 1;
									if (pickup4._textureName != null && textureName._stringLength != 0)
									{
										if (pickup4._textureName == null)
										{
											goto IL_0a7a;
										}
										if (!((CoherenceSync)(object)pickup4._textureName).HasStateAuthority)
										{
											goto IL_086d;
										}
									}
								}
								num9 = (nint)CS_0024_003C_003E8__locals79.other;
								if (CS_0024_003C_003E8__locals79.other != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
									goto IL_086d;
								}
								goto IL_0a7a;
								IL_0b11:
								CS_0024_003C_003E8__locals128.character = character;
								Pickup character2 = (Pickup)(object)CS_0024_003C_003E8__locals128.character;
								if ((object)CS_0024_003C_003E8__locals128.character != null && ((UnityEngine.Object)character2).m_CachedPtr != (IntPtr)0)
								{
									if ((object)CS_0024_003C_003E8__locals128.character != null)
									{
										ArcadeSprite arcadeSprite3 = CS_0024_003C_003E8__locals128.character.setVisible(visible: false);
										VampireSurvivors.Objects.Characters.CharacterController character3 = CS_0024_003C_003E8__locals128.character;
										if ((object)CS_0024_003C_003E8__locals128.character != null && (object)character3._spriteTrail != null)
										{
											SpriteTrail spriteTrail = character3._spriteTrail.setVisible(b: false);
											VampireSurvivors.Objects.Characters.CharacterController character4 = CS_0024_003C_003E8__locals128.character;
											if ((object)CS_0024_003C_003E8__locals128.character != null)
											{
												BaseBody baseBody2 = character4.body;
												if (character4.body != null)
												{
													baseBody2._enable = false;
													if ((object)CS_0024_003C_003E8__locals128.character != null)
													{
														CS_0024_003C_003E8__locals128.character.enabled = false;
														object[] array2 = new object[2];
														VentUsageSlot usageSlot12 = CS_0024_003C_003E8__locals79.usageSlot;
														if (CS_0024_003C_003E8__locals79.usageSlot != null && (object)usageSlot12._dummySprite != null)
														{
															Transform transform8 = usageSlot12._dummySprite.transform;
															if (array2 != null)
															{
																if ((object)transform8 != null)
																{
																	nint num10 = (nint)array2;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj7 = default(object);
																	if (obj7 == null)
																	{
																		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
																		throw ex2;
																	}
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if ((object)CS_0024_003C_003E8__locals128.character != null)
																{
																	Transform transform9 = CS_0024_003C_003E8__locals128.character.transform;
																	if ((object)transform9 != null)
																	{
																		nint num11 = (nint)array2;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																		object obj8 = default(object);
																		if (obj8 == null)
																		{
																			ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
																			throw ex3;
																		}
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	CS_0024_003C_003E8__locals128.tweenTargets = array2;
																	goto IL_095e;
																}
															}
														}
													}
												}
											}
										}
									}
									goto IL_0a7a;
								}
								Pickup other3 = (Pickup)CS_0024_003C_003E8__locals79.other;
								nint num13;
								object obj11;
								if (CS_0024_003C_003E8__locals79.other != null)
								{
									nint num12 = (nint)typeof(EnemyController);
									num13 = (nint)other3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1490 @ r8_v42 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
									object obj9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1491 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
									nint num14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1490 @ r8_v42 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
									if (num14 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1491 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
										object obj10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1546 @ rax_v122+FFFFFFF8+v1492 @ rax_v118*8]");
										if (0 == (nint)typeof(EnemyController))
										{
											obj11 = 1;
											goto IL_0ba7;
										}
									}
									obj11 = 0;
									goto IL_0ba7;
								}
								pickup4 = null;
								goto IL_0be4;
								IL_0ae5:
								IDamageable other4 = CS_0024_003C_003E8__locals79.other;
								if (CS_0024_003C_003E8__locals79.other == null)
								{
									character = null;
									goto IL_0b11;
								}
								nint num15 = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
								nint num16 = (nint)other4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1037 @ r8_v56 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
								object obj12 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r9_v10 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+130]");
								nint num17 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1037 @ r8_v56 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
								if (num17 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r9_v10 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+C8]");
									object obj13 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1135 @ rax_v157+FFFFFFF8+v1039 @ rax_v152*8]");
									if (0 == (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController))
									{
										obj6 = 1;
										goto IL_0b23;
									}
								}
								obj6 = 0;
								goto IL_0b23;
								IL_0136:
								VentUsageSlot usageSlot13 = CS_0024_003C_003E8__locals79.usageSlot;
								if (CS_0024_003C_003E8__locals79.usageSlot != null && (object)usageSlot13._dummySprite != null)
								{
									usageSlot13._dummySprite.enabled = true;
									if (CS_0024_003C_003E8__locals79.other != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496460");
										object obj14 = default(object);
										bool flag26 = (nint)obj14 <= 0;
										num9 = (nint)CS_0024_003C_003E8__locals79.other;
										if (flag26)
										{
											goto IL_0ae5;
										}
										Pickup pickup5 = (Pickup)(object)CS_0024_003C_003E8__locals79._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals79._003C_003E4__this != null)
										{
											Pickup playerOptions = (Pickup)(object)pickup5._playerOptions;
											if (pickup5._playerOptions != null)
											{
												num9 = (nint)CS_0024_003C_003E8__locals79.other;
												if (CS_0024_003C_003E8__locals79.other != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180496460");
													object obj15 = obj14;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rbx_v25 (VampireSurvivors.Objects.Pickups.Pickup)+134]");
													obj14 = obj15 + 0;
													goto IL_0ae5;
												}
											}
										}
									}
								}
								goto IL_0a7a;
								IL_0ba7:
								bool flag27 = obj11 == null;
								num16 = num13;
								num9 = (nint)typeof(EnemyController);
								pickup4 = null;
								if (!flag27)
								{
									num16 = num13;
									num9 = (nint)typeof(EnemyController);
									pickup4 = (Pickup)CS_0024_003C_003E8__locals79.other;
								}
								goto IL_0be4;
							};
							bool flag22 = CS_0024_003C_003E8__locals79.other == null;
							CS_0024_003C_003E8__locals79.other.GiveReward(onRewardGiven);
							return;
						}
					}
				}
			}
		}
		goto IL_0845;
	}

	private void UpdateClipping(SpriteRenderer dummySprite, float offset = 0f)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4DE2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Material material = ((Renderer)dummySprite).GetMaterial();
		Bounds bounds = _ventSprite.Bounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v5 (UnityEngine.Bounds)+10]");
		object obj2 = default(object);
		object obj = obj2 - 0;
		int num = Shader.PropertyToID("_WorldClipY");
		float num2 = (float)obj + 0.04f;
		float value = num2 + offset;
		material.SetFloatImpl(num, value);
	}

	private unsafe void ReturnFromVent(ArcadeSprite phaserObject, object[] tweenTargets, VentUsageSlot slot)
	{
		//IL_00b6: Expected O, but got I
		//IL_013a: Expected O, but got I
		//IL_017a: Expected O, but got I
		//IL_039d: Expected I, but got O
		//IL_047e: Expected I, but got O
		//IL_0449->IL031c: Incompatible stack heights: 6 vs 0
		//IL_0290->IL031c: Incompatible stack heights: 6 vs 0
		//IL_02c6->IL031c: Incompatible stack heights: 6 vs 0
		//IL_0304->IL031c: Incompatible stack heights: 7 vs 0
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals55 = new _003C_003Ec__DisplayClass24_0();
		if (CS_0024_003C_003E8__locals55 != null)
		{
			CS_0024_003C_003E8__locals55._003C_003E4__this = this;
			CS_0024_003C_003E8__locals55.slot = slot;
			CS_0024_003C_003E8__locals55.tweenTargets = tweenTargets;
			CS_0024_003C_003E8__locals55.phaserObject = phaserObject;
			VentUsageSlot slot2 = CS_0024_003C_003E8__locals55.slot;
			if (CS_0024_003C_003E8__locals55.slot != null)
			{
				VentUsageSlot phaserObject2 = (VentUsageSlot)(object)CS_0024_003C_003E8__locals55.phaserObject;
				if ((object)CS_0024_003C_003E8__locals55.phaserObject != null)
				{
					CS_0024_003C_003E8__locals55.phaserObject.CheckRenderer();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v10 (VampireSurvivors.Objects.Projectiles.VentProjectile+VentUsageSlot)+48]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v10 (VampireSurvivors.Objects.Projectiles.VentProjectile+VentUsageSlot)+48]");
						Sprite sprite = ((SpriteRenderer)0).sprite;
						if ((object)slot2._dummySprite != null)
						{
							slot2._dummySprite.sprite = sprite;
							object[] slot3 = (object[])(object)CS_0024_003C_003E8__locals55.slot;
							if (CS_0024_003C_003E8__locals55.slot != null)
							{
								VentUsageSlot phaserObject3 = (VentUsageSlot)(object)CS_0024_003C_003E8__locals55.phaserObject;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rsi_v11 (System.Object[])+10]");
								object[] array = (object[])0;
								if ((object)CS_0024_003C_003E8__locals55.phaserObject != null)
								{
									CS_0024_003C_003E8__locals55.phaserObject.CheckRenderer();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v11 (VampireSurvivors.Objects.Projectiles.VentProjectile+VentUsageSlot)+48]");
									VentUsageSlot ventUsageSlot = (VentUsageSlot)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v11 (VampireSurvivors.Objects.Projectiles.VentProjectile+VentUsageSlot)+48]");
									if ((nint)0 != 0)
									{
										bool flag = (object)ventUsageSlot._dummySprite == null;
										SpriteRenderer.get_color_Injected((IntPtr)ventUsageSlot._dummySprite, out Color ret);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rsi_v11 (System.Object[])+10]");
										bool flag2 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rsi_v12 (System.Object[])+10]");
										bool flag3 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rsi_v12 (System.Object[])+10]");
										Color value = default(Color);
										SpriteRenderer.set_color_Injected((IntPtr)0, ref value);
										VentUsageSlot slot4 = CS_0024_003C_003E8__locals55.slot;
										bool flag4 = CS_0024_003C_003E8__locals55.slot == null;
										bool flag5 = (object)slot4._dummySprite == null;
										slot4._dummySprite.flipX = false;
										ArcadeSprite phaserObject4 = CS_0024_003C_003E8__locals55.phaserObject;
										bool flag6 = (object)CS_0024_003C_003E8__locals55.phaserObject == null;
										if (phaserObject4.body != null)
										{
											float2 float5 = CS_0024_003C_003E8__locals55.phaserObject.displaySize;
										}
										VentUsageSlot slot5 = CS_0024_003C_003E8__locals55.slot;
										if (CS_0024_003C_003E8__locals55.slot != null)
										{
											UpdateClipping(slot5._dummySprite);
											VentUsageSlot slot6 = CS_0024_003C_003E8__locals55.slot;
											TweenConfig tweenConfig = new TweenConfig();
											if (tweenConfig != null)
											{
												_ = CS_0024_003C_003E8__locals55.tweenTargets;
												Transform transform = base.transform;
												if ((object)transform != null)
												{
													bool flag7 = (object)((VentUsageSlot)(object)transform)._dummySprite == null;
													Transform.get_position_Injected((IntPtr)((VentUsageSlot)(object)transform)._dummySprite, out *(Vector3*)(&ret));
													_ = 1137180672;
													_ = 10;
													_ = 1;
													TweenCallback tweenCallback = delegate
													{
														//IL_01cd: Expected O, but got I4
														//IL_0147->IL015f: Incompatible stack heights: 1 vs 0
														VentUsageSlot slot7 = CS_0024_003C_003E8__locals55.slot;
														if (CS_0024_003C_003E8__locals55.slot != null && (object)CS_0024_003C_003E8__locals55._003C_003E4__this != null)
														{
															CS_0024_003C_003E8__locals55._003C_003E4__this.UpdateClipping(slot7._dummySprite, -1000f);
															VentUsageSlot slot8 = CS_0024_003C_003E8__locals55.slot;
															TweenConfig tweenConfig2 = new TweenConfig();
															if (tweenConfig2 != null)
															{
																tweenConfig2.targets = CS_0024_003C_003E8__locals55.tweenTargets;
																if ((object)CS_0024_003C_003E8__locals55._003C_003E4__this != null)
																{
																	Transform transform2 = CS_0024_003C_003E8__locals55._003C_003E4__this.transform;
																	if ((object)transform2 != null)
																	{
																		bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																		Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
																		tweenConfig2.y = (float?)(object)1;
																		tweenConfig2.duration = 400f;
																		tweenConfig2.ease = Ease.OutBounce;
																		TweenCallback onComplete = CS_0024_003C_003E8__locals55._003C_003E9__1;
																		if (CS_0024_003C_003E8__locals55._003C_003E9__1 == null)
																		{
																			onComplete = (CS_0024_003C_003E8__locals55._003C_003E9__1 = delegate
																			{
																				//IL_01bd: Expected I, but got O
																				//IL_01c5: Expected I, but got O
																				//IL_01d5: Expected O, but got I
																				//IL_0255: Expected O, but got I4
																				//IL_0211: Expected O, but got I
																				//IL_0247: Expected O, but got I4
																				//IL_02d5: Expected O, but got I
																				//IL_03ed->IL030f: Incompatible stack heights: 7 vs 0
																				//IL_02f8->IL030f: Incompatible stack heights: 7 vs 0
																				//IL_02ba->IL030f: Incompatible stack heights: 7 vs 0
																				object obj3;
																				Transform transform5;
																				if ((object)CS_0024_003C_003E8__locals55.phaserObject != null)
																				{
																					Transform transform3 = CS_0024_003C_003E8__locals55.phaserObject.transform;
																					VentUsageSlot slot9 = CS_0024_003C_003E8__locals55.slot;
																					if (CS_0024_003C_003E8__locals55.slot != null && (object)slot9._dummySprite != null)
																					{
																						Transform transform4 = slot9._dummySprite.transform;
																						if ((object)transform4 != null)
																						{
																							bool flag9 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																							Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out Vector3 _);
																							bool flag10 = (object)transform3 == null;
																							bool flag11 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																							Vector3 value2 = default(Vector3);
																							Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
																							VentUsageSlot slot10 = CS_0024_003C_003E8__locals55.slot;
																							bool flag12 = CS_0024_003C_003E8__locals55.slot == null;
																							bool flag13 = (object)slot10._dummySprite == null;
																							slot10._dummySprite.enabled = false;
																							bool flag14 = (object)CS_0024_003C_003E8__locals55.phaserObject == null;
																							ArcadeSprite arcadeSprite = CS_0024_003C_003E8__locals55.phaserObject.setVisible(visible: true);
																							ArcadeSprite phaserObject5 = CS_0024_003C_003E8__locals55.phaserObject;
																							bool flag15 = (object)CS_0024_003C_003E8__locals55.phaserObject == null;
																							if (phaserObject5.body != null)
																							{
																								BaseBody baseBody = phaserObject5.body;
																								baseBody._enable = true;
																							}
																							if ((object)CS_0024_003C_003E8__locals55.phaserObject != null)
																							{
																								CS_0024_003C_003E8__locals55.phaserObject.enabled = true;
																								ArcadeSprite phaserObject6 = CS_0024_003C_003E8__locals55.phaserObject;
																								if ((object)CS_0024_003C_003E8__locals55.phaserObject != null)
																								{
																									nint num = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
																									nint num2 = (nint)phaserObject6;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
																									object obj = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ r9_v8 (Il2CppClass<ArcadeSprite>)+130]");
																									nint num3 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
																									if (num3 >= 0)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ r9_v8 (Il2CppClass<ArcadeSprite>)+C8]");
																										object obj2 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rax_v50+FFFFFFF8+v567 @ rax_v46*8]");
																										if (0 == (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController))
																										{
																											obj3 = 1;
																											goto IL_03f7;
																										}
																									}
																									obj3 = 0;
																									goto IL_03f7;
																								}
																								transform5 = null;
																								goto IL_041e;
																							}
																						}
																					}
																				}
																				goto IL_030f;
																				IL_030f:
																				throw new NullReferenceException();
																				IL_041e:
																				if ((object)transform5 != null && ((UnityEngine.Object)transform5).m_CachedPtr != (IntPtr)0)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v9 (UnityEngine.Transform)+E0]");
																					if ((nint)0 == 0)
																					{
																						goto IL_030f;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v9 (UnityEngine.Transform)+E0]");
																					SpriteTrail spriteTrail = ((SpriteTrail)0).setVisible(b: true);
																				}
																				if ((object)CS_0024_003C_003E8__locals55._003C_003E4__this != null)
																				{
																					CS_0024_003C_003E8__locals55._003C_003E4__this.UseFinished(CS_0024_003C_003E8__locals55.slot);
																					return;
																				}
																				goto IL_030f;
																				IL_03f7:
																				bool flag16 = obj3 == null;
																				transform5 = null;
																				if (!flag16)
																				{
																					transform5 = (Transform)(object)CS_0024_003C_003E8__locals55.phaserObject;
																				}
																				goto IL_041e;
																			});
																		}
																		tweenConfig2.onComplete = onComplete;
																		MultiTargetTween currentTween2 = Tweens.Add(tweenConfig2);
																		if (CS_0024_003C_003E8__locals55.slot != null)
																		{
																			slot8._currentTween = currentTween2;
																			return;
																		}
																	}
																}
															}
														}
														throw new NullReferenceException();
													};
													MultiTargetTween currentTween = Tweens.Add(tweenConfig);
													if (CS_0024_003C_003E8__locals55.slot != null)
													{
														slot6._currentTween = currentTween;
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
		throw new NullReferenceException();
	}

	private void UseFinished(VentUsageSlot slot)
	{
		int currentlyAnimatingCount = _currentlyAnimatingCount - 1;
		_currentlyAnimatingCount = currentlyAnimatingCount;
		slot._dummySprite.enabled = false;
		slot._currentTween = null;
		bool flag = ((List<object>)(object)_usageSlots).Remove((object)slot);
		bool flag2 = _usageSlots.Remove(slot);
		if (_uses <= 0 && _currentlyAnimatingCount <= 0)
		{
			FadeOut();
		}
	}

	private void FadeOut()
	{
		//IL_004b: Expected F4, but got I4
		//IL_0098: Expected I, but got O
		//IL_010a: Expected O, but got I4
		//IL_0125: Expected I, but got O
		PhaserSprite ventSprite = _ventSprite;
		ventSprite._spriteAnimation.SetAnimation("close");
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_VentOpen, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_ventSprite != null)
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
		tweenConfig.delay = 250f;
		tweenConfig.duration = 100f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.VentProjectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween currentTween = Tweens.Add(tweenConfig);
		_currentTween = currentTween;
	}

	public void AddUses(int uses)
	{
		int uses2 = _uses + uses;
		_uses = uses2;
	}

	public bool IsAnimating()
	{
		//IL_003f: Expected O, but got I4
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_00db: Expected O, but got I
		if (_currentTween == null || !_currentTween.IsAlive())
		{
			bool flag = _currentlyAnimatingCount <= 0;
			object obj = 0;
			if (flag)
			{
				goto IL_0119;
			}
			bool result = default(bool);
			while (true)
			{
				List<VentUsageSlot> usageSlots = _usageSlots;
				if ((nint)obj < usageSlots._size)
				{
					VentUsageSlot[] items = usageSlots._items;
					VentUsageSlot ventUsageSlot = items[obj];
					if (ventUsageSlot._currentTween != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v15+18]");
						if (((MultiTargetTween)0).IsAlive())
						{
							break;
						}
					}
					obj++;
					if ((nint)obj < _currentlyAnimatingCount)
					{
						continue;
					}
					goto IL_0119;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		return true;
		IL_0119:
		return false;
	}

	public override void Despawn()
	{
		//IL_0108: Expected O, but got I
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		if (_currentTween != null)
		{
			_currentTween.Kill();
		}
		_currentTween = null;
		bool flag = _currentlyAnimatingCount <= 0;
		MultiTargetTween multiTargetTween = null;
		if (!flag)
		{
			do
			{
				List<VentUsageSlot> usageSlots = _usageSlots;
				if ((nint)multiTargetTween < usageSlots._size)
				{
					VentUsageSlot[] items = usageSlots._items;
					VentUsageSlot ventUsageSlot = items[(object)multiTargetTween];
					if (ventUsageSlot._currentTween != null)
					{
						ventUsageSlot._currentTween.Kill();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rax_v10+10]");
					((Renderer)0).enabled = false;
					multiTargetTween = (MultiTargetTween)(multiTargetTween + 1);
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			while ((nint)multiTargetTween < _currentlyAnimatingCount);
		}
		_currentlyAnimatingCount = 0;
		PhaserSprite phaserSprite = _ventSprite.setVisible(visible: false);
		base.Despawn();
	}

	public VentProjectile()
	{
		List<VentUsageSlot> usageSlots = new List<VentUsageSlot>();
		_usageSlots = usageSlots;
		base._002Ector();
	}
}
