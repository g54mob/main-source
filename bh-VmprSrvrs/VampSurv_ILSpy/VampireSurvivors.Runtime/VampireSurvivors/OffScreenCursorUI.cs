using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Objects;
using VampireSurvivors.Signals;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class OffScreenCursorUI : MonoBehaviour
{
	private sealed class _003CDoLateUpdate_003Ed__15(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public OffScreenCursorUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0028: Expected I4, but got I8
			//IL_005e: Expected I4, but got I8
			//IL_00a6: Expected O, but got I4
			//IL_00ba: Expected F4, but got I4
			//IL_05d7: Expected O, but got F4
			//IL_05f5: Expected O, but got F4
			//IL_06ee: Invalid comparison between O and F4
			//IL_06fe: Expected O, but got I4
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Expected O, but got Unknown
			//IL_0216: Expected O, but got I
			//IL_0184: Invalid comparison between O and F4
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Expected O, but got Unknown
			//IL_01f4: Expected O, but got I4
			//IL_0818: Expected O, but got Ref
			//IL_0818: Expected O, but got Ref
			//IL_0767: Expected O, but got Ref
			//IL_0767: Expected O, but got Ref
			//IL_08b9: Expected O, but got F4
			//IL_085b: Expected O, but got F4
			//IL_07aa: Expected O, but got F4
			//IL_07f4->IL053c: Incompatible stack heights: 2 vs 0
			//IL_03d6->IL07d3: Incompatible stack heights: 14 vs 2
			//IL_08c1->IL07d3: Incompatible stack heights: 15 vs 2
			//IL_0863->IL07d3: Incompatible stack heights: 15 vs 2
			//IL_07b2->IL07d3: Incompatible stack heights: 17 vs 2
			OffScreenCursorUI offScreenCursorUI = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				bool flag2 = offScreenCursorUI._spawnedCursors == null;
				Vector2 vector = (Vector2)2;
				Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
				Vector2 position = default(Vector2);
				Vector2 screenPoint = default(Vector2);
				object obj2 = default(object);
				Vector2 vector2 = default(Vector2);
				float num2 = default(float);
				object obj3 = default(object);
				Vector3 screenPosition = default(Vector3);
				float angle = default(float);
				Vector3 vector3 = default(Vector3);
				Vector3 vector4 = default(Vector3);
				float value = default(float);
				Vector3 screenPosition2 = default(Vector3);
				Vector3 vector5 = default(Vector3);
				Vector3 vector6 = default(Vector3);
				float value2 = default(float);
				float value3 = default(float);
				while (enumerator.MoveNext())
				{
					float num = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
					object obj = null;
					object cam = offScreenCursorUI._cam;
					bool flag3 = 0 == 0;
					bool flag4 = ((UnityEngine.Object)num).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)num).m_CachedPtr);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					bool flag5 = (object)transform == null;
					bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector2 ret;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					bool flag7 = (object)offScreenCursorUI._cam == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1053 @ r15_v7 (System.Object)+10]");
					bool flag8 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1053 @ r15_v7 (System.Object)+10]");
					Camera.WorldToScreenPoint_Injected((IntPtr)0, ref *(Vector3*)(&position), Camera.MonoOrStereoscopicEye.Mono, out Vector3 _);
					bool flag9 = RectTransformUtility.ScreenPointToLocalPointInRectangle(offScreenCursorUI._CanvasRect, screenPoint, offScreenCursorUI._cam, out var localPoint);
					Transform canvasRect = offScreenCursorUI._CanvasRect;
					bool flag10 = (object)offScreenCursorUI._CanvasRect == null;
					bool flag11 = ((UnityEngine.Object)canvasRect).m_CachedPtr == (IntPtr)0;
					float ret3;
					RectTransform.get_rect_Injected(((UnityEngine.Object)canvasRect).m_CachedPtr, out *(Rect*)(&ret3));
					bool flag12 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref localPoint) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)ret3);
					vector = (Vector2)0;
					object obj5;
					if (!flag12)
					{
						vector = (Vector2)(obj2 + ret3);
						if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref localPoint) && System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
						{
							vector = (Vector2)(obj3 + num2);
							bool flag13 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) < System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2);
							object obj4 = vector - vector2;
							bool flag14 = obj4 == null;
							bool flag15 = !flag13;
							bool flag16 = !flag14;
							obj5 = flag16 & flag15;
							goto IL_070d;
						}
					}
					obj5 = null;
					goto IL_070d;
					IL_070d:
					bool flag17 = 0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ rsi_v7 (System.Object)+40]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ rsi_v7 (System.Object)+40]");
					bool flag18 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2598 @ rcx_v36+48]");
					Vector2 localPoint2;
					if ((nint)0 == 0)
					{
						if (obj5 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ rsi_v7 (System.Object)+10]");
							bool flag19 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ rsi_v7 (System.Object)+10]");
							IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
							GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
							bool flag20 = (object)gameObject == null;
							gameObject.SetActive(value: true);
							RectTransform component = ((Component)null).GetComponent<RectTransform>();
							GetArrowIndicatorPositionAndAngle(ref screenPosition, ref angle, (Vector3)(&vector3), (Vector3)(&vector4));
							bool flag21 = RectTransformUtility.ScreenPointToLocalPointInRectangle(offScreenCursorUI._CanvasRect, screenPoint, offScreenCursorUI._cam, out localPoint2);
							bool flag22 = (object)component == null;
							component.anchoredPosition = localPoint2;
							Transform transform2 = component.transform;
							float z = angle * 57.29578f;
							Quaternion quaternion = Quaternion.Euler(0f, 0f, z);
							bool flag23 = (object)transform2 == null;
							bool flag24 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Quaternion*)(&value));
							vector = (Vector2)quaternion.x;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ rsi_v7 (System.Object)+10]");
							bool flag25 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ rsi_v7 (System.Object)+10]");
							IntPtr gcHandlePtr3 = Component.get_gameObject_Injected((IntPtr)0);
							GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
							bool flag26 = (object)gameObject2 == null;
							gameObject2.SetActive(value: false);
						}
					}
					else if (obj5 == null)
					{
						RectTransform component2 = ((Component)null).GetComponent<RectTransform>();
						GetArrowIndicatorPositionAndAngle(ref screenPosition2, ref angle, (Vector3)(&vector5), (Vector3)(&vector6));
						bool flag27 = RectTransformUtility.ScreenPointToLocalPointInRectangle(offScreenCursorUI._CanvasRect, screenPoint, offScreenCursorUI._cam, out localPoint2);
						bool flag28 = (object)component2 == null;
						component2.anchoredPosition = localPoint2;
						Transform transform3 = component2.transform;
						float z = angle * 57.29578f;
						Quaternion quaternion2 = Quaternion.Euler(0f, 0f, z);
						bool flag29 = (object)transform3 == null;
						bool flag30 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Transform.set_rotation_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Quaternion*)(&value2));
						vector = (Vector2)quaternion2.x;
					}
					else
					{
						RectTransform component3 = ((Component)null).GetComponent<RectTransform>();
						bool flag31 = RectTransformUtility.ScreenPointToLocalPointInRectangle(offScreenCursorUI._CanvasRect, screenPoint, offScreenCursorUI._cam, out var localPoint3);
						bool flag32 = (object)component3 == null;
						component3.anchoredPosition = localPoint3;
						Transform transform4 = component3.transform;
						Quaternion quaternion3 = Quaternion.Euler(0f, 0f, -90f);
						bool flag33 = (object)transform4 == null;
						bool flag34 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
						Transform.set_rotation_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Quaternion*)(&value3));
						float z = -90f;
						vector = (Vector2)quaternion3.x;
					}
				}
			}
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			_003C_003E2__current = waitForEndOfFrame;
			_003C_003E1__state = 1;
			return true;
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

	private GameObject _CursorPrefab;

	private RectTransform _CanvasRect;

	private float _ScreenBoundsOffset = 0.9f;

	private readonly Dictionary<GameObject, OffScreenCursor> _spawnedCursors;

	private SignalBus _signalBus;

	private GameManager _gameManager;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private Camera _cam;

	private Vector3 _screenCenter;

	private Vector3 _screenBounds;

	private void Construct(SignalBus signal, GameManager gameManager, DataManager data, PlayerOptions player)
	{
		_signalBus = signal;
		_gameManager = gameManager;
		_data = data;
		PlayerOptions playerOptions = default(PlayerOptions);
		_playerOptions = playerOptions;
	}

	private void Start()
	{
		//IL_0035: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		Camera main = Camera.main;
		_cam = main;
		object obj = Screen.width;
		object obj2 = Screen.height;
		Vector3 vector = default(Vector3);
		_screenCenter = vector;
		_ = 0;
		float num = 0f * _ScreenBoundsOffset;
		_screenBounds = vector;
		_003CDoLateUpdate_003Ed__15 obj3 = null;
		obj3._003C_003E1__state = 0;
		obj3._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj3);
	}

	private void OnDestroy()
	{
	}

	public unsafe static void GetArrowIndicatorPositionAndAngle(ref Vector3 screenPosition, ref float angle, Vector3 screenCentre, Vector3 screenBounds)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0052: Expected Ref, but got F4
		//IL_014e: Expected Ref, but got F4
		//IL_0169: Invalid comparison between I and F4
		//IL_009f: Expected Ref, but got F4
		//IL_0100: Expected Ref, but got F4
		//IL_00c4: Expected O, but got F4
		//IL_01a1: Expected Ref, but got F4
		//IL_00f3: Expected Ref, but got F4
		float num = (float)screenPosition - screenCentre.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [screenPosition @ rcx (UnityEngine.Vector3&)+8]");
		object obj = 0 - screenCentre.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [screenPosition @ rcx (UnityEngine.Vector3&)+4]");
		float num3 = default(float);
		float num2 = 0f - num3;
		ref Vector3 reference = ref *(Vector3*)num3;
		if (0 > (nint)obj)
		{
			num2 *= -1f;
			float num4 = (float)obj * -1f;
			reference = ref *(Vector3*)num3;
			num = num3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [screenPosition @ rcx (UnityEngine.Vector3&)+4]");
		ref float reference2 = ref *(float*)null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B745E0");
		if ((nint)screenPosition <= 0)
		{
		}
		reference = ref *(Vector3*)num3;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [screenPosition @ rcx (UnityEngine.Vector3&)+4]");
		if (!(0f > screenBounds.y))
		{
			object obj2 = screenBounds.y ^ -0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [screenPosition @ rcx (UnityEngine.Vector3&)+4]");
			if ((nint)obj2 <= 0)
			{
				goto IL_017d;
			}
			reference = ref *(Vector3*)num3;
		}
		else
		{
			reference = ref *(Vector3*)num3;
		}
		_ = 0;
		goto IL_017d;
		IL_017d:
		float num5 = screenCentre.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [screenPosition @ rcx (UnityEngine.Vector3&)+8]");
		float num6 = num5 + 0f;
		reference = ref *(Vector3*)num3;
	}

	private IEnumerator DoLateUpdate()
	{
		_003CDoLateUpdate_003Ed__15 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private bool CheckIfInScreenBounds(Vector2 pos)
	{
		RectTransform canvasRect = _CanvasRect;
		bool flag = ((UnityEngine.Object)canvasRect).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)canvasRect).m_CachedPtr, out Rect ret);
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref pos) >= System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref ret))
		{
			object obj2 = default(object);
			object obj = obj2 + (object)ret;
			object obj3 = default(object);
			object obj4 = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref pos) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				object obj6 = default(object);
				object obj5 = obj6 + obj4;
				bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
				object obj7 = obj5 - obj3;
				bool flag3 = obj7 == null;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
		}
		return false;
	}

	private void SpawnCursor(UISignals.SpawnOffScreenCursorSignal sig)
	{
		Transform parent = base.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(_CursorPrefab, parent);
		CursorData data = sig.Data;
		Sprite cursorSprite = data.CursorSprite;
		if ((object)data.CursorSprite != null && ((UnityEngine.Object)cursorSprite).m_CachedPtr != (IntPtr)0)
		{
			Transform transform = gameObject.transform;
			Transform child = transform.GetChild(1);
			GameObject gameObject2 = child.gameObject;
			gameObject2.SetActive(value: true);
			Transform transform2 = gameObject.transform;
			Transform child2 = transform2.GetChild(1);
			Image component = child2.GetComponent<Image>();
			CursorData data2 = sig.Data;
			component.sprite = data2.CursorSprite;
		}
		OffScreenCursor component2 = gameObject.GetComponent<OffScreenCursor>();
		component2.Init(sig.Data, sig.Target);
		bool flag = ((Dictionary<object, object>)(object)_spawnedCursors).TryInsert((object)sig.Target, (object)component2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	private void RemoveCursor(UISignals.RemoveOffScreenCursorSignal sig)
	{
		int num = _spawnedCursors.FindEntry((GameObject)sig);
		if (num >= 0)
		{
			OffScreenCursor offScreenCursor = _spawnedCursors.get_Item((GameObject)sig);
			GameObject obj = offScreenCursor.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
			bool flag = ((Dictionary<object, object>)(object)_spawnedCursors).Remove((object)sig);
		}
	}

	private unsafe void PositionNearScreenEdge(OffScreenCursor offScreenCursor, Vector3 screenPos)
	{
		//IL_0027: Expected O, but got Ref
		//IL_0027: Expected O, but got Ref
		if ((object)offScreenCursor != null)
		{
			RectTransform component = offScreenCursor.GetComponent<RectTransform>();
			float angle = default(float);
			Vector2 euler = default(Vector2);
			Quaternion ret = default(Quaternion);
			GetArrowIndicatorPositionAndAngle(ref *(Vector3*)screenPos, ref angle, (Vector3)(&euler), (Vector3)(&ret));
			Vector2 screenPoint = default(Vector2);
			bool flag = RectTransformUtility.ScreenPointToLocalPointInRectangle(_CanvasRect, screenPoint, _cam, out var localPoint);
			if ((object)component != null)
			{
				component.anchoredPosition = localPoint;
				Transform transform = component.transform;
				Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out ret);
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)(&localPoint));
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void PointAtTarget(OffScreenCursor offScreenCursor, Vector3 screenPos)
	{
		if ((object)offScreenCursor != null)
		{
			RectTransform component = offScreenCursor.GetComponent<RectTransform>();
			Vector2 screenPoint = default(Vector2);
			bool flag = RectTransformUtility.ScreenPointToLocalPointInRectangle(_CanvasRect, screenPoint, _cam, out var localPoint);
			if ((object)component != null)
			{
				component.anchoredPosition = localPoint;
				Transform transform = component.transform;
				Vector2 euler = default(Vector2);
				Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out Quaternion _);
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Quaternion value = default(Quaternion);
				Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public OffScreenCursorUI()
	{
		Dictionary<GameObject, OffScreenCursor> spawnedCursors = new Dictionary<GameObject, OffScreenCursor>();
		_spawnedCursors = spawnedCursors;
	}
}
