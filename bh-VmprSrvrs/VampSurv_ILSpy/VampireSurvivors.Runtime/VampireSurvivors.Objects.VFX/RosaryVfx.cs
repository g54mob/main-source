using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.VFX;

public class RosaryVfx : PoolableMonoBehaviour
{
	private SpriteRenderer _ScreenFillRenderer;

	private SpriteAnimation _BurstAnimation;

	private Timer _timer;

	private Transform _originalParent;

	private void Awake()
	{
	}

	public void SetParent(Transform newParent)
	{
		Transform transform = base.transform;
		Transform parent = transform.parent;
		_originalParent = parent;
		Transform transform2 = base.transform;
		transform2.SetParent(newParent, worldPositionStays: true);
	}

	public void Play(float volume = 1.8f, bool setDark = false)
	{
		//IL_00a3: Expected O, but got I
		//IL_0414: Expected O, but got I4
		//IL_01c4: Expected F4, but got I4
		//IL_027b: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_04e3: Expected I4, but got O
		//IL_0292: Expected O, but got I4
		//IL_0343: Expected I4, but got O
		//IL_0343: Expected O, but got I4
		SetupScreenFill();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 1f, 0.1f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
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
		bool flag = tweenerCore == null;
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = tweenerCore;
		if (!flag)
		{
			tweenerCore2 = tweenerCore;
			if ((object)_BurstAnimation != null)
			{
				_BurstAnimation.CleanAnimations();
				bool flag2 = default(bool);
				List<Sprite> animation = SpriteManager.GetAnimation("Burst", 1, 6, "vfx", flag2);
				if ((object)_BurstAnimation != null)
				{
					bool flag3 = default(bool);
					Action action = default(Action);
					bool flag4 = default(bool);
					_BurstAnimation.AddAnimation("Enter", animation, 30, flag2, flag3, action, flag4);
					if ((object)_BurstAnimation != null)
					{
						_BurstAnimation.SetAnimation("Enter");
						bool flag5 = !setDark;
						float rate = 1f;
						if (!flag5)
						{
							rate = 0.75f;
						}
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						soundConfig.Volume = (float?)(object)1;
						soundConfig.Rate = rate;
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Rosary, soundConfig, 500f, 4, flag2 ? 1 : 0);
						tweenerCore2 = (TweenerCore<Color, Color, ColorOptions>)(object)_ScreenFillRenderer;
						if ((object)_ScreenFillRenderer != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rbx_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
							if ((nint)0 == 0)
							{
								UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(tweenerCore2);
								/*Error: End of method reached without returning.*/;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rbx_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
							Renderer.set_sortingOrder_Injected((IntPtr)0, 10000);
							if ((object)_BurstAnimation != null)
							{
								SpriteRenderer component = _BurstAnimation.GetComponent<SpriteRenderer>();
								bool flag6 = (object)component == null;
								tweenerCore2 = (TweenerCore<Color, Color, ColorOptions>)(object)component;
								if (!flag6)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v31 (UnityEngine.SpriteRenderer)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rax_v31 (UnityEngine.SpriteRenderer)+10]");
										Renderer.set_sortingOrder_Injected((IntPtr)0, 10000);
										Component burstAnimation;
										TweenerCore<Color, Color, ColorOptions> tweenerCore3;
										if (!setDark)
										{
											SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_ScreenFillRenderer, 16777215u);
											burstAnimation = _BurstAnimation;
											bool flag7 = (object)_BurstAnimation == null;
											tweenerCore2 = (TweenerCore<Color, Color, ColorOptions>)16777215;
											if (flag7)
											{
												goto IL_03d2;
											}
											tweenerCore3 = (TweenerCore<Color, Color, ColorOptions>)16777215;
										}
										else
										{
											SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_ScreenFillRenderer, 0u);
											burstAnimation = _BurstAnimation;
											bool flag8 = (object)_BurstAnimation == null;
											tweenerCore2 = (TweenerCore<Color, Color, ColorOptions>)(object)component;
											if (flag8)
											{
												goto IL_03d2;
											}
											tweenerCore3 = (TweenerCore<Color, Color, ColorOptions>)5570645;
										}
										SpriteRenderer component2 = burstAnimation.GetComponent<SpriteRenderer>();
										SpriteRenderer spriteRenderer3 = RenderingExtensions.SetTint(component2, (uint)(int)tweenerCore3);
										if (_timer != null)
										{
											_timer.Cancel();
										}
										Action onComplete = Cleanup;
										Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, flag2, (MonoBehaviour)flag3, (int)action, flag4 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
										_timer = timer;
										return;
									}
									UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(component);
									tweenerCore2 = (TweenerCore<Color, Color, ColorOptions>)(object)component;
								}
							}
						}
					}
				}
			}
		}
		goto IL_03d2;
		IL_03d2:
		throw new NullReferenceException();
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

	private void SetupBurstAnim()
	{
		_BurstAnimation.CleanAnimations();
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("Burst", 1, 6, "vfx", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_BurstAnimation.AddAnimation("Enter", animation, 30, flag, startRandomFrame, onComplete, autoSetAnimation);
		_BurstAnimation.SetAnimation("Enter");
	}

	private void ResetParent()
	{
		Transform transform = base.transform;
		transform.SetParent(_originalParent, worldPositionStays: true);
	}

	public RosaryVfx()
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
