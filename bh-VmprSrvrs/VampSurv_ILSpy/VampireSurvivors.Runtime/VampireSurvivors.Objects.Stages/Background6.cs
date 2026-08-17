using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using PhaserPort;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.Video;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.VFX.Shatter;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class Background6 : BackgroundManager
{
	private sealed class _003C_003Ec__DisplayClass105_0
	{
		public List<Gem> gems;

		public int i;

		public Action<Pickup> _003C_003E9__0;

		internal void _003CSendGem_003Eb__0(Pickup gem)
		{
			//IL_0013: Expected I, but got O
			//IL_001b: Expected I, but got O
			//IL_002b: Expected O, but got I
			//IL_00ab: Expected O, but got I4
			//IL_0067: Expected O, but got I
			//IL_009d: Expected O, but got I4
			nint num = (nint)typeof(Gem);
			nint num2 = (nint)gem;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
			object obj3;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v10+FFFFFFF8+v50 @ rax_v4*8]");
				if (0 == (nint)typeof(Gem))
				{
					obj3 = 1;
					goto IL_0108;
				}
			}
			obj3 = 0;
			goto IL_0108;
			IL_0108:
			bool flag = obj3 == null;
			Pickup pickup = null;
			if (!flag)
			{
				pickup = gem;
			}
			pickup.GoToPlayer = true;
			pickup.Time = 1f;
			float num4 = 250f - (float)i;
			pickup._003CSpeed_003Ek__BackingField = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA54B0");
		}
	}

	private sealed class _003C_003Ec__DisplayClass106_0
	{
		public int i;

		internal void _003CSendCoins_003Eb__0(Pickup coin)
		{
			if ((object)coin != null && ((UnityEngine.Object)coin).m_CachedPtr != (IntPtr)0)
			{
				coin.GoToPlayer = true;
				GameManager core = GM.Core;
				GameSessionData gameSessionData = core._gameSessionData;
				coin._targetPlayer = gameSessionData._activeCharacter;
				coin.Time = 1f;
				float num = 250f - (float)i;
				coin._003CSpeed_003Ek__BackingField = num;
				float num2 = coin._003CValue_003Ek__BackingField * 10f;
				coin._003CValue_003Ek__BackingField = num2;
			}
		}

		internal void _003CSendCoins_003Eb__1(Pickup coin)
		{
			if ((object)coin != null && ((UnityEngine.Object)coin).m_CachedPtr != (IntPtr)0)
			{
				coin.GoToPlayer = true;
				GameManager core = GM.Core;
				GameSessionData gameSessionData = core._gameSessionData;
				coin._targetPlayer = gameSessionData._activeCharacter;
				coin.Time = 1f;
				float num = 250f - (float)i;
				coin._003CSpeed_003Ek__BackingField = num;
				float num2 = coin._003CValue_003Ek__BackingField * 10f;
				coin._003CValue_003Ek__BackingField = num2;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass109_0
	{
		public Background6 _003C_003E4__this;

		public int index;

		public List<Renderer> renderers;

		public VideoPlayerHelper videoHelper;

		internal unsafe void _003CPlayVideosAt_003Eb__0()
		{
			//IL_006e: Expected O, but got I
			//IL_00bc: Expected I, but got O
			//IL_0119: Expected O, but got I
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Expected O, but got Unknown
			//IL_019b: Expected O, but got I
			//IL_0411: Expected O, but got I4
			//IL_01bb: Expected O, but got I
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Expected O, but got Unknown
			//IL_023d: Expected O, but got I
			//IL_0179: Expected O, but got I8
			//IL_044e: Expected O, but got I4
			//IL_021b: Expected O, but got I8
			//IL_02af: Expected I, but got O
			//IL_02c5: Expected O, but got I
			//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d3: Expected O, but got Unknown
			//IL_033c: Expected I, but got O
			//IL_046b: Expected O, but got I4
			//IL_0482: Expected I, but got I8
			//IL_0325: Expected I, but got I8
			Background6 background = _003C_003E4__this;
			List<float> videoStarts = background._videoStarts;
			nint num = index;
			int num2 = index;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num2 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v6 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v3+20+v60 @ rcx_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.Background6+<>c__DisplayClass109_1>)*4]");
				float duration = 0f * 0.001f;
				List<Renderer>.Enumerator enumerator = default(List<Renderer>.Enumerator);
				TweenerCore<Color, Color, ColorOptions> tweenerCore;
				do
				{
					if (!enumerator.MoveNext())
					{
						return;
					}
					_003C_003Ec__DisplayClass109_1 obj2 = new _003C_003Ec__DisplayClass109_1();
					bool flag = obj2 == null;
					nint num3 = (nint)typeof(_003C_003Ec__DisplayClass109_1);
					DOGetter<Color> getter;
					if (!flag)
					{
						obj2.CS_0024_003C_003E8__locals1 = this;
						obj2.videoRenderer = null;
						getter = null;
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ r9_v7 (Il2CppMethodInfo)+8]");
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ r9_v7 (Il2CppMethodInfo)+4C]");
						object obj3 = (nint)0 >> 4;
						object obj4 = obj3 & 1;
						object obj5;
						if (obj4 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ r9_v7 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								obj5 = 6447965248L;
								goto IL_0408;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rax_v25 (DG.Tweening.Core.DOGetter`1<UnityEngine.Color>)+20]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rax_v25 (DG.Tweening.Core.DOGetter`1<UnityEngine.Color>)+10]");
						obj5 = 0;
						goto IL_0408;
					}
					throw new NullReferenceException();
					IL_0445:
					object obj6 = 24;
					_ = 6447743392L;
					DOSetter<Color> setter;
					tweenerCore = DOTween.ToAlpha(getter, setter, 0.5f, duration);
					TweenCallback tweenCallback = null;
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ r10_v6 (Il2CppMethodInfo)+8]");
					((Delegate)tweenCallback).method_ptr = (IntPtr)0;
					((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass109_1._003CPlayVideosAt_003Eb__3);
					((Delegate)tweenCallback).m_target = obj2;
					((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ r10_v6 (Il2CppMethodInfo)+4C]");
					object obj7 = (nint)0 >> 4;
					object obj8 = obj7 & 1;
					nint num6;
					if (obj8 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ r10_v6 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num6 = unchecked((nint)6447293664L);
							goto IL_0462;
						}
					}
					((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
					num6 = ((Delegate)tweenCallback).method_ptr;
					goto IL_0462;
					IL_0462:
					object obj9 = 24;
					((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ rax_v39 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
						if ((nint)0 == 0)
						{
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					continue;
					IL_0408:
					object obj10 = 24;
					_ = 6447965136L;
					setter = null;
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ r9_v8 (Il2CppMethodInfo)+8]");
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ r9_v8 (Il2CppMethodInfo)+4C]");
					object obj11 = (nint)0 >> 4;
					object obj12 = obj11 & 1;
					object obj13;
					if (obj12 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ r9_v8 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 1)
						{
							obj13 = 6447743504L;
							goto IL_0445;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ rax_v31 (DG.Tweening.Core.DOSetter`1<UnityEngine.Color>)+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ rax_v31 (DG.Tweening.Core.DOSetter`1<UnityEngine.Color>)+10]");
					obj13 = 0;
					goto IL_0445;
				}
				while (tweenerCore != null);
				throw new NullReferenceException();
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass109_1
	{
		public Renderer videoRenderer;

		public _003C_003Ec__DisplayClass109_0 CS_0024_003C_003E8__locals1;

		public DOGetter<Color> _003C_003E9__4;

		public DOSetter<Color> _003C_003E9__5;

		public DOGetter<Color> _003C_003E9__7;

		public DOSetter<Color> _003C_003E9__8;

		public Action _003C_003E9__10;

		public TweenCallback _003C_003E9__9;

		public TweenCallback _003C_003E9__6;

		internal unsafe Color _003CPlayVideosAt_003Eb__1()
		{
			//IL_00ce: Expected native int or pointer, but got O
			if ((object)videoRenderer != null)
			{
				Material material = videoRenderer.GetMaterial();
				if ((object)material != null)
				{
					int firstPropertyNameIdByAttribute = material.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainColor);
					int nameID = ((firstPropertyNameIdByAttribute < 0) ? Material.k_ColorId : firstPropertyNameIdByAttribute);
					Color color = default(Color);
					((Color*)(nint)color)->r = material.GetColor(nameID).r;
					return color;
				}
			}
			return (Color)new NullReferenceException();
		}

		internal unsafe void _003CPlayVideosAt_003Eb__2(Color x)
		{
			//IL_0021: Expected O, but got Ref
			Material material = videoRenderer.GetMaterial();
			object obj = default(object);
			material.color = (Color)(&obj);
		}

		internal void _003CPlayVideosAt_003Eb__3()
		{
			//IL_0072: Expected O, but got I
			//IL_00ee: Expected O, but got I
			//IL_016a: Expected O, but got I
			//IL_018c: Expected O, but got I
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Expected O, but got Unknown
			//IL_0314: Expected O, but got I
			//IL_032f: Expected O, but got I
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Expected O, but got Unknown
			//IL_03ff: Expected O, but got I8
			//IL_03ed: Expected O, but got I4
			//IL_043c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0441: Expected O, but got Unknown
			_003C_003Ec__DisplayClass109_0 obj = CS_0024_003C_003E8__locals1;
			Background6 background = obj._003C_003E4__this;
			int index = obj.index;
			List<float> videoEnds = background._videoEnds;
			int index2 = obj.index;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)index2 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj2 = 0;
				_003C_003Ec__DisplayClass109_0 obj3 = CS_0024_003C_003E8__locals1;
				Background6 background2 = obj3._003C_003E4__this;
				int index3 = obj3.index;
				List<float> videoStarts = background2._videoStarts;
				int index4 = obj3.index;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)index4 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v11 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj4 = 0;
					_003C_003Ec__DisplayClass109_0 obj5 = CS_0024_003C_003E8__locals1;
					Background6 background3 = obj5._003C_003E4__this;
					int index5 = obj5.index;
					List<int> videoBlinks = background3._videoBlinks;
					int index6 = obj5.index;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32>)+18]");
					if ((nint)index6 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32>)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v7+20+v105 @ rdx_v3 (System.Int32)*4]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v6+20+v125 @ rcx_v8 (System.Int32)*4]");
						object obj7 = num - 0;
						DOGetter<Color> getter = _003C_003E9__4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v5+20+v91 @ r9_v4 (System.Int32)*4]");
						object obj8 = obj7 / 0;
						float num2 = (float)obj8 * 0.5f;
						float duration = num2 * 0.001f;
						if (_003C_003E9__4 == null)
						{
							DOGetter<Color> dOGetter = null;
							Color color = _003CPlayVideosAt_003Eb__4();
							_003C_003E9__4 = dOGetter;
							getter = dOGetter;
						}
						DOSetter<Color> setter = _003C_003E9__5;
						if (_003C_003E9__5 == null)
						{
							DOSetter<Color> dOSetter = null;
							((_003C_003Ec__DisplayClass109_1)(object)dOSetter)._003CPlayVideosAt_003Eb__5((Color)this);
							_003C_003E9__5 = dOSetter;
							setter = dOSetter;
						}
						TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(getter, setter, 0.9f, duration);
						_003C_003Ec__DisplayClass109_0 obj9 = CS_0024_003C_003E8__locals1;
						Background6 background4 = obj9._003C_003E4__this;
						_003C_003Ec__DisplayClass109_0 obj10 = CS_0024_003C_003E8__locals1;
						int index7 = obj10.index;
						List<int> videoBlinks2 = background4._videoBlinks;
						int index8 = obj10.index;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32>)+18]");
						if ((nint)index8 < (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32>)+10]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v17+20+v120 @ rax_v17 (System.Int32)*4]");
							object obj12 = (nint)0 * (nint)2;
							object obj13 = obj12 - 2;
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
									if ((nint)0 == 0)
									{
										if ((nint)obj13 >= -1)
										{
											if (obj13 == null)
											{
												obj13 = 1;
											}
										}
										else
										{
											obj13 = 4294967295L;
										}
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
										if ((nint)0 == 0)
										{
											if ((nint)obj13 <= -1)
											{
												_ = 2139095040;
											}
											else
											{
												object obj14 = obj13;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
												object obj15 = obj14 * 0;
											}
										}
									}
								}
							}
							TweenCallback tweenCallback = _003C_003E9__6;
							if (_003C_003E9__6 == null)
							{
								tweenCallback = (_003C_003E9__6 = delegate
								{
									DOGetter<Color> getter2 = _003C_003E9__7;
									if (_003C_003E9__7 == null)
									{
										DOGetter<Color> dOGetter2 = null;
										Color color2 = _003CPlayVideosAt_003Eb__7();
										_003C_003E9__7 = dOGetter2;
										getter2 = dOGetter2;
									}
									DOSetter<Color> setter2 = _003C_003E9__8;
									if (_003C_003E9__8 == null)
									{
										DOSetter<Color> dOSetter2 = null;
										((_003C_003Ec__DisplayClass109_1)(object)dOSetter2)._003CPlayVideosAt_003Eb__8((Color)this);
										_003C_003E9__8 = dOSetter2;
										setter2 = dOSetter2;
									}
									TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTween.ToAlpha(getter2, setter2, 0f, 1f);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									TweenCallback tweenCallback2 = _003C_003E9__9;
									if (_003C_003E9__9 == null)
									{
										tweenCallback2 = (_003C_003E9__9 = delegate
										{
											GameObject gameObject = videoRenderer.gameObject;
											gameObject.SetActive(value: false);
											_003C_003Ec__DisplayClass109_0 obj16 = CS_0024_003C_003E8__locals1;
											obj16.videoHelper.Stop();
											Action onComplete = _003C_003E9__10;
											if (_003C_003E9__10 == null)
											{
												onComplete = (_003C_003E9__10 = delegate
												{
													Renderer renderer = videoRenderer;
													if ((object)videoRenderer != null && ((UnityEngine.Object)renderer).m_CachedPtr != (IntPtr)0)
													{
														GameObject gameObject2 = videoRenderer.gameObject;
														if ((object)gameObject2 != null && ((UnityEngine.Object)gameObject2).m_CachedPtr != (IntPtr)0)
														{
															GameObject gameObject3 = videoRenderer.gameObject;
															UnityEngine.Object.Destroy(gameObject3, 0f);
														}
													}
												});
											}
											bool useRealTime = default(bool);
											MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
											int repeat = default(int);
											TimerType type = default(TimerType);
											Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
										});
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
									if ((nint)0 == 0)
									{
									}
								});
							}
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								if ((nint)0 == 0)
								{
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							return;
						}
					}
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			throw new NullReferenceException();
		}

		internal unsafe Color _003CPlayVideosAt_003Eb__4()
		{
			//IL_00ce: Expected native int or pointer, but got O
			if ((object)videoRenderer != null)
			{
				Material material = videoRenderer.GetMaterial();
				if ((object)material != null)
				{
					int firstPropertyNameIdByAttribute = material.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainColor);
					int nameID = ((firstPropertyNameIdByAttribute < 0) ? Material.k_ColorId : firstPropertyNameIdByAttribute);
					Color color = default(Color);
					((Color*)(nint)color)->r = material.GetColor(nameID).r;
					return color;
				}
			}
			return (Color)new NullReferenceException();
		}

		internal unsafe void _003CPlayVideosAt_003Eb__5(Color x)
		{
			//IL_0021: Expected O, but got Ref
			Material material = videoRenderer.GetMaterial();
			object obj = default(object);
			material.color = (Color)(&obj);
		}

		internal void _003CPlayVideosAt_003Eb__6()
		{
			DOGetter<Color> getter = _003C_003E9__7;
			if (_003C_003E9__7 == null)
			{
				DOGetter<Color> dOGetter = null;
				Color color = _003CPlayVideosAt_003Eb__7();
				_003C_003E9__7 = dOGetter;
				getter = dOGetter;
			}
			DOSetter<Color> setter = _003C_003E9__8;
			if (_003C_003E9__8 == null)
			{
				DOSetter<Color> dOSetter = null;
				((_003C_003Ec__DisplayClass109_1)(object)dOSetter)._003CPlayVideosAt_003Eb__8((Color)this);
				_003C_003E9__8 = dOSetter;
				setter = dOSetter;
			}
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.ToAlpha(getter, setter, 0f, 1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			TweenCallback tweenCallback = _003C_003E9__9;
			if (_003C_003E9__9 == null)
			{
				tweenCallback = (_003C_003E9__9 = delegate
				{
					GameObject gameObject = videoRenderer.gameObject;
					gameObject.SetActive(value: false);
					_003C_003Ec__DisplayClass109_0 obj = CS_0024_003C_003E8__locals1;
					obj.videoHelper.Stop();
					Action onComplete = _003C_003E9__10;
					if (_003C_003E9__10 == null)
					{
						onComplete = (_003C_003E9__10 = delegate
						{
							Renderer renderer = videoRenderer;
							if ((object)videoRenderer != null && ((UnityEngine.Object)renderer).m_CachedPtr != (IntPtr)0)
							{
								GameObject gameObject2 = videoRenderer.gameObject;
								if ((object)gameObject2 != null && ((UnityEngine.Object)gameObject2).m_CachedPtr != (IntPtr)0)
								{
									GameObject gameObject3 = videoRenderer.gameObject;
									UnityEngine.Object.Destroy(gameObject3, 0f);
								}
							}
						});
					}
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				});
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}

		internal unsafe Color _003CPlayVideosAt_003Eb__7()
		{
			//IL_00ce: Expected native int or pointer, but got O
			if ((object)videoRenderer != null)
			{
				Material material = videoRenderer.GetMaterial();
				if ((object)material != null)
				{
					int firstPropertyNameIdByAttribute = material.GetFirstPropertyNameIdByAttribute(ShaderPropertyFlags.MainColor);
					int nameID = ((firstPropertyNameIdByAttribute < 0) ? Material.k_ColorId : firstPropertyNameIdByAttribute);
					Color color = default(Color);
					((Color*)(nint)color)->r = material.GetColor(nameID).r;
					return color;
				}
			}
			return (Color)new NullReferenceException();
		}

		internal unsafe void _003CPlayVideosAt_003Eb__8(Color x)
		{
			//IL_0021: Expected O, but got Ref
			Material material = videoRenderer.GetMaterial();
			object obj = default(object);
			material.color = (Color)(&obj);
		}

		internal void _003CPlayVideosAt_003Eb__9()
		{
			GameObject gameObject = videoRenderer.gameObject;
			gameObject.SetActive(value: false);
			_003C_003Ec__DisplayClass109_0 obj = CS_0024_003C_003E8__locals1;
			obj.videoHelper.Stop();
			Action onComplete = _003C_003E9__10;
			if (_003C_003E9__10 == null)
			{
				onComplete = (_003C_003E9__10 = delegate
				{
					Renderer renderer = videoRenderer;
					if ((object)videoRenderer != null && ((UnityEngine.Object)renderer).m_CachedPtr != (IntPtr)0)
					{
						GameObject gameObject2 = videoRenderer.gameObject;
						if ((object)gameObject2 != null && ((UnityEngine.Object)gameObject2).m_CachedPtr != (IntPtr)0)
						{
							GameObject gameObject3 = videoRenderer.gameObject;
							UnityEngine.Object.Destroy(gameObject3, 0f);
						}
					}
				});
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}

		internal void _003CPlayVideosAt_003Eb__10()
		{
			Renderer renderer = videoRenderer;
			if ((object)videoRenderer != null && ((UnityEngine.Object)renderer).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject = videoRenderer.gameObject;
				if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
				{
					GameObject gameObject2 = videoRenderer.gameObject;
					UnityEngine.Object.Destroy(gameObject2, 0f);
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass65_0
	{
		public string key;

		public Background6 _003C_003E4__this;

		internal void _003CCreate_003Eb__0(VideoClip vc)
		{
			Background6 background = _003C_003E4__this;
			bool flag = ((Dictionary<object, object>)(object)background._videoClips).TryInsert((object)key, (object)vc, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
	}

	private sealed class _003C_003Ec__DisplayClass84_0
	{
		public Background6 _003C_003E4__this;

		public float startUIZoom;

		public TweenCallback _003C_003E9__1;

		public Action _003C_003E9__3;

		public Action _003C_003E9__4;

		internal void _003CStartZoomingOut_003Eb__1()
		{
			//IL_009c: Expected O, but got I
			//IL_01d7->IL0176: Incompatible stack heights: 1 vs 0
			//IL_00f5->IL0176: Incompatible stack heights: 1 vs 0
			//IL_0117->IL0176: Incompatible stack heights: 1 vs 0
			//IL_0149->IL0176: Incompatible stack heights: 1 vs 0
			//IL_0167->IL0176: Incompatible stack heights: 1 vs 0
			Background6 background = _003C_003E4__this;
			if ((object)_003C_003E4__this != null && (object)background._mainCamera != null)
			{
				background._mainCamera.orthographicSize = background._OriginalZoom;
				object obj = _003C_003E4__this;
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v6 (System.Object)+1C0]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v6 (System.Object)+1C0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdi_v7 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdi_v7 (System.Object)+10]");
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected((IntPtr)0, ref value);
						Background6 background2 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null)
						{
							FakeTilingBackground tilingBg = background2._tilingBg;
							if ((object)background2._tilingBg != null && (object)tilingBg._bgTile != null)
							{
								Transform transform = tilingBg._bgTile.transform;
								if ((object)_003C_003E4__this != null && (object)transform != null)
								{
									bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Vector3 value2 = default(Vector3);
									Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
									return;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CStartZoomingOut_003Eb__2()
		{
			Background6 background = _003C_003E4__this;
			if ((object)_003C_003E4__this != null && (object)background._mainCamera != null)
			{
				background._mainCamera.orthographicSize = background._OriginalZoom;
				Background6 background2 = _003C_003E4__this;
				if ((object)_003C_003E4__this != null)
				{
					object mainUIView = background2._mainUIView;
					if ((object)background2._mainUIView != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v5 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v5 (System.Object)+10]");
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected((IntPtr)0, ref value);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CStartZoomingOut_003Eb__0()
		{
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Expected O, but got Unknown
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected O, but got Unknown
			GameManager core = GM.Core;
			PlayerOptions playerOptions = core._playerOptions;
			core._playerOptions.TrackEnemyKill(EnemyType.DIRECTER, playerOptions._mainGameConfig);
			GameManager core2 = GM.Core;
			PlayerOptions playerOptions2 = core2._playerOptions;
			PlayerOptionsData mainGameConfig = playerOptions2._mainGameConfig;
			bool flag = default(bool);
			Action onComplete;
			if (mainGameConfig._003CHasSeenFinalFireworks_003Ek__BackingField)
			{
				GameManager core3 = GM.Core;
				PlayerOptions playerOptions3 = core3._playerOptions;
				PlayerOptionsData mainGameConfig2 = playerOptions3._mainGameConfig;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B0B0");
				object obj = default(object);
				if (obj != null)
				{
					GameManager core4 = GM.Core;
					core4._playerOptions.Save();
					GameManager core5 = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj3 = default(object);
					object obj2 = obj3 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					Type signalType = default(Type);
					core5._signalBus.InternalFire(signalType, (object)null, (object)null, flag);
					onComplete = _003C_003E9__3;
					if (_003C_003E9__3 == null)
					{
						onComplete = (_003C_003E9__3 = delegate
						{
							Background6 background = _003C_003E4__this;
							background._mainCamera.orthographicSize = startUIZoom;
						});
					}
					goto IL_0186;
				}
			}
			GameManager core6 = GM.Core;
			core6._playerOptions.Save();
			GameManager core7 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj5 = default(object);
			object obj4 = obj5 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType2 = default(Type);
			core7._signalBus.InternalFire(signalType2, (object)null, (object)null, flag);
			onComplete = _003C_003E9__4;
			if (_003C_003E9__4 == null)
			{
				onComplete = (_003C_003E9__4 = delegate
				{
					Background6 background = _003C_003E4__this;
					background._mainCamera.orthographicSize = startUIZoom;
				});
			}
			goto IL_0186;
			IL_0186:
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			Timer timer = TimerHelper.RegisterMillisUI(50f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat);
		}

		internal void _003CStartZoomingOut_003Eb__3()
		{
			Background6 background = _003C_003E4__this;
			background._mainCamera.orthographicSize = startUIZoom;
		}

		internal void _003CStartZoomingOut_003Eb__4()
		{
			Background6 background = _003C_003E4__this;
			background._mainCamera.orthographicSize = startUIZoom;
		}
	}

	private sealed class _003C_003Ec__DisplayClass87_0
	{
		public int index;

		public Background6 _003C_003E4__this;

		internal void _003CStartGifts_003Eb__0()
		{
			//IL_0010: Expected O, but got I4
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected I4, but got Unknown
			object obj = index - 30;
			int num = index ^ 0x1E;
			int num2 = index ^ obj;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = obj == null;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			bool isRandomColor = flag5 & flag4;
			_003C_003E4__this.SendGem(isCluster: true, isRandomColor);
		}
	}

	private sealed class _003C_003Ec__DisplayClass87_1
	{
		public int index;

		public Background6 _003C_003E4__this;

		internal void _003CStartGifts_003Eb__1()
		{
			//IL_0010: Expected O, but got I4
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected I4, but got Unknown
			object obj = index - 20;
			int num = index ^ 0x14;
			int num2 = index ^ obj;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = obj == null;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			bool isRandomType = flag5 & flag4;
			_003C_003E4__this.SendCoins(isRandomType);
		}
	}

	private sealed class _003C_003Ec__DisplayClass89_0
	{
		public Background6 _003C_003E4__this;

		public float rendererWidth;

		internal void _003CPlayVideos_003Eb__0()
		{
			List<Vector2> list = new List<Vector2>();
			Vector2 item = default(Vector2);
			list.Add(item);
			list.Add(item);
			_003C_003E4__this.PlayVideosAt(1, list);
		}

		internal void _003CPlayVideos_003Eb__1()
		{
			List<Vector2> list = new List<Vector2>();
			Vector2 item = default(Vector2);
			list.Add(item);
			list.Add(item);
			_003C_003E4__this.PlayVideosAt(2, list);
		}

		internal void _003CPlayVideos_003Eb__2()
		{
			List<Vector2> list = new List<Vector2>();
			Vector2 item = default(Vector2);
			list.Add(item);
			list.Add(item);
			list.Add(item);
			_003C_003E4__this.PlayVideosAt(0, list);
		}

		internal void _003CPlayVideos_003Eb__3()
		{
			List<Vector2> list = new List<Vector2>();
			Vector2 item = default(Vector2);
			list.Add(item);
			list.Add(item);
			_003C_003E4__this.PlayVideosAt(1, list);
		}

		internal void _003CPlayVideos_003Eb__4()
		{
			List<Vector2> list = new List<Vector2>();
			Vector2 item = default(Vector2);
			list.Add(item);
			list.Add(item);
			list.Add(item);
			_003C_003E4__this.PlayVideosAt(0, list);
		}

		internal void _003CPlayVideos_003Eb__5()
		{
			List<Vector2> list = new List<Vector2>();
			Vector2 item = default(Vector2);
			list.Add(item);
			list.Add(item);
			_003C_003E4__this.PlayVideosAt(2, list);
		}

		internal void _003CPlayVideos_003Eb__6()
		{
			List<Vector2> list = new List<Vector2>();
			Vector2 item = default(Vector2);
			list.Add(item);
			list.Add(item);
			list.Add(item);
			_003C_003E4__this.PlayVideosAt(0, list);
		}
	}

	private sealed class _003C_003Ec__DisplayClass93_0
	{
		public SpriteRenderer s;

		public int index;

		public TweenCallback _003C_003E9__2;

		internal void _003CRemovePowers_003Eb__0()
		{
			s.enabled = true;
		}

		internal unsafe void _003CRemovePowers_003Eb__1()
		{
			//IL_0026: Expected O, but got Ref
			Transform transform = s.transform;
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, (Vector3)(&obj), 0.5f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			float num = (float)index + 1100f;
			float delay = num * 0.001f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(tweenerCore, delay);
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					s.enabled = false;
				});
			}
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CRemovePowers_003Eb__2()
		{
			s.enabled = false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass94_0
	{
		public Background6 _003C_003E4__this;

		public float number;

		internal unsafe void _003CSnapEggs_003Eb__0()
		{
			//IL_0072: Expected O, but got I4
			//IL_06a0: Invalid comparison between F4 and I4
			//IL_06b2: Expected F4, but got I4
			//IL_06c4: Expected O, but got I4
			//IL_012c: Expected O, but got I4
			//IL_013f: Expected F4, but got I4
			//IL_0151: Expected O, but got I4
			//IL_06db: Expected O, but got F4
			//IL_097e: Expected O, but got F4
			//IL_056e: Expected I, but got O
			//IL_05d8: Expected O, but got I4
			//IL_0294: Expected I, but got O
			//IL_0336: Expected I, but got O
			//IL_07da: Expected O, but got F4
			//IL_080d: Expected O, but got I4
			//IL_03e5: Expected O, but got I
			//IL_0403: Expected O, but got I4
			//IL_083f: Expected O, but got F4
			//IL_086d: Expected O, but got I4
			//IL_098c: Expected O, but got F4
			//IL_087f: Expected I, but got O
			//IL_0895: Expected O, but got I
			//IL_089e: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a3: Expected O, but got Unknown
			//IL_0454: Expected I, but got O
			//IL_08c9: Expected O, but got I4
			//IL_08e0: Expected I, but got I8
			//IL_08f6: Expected O, but got I4
			//IL_048b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0490: Expected O, but got Unknown
			//IL_049a: Invalid comparison between F4 and O
			//IL_04d3: Expected O, but got I4
			//IL_043d: Expected I, but got I8
			//IL_0522->IL062b: Incompatible stack heights: 1 vs 0
			//IL_053f->IL062b: Incompatible stack heights: 1 vs 0
			//IL_05b3->IL062b: Incompatible stack heights: 1 vs 0
			//IL_0591->IL0591: Incompatible stack heights: 2 vs 1
			//IL_06fa->IL062b: Incompatible stack heights: 1 vs 0
			//IL_01b0->IL062b: Incompatible stack heights: 1 vs 0
			//IL_0754->IL062b: Incompatible stack heights: 2 vs 0
			//IL_01e4->IL062b: Incompatible stack heights: 2 vs 0
			//IL_0218->IL062b: Incompatible stack heights: 2 vs 0
			//IL_0264->IL062b: Incompatible stack heights: 2 vs 0
			//IL_02b8->IL02b8: Incompatible stack heights: 3 vs 2
			//IL_031c->IL062b: Incompatible stack heights: 3 vs 0
			//IL_0353->IL0353: Incompatible stack heights: 5 vs 4
			//IL_07cc->IL062b: Incompatible stack heights: 5 vs 0
			//IL_03be->IL062b: Incompatible stack heights: 5 vs 0
			//IL_0831->IL062b: Incompatible stack heights: 5 vs 0
			//IL_04dc->IL08fb: Incompatible stack heights: 5 vs 1
			//IL_04e1->IL04e1: Incompatible stack heights: 5 vs 1
			Background6 background = _003C_003E4__this;
			if ((object)_003C_003E4__this != null && (object)background._snapAnimation != null)
			{
				background._snapAnimation.SetAnimation("snap_do");
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Detune = 1000f;
				soundConfig.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.BGM_GameOver, soundConfig, 0f, 10, time);
				Background6 background2 = _003C_003E4__this;
				if ((object)_003C_003E4__this != null && (object)background2._mainCamera != null)
				{
					Transform transform = background2._mainCamera.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						float num = number;
						bool flag2 = !(number > 0f);
						float num2 = 0f;
						int num3 = 10;
						object obj = 0;
						if (!flag2)
						{
							object obj3 = default(object);
							object obj2 = obj3;
							object obj4 = 0;
							float num4 = number;
							float num5 = 0f;
							int num6 = 10;
							object obj5 = 0;
							Vector2 pos = default(Vector2);
							object obj9 = default(object);
							bool flag10;
							do
							{
								bool flag3 = (nint)obj4 >= 500;
								obj3 = obj2;
								num = num4;
								num2 = num5;
								num3 = num6;
								obj = obj5;
								if (flag3)
								{
									break;
								}
								_003C_003Ec__DisplayClass94_1 obj6 = new _003C_003Ec__DisplayClass94_1();
								object obj7 = UnityEngine.Random.value;
								object obj8 = UnityEngine.Random.value;
								TweenConfig tweenConfig;
								TweenCallback tweenCallback;
								if ((object)_003C_003E4__this != null)
								{
									GameObject gameObject = _003C_003E4__this.gameObject;
									SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, pos, "items", "goldenegg");
									if ((object)spriteRenderer != null)
									{
										bool flag4 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
										Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, 9000);
										Background6 background3 = _003C_003E4__this;
										if ((object)_003C_003E4__this != null)
										{
											Transform transform2 = spriteRenderer.transform;
											if ((object)transform2 != null)
											{
												transform2.SetParent(background3._spritesRootTransform, worldPositionStays: true);
												if (obj6 != null)
												{
													obj6.s = spriteRenderer;
													tweenConfig = new TweenConfig();
													object[] array = new object[2];
													if (array != null)
													{
														if ((object)obj6.s != null)
														{
															nint num7 = (nint)array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															bool flag5 = obj9 == null;
														}
														bool flag6 = array.Length <= 0;
														array[0] = obj6.s;
														Transform s = (Transform)(object)obj6.s;
														if ((object)obj6.s != null)
														{
															bool flag7 = ((UnityEngine.Object)s).m_CachedPtr == (IntPtr)0;
															IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)s).m_CachedPtr);
															Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
															if ((object)transform3 != null)
															{
																Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform3);
																bool flag8 = (object)transform4 == null;
															}
															bool flag9 = array.Length <= 1;
															array[1] = transform3;
															if (tweenConfig != null)
															{
																tweenConfig.targets = array;
																Background6 background4 = _003C_003E4__this;
																if ((object)_003C_003E4__this != null)
																{
																	object obj10 = UnityEngine.Random.value;
																	float num8 = (float)background4._camBounds * 48f;
																	float num9 = num8 * 0.01f;
																	tweenConfig.x = (float?)(object)1;
																	Background6 background5 = _003C_003E4__this;
																	if ((object)_003C_003E4__this != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2393 @ rcx_v95 (VampireSurvivors.Objects.Stages.Background6)+34]");
																		nint num10 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2393 @ rcx_v95 (VampireSurvivors.Objects.Stages.Background6)+40]");
																		object obj11 = num10 - 0;
																		num2 = (float)obj11 + 0.32f;
																		tweenConfig.y = (float?)(object)1;
																		object obj12 = UnityEngine.Random.value;
																		float num11 = num9 * 180f;
																		float num12 = num11 + 180f;
																		tweenConfig.angle = (float?)(object)1;
																		object obj13 = UnityEngine.Random.value;
																		float num13 = num12 * 300f;
																		tweenConfig.ease = Ease.InCirc;
																		float duration = num13 + 300f;
																		tweenConfig.duration = duration;
																		float delay = (float)obj4 * 10f;
																		tweenConfig.delay = delay;
																		tweenCallback = null;
																		nint num14 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																		num3 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ r10_v19 (Il2CppMethodInfo)+8]");
																		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
																		((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass94_1._003CSnapEggs_003Eb__1);
																		((Delegate)tweenCallback).m_target = obj6;
																		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ r10_v19 (Il2CppMethodInfo)+4C]");
																		object obj14 = (nint)0 >> 4;
																		object obj15 = obj14 & 1;
																		nint num15;
																		if (obj15 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ r10_v19 (Il2CppMethodInfo)+52]");
																			if ((nint)0 == 0)
																			{
																				num15 = unchecked((nint)6447293664L);
																				goto IL_08c0;
																			}
																		}
																		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
																		num15 = ((Delegate)tweenCallback).method_ptr;
																		goto IL_08c0;
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
								goto IL_062b;
								IL_08c0:
								object obj16 = 24;
								((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
								tweenConfig.onComplete = tweenCallback;
								obj = 24;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								num = number;
								obj4++;
								float num16 = number;
								flag10 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num16) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
								obj3 = obj4;
								obj2 = obj4;
								num4 = number;
								num5 = num2;
								num6 = num3;
								obj5 = 24;
							}
							while (flag10);
						}
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						Background6 background6 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null && array2 != null)
						{
							if ((object)background6._snap != null)
							{
								nint num17 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj17 = default(object);
								bool flag11 = obj17 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig2 != null)
							{
								tweenConfig2.targets = array2;
								tweenConfig2.alpha = (float?)(object)1;
								tweenConfig2.duration = 300f;
								float num18 = number;
								if (!(500f > number))
								{
									num18 = 500f;
								}
								float num19 = num18 * 10f;
								float delay2 = num19 + 600f;
								tweenConfig2.delay = delay2;
								MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
								return;
							}
						}
					}
				}
			}
			goto IL_062b;
			IL_062b:
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass94_1
	{
		public SpriteRenderer s;

		internal void _003CSnapEggs_003Eb__1()
		{
			GameObject gameObject = s.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
		}
	}

	private sealed class _003CEnterPhase5PostShatterAnimation_003Ed__80(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Background6 _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0263: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_022b: Expected I4, but got I8
			//IL_0052: Expected I4, but got I8
			//IL_029a: Expected I4, but got O
			//IL_00d3: Expected O, but got I4
			Background6 background = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj == 1)
					{
						_003C_003E1__state = -1;
						if ((object)_003C_003E4__this != null)
						{
							TweenConfig tweenConfig = new TweenConfig();
							if (background._windows != null)
							{
								PhaserSprite[] targets = background._windows.ToArray();
								if (tweenConfig != null)
								{
									tweenConfig.targets = targets;
									tweenConfig.duration = 1000f;
									tweenConfig.scaleX = (float?)(object)1;
									MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
									GameManager core = GM.Core;
									if ((object)GM.Core != null && core._signalBus != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA53D0");
										if ((object)GM.Core != null)
										{
											GM.Core.TogglePlayerHealthBar(visible: false);
											_003C_003E4__this.SpawnFakePlayerUILevelUp(0f, 0f);
											_003C_003E4__this.SpawnFakePlayerUILevelUp(8f, 64f);
											_003C_003E4__this.SpawnFakePlayerUILevelUp(16f, 48f);
											_003C_003E4__this.SpawnFakePlayerUILevelUp(8f, 32f);
											_003C_003E4__this.SpawnFakePlayerUILevelUp(-16f, 16f);
											_003C_003E4__this.SpawnFakePlayerUILevelUp(-32f, 80f);
											_003C_003E4__this.RemoveColorBg();
											_003C_003E4__this.PlayVideos();
											_003C_003E4__this.StartGifts();
											_003C_003E4__this.MakeThrowingHands();
											_003C_003E4__this.StartZoomingOut();
											goto IL_0216;
										}
									}
								}
							}
						}
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					goto IL_0216;
				}
				_003C_003E1__state = -1;
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E1__state = -1;
			WaitForEndOfFrame waitForEndOfFrame2 = new WaitForEndOfFrame();
			_003C_003E2__current = waitForEndOfFrame2;
			_003C_003E1__state = 1;
			return true;
			IL_0216:
			return false;
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

	private sealed class _003CShatterImageRoutine_003Ed__100(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Background6 _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_006e: Expected I4, but got I8
			//IL_01eb: Expected I4, but got O
			//IL_011f: Expected O, but got I4
			//IL_0189: Expected O, but got Ref
			Background6 background = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)background._mainCamera != null)
				{
					RenderTexture targetTexture = background._mainCamera.targetTexture;
					if ((object)targetTexture != null)
					{
						int width = targetTexture.width;
						int height = targetTexture.height;
						int mipCount = default(int);
						bool linear = default(bool);
						IntPtr nativeTex = default(IntPtr);
						bool createUninitialized = default(bool);
						Texture2D capturedScreenshot = new Texture2D(width, height, TextureFormat.ARGB32, mipCount, linear, nativeTex, createUninitialized, (MipmapLimitDescriptor)1);
						background._capturedScreenshot = capturedScreenshot;
						RenderTexture.SetActive(targetTexture);
						int width2 = targetTexture.width;
						int height2 = targetTexture.height;
						if ((object)background._capturedScreenshot != null)
						{
							object obj = default(object);
							background._capturedScreenshot.ReadPixels((Rect)(&obj), 0, 0);
							if ((object)background._capturedScreenshot != null)
							{
								background._capturedScreenshot.Apply(updateMipmaps: true, makeNoLongerReadable: false);
								background._hasCaptureScreenshot = true;
								return false;
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
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

	private DirecterManager _directerManager;

	private GameObject _fakePlayerUiLevelUpPrefab;

	private bool _hasMirror;

	private bool _hasTrumpet;

	private bool _hasJubilee;

	private bool _canContinueStageZoom;

	private float _colorBgValue;

	private Transform _spritesRootTransform;

	private PhaserSprite _snap;

	private SpriteAnimation _snapAnimation;

	private PhaserSprite _sSunCircle;

	private PhaserSprite _sMoonCircle;

	private PhaserSprite _sWorldCircle;

	private PhaserSprite _sCentralCircle;

	private PhaserSprite _sunCircle;

	private PhaserSprite _moonCircle;

	private PhaserSprite _worldCircle;

	private PhaserSprite _centralCircle;

	private PhaserSprite _colorBg;

	private List<PhaserSprite> _windows;

	private FakeTilingBackground _tilingBg;

	private MultiTargetTween _sunCircleTween;

	private MultiTargetTween _moonCircleTween;

	private MultiTargetTween _worldCircleTween;

	private MultiTargetTween _stageZoomTween;

	private Timer _colorBgTimer;

	private ParticleEmitterManager _pfxEmitter;

	private ParticleSystem _pfxFire1;

	private ParticleSystem _pfxFire2;

	private ParticleSystem _pfxFireRed1;

	private ParticleSystem _pfxFireRed2;

	private ShatterVFX _shatterVfx;

	private Texture2D _capturedScreenshot;

	private bool _hasCaptureScreenshot;

	private SpriteRenderer _shatterVfxRenderer;

	private float _shatterGlobalScale;

	private Tween[] _shatterMoveTweens;

	private Tween[] _shatterAngleTweens;

	private Tween[] _shatterAlphaTweens;

	private Pickup _pickupDirecter;

	private EnemyDirecter _directer;

	private int _stageKeyIndex;

	private List<string> _stageKeys;

	public float _OriginalZoom;

	public float _OriginalUIZoom;

	private RectTransform _mainUIView;

	private GameObject _videoPlayerPrefab;

	private Dictionary<string, VideoClip> _videoClips;

	private List<string> _videoKeys;

	private List<float> _videoStarts;

	private List<float> _videoEnds;

	private List<int> _videoBlinks;

	private List<VideoPlayerHelper> _videoPlayerHelpers;

	private VideoPlaybackManager _videoPlaybackManager;

	public EnemyDirecter Directer => _directer;

	public ParticleSystem PfxFire1 => _pfxFire1;

	public ParticleSystem PfxFire2 => _pfxFire2;

	private DirecterManager DirecterMan => _directerManager;

	protected override void OnDestroy()
	{
		base.OnDestroy();
		_sunCircleTween.Kill();
		_moonCircleTween.Kill();
		_worldCircleTween.Kill();
		if (_colorBgTimer != null)
		{
			_colorBgTimer.Cancel();
		}
		GameManager.SfxVolumeFactor = 1f;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		stage._003CStopCheckingMinutes_003Ek__BackingField = false;
		DirecterManager directerManager = _directerManager;
		if (_directerManager != null)
		{
			AudioSource currentBgm = directerManager._currentBgm;
			if ((object)directerManager._currentBgm != null && ((UnityEngine.Object)currentBgm).m_CachedPtr != (IntPtr)0)
			{
				directerManager._currentBgm.Stop();
			}
		}
		if (_videoPlaybackManager != null)
		{
			_videoPlaybackManager.Cleanup();
		}
		Action<EnemyController> value = OnRemoteEnemySpawned;
		Delegate obj = Delegate.Remove(EnemyInstantiator.OnRemoteEnemySpawned, value);
		if ((object)obj == null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = (Action<EnemyController>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<EnemyController> action = default(Action<EnemyController>);
			if (action == null)
			{
				throw new InvalidCastException();
			}
			EnemyInstantiator.OnRemoteEnemySpawned = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				throw new InvalidCastException();
			}
		}
		Action<Pickup> value2 = OnRemoteItemInstantiated;
		Delegate obj3 = Delegate.Remove(ItemInstantiator.OnRemoteItemInstantiated, value2);
		if ((object)obj3 == null)
		{
			ItemInstantiator.OnRemoteItemInstantiated = (Action<Pickup>)obj3;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<Pickup> action2 = default(Action<Pickup>);
		if (action2 != null)
		{
			ItemInstantiator.OnRemoteItemInstantiated = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	protected override void OnUpdate()
	{
		//IL_04ed: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_0219: Expected O, but got I4
		//IL_0222: Expected O, but got I4
		//IL_05b0: Expected O, but got F4
		//IL_02e5: Expected O, but got I4
		//IL_0363: Expected O, but got I4
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Expected O, but got Unknown
		//IL_03e1: Expected O, but got I4
		//IL_045f: Expected O, but got I4
		base.OnUpdate();
		bool flag = !_hasCaptureScreenshot;
		object obj = 0;
		if (!flag)
		{
			Shatter();
			_hasCaptureScreenshot = false;
			obj = 0;
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.width / 1.28f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
		float num2 = num + 1f;
		float num3 = num2 * 1.28f;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num4 = renderer2.height / 3.58f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
		float num5 = num4 + 1f;
		float num6 = num5 * 3.58f;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		PhaserScene s_scene4 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer4 = s_scene4._renderer;
		float num7 = renderer4.width * 0.5f;
		float num8 = (float)renderer3.screenCenter - num7;
		PhaserScene s_scene5 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer5 = s_scene5._renderer;
		float num9 = renderer5.width * 0.5f;
		float num10 = num9 + (float)renderer3.screenCenter;
		PhaserScene s_scene6 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer6 = s_scene6._renderer;
		float num11 = renderer6.height * 0.5f;
		float num12 = num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v27 (PhaserScene+Renderer)+38]");
		float num13 = num12 + 0f;
		PhaserScene s_scene7 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer7 = s_scene7._renderer;
		List<PhaserSprite> windows = _windows;
		float num14 = renderer7.height * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v27 (PhaserScene+Renderer)+38]");
		float num15 = 0f - num14;
		object obj2 = 0;
		object obj3 = 0;
		while ((nint)obj3 < windows._size)
		{
			List<PhaserSprite> windows2 = _windows;
			if ((nint)obj2 < windows2._size)
			{
				PhaserSprite[] items = windows2._items;
				float x = items[obj2].X;
				if (num8 > x)
				{
					float x2 = items[obj2].X;
					float x3 = x2 + num3;
					items[obj2].X = x3;
					object obj4 = 0;
				}
				float x4 = items[obj2].X;
				if (x4 > num10)
				{
					float x5 = items[obj2].X;
					float x6 = x5 - num3;
					items[obj2].X = x6;
					object obj4 = 0;
				}
				float y = items[obj2].Y;
				if (y > num13)
				{
					float y2 = items[obj2].Y;
					float y3 = y2 - num6;
					items[obj2].Y = y3;
					object obj4 = 0;
				}
				num14 = items[obj2].Y;
				if (num15 > num14)
				{
					float y4 = items[obj2].Y;
					num14 = y4 + num6;
					items[obj2].Y = num14;
					object obj4 = 0;
				}
				windows = _windows;
				obj2++;
				obj3 = obj2;
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
		if (_directerManager != null)
		{
			if (PauseSystem._paused)
			{
				_directerManager.Update(0f);
				return;
			}
			object obj5 = Time.deltaTime;
			_directerManager.Update(num14);
		}
	}

	public DirecterManager GetDirecterManager()
	{
		return _directerManager;
	}

	public override void Create()
	{
		//IL_0123: Expected O, but got I4
		//IL_012c: Expected O, but got I4
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Expected O, but got Unknown
		//IL_01fc: Expected O, but got I4
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Expected O, but got Unknown
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_068f: Expected O, but got Unknown
		//IL_0f9e: Expected F4, but got I4
		base.Create();
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			Action<EnemyController> b = OnRemoteEnemySpawned;
			Delegate obj = Delegate.Combine(EnemyInstantiator.OnRemoteEnemySpawned, b);
			if ((object)obj == null)
			{
				EnemyInstantiator.OnRemoteEnemySpawned = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<EnemyController> action = default(Action<EnemyController>);
				if (action == null)
				{
					throw new InvalidCastException();
				}
				EnemyInstantiator.OnRemoteEnemySpawned = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
			Action<Pickup> b2 = OnRemoteItemInstantiated;
			Delegate obj3 = Delegate.Combine(ItemInstantiator.OnRemoteItemInstantiated, b2);
			if ((object)obj3 == null)
			{
				ItemInstantiator.OnRemoteItemInstantiated = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<Pickup> action2 = default(Action<Pickup>);
				if (action2 == null)
				{
					throw new InvalidCastException();
				}
				ItemInstantiator.OnRemoteItemInstantiated = action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					throw new InvalidCastException();
				}
			}
		}
		GameObject fakePlayerUiLevelUpPrefab = Resources.Load<GameObject>("FakePlayerUILevelUp");
		_fakePlayerUiLevelUpPrefab = fakePlayerUiLevelUpPrefab;
		GameObject videoPlayerPrefab = Resources.Load<GameObject>("VideoPlayer");
		_videoPlayerPrefab = videoPlayerPrefab;
		List<string> videoKeys = _videoKeys;
		DlcType? dlcType = (DlcType?)(object)0;
		DlcType? dlcType2 = (DlcType?)(object)0;
		bool flag = default(bool);
		Vector2 pos = default(Vector2);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		object obj6 = default(object);
		object obj8 = default(object);
		object obj10 = default(object);
		while (true)
		{
			if ((nint)dlcType2 < videoKeys._size)
			{
				_003C_003Ec__DisplayClass65_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass65_0();
				CS_0024_003C_003E8__locals5._003C_003E4__this = this;
				List<string> videoKeys2 = _videoKeys;
				if ((nint)dlcType >= videoKeys2._size)
				{
					break;
				}
				string[] items = videoKeys2._items;
				CS_0024_003C_003E8__locals5.key = items[(object)dlcType];
				Action<VideoClip> onComplete = delegate(VideoClip vc)
				{
					Background6 background = CS_0024_003C_003E8__locals5._003C_003E4__this;
					bool flag5 = ((Dictionary<object, object>)(object)background._videoClips).TryInsert((object)CS_0024_003C_003E8__locals5.key, (object)vc, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				};
				VideoLoader.LoadVideoInternal(CS_0024_003C_003E8__locals5.key, "Gameplay", (DlcType?)(object)0, onComplete, flag);
				videoKeys = _videoKeys;
				dlcType = (DlcType?)(object)((_003F?)dlcType + 1);
				dlcType2 = dlcType;
				continue;
			}
			CacheVideoHelpers();
			GameManager core2 = GM.Core;
			PlayerOptions playerOptions = core2._playerOptions;
			PlayerOptionsData playerOptionsData;
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig == null)
				{
					if (playerOptions._currentAdventureSaveData != null)
					{
						PlayerOptionsData currentAdventureSaveData = playerOptions._currentAdventureSaveData;
						if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							playerOptionsData = currentAdventureSaveData;
							goto IL_147b;
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
			goto IL_147b;
			IL_1270:
			PlayerOptionsData playerOptionsData2;
			playerOptionsData2._003CSelectedHurry_003Ek__BackingField = false;
			GameManager core3 = GM.Core;
			PlayerOptions playerOptions2 = core3._playerOptions;
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
							goto IL_12b1;
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
			goto IL_12b1;
			IL_13b5:
			PlayerOptionsData playerOptionsData4;
			playerOptionsData4._003CSelectedRandomEvents_003Ek__BackingField = false;
			if (!_hasMirror || !_hasTrumpet || _hasJubilee)
			{
				goto IL_13e2;
			}
			GameManager core4 = GM.Core;
			PlayerOptions playerOptions3 = core4._playerOptions;
			PlayerOptionsData playerOptionsData5;
			if (playerOptions3._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions3._hostGameConfig == null)
				{
					if (playerOptions3._currentAdventureSaveData != null)
					{
						playerOptionsData5 = playerOptions3._currentAdventureSaveData;
						if ((object)playerOptionsData5._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_1412;
						}
					}
					playerOptionsData5 = playerOptions3._mainGameConfig;
				}
				else
				{
					playerOptionsData5 = playerOptions3._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData5 = playerOptions3._onlineClientWithRunDataConfig;
			}
			goto IL_1412;
			IL_1333:
			PlayerOptionsData playerOptionsData6;
			playerOptionsData6._003CSelectedInverse_003Ek__BackingField = false;
			GameManager core5 = GM.Core;
			PlayerOptions playerOptions4 = core5._playerOptions;
			PlayerOptionsData playerOptionsData7;
			if (playerOptions4._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions4._hostGameConfig == null)
				{
					if (playerOptions4._currentAdventureSaveData != null)
					{
						playerOptionsData7 = playerOptions4._currentAdventureSaveData;
						if ((object)playerOptionsData7._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_1374;
						}
					}
					playerOptionsData7 = playerOptions4._mainGameConfig;
				}
				else
				{
					playerOptionsData7 = playerOptions4._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData7 = playerOptions4._onlineClientWithRunDataConfig;
			}
			goto IL_1374;
			IL_1374:
			playerOptionsData7._003CSelectedReapers_003Ek__BackingField = false;
			GameManager core6 = GM.Core;
			PlayerOptions playerOptions5 = core6._playerOptions;
			if (playerOptions5._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions5._hostGameConfig == null)
				{
					if (playerOptions5._currentAdventureSaveData != null)
					{
						playerOptionsData4 = playerOptions5._currentAdventureSaveData;
						if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_13b5;
						}
					}
					playerOptionsData4 = playerOptions5._mainGameConfig;
				}
				else
				{
					playerOptionsData4 = playerOptions5._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData4 = playerOptions5._onlineClientWithRunDataConfig;
			}
			goto IL_13b5;
			IL_13e2:
			GenerateFakeTilingBackground();
			float num = (float)CameraExtensions.OrthographicBounds(_mainCamera).m_Extents * 2f;
			Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3070 @ rax_v74 (UnityEngine.Bounds)+10]");
			float num2 = 0f * 2f;
			if (!(num2 > num))
			{
				num = num2;
			}
			float num3 = num * 100f;
			float num4 = num3 * 0.8f;
			float shatterGlobalScale = num4 * 0.00390625f;
			_shatterGlobalScale = shatterGlobalScale;
			RemovePowerUps();
			SnapEggs();
			MakeCircles();
			MakeFireEmitters();
			MakeWindows();
			Pickup pickupDirecter = GM.Core.MakeStagePickup(pos, ItemType.DIRECTER, WeaponType.VOID, flag ? 1 : 0, relicType, validatePickups);
			_pickupDirecter = pickupDirecter;
			SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
			DirecterManager directerManager = new DirecterManager(this);
			_directerManager = directerManager;
			MainGamePage mainGamePage = UnityEngine.Object.FindObjectOfType<MainGamePage>(includeInactive: true);
			RectTransform component = mainGamePage.GetComponent<RectTransform>();
			_mainUIView = component;
			GameManager core7 = GM.Core;
			_tilingBg.MakeBackground("dummy1", core7._stage);
			return;
			IL_122f:
			PlayerOptionsData playerOptionsData8;
			playerOptionsData8._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
			GameManager core8 = GM.Core;
			PlayerOptions playerOptions6 = core8._playerOptions;
			if (playerOptions6._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions6._hostGameConfig == null)
				{
					if (playerOptions6._currentAdventureSaveData != null)
					{
						playerOptionsData2 = playerOptions6._currentAdventureSaveData;
						if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_1270;
						}
					}
					playerOptionsData2 = playerOptions6._mainGameConfig;
				}
				else
				{
					playerOptionsData2 = playerOptions6._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData2 = playerOptions6._onlineClientWithRunDataConfig;
			}
			goto IL_1270;
			IL_11ee:
			PlayerOptionsData playerOptionsData9;
			playerOptionsData9._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Machine;
			GameManager core9 = GM.Core;
			PlayerOptions playerOptions7 = core9._playerOptions;
			if (playerOptions7._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions7._hostGameConfig == null)
				{
					if (playerOptions7._currentAdventureSaveData != null)
					{
						playerOptionsData8 = playerOptions7._currentAdventureSaveData;
						if ((object)playerOptionsData8._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_122f;
						}
					}
					playerOptionsData8 = playerOptions7._mainGameConfig;
				}
				else
				{
					playerOptionsData8 = playerOptions7._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData8 = playerOptions7._onlineClientWithRunDataConfig;
			}
			goto IL_122f;
			IL_148d:
			PlayerOptionsData playerOptionsData10;
			List<ItemType> list = playerOptionsData10._003CCollectedItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			bool hasTrumpet;
			if ((nint)0 == 0)
			{
				hasTrumpet = false;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj5 = obj6 - -1;
				bool flag2 = obj5 == null;
				hasTrumpet = !flag2;
			}
			_hasTrumpet = hasTrumpet;
			GameManager core10 = GM.Core;
			PlayerOptions playerOptions8 = core10._playerOptions;
			PlayerOptionsData playerOptionsData11;
			if (playerOptions8._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions8._hostGameConfig == null)
				{
					if (playerOptions8._currentAdventureSaveData != null)
					{
						playerOptionsData11 = playerOptions8._currentAdventureSaveData;
						if ((object)playerOptionsData11._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_1158;
						}
					}
					playerOptionsData11 = playerOptions8._mainGameConfig;
				}
				else
				{
					playerOptionsData11 = playerOptions8._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData11 = playerOptions8._onlineClientWithRunDataConfig;
			}
			goto IL_1158;
			IL_11ad:
			PlayerOptionsData playerOptionsData12;
			playerOptionsData12._003CSelectedStage_003Ek__BackingField = StageType.MACHINE;
			GameManager core11 = GM.Core;
			PlayerOptions playerOptions9 = core11._playerOptions;
			if (playerOptions9._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions9._hostGameConfig == null)
				{
					if (playerOptions9._currentAdventureSaveData != null)
					{
						playerOptionsData9 = playerOptions9._currentAdventureSaveData;
						if ((object)playerOptionsData9._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_11ee;
						}
					}
					playerOptionsData9 = playerOptions9._mainGameConfig;
				}
				else
				{
					playerOptionsData9 = playerOptions9._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData9 = playerOptions9._onlineClientWithRunDataConfig;
			}
			goto IL_11ee;
			IL_1158:
			List<WeaponType> list2 = playerOptionsData11._003CUnlockedWeapons_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rcx_v37 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			bool hasJubilee;
			if ((nint)0 == 0)
			{
				hasJubilee = false;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj7 = obj8 - -1;
				bool flag3 = obj7 == null;
				hasJubilee = !flag3;
			}
			_hasJubilee = hasJubilee;
			GenerateSprites();
			GameManager core12 = GM.Core;
			PlayerOptions playerOptions10 = core12._playerOptions;
			if (playerOptions10._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions10._hostGameConfig == null)
				{
					if (playerOptions10._currentAdventureSaveData != null)
					{
						playerOptionsData12 = playerOptions10._currentAdventureSaveData;
						if ((object)playerOptionsData12._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_11ad;
						}
					}
					playerOptionsData12 = playerOptions10._mainGameConfig;
				}
				else
				{
					playerOptionsData12 = playerOptions10._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData12 = playerOptions10._onlineClientWithRunDataConfig;
			}
			goto IL_11ad;
			IL_147b:
			List<ItemType> list3 = playerOptionsData._003CCollectedItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rcx_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			bool hasMirror;
			if ((nint)0 == 0)
			{
				hasMirror = false;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj9 = obj10 - -1;
				bool flag4 = obj9 == null;
				hasMirror = !flag4;
			}
			_hasMirror = hasMirror;
			GameManager core13 = GM.Core;
			PlayerOptions playerOptions11 = core13._playerOptions;
			if (playerOptions11._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions11._hostGameConfig == null)
				{
					if (playerOptions11._currentAdventureSaveData != null)
					{
						PlayerOptionsData currentAdventureSaveData2 = playerOptions11._currentAdventureSaveData;
						if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							playerOptionsData10 = currentAdventureSaveData2;
							goto IL_148d;
						}
					}
					playerOptionsData10 = playerOptions11._mainGameConfig;
				}
				else
				{
					playerOptionsData10 = playerOptions11._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData10 = playerOptions11._onlineClientWithRunDataConfig;
			}
			goto IL_148d;
			IL_12f2:
			PlayerOptionsData playerOptionsData13;
			playerOptionsData13._003CSelectedHyper_003Ek__BackingField = false;
			GameManager core14 = GM.Core;
			PlayerOptions playerOptions12 = core14._playerOptions;
			if (playerOptions12._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions12._hostGameConfig == null)
				{
					if (playerOptions12._currentAdventureSaveData != null)
					{
						playerOptionsData6 = playerOptions12._currentAdventureSaveData;
						if ((object)playerOptionsData6._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_1333;
						}
					}
					playerOptionsData6 = playerOptions12._mainGameConfig;
				}
				else
				{
					playerOptionsData6 = playerOptions12._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData6 = playerOptions12._onlineClientWithRunDataConfig;
			}
			goto IL_1333;
			IL_12b1:
			playerOptionsData3._003CSelectedMazzo_003Ek__BackingField = false;
			GameManager core15 = GM.Core;
			PlayerOptions playerOptions13 = core15._playerOptions;
			if (playerOptions13._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions13._hostGameConfig == null)
				{
					if (playerOptions13._currentAdventureSaveData != null)
					{
						playerOptionsData13 = playerOptions13._currentAdventureSaveData;
						if ((object)playerOptionsData13._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_12f2;
						}
					}
					playerOptionsData13 = playerOptions13._mainGameConfig;
				}
				else
				{
					playerOptionsData13 = playerOptions13._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData13 = playerOptions13._onlineClientWithRunDataConfig;
			}
			goto IL_12f2;
			IL_1412:
			playerOptionsData5._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Forsaken;
			goto IL_13e2;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void OnRemoteItemInstantiated(Pickup item)
	{
		if (item._003CPickupType_003Ek__BackingField != ItemType.DIRECTER)
		{
			return;
		}
		_pickupDirecter = item;
		Action<Pickup> value = OnRemoteItemInstantiated;
		Delegate obj = Delegate.Remove(ItemInstantiator.OnRemoteItemInstantiated, value);
		if ((object)obj == null)
		{
			ItemInstantiator.OnRemoteItemInstantiated = (Action<Pickup>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<Pickup> action = default(Action<Pickup>);
		if (action != null)
		{
			ItemInstantiator.OnRemoteItemInstantiated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	private void OnRemoteEnemySpawned(EnemyController enemy)
	{
		if (enemy._enemyType != EnemyType.DIRECTER)
		{
			return;
		}
		EnemyDirecter component = enemy.GetComponent<EnemyDirecter>();
		_directer = component;
		Action<EnemyController> value = OnRemoteEnemySpawned;
		Delegate obj = Delegate.Remove(EnemyInstantiator.OnRemoteEnemySpawned, value);
		if ((object)obj == null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = (Action<EnemyController>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<EnemyController> action = default(Action<EnemyController>);
		if (action != null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	public void SwapDirecters()
	{
		Pickup pickupDirecter = _pickupDirecter;
		if ((object)_pickupDirecter != null && ((UnityEngine.Object)pickupDirecter).m_CachedPtr != (IntPtr)0)
		{
			_pickupDirecter.Despawn();
		}
		GameManager core = GM.Core;
		Vector2 spawnPos = default(Vector2);
		bool forceSpawn = default(bool);
		GameObject gameObject = core._stage.SpawnEnemy(EnemyType.DIRECTER, spawnPos, asRemote: false, forceSpawn);
		if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
		{
			EnemyDirecter component = gameObject.GetComponent<EnemyDirecter>();
			_directer = component;
		}
	}

	public void OnPhase1()
	{
		//IL_0014: Expected I8, but got O
		Action singlePlayerTrigger = _directer.TriggerPhase1OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase1((long)_directer);
		_directer.TriggerPhase(singlePlayerTrigger, action);
	}

	public void OnPhase2()
	{
		//IL_0014: Expected I8, but got O
		Action singlePlayerTrigger = _directer.TriggerPhase2OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase2((long)_directer);
		_directer.TriggerPhase(singlePlayerTrigger, action);
	}

	public void OnPhase3()
	{
		//IL_0014: Expected I8, but got O
		Action singlePlayerTrigger = _directer.TriggerPhase3OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase3((long)_directer);
		_directer.TriggerPhase(singlePlayerTrigger, action);
	}

	public void OnPhase4()
	{
		//IL_0014: Expected I8, but got O
		Action singlePlayerTrigger = _directer.TriggerPhase4OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase4((long)_directer);
		_directer.TriggerPhase(singlePlayerTrigger, action);
	}

	public void OnPhase5()
	{
		//IL_0014: Expected I8, but got O
		Action singlePlayerTrigger = _directer.TriggerPhase5OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase5((long)_directer);
		_directer.TriggerPhase(singlePlayerTrigger, action);
	}

	public void RemoveCircles()
	{
		//IL_002c: Expected I, but got O
		//IL_0084: Expected I, but got O
		//IL_00dc: Expected I, but got O
		//IL_0140: Expected O, but got I4
		//IL_019b: Expected I, but got O
		//IL_01f3: Expected I, but got O
		//IL_024b: Expected I, but got O
		//IL_02a1: Expected O, but got I4
		//IL_0313: Expected I, but got O
		//IL_036b: Expected I, but got O
		//IL_03c1: Expected O, but got I4
		//IL_03f1: Expected O, but got I4
		//IL_046f: Expected I, but got O
		//IL_04c7: Expected I, but got O
		//IL_051f: Expected I, but got O
		//IL_0575: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[3];
		if ((object)_sunCircle != null)
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
		if ((object)_moonCircle != null)
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
		if ((object)_worldCircle != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 2000f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[3];
		if ((object)_sunCircle != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_moonCircle != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_worldCircle != null)
		{
			nint num6 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 500f;
		tweenConfig2.delay = 2000f;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[2];
		if ((object)_centralCircle != null)
		{
			nint num7 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
				throw ex7;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sCentralCircle != null)
		{
			nint num8 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
				throw ex8;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.scale = (float?)(object)1;
		float y = _centralCircle.Y;
		tweenConfig3.duration = 1000f;
		tweenConfig3.y = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _centralCircle.setVisible(visible: false);
		};
		tweenConfig3.onComplete = onComplete;
		MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
		TweenConfig tweenConfig4 = new TweenConfig();
		object[] array4 = new object[3];
		if ((object)_sSunCircle != null)
		{
			nint num9 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj9 = default(object);
			if (obj9 == null)
			{
				ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
				throw ex9;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sMoonCircle != null)
		{
			nint num10 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			if (obj10 == null)
			{
				ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
				throw ex10;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sWorldCircle != null)
		{
			nint num11 = (nint)array4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj11 = default(object);
			if (obj11 == null)
			{
				ArrayTypeMismatchException ex11 = new ArrayTypeMismatchException();
				throw ex11;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig4.targets = array4;
		tweenConfig4.alpha = (float?)(object)1;
		tweenConfig4.duration = 500f;
		MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
	}

	public unsafe void RemoveTileset()
	{
		//IL_0353: Expected I, but got O
		//IL_0096: Expected I, but got O
		//IL_015c: Expected I, but got O
		//IL_0181: Expected F4, but got I4
		//IL_01d2: Expected O, but got I4
		//IL_01db: Expected F4, but got I4
		//IL_0245: Expected I, but got O
		//IL_0211: Expected F4, but got I4
		//IL_021a: Expected O, but got I4
		//IL_0223: Expected F4, but got I4
		//IL_03df: Expected I, but got O
		//IL_03f5: Expected O, but got I
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_0326: Expected I, but got O
		//IL_0429: Expected O, but got I4
		//IL_0440: Expected I, but got I8
		//IL_02e0: Expected I, but got I8
		nint num = (nint)GM.Core;
		Sequence sequence;
		TweenCallback tweenCallback;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v7 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+B8]");
			num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v7 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+B8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v7 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+C0]");
				num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v7 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+C0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v7 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+1C]");
					_ = (nint)0 + (nint)1;
					_ = 0;
					nint num2 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v9 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					num = 0;
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						Stage stage = core._stage;
						if ((object)core._stage != null && (object)stage._tilingTileset != null)
						{
							List<Tilemap> allLayers = stage._tilingTileset.GetAllLayers();
							sequence = DOTween.Sequence();
							bool flag = allLayers == null;
							bool flag2 = false;
							num = unchecked((nint)null);
							if (!flag)
							{
								flag2 = false;
								float num3 = 0f;
								List<Tilemap>.Enumerator enumerator = default(List<Tilemap>.Enumerator);
								while (enumerator.MoveNext())
								{
									Tweener t = VampireSurvivors.Tools.TweenExtensions.DOFade(null, 0f, 1f);
									bool flag3 = TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false);
									bool flag4 = !flag3;
									float num4 = 1f;
									object obj = 0;
									num3 = 0f;
									flag2 = false;
									if (!flag4)
									{
										Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
										num4 = 0f;
										obj = 0;
										num3 = 0f;
										flag2 = false;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
								bool flag5 = (nint)0 != 0;
								num = (nint)(&enumerator);
								if (!flag5)
								{
									_ = 1;
									num = unchecked((nint)"DefaultGameTweenId");
								}
								bool flag6 = sequence == null;
								List<Tilemap> list = allLayers;
								if (!flag6)
								{
									sequence.stringId = "DefaultGameTweenId";
									tweenCallback = null;
									nint num5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ r10_v2 (Il2CppMethodInfo)+8]");
									((Delegate)tweenCallback).method_ptr = (IntPtr)0;
									((Delegate)tweenCallback).method = (nint)__ldftn(Background6.RemoveWalls);
									((Delegate)tweenCallback).m_target = this;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
									flag2 = false;
									((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ r10_v2 (Il2CppMethodInfo)+4C]");
									object obj2 = (nint)0 >> 4;
									object obj3 = obj2 & 1;
									nint num6;
									if (obj3 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ r10_v2 (Il2CppMethodInfo)+52]");
										if ((nint)0 == 0)
										{
											num6 = unchecked((nint)6447293664L);
											goto IL_0420;
										}
									}
									else
									{
										bool flag7 = (object)this == null;
										list = allLayers;
										if (flag7)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
											object obj4 = default(object);
											throw obj4;
										}
									}
									num6 = ((Delegate)tweenCallback).method_ptr;
									((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
									goto IL_0420;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0420:
		object obj5 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onComplete = tweenCallback;
		}
	}

	public void RemoveWalls()
	{
		//IL_0258: Expected I, but got O
		//IL_0041: Expected I, but got O
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				num2 = (nint)stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rcx_v4 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+50]");
					if ((nint)0 != 0)
					{
						List<SuperTiled2Unity.SuperMap>.Enumerator enumerator = default(List<SuperTiled2Unity.SuperMap>.Enumerator);
						if (enumerator.MoveNext())
						{
							Component component = null;
							throw new NullReferenceException();
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage2 = core2._stage;
							if ((object)core2._stage != null && (object)stage2._tilingTileset != null)
							{
								stage2._tilingTileset.SetTilemapCollisionsEnabled(isEnabled: false);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void ZoomOverStages()
	{
		//IL_00c1: Expected O, but got I4
		//IL_01cd: Expected I, but got O
		//IL_0223: Expected O, but got I4
		//IL_025b: Expected O, but got I4
		List<string> stageKeys = _stageKeys;
		int stageKeyIndex = _stageKeyIndex;
		if (_stageKeyIndex < stageKeys._size)
		{
			string[] items = stageKeys._items;
			FakeTilingBackground tilingBg = _tilingBg;
			TileSprite bgTile = tilingBg._bgTile;
			Sprite unpackedSprite = SpriteManager.GetUnpackedSprite(items[stageKeyIndex]);
			bgTile._spriteRenderer.sprite = unpackedSprite;
			FakeTilingBackground tilingBg2 = _tilingBg;
			TileSprite tileSprite = tilingBg2._bgTile.SetTileScale(2f, (float?)(object)0);
			FakeTilingBackground tilingBg3 = _tilingBg;
			tilingBg3._speedFactor = 0.5f;
			FakeTilingBackground tilingBg4 = _tilingBg;
			tilingBg4._bgTile.SetVisible(visible: true);
			EnemyDirecter directer = _directer;
			if ((object)_directer != null && ((UnityEngine.Object)directer).m_CachedPtr != (IntPtr)0)
			{
				EnemyDirecter directer2 = _directer;
				directer2._003CStageIndex_003Ek__BackingField = _stageKeyIndex;
			}
			if (_stageZoomTween != null)
			{
				_stageZoomTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			FakeTilingBackground tilingBg5 = _tilingBg;
			if ((object)tilingBg5._bgTile != null)
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
			tweenConfig.tileScaleX = (float?)(object)1;
			tweenConfig.yoyo = true;
			tweenConfig.duration = 10000f;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.tileScaleY = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				//IL_002c: Expected O, but got Ref
				//IL_0053: Expected O, but got Ref
				if (_canContinueStageZoom)
				{
					ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(-500f, -600f);
					object obj2 = default(object);
					RenderingExtensions.SetSpeedY(_pfxFire1, (ParticleSystem.MinMaxCurve)(&obj2));
					ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(-500f, -600f);
					RenderingExtensions.SetSpeedY(_pfxFire2, (ParticleSystem.MinMaxCurve)(&obj2));
					RenderingExtensions.Start(_pfxFire1);
					RenderingExtensions.Start(_pfxFire2);
					Action onComplete2 = delegate
					{
						//IL_0044: Expected O, but got I4
						//IL_0051: Unknown result type (might be due to invalid IL or missing references)
						//IL_0056: Expected I4, but got Unknown
						if (_canContinueStageZoom)
						{
							RenderingExtensions.StopEmitting(_pfxFire1);
							RenderingExtensions.StopEmitting(_pfxFire2);
							List<string> stageKeys2 = _stageKeys;
							object obj3 = _stageKeyIndex + 1;
							int stageKeyIndex2 = obj3 % stageKeys2._size;
							_stageKeyIndex = stageKeyIndex2;
							ZoomOverStages();
						}
					};
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				}
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween stageZoomTween = Tweens.Add(tweenConfig);
			_stageZoomTween = stageZoomTween;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe void TurnBgToFire()
	{
		//IL_0042: Expected O, but got Ref
		//IL_0069: Expected O, but got Ref
		_canContinueStageZoom = false;
		RenderingExtensions.StopEmitting(_pfxFireRed1);
		RenderingExtensions.StopEmitting(_pfxFireRed2);
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(-300f, -300f);
		object obj = default(object);
		RenderingExtensions.SetSpeedY(_pfxFireRed1, (ParticleSystem.MinMaxCurve)(&obj));
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(-300f, -300f);
		RenderingExtensions.SetSpeedY(_pfxFireRed2, (ParticleSystem.MinMaxCurve)(&obj));
		RenderingExtensions.Start(_pfxFireRed1);
		RenderingExtensions.Start(_pfxFireRed2);
	}

	public void StartColorChangingBackground()
	{
		//IL_00d0: Expected I4, but got I8
		//IL_01d1: Expected O, but got I4
		//IL_032a: Expected I, but got O
		//IL_03a2: Expected O, but got I4
		//IL_04b5->IL0446: Incompatible stack heights: 1 vs 0
		//IL_00ed->IL0446: Incompatible stack heights: 1 vs 0
		//IL_04dc->IL0446: Incompatible stack heights: 1 vs 0
		//IL_0121->IL0446: Incompatible stack heights: 1 vs 0
		//IL_013f->IL0446: Incompatible stack heights: 1 vs 0
		//IL_0503->IL0446: Incompatible stack heights: 1 vs 0
		//IL_0173->IL0446: Incompatible stack heights: 1 vs 0
		//IL_01a5->IL0446: Incompatible stack heights: 1 vs 0
		//IL_01ed->IL0446: Incompatible stack heights: 1 vs 0
		//IL_021c->IL0446: Incompatible stack heights: 1 vs 0
		//IL_024d->IL0446: Incompatible stack heights: 1 vs 0
		//IL_0279->IL0446: Incompatible stack heights: 1 vs 0
		//IL_02a3->IL0446: Incompatible stack heights: 1 vs 0
		//IL_02fe->IL0446: Incompatible stack heights: 1 vs 0
		//IL_036f->IL0446: Incompatible stack heights: 1 vs 0
		//IL_034d->IL034d: Incompatible stack heights: 2 vs 1
		RenderingExtensions.StopEmitting(_pfxFireRed1);
		RenderingExtensions.StopEmitting(_pfxFireRed2);
		RenderingExtensions.Start(_pfxFire1);
		RenderingExtensions.Start(_pfxFire2);
		if ((object)_spritesRootTransform != null)
		{
			GameObject gameObject = _spritesRootTransform.gameObject;
			if ((object)_mainCamera != null)
			{
				Transform transform = _mainCamera.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Vector2 pos = default(Vector2);
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "WhiteDot");
					if ((object)phaserSprite != null)
					{
						PhaserSprite phaserSprite2 = phaserSprite.setDepth(-4999);
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer = s_scene._renderer;
								if (s_scene._renderer != null && (object)GM.Core != null)
								{
									PhaserScene s_scene2 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										PhaserScene.Renderer renderer2 = s_scene2._renderer;
										if (s_scene2._renderer != null)
										{
											float num = renderer2.height * 100f;
											if ((object)phaserSprite2 != null)
											{
												float xScale = renderer.width * 100f;
												PhaserSprite phaserSprite3 = phaserSprite2.setScale(xScale, (float?)(object)1);
												if ((object)phaserSprite3 != null)
												{
													PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0f);
													if ((object)phaserSprite4 != null)
													{
														PhaserSprite phaserSprite5 = phaserSprite4.setBlendMode(VampireSurvivors.Framework.Particles.BlendMode.Add);
														if ((object)_mainCamera != null)
														{
															Transform parent = _mainCamera.transform;
															if ((object)phaserSprite5 != null)
															{
																Transform transform2 = phaserSprite5.transform;
																if ((object)transform2 != null)
																{
																	transform2.SetParent(parent, worldPositionStays: true);
																	_colorBg = phaserSprite5;
																	TweenConfig tweenConfig = new TweenConfig();
																	object[] array = new object[1];
																	if (array != null)
																	{
																		if ((object)_colorBg != null)
																		{
																			nint num2 = (nint)array;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																			object obj = default(object);
																			bool flag2 = obj == null;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		if (tweenConfig != null)
																		{
																			tweenConfig.targets = array;
																			tweenConfig.duration = 2000f;
																			tweenConfig.alpha = (float?)(object)1;
																			TweenCallback onComplete = delegate
																			{
																				FakeTilingBackground tilingBg = _tilingBg;
																				TileSprite bgTile = tilingBg._bgTile;
																				Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("hStars1");
																				bgTile._spriteRenderer.sprite = unpackedSprite;
																			};
																			tweenConfig.onComplete = onComplete;
																			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
																			_colorBgValue = 0f;
																			Action<float> action = null;
																			((Background6)(object)action)._003CStartColorChangingBackground_003Eb__79_0(0f);
																			bool useRealTime = default(bool);
																			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																			int repeat = default(int);
																			TimerType type = default(TimerType);
																			Timer colorBgTimer = Timers.Register(1f, null, action, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																			_colorBgTimer = colorBgTimer;
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
		throw new NullReferenceException();
	}

	public IEnumerator EnterPhase5PostShatterAnimation()
	{
		_003CEnterPhase5PostShatterAnimation_003Ed__80 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void BlockInput()
	{
		GameManager core = GM.Core;
		core._003CCanPause_003Ek__BackingField = false;
		GM.Core.TogglePlayerHealthBar(visible: false);
		GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
		List<EquipmentInfo> list = GM.Core.RemoveAllEquipmentFromPlayers();
	}

	public void ShatterImage()
	{
		InitShatterVfx();
		_003CShatterImageRoutine_003Ed__100 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	public void OpenWindows()
	{
		//IL_0047: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		PhaserSprite[] targets = _windows.ToArray();
		tweenConfig.targets = targets;
		tweenConfig.duration = 1000f;
		tweenConfig.scaleX = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public unsafe void StartZoomingOut()
	{
		//IL_004a: Expected O, but got F4
		//IL_0070: Invalid comparison between F4 and I4
		//IL_0097: Invalid comparison between F4 and I4
		//IL_00b9: Expected O, but got F4
		//IL_00cb: Invalid comparison between F4 and I4
		//IL_00f1: Expected O, but got F4
		//IL_0127: Expected O, but got F4
		//IL_014d: Invalid comparison between F4 and I4
		//IL_016e: Expected O, but got F4
		//IL_017c: Invalid comparison between F4 and I4
		//IL_019e: Expected O, but got F4
		//IL_01b0: Invalid comparison between F4 and I4
		//IL_01d6: Expected O, but got F4
		//IL_08c8: Expected I, but got O
		//IL_08cc: Expected O, but got F4
		//IL_08d6: Expected F4, but got O
		//IL_08e3: Expected F4, but got O
		//IL_0904: Expected I, but got O
		//IL_0934: Expected O, but got I4
		//IL_02ea: Expected I, but got O
		//IL_043e: Expected I, but got O
		//IL_04d2: Expected O, but got F4
		//IL_0522: Expected I, but got O
		//IL_05b9: Expected I, but got O
		//IL_0623: Expected O, but got I4
		//IL_09d9: Expected I, but got O
		//IL_09ef: Expected O, but got I
		//IL_09f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fd: Expected O, but got Unknown
		//IL_0759: Expected I, but got O
		//IL_0a23: Expected O, but got I4
		//IL_0a3a: Expected I, but got I8
		//IL_0742: Expected I, but got I8
		//IL_07d0: Expected I, but got O
		//IL_07e6: Expected O, but got I
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f4: Expected O, but got Unknown
		//IL_085d: Expected I, but got O
		//IL_0a63: Expected I, but got I8
		//IL_0846: Expected I, but got I8
		//IL_02dd->IL086f: Incompatible stack heights: 1 vs 0
		//IL_0921->IL086f: Incompatible stack heights: 3 vs 0
		//IL_0382->IL086f: Incompatible stack heights: 3 vs 0
		//IL_04db->IL0926: Incompatible stack heights: 3 vs 1
		//IL_0515->IL086f: Incompatible stack heights: 3 vs 0
		//IL_0573->IL086f: Incompatible stack heights: 4 vs 0
		//IL_05a2->IL086f: Incompatible stack heights: 4 vs 0
		//IL_05fe->IL086f: Incompatible stack heights: 5 vs 0
		//IL_05dc->IL05dc: Incompatible stack heights: 6 vs 5
		//IL_0654->IL086f: Incompatible stack heights: 5 vs 0
		_003C_003Ec__DisplayClass84_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass84_0();
		if (CS_0024_003C_003E8__locals15 != null)
		{
			CS_0024_003C_003E8__locals15._003C_003E4__this = this;
			TweenConfig tilingBg = (TweenConfig)(object)_tilingBg;
			if ((object)_tilingBg != null)
			{
				TweenConfig tweenConfig = (TweenConfig)tilingBg.repeatDelay;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background6)+40]");
				float num = 0f * 2f;
				if (tilingBg.repeatDelay != 0f && tweenConfig.repeatDelay != 0f)
				{
					Vector2 size = ((SpriteRenderer)tweenConfig.repeatDelay).size;
					if (tweenConfig.repeatDelay != 0f)
					{
						Vector2 vector = default(Vector2);
						((SpriteRenderer)tweenConfig.repeatDelay).size = vector;
						TweenConfig tilingBg2 = (TweenConfig)(object)_tilingBg;
						if ((object)_tilingBg != null)
						{
							TweenConfig tweenConfig2 = (TweenConfig)tilingBg2.repeatDelay;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background6)+3C]");
							float num2 = 0f * 2f;
							if (tilingBg2.repeatDelay != 0f)
							{
								tweenConfig2.onRepeat = (TweenCallback)num2;
								if (tweenConfig2.repeatDelay != 0f)
								{
									Vector2 size2 = ((SpriteRenderer)tweenConfig2.repeatDelay).size;
									if (tweenConfig2.repeatDelay != 0f)
									{
										((SpriteRenderer)tweenConfig2.repeatDelay).size = vector;
										FakeTilingBackground tilingBg3 = _tilingBg;
										if ((object)_tilingBg != null && (object)tilingBg3._bgTile != null)
										{
											tilingBg3._bgTile.TileScaleX = 1f;
											FakeTilingBackground tilingBg4 = _tilingBg;
											if ((object)_tilingBg != null && (object)tilingBg4._bgTile != null)
											{
												tilingBg4._bgTile.TileScaleY = 1f;
												TweenConfig mainCamera = (TweenConfig)(object)_mainCamera;
												if ((object)_mainCamera != null)
												{
													bool flag = mainCamera.targets == null;
													object obj = Camera.get_orthographicSize_Injected((IntPtr)mainCamera.targets);
													_OriginalZoom = (float)vector;
													CS_0024_003C_003E8__locals15.startUIZoom = (float)vector;
													_OriginalUIZoom = 1f;
													bool flag2 = false;
													Vector2 vector2 = size2;
													nint num3 = unchecked((nint)null);
													object obj3 = default(object);
													object value = default(object);
													object obj4 = default(object);
													object obj5 = default(object);
													object obj6 = default(object);
													object value2 = default(object);
													object value3 = default(object);
													bool useRealTime = default(bool);
													MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
													int repeat = default(int);
													TimerType type = default(TimerType);
													while (true)
													{
														object obj2 = (flag2 ? 1 : 0) + 1;
														float num4 = (float)obj2 * 0.025f;
														float num5 = _OriginalUIZoom - num4;
														TweenConfig tweenConfig3 = new TweenConfig();
														object[] array = new object[1];
														if (array == null)
														{
															break;
														}
														nint num6 = (nint)array;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														bool flag3 = obj3 == null;
														bool flag4 = array.Length <= 0;
														array[0] = this;
														if (tweenConfig3 == null)
														{
															break;
														}
														tweenConfig3.targets = array;
														Dictionary<string, object> dictionary = new Dictionary<string, object>();
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
														if (dictionary == null)
														{
															break;
														}
														bool flag5 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_OriginalZoom", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
														bool flag6 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_OriginalUIZoom", obj4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
														tweenConfig3.custom = dictionary;
														tweenConfig3.duration = 500f;
														float delay = (float)(flag2 ? 1 : 0) * 5000f;
														tweenConfig3.delay = delay;
														TweenCallback onUpdate = CS_0024_003C_003E8__locals15._003C_003E9__1;
														bool flag7 = CS_0024_003C_003E8__locals15._003C_003E9__1 != null;
														System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
														num3 = (nint)obj4;
														if (!flag7)
														{
															TweenCallback tweenCallback = (CS_0024_003C_003E8__locals15._003C_003E9__1 = delegate
															{
																//IL_009c: Expected O, but got I
																//IL_01d7->IL0176: Incompatible stack heights: 1 vs 0
																//IL_00f5->IL0176: Incompatible stack heights: 1 vs 0
																//IL_0117->IL0176: Incompatible stack heights: 1 vs 0
																//IL_0149->IL0176: Incompatible stack heights: 1 vs 0
																//IL_0167->IL0176: Incompatible stack heights: 1 vs 0
																Background6 background = CS_0024_003C_003E8__locals15._003C_003E4__this;
																if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null && (object)background._mainCamera != null)
																{
																	background._mainCamera.orthographicSize = background._OriginalZoom;
																	object obj12 = CS_0024_003C_003E8__locals15._003C_003E4__this;
																	if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v6 (System.Object)+1C0]");
																		object obj13 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v6 (System.Object)+1C0]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdi_v7 (System.Object)+10]");
																			bool flag14 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdi_v7 (System.Object)+10]");
																			Vector3 value4 = default(Vector3);
																			Transform.set_localScale_Injected((IntPtr)0, ref value4);
																			Background6 background2 = CS_0024_003C_003E8__locals15._003C_003E4__this;
																			if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null)
																			{
																				FakeTilingBackground tilingBg6 = background2._tilingBg;
																				if ((object)background2._tilingBg != null && (object)tilingBg6._bgTile != null)
																				{
																					Transform transform2 = tilingBg6._bgTile.transform;
																					if ((object)CS_0024_003C_003E8__locals15._003C_003E4__this != null && (object)transform2 != null)
																					{
																						bool flag15 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																						Vector3 value5 = default(Vector3);
																						Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value5);
																						return;
																					}
																				}
																			}
																		}
																	}
																}
																throw new NullReferenceException();
															});
															insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
															onUpdate = tweenCallback;
															num3 = 0;
														}
														tweenConfig3.onUpdate = onUpdate;
														MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig3);
														flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
														bool flag8 = (flag2 ? 1 : 0) < 9;
														vector2 = (Vector2)num5;
														if (flag8)
														{
															continue;
														}
														TweenConfig tweenConfig4 = new TweenConfig();
														object[] array2 = new object[2];
														if (array2 == null)
														{
															break;
														}
														nint num7 = (nint)array2;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														bool flag9 = obj5 == null;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														Background6 tilingBg5 = (Background6)(object)_tilingBg;
														if ((object)_tilingBg == null)
														{
															break;
														}
														Background6 mainCamera2 = (Background6)(object)tilingBg5._mainCamera;
														if ((object)tilingBg5._mainCamera == null)
														{
															break;
														}
														bool flag10 = ((UnityEngine.Object)mainCamera2).m_CachedPtr == (IntPtr)0;
														IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)mainCamera2).m_CachedPtr);
														Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
														if ((object)transform != null)
														{
															nint num8 = (nint)array2;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															bool flag11 = obj6 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig4 == null)
														{
															break;
														}
														tweenConfig4.targets = array2;
														tweenConfig4.scale = (float?)(object)1;
														Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
														if (dictionary2 == null)
														{
															break;
														}
														bool flag12 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_OriginalZoom", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
														bool flag13 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_OriginalUIZoom", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
														tweenConfig4.custom = dictionary2;
														tweenConfig4.duration = 500f;
														tweenConfig4.delay = 45000f;
														TweenCallback tweenCallback2 = null;
														nint num9 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1638 @ r10_v1 (Il2CppMethodInfo)+8]");
														((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
														((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass84_0._003CStartZoomingOut_003Eb__2);
														((Delegate)tweenCallback2).m_target = CS_0024_003C_003E8__locals15;
														((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1638 @ r10_v1 (Il2CppMethodInfo)+4C]");
														object obj7 = (nint)0 >> 4;
														object obj8 = obj7 & 1;
														nint num10;
														if (obj8 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1638 @ r10_v1 (Il2CppMethodInfo)+52]");
															if ((nint)0 == 0)
															{
																num10 = unchecked((nint)6447293664L);
																goto IL_0a1a;
															}
														}
														((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
														num10 = ((Delegate)tweenCallback2).method_ptr;
														goto IL_0a1a;
														IL_0a4c:
														Action action;
														((Delegate)action).extra_arg = unchecked((nint)6447293568L);
														Timer timer = Timers.Register(45.45f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
														return;
														IL_0a1a:
														object obj9 = 24;
														((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
														tweenConfig4.onUpdate = tweenCallback2;
														MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig4);
														action = null;
														nint num11 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1041 @ r10_v2 (Il2CppMethodInfo)+8]");
														((Delegate)action).method_ptr = (IntPtr)0;
														((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass84_0._003CStartZoomingOut_003Eb__0);
														((Delegate)action).m_target = CS_0024_003C_003E8__locals15;
														((Delegate)action).method_code = (IntPtr)action;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1041 @ r10_v2 (Il2CppMethodInfo)+4C]");
														object obj10 = (nint)0 >> 4;
														object obj11 = obj10 & 1;
														nint num12;
														if (obj11 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1041 @ r10_v2 (Il2CppMethodInfo)+52]");
															if ((nint)0 == 0)
															{
																num12 = unchecked((nint)6447293664L);
																goto IL_0a4c;
															}
														}
														((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
														num12 = ((Delegate)action).method_ptr;
														goto IL_0a4c;
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

	public void RemoveColorBg()
	{
		//IL_013b: Expected O, but got I4
		FakeTilingBackground tilingBg = _tilingBg;
		TileSprite bgTile = tilingBg._bgTile;
		Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("hStars1");
		bgTile._spriteRenderer.sprite = unpackedSprite;
		FakeTilingBackground tilingBg2 = _tilingBg;
		TileSprite tileSprite = RenderingExtensions.SetScale(tilingBg2._bgTile, 1f);
		RenderingExtensions.StopEmitting(_pfxFire1);
		RenderingExtensions.StopEmitting(_pfxFire2);
		TweenConfig tweenConfig = new TweenConfig();
		object[] targets = new object[1];
		if ((object)_colorBg != null)
		{
			TileSprite tileSprite2 = RenderingExtensions.SetScale((TileSprite)(object)_colorBg, 1f);
			if ((object)tileSprite2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = targets;
		tweenConfig.duration = 2000f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public void AddLevelUpBars()
	{
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA53D0");
		GM.Core.TogglePlayerHealthBar(visible: false);
		SpawnFakePlayerUILevelUp(0f, 0f);
		SpawnFakePlayerUILevelUp(8f, 64f);
		SpawnFakePlayerUILevelUp(16f, 48f);
		SpawnFakePlayerUILevelUp(8f, 32f);
		SpawnFakePlayerUILevelUp(-16f, 16f);
		SpawnFakePlayerUILevelUp(-32f, 80f);
	}

	public unsafe void StartGifts()
	{
		//IL_00ba: Expected I, but got O
		//IL_00d0: Expected O, but got I
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_0147: Expected I, but got O
		//IL_0288: Expected O, but got I4
		//IL_029f: Expected I, but got I8
		//IL_0130: Expected I, but got I8
		//IL_01d1: Expected I, but got O
		//IL_01e7: Expected O, but got I
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_025e: Expected I, but got O
		//IL_0332: Expected O, but got I4
		//IL_0349: Expected I, but got I8
		//IL_0247: Expected I, but got I8
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A971C0");
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager = core2._arcanaManager;
		arcanaManager._003CXpMultiplier_003Ek__BackingField = 0f;
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass87_0 obj = new _003C_003Ec__DisplayClass87_0();
			obj._003C_003E4__this = this;
			obj.index = (flag ? 1 : 0);
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass87_0._003CStartGifts_003Eb__0);
			((Delegate)action).m_target = obj;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num2;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_027f;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_027f;
			IL_027f:
			object obj4 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num3 = (float)(flag ? 1 : 0) * 500f;
			float duration = num3 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < 120);
		bool flag2 = false;
		do
		{
			_003C_003Ec__DisplayClass87_1 obj5 = new _003C_003Ec__DisplayClass87_1();
			obj5._003C_003E4__this = this;
			obj5.index = (flag2 ? 1 : 0);
			Action action2 = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action2).method_ptr = (IntPtr)0;
			((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass87_1._003CStartGifts_003Eb__1);
			((Delegate)action2).m_target = obj5;
			((Delegate)action2).method_code = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj6 = (nint)0 >> 4;
			object obj7 = obj6 & 1;
			nint num5;
			if (obj7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num5 = unchecked((nint)6447293664L);
					goto IL_0329;
				}
			}
			((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
			num5 = ((Delegate)action2).method_ptr;
			goto IL_0329;
			IL_0329:
			object obj8 = 24;
			((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
			float num6 = (float)(flag2 ? 1 : 0) * 1000f;
			float num7 = num6 + 500f;
			float duration2 = num7 * 0.001f;
			Timer timer2 = Timers.Register(duration2, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
		}
		while ((flag2 ? 1 : 0) < 120);
	}

	public unsafe void MakeThrowingHands()
	{
		//IL_08f4: Expected I4, but got O
		//IL_0038: Expected O, but got I
		//IL_098d: Expected I4, but got O
		//IL_0159: Expected O, but got I
		//IL_04a1: Expected O, but got I
		//IL_018b: Expected I, but got O
		//IL_01b1: Expected O, but got F4
		//IL_01e4: Expected O, but got I4
		//IL_0200: Expected O, but got I4
		//IL_05cc: Expected O, but got I
		//IL_026f: Expected O, but got F4
		//IL_02d0: Expected O, but got I4
		//IL_02d0: Expected I4, but got O
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_0624: Expected O, but got F4
		//IL_034a: Expected O, but got Ref
		//IL_0657: Expected O, but got I4
		//IL_0673: Expected O, but got I4
		//IL_06e2: Expected O, but got F4
		//IL_0407: Expected I4, but got I8
		//IL_0431: Expected O, but got I4
		//IL_03a8: Expected I, but got O
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		//IL_0743: Expected O, but got I4
		//IL_0743: Expected I4, but got O
		//IL_076b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Expected O, but got Unknown
		//IL_07bd: Expected O, but got Ref
		//IL_088f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0894: Expected O, but got Unknown
		//IL_03cb->IL03cb: Incompatible stack heights: 6 vs 5
		//IL_0472->IL095d: Incompatible stack heights: 5 vs 2
		//IL_083e->IL083e: Incompatible stack heights: 8 vs 7
		//IL_08b5->IL0572: Incompatible stack heights: 7 vs 4
		Transform transform = _mainCamera.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
		int num = (int)ArcadePhysics.s_scene;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ r9_v12 (System.Int32)+28]");
		object obj = 0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Ellipse ellipse = new Ellipse();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v35+10]");
		float width = 0f * 1.4f;
		float height = renderer.height * 1.4f;
		ellipse._width = width;
		ellipse._height = height;
		ellipse._x = ret;
		float num2 = default(float);
		ellipse._y = num2;
		List<Vector2> points = ellipse.GetPoints(32);
		bool flag2 = (object)GM.Core == null;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		Transform transform2 = null;
		Transform transform3 = null;
		float num3 = num2;
		Transform transform4 = null;
		float num5 = default(float);
		string text = default(string);
		int num6 = default(int);
		bool flag6 = default(bool);
		bool autoSetAnimation = default(bool);
		float num8 = default(float);
		object obj7 = default(object);
		while (true)
		{
			Transform obj2 = transform4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj2 >= 0)
			{
				break;
			}
			Transform obj3 = transform2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag3 = (nint)obj3 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v41 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj4 = 0;
			Transform obj5 = transform2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rcx_v82+18]");
			bool flag4 = (nint)obj5 >= 0;
			nint num4 = (nint)_spritesRootTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdi_v19 (System.IntPtr)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdi_v19 (System.IntPtr)+10]");
			IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
			GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, (Vector2)num5, "enemiesM", "hand_reveal_01");
			PhaserSprite phaserSprite2 = phaserSprite.setDepth(32767);
			PhaserSprite phaserSprite3 = phaserSprite2.setScale(2f, (float?)(object)0);
			PhaserSprite phaserSprite4 = phaserSprite3.setOrigin(1f, (float?)(object)1);
			if ((object)transform3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ r12_v15 (UnityEngine.Transform)+18]");
				if ((nint)0 > (nint)0)
				{
					goto IL_0280;
				}
			}
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("hand_reveal_", 1, 4, (Vector2)num5, text, num6, flag6);
			transform3 = (Transform)(object)animationFrames;
			goto IL_0280;
			IL_0280:
			GameObject gameObject2 = phaserSprite4._spriteRenderer.gameObject;
			SpriteAnimation spriteAnimation = gameObject2.AddComponent<SpriteAnimation>();
			spriteAnimation.AddAnimation("throw", (List<Sprite>)(object)transform3, 4, (byte)(int)text != 0, (byte)num6 != 0, (Action)flag6, autoSetAnimation);
			spriteAnimation.SetAnimation("throw");
			float2 screenCenter = renderer2.screenCenter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rcx_v82+20+v273 @ rbp_v12 (UnityEngine.Transform)*8]");
			object obj6 = screenCenter - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v45 (PhaserScene+Renderer)+38]");
			float num7 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rcx_v82+24+v273 @ rbp_v12 (UnityEngine.Transform)*8]");
			num3 = num7 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Transform transform5 = phaserSprite4.transform;
			transform5.localEulerAngles = (Vector3)(&num8);
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform transform6 = phaserSprite4._spriteRenderer.transform;
			if ((object)transform6 != null)
			{
				nint num9 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag7 = obj7 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.yoyo = true;
			tweenConfig.repeat = -1;
			tweenConfig.duration = 1000f;
			tweenConfig.ease = Ease.InOutExpo;
			tweenConfig.localAngle = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			transform2 = (Transform)(transform2 + 1);
			num8 = num5;
			num = 4;
			transform4 = transform2;
		}
		bool flag8 = (object)GM.Core == null;
		int num10 = (int)ArcadePhysics.s_scene;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ r9_v14 (System.Int32)+28]");
		object obj8 = 0;
		bool flag9 = (object)GM.Core == null;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		Ellipse ellipse2 = new Ellipse();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rax_v51+10]");
		float width2 = 0f * 1.7f;
		float height2 = renderer3.height * 1.7f;
		ellipse2._width = width2;
		ellipse2._height = height2;
		ellipse2._x = ret;
		ellipse2._y = num2;
		List<Vector2> points2 = ellipse2.GetPoints(42);
		Transform transform7 = null;
		float num11 = num2;
		Transform transform8 = null;
		object obj15 = default(object);
		while (true)
		{
			Transform obj9 = transform8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v57 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj9 >= 0)
			{
				break;
			}
			Transform obj10 = transform7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v57 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag10 = (nint)obj10 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v57 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj11 = 0;
			Transform obj12 = transform7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rcx_v44+18]");
			bool flag11 = (nint)obj12 >= 0;
			object spritesRootTransform = _spritesRootTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rdi_v15 (System.Object)+10]");
			bool flag12 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rdi_v15 (System.Object)+10]");
			IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
			GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
			PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject3, (Vector2)num5, "enemiesM", "hand_reveal_01");
			PhaserSprite phaserSprite6 = phaserSprite5.setDepth(32767);
			PhaserSprite phaserSprite7 = phaserSprite6.setScale(2f, (float?)(object)0);
			PhaserSprite phaserSprite8 = phaserSprite7.setOrigin(1f, (float?)(object)1);
			if ((object)transform3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ r12_v15 (UnityEngine.Transform)+18]");
				if ((nint)0 > (nint)0)
				{
					goto IL_06f3;
				}
			}
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("hand_reveal_", 1, 4, (Vector2)num5, text, num6, flag6);
			transform3 = (Transform)(object)animationFrames2;
			goto IL_06f3;
			IL_06f3:
			GameObject gameObject4 = phaserSprite8._spriteRenderer.gameObject;
			SpriteAnimation spriteAnimation2 = gameObject4.AddComponent<SpriteAnimation>();
			spriteAnimation2.AddAnimation("throw", (List<Sprite>)(object)transform3, 4, (byte)(int)text != 0, (byte)num6 != 0, (Action)flag6, autoSetAnimation);
			spriteAnimation2.SetAnimation("throw");
			float2 screenCenter2 = renderer2.screenCenter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rcx_v44+20+v275 @ rbp_v14 (UnityEngine.Transform)*8]");
			object obj13 = screenCenter2 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rax_v45 (PhaserScene+Renderer)+38]");
			float num12 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rcx_v44+24+v275 @ rbp_v14 (UnityEngine.Transform)*8]");
			num11 = num12 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Transform transform9 = phaserSprite8.transform;
			transform9.localEulerAngles = (Vector3)(&num8);
			TweenConfig config = new TweenConfig();
			object[] array2 = new object[1];
			Transform transform10 = phaserSprite8._spriteRenderer.transform;
			if ((object)transform10 != null)
			{
				object obj14 = array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag13 = obj15 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			_ = 1;
			_ = 4294967295L;
			_ = 1148846080;
			_ = 19;
			_ = 1;
			MultiTargetTween multiTargetTween2 = Tweens.Add(config);
			transform7 = (Transform)(transform7 + 1);
			num8 = num5;
			num10 = 4;
			transform8 = transform7;
		}
	}

	public void PlayVideos()
	{
		_003C_003Ec__DisplayClass89_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass89_0();
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		CS_0024_003C_003E8__locals9.rendererWidth = renderer.width;
		List<Vector2> list = new List<Vector2>();
		Vector2 item = default(Vector2);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		PlayVideosAt(0, list);
		Action onComplete = delegate
		{
			List<Vector2> list2 = new List<Vector2>();
			Vector2 item2 = default(Vector2);
			list2.Add(item2);
			list2.Add(item2);
			CS_0024_003C_003E8__locals9._003C_003E4__this.PlayVideosAt(1, list2);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			List<Vector2> list2 = new List<Vector2>();
			Vector2 item2 = default(Vector2);
			list2.Add(item2);
			list2.Add(item2);
			CS_0024_003C_003E8__locals9._003C_003E4__this.PlayVideosAt(2, list2);
		};
		Timer timer2 = Timers.Register(15.000001f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete3 = delegate
		{
			List<Vector2> list2 = new List<Vector2>();
			Vector2 item2 = default(Vector2);
			list2.Add(item2);
			list2.Add(item2);
			list2.Add(item2);
			CS_0024_003C_003E8__locals9._003C_003E4__this.PlayVideosAt(0, list2);
		};
		Timer timer3 = Timers.Register(25.000002f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete4 = delegate
		{
			List<Vector2> list2 = new List<Vector2>();
			Vector2 item2 = default(Vector2);
			list2.Add(item2);
			list2.Add(item2);
			CS_0024_003C_003E8__locals9._003C_003E4__this.PlayVideosAt(1, list2);
		};
		Timer timer4 = Timers.Register(30.000002f, onComplete4, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete5 = delegate
		{
			List<Vector2> list2 = new List<Vector2>();
			Vector2 item2 = default(Vector2);
			list2.Add(item2);
			list2.Add(item2);
			list2.Add(item2);
			CS_0024_003C_003E8__locals9._003C_003E4__this.PlayVideosAt(0, list2);
		};
		Timer timer5 = Timers.Register(35f, onComplete5, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete6 = delegate
		{
			List<Vector2> list2 = new List<Vector2>();
			Vector2 item2 = default(Vector2);
			list2.Add(item2);
			list2.Add(item2);
			CS_0024_003C_003E8__locals9._003C_003E4__this.PlayVideosAt(2, list2);
		};
		Timer timer6 = Timers.Register(40f, onComplete6, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete7 = delegate
		{
			List<Vector2> list2 = new List<Vector2>();
			Vector2 item2 = default(Vector2);
			list2.Add(item2);
			list2.Add(item2);
			list2.Add(item2);
			CS_0024_003C_003E8__locals9._003C_003E4__this.PlayVideosAt(0, list2);
		};
		Timer timer7 = Timers.Register(45.000004f, onComplete7, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void GenerateSprites()
	{
		//IL_0158: Expected O, but got I4
		//IL_0191: Expected O, but got I4
		//IL_0061->IL03a4: Incompatible stack heights: 1 vs 0
		//IL_0102->IL03a4: Incompatible stack heights: 4 vs 0
		//IL_012c->IL03a4: Incompatible stack heights: 4 vs 0
		//IL_0179->IL03a4: Incompatible stack heights: 4 vs 0
		//IL_01ad->IL03a4: Incompatible stack heights: 4 vs 0
		//IL_01dc->IL03a4: Incompatible stack heights: 4 vs 0
		//IL_020b->IL03a4: Incompatible stack heights: 4 vs 0
		//IL_0255->IL03a4: Incompatible stack heights: 4 vs 0
		//IL_0277->IL03a4: Incompatible stack heights: 4 vs 0
		//IL_02a6->IL03a4: Incompatible stack heights: 4 vs 0
		//IL_0307->IL03a4: Incompatible stack heights: 4 vs 0
		//IL_0375->IL03a4: Incompatible stack heights: 4 vs 0
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, "Background6SpritesRoot");
				if ((object)gameObject != null)
				{
					Transform spritesRootTransform = gameObject.transform;
					_spritesRootTransform = spritesRootTransform;
					GameObject spritesRootTransform2 = (GameObject)(object)_spritesRootTransform;
					bool flag2 = (object)_spritesRootTransform == null;
					bool flag3 = ((UnityEngine.Object)spritesRootTransform2).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)spritesRootTransform2).m_CachedPtr, ref *(Vector3*)(&ret));
					bool flag4 = (object)_spritesRootTransform == null;
					_spritesRootTransform.SetParent(transform, worldPositionStays: true);
					GameObject gameObject2 = base.gameObject;
					Vector2 pos = default(Vector2);
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "enemiesM", "hand_snap_01");
					if ((object)phaserSprite != null)
					{
						Transform transform2 = phaserSprite.transform;
						if ((object)transform2 != null)
						{
							transform2.SetParent(_spritesRootTransform, worldPositionStays: true);
							PhaserSprite phaserSprite2 = phaserSprite.setOrigin(1f, (float?)(object)1);
							if ((object)phaserSprite2 != null)
							{
								PhaserSprite phaserSprite3 = phaserSprite2.setScale(3f, (float?)(object)0);
								if ((object)phaserSprite3 != null)
								{
									PhaserSprite phaserSprite4 = phaserSprite3.setFlipX(flipX: false);
									if ((object)phaserSprite4 != null)
									{
										PhaserSprite phaserSprite5 = phaserSprite4.setDepth(10000);
										if ((object)phaserSprite5 != null)
										{
											PhaserSprite snap = phaserSprite5.setVisible(visible: false);
											_snap = snap;
											PhaserSprite snap2 = _snap;
											if ((object)_snap != null && (object)snap2._spriteRenderer != null)
											{
												GameObject gameObject3 = snap2._spriteRenderer.gameObject;
												if ((object)gameObject3 != null)
												{
													SpriteAnimation snapAnimation = gameObject3.AddComponent<SpriteAnimation>();
													_snapAnimation = snapAnimation;
													int num = default(int);
													List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("hand_snap_", 1, 3, "enemiesM", num);
													if ((object)_snapAnimation != null)
													{
														bool startRandomFrame = default(bool);
														Action onComplete = default(Action);
														bool autoSetAnimation = default(bool);
														_snapAnimation.AddAnimation("snap_start", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
														List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("hand_snap_", 4, 5, "enemiesM", num);
														if ((object)_snapAnimation != null)
														{
															_snapAnimation.AddAnimation("snap_do", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
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
		throw new NullReferenceException();
	}

	private void GenerateFakeTilingBackground()
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "FakeTilingBackground");
		Transform transform = gameObject.transform;
		transform.SetParent(_spritesRootTransform, worldPositionStays: true);
		Transform transform2 = gameObject.transform;
		bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		FakeTilingBackground tilingBg = gameObject.AddComponent<FakeTilingBackground>();
		_tilingBg = tilingBg;
	}

	private void RemovePowerUps()
	{
		List<string> list = new List<string>();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list2 = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"Tear");
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<ItemType> list3 = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._size >= items2.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"Tarots");
				}
				else
				{
					int size2 = list._size + 1;
					list._size = size2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
		}
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		List<ItemType> list4 = config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v19 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				int version3 = list._version + 1;
				list._version = version3;
				string[] items3 = list._items;
				if (list._size >= items3.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"trumpet");
				}
				else
				{
					int size3 = list._size + 1;
					list._size = size3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
		}
		GameManager core4 = GM.Core;
		PlayerOptionsData config4 = core4._playerOptions.Config;
		List<ItemType> list5 = config4._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				int version4 = list._version + 1;
				list._version = version4;
				string[] items4 = list._items;
				if (list._size >= items4.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"mirror");
				}
				else
				{
					int size4 = list._size + 1;
					list._size = size4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
		}
		GameManager core5 = GM.Core;
		PlayerOptionsData config5 = core5._playerOptions.Config;
		List<ItemType> list6 = config5._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		}
		GameManager core6 = GM.Core;
		PlayerOptionsData config6 = core6._playerOptions.Config;
		List<ItemType> list7 = config6._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj5 = default(object);
			if ((nint)obj5 != -1)
			{
				int version5 = list._version + 1;
				list._version = version5;
				string[] items5 = list._items;
				if (list._size >= items5.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"glassmask");
				}
				else
				{
					int size5 = list._size + 1;
					list._size = size5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
		}
		GameManager core7 = GM.Core;
		PlayerOptionsData config7 = core7._playerOptions.Config;
		List<ItemType> list8 = config7._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			if ((nint)obj6 != -1)
			{
				int version6 = list._version + 1;
				list._version = version6;
				string[] items6 = list._items;
				if (list._size >= items6.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"banger");
				}
				else
				{
					int size6 = list._size + 1;
					list._size = size6;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1085 Invalid \"Jump target not found in method: 0x186EEDAD0\"");
		throw new NullReferenceException();
	}

	private unsafe void RemovePowers(List<string> frames)
	{
		//IL_0624: Expected O, but got Ref
		//IL_0652: Expected I, but got O
		//IL_0668: Expected O, but got I
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected O, but got Unknown
		//IL_025e: Expected I, but got O
		//IL_069c: Expected O, but got I4
		//IL_06b3: Expected I, but got I8
		//IL_02ed: Expected I, but got O
		//IL_0303: Expected O, but got I
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		//IL_0247: Expected I, but got I8
		//IL_037a: Expected I, but got O
		//IL_06d9: Expected O, but got I4
		//IL_06f0: Expected I, but got I8
		//IL_0363: Expected I, but got I8
		//IL_041c->IL070d: Incompatible stack heights: 8 vs 1
		float num = (float)Math.PI * 2f / (float)frames._size;
		Transform transform = _mainCamera.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		int num2 = 0;
		int num3 = 0;
		Vector2 vector = default(Vector2);
		string spriteName = default(string);
		Vector2 vector2 = default(Vector2);
		while (num3 < frames._size)
		{
			_003C_003Ec__DisplayClass93_0 obj = new _003C_003Ec__DisplayClass93_0();
			bool flag2 = num2 >= frames._size;
			string[] items = frames._items;
			bool flag3 = num2 >= items.Length;
			GameObject gameObject = base.gameObject;
			SpriteRenderer s = RenderingExtensions.AddSprite(gameObject, vector, vector, "items", spriteName);
			obj.s = s;
			Transform s2 = (Transform)(object)obj.s;
			bool flag4 = ((UnityEngine.Object)s2).m_CachedPtr == (IntPtr)0;
			Renderer.set_enabled_Injected(((UnityEngine.Object)s2).m_CachedPtr, false);
			Transform s3 = (Transform)(object)obj.s;
			bool flag5 = ((UnityEngine.Object)s3).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)s3).m_CachedPtr, 2000);
			Transform transform2 = obj.s.transform;
			transform2.SetParent(_spritesRootTransform, worldPositionStays: true);
			Transform s4 = (Transform)(object)obj.s;
			bool flag6 = ((UnityEngine.Object)s4).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)s4).m_CachedPtr);
			Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag7 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
			float num4 = (float)num2 * num;
			float num5 = num4 + 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num6 = (float)num2 * num;
			float num7 = num6 + 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Transform s5 = (Transform)(object)obj.s;
			obj.index = num2;
			bool flag8 = ((UnityEngine.Object)s5).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)s5).m_CachedPtr);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMove(target, (Vector3)(&vector2), 0.5f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1758 @ rax_v77 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			float num8 = (float)num2 * 100f;
			float num9 = num8 + 800f;
			float delay = num9 * 0.001f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(tweenerCore, delay);
			TweenCallback tweenCallback = null;
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1833 @ r10_v16 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass93_0._003CRemovePowers_003Eb__0);
			((Delegate)tweenCallback).m_target = obj;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1833 @ r10_v16 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num11;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1833 @ r10_v16 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num11 = unchecked((nint)6447293664L);
					goto IL_0693;
				}
			}
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			num11 = ((Delegate)tweenCallback).method_ptr;
			goto IL_0693;
			IL_06d0:
			object obj4 = 24;
			TweenCallback tweenCallback2;
			((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1826 @ rax_v79 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			num2++;
			vector2 = vector;
			num3 = num2;
			continue;
			IL_0693:
			object obj5 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1826 @ rax_v79 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			tweenCallback2 = null;
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r10_v17 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass93_0._003CRemovePowers_003Eb__1);
			((Delegate)tweenCallback2).m_target = obj;
			((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r10_v17 (Il2CppMethodInfo)+4C]");
			object obj6 = (nint)0 >> 4;
			object obj7 = obj6 & 1;
			nint num13;
			if (obj7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r10_v17 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num13 = unchecked((nint)6447293664L);
					goto IL_06d0;
				}
			}
			((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
			num13 = ((Delegate)tweenCallback2).method_ptr;
			goto IL_06d0;
		}
	}

	private unsafe void SnapEggs()
	{
		//IL_0091: Invalid comparison between I4 and F4
		_003C_003Ec__DisplayClass94_0 CS_0024_003C_003E8__locals24 = new _003C_003Ec__DisplayClass94_0();
		CS_0024_003C_003E8__locals24._003C_003E4__this = this;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			return;
		}
		GameManager core2 = GM.Core;
		if (!(0f < (CS_0024_003C_003E8__locals24.number = core2._eggManager.RemoveBonuses())))
		{
			return;
		}
		PhaserSprite phaserSprite = _snap.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _snap.setAlpha(1f);
		_snapAnimation.SetAnimation("snap_start");
		Action onComplete = delegate
		{
			//IL_0072: Expected O, but got I4
			//IL_06a0: Invalid comparison between F4 and I4
			//IL_06b2: Expected F4, but got I4
			//IL_06c4: Expected O, but got I4
			//IL_012c: Expected O, but got I4
			//IL_013f: Expected F4, but got I4
			//IL_0151: Expected O, but got I4
			//IL_06db: Expected O, but got F4
			//IL_097e: Expected O, but got F4
			//IL_056e: Expected I, but got O
			//IL_05d8: Expected O, but got I4
			//IL_0294: Expected I, but got O
			//IL_0336: Expected I, but got O
			//IL_07da: Expected O, but got F4
			//IL_080d: Expected O, but got I4
			//IL_03e5: Expected O, but got I
			//IL_0403: Expected O, but got I4
			//IL_083f: Expected O, but got F4
			//IL_086d: Expected O, but got I4
			//IL_098c: Expected O, but got F4
			//IL_087f: Expected I, but got O
			//IL_0895: Expected O, but got I
			//IL_089e: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a3: Expected O, but got Unknown
			//IL_0454: Expected I, but got O
			//IL_08c9: Expected O, but got I4
			//IL_08e0: Expected I, but got I8
			//IL_08f6: Expected O, but got I4
			//IL_048b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0490: Expected O, but got Unknown
			//IL_049a: Invalid comparison between F4 and O
			//IL_04d3: Expected O, but got I4
			//IL_043d: Expected I, but got I8
			//IL_0522->IL062b: Incompatible stack heights: 1 vs 0
			//IL_053f->IL062b: Incompatible stack heights: 1 vs 0
			//IL_05b3->IL062b: Incompatible stack heights: 1 vs 0
			//IL_0591->IL0591: Incompatible stack heights: 2 vs 1
			//IL_06fa->IL062b: Incompatible stack heights: 1 vs 0
			//IL_01b0->IL062b: Incompatible stack heights: 1 vs 0
			//IL_0754->IL062b: Incompatible stack heights: 2 vs 0
			//IL_01e4->IL062b: Incompatible stack heights: 2 vs 0
			//IL_0218->IL062b: Incompatible stack heights: 2 vs 0
			//IL_0264->IL062b: Incompatible stack heights: 2 vs 0
			//IL_02b8->IL02b8: Incompatible stack heights: 3 vs 2
			//IL_031c->IL062b: Incompatible stack heights: 3 vs 0
			//IL_0353->IL0353: Incompatible stack heights: 5 vs 4
			//IL_07cc->IL062b: Incompatible stack heights: 5 vs 0
			//IL_03be->IL062b: Incompatible stack heights: 5 vs 0
			//IL_0831->IL062b: Incompatible stack heights: 5 vs 0
			//IL_04dc->IL08fb: Incompatible stack heights: 5 vs 1
			//IL_04e1->IL04e1: Incompatible stack heights: 5 vs 1
			Background6 background = CS_0024_003C_003E8__locals24._003C_003E4__this;
			if ((object)CS_0024_003C_003E8__locals24._003C_003E4__this != null && (object)background._snapAnimation != null)
			{
				background._snapAnimation.SetAnimation("snap_do");
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Detune = 1000f;
				soundConfig.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.BGM_GameOver, soundConfig, 0f, 10, time);
				Background6 background2 = CS_0024_003C_003E8__locals24._003C_003E4__this;
				if ((object)CS_0024_003C_003E8__locals24._003C_003E4__this != null && (object)background2._mainCamera != null)
				{
					Transform transform = background2._mainCamera.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						float number = CS_0024_003C_003E8__locals24.number;
						bool flag2 = !(CS_0024_003C_003E8__locals24.number > 0f);
						float num = 0f;
						int num2 = 10;
						object obj = 0;
						if (!flag2)
						{
							object obj3 = default(object);
							object obj2 = obj3;
							object obj4 = 0;
							float number2 = CS_0024_003C_003E8__locals24.number;
							float num3 = 0f;
							int num4 = 10;
							object obj5 = 0;
							Vector2 pos = default(Vector2);
							object obj9 = default(object);
							bool flag10;
							do
							{
								bool flag3 = (nint)obj4 >= 500;
								obj3 = obj2;
								number = number2;
								num = num3;
								num2 = num4;
								obj = obj5;
								if (flag3)
								{
									break;
								}
								_003C_003Ec__DisplayClass94_1 obj6 = new _003C_003Ec__DisplayClass94_1();
								object obj7 = UnityEngine.Random.value;
								object obj8 = UnityEngine.Random.value;
								TweenConfig tweenConfig;
								TweenCallback tweenCallback;
								if ((object)CS_0024_003C_003E8__locals24._003C_003E4__this != null)
								{
									GameObject gameObject = CS_0024_003C_003E8__locals24._003C_003E4__this.gameObject;
									SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, pos, "items", "goldenegg");
									if ((object)spriteRenderer != null)
									{
										bool flag4 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
										Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, 9000);
										Background6 background3 = CS_0024_003C_003E8__locals24._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals24._003C_003E4__this != null)
										{
											Transform transform2 = spriteRenderer.transform;
											if ((object)transform2 != null)
											{
												transform2.SetParent(background3._spritesRootTransform, worldPositionStays: true);
												if (obj6 != null)
												{
													obj6.s = spriteRenderer;
													tweenConfig = new TweenConfig();
													object[] array = new object[2];
													if (array != null)
													{
														if ((object)obj6.s != null)
														{
															nint num5 = (nint)array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															bool flag5 = obj9 == null;
														}
														bool flag6 = array.Length <= 0;
														array[0] = obj6.s;
														Transform s = (Transform)(object)obj6.s;
														if ((object)obj6.s != null)
														{
															bool flag7 = ((UnityEngine.Object)s).m_CachedPtr == (IntPtr)0;
															IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)s).m_CachedPtr);
															Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
															if ((object)transform3 != null)
															{
																Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform3);
																bool flag8 = (object)transform4 == null;
															}
															bool flag9 = array.Length <= 1;
															array[1] = transform3;
															if (tweenConfig != null)
															{
																tweenConfig.targets = array;
																Background6 background4 = CS_0024_003C_003E8__locals24._003C_003E4__this;
																if ((object)CS_0024_003C_003E8__locals24._003C_003E4__this != null)
																{
																	object obj10 = UnityEngine.Random.value;
																	float num6 = (float)background4._camBounds * 48f;
																	float num7 = num6 * 0.01f;
																	tweenConfig.x = (float?)(object)1;
																	Background6 background5 = CS_0024_003C_003E8__locals24._003C_003E4__this;
																	if ((object)CS_0024_003C_003E8__locals24._003C_003E4__this != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2393 @ rcx_v95 (VampireSurvivors.Objects.Stages.Background6)+34]");
																		nint num8 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2393 @ rcx_v95 (VampireSurvivors.Objects.Stages.Background6)+40]");
																		object obj11 = num8 - 0;
																		num = (float)obj11 + 0.32f;
																		tweenConfig.y = (float?)(object)1;
																		object obj12 = UnityEngine.Random.value;
																		float num9 = num7 * 180f;
																		float num10 = num9 + 180f;
																		tweenConfig.angle = (float?)(object)1;
																		object obj13 = UnityEngine.Random.value;
																		float num11 = num10 * 300f;
																		tweenConfig.ease = Ease.InCirc;
																		float duration = num11 + 300f;
																		tweenConfig.duration = duration;
																		float delay = (float)obj4 * 10f;
																		tweenConfig.delay = delay;
																		tweenCallback = null;
																		nint num12 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																		num2 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ r10_v19 (Il2CppMethodInfo)+8]");
																		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
																		((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass94_1._003CSnapEggs_003Eb__1);
																		((Delegate)tweenCallback).m_target = obj6;
																		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ r10_v19 (Il2CppMethodInfo)+4C]");
																		object obj14 = (nint)0 >> 4;
																		object obj15 = obj14 & 1;
																		nint num13;
																		if (obj15 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ r10_v19 (Il2CppMethodInfo)+52]");
																			if ((nint)0 == 0)
																			{
																				num13 = unchecked((nint)6447293664L);
																				goto IL_08c0;
																			}
																		}
																		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
																		num13 = ((Delegate)tweenCallback).method_ptr;
																		goto IL_08c0;
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
								goto IL_062b;
								IL_08c0:
								object obj16 = 24;
								((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
								tweenConfig.onComplete = tweenCallback;
								obj = 24;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								number = CS_0024_003C_003E8__locals24.number;
								obj4++;
								float number3 = CS_0024_003C_003E8__locals24.number;
								flag10 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)number3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
								obj3 = obj4;
								obj2 = obj4;
								number2 = CS_0024_003C_003E8__locals24.number;
								num3 = num;
								num4 = num2;
								obj5 = 24;
							}
							while (flag10);
						}
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						Background6 background6 = CS_0024_003C_003E8__locals24._003C_003E4__this;
						if ((object)CS_0024_003C_003E8__locals24._003C_003E4__this != null && array2 != null)
						{
							if ((object)background6._snap != null)
							{
								nint num14 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj17 = default(object);
								bool flag11 = obj17 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig2 != null)
							{
								tweenConfig2.targets = array2;
								tweenConfig2.alpha = (float?)(object)1;
								tweenConfig2.duration = 300f;
								float num15 = CS_0024_003C_003E8__locals24.number;
								if (!(500f > CS_0024_003C_003E8__locals24.number))
								{
									num15 = 500f;
								}
								float num16 = num15 * 10f;
								float delay2 = num16 + 600f;
								tweenConfig2.delay = delay2;
								MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
								return;
							}
						}
					}
				}
			}
			goto IL_062b;
			IL_062b:
			throw new NullReferenceException();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void MakeCircles()
	{
		//IL_004b: Expected I4, but got I8
		//IL_00d6: Expected I4, but got I8
		//IL_0161: Expected I4, but got I8
		//IL_01ec: Expected I4, but got I8
		//IL_0277: Expected I4, but got I8
		//IL_02e6: Expected I4, but got I8
		//IL_0355: Expected I4, but got I8
		//IL_03c4: Expected I4, but got I8
		//IL_0445: Expected I, but got O
		//IL_049d: Expected I, but got O
		//IL_0505: Expected I4, but got I8
		//IL_0513: Expected O, but got I4
		//IL_057d: Expected I, but got O
		//IL_05d5: Expected I, but got O
		//IL_062b: Expected O, but got I4
		//IL_064b: Expected I4, but got I8
		//IL_06b0: Expected I, but got O
		//IL_0708: Expected I, but got O
		//IL_075e: Expected O, but got I4
		//IL_077e: Expected I4, but got I8
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "background6", "sun");
		PhaserSprite phaserSprite2 = phaserSprite.setDepth(-3001);
		PhaserSprite phaserSprite3 = phaserSprite2.setTintFill(isEnabled: true, 526344u);
		GameObject gameObject2 = phaserSprite3.gameObject;
		((UnityEngine.Object)gameObject2).SetName("sSunCircle");
		_sSunCircle = phaserSprite3;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "background6", "moon");
		PhaserSprite phaserSprite5 = phaserSprite4.setDepth(-3001);
		PhaserSprite phaserSprite6 = phaserSprite5.setTintFill(isEnabled: true, 526344u);
		GameObject gameObject4 = phaserSprite6.gameObject;
		((UnityEngine.Object)gameObject4).SetName("sMoonCircle");
		_sMoonCircle = phaserSprite6;
		GameObject gameObject5 = base.gameObject;
		PhaserSprite phaserSprite7 = RenderingExtensions.AddPhaserSprite(gameObject5, pos, "background6", "world");
		PhaserSprite phaserSprite8 = phaserSprite7.setDepth(-3001);
		PhaserSprite phaserSprite9 = phaserSprite8.setTintFill(isEnabled: true, 526344u);
		GameObject gameObject6 = phaserSprite9.gameObject;
		((UnityEngine.Object)gameObject6).SetName("sWorldCircle");
		_sWorldCircle = phaserSprite9;
		GameObject gameObject7 = base.gameObject;
		PhaserSprite phaserSprite10 = RenderingExtensions.AddPhaserSprite(gameObject7, pos, "background6", "center");
		PhaserSprite phaserSprite11 = phaserSprite10.setDepth(-3001);
		PhaserSprite phaserSprite12 = phaserSprite11.setTintFill(isEnabled: true, 526344u);
		GameObject gameObject8 = phaserSprite12.gameObject;
		((UnityEngine.Object)gameObject8).SetName("sCentralCircle");
		_sCentralCircle = phaserSprite12;
		GameObject gameObject9 = base.gameObject;
		PhaserSprite phaserSprite13 = RenderingExtensions.AddPhaserSprite(gameObject9, pos, "background6", "sun");
		PhaserSprite phaserSprite14 = phaserSprite13.setDepth(-3000);
		GameObject gameObject10 = phaserSprite14.gameObject;
		((UnityEngine.Object)gameObject10).SetName("sunCircle");
		_sunCircle = phaserSprite14;
		GameObject gameObject11 = base.gameObject;
		PhaserSprite phaserSprite15 = RenderingExtensions.AddPhaserSprite(gameObject11, pos, "background6", "moon");
		PhaserSprite phaserSprite16 = phaserSprite15.setDepth(-3000);
		GameObject gameObject12 = phaserSprite16.gameObject;
		((UnityEngine.Object)gameObject12).SetName("moonCircle");
		_moonCircle = phaserSprite16;
		GameObject gameObject13 = base.gameObject;
		PhaserSprite phaserSprite17 = RenderingExtensions.AddPhaserSprite(gameObject13, pos, "background6", "world");
		PhaserSprite phaserSprite18 = phaserSprite17.setDepth(-3000);
		GameObject gameObject14 = phaserSprite18.gameObject;
		((UnityEngine.Object)gameObject14).SetName("worldCircle");
		_worldCircle = phaserSprite18;
		GameObject gameObject15 = base.gameObject;
		PhaserSprite phaserSprite19 = RenderingExtensions.AddPhaserSprite(gameObject15, pos, "background6", "center");
		PhaserSprite phaserSprite20 = phaserSprite19.setDepth(-3000);
		GameObject gameObject16 = phaserSprite20.gameObject;
		((UnityEngine.Object)gameObject16).SetName("centralCircle");
		_centralCircle = phaserSprite20;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_sunCircle != null)
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
		if ((object)_sSunCircle != null)
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
		tweenConfig.duration = 12000f;
		tweenConfig.repeat = -1;
		tweenConfig.angle = (float?)(object)1;
		MultiTargetTween sunCircleTween = Tweens.Add(tweenConfig);
		_sunCircleTween = sunCircleTween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		if ((object)_moonCircle != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sMoonCircle != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.angle = (float?)(object)1;
		tweenConfig2.duration = 24000f;
		tweenConfig2.repeat = -1;
		MultiTargetTween moonCircleTween = Tweens.Add(tweenConfig2);
		_moonCircleTween = moonCircleTween;
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[2];
		if ((object)_worldCircle != null)
		{
			nint num5 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sWorldCircle != null)
		{
			nint num6 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.angle = (float?)(object)1;
		tweenConfig3.duration = 36000f;
		tweenConfig3.repeat = -1;
		MultiTargetTween worldCircleTween = Tweens.Add(tweenConfig3);
		_worldCircleTween = worldCircleTween;
	}

	private unsafe void MakeFireEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_1436: Unknown result type (might be due to invalid IL or missing references)
		//IL_143b: Expected O, but got Unknown
		//IL_01f5: Expected O, but got I4
		//IL_0225: Expected O, but got Ref
		//IL_0243: Expected native int or pointer, but got O
		//IL_025d: Expected O, but got I
		//IL_028b: Expected O, but got I4
		//IL_02a4: Expected O, but got Ref
		//IL_02be: Expected native int or pointer, but got O
		//IL_146a: Expected O, but got I4
		//IL_02e3: Expected O, but got Ref
		//IL_02fd: Expected native int or pointer, but got O
		//IL_14a4: Expected O, but got I
		//IL_0335: Expected O, but got Ref
		//IL_034f: Expected native int or pointer, but got O
		//IL_14de: Expected O, but got I
		//IL_03a0: Expected O, but got I
		//IL_1514: Expected O, but got I
		//IL_16ef: Expected O, but got Ref
		//IL_0583: Expected O, but got I4
		//IL_05d1: Expected O, but got Ref
		//IL_05ef: Expected native int or pointer, but got O
		//IL_0609: Expected O, but got I
		//IL_0637: Expected O, but got I4
		//IL_0650: Expected O, but got Ref
		//IL_066a: Expected native int or pointer, but got O
		//IL_0692: Expected O, but got I
		//IL_1579: Expected O, but got I
		//IL_06a5: Expected O, but got Ref
		//IL_06bf: Expected native int or pointer, but got O
		//IL_15b3: Expected O, but got I
		//IL_06f7: Expected O, but got Ref
		//IL_0711: Expected native int or pointer, but got O
		//IL_15ed: Expected O, but got I
		//IL_0768: Expected O, but got I
		//IL_078f: Expected O, but got I
		//IL_07b0: Expected O, but got I
		//IL_1623: Expected O, but got I
		//IL_1724: Expected O, but got Ref
		//IL_0a35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3a: Expected O, but got Unknown
		//IL_0a48: Expected O, but got I4
		//IL_0a8b: Expected O, but got I
		//IL_0a9e: Expected O, but got Ref
		//IL_0ac4: Expected F4, but got I
		//IL_0abf: Expected native int or pointer, but got O
		//IL_0ad9: Expected O, but got I
		//IL_0b07: Expected O, but got I4
		//IL_0b20: Expected O, but got Ref
		//IL_0b3a: Expected native int or pointer, but got O
		//IL_0b7f: Expected O, but got I
		//IL_0ba7: Expected O, but got Ref
		//IL_0bc1: Expected native int or pointer, but got O
		//IL_0c06: Expected O, but got I
		//IL_0c33: Expected O, but got Ref
		//IL_0c4d: Expected native int or pointer, but got O
		//IL_0c92: Expected O, but got I
		//IL_0cd3: Expected O, but got I
		//IL_0d1a: Expected O, but got I
		//IL_0dda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddf: Expected O, but got Unknown
		//IL_0ded: Expected O, but got I4
		//IL_0e30: Expected O, but got I
		//IL_0e43: Expected O, but got Ref
		//IL_0e69: Expected F4, but got I
		//IL_0e64: Expected native int or pointer, but got O
		//IL_0e7e: Expected O, but got I
		//IL_0eac: Expected O, but got I4
		//IL_0ec5: Expected O, but got Ref
		//IL_0edf: Expected native int or pointer, but got O
		//IL_0f24: Expected O, but got I
		//IL_0f4c: Expected O, but got Ref
		//IL_0f66: Expected native int or pointer, but got O
		//IL_0fab: Expected O, but got I
		//IL_0fd8: Expected O, but got Ref
		//IL_0ff2: Expected native int or pointer, but got O
		//IL_1037: Expected O, but got I
		//IL_107e: Expected O, but got I
		//IL_10a5: Expected O, but got I
		//IL_10c6: Expected O, but got I
		//IL_16aa: Expected O, but got I
		//IL_1144: Expected I4, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background6)+40]");
		object obj4 = default(object);
		object obj3 = obj4 - 0;
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "PfxEmitter");
		Transform transform = gameObject.transform;
		transform.SetParent(_spritesRootTransform, worldPositionStays: false);
		ParticleEmitterManager pfxEmitter = gameObject.AddComponent<ParticleEmitterManager>();
		_pfxEmitter = pfxEmitter;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("shop");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"colours7");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"colours8");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		float constant = (float)obj3 - 3.36f;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 336));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, renderer.width));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+150]");
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+160]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(5000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 368));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-100f, -300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+180]");
		_ = 0;
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 400));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+190]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1A0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 432));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1C0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+3F0]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem pfxFireRed = _pfxEmitter.CreateEmitter(particleSystemConfig, null, "PfxFireRed1");
		_pfxFireRed1 = pfxFireRed;
		_ = _pfxFireRed1;
		_ = _pfxFireRed1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 1024));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2200 @ rax_v60 (should have been resolved before IL gen)");
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("shop");
		List<string> list2 = new List<string>();
		list2._002Ector();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"colours7");
		}
		else
		{
			int size3 = list2._size + 1;
			list2._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"colours8");
		}
		else
		{
			int size4 = list2._size + 1;
			list2._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		float constant2 = (float)obj3 - 3.36f;
		minMaxCurve = new ParticleSystem.MinMaxCurve(constant2);
		particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 464));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, renderer2.width));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1D0]");
			particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1E0]");
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(5000f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 496));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(-100f, -300f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1F0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+200]");
			obj = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
			particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 528));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+210]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+220]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 560));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(1f, 2f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+230]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+240]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
			particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+3F0]");
			particleSystemConfig2._quantity = (int?)(object)0;
			_ = 1133903872;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+3F0]");
			particleSystemConfig2._frequency = (float?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+3F0]");
			particleSystemConfig2._blendMode = (VampireSurvivors.Framework.Particles.BlendMode?)(object)0;
			ParticleSystem pfxFireRed2 = _pfxEmitter.CreateEmitter(particleSystemConfig2, null, "PfxFireRed2");
			_pfxFireRed2 = pfxFireRed2;
			_ = _pfxFireRed2;
			_ = _pfxFireRed2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj7 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 1032));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3110 @ rax_v100 (should have been resolved before IL gen)");
			List<string> list3 = new List<string>();
			int version5 = list3._version + 1;
			list3._version = version5;
			string[] items5 = list3._items;
			if (list3._size >= items5.Length)
			{
				((List<object>)(object)list3).AddWithResize((object)"colours7");
			}
			else
			{
				int size5 = list3._size + 1;
				list3._size = size5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version6 = list3._version + 1;
			list3._version = version6;
			string[] items6 = list3._items;
			if (list3._size >= items6.Length)
			{
				((List<object>)(object)list3).AddWithResize((object)"colours8");
			}
			else
			{
				int size6 = list3._size + 1;
				list3._size = size6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int cycleCount = default(int);
			RenderingExtensions.SetFrames(_pfxFireRed1, list3, null, clearExistingFrames: false, cycleCount);
			List<string> list4 = new List<string>();
			list4.Add("colours7");
			list4.Add("colours8");
			RenderingExtensions.SetFrames(_pfxFireRed2, list4, null, clearExistingFrames: false, cycleCount);
			ParticleSystemConfig particleSystemConfig3 = new ParticleSystemConfig("shop");
			List<string> list5 = new List<string>();
			list5.Add("colours3");
			list5.Add("colours4");
			particleSystemConfig3._frame = list5;
			float constant3 = (float)obj3 - 3.36f;
			minMaxCurve = new ParticleSystem.MinMaxCurve(constant3);
			object obj9 = particleSystemConfig3 + 56;
			particleSystemConfig3._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rax_v124+28]");
				object obj10 = 0;
				ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 592));
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rcx_v111+10]");
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(0f, 0f));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+250]");
				particleSystemConfig3._x = (ParticleSystem.MinMaxCurve)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+260]");
				_ = 0;
				minMaxCurve = new ParticleSystem.MinMaxCurve(5000f);
				particleSystemConfig3._lifespan = (ParticleSystem.MinMaxCurve)0;
				_ = 0;
				ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 624));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(-100f, -300f));
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+270]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+280]");
				_ = 0;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
				particleSystemConfig3._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+80]");
				_ = 0;
				ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 656));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(1f, 0f));
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+290]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2A0]");
				_ = 0;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+88]");
				particleSystemConfig3._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+98]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A8]");
				_ = 0;
				ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 688));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(1f, 2f));
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2B0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2C0]");
				_ = 0;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
				particleSystemConfig3._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
				_ = 0;
				_ = 0;
				_ = 1;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+3F0]");
				particleSystemConfig3._quantity = (int?)(object)0;
				ParticleSystem pfxFire = _pfxEmitter.CreateEmitter(particleSystemConfig3, null, "PfxFire1");
				_pfxFire1 = pfxFire;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj11 == null)
					{
						MissingMethodException ex3 = new MissingMethodException();
						throw ex3;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3293 @ rax_v143 (should have been resolved before IL gen)");
				ParticleSystemConfig particleSystemConfig4 = new ParticleSystemConfig("shop");
				List<string> list6 = new List<string>();
				list6._002Ector();
				list6.Add("colours3");
				list6.Add("colours4");
				particleSystemConfig4._frame = list6;
				float constant4 = (float)obj3 - 3.36f;
				minMaxCurve = new ParticleSystem.MinMaxCurve(constant4);
				object obj12 = particleSystemConfig4 + 56;
				particleSystemConfig4._y = (ParticleSystem.MinMaxCurve)0;
				_ = 0;
				if ((object)GM.Core != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rax_v155+28]");
					object obj13 = 0;
					ParticleSystem.MinMaxCurve minMaxCurve14 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 720));
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rcx_v139+10]");
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve14, new ParticleSystem.MinMaxCurve(0f, 0f));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2D0]");
					particleSystemConfig4._x = (ParticleSystem.MinMaxCurve)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2E0]");
					_ = 0;
					minMaxCurve = new ParticleSystem.MinMaxCurve(5000f);
					particleSystemConfig4._lifespan = (ParticleSystem.MinMaxCurve)0;
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve15 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 752));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve15, new ParticleSystem.MinMaxCurve(-100f, -300f));
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2F0]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+300]");
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D8]");
					particleSystemConfig4._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F8]");
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve16 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 784));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve16, new ParticleSystem.MinMaxCurve(1f, 0f));
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+310]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+320]");
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
					particleSystemConfig4._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+110]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+120]");
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve17 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 816));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve17, new ParticleSystem.MinMaxCurve(1f, 2f));
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+330]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+340]");
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+128]");
					particleSystemConfig4._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+138]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+148]");
					_ = 0;
					_ = 0;
					_ = 1;
					_ = 1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+3F0]");
					particleSystemConfig4._quantity = (int?)(object)0;
					_ = 1133903872;
					_ = 1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+3F0]");
					particleSystemConfig4._frequency = (float?)(object)0;
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+3F0]");
					particleSystemConfig4._blendMode = (VampireSurvivors.Framework.Particles.BlendMode?)(object)0;
					ParticleSystem pfxFire2 = _pfxEmitter.CreateEmitter(particleSystemConfig4, null, "PfxFire2");
					_pfxFire2 = pfxFire2;
					_ = _pfxFire2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj14 == null)
						{
							MissingMethodException ex4 = new MissingMethodException();
							throw ex4;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3517 @ rax_v177 (should have been resolved before IL gen)");
					ParticleEmitterManager particleEmitterManager = _pfxEmitter.SetDepth(-5000);
					List<string> list7 = new List<string>();
					int version7 = list7._version + 1;
					list7._version = version7;
					string[] items7 = list7._items;
					if (list7._size >= items7.Length)
					{
						((List<object>)(object)list7).AddWithResize((object)"colours3");
					}
					else
					{
						int size7 = list7._size + 1;
						list7._size = size7;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version8 = list7._version + 1;
					list7._version = version8;
					string[] items8 = list7._items;
					if (list7._size >= items8.Length)
					{
						((List<object>)(object)list7).AddWithResize((object)"colours4");
					}
					else
					{
						int size8 = list7._size + 1;
						list7._size = size8;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					RenderingExtensions.SetFrames(_pfxFire1, list7, null, clearExistingFrames: false, cycleCount);
					List<string> list8 = new List<string>();
					int version9 = list8._version + 1;
					list8._version = version9;
					string[] items9 = list8._items;
					if (list8._size >= items9.Length)
					{
						((List<object>)(object)list8).AddWithResize((object)"colours3");
					}
					else
					{
						int size9 = list8._size + 1;
						list8._size = size9;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version10 = list8._version + 1;
					list8._version = version10;
					string[] items10 = list8._items;
					if (list8._size >= items10.Length)
					{
						((List<object>)(object)list8).AddWithResize((object)"colours4");
					}
					else
					{
						int size10 = list8._size + 1;
						list8._size = size10;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					RenderingExtensions.SetFrames(_pfxFire2, list8, null, clearExistingFrames: false, cycleCount);
					RenderingExtensions.Start(_pfxFire1);
					RenderingExtensions.Start(_pfxFire2);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void MakeWindows()
	{
		//IL_027f: Invalid comparison between F4 and I4
		//IL_029f: Expected O, but got I4
		//IL_053b: Invalid comparison between F4 and I4
		//IL_04e2: Expected O, but got I4
		//IL_04fe: Expected O, but got I4
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Expected O, but got Unknown
		//IL_048b: Invalid comparison between F4 and O
		//IL_03a5: Expected O, but got I4
		//IL_03c0: Expected I4, but got I8
		//IL_03dc: Expected O, but got I4
		//IL_040b: Expected O, but got I
		//IL_0443: Expected O, but got I4
		//IL_044b: Invalid comparison between F4 and O
		//IL_045b: Expected O, but got I4
		//IL_0464: Expected F4, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.width / 1.28f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
		float num2 = num + 1f;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num3 = renderer2.height / 3.58f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E0DC");
		float num4 = num3 + 1f;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"window2.png");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"window4.png");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		List<object> items3 = (List<object>)(object)list._items;
		if (list._size >= items3._size)
		{
			((List<object>)(object)list).AddWithResize((object)"window5.png");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		if (num2 > 0f)
		{
			float? num5 = (float?)(object)0;
			Vector2 pos = default(Vector2);
			IntPtr intPtr = default(IntPtr);
			object arg = default(object);
			do
			{
				if (num4 > 0f)
				{
					bool flag3;
					do
					{
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(this, pos, "shop", "window2");
						PhaserSprite phaserSprite2 = phaserSprite.setTint(0u);
						string spriteName = VampireSurvivors.App.Tools.Extensions.PickRnd(list);
						PhaserSprite phaserSprite3 = phaserSprite2.setFrame(spriteName, "shop");
						float value = UnityEngine.Random.value;
						bool flag = value < 0.5f;
						bool flipX = !flag;
						PhaserSprite phaserSprite4 = phaserSprite3.setFlipX(flipX);
						float value2 = UnityEngine.Random.value;
						bool flag2 = value2 < 0.5f;
						bool flipY = !flag2;
						PhaserSprite phaserSprite5 = phaserSprite4.setFlipY(flipY);
						PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0f);
						PhaserSprite phaserSprite7 = phaserSprite6.setScale(-0.1f, (float?)(object)1);
						PhaserSprite phaserSprite8 = phaserSprite7.setDepth(-4900);
						PhaserSprite phaserSprite9 = phaserSprite8.setOrigin(0f, (float?)(object)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
						string text = $"Window[{(nint)intPtr}][{arg}]";
						object obj = phaserSprite9.setName(text);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
						float? num6 = (float?)(object)(0 + 1);
						flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num6);
						float? num7 = (float?)(object)0;
						float num8 = 0f;
					}
					while (flag3);
				}
				num5 = (float?)(object)((_003F?)num5 + 1);
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num5));
		}
		TweenConfig tweenConfig = new TweenConfig();
		PhaserSprite[] targets = _windows.ToArray();
		tweenConfig.targets = targets;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.duration = 1000f;
		tweenConfig.scaleX = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void MakeDirector()
	{
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickupDirecter = GM.Core.MakeStagePickup(pos, ItemType.DIRECTER, WeaponType.VOID, value, relicType, validatePickups);
		_pickupDirecter = pickupDirecter;
	}

	private void InitShatterVfx()
	{
		//IL_028a: Expected O, but got I4
		//IL_00e6->IL0333: Incompatible stack heights: 1 vs 0
		//IL_03c5->IL0333: Incompatible stack heights: 1 vs 0
		//IL_011a->IL0333: Incompatible stack heights: 1 vs 0
		//IL_0138->IL0333: Incompatible stack heights: 1 vs 0
		//IL_03ec->IL0333: Incompatible stack heights: 1 vs 0
		//IL_016c->IL0333: Incompatible stack heights: 1 vs 0
		//IL_01a8->IL0333: Incompatible stack heights: 1 vs 0
		//IL_01e4->IL0333: Incompatible stack heights: 1 vs 0
		//IL_0213->IL0333: Incompatible stack heights: 1 vs 0
		//IL_02d4->IL0333: Incompatible stack heights: 1 vs 0
		//IL_0300->IL0333: Incompatible stack heights: 1 vs 0
		//IL_0415->IL0333: Incompatible stack heights: 1 vs 0
		//IL_0333->IL036d: Incompatible stack heights: 1 vs 0
		ShatterVFX shatterVfx = _shatterVfx;
		if ((object)_shatterVfx != null && ((UnityEngine.Object)shatterVfx).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		if ((object)_spritesRootTransform != null)
		{
			GameObject gameObject = _spritesRootTransform.gameObject;
			if ((object)_mainCamera != null)
			{
				Transform transform = _mainCamera.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Vector2 pos = default(Vector2);
					SpriteRenderer component = RenderingExtensions.AddGraphic(gameObject, pos);
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer = s_scene._renderer;
							if (s_scene._renderer != null && (object)GM.Core != null)
							{
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									PhaserScene.Renderer renderer2 = s_scene2._renderer;
									if (s_scene2._renderer != null)
									{
										SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, renderer.width, renderer2.height);
										if ((object)spriteRenderer != null)
										{
											((UnityEngine.Object)spriteRenderer).SetName("ShatterVFX");
											_shatterVfxRenderer = spriteRenderer;
											if ((object)_shatterVfxRenderer != null)
											{
												_shatterVfxRenderer.sortingLayerName = "UI";
												if ((object)_shatterVfxRenderer != null)
												{
													_shatterVfxRenderer.sortingOrder = 10;
													ShatterVFX.ShatterDetails shatterDetails = new ShatterVFX.ShatterDetails
													{
														horizontalCuts = 8,
														verticalCuts = 8,
														shatterType = ShatterVFX.ShatterType.Radial,
														radialSectors = 13,
														radials = 3,
														radialCentre = (Vector2)1056964608
													};
													_ = 1056964608;
													shatterDetails.randomSeed = 61;
													shatterDetails.randomizeAtRunTime = false;
													shatterDetails.randomness = 1f;
													if ((object)_shatterVfxRenderer != null)
													{
														GameObject gameObject2 = _shatterVfxRenderer.gameObject;
														if ((object)gameObject2 != null)
														{
															ShatterVFX shatterVfx2 = gameObject2.AddComponent<ShatterVFX>();
															_shatterVfx = shatterVfx2;
															ShatterVFX shatterVfx3 = _shatterVfx;
															if ((object)_shatterVfx != null)
															{
																shatterVfx3.shatterDetails = shatterDetails;
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
		throw new NullReferenceException();
	}

	private IEnumerator ShatterImageRoutine()
	{
		_003CShatterImageRoutine_003Ed__100 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void Shatter()
	{
		//IL_00b2: Expected O, but got Ref
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected I4, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		//IL_08eb: Expected I, but got O
		//IL_0901: Expected O, but got I
		//IL_090a: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Expected O, but got Unknown
		//IL_0985: Expected I, but got O
		//IL_09ec: Expected O, but got F4
		//IL_0b85: Expected O, but got I4
		//IL_0b9c: Expected I, but got I8
		//IL_0c01: Expected O, but got F4
		//IL_09fa: Expected O, but got F4
		//IL_0961: Expected I, but got I8
		//IL_0aaa: Expected O, but got Ref
		//IL_058d: Expected O, but got Ref
		//IL_087a: Unknown result type (might be due to invalid IL or missing references)
		//IL_087f: Expected O, but got Unknown
		//IL_0a54->IL09a8: Incompatible stack heights: 1 vs 0
		//IL_0af6->IL09a8: Incompatible stack heights: 2 vs 0
		//IL_0526->IL09a8: Incompatible stack heights: 2 vs 0
		//IL_0b39->IL09a8: Incompatible stack heights: 3 vs 0
		//IL_06d9->IL09a8: Incompatible stack heights: 3 vs 0
		//IL_0b56->IL09a8: Incompatible stack heights: 4 vs 0
		//IL_0823->IL09a8: Incompatible stack heights: 4 vs 0
		//IL_08a0->IL0b5b: Incompatible stack heights: 5 vs 0
		Texture2D capturedScreenshot = _capturedScreenshot;
		if ((object)_capturedScreenshot == null || ((UnityEngine.Object)capturedScreenshot).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if ((object)_capturedScreenshot != null)
		{
			int width = _capturedScreenshot.width;
			if ((object)_capturedScreenshot != null)
			{
				int height = _capturedScreenshot.height;
				Vector2 vector = default(Vector2);
				Vector2 vector2 = default(Vector2);
				uint num = default(uint);
				SpriteMeshType meshType = default(SpriteMeshType);
				Sprite sprite = Sprite.Create(_capturedScreenshot, (Rect)(&vector), vector2, 100f, num, meshType);
				if ((object)_shatterVfxRenderer != null)
				{
					_shatterVfxRenderer.sprite = sprite;
					float2 rendererSizeIgnoringBorders = RenderingHelper.GetRendererSizeIgnoringBorders();
					if ((object)_capturedScreenshot != null)
					{
						int height2 = _capturedScreenshot.height;
						object obj = default(object);
						int num2 = obj / height2;
						float num3 = (float)num2 * 100f;
						SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_shatterVfxRenderer, num3, num3);
						if ((object)_shatterVfx != null)
						{
							SpriteRenderer[] array = _shatterVfx.Shatter();
							Tween[] shatterMoveTweens = _shatterMoveTweens;
							bool flag = _shatterMoveTweens == null;
							Texture2D texture2D = null;
							Texture2D texture2D2 = null;
							if (!flag)
							{
								while ((nint)texture2D2 < shatterMoveTweens.Length)
								{
									if (shatterMoveTweens[(object)texture2D] != null)
									{
										DG.Tweening.TweenExtensions.Kill(shatterMoveTweens[(object)texture2D]);
									}
									texture2D = (Texture2D)(texture2D + 1);
									texture2D2 = texture2D;
								}
								Tween[] shatterAngleTweens = _shatterAngleTweens;
								bool flag2 = _shatterAngleTweens == null;
								Texture2D texture2D3 = null;
								Texture2D texture2D4 = null;
								if (!flag2)
								{
									while ((nint)texture2D4 < shatterAngleTweens.Length)
									{
										if (shatterAngleTweens[(object)texture2D3] != null)
										{
											DG.Tweening.TweenExtensions.Kill(shatterAngleTweens[(object)texture2D3]);
										}
										texture2D3 = (Texture2D)(texture2D3 + 1);
										texture2D4 = texture2D3;
									}
									Tween[] shatterAlphaTweens = _shatterAlphaTweens;
									bool flag3 = _shatterAlphaTweens == null;
									Texture2D texture2D5 = null;
									Texture2D texture2D6 = null;
									if (!flag3)
									{
										while ((nint)texture2D6 < shatterAlphaTweens.Length)
										{
											if (shatterAlphaTweens[(object)texture2D5] != null)
											{
												DG.Tweening.TweenExtensions.Kill(shatterAlphaTweens[(object)texture2D5]);
											}
											texture2D5 = (Texture2D)(texture2D5 + 1);
											texture2D6 = texture2D5;
										}
										if (array != null)
										{
											Tween[] shatterMoveTweens2 = new Tween[array.Length];
											_shatterMoveTweens = shatterMoveTweens2;
											Tween[] shatterAngleTweens2 = new Tween[array.Length];
											_shatterAngleTweens = shatterAngleTweens2;
											Tween[] shatterAlphaTweens2 = new Tween[array.Length];
											_shatterAlphaTweens = shatterAlphaTweens2;
											Texture2D texture2D7 = null;
											vector = vector2;
											Texture2D texture2D8 = null;
											Vector2 vector3 = default(Vector2);
											while (true)
											{
												TweenCallback tweenCallback;
												if ((nint)texture2D8 >= array.Length)
												{
													tweenCallback = null;
													nint num4 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ r10_v14 (Il2CppMethodInfo)+8]");
													((Delegate)tweenCallback).method_ptr = (IntPtr)0;
													((Delegate)tweenCallback).method = (nint)__ldftn(Background6._003CShatter_003Eb__101_0);
													((Delegate)tweenCallback).m_target = this;
													((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ r10_v14 (Il2CppMethodInfo)+4C]");
													object obj2 = (nint)0 >> 4;
													object obj3 = obj2 & 1;
													nint num5;
													if (obj3 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ r10_v14 (Il2CppMethodInfo)+52]");
														if ((nint)0 == 0)
														{
															num5 = unchecked((nint)6447293664L);
															goto IL_0b7c;
														}
													}
													num5 = ((Delegate)tweenCallback).method_ptr;
													((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
													goto IL_0b7c;
												}
												object obj4 = UnityEngine.Random.value;
												object obj5 = UnityEngine.Random.value;
												object obj6 = UnityEngine.Random.value;
												SpriteRenderer spriteRenderer2 = array[(object)texture2D7];
												if ((object)array[(object)texture2D7] == null)
												{
													break;
												}
												bool flag4 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
												IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr);
												Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
												if ((object)transform == null)
												{
													break;
												}
												bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
												Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
												Tween[] shatterMoveTweens3 = _shatterMoveTweens;
												TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOMove(transform, (Vector3)(&vector3), 1f);
												TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 0.15f);
												if (tweenerCore != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2463 @ rax_v106 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
													if ((nint)0 != 0)
													{
														_ = 1;
														_ = 0;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
												bool flag6 = (nint)0 != 0;
												int num6 = (int)num;
												if (!flag6)
												{
													_ = 1;
													num6 = (int)num;
												}
												if (tweenerCore == null || _shatterMoveTweens == null)
												{
													break;
												}
												TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(tweenerCore, 0.15f);
												bool flag7 = tweenerCore2 == null;
												shatterMoveTweens3[(object)texture2D7] = tweenerCore;
												Tween[] shatterAngleTweens3 = _shatterAngleTweens;
												TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = ShortcutExtensions.DOLocalRotate(transform, (Vector3)(&vector), 1f, RotateMode.FastBeyond360);
												TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = TweenSettingsExtensions.SetDelay(t2, 0.15f);
												if (tweenerCore3 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2693 @ rax_v116 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2693 @ rax_v116 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2693 @ rax_v116 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
															if ((nint)0 == 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2693 @ rax_v116 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
																if ((nint)0 == 0)
																{
																	_ = 1;
																}
															}
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2693 @ rax_v116 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
														if ((nint)0 != 0)
														{
															_ = 1;
															_ = 0;
														}
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
												if (tweenerCore3 == null || _shatterAngleTweens == null)
												{
													break;
												}
												TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = TweenSettingsExtensions.SetDelay(tweenerCore3, 0.15f);
												bool flag8 = tweenerCore4 == null;
												shatterAngleTweens3[(object)texture2D7] = tweenerCore3;
												Tween[] shatterAlphaTweens3 = _shatterAlphaTweens;
												TweenerCore<Color, Color, ColorOptions> t3 = DOTweenModuleSprite.DOFade(array[(object)texture2D7], 0f, 1f);
												TweenerCore<Color, Color, ColorOptions> tweenerCore5 = TweenSettingsExtensions.SetDelay(t3, 0.15f);
												if (tweenerCore5 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2973 @ rax_v127 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
													if ((nint)0 != 0)
													{
														_ = 1;
														_ = 0;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
												bool flag9 = (nint)0 != 0;
												num = (uint)num6;
												if (!flag9)
												{
													_ = 1;
													num = (uint)num6;
												}
												if (tweenerCore5 == null || _shatterAlphaTweens == null)
												{
													break;
												}
												SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale((SpriteRenderer)(object)tweenerCore5, 0.15f, 1f);
												bool flag10 = (object)spriteRenderer3 == null;
												shatterAlphaTweens3[(object)texture2D7] = tweenerCore5;
												texture2D7 = (Texture2D)(texture2D7 + 1);
												vector3 = vector2;
												vector = vector2;
												texture2D8 = texture2D7;
												continue;
												IL_0b7c:
												object obj7 = 24;
												((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
												Tween tween = DOVirtual.DelayedCall(1.1500001f, tweenCallback, ignoreTimeScale: false);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
												if (tween == null)
												{
													break;
												}
												tween.stringId = "DefaultGameTweenId";
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

	private void KillShatterTweens()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_0113: Expected O, but got I4
		//IL_011c: Expected O, but got I4
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		Tween[] shatterMoveTweens = _shatterMoveTweens;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < shatterMoveTweens.Length)
		{
			if (shatterMoveTweens[obj2] != null)
			{
				DG.Tweening.TweenExtensions.Kill(shatterMoveTweens[obj2]);
			}
			obj2++;
			obj = obj2;
		}
		Tween[] shatterAngleTweens = _shatterAngleTweens;
		object obj3 = 0;
		object obj4 = 0;
		while ((nint)obj3 < shatterAngleTweens.Length)
		{
			if (shatterAngleTweens[obj4] != null)
			{
				DG.Tweening.TweenExtensions.Kill(shatterAngleTweens[obj4]);
			}
			obj4++;
			obj3 = obj4;
		}
		Tween[] shatterAlphaTweens = _shatterAlphaTweens;
		object obj5 = 0;
		object obj6 = 0;
		while ((nint)obj5 < shatterAlphaTweens.Length)
		{
			if (shatterAlphaTweens[obj6] != null)
			{
				DG.Tweening.TweenExtensions.Kill(shatterAlphaTweens[obj6]);
			}
			obj6++;
			obj5 = obj6;
		}
	}

	private static void KillTween(Tween[] tweens)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < tweens.Length)
		{
			if (tweens[obj2] != null)
			{
				DG.Tweening.TweenExtensions.Kill(tweens[obj2]);
			}
			obj2++;
			obj = obj2;
		}
	}

	private void SpawnFakePlayerUILevelUp(float xPos, float yPos)
	{
		//IL_005d->IL00e1: Incompatible stack heights: 1 vs 0
		//IL_0087->IL00e1: Incompatible stack heights: 1 vs 0
		//IL_00ca->IL00e1: Incompatible stack heights: 1 vs 0
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C10");
				Transform transform2 = default(Transform);
				if ((object)transform2 != null)
				{
					Transform transform3 = ((GameObject)(object)transform2).transform;
					if ((object)transform3 != null)
					{
						transform3.SetParent(_spritesRootTransform, worldPositionStays: true);
						FakePlayerUILevelUp component = ((GameObject)(object)transform2).GetComponent<FakePlayerUILevelUp>();
						if ((object)component != null)
						{
							component.Init(xPos, yPos);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SendGem(bool isCluster, bool isRandomColor)
	{
		//IL_0c2a: Expected I4, but got I8
		//IL_0c58: Expected O, but got I4
		//IL_0c61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c66: Expected O, but got Unknown
		//IL_0c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c74: Expected I4, but got Unknown
		//IL_0c89: Expected O, but got I
		//IL_087d: Expected O, but got I4
		//IL_089e: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a3: Expected I4, but got Unknown
		//IL_0953: Expected O, but got I4
		//IL_0972: Unknown result type (might be due to invalid IL or missing references)
		//IL_0977: Expected O, but got Unknown
		//IL_0989: Expected F4, but got I4
		//IL_0905: Expected O, but got I
		//IL_0e08: Expected I, but got O
		//IL_0e30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e35: Expected O, but got Unknown
		//IL_0d9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9f: Expected O, but got Unknown
		//IL_0997: Unknown result type (might be due to invalid IL or missing references)
		//IL_099c: Expected O, but got Unknown
		//IL_09a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09aa: Expected O, but got Unknown
		//IL_09b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b8: Expected O, but got Unknown
		//IL_09c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cb: Expected O, but got Unknown
		//IL_09d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d9: Expected O, but got Unknown
		//IL_09e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e7: Expected O, but got Unknown
		//IL_0b42: Expected O, but got I4
		//IL_0ae3: Expected O, but got I
		//IL_0aeb: Expected I4, but got O
		//IL_0ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baa: Expected O, but got Unknown
		//IL_0bb7: Expected O, but got F4
		//IL_0bdc: Invalid comparison between F4 and I4
		//IL_0beb: Invalid comparison between F4 and I4
		_003C_003Ec__DisplayClass105_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass105_0();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		Ellipse ellipse = new Ellipse();
		float width = renderer.width * 1.4f;
		float height = renderer2.height * 1.4f;
		ellipse._x = 0f;
		ellipse._width = width;
		ellipse._height = height;
		List<Vector2> points = ellipse.GetPoints(32);
		List<Gem> gems = new List<Gem>();
		CS_0024_003C_003E8__locals11.gems = gems;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			Vector2 pos = default(Vector2);
			if (isCluster)
			{
				List<string> list = new List<string>();
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemBlue.png");
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._size >= items2.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemBlue.png");
				}
				else
				{
					int size2 = list._size + 1;
					list._size = size2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version3 = list._version + 1;
				list._version = version3;
				string[] items3 = list._items;
				if (list._size >= items3.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemBlue.png");
				}
				else
				{
					int size3 = list._size + 1;
					list._size = size3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version4 = list._version + 1;
				list._version = version4;
				string[] items4 = list._items;
				if (list._size >= items4.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemBlue.png");
				}
				else
				{
					int size4 = list._size + 1;
					list._size = size4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version5 = list._version + 1;
				list._version = version5;
				string[] items5 = list._items;
				if (list._size >= items5.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemBlue.png");
				}
				else
				{
					int size5 = list._size + 1;
					list._size = size5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version6 = list._version + 1;
				list._version = version6;
				string[] items6 = list._items;
				if (list._size >= items6.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemBlue.png");
				}
				else
				{
					int size6 = list._size + 1;
					list._size = size6;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version7 = list._version + 1;
				list._version = version7;
				string[] items7 = list._items;
				if (list._size >= items7.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemBlue.png");
				}
				else
				{
					int size7 = list._size + 1;
					list._size = size7;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version8 = list._version + 1;
				list._version = version8;
				string[] items8 = list._items;
				if (list._size >= items8.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemBlue.png");
				}
				else
				{
					int size8 = list._size + 1;
					list._size = size8;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version9 = list._version + 1;
				list._version = version9;
				string[] items9 = list._items;
				if (list._size >= items9.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemBlue.png");
				}
				else
				{
					int size9 = list._size + 1;
					list._size = size9;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version10 = list._version + 1;
				list._version = version10;
				string[] items10 = list._items;
				if (list._size >= items10.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemGreen.png");
				}
				else
				{
					int size10 = list._size + 1;
					list._size = size10;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version11 = list._version + 1;
				list._version = version11;
				string[] items11 = list._items;
				if (list._size >= items11.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemGreen.png");
				}
				else
				{
					int size11 = list._size + 1;
					list._size = size11;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version12 = list._version + 1;
				list._version = version12;
				string[] items12 = list._items;
				if (list._size >= items12.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemGreen.png");
				}
				else
				{
					int size12 = list._size + 1;
					list._size = size12;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version13 = list._version + 1;
				list._version = version13;
				string[] items13 = list._items;
				object obj = list._size - items13.Length;
				int num = list._size ^ items13.Length;
				int num2 = list._size ^ obj;
				int num3 = num & num2;
				bool flag = num3 < 0;
				bool flag2 = (nint)obj < 0;
				if (list._size >= items13.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"GemRed.png");
					object obj2 = 0;
					object obj3 = "GemRed.png";
				}
				else
				{
					int size13 = list._size + 1;
					list._size = size13;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					object obj2 = "GemRed.png";
					object obj3 = list._size;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA41C0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v25 (PhaserScene+Renderer)+38]");
				object obj5 = default(object);
				object obj4 = 0 - obj5;
				object obj6 = "GemRed.png";
				float num4 = 0f;
				do
				{
					nint num5 = (nint)typeof(GM);
					float num6 = num4 * ((float)Math.PI / 54f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					object obj7 = num4 & 0x80000003L;
					if (flag2 != flag)
					{
						object obj8 = obj7 - 1;
						object obj9 = obj8 | -4;
						obj7 = obj9 + 1;
					}
					float num7 = num4 * ((float)Math.PI / 54f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num8 = num7 * 0.32f;
					object obj10 = num4 & 0x80000003L;
					if (flag2 != flag)
					{
						object obj11 = obj10 - 1;
						object obj12 = obj11 | -4;
						obj10 = obj12 + 1;
					}
					float num9 = num8 * (float)obj10;
					float num10 = (float)obj4 - num9;
					Gem gem = GM.Core.MakeGemIgnoreAllTheLimits(pos, 1f);
					((Pickup)gem)._goToPlayer = true;
					PhysicsManager sInstance = PhysicsManager._sInstance;
					Group obj13 = sInstance._goToPlayerPickupGroup.add(gem);
					PhysicsManager sInstance2 = PhysicsManager._sInstance;
					sInstance2._pickupGroup.remove(gem);
					gem.Time = 1f;
					List<object> gems2 = (List<object>)(object)CS_0024_003C_003E8__locals11.gems;
					int version14 = gems2._version + 1;
					gems2._version = version14;
					obj6 = gems2._items;
					int num11 = gems2._size;
					int size14 = gems2._size;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r9_v24 (System.Object)+18]");
					Gem gem2;
					if ((nint)size14 >= (nint)0)
					{
						gems2.AddWithResize((object)gem);
						gem2 = (Gem)0;
						num11 = (int)gem;
					}
					else
					{
						int size15 = gems2._size + 1;
						gems2._size = size15;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						gem2 = gem;
					}
					bool flag3 = !isRandomColor;
					object obj2 = gem2;
					object obj3 = num11;
					if (!flag3)
					{
						string text = VampireSurvivors.App.Tools.Extensions.PickRnd(list);
						gem.SetFrame(text);
						obj2 = null;
						obj3 = text;
					}
					num4++;
					float num12 = num4 - 108f;
					object obj14 = num4 ^ 0x6C;
					object obj15 = num4 ^ num12;
					object obj16 = obj14 & obj15;
					flag = (nint)obj16 < 0;
					flag2 = num12 < 0f;
				}
				while (num4 < 108f);
				return;
			}
			CS_0024_003C_003E8__locals11.i = 0;
			while (true)
			{
				if (CS_0024_003C_003E8__locals11.i >= 108)
				{
					return;
				}
				int num13 = (int)(CS_0024_003C_003E8__locals11.i & 0x8000001FL);
				if ((nint)points < 0)
				{
					object obj17 = num13 - 1;
					object obj18 = obj17 | -32;
					num13 = obj18 + 1;
				}
				int num14 = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rax_v17 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)num14 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rax_v17 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				object obj19 = 0;
				int num15 = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r10_v6+18]");
				Action<Pickup> callback;
				if ((nint)num15 >= (nint)0)
				{
					callback = CS_0024_003C_003E8__locals11._003C_003E9__0;
					if (CS_0024_003C_003E8__locals11._003C_003E9__0 != null)
					{
						goto IL_0ce3;
					}
				}
				callback = (CS_0024_003C_003E8__locals11._003C_003E9__0 = delegate(Pickup pickup)
				{
					//IL_0013: Expected I, but got O
					//IL_001b: Expected I, but got O
					//IL_002b: Expected O, but got I
					//IL_00ab: Expected O, but got I4
					//IL_0067: Expected O, but got I
					//IL_009d: Expected O, but got I4
					nint num16 = (nint)typeof(Gem);
					nint num17 = (nint)pickup;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
					object obj20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
					nint num18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
					object obj22;
					if (num18 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
						object obj21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v10+FFFFFFF8+v50 @ rax_v4*8]");
						if (0 == (nint)typeof(Gem))
						{
							obj22 = 1;
							goto IL_0108;
						}
					}
					obj22 = 0;
					goto IL_0108;
					IL_0108:
					bool flag4 = obj22 == null;
					Pickup pickup2 = null;
					if (!flag4)
					{
						pickup2 = pickup;
					}
					pickup2.GoToPlayer = true;
					pickup2.Time = 1f;
					float num19 = 250f - (float)CS_0024_003C_003E8__locals11.i;
					pickup2._003CSpeed_003Ek__BackingField = num19;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA54B0");
				});
				goto IL_0ce3;
				IL_0ce3:
				GM.Core.MakeGem(pos, 1f, callback);
				int i = CS_0024_003C_003E8__locals11.i + 1;
				CS_0024_003C_003E8__locals11.i = i;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
		}
		throw new NullReferenceException();
	}

	private void SendCoins(bool isRandomType)
	{
		//IL_010f: Expected I4, but got I8
		//IL_013d: Expected O, but got I4
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected I4, but got Unknown
		//IL_016e: Expected O, but got I
		//IL_01b8: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_07a9: Expected O, but got I
		//IL_027c: Expected O, but got I
		//IL_07d1: Expected O, but got I
		//IL_02e6: Expected O, but got I
		//IL_07f9: Expected O, but got I
		//IL_0350: Expected O, but got I
		//IL_0821: Expected O, but got I
		//IL_03ba: Expected O, but got I
		//IL_0849: Expected O, but got I
		//IL_0424: Expected O, but got I
		//IL_0871: Expected O, but got I
		//IL_048e: Expected O, but got I
		//IL_0899: Expected O, but got I
		//IL_04f8: Expected O, but got I
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		Ellipse ellipse = new Ellipse();
		float width = renderer.width * 1.4f;
		float height = renderer2.height * 1.4f;
		ellipse._x = 0f;
		ellipse._width = width;
		ellipse._height = height;
		List<Vector2> points = ellipse.GetPoints(32);
		List<Pickup> list = new List<Pickup>();
		if ((object)GM.Core != null)
		{
			_003C_003Ec__DisplayClass106_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass106_0();
			CS_0024_003C_003E8__locals12.i = 0;
			List<ItemType> list2 = default(List<ItemType>);
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool shouldCallValidatePickups = default(bool);
			bool isRemote = default(bool);
			while (true)
			{
				if (CS_0024_003C_003E8__locals12.i >= 32)
				{
					return;
				}
				int num = (int)(CS_0024_003C_003E8__locals12.i & 0x8000001FL);
				if ((nint)points < 0)
				{
					object obj = num - 1;
					object obj2 = obj | -32;
					num = obj2 + 1;
				}
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rax_v13 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)num2 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rax_v13 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				object obj3 = 0;
				int num3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rcx_v17+18]");
				if ((nint)num3 >= (nint)0)
				{
					list2 = new List<ItemType>();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v11+18]");
				if (num4 >= 0)
				{
					((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)2);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					object obj5 = (nint)0 + (nint)1;
					_ = 2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rdx_v13+18]");
				if (num5 >= 0)
				{
					((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)2);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					object obj7 = (nint)0 + (nint)1;
					_ = 2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v15+18]");
				if (num6 >= 0)
				{
					((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)2);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					object obj9 = (nint)0 + (nint)1;
					_ = 2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v17+18]");
				if (num7 >= 0)
				{
					((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)2);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					object obj11 = (nint)0 + (nint)1;
					_ = 2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v19+18]");
				if (num8 >= 0)
				{
					((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)2);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					object obj13 = (nint)0 + (nint)1;
					_ = 2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v21+18]");
				if (num9 >= 0)
				{
					((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)3);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					object obj15 = (nint)0 + (nint)1;
					_ = 3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v23+18]");
				if (num10 >= 0)
				{
					((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)4);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					object obj17 = (nint)0 + (nint)1;
					_ = 4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdx_v25+18]");
				if (num11 >= 0)
				{
					((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)5);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					object obj19 = (nint)0 + (nint)1;
					_ = 5;
				}
				if (isRandomType)
				{
					ItemType itemType = VampireSurvivors.App.Tools.Extensions.PickRnd(list2);
					if (itemType != ItemType.COIN)
					{
						if (itemType != ItemType.COINBAG1)
						{
							Pickup pickup = GM.Core.MakePickup(pos, itemType, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
							if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
							{
								pickup.GoToPlayer = true;
								GameManager core = GM.Core;
								GameSessionData gameSessionData = core._gameSessionData;
								pickup.TargetPlayer = gameSessionData._activeCharacter;
								pickup.Time = 1f;
								float num12 = 250f - (float)CS_0024_003C_003E8__locals12.i;
								pickup._003CSpeed_003Ek__BackingField = num12;
								float num13 = pickup._003CValue_003Ek__BackingField * 10f;
								pickup._003CValue_003Ek__BackingField = num13;
								int i = CS_0024_003C_003E8__locals12.i + 1;
								CS_0024_003C_003E8__locals12.i = i;
								continue;
							}
							goto IL_0707;
						}
						Action<Pickup> callback = delegate(Pickup coin)
						{
							if ((object)coin != null && ((UnityEngine.Object)coin).m_CachedPtr != (IntPtr)0)
							{
								coin.GoToPlayer = true;
								GameManager core2 = GM.Core;
								GameSessionData gameSessionData2 = core2._gameSessionData;
								coin._targetPlayer = gameSessionData2._activeCharacter;
								coin.Time = 1f;
								float num14 = 250f - (float)CS_0024_003C_003E8__locals12.i;
								coin._003CSpeed_003Ek__BackingField = num14;
								float num15 = coin._003CValue_003Ek__BackingField * 10f;
								coin._003CValue_003Ek__BackingField = num15;
							}
						};
						GM.Core.MakeRedCoinBag(pos, 0f, callback);
						int i2 = CS_0024_003C_003E8__locals12.i + 1;
						CS_0024_003C_003E8__locals12.i = i2;
						continue;
					}
				}
				Action<Pickup> callback2 = delegate(Pickup coin)
				{
					if ((object)coin != null && ((UnityEngine.Object)coin).m_CachedPtr != (IntPtr)0)
					{
						coin.GoToPlayer = true;
						GameManager core2 = GM.Core;
						GameSessionData gameSessionData2 = core2._gameSessionData;
						coin._targetPlayer = gameSessionData2._activeCharacter;
						coin.Time = 1f;
						float num14 = 250f - (float)CS_0024_003C_003E8__locals12.i;
						coin._003CSpeed_003Ek__BackingField = num14;
						float num15 = coin._003CValue_003Ek__BackingField * 10f;
						coin._003CValue_003Ek__BackingField = num15;
					}
				};
				GM.Core.MakeCoin(pos, 0f, callback2);
				goto IL_0707;
				IL_0707:
				int i3 = CS_0024_003C_003E8__locals12.i + 1;
				CS_0024_003C_003E8__locals12.i = i3;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		throw new NullReferenceException();
	}

	private void CacheVideoHelpers()
	{
		VideoPlaybackManager videoPlaybackManager = new VideoPlaybackManager();
		Dictionary<VideoClip, RenderTexture> renderTextures = new Dictionary<VideoClip, RenderTexture>();
		videoPlaybackManager._renderTextures = renderTextures;
		Dictionary<VideoClip, VideoPlayerHelper> videoPlayerHelpers = new Dictionary<VideoClip, VideoPlayerHelper>();
		videoPlaybackManager._videoPlayerHelpers = videoPlayerHelpers;
		_videoPlaybackManager = videoPlaybackManager;
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				List<object> videoPlayerHelpers2 = (List<object>)(object)_videoPlayerHelpers;
				if (_videoPlaybackManager != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					VideoPlayerHelper item = _videoPlaybackManager.GenerateVideoPlayerForRenderTexture(null);
					if (_videoPlayerHelpers == null)
					{
						break;
					}
					int version = videoPlayerHelpers2._version + 1;
					videoPlayerHelpers2._version = version;
					VideoPlaybackManager items = (VideoPlaybackManager)(object)videoPlayerHelpers2._items;
					if (videoPlayerHelpers2._size >= (nint)items._renderTextures)
					{
						((List<object>)(object)_videoPlayerHelpers).AddWithResize((object)item);
						continue;
					}
					int size = videoPlayerHelpers2._size + 1;
					videoPlayerHelpers2._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					continue;
				}
				throw new NullReferenceException();
			}
			return;
		}
		throw new NullReferenceException();
	}

	private void CleanupVideoPlaybackManager()
	{
		if (_videoPlaybackManager != null)
		{
			_videoPlaybackManager.Cleanup();
		}
	}

	private unsafe void PlayVideosAt(int index, List<Vector2> positions, float scale = 0.75f)
	{
		//IL_0160: Expected O, but got Ref
		//IL_0395: Expected I, but got O
		//IL_03ab: Expected O, but got I
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected O, but got Unknown
		//IL_042f: Expected I, but got O
		//IL_0608: Expected O, but got I4
		//IL_061f: Expected I, but got I8
		//IL_040b: Expected I, but got I8
		//IL_0582: Expected I4, but got O
		//IL_0327->IL0447: Incompatible stack heights: 1 vs 0
		//IL_063c->IL0447: Incompatible stack heights: 1 vs 0
		//IL_02c9->IL05ad: Incompatible stack heights: 11 vs 0
		//IL_029a->IL05ad: Incompatible stack heights: 11 vs 0
		_003C_003Ec__DisplayClass109_0 obj = new _003C_003Ec__DisplayClass109_0();
		Action action;
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			obj.index = index;
			List<Renderer> renderers = new List<Renderer>();
			obj.renderers = renderers;
			if (positions != null)
			{
				List<Vector2>.Enumerator enumerator = default(List<Vector2>.Enumerator);
				Vector2 spawnPos = default(Vector2);
				Vector2 vector = default(Vector2);
				float alpha = default(float);
				while (enumerator.MoveNext())
				{
					List<string> videoKeys = _videoKeys;
					int index2 = obj.index;
					bool flag = _videoKeys == null;
					bool flag2 = obj.index >= videoKeys._size;
					string[] items = videoKeys._items;
					if (obj.index < items.Length)
					{
						VideoClip videoClip = _videoClips.get_Item(items[index2]);
						float num = scale * 6.64f;
						Renderer item = _videoPlaybackManager.GenerateQuadForVideoPlayback(videoClip, spawnPos, (Vector3)(&vector), alpha);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1881 @ rax_v87 (UnityEngine.Renderer)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1881 @ rax_v87 (UnityEngine.Renderer)+10]");
						IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						Transform spritesRootTransform = _spritesRootTransform;
						bool flag4 = (object)transform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1867 @ rax_v92 (UnityEngine.Transform)+10]");
						bool flag5 = (nint)0 == 0;
						int num2 = (((object)_spritesRootTransform != null) ? ((int)(nint)((UnityEngine.Object)spritesRootTransform).m_CachedPtr) : 0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1867 @ rax_v92 (UnityEngine.Transform)+10]");
						Transform.SetParent_Injected((IntPtr)0, (IntPtr)num2, true);
						bool flag6 = (object)GM.Core == null;
						PhaserScene s_scene = ArcadePhysics.s_scene;
						bool flag7 = ArcadePhysics.s_scene == null;
						PhaserScene.Renderer renderer = s_scene._renderer;
						bool flag8 = s_scene._renderer == null;
						float num3 = renderer.height * 100f;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,xmm0\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1881 @ rax_v87 (UnityEngine.Renderer)+10]");
						bool flag9 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1881 @ rax_v87 (UnityEngine.Renderer)+10]");
						Renderer.set_sortingOrder_Injected((IntPtr)0, (int)_spritesRootTransform);
						List<object> renderers2 = (List<object>)(object)obj.renderers;
						bool flag10 = obj.renderers == null;
						int version = renderers2._version + 1;
						renderers2._version = version;
						object[] items2 = renderers2._items;
						bool flag11 = renderers2._items == null;
						if (renderers2._size >= items2.Length)
						{
							((List<object>)(object)obj.renderers).AddWithResize((object)item);
							continue;
						}
						int size = renderers2._size + 1;
						renderers2._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						continue;
					}
					throw new IndexOutOfRangeException();
				}
				List<VideoPlayerHelper> videoPlayerHelpers = _videoPlayerHelpers;
				int index3 = obj.index;
				if (_videoPlayerHelpers != null)
				{
					bool flag12 = obj.index >= videoPlayerHelpers._size;
					VideoPlayerHelper[] items3 = videoPlayerHelpers._items;
					if (videoPlayerHelpers._items != null)
					{
						obj.videoHelper = items3[index3];
						action = null;
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r10_v24 (Il2CppMethodInfo)+8]");
						((Delegate)action).method_ptr = (IntPtr)0;
						((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass109_0._003CPlayVideosAt_003Eb__0);
						((Delegate)action).m_target = obj;
						((Delegate)action).method_code = (IntPtr)action;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r10_v24 (Il2CppMethodInfo)+4C]");
						object obj2 = (nint)0 >> 4;
						object obj3 = obj2 & 1;
						nint num5;
						if (obj3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r10_v24 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num5 = unchecked((nint)6447293664L);
								goto IL_05ff;
							}
						}
						num5 = ((Delegate)action).method_ptr;
						((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
						goto IL_05ff;
					}
				}
			}
		}
		goto IL_0447;
		IL_0447:
		throw new NullReferenceException();
		IL_05ff:
		object obj4 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		if ((object)obj.videoHelper != null)
		{
			obj.videoHelper.Play(action);
			return;
		}
		goto IL_0447;
	}

	public Background6()
	{
		//IL_05ab: Expected O, but got I
		//IL_0605: Expected O, but got I
		//IL_0a44: Expected O, but got I
		//IL_066f: Expected O, but got I
		//IL_0a6c: Expected O, but got I
		//IL_06d9: Expected O, but got I
		//IL_0720: Expected O, but got I
		//IL_077a: Expected O, but got I
		//IL_0aa3: Expected O, but got I
		//IL_07e4: Expected O, but got I
		//IL_0acb: Expected O, but got I
		//IL_084e: Expected O, but got I
		//IL_0895: Expected O, but got I
		//IL_08ef: Expected O, but got I
		//IL_0b02: Expected O, but got I
		//IL_0959: Expected O, but got I
		//IL_0b2a: Expected O, but got I
		//IL_09c3: Expected O, but got I
		_canContinueStageZoom = true;
		List<PhaserSprite> windows = new List<PhaserSprite>();
		_windows = windows;
		_shatterGlobalScale = 1f;
		_shatterMoveTweens = new Tween[0];
		_shatterAngleTweens = new Tween[0];
		_shatterAlphaTweens = new Tween[0];
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"dummy1");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"dummy2");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"dummy3");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"dummy4");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"dummy5");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_stageKeys = list;
		_videoClips = new Dictionary<string, VideoClip>();
		List<string> list2 = new List<string>();
		list2._version++;
		string[] items6 = list2._items;
		if (list2._size >= items6.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Chestnobg");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items7 = list2._items;
		if (list2._size >= items7.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Chestnobg2");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items8 = list2._items;
		if (list2._size >= items8.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Chestnobg3");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_videoKeys = list2;
		List<float> list3 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rdx_v32+18]");
		if (num >= 0)
		{
			list3.AddWithResize(5000f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1167867904;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rdx_v33+18]");
		if (num2 >= 0)
		{
			list3.AddWithResize(3500f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1163575296;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rdx_v34+18]");
		if (num3 >= 0)
		{
			list3.AddWithResize(2500f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1159479296;
		}
		_videoStarts = list3;
		List<float> list4 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rdx_v37+18]");
		if (num4 >= 0)
		{
			list4.AddWithResize(8500f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1174720512;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rdx_v38+18]");
		if (num5 >= 0)
		{
			list4.AddWithResize(12500f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1178816512;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rdx_v39+18]");
		if (num6 >= 0)
		{
			list4.AddWithResize(16000f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rax_v41 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1182400512;
		}
		_videoEnds = list4;
		List<int> list5 = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rdx_v42+18]");
		if (num7 >= 0)
		{
			list5.AddWithResize(3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rdx_v44+18]");
		if (num8 >= 0)
		{
			list5.AddWithResize(5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rdx_v46+18]");
		if (num9 >= 0)
		{
			list5.AddWithResize(7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1583 @ rax_v48 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 7;
		}
		_videoBlinks = list5;
		_videoPlayerHelpers = new List<VideoPlayerHelper>();
		base._002Ector();
	}

	private void _003CRemoveCircles_003Eb__74_0()
	{
		PhaserSprite phaserSprite = _centralCircle.setVisible(visible: false);
	}

	private unsafe void _003CZoomOverStages_003Eb__77_0()
	{
		//IL_002c: Expected O, but got Ref
		//IL_0053: Expected O, but got Ref
		if (!_canContinueStageZoom)
		{
			return;
		}
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(-500f, -600f);
		object obj = default(object);
		RenderingExtensions.SetSpeedY(_pfxFire1, (ParticleSystem.MinMaxCurve)(&obj));
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(-500f, -600f);
		RenderingExtensions.SetSpeedY(_pfxFire2, (ParticleSystem.MinMaxCurve)(&obj));
		RenderingExtensions.Start(_pfxFire1);
		RenderingExtensions.Start(_pfxFire2);
		Action onComplete = delegate
		{
			//IL_0044: Expected O, but got I4
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected I4, but got Unknown
			if (_canContinueStageZoom)
			{
				RenderingExtensions.StopEmitting(_pfxFire1);
				RenderingExtensions.StopEmitting(_pfxFire2);
				List<string> stageKeys = _stageKeys;
				object obj2 = _stageKeyIndex + 1;
				int stageKeyIndex = obj2 % stageKeys._size;
				_stageKeyIndex = stageKeyIndex;
				ZoomOverStages();
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void _003CZoomOverStages_003Eb__77_1()
	{
		//IL_0044: Expected O, but got I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected I4, but got Unknown
		if (_canContinueStageZoom)
		{
			RenderingExtensions.StopEmitting(_pfxFire1);
			RenderingExtensions.StopEmitting(_pfxFire2);
			List<string> stageKeys = _stageKeys;
			object obj = _stageKeyIndex + 1;
			int stageKeyIndex = obj % stageKeys._size;
			_stageKeyIndex = stageKeyIndex;
			ZoomOverStages();
		}
	}

	private void _003CStartColorChangingBackground_003Eb__79_1()
	{
		FakeTilingBackground tilingBg = _tilingBg;
		TileSprite bgTile = tilingBg._bgTile;
		Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("hStars1");
		bgTile._spriteRenderer.sprite = unpackedSprite;
	}

	private unsafe void _003CStartColorChangingBackground_003Eb__79_0(float _)
	{
		//IL_00c7: Expected O, but got Ref
		float colorBgValue = _colorBgValue + 0.01f;
		_colorBgValue = colorBgValue;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			PhaserSprite phaserSprite = _colorBg.setTintFill(isEnabled: true, 2254557u);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num = _colorBgValue * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		object obj = default(object);
		PhaserSprite phaserSprite2 = _colorBg.setTintFill(isEnabled: true, (Color?)(object)(&obj));
	}

	private void _003CShatter_003Eb__101_0()
	{
		GameObject gameObject = _shatterVfx.gameObject;
		gameObject.SetActive(value: false);
	}
}
