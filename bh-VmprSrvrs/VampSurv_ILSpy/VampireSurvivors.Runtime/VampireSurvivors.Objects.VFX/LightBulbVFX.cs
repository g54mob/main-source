using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.VFX;

public class LightBulbVFX : PoolableMonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__14_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CEndEffect_003Eb__14_0()
		{
			GM.Core.ResumeGame();
			GameManager core = GM.Core;
			core._003CCanPause_003Ek__BackingField = true;
		}
	}

	private SpriteRenderer _ScreenFillRenderer;

	private Timer _timer;

	private Transform _originalParent;

	private PhaserSprite _StarSprite;

	private PhaserSprite _BulbSprite;

	private float _orthographicSize;

	private PhaserText _techniqueNameText;

	private PhaserSprite _techniqueNameBackground;

	private List<Transform> _originalCameraTargets;

	private void Awake()
	{
		//IL_0057: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		//IL_0175: Expected O, but got I4
		Sprite sprite = SpriteManager.GetSprite("blackDot", "vfx");
		_ScreenFillRenderer.sprite = sprite;
		PhaserWorld instance = PhaserWorld.Instance;
		PhaserSprite phaserSprite = instance.AddPhaserSprite((Vector2)0, "EME_items", "eme_lightbulb");
		Transform parent = base.transform;
		Transform transform = phaserSprite.transform;
		transform.SetParent(parent, worldPositionStays: false);
		_BulbSprite = phaserSprite;
		PhaserSprite phaserSprite2 = _BulbSprite.setScale(0f, (float?)(object)0);
		GameObject gameObject = phaserSprite2.gameObject;
		((UnityEngine.Object)gameObject).SetName("BulbSprite");
		PhaserWorld instance2 = PhaserWorld.Instance;
		PhaserSprite phaserSprite3 = instance2.AddPhaserSprite((Vector2)0, "vfx", "blurredSharpStar");
		Transform parent2 = base.transform;
		Transform transform2 = phaserSprite3.transform;
		transform2.SetParent(parent2, worldPositionStays: false);
		_StarSprite = phaserSprite3;
		PhaserSprite phaserSprite4 = _StarSprite.setBlendMode(BlendMode.Add);
		PhaserSprite phaserSprite5 = _StarSprite.setScale(0f, (float?)(object)0);
	}

	public void setDepth(int depth)
	{
		int sortingOrder = depth - 1;
		_ScreenFillRenderer.sortingOrder = sortingOrder;
		int depth2 = depth + 1;
		PhaserSprite phaserSprite = _StarSprite.setDepth(depth2);
		int depth3 = depth + 2;
		PhaserSprite phaserSprite2 = _BulbSprite.setDepth(depth3);
	}

	public void SetParent(Transform newParent)
	{
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Transform parent = transform.parent;
			_originalParent = parent;
			Transform transform2 = base.transform;
			if ((object)transform2 != null)
			{
				transform2.SetParent(newParent, worldPositionStays: true);
				Transform transform3 = base.transform;
				if ((object)transform3 != null)
				{
					bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void Play(string techniqueName, float volume = 1.8f)
	{
		//IL_009c: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_033b: Expected O, but got I4
		//IL_02f3: Expected O, but got I
		//IL_0871: Expected O, but got F4
		//IL_08c0: Expected I4, but got F4
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c2: Expected O, but got Unknown
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Expected O, but got Unknown
		//IL_06be: Expected I, but got O
		//IL_06d4: Expected O, but got I
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e2: Expected O, but got Unknown
		//IL_067c: Expected I4, but got F4
		//IL_0758: Expected I, but got O
		//IL_0932: Expected O, but got I4
		//IL_0949: Expected I, but got I8
		//IL_069e: Expected O, but got I4
		//IL_06ac: Expected O, but got I4
		//IL_0734: Expected I, but got I8
		if ((object)GM.Core != null)
		{
			GM.Core.PauseGame();
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				core._003CCanPause_003Ek__BackingField = false;
				SetupScreenFill();
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 0.65f, 0.1f);
				if ((object)_StarSprite != null)
				{
					PhaserSprite phaserSprite = _StarSprite.setScale(0f, (float?)(object)0);
					if ((object)_BulbSprite != null)
					{
						PhaserSprite phaserSprite2 = _BulbSprite.setScale(0f, (float?)(object)0);
						if ((object)_StarSprite != null)
						{
							PhaserSprite phaserSprite3 = _StarSprite.setAlpha(1f);
							if ((object)_BulbSprite != null)
							{
								PhaserSprite phaserSprite4 = _BulbSprite.setAlpha(1f);
								if ((object)_StarSprite != null)
								{
									PhaserSprite phaserSprite5 = _StarSprite.setDepth(5000);
									if ((object)_BulbSprite != null)
									{
										PhaserSprite phaserSprite6 = _BulbSprite.setDepth(5001);
										if ((object)_BulbSprite != null)
										{
											Transform target = _BulbSprite.transform;
											TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, 2f, 0.3f);
											if ((object)_StarSprite != null)
											{
												Transform target2 = _StarSprite.transform;
												TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target2, 4f, 0.3f);
												if (tweenerCore3 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v34 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v34 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
														if ((nint)0 == 0)
														{
															_ = 2;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v34 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
															if ((nint)0 == 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v34 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
																nint num = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v34 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
																object obj = num + 0;
															}
														}
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
												if ((nint)0 == 0)
												{
													_ = 1;
												}
												if (tweenerCore3 != null)
												{
													List<Transform> originalCameraTargets = new List<Transform>();
													_originalCameraTargets = originalCameraTargets;
													float? num2 = (float?)(object)0;
													float num3 = default(float);
													Vector2 vector = default(Vector2);
													int repeat = default(int);
													while (true)
													{
														ProCamera2D instance = ProCamera2D.Instance;
														if ((object)instance == null)
														{
															break;
														}
														List<Com.LuisPedroFonseca.ProCamera2D.CameraTarget> cameraTargets = instance.CameraTargets;
														if (instance.CameraTargets == null)
														{
															break;
														}
														if ((nint)num2 < cameraTargets._size)
														{
															List<Transform> originalCameraTargets2 = _originalCameraTargets;
															ProCamera2D instance2 = ProCamera2D.Instance;
															if ((object)instance2 == null)
															{
																break;
															}
															List<Com.LuisPedroFonseca.ProCamera2D.CameraTarget> cameraTargets2 = instance2.CameraTargets;
															if (instance2.CameraTargets == null)
															{
																break;
															}
															if ((nint)num2 < cameraTargets2._size)
															{
																Com.LuisPedroFonseca.ProCamera2D.CameraTarget[] items = cameraTargets2._items;
																if (cameraTargets2._items == null)
																{
																	break;
																}
																if ((nint)num2 < items.Length)
																{
																	Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = items[(object)num2];
																	if (items[(object)num2] == null || _originalCameraTargets == null)
																	{
																		break;
																	}
																	int version = originalCameraTargets2._version + 1;
																	originalCameraTargets2._version = version;
																	List<Transform> items2 = (List<Transform>)(object)originalCameraTargets2._items;
																	if (originalCameraTargets2._items == null)
																	{
																		break;
																	}
																	if (originalCameraTargets2._size >= items2._size)
																	{
																		((List<object>)(object)_originalCameraTargets).AddWithResize((object)cameraTarget.TargetTransform);
																		num2 = (float?)(object)((_003F?)num2 + 1);
																		continue;
																	}
																	int size = originalCameraTargets2._size + 1;
																	originalCameraTargets2._size = size;
																	((List<Transform>)(object)originalCameraTargets2._items)._002Ector();
																	num2 = (float?)(object)((_003F?)num2 + 1);
																	continue;
																}
															}
															else
															{
																System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
															}
															throw new IndexOutOfRangeException();
														}
														ProCamera2D instance3 = ProCamera2D.Instance;
														if ((object)instance3 == null)
														{
															break;
														}
														instance3.RemoveAllCameraTargets(0.1f);
														ProCamera2D instance4 = ProCamera2D.Instance;
														object bulbSprite = _BulbSprite;
														if ((object)_BulbSprite == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v12 (System.Object)+10]");
														if ((nint)0 == 0)
														{
															UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_BulbSprite);
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v12 (System.Object)+10]");
														IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
														Transform targetTransform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
														if ((object)instance4 == null)
														{
															break;
														}
														Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget2 = instance4.AddCameraTarget(targetTransform, 1f, 1f, num3, vector);
														IntPtr main_Injected = Camera.get_main_Injected();
														Camera camera = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Camera>(main_Injected);
														if ((object)camera == null)
														{
															break;
														}
														bool flag = ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0;
														object obj2 = Camera.get_orthographicSize_Injected(((UnityEngine.Object)camera).m_CachedPtr);
														_orthographicSize = 0f;
														TweenerCore<float, float, FloatOptions> tweenerCore4 = ShortcutExtensions.DOOrthoSize(camera, 1f, 0.2f);
														SetupTextBox(techniqueName);
														Timer timer = _timer;
														bool flag2 = _timer == null;
														bool useRealTime = (byte)(int)num3 != 0;
														if (!flag2)
														{
															useRealTime = (byte)(int)num3 != 0;
															if (!_timer.IsDone)
															{
																float timeElapsed = _timer.GetTimeElapsed();
																timer._timeElapsedBeforeCancel = (float?)(object)1;
																timer._timeElapsedBeforePause = (float?)(object)0;
															}
														}
														Action action = null;
														nint num4 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v756 @ r10_v1 (Il2CppMethodInfo)+8]");
														((Delegate)action).method_ptr = (IntPtr)0;
														((Delegate)action).method = (nint)__ldftn(LightBulbVFX.EndEffect);
														((Delegate)action).m_target = this;
														((Delegate)action).method_code = (IntPtr)action;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v756 @ r10_v1 (Il2CppMethodInfo)+4C]");
														object obj3 = (nint)0 >> 4;
														object obj4 = obj3 & 1;
														nint num5;
														if (obj4 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v756 @ r10_v1 (Il2CppMethodInfo)+52]");
															if ((nint)0 == 0)
															{
																num5 = unchecked((nint)6447293664L);
																goto IL_0929;
															}
														}
														num5 = ((Delegate)action).method_ptr;
														((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
														goto IL_0929;
														IL_0929:
														object obj5 = 24;
														((Delegate)action).extra_arg = unchecked((nint)6447293568L);
														Timer timer2 = TimerHelper.RegisterMillisUI(1000f, action, null, isLooped: false, useRealTime, (MonoBehaviour)vector, repeat);
														_timer = timer2;
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

	private unsafe void SetupTextBox(string techniqueName)
	{
		//IL_01b3: Expected O, but got Ref
		//IL_0232: Expected O, but got I4
		//IL_0856: Invalid comparison between O and F4
		//IL_04b9: Expected O, but got I4
		//IL_06d7: Invalid comparison between O and F4
		//IL_040f->IL0763: Incompatible stack heights: 1 vs 0
		//IL_08b4->IL0763: Incompatible stack heights: 1 vs 0
		//IL_0557->IL0763: Incompatible stack heights: 1 vs 0
		//IL_0579->IL0763: Incompatible stack heights: 1 vs 0
		//IL_0472->IL0763: Incompatible stack heights: 1 vs 0
		//IL_05a8->IL0763: Incompatible stack heights: 1 vs 0
		//IL_04a1->IL0763: Incompatible stack heights: 1 vs 0
		//IL_05de->IL0763: Incompatible stack heights: 1 vs 0
		//IL_0600->IL0763: Incompatible stack heights: 1 vs 0
		//IL_04f0->IL0763: Incompatible stack heights: 1 vs 0
		//IL_062f->IL0763: Incompatible stack heights: 1 vs 0
		//IL_0512->IL0763: Incompatible stack heights: 1 vs 0
		//IL_090d->IL0763: Incompatible stack heights: 2 vs 0
		//IL_065b->IL0763: Incompatible stack heights: 2 vs 0
		//IL_0696->IL0763: Incompatible stack heights: 2 vs 0
		//IL_06b8->IL0763: Incompatible stack heights: 2 vs 0
		//IL_0712->IL0763: Incompatible stack heights: 2 vs 0
		//IL_0734->IL0763: Incompatible stack heights: 2 vs 0
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		Vector2 vector = default(Vector2);
		float num = (float)vector * 2f;
		float num2 = num / _orthographicSize;
		float num3 = num2 * 0.9f;
		Camera main2 = Camera.main;
		Bounds bounds2 = CameraExtensions.OrthographicBounds(main2);
		float num4 = (float)vector * 2f;
		float num5 = num4 / _orthographicSize;
		bool flag = (object)GM.Core == null;
		float num6 = num5 * 0.75f;
		Vector3 ret = default(Vector3);
		if (!flag)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
				{
					Camera techniqueNameText = (Camera)(object)_techniqueNameText;
					if ((object)_techniqueNameText != null && ((UnityEngine.Object)techniqueNameText).m_CachedPtr != (IntPtr)0)
					{
						goto IL_0248;
					}
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene3 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							float fontSize = default(float);
							PhaserText component = RenderingExtensions.text(s_scene3.add, vector, "", (Color)(&ret), fontSize);
							PhaserText phaserText = RenderingExtensions.SetScrollFactor(component, 0f);
							if ((object)phaserText != null)
							{
								PhaserText phaserText2 = phaserText.SetDepth(31758);
								if ((object)phaserText2 != null)
								{
									PhaserText techniqueNameText2 = phaserText2.setOrigin(0.5f, (float?)(object)1);
									_techniqueNameText = techniqueNameText2;
									goto IL_0248;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0763;
		IL_0763:
		throw new NullReferenceException();
		IL_0248:
		if ((object)_techniqueNameText != null)
		{
			PhaserText phaserText3 = _techniqueNameText.SetText(techniqueName);
			PhaserText techniqueNameText3 = _techniqueNameText;
			if ((object)_techniqueNameText != null && (object)techniqueNameText3._textRenderer != null)
			{
				RectTransform rectTransform = techniqueNameText3._textRenderer.rectTransform;
				if ((object)rectTransform != null)
				{
					Vector2 sizeDelta = rectTransform.sizeDelta;
					PhaserText techniqueNameText4 = _techniqueNameText;
					if ((object)_techniqueNameText != null && (object)techniqueNameText4._textRenderer != null)
					{
						Transform transform = techniqueNameText4._textRenderer.transform;
						if ((object)transform != null)
						{
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_lossyScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
							object obj = ret * sizeDelta;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
							{
								PhaserText phaserText4 = RenderingExtensions.SetScale(scale: num6 / (float)obj, component: _techniqueNameText);
							}
							Camera techniqueNameBackground = (Camera)(object)_techniqueNameBackground;
							if ((object)_techniqueNameBackground != null && ((UnityEngine.Object)techniqueNameBackground).m_CachedPtr != (IntPtr)0)
							{
								goto IL_0533;
							}
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene4 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									PhaserSprite component2 = RenderingExtensions.sprite(s_scene4.add, vector, "UI", "frame1_c2");
									PhaserSprite phaserSprite = RenderingExtensions.SetScrollFactor(component2, 0f);
									if ((object)phaserSprite != null)
									{
										PhaserSprite phaserSprite2 = phaserSprite.setDepth(31757);
										if ((object)phaserSprite2 != null)
										{
											PhaserSprite techniqueNameBackground2 = phaserSprite2.setOrigin(0.5f, (float?)(object)1);
											_techniqueNameBackground = techniqueNameBackground2;
											PhaserSprite techniqueNameBackground3 = _techniqueNameBackground;
											if ((object)_techniqueNameBackground != null && (object)techniqueNameBackground3._spriteRenderer != null)
											{
												techniqueNameBackground3._spriteRenderer.drawMode = SpriteDrawMode.Sliced;
												goto IL_0533;
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
		goto IL_0763;
		IL_0533:
		PhaserText techniqueNameText5 = _techniqueNameText;
		if ((object)_techniqueNameText != null && (object)techniqueNameText5._textRenderer != null)
		{
			RectTransform rectTransform2 = techniqueNameText5._textRenderer.rectTransform;
			if ((object)rectTransform2 != null)
			{
				Vector2 sizeDelta2 = rectTransform2.sizeDelta;
				PhaserText techniqueNameText6 = _techniqueNameText;
				if ((object)_techniqueNameText != null && (object)techniqueNameText6._textRenderer != null)
				{
					Transform transform2 = techniqueNameText6._textRenderer.transform;
					if ((object)transform2 != null)
					{
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_lossyScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
						PhaserSprite techniqueNameBackground4 = _techniqueNameBackground;
						if ((object)_techniqueNameBackground != null && (object)techniqueNameBackground4._spriteRenderer != null)
						{
							techniqueNameBackground4._spriteRenderer.size = vector;
							PhaserSprite techniqueNameBackground5 = _techniqueNameBackground;
							if ((object)_techniqueNameBackground != null && (object)techniqueNameBackground5._spriteRenderer != null)
							{
								Vector2 size = techniqueNameBackground5._spriteRenderer.size;
								if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref size) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3))
								{
									return;
								}
								PhaserSprite techniqueNameBackground6 = _techniqueNameBackground;
								if ((object)_techniqueNameBackground != null && (object)techniqueNameBackground6._spriteRenderer != null)
								{
									Vector2 size2 = techniqueNameBackground6._spriteRenderer.size;
									techniqueNameBackground6._spriteRenderer.size = vector;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0763;
	}

	public void EndEffect()
	{
		//IL_0160: Expected I4, but got F4
		PhaserText techniqueNameText = _techniqueNameText;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(techniqueNameText._textRenderer, 0f, 0.1f);
		PhaserSprite techniqueNameBackground = _techniqueNameBackground;
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(techniqueNameBackground._spriteRenderer, 0f, 0.1f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 0f, 0.1f);
		PhaserSprite bulbSprite = _BulbSprite;
		TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleSprite.DOFade(bulbSprite._spriteRenderer, 0f, 0.5f);
		PhaserSprite starSprite = _StarSprite;
		TweenerCore<Color, Color, ColorOptions> tweenerCore5 = DOTweenModuleSprite.DOFade(starSprite._spriteRenderer, 0f, 0.5f);
		Camera main = Camera.main;
		TweenerCore<float, float, FloatOptions> tweenerCore6 = ShortcutExtensions.DOOrthoSize(main, _orthographicSize, 0.2f);
		ProCamera2D instance = ProCamera2D.Instance;
		instance.RemoveAllCameraTargets(0.5f);
		ProCamera2D instance2 = ProCamera2D.Instance;
		float num = default(float);
		Vector2 vector = default(Vector2);
		instance2.AddCameraTargets(_originalCameraTargets, 1f, 1f, num, vector);
		Action onComplete = _003C_003Ec._003C_003E9__14_0;
		if (_003C_003Ec._003C_003E9__14_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__14_0 = delegate
			{
				GM.Core.ResumeGame();
				GameManager core = GM.Core;
				core._003CCanPause_003Ek__BackingField = true;
			});
		}
		int repeat = default(int);
		Timer timer = TimerHelper.RegisterMillisUI(500f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)vector, repeat);
	}

	private void Cleanup()
	{
		if (_timer != null)
		{
			_timer.Cancel();
		}
		Transform transform = base.transform;
		transform.SetParent(_originalParent, worldPositionStays: true);
		GameObject obj = base.gameObject;
		base._parentPool.Release(obj);
	}

	private unsafe void SetupScreenFill()
	{
		//IL_01e4: Expected O, but got I4
		//IL_0291: Expected O, but got I4
		//IL_006b->IL00f5: Incompatible stack heights: 3 vs 0
		//IL_02ab->IL00f5: Incompatible stack heights: 3 vs 0
		//IL_00ab->IL00f5: Incompatible stack heights: 3 vs 0
		//IL_00d7->IL00f5: Incompatible stack heights: 3 vs 0
		//IL_0288->IL01da: Incompatible stack heights: 7 vs 3
		SpriteRenderer screenFillRenderer = _ScreenFillRenderer;
		if ((object)_ScreenFillRenderer != null)
		{
			bool flag = ((UnityEngine.Object)screenFillRenderer).m_CachedPtr == (IntPtr)0;
			SpriteRenderer.get_color_Injected(((UnityEngine.Object)screenFillRenderer).m_CachedPtr, out Color ret);
			Camera screenFillRenderer2 = (Camera)(object)_ScreenFillRenderer;
			bool flag2 = (object)_ScreenFillRenderer == null;
			bool flag3 = ((UnityEngine.Object)screenFillRenderer2).m_CachedPtr == (IntPtr)0;
			Color value = default(Color);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)screenFillRenderer2).m_CachedPtr, ref value);
			Camera main = Camera.main;
			if ((object)main == null || ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			Camera main2 = Camera.main;
			if ((object)main2 != null)
			{
				float orthographicSize = main2.orthographicSize;
				object obj = Screen.height;
				object obj2 = Screen.width;
				if ((object)_ScreenFillRenderer != null)
				{
					Sprite sprite = _ScreenFillRenderer.sprite;
					if ((object)_ScreenFillRenderer != null)
					{
						Transform transform = _ScreenFillRenderer.transform;
						if ((object)sprite != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v61 (UnityEngine.Sprite)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v61 (UnityEngine.Sprite)+10]");
							Sprite.get_bounds_Injected((IntPtr)0, out *(Bounds*)(&ret));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v61 (UnityEngine.Sprite)+10]");
							bool flag5 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v61 (UnityEngine.Sprite)+10]");
							Sprite.get_bounds_Injected((IntPtr)0, out Bounds _);
							bool flag6 = (object)transform == null;
							bool flag7 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void ResetParent()
	{
		Transform transform = base.transform;
		transform.SetParent(_originalParent, worldPositionStays: true);
	}

	public LightBulbVFX()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
