using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class GoldFeverFlashingLights : MonoBehaviour
{
	private List<Image> _Lights;

	private List<Sprite> _Sprites;

	private List<Tween> _tweens;

	private unsafe void Awake()
	{
		//IL_0013: Expected O, but got I4
		//IL_003b: Expected O, but got Ref
		//IL_00f2: Expected O, but got I4
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00d9: Expected O, but got I4
		object obj = 0;
		List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				List<Sprite> sprites = _Sprites;
				bool flag = _Sprites == null;
				List<Image>.Enumerator enumerator2 = (List<Image>.Enumerator)(&enumerator);
				if (flag)
				{
					break;
				}
				if ((nint)obj < sprites._size)
				{
					Sprite[] items = sprites._items;
					((Image)null).sprite = items[obj];
					obj++;
					List<Sprite> sprites2 = _Sprites;
					if ((nint)obj >= sprites2._size)
					{
						obj = 0;
					}
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				enumerator2 = (List<Image>.Enumerator)0;
				break;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe void Show()
	{
		//IL_02e5: Expected O, but got Ref
		//IL_01b4: Expected O, but got I4
		//IL_01bc->IL0321: Incompatible stack heights: 6 vs 0
		//IL_017d->IL0321: Incompatible stack heights: 6 vs 0
		List<Tween>.Enumerator enumerator = default(List<Tween>.Enumerator);
		while (enumerator.MoveNext())
		{
		}
		List<Image>.Enumerator enumerator2 = default(List<Image>.Enumerator);
		Vector3 value = default(Vector3);
		List<Image>.Enumerator enumerator3 = default(List<Image>.Enumerator);
		while (enumerator2.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rdi_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rdi_v4 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag2 = (object)transform == null;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			List<object> tweens = (List<object>)(object)_tweens;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rdi_v4 (System.Object)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rdi_v4 (System.Object)+10]");
			IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&enumerator3), 1.5000001f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v940 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
				}
			}
			bool flag5 = _tweens == null;
			int version = tweens._version + 1;
			tweens._version = version;
			List<Tween> items = (List<Tween>)(object)tweens._items;
			bool flag6 = tweens._items == null;
			if (tweens._size >= items._size)
			{
				((List<object>)(object)_tweens).AddWithResize((object)tweenerCore);
				continue;
			}
			int size = tweens._size + 1;
			tweens._size = size;
			((List<Tween>)(object)tweens._items).AddWithResize((Tween)tweens._size);
		}
	}

	public unsafe void Exit()
	{
		//IL_0261: Expected O, but got Ref
		//IL_013e: Expected I, but got O
		//IL_0154: Expected O, but got I
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_01cb: Expected I, but got O
		//IL_01d8: Expected O, but got I
		//IL_03f7: Expected O, but got I4
		//IL_040e: Expected I, but got I8
		//IL_01b4: Expected O, but got I8
		//IL_036b: Expected O, but got Ref
		//IL_0124: Expected O, but got I4
		//IL_012c->IL038a: Incompatible stack heights: 6 vs 0
		//IL_00ed->IL038a: Incompatible stack heights: 6 vs 0
		bool flag = _tweens == null;
		GoldFeverFlashingLights goldFeverFlashingLights = this;
		TweenCallback tweenCallback;
		if (!flag)
		{
			List<Tween>.Enumerator enumerator = default(List<Tween>.Enumerator);
			while (enumerator.MoveNext())
			{
			}
			bool flag2 = _Lights == null;
			goldFeverFlashingLights = (GoldFeverFlashingLights)(&enumerator);
			if (!flag2)
			{
				List<Image>.Enumerator enumerator2 = default(List<Image>.Enumerator);
				Vector3 value = default(Vector3);
				List<Image>.Enumerator enumerator3 = default(List<Image>.Enumerator);
				while (enumerator2.MoveNext())
				{
					object obj = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rsi_v15 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rsi_v15 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					bool flag4 = (object)transform == null;
					bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					List<object> tweens = (List<object>)(object)_tweens;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rsi_v15 (System.Object)+10]");
					bool flag6 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rsi_v15 (System.Object)+10]");
					IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
					Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
					TweenerCore<Vector3, Vector3, VectorOptions> item = ShortcutExtensions.DOScale(target, (Vector3)(&enumerator3), 1f);
					bool flag7 = _tweens == null;
					int version = tweens._version + 1;
					tweens._version = version;
					List<Tween> items = (List<Tween>)(object)tweens._items;
					bool flag8 = tweens._items == null;
					if (tweens._size >= items._size)
					{
						((List<object>)(object)_tweens).AddWithResize((object)item);
						continue;
					}
					int size = tweens._size + 1;
					tweens._size = size;
					((List<Tween>)(object)tweens._items).Add((Tween)tweens._size);
				}
				tweenCallback = null;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ r9_v16 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(GoldFeverFlashingLights._003CExit_003Eb__5_0);
				((Delegate)tweenCallback).m_target = this;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ r9_v16 (Il2CppMethodInfo)+4C]");
				object obj2 = (nint)0 >> 4;
				object obj3 = obj2 & 1;
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ r9_v16 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						goldFeverFlashingLights = (GoldFeverFlashingLights)6447293664L;
						goto IL_03ee;
					}
				}
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				goldFeverFlashingLights = (GoldFeverFlashingLights)(nint)((Delegate)tweenCallback).method_ptr;
				goto IL_03ee;
			}
		}
		goto IL_01f1;
		IL_03ee:
		object obj4 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		Tween tween = DOVirtual.DelayedCall(1f, tweenCallback);
		if (tween != null)
		{
			tween.stringId = "UI_CUSTOM_TIMER";
			return;
		}
		goto IL_01f1;
		IL_01f1:
		throw new NullReferenceException();
	}

	public GoldFeverFlashingLights()
	{
		List<Image> lights = new List<Image>();
		_Lights = lights;
		List<Sprite> sprites = new List<Sprite>();
		_Sprites = sprites;
		List<Tween> tweens = new List<Tween>();
		_tweens = tweens;
	}

	private void _003CExit_003Eb__5_0()
	{
		List<Tween> tweens = _tweens;
		int version = tweens._version + 1;
		tweens._version = version;
		tweens._size = 0;
		if (tweens._size > 0)
		{
			Array.Clear(tweens._items, 0, tweens._size);
		}
	}
}
