using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class RuneStripVfx2 : GameMonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public RuneText rune;

		internal float _003CInit_003Eb__2()
		{
			RuneText runeText = rune;
			return runeText._003CZ_003Ek__BackingField;
		}

		internal void _003CInit_003Eb__3(float v)
		{
			RuneText runeText = rune;
			runeText._003CZ_003Ek__BackingField = v;
		}
	}

	private float _heightAlpha;

	private float _alpha = 0.5f;

	private List<RuneText> _followers;

	private PhaserSpline _runeSpline;

	private Tween _alphaTween;

	private Transform _cachedTransform;

	private GameObject _runeTextPrefab;

	private Camera MainCam => Camera.main;

	private unsafe Bounds CamBounds
	{
		get
		{
			//IL_001f: Expected native int or pointer, but got O
			Camera main = Camera.main;
			Bounds bounds = default(Bounds);
			((Bounds*)(nint)bounds)->m_Center = CameraExtensions.OrthographicBounds(main).m_Center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v4 (UnityEngine.Bounds)+10]");
			_ = 0;
			return bounds;
		}
	}

	public static RuneStripVfx2 Create(float x, float durationMillis, int flip = 1, float alphaStart = 1f, float alphaEnd = 0.5f)
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "RuneStripVfx2");
		if ((object)gameObject != null)
		{
			RuneStripVfx2 runeStripVfx = gameObject.AddComponent<RuneStripVfx2>();
			if ((object)runeStripVfx != null)
			{
				float alphaStart2 = default(float);
				float alphaEnd2 = default(float);
				runeStripVfx.Init(x, durationMillis, flip, alphaStart2, alphaEnd2);
				return runeStripVfx;
			}
		}
		return (RuneStripVfx2)(object)new NullReferenceException();
	}

	public unsafe void InternalUpdate(float prop)
	{
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected F4, but got Unknown
		//IL_019c: Expected O, but got I
		//IL_00cb: Expected I, but got O
		//IL_00dd: Expected I, but got O
		//IL_00ee->IL01a1: Incompatible stack heights: 3 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float heightAlpha = prop ^ 0;
		_heightAlpha = heightAlpha;
		List<RuneText> followers = _followers;
		List<RuneText>.Enumerator enumerator = default(List<RuneText>.Enumerator);
		List<RuneText>.Enumerator value = default(List<RuneText>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rbx_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rbx_v4 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rbx_v4 (System.Object)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rbx_v4 (System.Object)+28]");
			bool flag3 = (nint)0 == 0;
			nint num = (nint)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v807 @ r8_v7 (Il2CppClass<System.Object>)+298] (should have been resolved before IL gen)");
			nint num2 = (nint)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v827 @ r8_v9 (Il2CppClass<System.Object>)+2A8] (should have been resolved before IL gen)");
		}
	}

	private unsafe void Init(float x, float durationMillis, int flip = 1, float alphaStart = 1f, float alphaEnd = 0.5f)
	{
		//IL_06d4: Expected O, but got I8
		//IL_0174: Expected O, but got I4
		//IL_0193: Expected O, but got I8
		//IL_01fe: Expected O, but got Ref
		//IL_0248: Expected I4, but got I8
		//IL_0436: Expected O, but got Ref
		//IL_07cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d1: Expected O, but got Unknown
		Transform cachedTransform = base.transform;
		object obj = 6442450944L;
		_cachedTransform = cachedTransform;
		object cachedTransform2 = _cachedTransform;
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		Camera main2 = Camera.main;
		Bounds bounds2 = CameraExtensions.OrthographicBounds(main2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v1 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v1 (System.Object)+10]");
			Vector2 value = default(Vector2);
			Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
			Camera main3 = Camera.main;
			Transform parent = main3.transform;
			_cachedTransform.SetParent(parent, worldPositionStays: true);
			Camera main4 = Camera.main;
			Bounds bounds3 = CameraExtensions.OrthographicBounds(main4);
			List<RuneText> followers = new List<RuneText>();
			_followers = followers;
			Camera main5 = Camera.main;
			Bounds bounds4 = CameraExtensions.OrthographicBounds(main5);
			List<Vector2> list = new List<Vector2>();
			Vector2 vector = default(Vector2);
			list.Add(vector);
			list.Add(vector);
			list.Add(vector);
			list.Add(vector);
			list.Add(vector);
			list.Add(vector);
			PhaserSpline phaserSpline = null;
			phaserSpline._points = list;
			nint num = 0;
			_runeSpline = phaserSpline;
			Vector3 vector2 = bounds4.m_Center;
			value = vector;
			Vector2 vector3 = (Vector2)0;
			RuneText rune = default(RuneText);
			float xScale = default(float);
			float num7;
			bool flag;
			do
			{
				_003C_003Ec__DisplayClass13_0 obj2 = new _003C_003Ec__DisplayClass13_0();
				if ((nint)vector3 <= 11)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r12_v1+6FD99E4+v550 @ rdi_v8 (UnityEngine.Vector2)*4]");
					object obj3 = 0 + 6442450944L;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v825 @ rdx_v53 (should have been resolved before IL gen)");
				}
				else
				{
					rune = CreateRune(0f, -0.32f, "");
				}
				obj2.rune = rune;
				((List<object>)(object)_followers).Add((object)obj2.rune);
				RuneText rune2 = obj2.rune;
				Transform transform = ((Component)rune2._003CTextRenderer_003Ek__BackingField).transform;
				transform.localEulerAngles = (Vector3)(&value);
				RuneText runeText = RenderingExtensions.SetScale(obj2.rune, 1f, 1f);
				RuneText rune3 = obj2.rune;
				rune3._003CTextRenderer_003Ek__BackingField.sortingOrder = -32668;
				RuneText rune4 = obj2.rune;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B080");
				RuneText rune5 = obj2.rune;
				rune5._003CZ_003Ek__BackingField = 0f;
				RuneText rune6 = obj2.rune;
				DOGetter<float> dOGetter = null;
				RuneText runeText2 = RenderingExtensions.SetScale((RuneText)(object)dOGetter, xScale, 1f);
				DOSetter<float> dOSetter = null;
				RuneText runeText3 = RenderingExtensions.SetScale((RuneText)(object)dOSetter, xScale, 1f);
				float duration = durationMillis * 0.001f;
				TweenerCore<float, float, FloatOptions> t = DOTween.To(dOGetter, dOSetter, 1f, duration);
				float num2 = durationMillis * 0.04f;
				float num3 = num2 * (float)vector3;
				float num4 = num3 * 0.001f;
				TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, num4);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1361 @ rax_v68 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1361 @ rax_v68 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1361 @ rax_v68 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
					}
				}
				RuneText gameId = RenderingExtensions.SetScale((RuneText)(object)tweenerCore, num4, 1f);
				Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId((Tween)(object)gameId);
				rune6._003CZTween_003Ek__BackingField = tween;
				Transform target = obj2.rune.transform;
				float duration2 = durationMillis * 0.001f;
				TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&vector2), duration2);
				TweenerCore<float, float, FloatOptions> t3 = TweenSettingsExtensions.SetDelay((TweenerCore<float, float, FloatOptions>)(object)t2, num4);
				float num5 = durationMillis * 0.04f;
				float num6 = num5 * (float)vector3;
				num7 = num6 * 0.001f;
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay((TweenerCore<Quaternion, Vector3, QuaternionOptions>)(object)t3, num7);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1434 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1434 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1434 @ rax_v75 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
					}
				}
				Tween tween2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(tweenerCore2);
				Vector2 vector4 = vector3 + 1;
				flag = (nint)vector4 <= 11;
				vector2 = vector;
				value = vector;
				vector3 = vector4;
				num = 0;
			}
			while (flag);
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter2 = null;
			((RuneStripVfx2)(object)dOSetter2)._003CInit_003Eb__13_1(num7);
			float num8 = durationMillis * 0.25f;
			float duration3 = num8 * 0.001f;
			float endValue = default(float);
			TweenerCore<float, float, FloatOptions> tweenerCore3 = DOTween.To(getter, dOSetter2, endValue, duration3);
			if (tweenerCore3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1523 @ rax_v83 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 3;
					_ = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1523 @ rax_v83 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1523 @ rax_v83 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1523 @ rax_v83 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
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
			_alphaTween = tweenerCore3;
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform2);
		throw new NullReferenceException();
	}

	private unsafe RuneText CreateRune(float x, float y, string text)
	{
		//IL_0154: Invalid comparison between F4 and I4
		//IL_016c: Expected native int or pointer, but got F4
		//IL_0163->IL0184: Incompatible stack heights: 4 vs 0
		GameObject runeTextPrefab = _runeTextPrefab;
		if ((object)_runeTextPrefab == null || ((UnityEngine.Object)runeTextPrefab).m_CachedPtr == (IntPtr)0)
		{
			GameObject runeTextPrefab2 = Resources.Load<GameObject>("RuneText");
			_runeTextPrefab = runeTextPrefab2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C10");
		GameObject gameObject = default(GameObject);
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			Transform parent = base.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, worldPositionStays: true);
				Transform transform2 = gameObject.transform;
				object obj = default(object);
				float num = (float)obj * 0.01f;
				float num2 = (float)Vector3.oneVector * 0.01f;
				bool flag = (object)transform2 == null;
				bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				RuneText component = gameObject.GetComponent<RuneText>();
				bool flag3 = (object)component == null;
				bool flag4 = (object)component._003CTextRenderer_003Ek__BackingField == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
				float heightAlpha = ((RuneStripVfx2)(object)component)._heightAlpha;
				if (((RuneStripVfx2)(object)component)._heightAlpha != 0f)
				{
					float value2 = ((float*)(nint)heightAlpha)->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v670 @ rax_v32 (System.Single)+2A8] (should have been resolved before IL gen)");
					return component;
				}
			}
		}
		throw new NullReferenceException();
	}

	public RuneStripVfx2()
	{
		List<RuneText> followers = new List<RuneText>();
		_followers = followers;
		base._onResumeSent = true;
	}

	private float _003CInit_003Eb__13_0()
	{
		return _alpha;
	}

	private void _003CInit_003Eb__13_1(float v)
	{
		_alpha = v;
	}
}
