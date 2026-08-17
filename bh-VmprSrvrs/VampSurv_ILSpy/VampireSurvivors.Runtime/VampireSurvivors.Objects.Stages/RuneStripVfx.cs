using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class RuneStripVfx : GameMonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public Rune rune;

		internal float _003CInit_003Eb__2()
		{
			Rune rune = this.rune;
			return rune._003CZ_003Ek__BackingField;
		}

		internal void _003CInit_003Eb__3(float v)
		{
			Rune rune = this.rune;
			rune._003CZ_003Ek__BackingField = v;
		}
	}

	private float _heightAlpha;

	private float _alpha = 0.5f;

	private List<Rune> _followers;

	private PhaserSpline _runeSpline;

	private Tween _alphaTween;

	private Transform _cachedTransform;

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

	public static RuneStripVfx Create(float x, float duration, int flip = 1, float alphaStart = 1f, float alphaEnd = 0.5f)
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "RuneStripVfx");
		if ((object)gameObject != null)
		{
			RuneStripVfx runeStripVfx = gameObject.AddComponent<RuneStripVfx>();
			if ((object)runeStripVfx != null)
			{
				float alphaStart2 = default(float);
				float alphaEnd2 = default(float);
				runeStripVfx.Init(x, duration, flip, alphaStart2, alphaEnd2);
				return runeStripVfx;
			}
		}
		return (RuneStripVfx)(object)new NullReferenceException();
	}

	public unsafe void InternalUpdate(float prop)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected F4, but got Unknown
		//IL_0056: Expected F4, but got I
		//IL_0091: Expected O, but got I
		//IL_009c->IL0143: Incompatible stack heights: 2 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float heightAlpha = prop ^ 0;
		_heightAlpha = heightAlpha;
		List<Rune>.Enumerator enumerator = default(List<Rune>.Enumerator);
		List<Rune>.Enumerator value = default(List<Rune>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v4 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			PhaserSpline runeSpline = _runeSpline;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v4 (System.Object)+48]");
			Vector2 point = runeSpline.GetPoint(0f);
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			float alpha = _heightAlpha * _alpha;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rbx_v4 (System.Object)+28]");
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha((SpriteRenderer)0, alpha);
		}
	}

	private unsafe void Init(float x, float duration, int flip = 1, float alphaStart = 1f, float alphaEnd = 0.5f)
	{
		//IL_01ba: Expected O, but got I4
		//IL_02d6: Expected O, but got I4
		//IL_02d6: Expected I4, but got O
		//IL_0336: Expected O, but got Ref
		//IL_0b17: Expected I4, but got I8
		//IL_0451: Expected O, but got I
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Expected O, but got Unknown
		//IL_04d3: Expected O, but got I
		//IL_0b32: Expected O, but got I4
		//IL_04f3: Expected O, but got I
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_0575: Expected O, but got I
		//IL_04b1: Expected O, but got I8
		//IL_0b6f: Expected O, but got I4
		//IL_0553: Expected O, but got I8
		//IL_0c14: Expected O, but got Ref
		//IL_0861: Unknown result type (might be due to invalid IL or missing references)
		//IL_0866: Expected O, but got Unknown
		//IL_0896->IL0c67: Incompatible stack heights: 2 vs 0
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		object cachedTransform2 = _cachedTransform;
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		Camera main2 = Camera.main;
		Bounds bounds2 = CameraExtensions.OrthographicBounds(main2);
		if ((object)_cachedTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v1 (System.Object)+10]");
			if ((nint)0 == 0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v1 (System.Object)+10]");
				Vector2 value = default(Vector2);
				Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
				Camera main3 = Camera.main;
				if ((object)main3 != null)
				{
					Transform parent = main3.transform;
					if ((object)_cachedTransform != null)
					{
						_cachedTransform.SetParent(parent, worldPositionStays: true);
						Camera main4 = Camera.main;
						Bounds bounds3 = CameraExtensions.OrthographicBounds(main4);
						List<Rune> followers = new List<Rune>();
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
						_runeSpline = phaserSpline;
						string text = default(string);
						int num = default(int);
						bool flag = default(bool);
						List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("_runes_0", 2, 6, vector, text, num, flag);
						Vector2 vector2 = (Vector2)0;
						Vector3 vector3 = bounds4.m_Center;
						value = vector;
						Vector2 vector4 = vector;
						bool autoSetAnimation = default(bool);
						float alpha = default(float);
						float num8;
						bool flag4;
						do
						{
							_003C_003Ec__DisplayClass12_0 obj = new _003C_003Ec__DisplayClass12_0();
							Rune rune = CreateRune(0f, -0.32f);
							obj.rune = rune;
							List<object> followers2 = (List<object>)(object)_followers;
							int version = followers2._version + 1;
							followers2._version = version;
							object[] items = followers2._items;
							if (followers2._size >= items.Length)
							{
								followers2.AddWithResize((object)obj.rune);
							}
							else
							{
								int size = followers2._size + 1;
								followers2._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Rune rune2 = obj.rune;
							rune2._003CSpriteAnimation_003Ek__BackingField.AddAnimation("Idle", animationFrames, 8, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
							Rune rune3 = obj.rune;
							rune3._003CSpriteAnimation_003Ek__BackingField.SetAnimation("Idle");
							Rune rune4 = obj.rune;
							Transform transform = rune4._003CSpriteRenderer_003Ek__BackingField.transform;
							transform.localEulerAngles = (Vector3)(&value);
							Rune rune5 = obj.rune;
							Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
							((Renderer)rune5._003CSpriteRenderer_003Ek__BackingField).SetMaterial(material);
							Rune rune6 = obj.rune;
							SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(rune6._003CSpriteRenderer_003Ek__BackingField, 0.5f, 0.5f);
							Rune rune7 = obj.rune;
							object obj2 = rune7._003CSpriteRenderer_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rbx_v19 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rbx_v19 (System.Object)+10]");
							Renderer.set_sortingOrder_Injected((IntPtr)0, -32668);
							Rune rune8 = obj.rune;
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(rune8._003CSpriteRenderer_003Ek__BackingField, alpha);
							Rune rune9 = obj.rune;
							rune9._003CZ_003Ek__BackingField = 0f;
							Rune rune10 = obj.rune;
							DOGetter<float> getter = null;
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1981 @ r9_v14 (Il2CppMethodInfo)+8]");
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1981 @ r9_v14 (Il2CppMethodInfo)+4C]");
							object obj3 = (nint)0 >> 4;
							object obj4 = obj3 & 1;
							object obj5;
							if (obj4 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1981 @ r9_v14 (Il2CppMethodInfo)+52]");
								if ((nint)0 == 0)
								{
									obj5 = 6447965120L;
									goto IL_0b29;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1970 @ rax_v85 (DG.Tweening.Core.DOGetter`1<System.Single>)+20]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1970 @ rax_v85 (DG.Tweening.Core.DOGetter`1<System.Single>)+10]");
							obj5 = 0;
							goto IL_0b29;
							IL_0b29:
							object obj6 = 24;
							_ = 6447969936L;
							DOSetter<float> setter = null;
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2101 @ r9_v15 (Il2CppMethodInfo)+8]");
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2101 @ r9_v15 (Il2CppMethodInfo)+4C]");
							object obj7 = (nint)0 >> 4;
							object obj8 = obj7 & 1;
							object obj9;
							if (obj8 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2101 @ r9_v15 (Il2CppMethodInfo)+52]");
								if ((nint)0 == 1)
								{
									obj9 = 6447299152L;
									goto IL_0b66;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2089 @ rax_v92 (DG.Tweening.Core.DOSetter`1<System.Single>)+20]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2089 @ rax_v92 (DG.Tweening.Core.DOSetter`1<System.Single>)+10]");
							obj9 = 0;
							goto IL_0b66;
							IL_0b66:
							object obj10 = 24;
							_ = 6449796912L;
							float duration2 = duration * 0.001f;
							TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, 1f, duration2);
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2225 @ rax_v100 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 1;
									_ = 0;
								}
							}
							float num4 = duration * 0.04f;
							float num5 = num4 * (float)vector2;
							float delay = num5 * 0.001f;
							TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(tweenerCore, delay);
							if (tweenerCore2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2290 @ rax_v102 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2290 @ rax_v102 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = 4294967295L;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2290 @ rax_v102 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
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
							rune10._003CZTween_003Ek__BackingField = tweenerCore2;
							object rune11 = obj.rune;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rbp_v8 (System.Object)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rbp_v8 (System.Object)+10]");
							IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
							Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							float duration3 = duration * 0.001f;
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&vector3), duration3);
							if (tweenerCore3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2552 @ rax_v113 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 1;
									_ = 0;
								}
							}
							float num6 = duration * 0.04f;
							float num7 = num6 * (float)vector2;
							num8 = num7 * 0.001f;
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = TweenSettingsExtensions.SetDelay(tweenerCore3, num8);
							if (tweenerCore4 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2617 @ rax_v115 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2617 @ rax_v115 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = 4294967295L;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2617 @ rax_v115 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
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
							vector2++;
							flag4 = (nint)vector2 < 5;
							vector3 = vector;
							value = vector;
							vector4 = vector2;
						}
						while (flag4);
						DOGetter<float> getter2 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
						DOSetter<float> dOSetter = null;
						((RuneStripVfx)(object)dOSetter)._003CInit_003Eb__12_1(num8);
						float num9 = duration * 0.25f;
						float duration4 = num9 * 0.001f;
						float endValue = default(float);
						TweenerCore<float, float, FloatOptions> tweenerCore5 = DOTween.To(getter2, dOSetter, endValue, duration4);
						if (tweenerCore5 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2867 @ rax_v126 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
							if ((nint)0 != 0)
							{
								_ = 3;
								_ = 0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2867 @ rax_v126 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2867 @ rax_v126 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2867 @ rax_v126 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
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
						_alphaTween = tweenerCore5;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private Rune CreateRune(float x, float y)
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "Rune");
		Transform transform = gameObject.transform;
		bool flag = (object)transform == null;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = gameObject.transform;
		Transform parent = base.transform;
		bool flag3 = (object)transform2 == null;
		transform2.SetParent(parent, worldPositionStays: true);
		return gameObject.AddComponent<Rune>();
	}

	public RuneStripVfx()
	{
		List<Rune> followers = new List<Rune>();
		_followers = followers;
		base._onResumeSent = true;
	}

	private float _003CInit_003Eb__12_0()
	{
		return _alpha;
	}

	private void _003CInit_003Eb__12_1(float v)
	{
		_alpha = v;
	}
}
