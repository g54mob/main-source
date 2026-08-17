using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.VFX;

public class LancetPierceEffect : PoolableMonoBehaviour
{
	private SpriteRenderer _PierceRenderer;

	private SpriteAnimation _PierceAnimator;

	private Tween _imageTween;

	public unsafe void Play()
	{
		//IL_035b: Expected O, but got I8
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_03c3: Expected O, but got I4
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_02f3->IL02b9: Incompatible stack heights: 2 vs 0
		float value = default(float);
		if (ColorUtility.DoTryParseHtmlColor("#cceeff", out Color32 _))
		{
			SpriteRenderer pierceRenderer = _PierceRenderer;
			bool flag = (object)_PierceRenderer == null;
			bool flag2 = ((UnityEngine.Object)pierceRenderer).m_CachedPtr == (IntPtr)0;
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)pierceRenderer).m_CachedPtr, ref *(Color*)(&value));
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_PierceRenderer, 1f);
		Transform transform = _PierceRenderer.transform;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade(_PierceRenderer, 0f, 0.5f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 0.2f);
		object obj = 6603577472L;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag4 = (nint)0 == 0;
				_ = 0;
				if (!flag4)
				{
					object obj2 = tweenerCore + 184;
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj4 & 0x3F;
					nint num2;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rbp_v4+462E0+v817 @ rdx_v39*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rbp_v4+462E0+v817 @ rdx_v39*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rbp_v4+462E0+v817 @ rdx_v39*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rbp_v4+462E0+v817 @ rdx_v39*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rbp_v4+462E0+v817 @ rdx_v39*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = base.Release;
					tweenCallback2 = tweenCallback;
					goto IL_0174;
				}
			}
		}
		TweenCallback tweenCallback3 = base.Release;
		bool flag5 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag5)
		{
			goto IL_0174;
		}
		goto IL_01a3;
		IL_0174:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v765 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_01a3;
		IL_01a3:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_imageTween = tweenerCore;
		bool flag6 = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("Pierce", 1, 5, "vfx", flag6);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_PierceAnimator.AddAnimation("pierce", animation, 30, flag6, startRandomFrame, onComplete, autoSetAnimation);
		SpriteAnimation pierceAnimator = _PierceAnimator;
		((BaseSpriteAnimation)pierceAnimator)._003CIsPaused_003Ek__BackingField = false;
		_PierceAnimator.SetAnimation("pierce");
		int height = Screen.height;
		_PierceRenderer.sortingOrder = height;
	}

	public LancetPierceEffect()
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
