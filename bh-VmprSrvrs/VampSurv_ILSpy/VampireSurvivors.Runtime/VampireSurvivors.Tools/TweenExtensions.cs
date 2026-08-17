using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace VampireSurvivors.Tools;

public static class TweenExtensions
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public Tilemap target;

		internal unsafe Color _003CDOFade_003Eb__0()
		{
			//IL_0051: Expected native int or pointer, but got O
			Tilemap tilemap = target;
			bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
			float ret;
			Tilemap.get_color_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, out *(Color*)(&ret));
			Color color = default(Color);
			((Color*)(nint)color)->r = ret;
			return color;
		}

		internal unsafe void _003CDOFade_003Eb__1(Color x)
		{
			Tilemap tilemap = target;
			bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Tilemap.set_color_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref *(Color*)(&value));
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public Tilemap target;

		internal unsafe Color _003CDoTint_003Eb__0()
		{
			//IL_0051: Expected native int or pointer, but got O
			Tilemap tilemap = target;
			bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
			float ret;
			Tilemap.get_color_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, out *(Color*)(&ret));
			Color color = default(Color);
			((Color*)(nint)color)->r = ret;
			return color;
		}

		internal unsafe void _003CDoTint_003Eb__1(Color x)
		{
			Tilemap tilemap = target;
			bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			Tilemap.set_color_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref *(Color*)(&value));
		}
	}

	public static Tween SetGameId(Tween tween)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tween != null)
		{
			tween.stringId = "DefaultGameTweenId";
			return tween;
		}
		return (Tween)(object)new NullReferenceException();
	}

	public static Sequence SetGameId(Sequence tween)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tween != null)
		{
			tween.stringId = "DefaultGameTweenId";
			return tween;
		}
		return (Sequence)(object)new NullReferenceException();
	}

	public static Tween SetGameIdPaused(Tween tween)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tween != null)
		{
			tween.stringId = "PausedGameTweenId";
			return tween;
		}
		return (Tween)(object)new NullReferenceException();
	}

	public static Sequence SetGameIdPaused(Sequence tween)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tween != null)
		{
			tween.stringId = "PausedGameTweenId";
			return tween;
		}
		return (Sequence)(object)new NullReferenceException();
	}

	[MethodImpl((MethodImplOptions)256)]
	public static void KillIfAlive(Tween tween)
	{
		if (tween != null && tween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(tween);
		}
	}

	public static void CompleteIfAlive(Tween tween)
	{
		if (tween != null && tween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Complete(tween, withCallbacks: false);
		}
	}

	public static Tweener DOFade(Tilemap target, float endValue, float duration)
	{
		_003C_003Ec__DisplayClass6_0 obj = new _003C_003Ec__DisplayClass6_0();
		if (obj != null)
		{
			obj.target = target;
			DOGetter<Color> getter = null;
			Color color = obj._003CDOFade_003Eb__0();
			DOSetter<Color> dOSetter = null;
			((_003C_003Ec__DisplayClass6_0)(object)dOSetter)._003CDOFade_003Eb__1((Color)obj);
			TweenerCore<Color, Color, ColorOptions> t = DOTween.ToAlpha(getter, dOSetter, endValue, duration);
			return TweenSettingsExtensions.SetTarget(t, obj.target);
		}
		return (Tweener)(object)new NullReferenceException();
	}

	public static Tweener DoTint(Tilemap target, Color endColour, float duration)
	{
		_003C_003Ec__DisplayClass7_0 obj = new _003C_003Ec__DisplayClass7_0();
		if (obj != null)
		{
			obj.target = target;
			DOGetter<Color> dOGetter = null;
			Color color = obj._003CDoTint_003Eb__0();
			DOSetter<Color> dOSetter = null;
			((_003C_003Ec__DisplayClass7_0)(object)dOSetter)._003CDoTint_003Eb__1((Color)obj);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DA50");
			Tweener result = default(Tweener);
			return result;
		}
		return (Tweener)(object)new NullReferenceException();
	}
}
