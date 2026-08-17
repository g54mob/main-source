using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.UI;

public class GameWindowedUIPage : BaseUIPage
{
	protected ParticleEmitterManager _PfxEmitter;

	protected RectTransform _WindowContainer;

	protected string _ParticleTexture = "shop";

	protected List<string> _ParticleFrames = new List<string>();

	protected List<string> _WindowFrames = new List<string>();

	protected TextMeshProUGUI _Title;

	protected RectTransform _TitlePanel;

	protected RectTransform _Content;

	protected RectTransform _BackButton;

	protected List<GameObject> _spawned = new List<GameObject>();

	protected ParticleSystem _pfx1;

	protected ParticleSystem _pfx2;

	protected bool _particlesCreated;

	protected List<Image> _windows = new List<Image>();

	protected bool hideBackgroundParticles;

	protected bool hideBackgroundWindows;

	public virtual void Purchase(ItemType t, ItemData d, ShopItemUI item, float price, RectTransform sender)
	{
	}

	public virtual void Purchase(WeaponType t, WeaponData d, float price, ShopItemUI item)
	{
	}

	public virtual void SetSelected(ShopItemUI item)
	{
	}

	public virtual void OnUserConfirmInput()
	{
	}

	public virtual float GetCurrency()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		if (!_particlesCreated && !hideBackgroundParticles)
		{
			CreateParticles();
		}
		ClearWindows();
		if (!hideBackgroundWindows)
		{
			CreateWindows();
		}
		if (!hideBackgroundParticles)
		{
			_pfx1.Play(withChildren: true);
			_pfx2.Play(withChildren: true);
		}
	}

	protected override void OnHideFinish(GameObject g)
	{
		base.OnHideFinish(g);
		ParticleSystem pfx = _pfx1;
		if ((object)_pfx1 != null && ((UnityEngine.Object)pfx).m_CachedPtr != (IntPtr)0)
		{
			_pfx1.Stop();
		}
		ParticleSystem pfx2 = _pfx2;
		if ((object)_pfx2 != null && ((UnityEngine.Object)pfx2).m_CachedPtr != (IntPtr)0)
		{
			_pfx2.Stop();
		}
	}

	protected unsafe virtual void CreateParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0073: Expected O, but got I4
		//IL_00b7: Expected O, but got Ref
		//IL_00d0: Expected native int or pointer, but got O
		//IL_00ef: Expected O, but got I
		//IL_011d: Expected O, but got I4
		//IL_0136: Expected O, but got Ref
		//IL_0150: Expected native int or pointer, but got O
		//IL_05a8: Expected O, but got I4
		//IL_0175: Expected O, but got Ref
		//IL_018f: Expected native int or pointer, but got O
		//IL_05e2: Expected O, but got I
		//IL_01c7: Expected O, but got Ref
		//IL_01e1: Expected native int or pointer, but got O
		//IL_061c: Expected O, but got I
		//IL_0232: Expected O, but got I
		//IL_0253: Expected O, but got I
		//IL_0297: Expected O, but got I4
		//IL_02db: Expected O, but got Ref
		//IL_02f4: Expected native int or pointer, but got O
		//IL_030e: Expected O, but got I
		//IL_033c: Expected O, but got I4
		//IL_0355: Expected O, but got Ref
		//IL_036f: Expected native int or pointer, but got O
		//IL_0397: Expected O, but got I
		//IL_0656: Expected O, but got I
		//IL_03aa: Expected O, but got Ref
		//IL_03c4: Expected native int or pointer, but got O
		//IL_0690: Expected O, but got I
		//IL_03fc: Expected O, but got Ref
		//IL_0416: Expected native int or pointer, but got O
		//IL_06ca: Expected O, but got I
		//IL_046d: Expected O, but got I
		//IL_0494: Expected O, but got I
		//IL_04b5: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float num = UIPositionHelper.ScreenHeight();
		float screenPosY = num + 672f;
		float yPositionFromScreenPosition = UIPositionHelper.GetYPositionFromScreenPosition(screenPosY);
		float num2 = UIPositionHelper.ScreenWidth();
		float screenPosX = num2 * 0.25f;
		float xPositionFromScreenPosition = UIPositionHelper.GetXPositionFromScreenPosition(screenPosX);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig(_ParticleTexture);
		particleSystemConfig._frame = _ParticleFrames;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(yPositionFromScreenPosition);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		object obj3 = default(object);
		float max = (float)obj3 * 2f;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, max));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+70]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(10000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-100f, -300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
		_ = 0;
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.8f, 0.9f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig(_ParticleTexture);
		particleSystemConfig2._frame = _ParticleFrames;
		minMaxCurve = new ParticleSystem.MinMaxCurve(yPositionFromScreenPosition);
		particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		Camera main2 = Camera.main;
		Bounds bounds2 = CameraExtensions.OrthographicBounds(main2);
		float max2 = (float)obj3 * 2f;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, max2));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E0]");
		particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F0]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(10000f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(-100f, -300f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+110]");
		obj = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(2f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+140]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+150]");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 1133903872;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		Transform transform = _PfxEmitter.transform;
		Transform parent = default(Transform);
		string psName = default(string);
		bool isAdditive = default(bool);
		bool requiresMasking = default(bool);
		ParticleSystem pfx = _PfxEmitter.CreateUIEmitter(particleSystemConfig, "UI", 3, parent, psName, isAdditive, requiresMasking);
		_pfx1 = pfx;
		Transform transform2 = _PfxEmitter.transform;
		ParticleSystem pfx2 = _PfxEmitter.CreateUIEmitter(particleSystemConfig2, "UI", 3, parent, psName, isAdditive, requiresMasking);
		_pfx2 = pfx2;
		_particlesCreated = true;
	}

	protected unsafe virtual void CreateWindows()
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_00bb: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_00de: Expected O, but got I4
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected O, but got Unknown
		//IL_0104: Expected O, but got I4
		//IL_010d: Expected O, but got I4
		//IL_0223: Expected O, but got Ref
		//IL_0260: Expected O, but got I4
		//IL_0436: Expected F4, but got I4
		//IL_027b: Expected O, but got I8
		//IL_028d: Expected F4, but got I8
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_03aa->IL05a7: Incompatible stack heights: 5 vs 0
		//IL_02d9->IL04a8: Incompatible stack heights: 4 vs 0
		//IL_0313->IL03bb: Incompatible stack heights: 4 vs 0
		ClearWindows();
		string[] array = _WindowFrames.ToArray();
		float num = UIPositionHelper.ScreenWidth();
		string[] array2 = ((List<string>)null).ToArray();
		object obj = array2 + 1;
		float num2 = UIPositionHelper.ScreenHeight();
		string[] array3 = ((List<string>)null).ToArray();
		object obj2 = array3 + 1;
		float value = default(float);
		if ((nint)obj > 0)
		{
			float num4 = default(float);
			float num3 = num4;
			object obj3 = 0;
			object obj4 = 0;
			object obj5 = obj;
			object obj6 = 0;
			object obj7 = 0;
			object obj8 = obj2;
			List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
			Vector2 anchorMax = default(Vector2);
			Vector2 anchorMin = default(Vector2);
			List<Image> list = default(List<Image>);
			bool flag7;
			do
			{
				if ((nint)obj8 > 0)
				{
					float num5 = (float)obj7 + 128f;
					object obj9 = 0;
					object obj10 = 0;
					float num9;
					do
					{
						object obj11 = obj10 + obj10;
						GameObject gameObject = new GameObject();
						Transform transform = gameObject.transform;
						transform.parent = _WindowContainer;
						RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
						rectTransform.anchoredPosition = (Vector2)enumerator;
						rectTransform.sizeDelta = (Vector2)enumerator;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
						rectTransform.anchorMax = anchorMax;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
						rectTransform.anchorMin = anchorMin;
						Image image = gameObject.AddComponent<Image>();
						int num6 = UnityEngine.Random.Range(0, array.Length);
						bool flag = num6 >= array.Length;
						Sprite sprite = SpriteManager.GetSprite(array[num6], "shop");
						image.sprite = sprite;
						image.color = (Color)(&list);
						RectTransform rectTransform2 = image.rectTransform;
						float num7 = UnityEngine.Random.Range(0f, 1f);
						bool flag2 = num7 > 0.5f;
						object obj12 = 1;
						if (!flag2)
						{
							obj12 = 4294967295L;
						}
						float num8 = UnityEngine.Random.Range(0f, 1f);
						bool flag3 = num8 > 0.5f;
						num9 = 1f;
						if (!flag3)
						{
							num9 = 4.2949673E+09f;
						}
						bool flag4 = (object)rectTransform2 == null;
						bool flag5 = ((UnityEngine.Object)rectTransform2).m_CachedPtr == (IntPtr)0;
						Transform.set_localScale_Injected(((UnityEngine.Object)rectTransform2).m_CachedPtr, ref *(Vector3*)(&value));
						bool flag6 = _windows == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A77500");
						obj9++;
						obj10 += 358;
					}
					while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2));
					num3 = num9;
					list = null;
					obj5 = obj;
					obj6 = obj4;
					obj7 = obj3;
					obj8 = obj2;
				}
				obj6++;
				obj7 += 256;
				flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5);
				num4 = num3;
				obj3 = obj7;
				obj4 = obj6;
			}
			while (flag7);
		}
		List<Image>.Enumerator enumerator2 = default(List<Image>.Enumerator);
		RectTransform rectTransform4 = default(RectTransform);
		RectTransform rectTransform5 = default(RectTransform);
		List<Image>.Enumerator value2 = default(List<Image>.Enumerator);
		while (enumerator2.MoveNext())
		{
			RectTransform rectTransform3 = ((Graphic)null).rectTransform;
			bool flag8 = (object)rectTransform3 == null;
			bool flag9 = ((UnityEngine.Object)rectTransform3).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)rectTransform3).m_CachedPtr, out *(Vector3*)(&value));
			bool flag10 = ((UnityEngine.Object)rectTransform4).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)rectTransform4).m_CachedPtr, out Vector3 _);
			bool flag11 = (object)rectTransform5 == null;
			bool flag12 = ((UnityEngine.Object)rectTransform5).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)rectTransform5).m_CachedPtr, ref *(Vector3*)(&value2));
			RectTransform rectTransform6 = ((Graphic)null).rectTransform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(rectTransform6, value, 1f);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade((Image)null, 1f, 1f);
			float num4 = 1f;
		}
	}

	protected void ClearWindows()
	{
		//IL_0039->IL0125: Incompatible stack heights: 1 vs 0
		if (_windows != null)
		{
			List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v7 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj2, 0f);
			}
			List<Image> windows = _windows;
			if (_windows != null)
			{
				int version = windows._version + 1;
				windows._version = version;
				windows._size = 0;
				if (windows._size > 0)
				{
					Array.Clear(windows._items, 0, windows._size);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected unsafe Sequence BackButtonInTween()
	{
		//IL_0066: Expected O, but got Ref
		//IL_0154: Expected O, but got Ref
		//IL_0113->IL0113: Incompatible stack heights: 6 vs 5
		//IL_01c4->IL01c4: Incompatible stack heights: 7 vs 6
		Sequence sequence = DOTween.Sequence();
		Transform transform = _BackButton.transform;
		bool flag = (object)transform == null;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag3 = (object)_BackButton == null;
		Transform transform2 = _BackButton.transform;
		bool flag4 = (object)transform2 == null;
		object obj = default(object);
		transform2.localEulerAngles = (Vector3)(&obj);
		bool flag5 = (object)_BackButton == null;
		Transform target = _BackButton.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, 1f, 0.15f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			bool flag6 = sequence == null;
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
		}
		bool flag7 = (object)_BackButton == null;
		Transform target2 = _BackButton.transform;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj), 0.15f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
		{
			bool flag8 = sequence == null;
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, sequence.lastTweenInsertTime);
		}
		return sequence;
	}
}
