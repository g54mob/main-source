using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Bindings;

namespace VampireSurvivors.UI;

public class UICarousel : MonoBehaviour
{
	public enum CarouselAxis
	{
		X,
		Y
	}

	public delegate void OnSelectionChanged(int index);

	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public GameObject item;

		internal void _003CMoveNext_003Eb__0()
		{
			UnityEngine.Object.Destroy(item, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public GameObject item;

		internal void _003CMovePrevious_003Eb__0()
		{
			UnityEngine.Object.Destroy(item, 0f);
		}
	}

	private RectTransform _TopSlot;

	private RectTransform _BottomSlot;

	private RectTransform _Disabled;

	private RectTransform _Container;

	private float _Padding;

	private float _MaxDistance;

	private float _ItemsToShow;

	private CarouselAxis _Axis;

	private OnSelectionChanged m_SelectionChanged;

	private RectTransform _rTrans;

	private float _size;

	private float _itemCount;

	private float _spacing;

	private int _halfSize;

	private int _midIndex;

	private float _itemHeight;

	private float _itemWidth;

	private List<GameObject> _cachedItems;

	private List<Transform> _slots;

	private List<GameObject> _spawnedItems;

	private int _currentIndex;

	public event OnSelectionChanged SelectionChanged
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 80;
			Delegate obj2 = this.m_SelectionChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnSelectionChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 80;
			Delegate obj2 = this.m_SelectionChanged;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnSelectionChanged);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public void Initialize(List<GameObject> carouselItems, int selectedIndex = 0)
	{
		//IL_030e: Expected O, but got I
		//IL_02bb: Expected O, but got I
		//IL_0051: Expected F4, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_00af: Expected I4, but got O
		//IL_021f: Expected F4, but got O
		//IL_024e->IL036f: Incompatible stack heights: 7 vs 5
		RectTransform component = GetComponent<RectTransform>();
		_rTrans = component;
		object rTrans = _rTrans;
		bool num;
		Rect ret;
		float size;
		if (_Axis != CarouselAxis.Y)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v1 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			num = flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v1 (System.Object)+10]");
			RectTransform.get_rect_Injected((IntPtr)0, out ret);
			float num2 = default(float);
			size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v1 (System.Object)+10]");
			object obj = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v1 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			num = flag2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v1 (System.Object)+10]");
			RectTransform.get_rect_Injected((IntPtr)0, out ret);
			float num3 = default(float);
			size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v1 (System.Object)+10]");
			object obj = 0;
		}
		_size = size;
		_itemCount = carouselItems._size;
		float spacing = _size / _ItemsToShow;
		_spacing = spacing;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rdi+48h]\"");
		object obj3 = default(object);
		object obj2 = obj3 - 1;
		object obj4 = obj2 >> 31;
		object obj5 = obj2 - obj4;
		int halfSize = obj5 >> 1;
		_halfSize = halfSize;
		_cachedItems = carouselItems;
		int currentIndex = default(int);
		_currentIndex = currentIndex;
		float num4 = _ItemsToShow * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		int midIndex = default(int);
		_midIndex = midIndex;
		List<GameObject> cachedItems = _cachedItems;
		bool flag3 = cachedItems._size <= 0;
		GameObject[] items = cachedItems._items;
		bool flag4 = items.Length <= 0;
		RectTransform component2 = items[0].GetComponent<RectTransform>();
		Vector2 sizeDelta = component2.sizeDelta;
		float itemHeight = default(float);
		_itemHeight = itemHeight;
		List<GameObject> cachedItems2 = _cachedItems;
		bool flag5 = cachedItems2._size <= 0;
		GameObject[] items2 = cachedItems2._items;
		bool flag6 = items2.Length <= 0;
		RectTransform component3 = items2[0].GetComponent<RectTransform>();
		Vector2 sizeDelta2 = component3.sizeDelta;
		_itemWidth = (float)sizeDelta2;
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj6 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v740 @ rbx_v5 (System.Object)+10]");
			bool flag7 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v740 @ rbx_v5 (System.Object)+10]");
			IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag8 = (object)transform == null;
			transform.SetParent(_Disabled, worldPositionStays: true);
		}
		CreateSlots2();
		CreateItems();
		AdjustMask();
	}

	public unsafe void Clear()
	{
		//IL_0289: Expected O, but got Ref
		//IL_0328: Expected O, but got Ref
		//IL_00f7: Expected I4, but got O
		//IL_00f7: Expected O, but got I
		//IL_0183: Expected I4, but got O
		//IL_0183: Expected O, but got I
		//IL_020f: Expected I4, but got O
		//IL_020f: Expected O, but got I
		//IL_0070->IL02e9: Incompatible stack heights: 1 vs 0
		bool flag = _cachedItems == null;
		UICarousel uICarousel = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			bool flag2 = _slots == null;
			uICarousel = (UICarousel)(&enumerator);
			if (!flag2)
			{
				List<Transform>.Enumerator enumerator2 = default(List<Transform>.Enumerator);
				while (enumerator2.MoveNext())
				{
					object obj = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rbx_v10 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rbx_v10 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
					GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					UnityEngine.Object.Destroy(obj2, 0f);
				}
				bool flag4 = _spawnedItems == null;
				uICarousel = (UICarousel)(&enumerator2);
				if (!flag4)
				{
					List<GameObject>.Enumerator enumerator3 = default(List<GameObject>.Enumerator);
					while (enumerator3.MoveNext())
					{
						UnityEngine.Object.Destroy(null, 0f);
					}
					uICarousel = (UICarousel)(object)_cachedItems;
					if (_cachedItems != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v8 (VampireSurvivors.UI.UICarousel)+1C]");
						_ = (nint)0 + (nint)1;
						((MonoBehaviour)uICarousel).m_CancellationTokenSource = null;
						if ((nint)((MonoBehaviour)uICarousel).m_CancellationTokenSource > 0)
						{
							Array.Clear((Array)(nint)((UnityEngine.Object)uICarousel).m_CachedPtr, 0, (int)((MonoBehaviour)uICarousel).m_CancellationTokenSource);
						}
						uICarousel = (UICarousel)(object)_slots;
						if (_slots != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v8 (VampireSurvivors.UI.UICarousel)+1C]");
							_ = (nint)0 + (nint)1;
							((MonoBehaviour)uICarousel).m_CancellationTokenSource = null;
							if ((nint)((MonoBehaviour)uICarousel).m_CancellationTokenSource > 0)
							{
								Array.Clear((Array)(nint)((UnityEngine.Object)uICarousel).m_CachedPtr, 0, (int)((MonoBehaviour)uICarousel).m_CancellationTokenSource);
							}
							uICarousel = (UICarousel)(object)_spawnedItems;
							if (_spawnedItems != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v8 (VampireSurvivors.UI.UICarousel)+1C]");
								_ = (nint)0 + (nint)1;
								((MonoBehaviour)uICarousel).m_CancellationTokenSource = null;
								if ((nint)((MonoBehaviour)uICarousel).m_CancellationTokenSource > 0)
								{
									Array.Clear((Array)(nint)((UnityEngine.Object)uICarousel).m_CachedPtr, 0, (int)((MonoBehaviour)uICarousel).m_CancellationTokenSource);
								}
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void MoveNext()
	{
		//IL_0018: Expected O, but got I4
		//IL_034a: Expected O, but got I4
		//IL_057b: Expected O, but got I
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058a: Expected O, but got Unknown
		//IL_0595: Expected O, but got I4
		//IL_059d: Expected I4, but got O
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected I4, but got Unknown
		//IL_05e9: Expected I, but got O
		//IL_03e6: Unsupported input type for neg.
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Expected O, but got Unknown
		//IL_01d9: Expected O, but got I
		//IL_01d9: Expected I4, but got O
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Expected I4, but got Unknown
		//IL_009d: Expected O, but got I
		//IL_009d: Expected I4, but got O
		//IL_0235: Expected O, but got I
		//IL_0235: Expected I4, but got O
		//IL_00f9: Expected O, but got I
		//IL_02cb: Expected O, but got I
		//IL_02cb: Expected I4, but got O
		//IL_02da: Expected I, but got O
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_030e: Expected O, but got I4
		//IL_0186: Expected I, but got O
		//IL_0666->IL04ff: Incompatible stack heights: 1 vs 0
		//IL_06c0->IL04ff: Incompatible stack heights: 2 vs 0
		List<GameObject> spawnedItems = _spawnedItems;
		bool flag = (nint)_spawnedItems < 0;
		UICarousel uICarousel;
		nint num2 = default(nint);
		nint num3 = default(nint);
		if (_spawnedItems != null)
		{
			Transform transform = (Transform)(spawnedItems._size - 1);
			uICarousel = this;
			if (flag)
			{
				goto IL_0325;
			}
			int num = transform + 1;
			IntPtr intPtr = num2;
			GameObject gameObject = default(GameObject);
			Transform t = default(Transform);
			GameObject gameObject2 = default(GameObject);
			GameObject item = default(GameObject);
			GameObject gameObject3 = default(GameObject);
			while (true)
			{
				List<Transform> slots = _slots;
				if (_slots == null)
				{
					break;
				}
				if (num < slots._size)
				{
					if (_spawnedItems == null)
					{
						break;
					}
					_spawnedItems.set_Item((int)transform, (GameObject)(nint)intPtr);
					if ((object)gameObject == null)
					{
						break;
					}
					CarouselItemUI component = gameObject.GetComponent<CarouselItemUI>();
					if (_slots == null)
					{
						break;
					}
					((List<GameObject>)(object)_slots).set_Item(num, (GameObject)(nint)intPtr);
					if ((object)component == null)
					{
						break;
					}
					Tween tween = component.SetTarget(t);
					flag = (nint)_spawnedItems < 0;
					if (_spawnedItems == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					_spawnedItems.set_Item(num, gameObject2);
					num2 = (nint)gameObject2;
					num3 = num;
					uICarousel = (UICarousel)(object)_spawnedItems;
				}
				else
				{
					_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass27_0();
					if (_spawnedItems == null)
					{
						break;
					}
					_spawnedItems.set_Item((int)transform, (GameObject)(nint)intPtr);
					if (CS_0024_003C_003E8__locals3 == null)
					{
						break;
					}
					CS_0024_003C_003E8__locals3.item = item;
					if (_spawnedItems == null)
					{
						break;
					}
					_spawnedItems.set_Item((int)transform, (GameObject)(nint)intPtr);
					if ((object)gameObject3 == null)
					{
						break;
					}
					CarouselItemUI component2 = gameObject3.GetComponent<CarouselItemUI>();
					flag = (nint)component2 < 0;
					if ((object)component2 == null)
					{
						break;
					}
					Tween tween2 = component2.SetTarget(_BottomSlot);
					TweenCallback tweenCallback = delegate
					{
						UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals3.item, 0f);
					};
					((List<GameObject>)(object)tween2).set_Item((int)tweenCallback, (GameObject)0);
					num2 = 0;
					num3 = (nint)tweenCallback;
					uICarousel = (UICarousel)(object)tween2;
				}
				num--;
				transform = (Transform)(transform - 1);
				object obj = !flag;
				intPtr = num2;
				if (obj != null)
				{
					continue;
				}
				goto IL_0325;
			}
		}
		goto IL_04ff;
		IL_04ff:
		throw new NullReferenceException();
		IL_0325:
		int currentIndex = _currentIndex - 1;
		_currentIndex = currentIndex;
		object obj2 = !flag;
		if (obj2 == null)
		{
			List<GameObject> cachedItems = _cachedItems;
			flag = (nint)_cachedItems < 0;
			if (_cachedItems == null)
			{
				goto IL_04ff;
			}
			int currentIndex2 = cachedItems._size - 1;
			_currentIndex = currentIndex2;
		}
		((List<GameObject>)(object)uICarousel).set_Item((int)num3, (GameObject)num2);
		object obj3 = default(object);
		CarouselItemUI carouselItemUI = (CarouselItemUI)(_currentIndex - obj3);
		object obj4 = !flag;
		int spawnIndex = (int)carouselItemUI;
		if (obj4 == null)
		{
			List<GameObject> cachedItems2 = _cachedItems;
			if (_cachedItems == null)
			{
				goto IL_04ff;
			}
			nint num4 = (nint)typeof(Math);
			CarouselItemUI carouselItemUI2 = (CarouselItemUI)(0 - carouselItemUI);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rcx_v102 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 < (nint)0)
			{
				carouselItemUI2 = carouselItemUI;
			}
			spawnIndex = cachedItems2._size - carouselItemUI2;
		}
		GameObject gameObject4 = SpawnNewItem(spawnIndex, 0);
		if ((object)gameObject4 != null)
		{
			bool flag2 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr);
			Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			CarouselItemUI topSlot = (CarouselItemUI)(object)_TopSlot;
			if ((object)_TopSlot != null)
			{
				bool flag3 = ((UnityEngine.Object)topSlot).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)topSlot).m_CachedPtr);
				Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				if ((object)transform3 != null)
				{
					bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 ret);
					bool flag5 = (object)transform2 == null;
					bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					bool flag7 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr3 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr);
					Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
					object topSlot2 = _TopSlot;
					bool flag8 = (object)_TopSlot == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1020 @ rbx_v30 (System.Object)+10]");
					bool flag9 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1020 @ rbx_v30 (System.Object)+10]");
					IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
					Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
					bool flag10 = (object)transform5 == null;
					bool flag11 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
					Transform.get_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out ret);
					bool flag12 = (object)transform4 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1159 @ rax_v79 (UnityEngine.Transform)+10]");
					bool flag13 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1159 @ rax_v79 (UnityEngine.Transform)+10]");
					Vector3 value2 = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)0, ref value2);
					CarouselItemUI spawnedItems2 = (CarouselItemUI)(object)_spawnedItems;
					bool flag14 = _spawnedItems == null;
					bool flag15 = (nint)((MonoBehaviour)spawnedItems2).m_CancellationTokenSource <= 0;
					bool flag16 = ((UnityEngine.Object)spawnedItems2).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1462 @ rbx_v33 (VampireSurvivors.CarouselItemUI)+1C]");
					_ = (nint)0 + (nint)1;
					if (this.m_SelectionChanged != null)
					{
						OnSelectionChanged selectionChanged = this.m_SelectionChanged;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1784.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
					return;
				}
			}
		}
		goto IL_04ff;
	}

	public GameObject GetSelectedItem()
	{
		List<GameObject> cachedItems = _cachedItems;
		int currentIndex = _currentIndex;
		if (_currentIndex < cachedItems._size)
		{
			GameObject[] items = cachedItems._items;
			return items[currentIndex];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
	}

	public unsafe void MovePrevious()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_05a7: Expected O, but got I
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Expected O, but got Unknown
		//IL_01c3: Expected O, but got I
		//IL_01c3: Expected I4, but got O
		//IL_038d: Expected I4, but got O
		//IL_0086: Expected O, but got I
		//IL_0086: Expected I4, but got O
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected I4, but got Unknown
		//IL_021f: Expected O, but got I
		//IL_021f: Expected I4, but got O
		//IL_03c5: Expected O, but got Ref
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected I4, but got Unknown
		//IL_00f0: Expected O, but got I
		//IL_02a6: Expected O, but got I
		//IL_02a6: Expected I4, but got O
		//IL_02b5: Expected I, but got O
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected I4, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_017a: Expected I, but got O
		//IL_04b7: Expected O, but got I
		//IL_06a9->IL058c: Incompatible stack heights: 1 vs 0
		List<GameObject> spawnedItems = _spawnedItems;
		bool flag = _spawnedItems == null;
		object obj = null;
		object obj2 = null;
		if (!flag)
		{
			nint num = default(nint);
			GameObject gameObject = default(GameObject);
			Transform t = default(Transform);
			GameObject gameObject2 = default(GameObject);
			nint num3 = default(nint);
			GameObject item = default(GameObject);
			GameObject gameObject3 = default(GameObject);
			object obj4 = default(object);
			Vector3 value = default(Vector3);
			Vector3 value2 = default(Vector3);
			while (true)
			{
				if ((nint)obj2 < spawnedItems._size)
				{
					object obj3 = obj - 1;
					if ((nint)obj3 >= 0)
					{
						if (_spawnedItems == null)
						{
							break;
						}
						_spawnedItems.set_Item((int)obj, (GameObject)num);
						if ((object)gameObject == null)
						{
							break;
						}
						CarouselItemUI component = gameObject.GetComponent<CarouselItemUI>();
						if (_slots == null)
						{
							break;
						}
						int index = obj - 1;
						((List<GameObject>)(object)_slots).set_Item(index, (GameObject)num);
						if ((object)component == null)
						{
							break;
						}
						Tween tween = component.SetTarget(t);
						if (_spawnedItems == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						int num2 = obj - 1;
						_spawnedItems.set_Item(num2, gameObject2);
						num = (nint)gameObject2;
						num3 = num2;
					}
					else
					{
						_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass29_0();
						if (_spawnedItems == null)
						{
							break;
						}
						_spawnedItems.set_Item((int)obj, (GameObject)num);
						if (CS_0024_003C_003E8__locals3 == null)
						{
							break;
						}
						CS_0024_003C_003E8__locals3.item = item;
						if (_spawnedItems == null)
						{
							break;
						}
						_spawnedItems.set_Item((int)obj, (GameObject)num);
						if ((object)gameObject3 == null)
						{
							break;
						}
						CarouselItemUI component2 = gameObject3.GetComponent<CarouselItemUI>();
						if ((object)component2 == null)
						{
							break;
						}
						Tween tween2 = component2.SetTarget(_TopSlot);
						TweenCallback tweenCallback = delegate
						{
							UnityEngine.Object.Destroy(CS_0024_003C_003E8__locals3.item, 0f);
						};
						((List<GameObject>)(object)tween2).set_Item((int)tweenCallback, (GameObject)0);
						num = 0;
						num3 = (nint)tweenCallback;
					}
					spawnedItems = _spawnedItems;
					obj++;
					if (_spawnedItems == null)
					{
						break;
					}
					obj2 = obj;
					continue;
				}
				List<GameObject> cachedItems = _cachedItems;
				int num4 = ++_currentIndex;
				if (_cachedItems == null)
				{
					break;
				}
				if (num4 >= cachedItems._size)
				{
					_currentIndex = 0;
				}
				_cachedItems.set_Item((int)num3, (GameObject)num);
				TweenCallback tweenCallback2 = (TweenCallback)(_currentIndex + obj4);
				List<GameObject> cachedItems2 = _cachedItems;
				if (_cachedItems == null)
				{
					break;
				}
				bool flag2 = (nint)tweenCallback2 < cachedItems2._size;
				int num5 = (int)tweenCallback2;
				if (!flag2)
				{
					num5 = tweenCallback2 - cachedItems2._size;
				}
				string text = System.Number.FormatInt32(num5, (ReadOnlySpan<char>)(&value), null);
				string message = "Index to spawn : " + text;
				Debug.Log(message);
				List<Transform> slots = _slots;
				if (_slots == null)
				{
					break;
				}
				int slotIndex = slots._size - 1;
				GameObject gameObject4 = SpawnNewItem(num5, slotIndex);
				if ((object)gameObject4 == null)
				{
					break;
				}
				if (((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(gameObject4);
					break;
				}
				IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				object bottomSlot = _BottomSlot;
				if ((object)_BottomSlot == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v25 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v25 (System.Object)+10]");
				IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				if ((object)transform2 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v73 (UnityEngine.Transform)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v73 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
				bool flag5 = (object)transform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v68 (UnityEngine.Transform)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v68 (UnityEngine.Transform)+10]");
				Transform.set_position_Injected((IntPtr)0, ref value2);
				bool flag7 = ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr3 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject4).m_CachedPtr);
				Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
				object bottomSlot2 = _BottomSlot;
				bool flag8 = (object)_BottomSlot == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ rbx_v29 (System.Object)+10]");
				bool flag9 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ rbx_v29 (System.Object)+10]");
				IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
				Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
				bool flag10 = (object)transform4 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v93 (UnityEngine.Transform)+10]");
				bool flag11 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v93 (UnityEngine.Transform)+10]");
				Transform.get_localScale_Injected((IntPtr)0, out ret);
				bool flag12 = (object)transform3 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1380 @ rax_v88 (UnityEngine.Transform)+10]");
				bool flag13 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1380 @ rax_v88 (UnityEngine.Transform)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref value);
				TweenCallback spawnedItems2 = (TweenCallback)(object)_spawnedItems;
				bool flag14 = _spawnedItems == null;
				object obj5 = (nint)((Delegate)spawnedItems2).invoke_impl - 1;
				bool flag15 = (nint)obj5 >= (nint)((Delegate)spawnedItems2).invoke_impl;
				bool flag16 = ((Delegate)spawnedItems2).method_ptr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1189 @ rbx_v32 (DG.Tweening.TweenCallback)+1C]");
				_ = (nint)0 + (nint)1;
				if (this.m_SelectionChanged != null)
				{
					OnSelectionChanged selectionChanged = this.m_SelectionChanged;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1823.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void CreateItems()
	{
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected I4, but got Unknown
		//IL_00aa: Invalid comparison between F4 and I4
		//IL_00bc: Expected F4, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_0387: Invalid comparison between F4 and O
		float num = _ItemsToShow * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj = default(object);
		int num2 = _currentIndex - obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A36E3]");
		if ((nint)0 < (nint)0)
		{
			int num3 = _currentIndex;
			bool flag = (nint)obj < 0;
			bool flag2 = (nint)obj <= 0;
			object obj2 = 0;
			num2 = _currentIndex;
			if (!flag2)
			{
				bool flag3;
				do
				{
					num3--;
					object obj3 = !flag;
					if (obj3 == null)
					{
						List<GameObject> cachedItems = _cachedItems;
						num3 = cachedItems._size - 1;
					}
					obj2++;
					object obj4 = obj2 - obj;
					flag = (nint)obj4 < 0;
					flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
					num2 = num3;
				}
				while (flag3);
			}
		}
		bool flag4 = !(_ItemsToShow > 0f);
		float num4 = 0f;
		object obj5 = 0;
		if (flag4)
		{
			return;
		}
		while (true)
		{
			List<GameObject> cachedItems2 = _cachedItems;
			if (num2 >= cachedItems2._size)
			{
				break;
			}
			GameObject[] items = cachedItems2._items;
			GameObject gameObject = UnityEngine.Object.Instantiate(items[num2], _Container);
			CarouselItemUI component = gameObject.GetComponent<CarouselItemUI>();
			component.Initialize(_MaxDistance);
			List<Transform> slots = _slots;
			if ((nint)obj5 >= slots._size)
			{
				break;
			}
			Transform[] items2 = slots._items;
			Tween tween = component.SetTarget(items2[obj5], completeImmediately: true);
			List<object> spawnedItems = (List<object>)(object)_spawnedItems;
			int version = spawnedItems._version + 1;
			spawnedItems._version = version;
			object[] items3 = spawnedItems._items;
			if (spawnedItems._size >= items3.Length)
			{
				spawnedItems.AddWithResize((object)gameObject);
			}
			else
			{
				int size = spawnedItems._size + 1;
				spawnedItems._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			List<GameObject> cachedItems3 = _cachedItems;
			int num5 = num2 + 1;
			num4 = _ItemsToShow;
			obj5++;
			bool flag5 = num5 >= cachedItems3._size;
			num2 = 0;
			if (!flag5)
			{
				num2 = num5;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private GameObject CreateInitialItem(int spawnIndex, int slotIndex)
	{
		List<GameObject> cachedItems = _cachedItems;
		if (spawnIndex < cachedItems._size)
		{
			GameObject[] items = cachedItems._items;
			GameObject gameObject = UnityEngine.Object.Instantiate(items[spawnIndex], _Container);
			CarouselItemUI component = gameObject.GetComponent<CarouselItemUI>();
			component.Initialize(_MaxDistance);
			List<Transform> slots = _slots;
			if (slotIndex < slots._size)
			{
				Transform[] items2 = slots._items;
				Tween tween = component.SetTarget(items2[slotIndex], completeImmediately: true);
				return gameObject;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
	}

	private GameObject SpawnNewItem(int spawnIndex, int slotIndex)
	{
		List<GameObject> cachedItems = _cachedItems;
		if (spawnIndex < cachedItems._size)
		{
			GameObject[] items = cachedItems._items;
			GameObject gameObject = UnityEngine.Object.Instantiate(items[spawnIndex], _Container);
			CarouselItemUI component = gameObject.GetComponent<CarouselItemUI>();
			component.Initialize(_MaxDistance);
			component.Deselect(completeImmediately: true);
			List<Transform> slots = _slots;
			if (slotIndex < slots._size)
			{
				Transform[] items2 = slots._items;
				Tween tween = component.SetTarget(items2[slotIndex]);
				return gameObject;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
	}

	private void CreateSlots2()
	{
		//IL_0011: Invalid comparison between F4 and I4
		//IL_00e8: Expected O, but got I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0107: Invalid comparison between F4 and O
		//IL_0718: Expected I, but got O
		//IL_0738: Expected O, but got I
		//IL_03bd: Expected O, but got I4
		//IL_03d8: Expected O, but got I4
		//IL_04ee: Expected O, but got I4
		//IL_04f8: Invalid comparison between F4 and O
		//IL_0518: Expected O, but got I4
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected O, but got Unknown
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Expected O, but got Unknown
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected O, but got Unknown
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Expected O, but got Unknown
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Expected O, but got Unknown
		//IL_0618: Invalid comparison between F4 and O
		//IL_02a0->IL065a: Incompatible stack heights: 1 vs 0
		//IL_01ae->IL065a: Incompatible stack heights: 1 vs 0
		//IL_02e5->IL065a: Incompatible stack heights: 2 vs 0
		//IL_01f3->IL065a: Incompatible stack heights: 2 vs 0
		//IL_0319->IL065a: Incompatible stack heights: 2 vs 0
		//IL_0227->IL065a: Incompatible stack heights: 2 vs 0
		//IL_08bb->IL065a: Incompatible stack heights: 3 vs 0
		//IL_0750->IL065a: Incompatible stack heights: 3 vs 0
		//IL_07d0->IL065a: Incompatible stack heights: 5 vs 0
		//IL_038b->IL065a: Incompatible stack heights: 6 vs 0
		//IL_0641->IL065a: Incompatible stack heights: 6 vs 0
		//IL_0452->IL065a: Incompatible stack heights: 6 vs 0
		//IL_03fe->IL065a: Incompatible stack heights: 6 vs 0
		//IL_0591->IL065a: Incompatible stack heights: 6 vs 0
		//IL_0489->IL065a: Incompatible stack heights: 6 vs 0
		//IL_053d->IL065a: Incompatible stack heights: 6 vs 0
		//IL_0428->IL065a: Incompatible stack heights: 6 vs 0
		//IL_05d6->IL065a: Incompatible stack heights: 6 vs 0
		//IL_0567->IL065a: Incompatible stack heights: 6 vs 0
		//IL_0809->IL065a: Incompatible stack heights: 6 vs 0
		//IL_086b->IL065a: Incompatible stack heights: 6 vs 0
		List<Transform> slots = new List<Transform>();
		_slots = slots;
		bool flag = !(_ItemsToShow > 0f);
		object obj = null;
		if (flag)
		{
			goto IL_011b;
		}
		while (true)
		{
			List<object> slots2 = (List<object>)(object)_slots;
			if (_slots == null)
			{
				break;
			}
			int version = slots2._version + 1;
			slots2._version = version;
			object[] items = slots2._items;
			if (slots2._items == null)
			{
				break;
			}
			if (slots2._size >= items.Length)
			{
				((List<object>)(object)_slots).AddWithResize((object)null);
			}
			else
			{
				int size = slots2._size + 1;
				slots2._size = size;
				((List<Transform>)(object)slots2._items).AddWithResize((Transform)slots2._size);
			}
			obj++;
			float itemsToShow = _ItemsToShow;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)itemsToShow) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				continue;
			}
			goto IL_011b;
		}
		goto IL_065a;
		IL_0899:
		GameObject gameObject = CreateSlot2();
		Vector2 ret;
		Vector2 vector = default(Vector2);
		object obj4;
		if ((object)gameObject != null)
		{
			RectTransform component = gameObject.GetComponent<RectTransform>();
			nint num = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rdx_v30 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ r8_v20 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
			object obj2 = 0;
			if ((object)component != null)
			{
				bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				RectTransform.set_anchoredPosition_Injected(((UnityEngine.Object)component).m_CachedPtr, ref ret);
				RectTransform slots3 = (RectTransform)(object)_slots;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rax_v40 (UnityEngine.GameObject)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rax_v40 (UnityEngine.GameObject)+10]");
				IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				if (_slots != null)
				{
					int midIndex = _midIndex;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rsi_v14 (UnityEngine.RectTransform)+18]");
					bool flag4 = (nint)midIndex >= (nint)0;
					if (((UnityEngine.Object)slots3).m_CachedPtr != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rsi_v14 (UnityEngine.RectTransform)+1C]");
						_ = (nint)0 + (nint)1;
						RectTransform rectTransform = (RectTransform)(_midIndex - 1);
						bool flag5 = (nint)rectTransform <= -1;
						object obj3 = 1;
						if (flag5)
						{
							goto IL_04de;
						}
						while (true)
						{
							GameObject gameObject2 = CreateSlot2();
							RectTransform component2;
							Vector2 anchoredPosition;
							if (_Axis != CarouselAxis.Y)
							{
								if ((object)gameObject2 == null)
								{
									break;
								}
								component2 = gameObject2.GetComponent<RectTransform>();
								if ((object)component2 == null)
								{
									break;
								}
								anchoredPosition = vector;
							}
							else
							{
								if ((object)gameObject2 == null)
								{
									break;
								}
								component2 = gameObject2.GetComponent<RectTransform>();
								obj2 = obj3 * obj4;
								if ((object)component2 == null)
								{
									break;
								}
								anchoredPosition = vector;
							}
							component2.anchoredPosition = anchoredPosition;
							Transform transform2 = gameObject2.transform;
							if (_slots == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F8B0");
							obj3++;
							rectTransform = (RectTransform)(rectTransform - 1);
							if ((nint)rectTransform > -1)
							{
								continue;
							}
							goto IL_04de;
						}
					}
				}
			}
		}
		goto IL_065a;
		IL_065a:
		throw new NullReferenceException();
		IL_062c:
		ApplyScales();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 993 Invalid \"Jump target not found in method: 0x186DFA530\"");
		goto IL_065a;
		IL_04de:
		RectTransform rectTransform2 = (RectTransform)(_midIndex + 1);
		float itemsToShow2 = _ItemsToShow;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)itemsToShow2) <= System.Runtime.CompilerServices.Unsafe.As<RectTransform, UIntPtr>(ref rectTransform2))
		{
			goto IL_062c;
		}
		object obj5 = 1;
		RectTransform rectTransform3 = rectTransform2;
		while (true)
		{
			GameObject gameObject3 = CreateSlot2();
			RectTransform component3;
			Vector2 anchoredPosition2;
			if (_Axis != CarouselAxis.Y)
			{
				if ((object)gameObject3 == null)
				{
					break;
				}
				component3 = gameObject3.GetComponent<RectTransform>();
				if ((object)component3 == null)
				{
					break;
				}
				anchoredPosition2 = vector;
			}
			else
			{
				if ((object)gameObject3 == null)
				{
					break;
				}
				component3 = gameObject3.GetComponent<RectTransform>();
				object obj6 = obj5 * obj4;
				rectTransform3 = (RectTransform)(obj6 ^ -0f);
				if ((object)component3 == null)
				{
					break;
				}
				anchoredPosition2 = vector;
			}
			component3.anchoredPosition = anchoredPosition2;
			Transform transform3 = gameObject3.transform;
			if (_slots == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F8B0");
			rectTransform2 = (RectTransform)(rectTransform2 + 1);
			obj5++;
			float itemsToShow3 = _ItemsToShow;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)itemsToShow3) > System.Runtime.CompilerServices.Unsafe.As<RectTransform, UIntPtr>(ref rectTransform2))
			{
				continue;
			}
			goto IL_062c;
		}
		goto IL_065a;
		IL_011b:
		bool flag6 = _Axis == CarouselAxis.Y;
		List<GameObject> cachedItems = _cachedItems;
		bool num3;
		bool num4;
		bool num5;
		if (!flag6)
		{
			if (_cachedItems != null)
			{
				bool flag7 = cachedItems._size <= 0;
				num3 = flag7;
				GameObject[] items2 = cachedItems._items;
				if (cachedItems._items != null)
				{
					bool flag8 = items2.Length <= 0;
					num4 = flag8;
					if ((object)items2[0] != null)
					{
						RectTransform component4 = items2[0].GetComponent<RectTransform>();
						if ((object)component4 != null)
						{
							bool flag9 = ((UnityEngine.Object)component4).m_CachedPtr == (IntPtr)0;
							num5 = flag9;
							RectTransform.get_sizeDelta_Injected(((UnityEngine.Object)component4).m_CachedPtr, out ret);
							obj4 = ret;
							goto IL_0899;
						}
					}
				}
			}
		}
		else if (_cachedItems != null)
		{
			bool flag10 = cachedItems._size <= 0;
			num3 = flag10;
			GameObject[] items3 = cachedItems._items;
			if (cachedItems._items != null)
			{
				bool flag11 = items3.Length <= 0;
				num4 = flag11;
				if ((object)items3[0] != null)
				{
					RectTransform component5 = items3[0].GetComponent<RectTransform>();
					if ((object)component5 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v78 (UnityEngine.RectTransform)+10]");
						bool flag12 = (nint)0 == 0;
						num5 = flag12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v78 (UnityEngine.RectTransform)+10]");
						RectTransform.get_sizeDelta_Injected((IntPtr)0, out ret);
						object obj7 = default(object);
						obj4 = obj7;
						goto IL_0899;
					}
				}
			}
		}
		goto IL_065a;
	}

	private void ApplyScales()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0260: Invalid comparison between I4 and F4
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_01bc: Expected F4, but got I4
		//IL_029a: Invalid comparison between I4 and F4
		//IL_01f8: Expected F4, but got I4
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_008f->IL0210: Incompatible stack heights: 1 vs 0
		//IL_00b5->IL0210: Incompatible stack heights: 1 vs 0
		//IL_00ed->IL0210: Incompatible stack heights: 1 vs 0
		//IL_02fb->IL0210: Incompatible stack heights: 2 vs 0
		//IL_020f->IL0300: Incompatible stack heights: 2 vs 0
		List<Transform> slots = _slots;
		float num = _size * 0.5f;
		if (_slots != null)
		{
			object obj = 0;
			object obj2 = 0;
			object obj5 = default(object);
			Vector3 value = default(Vector3);
			while (true)
			{
				if ((nint)obj2 >= slots._size)
				{
					return;
				}
				List<Transform> slots2 = _slots;
				if (_slots == null)
				{
					break;
				}
				bool flag = (nint)obj >= slots2._size;
				Transform[] items = slots2._items;
				if (slots2._items == null || (object)items[obj] == null)
				{
					break;
				}
				RectTransform component = items[obj].GetComponent<RectTransform>();
				if ((object)component == null)
				{
					break;
				}
				float num2;
				if (_Axis != CarouselAxis.Y)
				{
					Vector2 anchoredPosition = component.anchoredPosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj3 = anchoredPosition & 0;
					num2 = (float)obj3 / num;
				}
				else
				{
					Vector2 anchoredPosition2 = component.anchoredPosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj4 = obj5 & 0;
					float num3 = (float)obj4 / num;
					num2 = num3;
				}
				if (!(0f > num2))
				{
					if (num2 > 1f)
					{
						num2 = 1f;
					}
				}
				else
				{
					num2 = 0f;
				}
				Vector3 localScale = component.localScale;
				float num4 = 1f - num2;
				if (!(0f > num4))
				{
					if (num4 > 1f)
					{
						num4 = 1f;
					}
				}
				else
				{
					num4 = 0f;
				}
				bool flag2 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)component).m_CachedPtr, ref value);
				slots = _slots;
				obj++;
				if (_slots == null)
				{
					break;
				}
				obj2 = obj;
			}
		}
		throw new NullReferenceException();
	}

	private void ApplyPositions()
	{
		//IL_0228: Expected O, but got I4
		//IL_0107: Expected O, but got I4
		//IL_0111: Invalid comparison between F4 and O
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		//IL_0306: Invalid comparison between F4 and O
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		if (_Axis != CarouselAxis.Y)
		{
		}
		object obj = _midIndex - 1;
		if ((nint)obj <= -1)
		{
			goto IL_00f7;
		}
		Vector2 vector = default(Vector2);
		while (true)
		{
			List<Transform> slots = _slots;
			if ((nint)obj >= slots._size)
			{
				break;
			}
			Transform[] items = slots._items;
			RectTransform component = items[obj].GetComponent<RectTransform>();
			if (_Axis != CarouselAxis.Y)
			{
				Transform transform = component.transform;
				Vector3 localScale = transform.localScale;
			}
			else
			{
				Transform transform2 = component.transform;
				Vector3 localScale2 = transform2.localScale;
			}
			Vector2 anchoredPosition = ((_Axis == CarouselAxis.Y) ? vector : vector);
			component.anchoredPosition = anchoredPosition;
			obj--;
			if ((nint)obj > -1)
			{
				continue;
			}
			goto IL_00f7;
		}
		goto IL_0249;
		IL_0249:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_00f7:
		object obj2 = _midIndex + 1;
		float itemsToShow = _ItemsToShow;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)itemsToShow) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			return;
		}
		while (true)
		{
			List<Transform> slots2 = _slots;
			if ((nint)obj2 >= slots2._size)
			{
				break;
			}
			Transform[] items2 = slots2._items;
			RectTransform component2 = items2[obj2].GetComponent<RectTransform>();
			if (_Axis != CarouselAxis.Y)
			{
				Transform transform3 = component2.transform;
				Vector3 localScale3 = transform3.localScale;
			}
			else
			{
				Transform transform4 = component2.transform;
				Vector3 localScale4 = transform4.localScale;
			}
			Vector2 anchoredPosition2 = ((_Axis == CarouselAxis.Y) ? vector : vector);
			component2.anchoredPosition = anchoredPosition2;
			obj2++;
			float itemsToShow2 = _ItemsToShow;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)itemsToShow2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				return;
			}
		}
		goto IL_0249;
	}

	private unsafe void AdjustMask()
	{
		//IL_0018: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		//IL_02ea->IL057a: Incompatible stack heights: 15 vs 13
		List<GameObject> spawnedItems = _spawnedItems;
		object obj = spawnedItems._size - 1;
		bool flag = (nint)obj >= spawnedItems._size;
		GameObject[] items = spawnedItems._items;
		object obj2 = spawnedItems._size - 1;
		RectTransform component = items[obj2].GetComponent<RectTransform>();
		List<GameObject> spawnedItems2 = _spawnedItems;
		bool flag2 = spawnedItems2._size <= 0;
		GameObject[] items2 = spawnedItems2._items;
		RectTransform component2 = items2[0].GetComponent<RectTransform>();
		bool num;
		Vector3 ret;
		bool num2;
		if (_Axis != CarouselAxis.Y)
		{
			Vector2 anchoredPosition = component.anchoredPosition;
			Vector2 sizeDelta = component.sizeDelta;
			Transform transform = component.transform;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			num = flag3;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
			Vector2 anchoredPosition2 = component2.anchoredPosition;
			Vector2 sizeDelta2 = component2.sizeDelta;
			Transform transform2 = component2.transform;
			bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			num2 = flag4;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
		}
		else
		{
			Vector2 anchoredPosition3 = component.anchoredPosition;
			Vector2 sizeDelta3 = component.sizeDelta;
			Transform transform3 = component.transform;
			bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			num = flag5;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
			Vector2 anchoredPosition4 = component2.anchoredPosition;
			Vector2 sizeDelta4 = component2.sizeDelta;
			Transform transform4 = component2.transform;
			bool flag6 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
			num2 = flag6;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
		}
		Vector2 vector = default(Vector2);
		Vector2 sizeDelta5 = ((_Axis == CarouselAxis.Y) ? vector : vector);
		_Container.sizeDelta = sizeDelta5;
		Vector2 sizeDelta6 = component.sizeDelta;
		_TopSlot.sizeDelta = sizeDelta6;
		Vector2 sizeDelta7 = component2.sizeDelta;
		_BottomSlot.sizeDelta = sizeDelta7;
		Transform transform5 = _TopSlot.transform;
		Transform transform6 = component.transform;
		bool flag7 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out ret);
		bool flag8 = (object)transform5 == null;
		bool flag9 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
		List<GameObject> value = default(List<GameObject>);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)(&value));
		bool flag10 = (object)_BottomSlot == null;
		Transform transform7 = _BottomSlot.transform;
		Transform transform8 = component2.transform;
		bool flag11 = (object)transform8 == null;
		bool flag12 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)transform8).m_CachedPtr, out ret);
		bool flag13 = (object)transform7 == null;
		bool flag14 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref value2);
		bool flag15 = _spawnedItems == null;
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		while (enumerator.MoveNext())
		{
			Transform transform9 = null;
			bool flag16 = ((UnityEngine.Object)transform9).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)transform9).m_CachedPtr);
			Transform transform10 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag17 = (object)transform10 == null;
			transform10.SetParent(_Container, worldPositionStays: true);
		}
	}

	private GameObject CreateSlot2()
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
		Transform transform = gameObject.transform;
		Transform parent = base.transform;
		transform.SetParent(parent, worldPositionStays: true);
		Transform transform2 = gameObject.transform;
		bool flag = (object)transform2 == null;
		bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		return gameObject;
	}

	private GameObject GetNextItem()
	{
		List<GameObject> cachedItems = _cachedItems;
		if (++_currentIndex >= cachedItems._size)
		{
			_currentIndex = 0;
		}
		int currentIndex = _currentIndex;
		if (_currentIndex < cachedItems._size)
		{
			GameObject[] items = cachedItems._items;
			return items[currentIndex];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
	}

	private GameObject GetPreviousItem()
	{
		int currentIndex = _currentIndex - 1;
		_currentIndex = currentIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A36EC]");
		if ((nint)0 < (nint)0)
		{
			List<GameObject> cachedItems = _cachedItems;
			int currentIndex2 = cachedItems._size - 1;
			_currentIndex = currentIndex2;
		}
		List<GameObject> cachedItems2 = _cachedItems;
		int currentIndex3 = _currentIndex;
		if (_currentIndex < cachedItems2._size)
		{
			GameObject[] items = cachedItems2._items;
			return items[currentIndex3];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
	}

	private GameObject GetCurrentItem()
	{
		List<GameObject> cachedItems = _cachedItems;
		int currentIndex = _currentIndex;
		if (_currentIndex < cachedItems._size)
		{
			GameObject[] items = cachedItems._items;
			return items[currentIndex];
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
	}

	public UICarousel()
	{
		List<GameObject> cachedItems = new List<GameObject>();
		_cachedItems = cachedItems;
		List<Transform> slots = new List<Transform>();
		_slots = slots;
		List<GameObject> spawnedItems = new List<GameObject>();
		_spawnedItems = spawnedItems;
	}
}
