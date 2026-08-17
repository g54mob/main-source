using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Coherence.Toolkit.Bindings.TransformBindings;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundDevilRoom : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Action> _003C_003E9__39_0;

		public static Action<Action> _003C_003E9__39_1;

		public static Action<Action> _003C_003E9__39_2;

		public static Action<Action> _003C_003E9__39_3;

		public static Action<Action> _003C_003E9__39_4;

		public static Predicate<Pickup> _003C_003E9__43_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CCustomPreload_003Eb__39_0(Action cb)
		{
			//IL_001d: Expected O, but got I4
			AudioLoader.LoadSFXAsync(SfxType.Darkasso_Jingle, "SFX", (DlcType?)(object)0, cb);
		}

		internal void _003CCustomPreload_003Eb__39_1(Action cb)
		{
			//IL_001d: Expected O, but got I4
			AudioLoader.LoadSFXAsync(SfxType.sfx_geiger1, "SFX", (DlcType?)(object)0, cb);
		}

		internal void _003CCustomPreload_003Eb__39_2(Action cb)
		{
			//IL_001d: Expected O, but got I4
			AudioLoader.LoadSFXAsync(SfxType.sfx_geiger2, "SFX", (DlcType?)(object)0, cb);
		}

		internal void _003CCustomPreload_003Eb__39_3(Action cb)
		{
			//IL_001d: Expected O, but got I4
			AudioLoader.LoadSFXAsync(SfxType.sfx_geiger3, "SFX", (DlcType?)(object)0, cb);
		}

		internal void _003CCustomPreload_003Eb__39_4(Action cb)
		{
			//IL_001d: Expected O, but got I4
			AudioLoader.LoadSFXAsync(SfxType.sfx_geiger4, "SFX", (DlcType?)(object)0, cb);
		}

		internal bool _003CSearchForDarkasso_003Eb__43_0(Pickup p)
		{
			//IL_0013: Expected I, but got O
			//IL_001b: Expected I, but got O
			//IL_002b: Expected O, but got I
			//IL_00ab: Expected O, but got I4
			//IL_0067: Expected O, but got I
			//IL_009d: Expected O, but got I4
			//IL_00d3: Expected O, but got I
			if ((object)p == null)
			{
				goto IL_00e7;
			}
			nint num = (nint)typeof(PickupRelic);
			nint num2 = (nint)p;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
			object obj3;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v11+FFFFFFF8+v42 @ rax_v4*8]");
				if (0 == (nint)typeof(PickupRelic))
				{
					obj3 = 1;
					goto IL_010a;
				}
			}
			obj3 = 0;
			goto IL_010a;
			IL_00e7:
			return false;
			IL_010a:
			bool flag = obj3 == null;
			Pickup pickup = null;
			if (!flag)
			{
				pickup = p;
			}
			if ((object)pickup != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v7 (VampireSurvivors.Objects.Pickups.Pickup)+1F0]");
				object obj4 = -75;
				return obj4 == null;
			}
			goto IL_00e7;
		}
	}

	private sealed class _003C_PlayDarkassoCutscene_003Ed__52(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BackgroundDevilRoom _003C_003E4__this;

		private float _003CspiralT_003E5__2;

		private float _003CstartRadius_003E5__3;

		private float _003CstartAngle_003E5__4;

		private float _003CintermediateRadius_003E5__5;

		private float _003CendRadius_003E5__6;

		private float _003CanimationTime_003E5__7;

		private float _003CspinCount_003E5__8;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_002f: Expected I4, but got I8
			//IL_07b3: Expected I4, but got I8
			//IL_07c5: Expected F4, but got I4
			//IL_0047: Expected O, but got I
			//IL_004b: Expected I4, but got O
			//IL_09a3: Expected I4, but got O
			//IL_00ab: Expected I4, but got O
			//IL_09da: Expected I4, but got O
			//IL_0f7b: Expected O, but got F4
			//IL_00d5: Expected I, but got O
			//IL_09f5: Expected I4, but got O
			//IL_0a2b: Expected I, but got O
			//IL_0a86: Expected I, but got O
			//IL_0ae1: Expected I, but got O
			//IL_0f14: Expected I4, but got O
			//IL_016f: Expected O, but got Ref
			//IL_08e2: Expected O, but got I
			//IL_0262: Expected I, but got O
			//IL_02bd: Expected I, but got O
			//IL_1019: Expected I4, but got O
			//IL_0961: Expected O, but got I
			//IL_0323: Expected I4, but got O
			//IL_0bf5: Expected I4, but got O
			//IL_0373: Expected F4, but got I4
			//IL_0398: Expected I4, but got O
			//IL_03de: Expected I4, but got O
			//IL_0f43: Expected I4, but got O
			//IL_0416: Expected I4, but got O
			//IL_047f: Expected O, but got I
			//IL_0488: Expected I4, but got O
			//IL_04f1: Expected O, but got I
			//IL_051d: Expected I4, but got O
			//IL_055e: Expected I4, but got O
			//IL_05bc: Expected I4, but got O
			//IL_0ce2: Expected I4, but got O
			//IL_05fd: Expected I4, but got O
			//IL_0c76: Expected I4, but got O
			//IL_0d1e: Expected I4, but got O
			//IL_0626: Unknown result type (might be due to invalid IL or missing references)
			//IL_062b: Expected O, but got Unknown
			//IL_06bc: Expected I4, but got O
			//IL_11c5: Expected O, but got I
			//IL_11e9: Expected I4, but got O
			//IL_0725: Expected O, but got I
			//IL_0e20: Expected I4, but got O
			//IL_077d: Expected O, but got I
			//IL_0db1: Expected O, but got I
			//IL_0bb7->IL0fda: Incompatible stack heights: 1 vs 0
			//IL_109c->IL0e6c: Incompatible stack heights: 1 vs 0
			//IL_1104->IL0e6c: Incompatible stack heights: 2 vs 0
			//IL_0ceb->IL0e6c: Incompatible stack heights: 7 vs 0
			//IL_0c93->IL0e6c: Incompatible stack heights: 7 vs 0
			//IL_0d27->IL0e6c: Incompatible stack heights: 7 vs 0
			//IL_11b5->IL0e5e: Incompatible stack heights: 7 vs 0
			//IL_0df7->IL0e6c: Incompatible stack heights: 7 vs 0
			//IL_0d61->IL0e6c: Incompatible stack heights: 7 vs 0
			//IL_0e3d->IL0e6c: Incompatible stack heights: 7 vs 0
			BackgroundDevilRoom backgroundDevilRoom = _003C_003E4__this;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator value = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			float num9;
			float num10;
			_003C_PlayDarkassoCutscene_003Ed__52 obj7;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				IntPtr intPtr = default(IntPtr);
				BgmType bgmType = (BgmType)((CoherenceSync)(object)typeof(SoundManager)).GetBakedValueBinding<PositionBinding>((string)(nint)intPtr);
				SoundManager.FadeMusic(bgmType, 0f, 500f);
				bool flag = (object)_003C_003E4__this == null;
				BgmType bgmType2 = bgmType;
				if (!flag)
				{
					bool flag2 = backgroundDevilRoom._helper == null;
					bgmType2 = (BgmType)backgroundDevilRoom._helper;
					if (!flag2)
					{
						backgroundDevilRoom._helper.StopGeigerNoise();
						nint num = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1138 @ rax_v150 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num2 = 0;
						GameManager core = GM.Core;
						bool flag3 = (object)GM.Core == null;
						bgmType2 = (BgmType)num2;
						if (!flag3)
						{
							bool flag4 = core._characters == null;
							bgmType2 = (BgmType)num2;
							if (!flag4)
							{
								value = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
								List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
								List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
								if (enumerator.MoveNext())
								{
									VampireSurvivors.Objects.Characters.CharacterController characterController = null;
									Behaviour behaviour = (Behaviour)(&enumerator);
									throw new NullReferenceException();
								}
								bool flag5 = (object)GM.Core == null;
								bgmType2 = (BgmType)GM.Core;
								if (!flag5)
								{
									GM.Core.SetAllPlayersWeaponsActive(active: false);
									nint num3 = (nint)typeof(GM);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2039 @ rax_v159 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
									nint num4 = 0;
									GameManager core2 = GM.Core;
									bool flag6 = (object)GM.Core == null;
									bgmType2 = (BgmType)num4;
									if (!flag6)
									{
										core2._003CCanInterrupt_003Ek__BackingField = false;
										nint num5 = (nint)typeof(GM);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2041 @ rax_v161 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
										nint num6 = 0;
										GameManager core3 = GM.Core;
										bool flag7 = (object)GM.Core == null;
										bgmType2 = (BgmType)num6;
										if (!flag7)
										{
											core3._003CCanPause_003Ek__BackingField = false;
											bool flag8 = (object)GM.Core == null;
											bgmType2 = (BgmType)GM.Core;
											if (!flag8)
											{
												GM.Core.EraseEnemies();
												float? volume = default(float?);
												float rate = default(float);
												float detune = default(float);
												bool loop = default(bool);
												PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Darkasso_Jingle, 0f, 10, 0f, volume, rate, detune, loop, 1f);
												bool flag9 = (object)backgroundDevilRoom._darkassoPickup == null;
												bgmType2 = (BgmType)backgroundDevilRoom._darkassoPickup;
												if (!flag9)
												{
													ArcadeSprite arcadeSprite = backgroundDevilRoom._darkassoPickup.setVisible(visible: true);
													bool flag10 = (object)backgroundDevilRoom._darkassoPickup == null;
													bgmType2 = (BgmType)backgroundDevilRoom._darkassoPickup;
													if (!flag10)
													{
														GameObject gameObject = backgroundDevilRoom._darkassoPickup.gameObject;
														bool flag11 = backgroundDevilRoom._signalBus == null;
														bgmType2 = (BgmType)backgroundDevilRoom._darkassoPickup;
														if (!flag11)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
															bgmType2 = (BgmType)GM.Core;
															if ((object)GM.Core != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+190]");
																bool flag12 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+190]");
																bgmType2 = BgmType.BGM_Forest;
																if (!flag12)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+190]");
																	((ParticleSystem)0).Clear(withChildren: true);
																	bgmType2 = (BgmType)GM.Core;
																	if ((object)GM.Core != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+198]");
																		bool flag13 = (nint)0 == 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+198]");
																		bgmType2 = BgmType.BGM_Forest;
																		if (!flag13)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+198]");
																			((ParticleSystem)0).Clear(withChildren: true);
																			_003CspiralT_003E5__2 = 0f;
																			bool flag14 = (object)backgroundDevilRoom._darkassoPickup == null;
																			bgmType2 = (BgmType)backgroundDevilRoom._darkassoPickup;
																			if (!flag14)
																			{
																				float2 position = backgroundDevilRoom._darkassoPickup.position;
																				bool flag15 = (object)backgroundDevilRoom._darkassoTargetPlayer == null;
																				bgmType2 = (BgmType)backgroundDevilRoom._darkassoTargetPlayer;
																				if (!flag15)
																				{
																					float2 position2 = backgroundDevilRoom._darkassoTargetPlayer.position;
																					object obj = default(object);
																					float num7 = 1.0653532E+09f - (float)obj;
																					object obj2 = position - position2;
																					bool flag16 = (object)backgroundDevilRoom._darkassoTargetPlayer == null;
																					bgmType2 = (BgmType)backgroundDevilRoom._darkassoTargetPlayer;
																					if (!flag16)
																					{
																						float2 position3 = backgroundDevilRoom._darkassoTargetPlayer.position;
																						bool flag17 = (object)backgroundDevilRoom._darkassoPickup == null;
																						bgmType2 = (BgmType)backgroundDevilRoom._darkassoPickup;
																						if (!flag17)
																						{
																							float2 position4 = backgroundDevilRoom._darkassoPickup.position;
																							object obj3 = 1065353216 - obj;
																							object obj4 = position4 - position3;
																							object obj5 = obj3 * obj3;
																							object obj6 = obj4 * obj4;
																							float num8 = (float)obj6 + (float)obj5;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
																							_003CstartRadius_003E5__3 = num8;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
																							_003CstartAngle_003E5__4 = num7;
																							_003CintermediateRadius_003E5__5 = 5f;
																							_003CanimationTime_003E5__7 = 8f;
																							_003CspinCount_003E5__8 = 3f;
																							bgmType2 = (BgmType)backgroundDevilRoom._darkassoPickup;
																							if ((object)backgroundDevilRoom._darkassoPickup != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+148]");
																								bool flag18 = (nint)0 == 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+148]");
																								bgmType2 = BgmType.BGM_Forest;
																								if (!flag18)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+148]");
																									PositionBinding bakedValueBinding = ((CoherenceSync)0).GetBakedValueBinding<PositionBinding>();
																									bool flag19 = bakedValueBinding == null;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+148]");
																									bgmType2 = BgmType.BGM_Forest;
																									if (!flag19)
																									{
																										_ = 1;
																										num9 = 1f;
																										num10 = num7;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+148]");
																										obj7 = (_003C_PlayDarkassoCutscene_003Ed__52)0;
																										goto IL_0f51;
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
				goto IL_0e6c;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_0e5e;
			}
			_003C_003E1__state = -1;
			num9 = 1f;
			num10 = 0f;
			obj7 = this;
			goto IL_0f51;
			IL_0e5e:
			return false;
			IL_11a5:
			_003C_003E4__this.ResumeEnemyWaves();
			goto IL_0e5e;
			IL_0e6c:
			throw new NullReferenceException();
			IL_0f51:
			if (!(num9 > _003CspiralT_003E5__2))
			{
				bool flag20 = (object)_003C_003E4__this == null;
				BgmType bgmType2 = (BgmType)obj7;
				if (!flag20)
				{
					PickupRelic darkassoPickup = backgroundDevilRoom._darkassoPickup;
					bool flag21 = (object)backgroundDevilRoom._darkassoPickup == null;
					bgmType2 = (BgmType)obj7;
					if (!flag21)
					{
						bgmType2 = (BgmType)darkassoPickup.body;
						if (darkassoPickup.body != null)
						{
							_ = 1;
							nint num11 = (nint)typeof(GM);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1453 @ rax_v35 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
							nint num12 = 0;
							GameManager core4 = GM.Core;
							bool flag22 = (object)GM.Core == null;
							bgmType2 = (BgmType)num12;
							if (!flag22)
							{
								core4._003CCanInterrupt_003Ek__BackingField = true;
								nint num13 = (nint)typeof(GM);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1526 @ rax_v37 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
								nint num14 = 0;
								GameManager core5 = GM.Core;
								bool flag23 = (object)GM.Core == null;
								bgmType2 = (BgmType)num14;
								if (!flag23)
								{
									core5._003CCanPause_003Ek__BackingField = true;
									nint num15 = (nint)typeof(GM);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ rax_v39 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
									nint num16 = 0;
									GameManager core6 = GM.Core;
									bool flag24 = (object)GM.Core == null;
									bgmType2 = (BgmType)num16;
									if (!flag24)
									{
										bool flag25 = core6._characters == null;
										bgmType2 = (BgmType)num16;
										if (!flag25)
										{
											List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
											while (enumerator2.MoveNext())
											{
												VampireSurvivors.Objects.Characters.CharacterController characterController2 = null;
												if (!((VampireSurvivors.Objects.Characters.CharacterController)null).IsDisconnectedFromOnlinePlay)
												{
													((Behaviour)null).enabled = true;
													SpriteAnimation spriteAnimation = characterController2._spriteAnimation;
													bool flag26 = (object)characterController2._spriteAnimation == null;
													((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
												}
											}
											bool flag27 = (object)GM.Core == null;
											bgmType2 = (BgmType)GM.Core;
											if (!flag27)
											{
												GM.Core.SetAllPlayersWeaponsActive(active: true);
												object darkassoPickup2 = backgroundDevilRoom._darkassoPickup;
												bool flag28 = (object)backgroundDevilRoom._darkassoPickup == null;
												bgmType2 = (BgmType)GM.Core;
												if (!flag28)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rdi_v16 (System.Object)+10]");
													bool flag29 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rdi_v16 (System.Object)+10]");
													IntPtr intPtr2 = Component.get_transform_Injected((IntPtr)0);
													Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(intPtr2);
													object darkassoTargetPlayer = backgroundDevilRoom._darkassoTargetPlayer;
													bool flag30 = (object)backgroundDevilRoom._darkassoTargetPlayer == null;
													bgmType2 = (BgmType)(nint)intPtr2;
													if (!flag30)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rdi_v17 (System.Object)+10]");
														bool flag31 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rdi_v17 (System.Object)+10]");
														IntPtr intPtr3 = Component.get_transform_Injected((IntPtr)0);
														Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(intPtr3);
														bool flag32 = (object)transform2 == null;
														bgmType2 = (BgmType)(nint)intPtr3;
														if (!flag32)
														{
															bool flag33 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
															Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
															bool flag34 = (object)transform == null;
															bool flag35 = ((_003C_PlayDarkassoCutscene_003Ed__52)(object)transform)._003C_003E1__state == 0;
															Transform.set_position_Injected((IntPtr)((_003C_PlayDarkassoCutscene_003Ed__52)(object)transform)._003C_003E1__state, ref *(Vector3*)(&value));
															GameManager core7 = GM.Core;
															bool flag36 = (object)GM.Core == null;
															bool flag37 = core7._multiplayer == null;
															if (!core7._multiplayer.IsOnlineMultiplayer)
															{
																bgmType2 = (BgmType)backgroundDevilRoom._darkassoPickup;
																if ((object)backgroundDevilRoom._darkassoPickup != null)
																{
																	int value__ = ((BgmType*)(int)bgmType2)->value__;
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2889 @ rax_v88 (System.Int32)+378] (should have been resolved before IL gen)");
																	goto IL_11a5;
																}
															}
															else
															{
																VampireSurvivors.Objects.Characters.CharacterController darkassoTargetPlayer2 = backgroundDevilRoom._darkassoTargetPlayer;
																bool flag38 = (object)backgroundDevilRoom._darkassoTargetPlayer == null;
																bgmType2 = (BgmType)core7._multiplayer;
																if (!flag38)
																{
																	ArcadeSprite coherenceSync = (ArcadeSprite)(object)darkassoTargetPlayer2._coherenceSync;
																	bool flag39 = (object)darkassoTargetPlayer2._coherenceSync == null;
																	bgmType2 = (BgmType)core7._multiplayer;
																	if (!flag39)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ rdi_v21 (ArcadeSprite)+160]");
																		object obj8 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ rdi_v21 (ArcadeSprite)+160]");
																		bool flag40 = (nint)0 == 0;
																		bgmType2 = (BgmType)core7._multiplayer;
																		if (!flag40)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1166 @ rax_v74+20]");
																			bgmType2 = BgmType.BGM_Forest;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1166 @ rax_v74+20]");
																			if ((nint)0 == 0)
																			{
																				goto IL_0e6c;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+10]");
																			bool flag41 = false;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+10]");
																			if ((nint)0 != 1)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rcx_v100 (VampireSurvivors.Data.BgmType)+10]");
																				object obj9 = -3;
																				bool flag42 = obj9 == null;
																				flag41 = flag42;
																			}
																			if (!flag41)
																			{
																				goto IL_11a5;
																			}
																		}
																		PickupRelic darkassoPickup3 = backgroundDevilRoom._darkassoPickup;
																		if ((object)backgroundDevilRoom._darkassoPickup != null)
																		{
																			darkassoPickup3._targetPlayer = backgroundDevilRoom._darkassoTargetPlayer;
																			bgmType2 = (BgmType)backgroundDevilRoom._darkassoPickup;
																			if ((object)backgroundDevilRoom._darkassoPickup != null)
																			{
																				int value__2 = ((BgmType*)(int)bgmType2)->value__;
																				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3043 @ rax_v78 (System.Int32)+438] (should have been resolved before IL gen)");
																				goto IL_11a5;
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
				object obj10 = Time.unscaledDeltaTime;
				float num17 = num9 / _003CanimationTime_003E5__7;
				float num18 = num17 * num10;
				float num19 = num18 + _003CspiralT_003E5__2;
				_003CspiralT_003E5__2 = num19;
				if ((object)_003C_003E4__this != null && (object)backgroundDevilRoom._darkassoTargetPlayer != null)
				{
					float2 position5 = backgroundDevilRoom._darkassoTargetPlayer.position;
					PositionBinding bakedValueBinding2 = ((CoherenceSync)(object)backgroundDevilRoom._darkassoTargetPlayer).GetBakedValueBinding<PositionBinding>((string)null);
					PositionBinding bakedValueBinding3 = ((CoherenceSync)(object)backgroundDevilRoom._darkassoTargetPlayer).GetBakedValueBinding<PositionBinding>((string)null);
					if ((object)backgroundDevilRoom._darkassoPickup != null)
					{
						float2 float5 = default(float2);
						backgroundDevilRoom._darkassoPickup.position = float5;
						ArcadeSprite darkassoPickup4 = backgroundDevilRoom._darkassoPickup;
						if ((object)backgroundDevilRoom._darkassoPickup != null)
						{
							float2 position6 = backgroundDevilRoom._darkassoPickup.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rdi_v24 (ArcadeSprite)+1E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rdi_v24 (ArcadeSprite)+1E8]");
								PositionBinding bakedValueBinding4 = ((CoherenceSync)0).GetBakedValueBinding<PositionBinding>((string)position6);
								ArcadeSprite darkassoPickup5 = backgroundDevilRoom._darkassoPickup;
								if ((object)backgroundDevilRoom._darkassoPickup != null)
								{
									float2 position7 = backgroundDevilRoom._darkassoPickup.position;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1155 @ rax_v116 (ArcadeSprite)+1E0]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1155 @ rax_v116 (ArcadeSprite)+1E0]");
										PositionBinding bakedValueBinding5 = ((CoherenceSync)0).GetBakedValueBinding<PositionBinding>((string)float5);
										_003C_003E2__current = null;
										_003C_003E1__state = 1;
										return true;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0e6c;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private TileSprite _carpet;

	private TileSprite _Tile_H_Plain;

	private TileSprite _Tile_V_Deco;

	private TileSprite _Tile_V_Deco2;

	private TileSprite _Tile_H_Border;

	private TileSprite _Tile_V_Border;

	private int[] _cachedPlayerCharm;

	private List<int> tresholds;

	private List<EnemyType?> enemies;

	private List<EnemyType?> bosses;

	private List<EnemyType?> _secondPhaseBosses;

	private List<EnemyType?> _secondPhaseEnemies;

	public int currentLevel;

	private List<PhaserSprite> walls;

	private List<Vector2> darkassoLoc;

	private BackgroundDevilRoom_Helper _helper;

	private PickupRelic _darkassoPickup;

	private bool _hasTriggeredDarkassoCutscene;

	private List<Rectangle> _darkassoCutsceneTriggerZones;

	private VampireSurvivors.Objects.Characters.CharacterController _darkassoTargetPlayer;

	private Timer skullsTimer;

	private bool _isSendingAdvanceLevel;

	private List<Vector2> _003CWallEyesLocations_003Ek__BackingField;

	private List<Vector2> _003CLeftEyesLocations_003Ek__BackingField;

	private List<Vector2> _003CRightEyesLocations_003Ek__BackingField;

	private int _lastEnemies;

	private float _lastSeconds;

	public Camera MainCamera => _mainCamera;

	public unsafe Bounds CamBounds
	{
		get
		{
			//IL_000a: Expected native int or pointer, but got O
			Bounds bounds = default(Bounds);
			((Bounds*)(nint)bounds)->m_Center = (Vector3)_camBounds;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Objects.Stages.BackgroundDevilRoom)+40]");
			_ = 0;
			return bounds;
		}
	}

	public List<Vector2> WallEyesLocations
	{
		get
		{
			return _003CWallEyesLocations_003Ek__BackingField;
		}
		set
		{
			_003CWallEyesLocations_003Ek__BackingField = value;
		}
	}

	public List<Vector2> LeftEyesLocations
	{
		get
		{
			return _003CLeftEyesLocations_003Ek__BackingField;
		}
		set
		{
			_003CLeftEyesLocations_003Ek__BackingField = value;
		}
	}

	public List<Vector2> RightEyesLocations
	{
		get
		{
			return _003CRightEyesLocations_003Ek__BackingField;
		}
		set
		{
			_003CRightEyesLocations_003Ek__BackingField = value;
		}
	}

	public unsafe override void Create()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00d7: Expected I4, but got I8
		//IL_014b: Expected I4, but got I8
		//IL_01bf: Expected I4, but got I8
		//IL_0233: Expected I4, but got I8
		//IL_02a7: Expected I4, but got I8
		//IL_031b: Expected I4, but got I8
		//IL_0508: Expected F4, but got I4
		//IL_057b: Expected F4, but got I
		//IL_0594: Expected O, but got Ref
		//IL_0659: Expected F4, but got I
		//IL_066c: Expected O, but got Ref
		//IL_0737: Expected F4, but got I
		//IL_074a: Expected O, but got Ref
		//IL_0815: Expected F4, but got I
		//IL_0828: Expected O, but got Ref
		//IL_08f3: Expected F4, but got I
		//IL_0906: Expected O, but got Ref
		//IL_09d1: Expected F4, but got I
		//IL_09e4: Expected O, but got Ref
		//IL_0bd4: Expected O, but got I
		//IL_0bea: Expected I4, but got I8
		//IL_0d8a: Expected O, but got I
		//IL_0e98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9d: Expected O, but got Unknown
		//IL_0f88: Expected O, but got I4
		//IL_18aa: Expected O, but got I4
		//IL_0fea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fef: Expected O, but got Unknown
		//IL_0fd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdb: Expected O, but got Unknown
		//IL_14a1: Expected O, but got I4
		//IL_14aa: Expected O, but got I4
		//IL_160b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1610: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Create();
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			Action<Pickup> b = OnRemoteItemInstantiated;
			Delegate obj3 = Delegate.Combine(ItemInstantiator.OnRemoteItemInstantiated, b);
			if ((object)obj3 == null)
			{
				ItemInstantiator.OnRemoteItemInstantiated = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<Pickup> action = default(Action<Pickup>);
				if (action == null)
				{
					throw new InvalidCastException();
				}
				ItemInstantiator.OnRemoteItemInstantiated = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					throw new InvalidCastException();
				}
			}
		}
		base._003CHasMovingBg_003Ek__BackingField = true;
		float height = default(float);
		string textureName = default(string);
		string spriteName = default(string);
		TileSprite tileSprite = RenderingExtensions.AddTileSprite(this, 0f, 0f, 5.12f, height, textureName, spriteName);
		TileSprite tileSprite2 = tileSprite.SetDepth(-3000);
		GameObject gameObject = tileSprite2.gameObject;
		((UnityEngine.Object)gameObject).SetName("Tile_Carpet");
		_carpet = tileSprite2;
		TileSprite tileSprite3 = RenderingExtensions.AddTileSprite(this, 0f, 0f, 0.64f, height, textureName, spriteName);
		TileSprite tileSprite4 = tileSprite3.SetDepth(-1999);
		GameObject gameObject2 = tileSprite4.gameObject;
		((UnityEngine.Object)gameObject2).SetName("Tile_V_Deco");
		_Tile_V_Deco = tileSprite4;
		TileSprite tileSprite5 = RenderingExtensions.AddTileSprite(this, 0f, 0f, 0.64f, height, textureName, spriteName);
		TileSprite tileSprite6 = tileSprite5.SetDepth(-1999);
		GameObject gameObject3 = tileSprite6.gameObject;
		((UnityEngine.Object)gameObject3).SetName("Tile_V_Deco2");
		_Tile_V_Deco2 = tileSprite6;
		TileSprite tileSprite7 = RenderingExtensions.AddTileSprite(this, 0f, 0f, 5.12f, height, textureName, spriteName);
		TileSprite tileSprite8 = tileSprite7.SetDepth(-1998);
		GameObject gameObject4 = tileSprite8.gameObject;
		((UnityEngine.Object)gameObject4).SetName("Tile_H_Plain");
		_Tile_H_Plain = tileSprite8;
		TileSprite tileSprite9 = RenderingExtensions.AddTileSprite(this, 0f, 0f, 5.12f, height, textureName, spriteName);
		TileSprite tileSprite10 = tileSprite9.SetDepth(-1997);
		GameObject gameObject5 = tileSprite10.gameObject;
		((UnityEngine.Object)gameObject5).SetName("Tile_H_Border");
		_Tile_H_Border = tileSprite10;
		TileSprite tileSprite11 = RenderingExtensions.AddTileSprite(this, 0f, 0f, 0.64f, height, textureName, spriteName);
		TileSprite tileSprite12 = tileSprite11.SetDepth(-1996);
		GameObject gameObject6 = tileSprite12.gameObject;
		((UnityEngine.Object)gameObject6).SetName("Tile_V_Border");
		_Tile_V_Border = tileSprite12;
		TileSprite carpet = _carpet;
		Material material = MaterialManager.GetMaterial(MaterialType.ScrollableSprite);
		((Renderer)carpet._spriteRenderer).SetMaterial(material);
		TileSprite tile_H_Plain = _Tile_H_Plain;
		Material material2 = MaterialManager.GetMaterial(MaterialType.ScrollableSprite);
		((Renderer)tile_H_Plain._spriteRenderer).SetMaterial(material2);
		TileSprite tile_V_Deco = _Tile_V_Deco;
		Material material3 = MaterialManager.GetMaterial(MaterialType.ScrollableSprite);
		((Renderer)tile_V_Deco._spriteRenderer).SetMaterial(material3);
		TileSprite tile_V_Deco2 = _Tile_V_Deco2;
		Material material4 = MaterialManager.GetMaterial(MaterialType.ScrollableSprite);
		((Renderer)tile_V_Deco2._spriteRenderer).SetMaterial(material4);
		TileSprite tile_H_Border = _Tile_H_Border;
		Material material5 = MaterialManager.GetMaterial(MaterialType.ScrollableSprite);
		((Renderer)tile_H_Border._spriteRenderer).SetMaterial(material5);
		TileSprite tile_V_Border = _Tile_V_Border;
		Material material6 = MaterialManager.GetMaterial(MaterialType.ScrollableSprite);
		((Renderer)tile_V_Border._spriteRenderer).SetMaterial(material6);
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		List<Vector2> specialLocations = stage._tilingTileset.GetSpecialLocations("Darkasso");
		darkassoLoc = specialLocations;
		List<Vector2> list = darkassoLoc;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v94 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		bool flag = (nint)0 <= (nint)0;
		float num = 0f;
		Vector2 vector2 = default(Vector2);
		if (!flag)
		{
			Transform transform = _carpet.transform;
			List<Vector2> list2 = darkassoLoc;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rcx_v236 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_17c2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
			num = 0f;
			_ = 0;
			Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			transform.position = position;
			Vector2 vector = vector2;
		}
		GameManager core3 = GM.Core;
		Stage stage2 = core3._stage;
		List<Vector2> specialLocations2 = stage2._tilingTileset.GetSpecialLocations("Tile_H_Plain");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rax_v101 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Transform transform2 = _Tile_H_Plain.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
			num = 0f;
			Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			_ = 0;
			transform2.position = position2;
			Vector2 vector = vector2;
		}
		GameManager core4 = GM.Core;
		Stage stage3 = core4._stage;
		List<Vector2> specialLocations3 = stage3._tilingTileset.GetSpecialLocations("Tile_V_Deco");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rax_v106 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Transform transform3 = _Tile_V_Deco.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
			num = 0f;
			Vector3 position3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			_ = 0;
			transform3.position = position3;
			Vector2 vector = vector2;
		}
		GameManager core5 = GM.Core;
		Stage stage4 = core5._stage;
		List<Vector2> specialLocations4 = stage4._tilingTileset.GetSpecialLocations("Tile_H_Border");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v111 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Transform transform4 = _Tile_H_Border.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
			num = 0f;
			Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			_ = 0;
			transform4.position = position4;
			Vector2 vector = vector2;
		}
		GameManager core6 = GM.Core;
		Stage stage5 = core6._stage;
		List<Vector2> specialLocations5 = stage5._tilingTileset.GetSpecialLocations("Tile_V_Border");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v116 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Transform transform5 = _Tile_V_Border.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
			num = 0f;
			Vector3 position5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			_ = 0;
			transform5.position = position5;
			Vector2 vector = vector2;
		}
		GameManager core7 = GM.Core;
		Stage stage6 = core7._stage;
		List<Vector2> specialLocations6 = stage6._tilingTileset.GetSpecialLocations("Tile_V_Deco2");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rax_v121 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Transform transform6 = _Tile_V_Deco2.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7B]");
			num = 0f;
			Vector3 position6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			_ = 0;
			transform6.position = position6;
			Vector2 vector = vector2;
		}
		List<PhaserSprite> list3 = new List<PhaserSprite>();
		walls = list3;
		GameManager core8 = GM.Core;
		Stage stage7 = core8._stage;
		List<Vector2> specialLocations7 = stage7._tilingTileset.GetSpecialLocations("Wall1");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ rax_v129 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
		}
		string[] array = new string[15];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Action<Pickup> action2 = null;
		do
		{
			GameObject gameObject7 = base.gameObject;
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject7, vector2, "backgroundDevil", array[(object)action2]);
			_ = 0;
			_ = 1065353216;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
			PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0.5f, (float?)(object)0);
			PhaserSprite phaserSprite3 = phaserSprite.setDepth(-1997);
			phaserSprite.EnsureSpriteRenderer();
			Material material7 = MaterialManager.GetMaterial(MaterialType.DefaultSpriteLit);
			((Renderer)phaserSprite._spriteRenderer).SetMaterial(material7);
			((UnityEngine.Object)phaserSprite).SetName(array[(object)action2]);
			List<object> list4 = (List<object>)(object)walls;
			int version = list4._version + 1;
			list4._version = version;
			object[] items = list4._items;
			if (list4._size >= items.Length)
			{
				list4.AddWithResize((object)phaserSprite);
			}
			else
			{
				int size = list4._size + 1;
				list4._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			GameObject gameObject8 = base.gameObject;
			PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject8, vector2, "backgroundDevil", "WallOverlay");
			_ = 0;
			_ = 1065353216;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
			PhaserSprite phaserSprite5 = phaserSprite4.setOrigin(0.5f, (float?)(object)0);
			PhaserSprite phaserSprite6 = phaserSprite4.setDepth(1);
			phaserSprite4.EnsureSpriteRenderer();
			Material material8 = MaterialManager.GetMaterial(MaterialType.DefaultSpriteLit);
			((Renderer)phaserSprite4._spriteRenderer).SetMaterial(material8);
			((UnityEngine.Object)phaserSprite4).SetName(array[(object)action2]);
			List<object> list5 = (List<object>)(object)walls;
			int version2 = list5._version + 1;
			list5._version = version2;
			object[] items2 = list5._items;
			if (list5._size >= items2.Length)
			{
				list5.AddWithResize((object)phaserSprite4);
			}
			else
			{
				int size2 = list5._size + 1;
				list5._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			action2 = (Action<Pickup>)(action2 + 1);
		}
		while ((nint)action2 < 15);
		GameManager core9 = GM.Core;
		Stage stage8 = core9._stage;
		List<Vector2> specialLocations8 = stage8._tilingTileset.GetSpecialLocations("EyePositionWall");
		GameManager core10 = GM.Core;
		Stage stage9 = core10._stage;
		List<Vector2> specialLocations9 = stage9._tilingTileset.GetSpecialLocations("EyePositionLeft");
		_003CLeftEyesLocations_003Ek__BackingField = specialLocations9;
		GameManager core11 = GM.Core;
		Stage stage10 = core11._stage;
		List<Vector2> specialLocations10 = stage10._tilingTileset.GetSpecialLocations("EyePositionRight");
		_003CRightEyesLocations_003Ek__BackingField = specialLocations10;
		Vector2 vector3 = (Vector2)0;
		do
		{
			Vector2 vector4 = (Vector2)0;
			while (true)
			{
				Vector2 vector5 = vector4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4096 @ rax_v179 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)vector5 >= 0)
				{
					break;
				}
				specialLocations8.Add(vector4);
				specialLocations8.Add(vector4);
				_003CWallEyesLocations_003Ek__BackingField.Add(vector2);
				vector4++;
			}
			vector3++;
		}
		while ((nint)vector3 < 15);
		GameManager core12 = GM.Core;
		Stage stage11 = core12._stage;
		List<Rectangle> scriptRectangularLocations = stage11._tilingTileset.GetScriptRectangularLocations("DarkassoTrigger", autoScaleAndOffset: true);
		_darkassoCutsceneTriggerZones = scriptRectangularLocations;
		GameManager core13 = GM.Core;
		PlayerOptions playerOptions = core13._playerOptions;
		PlayerOptionsData playerOptionsData;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_18d4;
					}
				}
				playerOptionsData = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_18d4;
		IL_17c2:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_1997:
		PlayerOptionsData playerOptionsData2;
		playerOptionsData2._003CSelectedReapers_003Ek__BackingField = false;
		GameManager core14 = GM.Core;
		PlayerOptions playerOptions2 = core14._playerOptions;
		PlayerOptionsData playerOptionsData3;
		if (playerOptions2._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions2._hostGameConfig == null)
			{
				if (playerOptions2._currentAdventureSaveData != null)
				{
					playerOptionsData3 = playerOptions2._currentAdventureSaveData;
					if ((object)playerOptionsData3._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_19d8;
					}
				}
				playerOptionsData3 = playerOptions2._mainGameConfig;
			}
			else
			{
				playerOptionsData3 = playerOptions2._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData3 = playerOptions2._onlineClientWithRunDataConfig;
		}
		goto IL_19d8;
		IL_1956:
		PlayerOptionsData playerOptionsData4;
		playerOptionsData4._003CSelectedInverse_003Ek__BackingField = false;
		GameManager core15 = GM.Core;
		PlayerOptions playerOptions3 = core15._playerOptions;
		if (playerOptions3._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions3._hostGameConfig == null)
			{
				if (playerOptions3._currentAdventureSaveData != null)
				{
					playerOptionsData2 = playerOptions3._currentAdventureSaveData;
					if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_1997;
					}
				}
				playerOptionsData2 = playerOptions3._mainGameConfig;
			}
			else
			{
				playerOptionsData2 = playerOptions3._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData2 = playerOptions3._onlineClientWithRunDataConfig;
		}
		goto IL_1997;
		IL_1915:
		PlayerOptionsData playerOptionsData5;
		playerOptionsData5._003CSelectedHyper_003Ek__BackingField = false;
		GameManager core16 = GM.Core;
		PlayerOptions playerOptions4 = core16._playerOptions;
		if (playerOptions4._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions4._hostGameConfig == null)
			{
				if (playerOptions4._currentAdventureSaveData != null)
				{
					playerOptionsData4 = playerOptions4._currentAdventureSaveData;
					if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_1956;
					}
				}
				playerOptionsData4 = playerOptions4._mainGameConfig;
			}
			else
			{
				playerOptionsData4 = playerOptions4._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData4 = playerOptions4._onlineClientWithRunDataConfig;
		}
		goto IL_1956;
		IL_19d8:
		playerOptionsData3._003CSelectedRandomEvents_003Ek__BackingField = false;
		GameManager core17 = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core17._characters;
		int[] cachedPlayerCharm = new int[characters._size];
		_cachedPlayerCharm = cachedPlayerCharm;
		GameManager core18 = GM.Core;
		Vector2 vector6 = (Vector2)0;
		Vector2 vector7 = (Vector2)0;
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core18._characters;
			if ((nint)vector6 < characters2._size)
			{
				GameManager core19 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> characters3 = core19._characters;
				if ((nint)vector7 >= characters3._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items3 = characters3._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items3[(object)vector7];
				PlayerModifierStats playerStats = characterController._playerStats;
				int[] cachedPlayerCharm2 = _cachedPlayerCharm;
				cachedPlayerCharm2[(object)vector7] = playerStats._003CCharm_003Ek__BackingField;
				GameManager core20 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> characters4 = core20._characters;
				if ((nint)vector7 >= characters4._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items4 = characters4._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = items4[(object)vector7];
				PlayerModifierStats playerStats2 = characterController2._playerStats;
				playerStats2._003CCharm_003Ek__BackingField = 0;
				vector7++;
				core18 = GM.Core;
				bool flag2 = (object)GM.Core != null;
				vector6 = vector7;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
				continue;
			}
			GameManager core21 = GM.Core;
			PlayerOptions playerOptions5 = core21._playerOptions;
			PlayerOptionsData playerOptionsData6;
			if (playerOptions5._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions5._hostGameConfig == null)
				{
					if (playerOptions5._currentAdventureSaveData != null)
					{
						playerOptionsData6 = playerOptions5._currentAdventureSaveData;
						if ((object)playerOptionsData6._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_1a2b;
						}
					}
					playerOptionsData6 = playerOptions5._mainGameConfig;
				}
				else
				{
					playerOptionsData6 = playerOptions5._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData6 = playerOptions5._onlineClientWithRunDataConfig;
			}
			goto IL_1a2b;
			IL_1a2b:
			if (playerOptionsData6._003CSelectedGoldenEggs_003Ek__BackingField)
			{
				GameManager core22 = GM.Core;
				float num2 = core22._eggManager.RemoveBonuses();
				GameManager core23 = GM.Core;
				core23._stage.RecalculateCurseAndCharm();
			}
			GameManager core24 = GM.Core;
			core24._stage.ResetStageMinimumSpawnToDefault();
			GameManager core25 = GM.Core;
			Stage stage12 = core25._stage;
			stage12._maximum = stage12._defaultMaximum;
			return;
		}
		goto IL_17c2;
		IL_18d4:
		playerOptionsData._003CSelectedHurry_003Ek__BackingField = false;
		GameManager core26 = GM.Core;
		PlayerOptions playerOptions6 = core26._playerOptions;
		if (playerOptions6._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions6._hostGameConfig == null)
			{
				if (playerOptions6._currentAdventureSaveData != null)
				{
					playerOptionsData5 = playerOptions6._currentAdventureSaveData;
					if ((object)playerOptionsData5._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_1915;
					}
				}
				playerOptionsData5 = playerOptions6._mainGameConfig;
			}
			else
			{
				playerOptionsData5 = playerOptions6._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData5 = playerOptions6._onlineClientWithRunDataConfig;
		}
		goto IL_1915;
	}

	public override void CustomPreload(Action onComplete)
	{
		AsyncLoader asyncLoader = new AsyncLoader(onComplete);
		Action<Action> loadCall = _003C_003Ec._003C_003E9__39_0;
		if (_003C_003Ec._003C_003E9__39_0 == null)
		{
			loadCall = (_003C_003Ec._003C_003E9__39_0 = delegate(Action cb)
			{
				//IL_001d: Expected O, but got I4
				AudioLoader.LoadSFXAsync(SfxType.Darkasso_Jingle, "SFX", (DlcType?)(object)0, cb);
			});
		}
		asyncLoader.Add(loadCall);
		Action<Action> loadCall2 = _003C_003Ec._003C_003E9__39_1;
		if (_003C_003Ec._003C_003E9__39_1 == null)
		{
			loadCall2 = (_003C_003Ec._003C_003E9__39_1 = delegate(Action cb)
			{
				//IL_001d: Expected O, but got I4
				AudioLoader.LoadSFXAsync(SfxType.sfx_geiger1, "SFX", (DlcType?)(object)0, cb);
			});
		}
		asyncLoader.Add(loadCall2);
		Action<Action> loadCall3 = _003C_003Ec._003C_003E9__39_2;
		if (_003C_003Ec._003C_003E9__39_2 == null)
		{
			loadCall3 = (_003C_003Ec._003C_003E9__39_2 = delegate(Action cb)
			{
				//IL_001d: Expected O, but got I4
				AudioLoader.LoadSFXAsync(SfxType.sfx_geiger2, "SFX", (DlcType?)(object)0, cb);
			});
		}
		asyncLoader.Add(loadCall3);
		Action<Action> loadCall4 = _003C_003Ec._003C_003E9__39_3;
		if (_003C_003Ec._003C_003E9__39_3 == null)
		{
			loadCall4 = (_003C_003Ec._003C_003E9__39_3 = delegate(Action cb)
			{
				//IL_001d: Expected O, but got I4
				AudioLoader.LoadSFXAsync(SfxType.sfx_geiger3, "SFX", (DlcType?)(object)0, cb);
			});
		}
		asyncLoader.Add(loadCall4);
		Action<Action> loadCall5 = _003C_003Ec._003C_003E9__39_4;
		if (_003C_003Ec._003C_003E9__39_4 == null)
		{
			loadCall5 = (_003C_003Ec._003C_003E9__39_4 = delegate(Action cb)
			{
				//IL_001d: Expected O, but got I4
				AudioLoader.LoadSFXAsync(SfxType.sfx_geiger4, "SFX", (DlcType?)(object)0, cb);
			});
		}
		asyncLoader.Add(loadCall5);
		asyncLoader.Load();
	}

	private void OnRemoteItemInstantiated(Pickup pickup)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		if ((object)pickup == null)
		{
			return;
		}
		nint num = (nint)typeof(PickupRelic);
		nint num2 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v39+FFFFFFF8+v50 @ rax_v3*8]");
			if (0 == (nint)typeof(PickupRelic))
			{
				obj3 = 1;
				goto IL_01ff;
			}
		}
		obj3 = 0;
		goto IL_01ff;
		IL_01ff:
		bool flag = obj3 == null;
		Pickup pickup2 = null;
		if (!flag)
		{
			pickup2 = pickup;
		}
		if ((object)pickup2 == null)
		{
			return;
		}
		_darkassoPickup = (PickupRelic)pickup2;
		Action<Pickup> value = OnRemoteItemInstantiated;
		Delegate obj4 = Delegate.Remove(ItemInstantiator.OnRemoteItemInstantiated, value);
		if ((object)obj4 == null)
		{
			ItemInstantiator.OnRemoteItemInstantiated = (Action<Pickup>)obj4;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<Pickup> action = default(Action<Pickup>);
			if (action == null)
			{
				throw new InvalidCastException();
			}
			ItemInstantiator.OnRemoteItemInstantiated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				throw new InvalidCastException();
			}
		}
		PickupRelic darkassoPickup = _darkassoPickup;
		BaseBody body = darkassoPickup.body;
		body._enable = false;
		ArcadeSprite arcadeSprite = _darkassoPickup.setVisible(visible: true);
		_hasTriggeredDarkassoCutscene = false;
	}

	public override void OnInitCompleted()
	{
		PhaserScene phaserScene = base.scene;
		BackgroundDevilRoom_Helper helper = new BackgroundDevilRoom_Helper(phaserScene, this);
		_helper = helper;
		_helper.AddRotatingBackground();
		base.OnInitCompleted();
	}

	protected override void OnUpdate()
	{
		//IL_0107: Expected O, but got F4
		//IL_01a3: Expected O, but got F4
		base.OnUpdate();
		SearchForDarkasso();
		float deltaTime = PauseSystem.DeltaTime;
		TileSprite carpet = _carpet;
		float num = deltaTime * 0.1f;
		float scrollOffsetX = (carpet._xScrollOffset = num + carpet._xScrollOffset);
		carpet._spriteScroller.SetScrollOffsetX(scrollOffsetX);
		TileSprite carpet2 = _carpet;
		float scrollOffsetY = (carpet2._yScrollOffset = num + carpet2._yScrollOffset);
		carpet2._spriteScroller.SetScrollOffsetY(scrollOffsetY);
		TileSprite tile_H_Plain = _Tile_H_Plain;
		float scrollOffsetX2 = (tile_H_Plain._xScrollOffset = num + tile_H_Plain._xScrollOffset);
		tile_H_Plain._spriteScroller.SetScrollOffsetX(scrollOffsetX2);
		TileSprite tile_H_Border = _Tile_H_Border;
		object obj = num ^ -0f;
		float scrollOffsetX3 = (tile_H_Border._xScrollOffset = (float)obj + tile_H_Border._xScrollOffset);
		tile_H_Border._spriteScroller.SetScrollOffsetX(scrollOffsetX3);
		TileSprite tile_V_Deco = _Tile_V_Deco;
		float scrollOffsetY2 = (tile_V_Deco._yScrollOffset = num + tile_V_Deco._yScrollOffset);
		tile_V_Deco._spriteScroller.SetScrollOffsetY(scrollOffsetY2);
		TileSprite tile_V_Deco2 = _Tile_V_Deco2;
		object obj2 = num ^ -0f;
		float scrollOffsetY3 = (tile_V_Deco2._yScrollOffset = (float)obj2 + tile_V_Deco2._yScrollOffset);
		tile_V_Deco2._spriteScroller.SetScrollOffsetY(scrollOffsetY3);
		TileSprite tile_V_Border = _Tile_V_Border;
		float scrollOffsetY4 = (tile_V_Border._yScrollOffset = num + tile_V_Border._yScrollOffset);
		tile_V_Border._spriteScroller.SetScrollOffsetY(scrollOffsetY4);
		if (!CheckLevel())
		{
			PickupRelic darkassoPickup = _darkassoPickup;
			if ((object)_darkassoPickup != null && ((UnityEngine.Object)darkassoPickup).m_CachedPtr != (IntPtr)0 && !_hasTriggeredDarkassoCutscene)
			{
				CheckForDarkassoCutscene();
			}
		}
	}

	private void SearchForDarkasso()
	{
		//IL_00bf: Expected I, but got O
		//IL_00cd: Expected I, but got O
		//IL_00dd: Expected O, but got I
		//IL_015d: Expected O, but got I4
		//IL_0119: Expected O, but got I
		//IL_014f: Expected O, but got I4
		if (GM.Core.IsStageHost)
		{
			return;
		}
		PickupRelic darkassoPickup = _darkassoPickup;
		if ((object)_darkassoPickup != null && ((UnityEngine.Object)darkassoPickup).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core = GM.Core;
		Predicate<Pickup> match = _003C_003Ec._003C_003E9__43_0;
		if (_003C_003Ec._003C_003E9__43_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__43_0 = delegate(Pickup p)
			{
				//IL_0013: Expected I, but got O
				//IL_001b: Expected I, but got O
				//IL_002b: Expected O, but got I
				//IL_00ab: Expected O, but got I4
				//IL_0067: Expected O, but got I
				//IL_009d: Expected O, but got I4
				//IL_00d3: Expected O, but got I
				if ((object)p == null)
				{
					goto IL_00e7;
				}
				nint num4 = (nint)typeof(PickupRelic);
				nint num5 = (nint)p;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
				object obj6;
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v11+FFFFFFF8+v42 @ rax_v4*8]");
					if (0 == (nint)typeof(PickupRelic))
					{
						obj6 = 1;
						goto IL_010a;
					}
				}
				obj6 = 0;
				goto IL_010a;
				IL_00e7:
				return false;
				IL_010a:
				bool flag3 = obj6 == null;
				Pickup pickup2 = null;
				if (!flag3)
				{
					pickup2 = p;
				}
				if ((object)pickup2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v7 (VampireSurvivors.Objects.Pickups.Pickup)+1F0]");
					object obj7 = -75;
					return obj7 == null;
				}
				goto IL_00e7;
			});
		}
		Pickup pickup = core._stagePickups.Find(match);
		bool flag = (object)pickup == null;
		Pickup darkassoPickup2 = pickup;
		if (flag)
		{
			goto IL_0234;
		}
		nint num = (nint)pickup;
		nint num2 = (nint)typeof(PickupRelic);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rax_v42+FFFFFFF8+v409 @ rax_v37*8]");
			if (0 == (nint)typeof(PickupRelic))
			{
				obj3 = 1;
				goto IL_0243;
			}
		}
		obj3 = 0;
		goto IL_0243;
		IL_0243:
		bool flag2 = obj3 == null;
		darkassoPickup2 = null;
		if (!flag2)
		{
			darkassoPickup2 = pickup;
		}
		goto IL_0234;
		IL_0234:
		_darkassoPickup = (PickupRelic)darkassoPickup2;
		PickupRelic darkassoPickup3 = _darkassoPickup;
		if ((object)_darkassoPickup != null && ((UnityEngine.Object)darkassoPickup3).m_CachedPtr != (IntPtr)0)
		{
			OnDarkassoSpawned();
		}
	}

	private bool CheckLevel()
	{
		//IL_00ef: Expected O, but got I
		//IL_03e1: Expected O, but got I8
		//IL_0193: Expected O, but got I
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<int> list = tresholds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)0 > (nint)currentLevel && GM.Core.IsStageHost && !_isSendingAdvanceLevel)
		{
			List<int> list2 = tresholds;
			int num = currentLevel;
			int num2 = currentLevel;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v34 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)num2 >= (nint)0)
			{
				goto IL_03bc;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v34 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			int num3 = config._003CRunEnemies_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v24+20+v117 @ rax_v53 (System.Int32)*4]");
			if ((nint)num3 >= (nint)0)
			{
				GameManager core2 = GM.Core;
				if (!core2._multiplayer.IsOnlineMultiplayer)
				{
					AdvanceLevel();
				}
				else
				{
					_isSendingAdvanceLevel = true;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
					Action<long> action = null;
					long num4 = default(long);
					((OnlineStageManager)(object)action).AdvanceDevilRoomLevel(num4);
					long startingOnlineClientFrame = ((OnlineStageManager)num4).GetStartingOnlineClientFrame();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v57 (System.Int64)+78]");
					bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
				}
			}
		}
		if (currentLevel != 15)
		{
			goto IL_03a0;
		}
		GameManager core3 = GM.Core;
		Stage stage = core3._stage;
		List<Vector2> specialLocations = stage._tilingTileset.GetSpecialLocations("Darkasso");
		darkassoLoc = specialLocations;
		List<Vector2> list3 = darkassoLoc;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v21 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v21 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				List<Vector2> list4 = darkassoLoc;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ rax_v45 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)0 > (nint)0)
				{
					goto IL_03ea;
				}
			}
			goto IL_03bc;
		}
		goto IL_03ea;
		IL_03bc:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
		IL_03a0:
		return false;
		IL_03ea:
		int num5 = currentLevel + 1;
		currentLevel = num5;
		GameManager core4 = GM.Core;
		PlayerOptionsData config2 = core4._playerOptions.Config;
		List<ItemType> list5 = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v19 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		Vector2 vector = default(Vector2);
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				ResumeEnemyWaves();
				SpawnArcanaChestAt(vector);
				return true;
			}
		}
		GameManager core5 = GM.Core;
		core5._canRunTickerTimer = false;
		GameManager core6 = GM.Core;
		Stage stage2 = core6._stage;
		if (stage2._spawnTimer != null)
		{
			stage2._spawnTimer.Cancel();
		}
		SpawnDarkasso(vector);
		goto IL_03a0;
	}

	public void AdvanceLevel()
	{
		//IL_010f: Expected O, but got I
		//IL_0137: Expected O, but got I
		//IL_0147: Expected O, but got I
		//IL_01a8: Expected O, but got I
		//IL_018d: Expected O, but got I
		//IL_01fb: Expected O, but got I
		//IL_0223: Expected O, but got I
		//IL_0233: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0279: Expected O, but got I
		ExpandBounds(++currentLevel);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CSelectedMazzo_003Ek__BackingField = true;
		List<EnemyType?> list = enemies;
		int num = currentLevel;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v11 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		int num2 = (int)(-1);
		int num3 = currentLevel;
		if (currentLevel > num2)
		{
			num = num2;
		}
		List<EnemyType?> list2 = bosses;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v14 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		int num4 = (int)(-1);
		if (num3 > num4)
		{
			num3 = num4;
		}
		List<EnemyType?> list3 = new List<EnemyType?>();
		List<EnemyType?> list4 = enemies;
		int num5 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		if ((nint)num5 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r8_v5+18]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v14+20+v90 @ rdi_v5 (System.Int32)*8]");
				list3.AddWithResize((EnemyType?)(object)0);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v17 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
				object obj4 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v14+20+v90 @ rdi_v5 (System.Int32)*8]");
				_ = 0;
			}
			List<EnemyType?> list5 = new List<EnemyType?>();
			List<EnemyType?> list6 = bosses;
			int num7 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			if ((nint)num7 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rax_v22 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rax_v22 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rax_v22 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rax_v22 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r8_v7+18]");
				if (num8 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v19+20+v83 @ rbp_v5 (System.Int32)*8]");
					list5.AddWithResize((EnemyType?)(object)0);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rax_v22 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
					object obj8 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v19+20+v83 @ rbp_v5 (System.Int32)*8]");
					_ = 0;
				}
				GameManager core2 = GM.Core;
				core2._stage.UpdateEnemyPools(list3, list5);
				if (currentLevel == 0)
				{
					_helper.AddRotatingBackground();
				}
				GameManager core3 = GM.Core;
				PlayerOptionsData config2 = core3._playerOptions.Config;
				_lastEnemies = config2._003CRunEnemies_003Ek__BackingField;
				GameManager core4 = GM.Core;
				_lastSeconds = core4._003CSurvivedSeconds_003Ek__BackingField;
				_isSendingAdvanceLevel = false;
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void LateUpdate()
	{
		if (_helper != null)
		{
			_helper.Update();
		}
	}

	private void ResumeEnemyWaves()
	{
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageData stageData = stage._stageData;
		stageData._003Cminimum_003Ek__BackingField = 40;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		stage2._maximum = 300;
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		StageData stageData2 = stage3._stageData;
		stageData2._003Cfrequency_003Ek__BackingField = 100f;
		GameManager core4 = GM.Core;
		core4._canRunTickerTimer = true;
		GameManager core5 = GM.Core;
		core5._stage.StartTimers();
	}

	private void SpawnDarkasso(Vector2 location)
	{
		//IL_003b: Expected I, but got O
		//IL_006f: Expected I, but got O
		//IL_007f: Expected O, but got I
		//IL_00bb: Expected O, but got I
		//IL_0100: Expected I, but got O
		//IL_0108: Expected I, but got O
		//IL_0118: Expected O, but got I
		//IL_0154: Expected O, but got I
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = GM.Core.MakeStagePickup(location, ItemType.RELIC, WeaponType.VOID, value, relicType, validatePickups);
		nint num = (nint)typeof(PickupRelic);
		if ((object)pickup == null)
		{
			_darkassoPickup = null;
			goto IL_0186;
		}
		nint num2 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rax_v30+FFFFFFF8+v149 @ rax_v29*8]");
			if (0 == (nint)typeof(PickupRelic))
			{
				_darkassoPickup = (PickupRelic)pickup;
				nint num4 = (nint)typeof(PickupRelic);
				nint num5 = (nint)pickup;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v32+FFFFFFF8+v175 @ rax_v31*8]");
					if (0 == (nint)typeof(PickupRelic))
					{
						goto IL_0186;
					}
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
		IL_0186:
		PickupRelic darkassoPickup = _darkassoPickup;
		if ((object)_darkassoPickup != null && ((UnityEngine.Object)darkassoPickup).m_CachedPtr != (IntPtr)0)
		{
			PickupRelic darkassoPickup2 = _darkassoPickup;
			BaseBody body = darkassoPickup2.body;
			body._enable = false;
			ArcadeSprite arcadeSprite = _darkassoPickup.setVisible(visible: true);
			_hasTriggeredDarkassoCutscene = false;
		}
	}

	private void OnDarkassoSpawned()
	{
		PickupRelic darkassoPickup = _darkassoPickup;
		BaseBody body = darkassoPickup.body;
		body._enable = false;
		ArcadeSprite arcadeSprite = _darkassoPickup.setVisible(visible: true);
		_hasTriggeredDarkassoCutscene = false;
	}

	private unsafe void CheckForDarkassoCutscene()
	{
		//IL_0035: Expected O, but got I4
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_00af: Expected O, but got Ref
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		object obj = 0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (true)
		{
			List<Rectangle> darkassoCutsceneTriggerZones = _darkassoCutsceneTriggerZones;
			if ((nint)obj < darkassoCutsceneTriggerZones._size)
			{
				if ((nint)obj >= darkassoCutsceneTriggerZones._size)
				{
					break;
				}
				Rectangle[] items = darkassoCutsceneTriggerZones._items;
				GameManager core = GM.Core;
				if (enumerator.MoveNext())
				{
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				obj++;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public void TriggerCutscene(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		_darkassoTargetPlayer = character;
		_hasTriggeredDarkassoCutscene = true;
		_003C_PlayDarkassoCutscene_003Ed__52 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator _PlayDarkassoCutscene()
	{
		_003C_PlayDarkassoCutscene_003Ed__52 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void SpawnArcanaChestAt(Vector2 position)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0462: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_048a: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_018e: Expected O, but got I
		//IL_01e8: Expected O, but got I
		//IL_01cd: Expected O, but got I4
		//IL_04c1: Expected O, but got I
		//IL_0252: Expected O, but got I
		//IL_0237: Expected O, but got I4
		//IL_04e9: Expected O, but got I
		//IL_02bc: Expected O, but got I
		//IL_02a1: Expected O, but got I4
		//IL_0511: Expected O, but got I
		//IL_0326: Expected O, but got I
		//IL_030b: Expected O, but got I4
		//IL_0539: Expected O, but got I
		//IL_0390: Expected O, but got I
		//IL_0375: Expected O, but got I4
		List<float> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v5+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(10f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1092616192;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v6+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(100f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1120403456;
		}
		List<PrizeType?> list2 = new List<PrizeType?>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v8+18]");
		if (num4 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdx_v10+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v12+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v14+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v16+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ rax_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1;
		}
		Treasure treasure = new Treasure();
		treasure._003Cchances_003Ek__BackingField = list;
		treasure._003CprizeTypes_003Ek__BackingField = list2;
		List<WeaponType> list3 = new List<WeaponType>();
		treasure._003CfixedPrizes_003Ek__BackingField = list3;
		treasure._003ChasArcana_003Ek__BackingField = true;
		GameManager core = GM.Core;
		int num9 = core._stage.SetTreasureLevelFromChance(treasure);
		TreasureChest treasureChest = GM.Core.MakeTreasure(position, treasure);
	}

	public override void CheckMinute(int minute)
	{
		//IL_0036: Invalid comparison between F4 and O
		//IL_0059: Invalid comparison between F4 and I4
		//IL_0082: Expected O, but got I4
		//IL_00ae: Expected O, but got I4
		//IL_0188: Expected O, but got I
		//IL_01ec: Expected O, but got I
		//IL_0201: Expected O, but got I
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
		float num = core._003CSurvivedSeconds_003Ek__BackingField;
		object obj = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float num2 = core._003CSurvivedSeconds_003Ek__BackingField - (float)obj;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj2 = flag4 & flag3;
		object obj3 = (object?)stageModifiers._003CTimeLimit_003Ek__BackingField & obj2;
		bool flag5 = obj3 == null;
		object obj4 = !flag5;
		List<EnemyType?> list8;
		List<EnemyType?> list9;
		if (obj4 == null)
		{
			List<EnemyType?> list = enemies;
			int num3 = currentLevel;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v22 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			List<EnemyType?> list7;
			if ((nint)num3 < (nint)0)
			{
				List<EnemyType?> list2 = enemies;
				int num4 = currentLevel;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v36 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
				int num5 = (int)(-1);
				if (currentLevel > num5)
				{
					num4 = num5;
				}
				List<EnemyType?> list3 = new List<EnemyType?>();
				List<EnemyType?> list4 = enemies;
				int num6 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v41 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
				if ((nint)num6 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v41 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4860");
					List<EnemyType?> list5 = new List<EnemyType?>();
					List<EnemyType?> list6 = bosses;
					int num7 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v46 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
					if ((nint)num7 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v46 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v47+20+v98 @ rbx_v12 (System.Int32)*8]");
						list7 = (List<EnemyType?>)0;
						list8 = list3;
						list9 = list5;
						goto IL_0359;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			List<EnemyType?> list10 = new List<EnemyType?>();
			_secondPhaseEnemies._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4860");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA55F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4860");
			List<EnemyType?> list11 = new List<EnemyType?>();
			_secondPhaseBosses._002Ector();
			list8 = list10;
			List<EnemyType?> list12 = default(List<EnemyType?>);
			list7 = list12;
			list9 = list11;
			goto IL_0359;
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		List<EnemyType?> list13 = new List<EnemyType?>();
		List<EnemyType?> list14 = new List<EnemyType?>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4860");
		list8 = list13;
		list9 = list14;
		goto IL_02fe;
		IL_02fe:
		stage2.UpdateEnemyPools(list8, list9);
		GameManager core3 = GM.Core;
		core3._stage.SpawnBoss();
		return;
		IL_0359:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4860");
		GameManager core4 = GM.Core;
		stage2 = core4._stage;
		goto IL_02fe;
	}

	private unsafe void ExpandBounds(int level)
	{
		//IL_0317: Expected I4, but got F4
		//IL_0680: Expected I4, but got F4
		//IL_04ae: Expected O, but got I4
		//IL_04eb: Expected O, but got I4
		//IL_0501: Expected O, but got I8
		//IL_042e: Expected O, but got I4
		//IL_0520: Expected O, but got I4
		//IL_058d: Expected O, but got I4
		//IL_0557: Expected O, but got I8
		//IL_0354: Expected I4, but got F4
		//IL_05ca: Expected F4, but got I4
		//IL_05ea: Expected O, but got I4
		//IL_0622: Expected F4, but got I4
		//IL_03d3: Expected O, but got Ref
		List<PhaserSprite> list = walls;
		if (list._size == 0)
		{
			return;
		}
		GameManager core = GM.Core;
		SuperObject hardBoundsObjFromTMX = core._stage.GetHardBoundsObjFromTMX();
		if ((object)hardBoundsObjFromTMX == null || ((UnityEngine.Object)hardBoundsObjFromTMX).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		_helper.PulseLight();
		_helper.PulseBackground();
		float xMax = hardBoundsObjFromTMX.m_Width + hardBoundsObjFromTMX.m_X;
		float x = hardBoundsObjFromTMX.m_X;
		float y = hardBoundsObjFromTMX.m_Y;
		float num = default(float);
		bool flag = default(bool);
		GM.Core.SetHardBoundsMinMax(hardBoundsObjFromTMX.m_X, hardBoundsObjFromTMX.m_Y, xMax, num, flag);
		List<PhaserSprite> list2 = walls;
		if (list2._size > 0)
		{
			if (list2._size <= 0)
			{
				goto IL_065d;
			}
			PhaserSprite[] items = list2._items;
			GameObject gameObject = items[0].gameObject;
			gameObject.SetActive(value: false);
			walls.RemoveAt(0);
		}
		List<PhaserSprite> list3 = walls;
		if (list3._size <= 0)
		{
			goto IL_02fb;
		}
		GameManager core2 = GM.Core;
		List<PhaserSprite> list4 = walls;
		if (list4._size > 0)
		{
			PhaserSprite[] items2 = list4._items;
			float2 position = items2[0].position;
			Vector2 position2 = default(Vector2);
			core2._stage.SpawnChosenDestructiblesInClosestLocations(PropType.BRAZIER2, 16, position2);
			List<PhaserSprite> list5 = walls;
			if (list5._size > 0)
			{
				PhaserSprite[] items3 = list5._items;
				GameObject gameObject2 = items3[0].gameObject;
				gameObject2.SetActive(value: false);
				walls.RemoveAt(0);
				float num2 = default(float);
				x = num2;
				goto IL_02fb;
			}
		}
		goto IL_065d;
		IL_02fb:
		bool flag2 = currentLevel != 6;
		bool flag3 = (byte)(int)num != 0;
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (!flag2)
		{
			BackgroundDevilRoom_Helper helper = _helper;
			bool flag4 = !helper._bgEnabled;
			flag3 = (byte)(int)num != 0;
			if (!flag4)
			{
				Camera main = Camera.main;
				flag3 = (byte)(int)num != 0;
				if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
				{
					float currentCameraAngleZ = helper._currentCameraAngleZ * -1f;
					helper._currentCameraAngleZ = currentCameraAngleZ;
					Transform target = main.transform;
					x = helper._currentCameraAngleZ;
					object obj = default(object);
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj), 10f);
					y = 10f;
				}
			}
			Action onComplete = _helper.TiltCamera;
			Timer timer = Timers.Register(30.000002f, onComplete, null, isLooped: true, flag3, (MonoBehaviour)flag, repeat, type, isOnlineTimer: false, canPause: false);
		}
		if (skullsTimer != null)
		{
			skullsTimer.Cancel();
		}
		BackgroundDevilRoom_Helper helper2 = _helper;
		RenderingExtensions.Start(helper2.SkullsEmitter);
		Action onComplete2 = delegate
		{
			BackgroundDevilRoom_Helper helper3 = _helper;
			helper3.SkullsEmitter.Stop();
		};
		object obj2 = currentLevel * 400;
		float duration = (float)obj2 * 0.001f;
		Timer timer2 = Timers.Register(duration, onComplete2, null, isLooped: false, flag3, (MonoBehaviour)flag, repeat, type, isOnlineTimer: false, canPause: false);
		object obj3 = 6442450944L;
		skullsTimer = timer2;
		object obj4 = currentLevel - 1;
		if ((nint)obj4 <= 14)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r9_v9+6F20BFC+v207 @ rax_v36*4]");
			object obj5 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v643 @ rcx_v37 (should have been resolved before IL gen)");
		}
		_helper.PulseLight();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Detune = -500f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lid, soundConfig, 150f, 2, flag3 ? 1 : 0);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = -200f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Haha, soundConfig2, 150f, 2, flag3 ? 1 : 0);
		return;
		IL_065d:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void CheckStageCosmetics(int level)
	{
		if (level == 0)
		{
			_helper.AddRotatingBackground();
		}
	}

	private void UpdateKillRatio(int level)
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		_lastEnemies = config._003CRunEnemies_003Ek__BackingField;
		GameManager core2 = GM.Core;
		_lastSeconds = core2._003CSurvivedSeconds_003Ek__BackingField;
	}

	public override float GetKillRatio()
	{
		//IL_0053: Invalid comparison between F4 and I4
		//IL_0084: Expected O, but got I4
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		GameManager core2 = GM.Core;
		float num = core2._003CSurvivedSeconds_003Ek__BackingField - _lastSeconds;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186F20DC7h\"");
		if (num == 0f)
		{
			return 1f;
		}
		object obj = config._003CRunEnemies_003Ek__BackingField - _lastEnemies;
		float num2 = (float)obj / num;
		bool flag = !(1f < num2);
		float num3 = 1f;
		if (!flag)
		{
			num3 = num2;
		}
		if (num3 > 2f)
		{
			num3 *= num3;
		}
		if (!(num3 > 10f))
		{
			object obj2 = 10f & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_0169;
			}
		}
		num3 = 10f;
		goto IL_0169;
		IL_0169:
		return num3;
	}

	public override void Cleanup()
	{
		base._003CIsBackgroundActive_003Ek__BackingField = false;
	}

	public override void EnableMovingBackground()
	{
	}

	public override void DisableMovingBackground()
	{
		_helper.DisableMovingBackground();
	}

	public override bool ShouldPlayNormalMusic()
	{
		//IL_00ce: Expected I4, but got O
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
				if (config._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					if ((nint)0 == 0)
					{
						return false;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj2 = default(object);
					object obj = obj2 - -1;
					bool flag = obj == null;
					return !flag;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public BackgroundDevilRoom()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_1327: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_134f: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_1377: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_139f: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_13c7: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_13ef: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_1417: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_143f: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_1467: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_148f: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_14b7: Expected O, but got I
		//IL_0510: Expected O, but got I
		//IL_14df: Expected O, but got I
		//IL_057a: Expected O, but got I
		//IL_1507: Expected O, but got I
		//IL_05e4: Expected O, but got I
		//IL_152f: Expected O, but got I
		//IL_064e: Expected O, but got I
		//IL_06ac: Expected O, but got I
		//IL_070d: Expected O, but got I
		//IL_06f2: Expected O, but got I
		//IL_1566: Expected O, but got I
		//IL_0785: Expected O, but got I
		//IL_076a: Expected O, but got I
		//IL_15a0: Expected O, but got I
		//IL_07fd: Expected O, but got I
		//IL_07e2: Expected O, but got I
		//IL_15da: Expected O, but got I
		//IL_0875: Expected O, but got I
		//IL_085a: Expected O, but got I
		//IL_1614: Expected O, but got I
		//IL_08ed: Expected O, but got I
		//IL_08d2: Expected O, but got I
		//IL_164e: Expected O, but got I
		//IL_0965: Expected O, but got I
		//IL_094a: Expected O, but got I
		//IL_1688: Expected O, but got I
		//IL_09dd: Expected O, but got I
		//IL_09c2: Expected O, but got I
		//IL_16c2: Expected O, but got I
		//IL_0a55: Expected O, but got I
		//IL_0a3a: Expected O, but got I
		//IL_16fc: Expected O, but got I
		//IL_0acd: Expected O, but got I
		//IL_0ab2: Expected O, but got I
		//IL_1736: Expected O, but got I
		//IL_0b45: Expected O, but got I
		//IL_0b2a: Expected O, but got I
		//IL_1770: Expected O, but got I
		//IL_0bbd: Expected O, but got I
		//IL_0ba2: Expected O, but got I
		//IL_17aa: Expected O, but got I
		//IL_0c35: Expected O, but got I
		//IL_0c1a: Expected O, but got I
		//IL_17e4: Expected O, but got I
		//IL_0cad: Expected O, but got I
		//IL_0c92: Expected O, but got I
		//IL_181e: Expected O, but got I
		//IL_0d25: Expected O, but got I
		//IL_0d0a: Expected O, but got I
		//IL_1858: Expected O, but got I
		//IL_0d9d: Expected O, but got I
		//IL_0d82: Expected O, but got I
		//IL_0e02: Expected O, but got I
		//IL_0e63: Expected O, but got I
		//IL_0e48: Expected O, but got I
		//IL_18a1: Expected O, but got I
		//IL_0edc: Expected O, but got I
		//IL_0ec0: Expected O, but got I
		//IL_18df: Expected O, but got I
		//IL_1906: Expected O, but got I
		//IL_192d: Expected O, but got I
		//IL_0f20: Expected O, but got I
		//IL_0f47: Expected O, but got I
		//IL_0f73: Expected O, but got I
		//IL_0f9a: Expected O, but got I
		//IL_0fc6: Expected O, but got I
		//IL_0fed: Expected O, but got I
		//IL_1019: Expected O, but got I
		//IL_1040: Expected O, but got I
		//IL_106c: Expected O, but got I
		//IL_1093: Expected O, but got I
		//IL_10dd: Expected O, but got I
		//IL_1127: Expected O, but got I
		//IL_114e: Expected O, but got I
		//IL_117a: Expected O, but got I
		//IL_11a1: Expected O, but got I
		//IL_11c9: Expected O, but got I
		//IL_123c: Expected O, but got I
		//IL_1221: Expected O, but got I
		//IL_1955: Expected O, but got I
		//IL_12b4: Expected O, but got I
		//IL_1299: Expected O, but got I
		List<int> list = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(100);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 100;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(200);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 200;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(300);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 300;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(400);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 400;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(500);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 500;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(600);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 600;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(700);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 700;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(800);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 800;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v20+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(900);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 900;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v22+18]");
		if (num10 >= 0)
		{
			list.AddWithResize(1000);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1000;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v24+18]");
		if (num11 >= 0)
		{
			list.AddWithResize(1100);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1100;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v26+18]");
		if (num12 >= 0)
		{
			list.AddWithResize(1200);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1200;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v28+18]");
		if (num13 >= 0)
		{
			list.AddWithResize(1300);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1300;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rdx_v30+18]");
		if (num14 >= 0)
		{
			list.AddWithResize(1400);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1400;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v32+18]");
		if (num15 >= 0)
		{
			list.AddWithResize(1665);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 1665;
		}
		tresholds = list;
		List<EnemyType?> list2 = new List<EnemyType?>();
		_ = 0;
		_ = 630;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v36+18]");
		if (num16 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj32 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj33 = 0;
		_ = 0;
		_ = 631;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v38+18]");
		if (num17 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj34 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj35 = 0;
		_ = 0;
		_ = 632;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v40+18]");
		if (num18 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj36 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj37 = 0;
		_ = 0;
		_ = 633;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v42+18]");
		if (num19 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj38 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj39 = 0;
		_ = 0;
		_ = 634;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v44+18]");
		if (num20 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj40 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj41 = 0;
		_ = 0;
		_ = 635;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v46+18]");
		if (num21 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj42 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj43 = 0;
		_ = 0;
		_ = 636;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v48+18]");
		if (num22 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj44 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj45 = 0;
		_ = 0;
		_ = 637;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v50+18]");
		if (num23 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj46 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj47 = 0;
		_ = 0;
		_ = 638;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v52+18]");
		if (num24 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj48 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj49 = 0;
		_ = 0;
		_ = 639;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v54+18]");
		if (num25 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj50 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj51 = 0;
		_ = 0;
		_ = 640;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v56+18]");
		if (num26 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj52 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj53 = 0;
		_ = 0;
		_ = 641;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v58+18]");
		if (num27 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj54 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj55 = 0;
		_ = 0;
		_ = 642;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v60+18]");
		if (num28 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj56 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj57 = 0;
		_ = 0;
		_ = 643;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v62+18]");
		if (num29 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj58 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj59 = 0;
		_ = 0;
		_ = 644;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v64+18]");
		if (num30 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list2.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1645 @ rax_v24 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj60 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		enemies = list2;
		List<EnemyType?> list3 = new List<EnemyType?>();
		_ = 0;
		_ = 849;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ rax_v43 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ rax_v43 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ rax_v43 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v68+18]");
		if (num31 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list3.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ rax_v43 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj62 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ rax_v43 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ rax_v43 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj63 = 0;
		_ = 0;
		_ = 849;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ rax_v43 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v70+18]");
		if (num32 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list3.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ rax_v43 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj64 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		_ = 0;
		_ = 849;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 849;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 849;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 849;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 849;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 849;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 849;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 849;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 855;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 855;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 855;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 855;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 855;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list3.Add((EnemyType?)(object)0);
		bosses = list3;
		List<EnemyType?> list4 = new List<EnemyType?>();
		_ = 0;
		_ = 852;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list4.Add((EnemyType?)(object)0);
		_secondPhaseBosses = list4;
		List<EnemyType?> list5 = new List<EnemyType?>();
		_ = 0;
		_ = 845;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list5.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 648;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list5.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 634;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list5.Add((EnemyType?)(object)0);
		_ = 0;
		_ = 856;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
		list5.Add((EnemyType?)(object)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2327 @ rax_v66 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2327 @ rax_v66 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj65 = 0;
		_ = 0;
		_ = 640;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2327 @ rax_v66 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v92+18]");
		if (num33 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list5.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2327 @ rax_v66 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj66 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2327 @ rax_v66 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2327 @ rax_v66 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj67 = 0;
		_ = 0;
		_ = 636;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2327 @ rax_v66 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v94+18]");
		if (num34 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			list5.AddWithResize((EnemyType?)(object)0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2327 @ rax_v66 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj68 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+30]");
			_ = 0;
		}
		_secondPhaseEnemies = list5;
		_003CWallEyesLocations_003Ek__BackingField = new List<Vector2>();
		base._002Ector();
	}

	private void _003CExpandBounds_003Eb__55_0()
	{
		BackgroundDevilRoom_Helper helper = _helper;
		helper.SkullsEmitter.Stop();
	}
}
