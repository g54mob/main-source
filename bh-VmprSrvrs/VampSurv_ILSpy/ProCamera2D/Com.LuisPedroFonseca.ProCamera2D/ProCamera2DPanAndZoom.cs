using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.EventSystems;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DPanAndZoom : BasePC2D, IPreMover
{
	public enum MouseButton
	{
		Left,
		Right,
		Middle
	}

	private sealed class _003CStart_003Ed__52(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public ProCamera2DPanAndZoom _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0098: Expected I4, but got I8
			//IL_0126: Expected I4, but got O
			//IL_012a: Expected O, but got I4
			//IL_00d4: Expected O, but got I
			BasePC2D basePC2D = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				ProCamera2D proCamera2D = _003C_003E4__this.ProCamera2D;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v20 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				float num = 0f * 0.5f;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				GameObject gameObject = _003C_003E4__this.gameObject;
				Scene scene = gameObject.scene;
				object obj = Scene.GetBuildIndexInternal((int)scene);
				if ((nint)obj == -1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (Com.LuisPedroFonseca.ProCamera2D.BasePC2D)+110]");
					GameObject gameObject2 = ((Component)0).gameObject;
					UnityEngine.Object.DontDestroyOnLoad(gameObject2);
				}
			}
			return false;
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

	public static string ExtensionName = "Pan And Zoom";

	public Action OnPanStarted;

	public Action OnPanFinished;

	public bool AutomaticInputDetection;

	public bool UseMouseInput;

	public bool UseTouchInput;

	public bool DisableOverUGUI;

	public bool AllowZoom;

	public float MouseZoomSpeed;

	public float PinchZoomSpeed;

	public float ZoomSmoothness;

	public float MaxZoomInAmount;

	public float MaxZoomOutAmount;

	public bool ZoomToInputCenter;

	public bool IsZooming;

	private float _zoomAmount;

	private float _initialCamSize;

	private bool _zoomStarted;

	private float _origFollowSmoothnessX;

	private float _origFollowSmoothnessY;

	private float _prevZoomAmount;

	private float _zoomVelocity;

	private Vector3 _zoomPoint;

	private float _touchZoomTime;

	public bool AllowPan;

	public bool UsePanByDrag;

	public float StopSpeedOnDragStart;

	public Rect DraggableAreaRect;

	public Vector2 DragPanSpeedMultiplier;

	public bool UsePanByMoveToEdges;

	public Vector2 EdgesPanSpeed;

	public float TopPanEdge;

	public float BottomPanEdge;

	public float LeftPanEdge;

	public float RightPanEdge;

	public MouseButton PanMouseButton;

	public float MinPanAmount;

	public bool ResetPrevPanPoint;

	public bool IsPanning;

	private Vector2 _panDelta;

	private Transform _panTarget;

	private Vector3 _prevMousePosition;

	private Vector3 _prevTouchPosition;

	private int _prevTouchId;

	private bool _onMaxZoom;

	private bool _onMinZoom;

	private EventSystem _eventSystem;

	private bool _skip;

	private Vector3 _startPanWorldPos;

	private int _prmOrder;

	public int PrMOrder
	{
		get
		{
			return _prmOrder;
		}
		set
		{
			_prmOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (AutomaticInputDetection)
		{
			bool touchSupported = Input.touchSupported;
			bool useMouseInput = (byte)((touchSupported ? 1u : 0u) ^ 1u) != 0;
			UseMouseInput = useMouseInput;
			bool touchSupported2 = Input.touchSupported;
			UseTouchInput = touchSupported2;
		}
		ProCamera2D proCamera2D = base.ProCamera2D;
		_origFollowSmoothnessX = proCamera2D.HorizontalFollowSmoothness;
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		_origFollowSmoothnessY = proCamera2D2.VerticalFollowSmoothness;
		EventSystem current = EventSystem.current;
		_eventSystem = current;
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "PC2DPanTarget");
		Transform panTarget = gameObject.transform;
		_panTarget = panTarget;
		ProCamera2D proCamera2D3 = base.ProCamera2D;
		proCamera2D3.AddPreMover(this);
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._preMovers).Remove((object)this);
		}
	}

	private IEnumerator Start()
	{
		_003CStart_003Ed__52 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected override void OnEnable()
	{
		Enable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v2 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
		float initialCamSize = 0f * 0.5f;
		_initialCamSize = initialCamSize;
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		float duration = default(float);
		Vector2 targetOffset = default(Vector2);
		CameraTarget cameraTarget = proCamera2D2.AddCameraTarget(_panTarget, 1f, 1f, duration, targetOffset);
		CenterPanTargetOnCamera();
	}

	protected override void OnDisable()
	{
		Disable();
		ResetPrevPanPoint = true;
		_onMaxZoom = false;
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.RemoveCameraTarget(_panTarget);
	}

	public unsafe void PreMove(float deltaTime)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0458: Expected O, but got I4
		//IL_0205: Expected I4, but got I8
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected O, but got Unknown
		//IL_03a5: Expected O, but got I4
		//IL_04a3: Expected O, but got I4
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0265: Expected O, but got F4
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_017b: Expected O, but got F4
		//IL_0110: Expected O, but got I4
		//IL_00f4: Expected O, but got I4
		object obj2 = default(object);
		object obj = obj2 - 24;
		float num2 = default(float);
		while (true)
		{
			bool flag = !UseTouchInput;
			float num = deltaTime;
			if (!flag)
			{
				int ret;
				if (_skip = DisableOverUGUI && (bool)_eventSystem)
				{
					_skip = false;
					bool flag2 = false;
					while (true)
					{
						object obj3 = Input.touchCount;
						if ((flag2 ? 1 : 0) >= (nint)obj3)
						{
							break;
						}
						_ = 0;
						_ = 0;
						Input.GetTouch_Injected(flag2 ? 1 : 0, out *(Touch*)(&ret));
						object obj4;
						if (!_eventSystem.IsPointerOverGameObject(ret))
						{
							flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
							obj4 = 0;
							continue;
						}
						_skip = true;
						obj4 = 0;
						break;
					}
				}
				bool flag3 = !_skip;
				num = deltaTime;
				if (!flag3)
				{
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					object obj5 = obj - 104;
					Input.GetTouch_Injected(0, out *(Touch*)obj5);
					_ = 0;
					_ = 0;
					Input.GetTouch_Injected(0, out *(Touch*)(&ret));
					Func<Vector3, float> vector3D = Vector3D;
					ProCamera2D proCamera2D = base.ProCamera2D;
					Vector3 localPosition = proCamera2D.LocalPosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v112 @ rdi_v22 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					float x = localPosition.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj4 = x & 0;
					_prevTouchPosition = (Vector3)num2;
					_zoomAmount = 0f;
					_prevZoomAmount = 0f;
					num = num2;
				}
			}
			if (UseMouseInput && (_skip = DisableOverUGUI && (bool)_eventSystem && _eventSystem.IsPointerOverGameObject(-1)))
			{
				Input.get_mousePosition_Injected(out Vector3 _);
				Input.get_mousePosition_Injected(out Vector3 _);
				Func<Vector3, float> vector3D2 = Vector3D;
				ProCamera2D proCamera2D2 = base.ProCamera2D;
				Vector3 localPosition2 = proCamera2D2.LocalPosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v226 @ rdi_v8 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				float x2 = localPosition2.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				object obj4 = x2 & 0;
				_prevMousePosition = (Vector3)num2;
				_zoomAmount = 0f;
				_prevZoomAmount = 0f;
				num = num2;
			}
			IsZooming = false;
			if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
			{
				object obj6 = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
				if (obj6 != null && AllowPan && !_skip)
				{
					Pan(deltaTime);
					num = deltaTime;
				}
				if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
				{
					break;
				}
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(this);
		}
		object obj7 = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj7 != null && AllowZoom && !_skip)
		{
			Zoom(deltaTime);
		}
	}

	private unsafe void Pan(float deltaTime)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_1d9b: Expected I, but got O
		//IL_1dc4: Expected F4, but got I
		//IL_1f6b: Expected O, but got I
		//IL_2863: Expected I, but got O
		//IL_28a0: Expected O, but got I
		//IL_28d0: Invalid comparison between F4 and O
		//IL_1e04: Expected O, but got F4
		//IL_1e0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e13: Expected O, but got Unknown
		//IL_1e1c: Invalid comparison between F4 and O
		//IL_1fa1: Expected O, but got I4
		//IL_1fca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fcf: Expected O, but got Unknown
		//IL_1504: Expected O, but got Ref
		//IL_151c: Expected F4, but got O
		//IL_0a03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Expected O, but got Unknown
		//IL_1e58: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5d: Expected O, but got Unknown
		//IL_1e6a: Expected I4, but got O
		//IL_2009: Expected O, but got I4
		//IL_0972: Unknown result type (might be due to invalid IL or missing references)
		//IL_0977: Expected O, but got Unknown
		//IL_0981: Expected O, but got F4
		//IL_23dc: Expected O, but got F4
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_0187: Expected O, but got F4
		//IL_2223: Unsupported input type for neg.
		//IL_2223: Unknown result type (might be due to invalid IL or missing references)
		//IL_2228: Expected O, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected F4, but got Unknown
		//IL_227c: Unsupported input type for neg.
		//IL_227c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2281: Expected O, but got Unknown
		//IL_22c2: Invalid comparison between I4 and F4
		//IL_2076: Expected O, but got F4
		//IL_17ba: Expected F4, but got O
		//IL_1162: Expected O, but got F4
		//IL_1080: Invalid comparison between F4 and I4
		//IL_22df: Invalid comparison between I4 and F4
		//IL_11d7: Invalid comparison between F4 and I4
		//IL_1efe: Expected F4, but got O
		//IL_1305: Expected O, but got F4
		//IL_10f0: Invalid comparison between I4 and F4
		//IL_1223: Invalid comparison between F4 and I4
		//IL_11ff: Expected F4, but got I4
		//IL_232b: Expected O, but got F4
		//IL_137a: Invalid comparison between F4 and I4
		//IL_1293: Invalid comparison between I4 and F4
		//IL_13d7: Expected O, but got I
		//IL_13a2: Expected F4, but got I4
		//IL_1886: Unknown result type (might be due to invalid IL or missing references)
		//IL_188b: Expected O, but got Unknown
		//IL_0b5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b62: Expected O, but got Unknown
		//IL_0b9e: Expected F4, but got O
		//IL_0be3: Expected F4, but got O
		//IL_0bf0: Expected I, but got O
		//IL_03e8: Invalid comparison between O and F4
		//IL_0400: Expected I, but got O
		//IL_0d52: Expected I, but got O
		//IL_0d5a: Expected F4, but got I4
		//IL_1f16: Expected O, but got F4
		//IL_1f23: Expected O, but got I4
		//IL_0432: Invalid comparison between F4 and O
		//IL_044d: Expected I, but got O
		//IL_0455: Expected I4, but got F4
		//IL_0d92: Expected I, but got O
		//IL_046b: Invalid comparison between O and F4
		//IL_0483: Expected I, but got O
		//IL_048b: Expected I4, but got F4
		//IL_0da8: Invalid comparison between O and F4
		//IL_0db3: Expected I, but got O
		//IL_04b0: Invalid comparison between F4 and O
		//IL_04ce: Invalid comparison between F4 and I4
		//IL_04f7: Expected O, but got I4
		//IL_0518: Expected I, but got O
		//IL_0520: Expected I4, but got F4
		//IL_0de0: Invalid comparison between F4 and O
		//IL_0dfe: Invalid comparison between F4 and I4
		//IL_0e27: Expected O, but got I4
		//IL_0e3b: Expected I, but got O
		//IL_0538: Expected O, but got F4
		//IL_0559: Expected I, but got O
		//IL_0562: Expected I4, but got F4
		//IL_1cef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf4: Expected O, but got Unknown
		//IL_0e5b: Expected O, but got F4
		//IL_0e6f: Expected I, but got O
		//IL_05cb: Expected O, but got Ref
		//IL_0ee0: Expected O, but got Ref
		//IL_25d6: Expected F4, but got O
		//IL_062f: Expected O, but got Ref
		//IL_0f5e: Expected O, but got Ref
		//IL_086e: Expected O, but got F4
		//IL_0887: Expected I4, but got F4
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Expected O, but got Unknown
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Expected I4, but got Unknown
		//IL_06f0: Invalid comparison between I4 and F4
		//IL_0703: Expected F4, but got O
		//IL_07ed: Expected O, but got Ref
		//IL_1007: Expected O, but got F4
		//IL_074e: Expected F4, but got O
		//IL_075c: Expected I, but got O
		//IL_2430->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_15e7->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_24a6->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_1613->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_1728->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_262b->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_20a2->IL2836: Incompatible stack heights: 1 vs 0
		//IL_1754->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_17f0->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_166c->IL166c: Incompatible stack heights: 1 vs 0
		//IL_1a26->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_2680->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_17ab->IL2435: Incompatible stack heights: 1 vs 0
		//IL_181c->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_1f0b->IL2797: Incompatible stack heights: 1 vs 0
		//IL_1a52->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_1b6a->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_184d->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_2103->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_1b96->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_1c11->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_1aae->IL1aae: Incompatible stack heights: 1 vs 0
		//IL_0b39->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_1bd4->IL1f0b: Incompatible stack heights: 1 vs 0
		//IL_24d9->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_0bb8->IL0bf5: Incompatible stack heights: 1 vs 0
		//IL_0bf5->IL0bf5: Incompatible stack heights: 1 vs 0
		//IL_26d5->IL1d86: Incompatible stack heights: 2 vs 0
		//IL_1c56->IL1d86: Incompatible stack heights: 2 vs 0
		//IL_252e->IL1d86: Incompatible stack heights: 2 vs 0
		//IL_1c82->IL1d86: Incompatible stack heights: 2 vs 0
		//IL_18f4->IL1d86: Incompatible stack heights: 2 vs 0
		//IL_1cb3->IL1d86: Incompatible stack heights: 2 vs 0
		//IL_2583->IL1d86: Incompatible stack heights: 3 vs 0
		//IL_2708->IL1d86: Incompatible stack heights: 2 vs 0
		//IL_1937->IL1d86: Incompatible stack heights: 3 vs 0
		//IL_2757->IL1d86: Incompatible stack heights: 3 vs 0
		//IL_1d49->IL1d86: Incompatible stack heights: 3 vs 0
		//IL_25db->IL2435: Incompatible stack heights: 5 vs 0
		//IL_2797->IL1f0b: Incompatible stack heights: 4 vs 0
		//IL_2211->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_0fd9->IL1d86: Incompatible stack heights: 1 vs 0
		//IL_102c->IL2168: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = obj2 - 232;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		Vector2 zeroVector = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rcx_v287 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		float num3 = 0f;
		_panDelta = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rcx_v287 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		int ret;
		float num4 = default(float);
		if (UseTouchInput)
		{
			object obj3 = Time.time;
			zeroVector -= _touchZoomTime;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f) <= System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref zeroVector))
			{
				if (AllowZoom)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185244A30");
					object obj4 = default(object);
					if ((nint)obj4 == 1)
					{
						goto IL_00cb;
					}
					bool flag = AllowZoom;
					num3 = 0.1f;
					if (flag)
					{
						goto IL_1e30;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185244A30");
				object obj5 = default(object);
				bool flag2 = (nint)obj5 <= 0;
				num3 = 0.1f;
				if (!flag2)
				{
					goto IL_00cb;
				}
				goto IL_1e30;
			}
			object obj6 = Input.touchCount;
			if ((nint)obj6 <= 0)
			{
				return;
			}
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			object obj7 = obj - 56;
			Input.GetTouch_Injected(0, out *(Touch*)obj7);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Input.GetTouch_Injected(0, out *(Touch*)(&ret));
			Camera vector3D = (Camera)(object)Vector3D;
			ProCamera2D proCamera2D = base.ProCamera2D;
			if ((object)proCamera2D != null)
			{
				Vector3 localPosition = proCamera2D.LocalPosition;
				if (Vector3D != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v858.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
					float x = localPosition.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj8 = x & 0;
					_prevTouchPosition = (Vector3)num4;
					return;
				}
			}
			goto IL_1d86;
		}
		goto IL_1f51;
		IL_1f51:
		Vector2 vector = DragPanSpeedMultiplier;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+D8]");
		object obj9 = 0;
		float ret2;
		float ret3;
		float value = default(float);
		float x2;
		if (UseMouseInput)
		{
			Input.get_mousePosition_Injected(out *(Vector3*)(&ret2));
			Input.get_mousePosition_Injected(out *(Vector3*)(&ret3));
			Func<Vector3, float> vector3D2 = Vector3D;
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			if ((object)proCamera2D2 != null)
			{
				Vector3 localPosition2 = proCamera2D2.LocalPosition;
				if (Vector3D != null)
				{
					x2 = localPosition2.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rdi_v61 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
					uint num5 = 0u;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rdi_v61 (System.Func`2<UnityEngine.Vector3, System.Single>)+28]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v661 @ rdi_v61 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					float x3 = localPosition2.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj10 = x3 & 0;
					object obj11 = Input.GetMouseButtonDown((int)PanMouseButton);
					bool flag3 = obj11 == null;
					value = localPosition2.x;
					if (flag3)
					{
						goto IL_2836;
					}
					ProCamera2D proCamera2D3 = base.ProCamera2D;
					if ((object)proCamera2D3 != null)
					{
						Camera gameCamera = proCamera2D3.GameCamera;
						if ((object)proCamera2D3.GameCamera != null)
						{
							bool flag4 = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
							Camera.ScreenToWorldPoint_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr, ref *(Vector3*)(&value), Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)(&ret3));
							_startPanWorldPos = (Vector3)ret3;
							_ = 0;
							value = num4;
							num5 = (uint)(&ret3);
							num6 = 2;
							x2 = ret3;
							goto IL_2836;
						}
					}
				}
			}
			goto IL_1d86;
		}
		goto IL_2855;
		IL_2855:
		nint num7 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rax_v106 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num8 = 0;
		object obj12 = _panDelta - Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+108]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rcx_v104 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		object obj13 = num9 - 0;
		object obj14 = obj13 * obj13;
		object obj15 = obj12 * obj12;
		object obj16 = obj14 + obj15;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16))
		{
			goto IL_152b;
		}
		Func<float, float, Vector3> vectorHV = VectorHV;
		float num13;
		float num14;
		if (VectorHV != null)
		{
			float num10 = (float)obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+108]");
			float num11 = num10 * 0f;
			float num12 = (float)vector * (float)_panDelta;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v665 @ rdx_v128 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
			if ((object)_panTarget != null)
			{
				_panTarget.Translate((Vector3)(&value), Space.Self);
				num13 = num12;
				num14 = num11;
				object obj17 = default(object);
				value = (float)obj17;
				uint num5 = 0u;
				goto IL_152b;
			}
		}
		goto IL_1d86;
		IL_11f6:
		float num15 = 0f;
		float num16;
		num3 = num16;
		goto IL_22d6;
		IL_1399:
		float num17 = 0f;
		float num18;
		num3 = num18;
		goto IL_22f3;
		IL_17b0:
		float num19 = (float)_panTarget;
		object vectorHVD = VectorHVD;
		Camera vector3H = (Camera)(object)Vector3H;
		ProCamera2D proCamera2D4 = base.ProCamera2D;
		if ((object)proCamera2D4 != null)
		{
			Vector3 localPosition3 = proCamera2D4.LocalPosition;
			if (Vector3H != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1426.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
				ProCamera2D proCamera2D5 = base.ProCamera2D;
				if ((object)proCamera2D5 != null)
				{
					float num20;
					if (proCamera2D5.IsRelativeOffset)
					{
						object obj18 = proCamera2D5._003CScreenSizeInWorldCoordinates_003Ek__BackingField * proCamera2D5.OffsetX;
						num20 = (float)obj18 * 0.5f;
					}
					else
					{
						num20 = proCamera2D5.OffsetX;
					}
					object panTarget = _panTarget;
					Func<Vector3, float> vector3V = Vector3V;
					if ((object)_panTarget != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1434 @ rdi_v53 (System.Object)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1434 @ rdi_v53 (System.Object)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret3));
						if (Vector3V != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1183 @ rsi_v49 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
							object panTarget2 = _panTarget;
							Func<Vector3, float> vector3D3 = Vector3D;
							if ((object)_panTarget != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rdi_v54 (System.Object)+10]");
								bool flag6 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1427 @ rdi_v54 (System.Object)+10]");
								Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret3));
								if (Vector3D != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1179 @ rsi_v50 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
									uint num5 = 0u;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1179 @ rsi_v50 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
									if (VectorHVD != null)
									{
										float num21 = num20 * 0.9999f;
										float num22 = localPosition3.x - num21;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1122 @ r13_v41 (System.Object)+18] (should have been resolved before IL gen)");
										bool flag7 = (object)_panTarget == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1131 @ r14_v48 (System.Single)+10]");
										bool flag8 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1131 @ r14_v48 (System.Single)+10]");
										Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
										num13 = num22;
										num14 = ret3;
										object obj19 = default(object);
										value = (float)obj19;
										goto IL_2435;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1d86;
		IL_2435:
		ProCamera2D proCamera2D6 = base.ProCamera2D;
		bool num23;
		if ((object)proCamera2D6 != null)
		{
			if (!proCamera2D6.IsCameraPositionBottomBounded)
			{
				goto IL_1aae;
			}
			object panTarget3 = _panTarget;
			Func<Vector3, float> vector3V2 = Vector3V;
			if ((object)_panTarget != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1429 @ rdi_v49 (System.Object)+10]");
				bool flag9 = (nint)0 == 0;
				num23 = flag9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1429 @ rdi_v49 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret3));
				if (Vector3V != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1181 @ rsi_v47 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					Camera vector3V3 = (Camera)(object)Vector3V;
					ProCamera2D proCamera2D7 = base.ProCamera2D;
					if ((object)proCamera2D7 != null)
					{
						Vector3 localPosition4 = proCamera2D7.LocalPosition;
						if (Vector3V != null)
						{
							uint num5 = vector3V3.m_NonSerializedVersion;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1430.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
							bool flag10 = localPosition4.x > ret3;
							value = localPosition4.x;
							value = localPosition4.x;
							if (!flag10)
							{
								goto IL_1aae;
							}
							goto IL_1bd9;
						}
					}
				}
			}
		}
		goto IL_1d86;
		IL_22d6:
		if (!(0f > num17))
		{
			if (num17 > 0f)
			{
				num18 = TopPanEdge * 0.5f;
				float num24 = num17 - num18;
				float num25 = 0.5f - num18;
				float num26 = num24 / num25;
				num17 = num26 * 0.5f;
				if (0f > num17)
				{
					goto IL_1399;
				}
				bool flag11 = !(num17 > 0.5f);
				num3 = num18;
				if (!flag11)
				{
					num17 = 0.5f;
					num3 = num18;
				}
			}
		}
		else
		{
			float num27 = num17 - -0.5f;
			object obj20 = BottomPanEdge ^ -0f;
			float num28 = (float)obj20 * 0.5f;
			float num29 = num28 - -0.5f;
			float num30 = num27 / num29;
			float num31 = num30 * 0.5f;
			num17 = num31 - 0.5f;
			if (!(-0.5f > num17))
			{
				bool flag12 = !(num17 > 0f);
				num18 = num3;
				if (!flag12)
				{
					goto IL_1399;
				}
			}
			else
			{
				num17 = -0.5f;
			}
		}
		goto IL_22f3;
		IL_22f3:
		float num32 = num15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1+F8]");
		float num33 = num32 * 0f;
		float num34 = num17;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1+F8]");
		float num35 = num34 * 0f;
		_panDelta = (Vector2)num33;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
		float num36 = num33;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1+F0]");
		float num37 = num36 - 0f;
		float num38 = num35;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1+F4]");
		float num39 = num38 - 0f;
		float num40 = num39 * num39;
		float num41 = num37 * num37;
		float num42 = num40 + num41;
		bool flag13 = 9.9999994E-11f > num42;
		num13 = -0.5f;
		num14 = -0f;
		x2 = 9.9999994E-11f;
		if (!flag13)
		{
			vector = EdgesPanSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+E4]");
			obj9 = 0;
			num13 = -0.5f;
			num14 = -0f;
			x2 = 9.9999994E-11f;
		}
		goto IL_2168;
		IL_2836:
		if (!UsePanByDrag || !Input.GetMouseButton((int)PanMouseButton) || IsPanning)
		{
			goto IL_0bf5;
		}
		ProCamera2D proCamera2D8 = base.ProCamera2D;
		if ((object)proCamera2D8 != null)
		{
			object gameCamera2 = proCamera2D8.GameCamera;
			if ((object)proCamera2D8.GameCamera != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1417 @ rdi_v72 (System.Object)+10]");
				bool flag14 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1417 @ rdi_v72 (System.Object)+10]");
				Camera.ScreenToWorldPoint_Injected((IntPtr)0, ref *(Vector3*)(&value), Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)(&ret3));
				ProCamera2D proCamera2D9 = base.ProCamera2D;
				if ((object)proCamera2D9 != null)
				{
					ProCamera2D proCamera2D10 = base.ProCamera2D;
					if ((object)proCamera2D10 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2DA0");
						Vector2 vector2 = proCamera2D9._003CScreenSizeInWorldCoordinates_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2429 @ rax_v321 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
						object obj21 = vector2 + 0;
						float num43 = (float)obj21 * 0.5f;
						x2 = ret3 / num43;
						bool flag15 = !(x2 > MinPanAmount);
						value = (float)_startPanWorldPos;
						uint num5 = (uint)(&ret3);
						nint num6 = 2;
						if (!flag15)
						{
							num3 = StopSpeedOnDragStart;
							CenterPanTargetOnCamera(StopSpeedOnDragStart);
							StartPanning();
							value = (float)_startPanWorldPos;
							num5 = (uint)(&ret3);
							num6 = unchecked((nint)null);
						}
						goto IL_0bf5;
					}
				}
			}
		}
		goto IL_1d86;
		IL_00cb:
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185244A30");
		Camera camera = default(Camera);
		object obj22 = camera - 1;
		Input.GetTouch_Injected((int)obj22, out *(Touch*)(&ret));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-6C]");
		bool flag16 = (nint)0 != 0;
		object obj24 = default(object);
		object obj23 = obj24;
		object obj26 = default(object);
		object obj25 = obj26;
		float num44 = 0.1f;
		if (!flag16)
		{
			_prevTouchId = ret;
			Camera vector3D4 = (Camera)(object)Vector3D;
			ProCamera2D proCamera2D11 = base.ProCamera2D;
			if ((object)proCamera2D11 != null)
			{
				Vector3 localPosition5 = proCamera2D11.LocalPosition;
				if (Vector3D != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1408.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
					float x4 = localPosition5.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj27 = x4 & 0;
					_prevTouchPosition = (Vector3)num4;
					ProCamera2D proCamera2D12 = base.ProCamera2D;
					if ((object)proCamera2D12 != null)
					{
						Camera gameCamera3 = proCamera2D12.GameCamera;
						if ((object)proCamera2D12.GameCamera != null)
						{
							obj23 = obj24;
							obj25 = obj26;
							bool flag17 = ((UnityEngine.Object)gameCamera3).m_CachedPtr == (IntPtr)0;
							Camera.ScreenToWorldPoint_Injected(((UnityEngine.Object)gameCamera3).m_CachedPtr, ref *(Vector3*)(&value), Camera.MonoOrStereoscopicEye.Mono, out Vector3 ret4);
							_startPanWorldPos = ret4;
							_ = 0;
							value = (float)_prevTouchPosition;
							num44 = num4;
							goto IL_2797;
						}
					}
				}
			}
			goto IL_1d86;
		}
		goto IL_2797;
		IL_2168:
		if (IsPanning && UsePanByDrag)
		{
			bool mouseButton = Input.GetMouseButton((int)PanMouseButton);
			if (!mouseButton)
			{
				bool flag18 = OnPanFinished == null;
				IsPanning = mouseButton;
				if (!flag18)
				{
					Action onPanFinished = OnPanFinished;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5036.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			}
		}
		_prevMousePosition = (Vector3)num4;
		goto IL_2855;
		IL_1bd9:
		object panTarget4 = _panTarget;
		Func<float, float, float, Vector3> vectorHVD2 = VectorHVD;
		Func<Vector3, float> vector3H2 = Vector3H;
		if ((object)_panTarget != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ r13_v40 (System.Object)+10]");
			bool flag19 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ r13_v40 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret3));
			if (Vector3H != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1182 @ rsi_v43 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Camera vector3V4 = (Camera)(object)Vector3V;
				ProCamera2D proCamera2D13 = base.ProCamera2D;
				if ((object)proCamera2D13 != null)
				{
					Vector3 localPosition6 = proCamera2D13.LocalPosition;
					if (Vector3V != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1433.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
						ProCamera2D proCamera2D14 = base.ProCamera2D;
						if ((object)proCamera2D14 != null)
						{
							float num45;
							if (proCamera2D14.IsRelativeOffset)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2455 @ rax_v123 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
								object obj28 = 0 * proCamera2D14.OffsetY;
								num45 = (float)obj28 * 0.5f;
							}
							else
							{
								num45 = proCamera2D14.OffsetY;
							}
							object vector3D5 = Vector3D;
							ProCamera2DPanAndZoom panTarget5 = (ProCamera2DPanAndZoom)(object)_panTarget;
							if ((object)_panTarget != null)
							{
								bool flag20 = ((UnityEngine.Object)panTarget5).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)panTarget5).m_CachedPtr, out *(Vector3*)(&ret3));
								if (Vector3D != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v862 @ rdi_v45 (System.Object)+18] (should have been resolved before IL gen)");
									if (VectorHVD != null)
									{
										float num46 = num45 * 0.9999f;
										float num47 = localPosition6.x - num46;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v767 @ r15_v40 (System.Func`4<System.Single, System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ r13_v40 (System.Object)+10]");
										bool flag21 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ r13_v40 (System.Object)+10]");
										Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1d86;
		IL_0bf5:
		if (!IsPanning || !UsePanByDrag || !Input.GetMouseButton((int)PanMouseButton))
		{
			if (!UsePanByMoveToEdges || Input.GetMouseButton((int)PanMouseButton))
			{
				goto IL_2168;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1864048B0");
			Input.get_mousePosition_Injected(out *(Vector3*)(&ret2));
			object obj30 = default(object);
			object obj29 = 0 - obj30;
			float num48 = (float)obj29 * 0.5f;
			float num49 = num48 + ret2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1864048B0");
			object obj31 = default(object);
			num15 = num49 / (float)obj31;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186404900");
			Input.get_mousePosition_Injected(out *(Vector3*)(&ret2));
			object obj33 = default(object);
			object obj32 = 0 - obj33;
			float num50 = (float)obj32 * 0.5f;
			object obj34 = default(object);
			float num51 = num50 + (float)obj34;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186404900");
			object obj35 = default(object);
			num17 = num51 / (float)obj35;
			if (!(0f > num15))
			{
				if (num15 > 0f)
				{
					num16 = RightPanEdge * 0.5f;
					float num52 = num15 - num16;
					float num53 = 0.5f - num16;
					float num54 = num52 / num53;
					num15 = num54 * 0.5f;
					if (0f > num15)
					{
						goto IL_11f6;
					}
					bool flag22 = !(num15 > 0.5f);
					num3 = num16;
					if (!flag22)
					{
						num15 = 0.5f;
						num3 = num16;
					}
				}
			}
			else
			{
				float num55 = num15 - -0.5f;
				object obj36 = LeftPanEdge ^ -0f;
				float num56 = (float)obj36 * 0.5f;
				float num57 = num56 - -0.5f;
				float num58 = num55 / num57;
				float num59 = num58 * 0.5f;
				num15 = num59 - 0.5f;
				if (!(-0.5f > num15))
				{
					bool flag23 = !(num15 > 0f);
					num16 = num3;
					if (!flag23)
					{
						goto IL_11f6;
					}
				}
				else
				{
					num15 = -0.5f;
				}
			}
			goto IL_22d6;
		}
		Input.get_mousePosition_Injected(out *(Vector3*)(&ret2));
		ProCamera2D proCamera2D15 = base.ProCamera2D;
		if ((object)proCamera2D15 != null && (object)proCamera2D15.GameCamera != null)
		{
			int pixelWidth = proCamera2D15.GameCamera.pixelWidth;
			Input.get_mousePosition_Injected(out *(Vector3*)(&ret3));
			ProCamera2D proCamera2D16 = base.ProCamera2D;
			if ((object)proCamera2D16 != null && (object)proCamera2D16.GameCamera != null)
			{
				int pixelHeight = proCamera2D16.GameCamera.pixelHeight;
				ProCamera2D proCamera2D17 = base.ProCamera2D;
				if ((object)proCamera2D17 != null && (object)proCamera2D17.GameCamera != null)
				{
					Rect pixelRect = proCamera2D17.GameCamera.pixelRect;
					num3 = pixelRect.m_XMin;
					bool flag24 = ret2 < pixelRect.m_XMin;
					nint num6 = unchecked((nint)null);
					x2 = pixelHeight;
					if (!flag24)
					{
						x2 = num4 + pixelRect.m_XMin;
						bool flag25 = !(x2 > ret2);
						num6 = unchecked((nint)null);
						if (!flag25)
						{
							object obj37 = default(object);
							bool flag26 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj37) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4);
							num6 = unchecked((nint)null);
							x2 = num4;
							if (!flag26)
							{
								num3 = num4 + num4;
								bool flag27 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj37);
								float num60 = num3 - (float)obj37;
								bool flag28 = num60 == 0f;
								bool flag29 = !flag27;
								bool flag30 = !flag28;
								object obj38 = flag30 & flag29;
								bool flag31 = obj38 == null;
								num6 = unchecked((nint)null);
								x2 = num4;
								if (!flag31)
								{
									bool flag32 = InsideDraggableArea((Vector2)num4);
									bool flag33 = !flag32;
									num6 = unchecked((nint)null);
									x2 = num4;
									if (!flag33)
									{
										ProCamera2D proCamera2D18 = base.ProCamera2D;
										if ((object)proCamera2D18 != null && (object)proCamera2D18.GameCamera != null)
										{
											Vector3 vector3 = proCamera2D18.GameCamera.ScreenToWorldPoint((Vector3)(&value));
											if (ResetPrevPanPoint)
											{
												ProCamera2D proCamera2D19 = base.ProCamera2D;
												if ((object)proCamera2D19 == null || (object)proCamera2D19.GameCamera == null)
												{
													goto IL_1d86;
												}
												Vector3 vector5 = default(Vector3);
												Vector3 vector4 = proCamera2D19.GameCamera.ScreenToWorldPoint((Vector3)(&vector5));
												ResetPrevPanPoint = false;
											}
											ProCamera2D proCamera2D20 = base.ProCamera2D;
											if ((object)proCamera2D20 != null)
											{
												object gameCamera4 = proCamera2D20.GameCamera;
												if ((object)proCamera2D20.GameCamera != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1420 @ rdi_v71 (System.Object)+10]");
													bool flag34 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1420 @ rdi_v71 (System.Object)+10]");
													Camera.ScreenToWorldPoint_Injected((IntPtr)0, ref *(Vector3*)(&value), Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)(&ret3));
													Func<Vector3, float> vector3H3 = Vector3H;
													if (Vector3H != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1536 @ rcx_v244 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
														Func<Vector3, float> vector3V5 = Vector3V;
														if (Vector3V != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1514 @ rcx_v246 (System.Func`2<UnityEngine.Vector3, System.Single>)+28]");
															num6 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1514 @ rcx_v246 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
															_panDelta = (Vector2)num4;
															value = num4;
															num3 = num4;
															uint num5 = (uint)(&ret3);
															x2 = num4;
															goto IL_2168;
														}
													}
												}
											}
										}
										goto IL_1d86;
									}
								}
							}
						}
					}
					goto IL_2168;
				}
			}
		}
		goto IL_1d86;
		IL_166c:
		ProCamera2D proCamera2D21 = base.ProCamera2D;
		bool num61;
		if ((object)proCamera2D21 != null)
		{
			if (!proCamera2D21.IsCameraPositionRightBounded)
			{
				goto IL_2435;
			}
			Camera panTarget6 = (Camera)(object)_panTarget;
			Func<Vector3, float> vector3H4 = Vector3H;
			if ((object)_panTarget != null)
			{
				bool flag35 = ((UnityEngine.Object)panTarget6).m_CachedPtr == (IntPtr)0;
				num61 = flag35;
				Transform.get_position_Injected(((UnityEngine.Object)panTarget6).m_CachedPtr, out *(Vector3*)(&ret3));
				if (Vector3H != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1177 @ rsi_v52 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					Camera vector3H5 = (Camera)(object)Vector3H;
					ProCamera2D proCamera2D22 = base.ProCamera2D;
					if ((object)proCamera2D22 != null)
					{
						Vector3 localPosition7 = proCamera2D22.LocalPosition;
						if (Vector3H != null)
						{
							uint num5 = vector3H5.m_NonSerializedVersion;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1425.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
							bool flag36 = !(ret3 > localPosition7.x);
							value = localPosition7.x;
							value = localPosition7.x;
							if (!flag36)
							{
								goto IL_17b0;
							}
							goto IL_2435;
						}
					}
				}
			}
		}
		goto IL_1d86;
		IL_1aae:
		ProCamera2D proCamera2D23 = base.ProCamera2D;
		if ((object)proCamera2D23 != null)
		{
			if (!proCamera2D23.IsCameraPositionTopBounded)
			{
				return;
			}
			object panTarget7 = _panTarget;
			Func<Vector3, float> vector3V6 = Vector3V;
			if ((object)_panTarget != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1431 @ rdi_v47 (System.Object)+10]");
				bool flag37 = (nint)0 == 0;
				num23 = flag37;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1431 @ rdi_v47 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret3));
				if (Vector3V != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v810 @ rsi_v46 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					Camera vector3V7 = (Camera)(object)Vector3V;
					ProCamera2D proCamera2D24 = base.ProCamera2D;
					if ((object)proCamera2D24 != null)
					{
						Vector3 localPosition8 = proCamera2D24.LocalPosition;
						if (Vector3V != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v861.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
							bool flag38 = !(ret3 > localPosition8.x);
							value = localPosition8.x;
							if (!flag38)
							{
								goto IL_1bd9;
							}
							return;
						}
					}
				}
			}
		}
		goto IL_1d86;
		IL_2797:
		if (ret != _prevTouchId)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-6C]");
		if ((nint)0 != 1)
		{
			return;
		}
		Camera vector3D6 = (Camera)(object)Vector3D;
		ProCamera2D proCamera2D25 = base.ProCamera2D;
		int num63;
		if ((object)proCamera2D25 != null)
		{
			Vector3 localPosition9 = proCamera2D25.LocalPosition;
			if (Vector3D != null)
			{
				uint num5 = vector3D6.m_NonSerializedVersion;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1410.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
				float x5 = localPosition9.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				float num62 = x5 & 0;
				ProCamera2D proCamera2D26 = base.ProCamera2D;
				if ((object)proCamera2D26 != null && (object)proCamera2D26.GameCamera != null)
				{
					int pixelWidth2 = proCamera2D26.GameCamera.pixelWidth;
					ProCamera2D proCamera2D27 = base.ProCamera2D;
					if ((object)proCamera2D27 != null && (object)proCamera2D27.GameCamera != null)
					{
						int pixelHeight2 = proCamera2D27.GameCamera.pixelHeight;
						ProCamera2D proCamera2D28 = base.ProCamera2D;
						if ((object)proCamera2D28 != null && (object)proCamera2D28.GameCamera != null)
						{
							Rect pixelRect2 = proCamera2D28.GameCamera.pixelRect;
							num3 = pixelRect2.m_XMin;
							bool flag39 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj23) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)pixelRect2.m_XMin);
							value = localPosition9.x;
							nint num6 = unchecked((nint)null);
							num63 = pixelHeight2;
							if (!flag39)
							{
								float num64 = num4 + pixelRect2.m_XMin;
								bool flag40 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num64) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj23);
								value = localPosition9.x;
								num6 = unchecked((nint)null);
								num63 = (int)num64;
								if (!flag40)
								{
									bool flag41 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj25) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4);
									value = localPosition9.x;
									num6 = unchecked((nint)null);
									num63 = (int)num4;
									if (!flag41)
									{
										num3 = num4 + num4;
										bool flag42 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj25);
										float num65 = num3 - (float)obj25;
										bool flag43 = num65 == 0f;
										bool flag44 = !flag42;
										bool flag45 = !flag43;
										object obj39 = flag45 & flag44;
										bool flag46 = obj39 == null;
										value = localPosition9.x;
										num6 = unchecked((nint)null);
										num63 = (int)num4;
										if (!flag46)
										{
											bool flag47 = InsideDraggableArea((Vector2)num4);
											bool flag48 = !flag47;
											value = localPosition9.x;
											num6 = unchecked((nint)null);
											num63 = (int)num4;
											if (!flag48)
											{
												ProCamera2D proCamera2D29 = base.ProCamera2D;
												if ((object)proCamera2D29 != null && (object)proCamera2D29.GameCamera != null)
												{
													Vector3 vector6 = proCamera2D29.GameCamera.ScreenToWorldPoint((Vector3)(&value));
													ProCamera2D proCamera2D30 = base.ProCamera2D;
													if ((object)proCamera2D30 != null && (object)proCamera2D30.GameCamera != null)
													{
														Vector3 vector7 = proCamera2D30.GameCamera.ScreenToWorldPoint((Vector3)(&value));
														if (!IsPanning)
														{
															ProCamera2D proCamera2D31 = base.ProCamera2D;
															if ((object)proCamera2D31 != null)
															{
																ProCamera2D proCamera2D32 = base.ProCamera2D;
																if ((object)proCamera2D32 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2DA0");
																	Vector2 vector8 = proCamera2D31._003CScreenSizeInWorldCoordinates_003Ek__BackingField;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2420 @ rax_v414 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
																	object obj40 = vector8 + 0;
																	float num66 = (float)obj40 * 0.5f;
																	num63 = (int)(_startPanWorldPos / num66);
																	bool flag49 = !((float)num63 > MinPanAmount);
																	value = (float)_startPanWorldPos;
																	num5 = 0u;
																	num6 = (nint)(&value);
																	if (!flag49)
																	{
																		num3 = StopSpeedOnDragStart;
																		CenterPanTargetOnCamera(StopSpeedOnDragStart);
																		StartPanning();
																		value = (float)_startPanWorldPos;
																		num5 = 0u;
																		num6 = unchecked((nint)null);
																	}
																	goto IL_1f0c;
																}
															}
														}
														else
														{
															bool flag50 = !ResetPrevPanPoint;
															value = num4;
															num5 = 0u;
															if (!flag50)
															{
																ProCamera2D proCamera2D33 = base.ProCamera2D;
																if ((object)proCamera2D33 == null || (object)proCamera2D33.GameCamera == null)
																{
																	goto IL_1d86;
																}
																Vector3 vector9 = proCamera2D33.GameCamera.ScreenToWorldPoint((Vector3)(&value));
																ResetPrevPanPoint = false;
																value = num4;
																num5 = 0u;
															}
															Func<Vector3, float> vector3H6 = Vector3H;
															if (Vector3H != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1535 @ rcx_v322 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
																Func<Vector3, float> vector3V8 = Vector3V;
																if (Vector3V != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1498 @ rcx_v324 (System.Func`2<UnityEngine.Vector3, System.Single>)+28]");
																	num6 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1498 @ rcx_v324 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
																	_panDelta = (Vector2)num4;
																	value = num4;
																	num3 = num4;
																	num63 = (int)num4;
																	goto IL_1f0c;
																}
															}
														}
													}
												}
												goto IL_1d86;
											}
										}
									}
								}
							}
							goto IL_1f0c;
						}
					}
				}
			}
		}
		goto IL_1d86;
		IL_1f0c:
		_prevTouchPosition = (Vector3)num4;
		zeroVector = (Vector2)num63;
		goto IL_1e30;
		IL_1e30:
		if (IsPanning)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185244A30");
			object obj41 = default(object);
			if (obj41 == null)
			{
				IsPanning = false;
				if (OnPanFinished != null)
				{
					Action onPanFinished2 = OnPanFinished;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3316.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			}
		}
		goto IL_1f51;
		IL_1d86:
		throw new NullReferenceException();
		IL_152b:
		ProCamera2D proCamera2D34 = base.ProCamera2D;
		if ((object)proCamera2D34 != null)
		{
			if (!proCamera2D34.IsCameraPositionLeftBounded)
			{
				goto IL_166c;
			}
			Camera panTarget8 = (Camera)(object)_panTarget;
			Func<Vector3, float> vector3H7 = Vector3H;
			if ((object)_panTarget != null)
			{
				bool flag51 = ((UnityEngine.Object)panTarget8).m_CachedPtr == (IntPtr)0;
				num61 = flag51;
				Transform.get_position_Injected(((UnityEngine.Object)panTarget8).m_CachedPtr, out *(Vector3*)(&ret3));
				if (Vector3H != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1175 @ rsi_v53 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					Camera vector3H8 = (Camera)(object)Vector3H;
					ProCamera2D proCamera2D35 = base.ProCamera2D;
					if ((object)proCamera2D35 != null)
					{
						Vector3 localPosition10 = proCamera2D35.LocalPosition;
						if (Vector3H != null)
						{
							uint num5 = vector3H8.m_NonSerializedVersion;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1422.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
							bool flag52 = localPosition10.x > ret3;
							value = localPosition10.x;
							value = localPosition10.x;
							if (!flag52)
							{
								goto IL_166c;
							}
							goto IL_17b0;
						}
					}
				}
			}
		}
		goto IL_1d86;
	}

	private void StartPanning()
	{
		IsPanning = true;
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.HorizontalFollowSmoothness = _origFollowSmoothnessX;
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		proCamera2D2.VerticalFollowSmoothness = _origFollowSmoothnessY;
		if (OnPanStarted != null)
		{
			Action onPanStarted = OnPanStarted;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v80.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void StopPanning()
	{
		bool flag = OnPanFinished == null;
		IsPanning = false;
		if (!flag)
		{
			Action onPanFinished = OnPanFinished;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private unsafe void Zoom(float deltaTime)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0a21: Expected F4, but got I4
		//IL_0a40: Expected O, but got I4
		//IL_0a85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8a: Expected O, but got Unknown
		//IL_0076: Expected F4, but got I4
		//IL_0cf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf8: Expected O, but got Unknown
		//IL_0ac4: Expected O, but got I4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected F4, but got Unknown
		//IL_00be: Expected F4, but got I4
		//IL_0d14: Expected O, but got I4
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Expected O, but got Unknown
		//IL_0401: Expected O, but got F4
		//IL_0ad2: Expected O, but got I4
		//IL_00e6: Expected F4, but got I4
		//IL_0b82: Invalid comparison between O and F4
		//IL_0d29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2e: Expected O, but got Unknown
		//IL_0d37: Expected O, but got I4
		//IL_0d47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4c: Expected O, but got Unknown
		//IL_0d5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d61: Expected O, but got Unknown
		//IL_0d71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d76: Expected O, but got Unknown
		//IL_0d7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d84: Expected O, but got Unknown
		//IL_0db0: Expected O, but got I
		//IL_0db9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbe: Expected O, but got Unknown
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected F4, but got Unknown
		//IL_01bc: Expected O, but got F4
		//IL_04f8: Expected O, but got I4
		//IL_0df4: Expected O, but got F4
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Expected Ref, but got Unknown
		//IL_0572: Invalid comparison between I4 and F4
		//IL_05bd: Invalid comparison between F4 and I4
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Expected O, but got Unknown
		//IL_0685: Invalid comparison between F4 and O
		//IL_088c: Invalid comparison between F4 and I4
		//IL_0361: Expected I, but got O
		//IL_0377->IL0ade: Incompatible stack heights: 6 vs 0
		//IL_0bf7->IL0748: Incompatible stack heights: 2 vs 0
		//IL_0cc3->IL0c42: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = obj2 - 184;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998C2E6]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = !UseTouchInput;
		float num = 0f;
		float num2 = deltaTime;
		float num4 = default(float);
		float touchZoomTime;
		float value = default(float);
		if (!flag)
		{
			object obj3 = Input.touchCount;
			if ((nint)obj3 == 2)
			{
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				object obj4 = obj - 56;
				Input.GetTouch_Injected(0, out *(Touch*)obj4);
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				object obj5 = obj - 128;
				Input.GetTouch_Injected(1, out *(Touch*)obj5);
				Camera camera = (Camera)Screen.width;
				object obj6 = Screen.height;
				Camera camera2 = (Camera)Screen.width;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-6C]");
				object obj7 = 0 / camera2;
				object obj8 = Screen.height;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-7C]");
				object obj9 = 0 - obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
				object obj10 = 0 / obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
				object obj11 = 0 - obj10;
				object obj12 = obj + 192;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
				object obj13 = num3 - 0;
				object obj14 = obj + 192;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
				num = (float)obj11 - num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9520");
				Camera vector3D = (Camera)(object)Vector3D;
				ProCamera2D proCamera2D = base.ProCamera2D;
				if ((object)proCamera2D != null)
				{
					Vector3 localPosition = proCamera2D.LocalPosition;
					if (Vector3D != null)
					{
						uint nonSerializedVersion = vector3D.m_NonSerializedVersion;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rdi_v35 (UnityEngine.Camera)+28]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v586.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
						float x = localPosition.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						touchZoomTime = x & 0;
						_zoomPoint = (Vector3)num4;
						bool flag2 = _zoomStarted;
						float num6 = 0.5f;
						num2 = num4;
						if (flag2)
						{
							goto IL_0deb;
						}
						Camera panTarget = (Camera)(object)_panTarget;
						_zoomStarted = true;
						ProCamera2D proCamera2D2 = base.ProCamera2D;
						if ((object)proCamera2D2 != null)
						{
							Vector3 localPosition2 = proCamera2D2.LocalPosition;
							ProCamera2D proCamera2D3 = base.ProCamera2D;
							if ((object)proCamera2D3 != null)
							{
								object obj15 = default(object);
								float num7 = (float)obj15 - num4;
								float num8 = localPosition2.z;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ rax_v166 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+A4]");
								num2 = num8 - 0f;
								bool flag3 = (object)_panTarget == null;
								bool flag4 = ((UnityEngine.Object)panTarget).m_CachedPtr == (IntPtr)0;
								Transform.set_position_Injected(((UnityEngine.Object)panTarget).m_CachedPtr, ref *(Vector3*)(&value));
								ProCamera2D proCamera2D4 = base.ProCamera2D;
								bool flag5 = (object)proCamera2D4 == null;
								_origFollowSmoothnessX = proCamera2D4.HorizontalFollowSmoothness;
								ProCamera2D proCamera2D5 = base.ProCamera2D;
								bool flag6 = (object)proCamera2D5 == null;
								_origFollowSmoothnessY = proCamera2D5.VerticalFollowSmoothness;
								ProCamera2D proCamera2D6 = base.ProCamera2D;
								bool flag7 = (object)proCamera2D6 == null;
								proCamera2D6.HorizontalFollowSmoothness = 0f;
								ProCamera2D proCamera2D7 = base.ProCamera2D;
								bool flag8 = (object)proCamera2D7 == null;
								proCamera2D7.VerticalFollowSmoothness = 0f;
								num5 = unchecked((nint)null);
								num6 = num4;
								touchZoomTime = num4;
								goto IL_0deb;
							}
						}
					}
				}
				goto IL_0ad7;
			}
			bool flag9 = !_zoomStarted;
			num = 0f;
			num2 = deltaTime;
			if (!flag9)
			{
				float zoomAmount = _zoomAmount;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				num2 = zoomAmount & 0;
				bool flag10 = !(0.001f > num2);
				num = 0f;
				if (!flag10)
				{
					RestoreFollowSmoothness();
					_zoomStarted = false;
					num = 0f;
				}
			}
		}
		goto IL_0a5d;
		IL_0deb:
		object obj16 = Time.time;
		_touchZoomTime = touchZoomTime;
		goto IL_0a5d;
		IL_0ad7:
		throw new NullReferenceException();
		IL_0a5d:
		Vector3 ret;
		if (UseMouseInput)
		{
			float axis = UnityEngine.Internal.InputUnsafeUtility.GetAxis("Mouse ScrollWheel");
			Input.get_mousePosition_Injected(out *(Vector3*)(&value));
			Input.get_mousePosition_Injected(out ret);
			Camera vector3D2 = (Camera)(object)Vector3D;
			ProCamera2D proCamera2D8 = base.ProCamera2D;
			if ((object)proCamera2D8 != null)
			{
				Vector3 localPosition3 = proCamera2D8.LocalPosition;
				if (Vector3D != null)
				{
					uint nonSerializedVersion = vector3D2.m_NonSerializedVersion;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdi_v31 (UnityEngine.Camera)+28]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v259.m_NonSerializedVersion (System.UInt32) (should have been resolved before IL gen)");
					float x2 = localPosition3.x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					object obj17 = x2 & 0;
					_zoomPoint = (Vector3)num4;
					num = axis;
					num2 = num4;
					goto IL_0cc3;
				}
			}
			goto IL_0ad7;
		}
		goto IL_0cc3;
		IL_0748:
		ProCamera2D proCamera2D9 = base.ProCamera2D;
		if ((object)proCamera2D9 == null)
		{
			goto IL_0ad7;
		}
		float num9 = _initialCamSize / MaxZoomInAmount;
		_onMaxZoom = false;
		float num10 = _initialCamSize * MaxZoomOutAmount;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rax_v73 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
		float num11 = 0f * 0.5f;
		float num12 = num11 + _zoomAmount;
		if (!(num9 > num12))
		{
			if (!(num12 > num10))
			{
				goto IL_0bf7;
			}
			num12 -= num10;
			_onMinZoom = true;
		}
		else
		{
			num12 -= num9;
			_onMaxZoom = true;
		}
		float zoomAmount2 = _zoomAmount - num12;
		_zoomAmount = zoomAmount2;
		goto IL_0bf7;
		IL_0c42:
		ProCamera2D proCamera2D10 = base.ProCamera2D;
		if ((object)proCamera2D10 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rax_v76 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
			float num13 = 0f * 0.5f;
			float newSize = num13 + _zoomAmount;
			proCamera2D10.UpdateScreenSize(newSize);
			IsZooming = true;
			return;
		}
		goto IL_0ad7;
		IL_05d4:
		_zoomAmount = 0f;
		_prevZoomAmount = 0f;
		return;
		IL_0cc3:
		ProCamera2D proCamera2D11 = base.ProCamera2D;
		float ret2;
		if ((object)proCamera2D11 != null)
		{
			Camera gameCamera = proCamera2D11.GameCamera;
			if ((object)proCamera2D11.GameCamera != null)
			{
				if (((UnityEngine.Object)gameCamera).m_CachedPtr != (IntPtr)0)
				{
					Camera.get_pixelRect_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr, out *(Rect*)(&ret2));
					if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref _zoomPoint) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)ret2))
					{
						return;
					}
					object obj19 = default(object);
					object obj18 = obj19 + ret2;
					Vector3 zoomPoint = _zoomPoint;
					object obj20 = default(object);
					object obj21 = default(object);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref zoomPoint) || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj20) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj21))
					{
						return;
					}
					object obj23 = default(object);
					object obj22 = obj23 + obj21;
					bool flag11 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj22) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj20);
					object obj24 = obj22 - obj20;
					bool flag12 = obj24 == null;
					bool flag13 = !flag11;
					bool flag14 = !flag12;
					object obj25 = flag14 & flag13;
					if (obj25 == null)
					{
						return;
					}
					float num14 = ((!UseTouchInput) ? MouseZoomSpeed : (PinchZoomSpeed * 10f));
					if (_onMaxZoom)
					{
						float num15 = num14 * num;
						if (0f > num15)
						{
							goto IL_05d4;
						}
					}
					if (_onMinZoom)
					{
						float num16 = num14 * num;
						if (num16 > 0f)
						{
							goto IL_05d4;
						}
					}
					ref float currentVelocity = ref *(float*)(this + 168);
					float num17 = num14 * num;
					float target = num17 * deltaTime;
					float maxSpeed = default(float);
					float deltaTime2 = default(float);
					float num18 = (_zoomAmount = Mathf.SmoothDamp(_prevZoomAmount, target, ref currentVelocity, ZoomSmoothness, maxSpeed, deltaTime2));
					if (UseMouseInput)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
						object obj26 = num18 & 0;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.0001f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj26))
						{
							if (~(_zoomStarted ? 1u : 0u) == 0)
							{
								RestoreFollowSmoothness();
							}
							_zoomStarted = false;
							_prevZoomAmount = 0f;
							return;
						}
						if (!_zoomStarted)
						{
							Camera panTarget2 = (Camera)(object)_panTarget;
							_zoomStarted = true;
							ProCamera2D proCamera2D12 = base.ProCamera2D;
							if ((object)proCamera2D12 != null)
							{
								Vector3 localPosition4 = proCamera2D12.LocalPosition;
								ProCamera2D proCamera2D13 = base.ProCamera2D;
								if ((object)proCamera2D13 != null)
								{
									bool flag15 = (object)_panTarget == null;
									bool flag16 = ((UnityEngine.Object)panTarget2).m_CachedPtr == (IntPtr)0;
									float value2 = default(float);
									Transform.set_position_Injected(((UnityEngine.Object)panTarget2).m_CachedPtr, ref *(Vector3*)(&value2));
									UpdateCurrentFollowSmoothness();
									RemoveFollowSmoothness();
									goto IL_0748;
								}
							}
							goto IL_0ad7;
						}
					}
					goto IL_0748;
				}
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(proCamera2D11.GameCamera);
			}
		}
		goto IL_0ad7;
		IL_0bf7:
		_prevZoomAmount = _zoomAmount;
		if (ZoomToInputCenter)
		{
			bool flag17 = _zoomAmount == 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851B9BACh\"");
			if (!flag17)
			{
				ProCamera2D proCamera2D14 = base.ProCamera2D;
				if ((object)proCamera2D14 != null)
				{
					Camera panTarget3 = (Camera)(object)_panTarget;
					if ((object)_panTarget != null)
					{
						Vector3 position = _panTarget.position;
						if ((object)_panTarget != null)
						{
							Vector3 position2 = _panTarget.position;
							ProCamera2D proCamera2D15 = base.ProCamera2D;
							if ((object)proCamera2D15 != null)
							{
								Camera gameCamera2 = proCamera2D15.GameCamera;
								if ((object)proCamera2D15.GameCamera != null)
								{
									bool flag18 = ((UnityEngine.Object)gameCamera2).m_CachedPtr == (IntPtr)0;
									Vector3 position3 = default(Vector3);
									Camera.ScreenToWorldPoint_Injected(((UnityEngine.Object)gameCamera2).m_CachedPtr, ref position3, Camera.MonoOrStereoscopicEye.Mono, out ret);
									bool flag19 = ((UnityEngine.Object)panTarget3).m_CachedPtr == (IntPtr)0;
									Transform.set_position_Injected(((UnityEngine.Object)panTarget3).m_CachedPtr, ref *(Vector3*)(&ret2));
									goto IL_0c42;
								}
							}
						}
					}
				}
				goto IL_0ad7;
			}
		}
		goto IL_0c42;
	}

	public void UpdateCurrentFollowSmoothness()
	{
		ProCamera2D proCamera2D = base.ProCamera2D;
		_origFollowSmoothnessX = proCamera2D.HorizontalFollowSmoothness;
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		_origFollowSmoothnessY = proCamera2D2.VerticalFollowSmoothness;
	}

	public unsafe void CenterPanTargetOnCamera(float interpolant = 1f)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_01a3: Invalid comparison between I4 and F4
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_02b5->IL021f: Incompatible stack heights: 2 vs 0
		Transform panTarget = _panTarget;
		if ((object)_panTarget != null && ((UnityEngine.Object)panTarget).m_CachedPtr != (IntPtr)0)
		{
			object panTarget2 = _panTarget;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rbp_v2 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rbp_v2 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			Func<float, float, Vector3> vectorHV = VectorHV;
			Func<Vector3, float> vector3H = Vector3H;
			ProCamera2D proCamera2D = base.ProCamera2D;
			Vector3 localPosition = proCamera2D.LocalPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v347 @ rdi_v9 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			float num;
			if (proCamera2D2.IsRelativeOffset)
			{
				object obj = proCamera2D2._003CScreenSizeInWorldCoordinates_003Ek__BackingField * proCamera2D2.OffsetX;
				num = (float)obj * 0.5f;
			}
			else
			{
				num = proCamera2D2.OffsetX;
			}
			Func<Vector3, float> vector3V = Vector3V;
			ProCamera2D proCamera2D3 = base.ProCamera2D;
			Vector3 localPosition2 = proCamera2D3.LocalPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v142 @ rdi_v10 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			ProCamera2D proCamera2D4 = base.ProCamera2D;
			float num2;
			if (proCamera2D4.IsRelativeOffset)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rax_v34 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				object obj2 = 0 * proCamera2D4.OffsetY;
				num2 = (float)obj2 * 0.5f;
			}
			else
			{
				num2 = proCamera2D4.OffsetY;
			}
			float num3 = localPosition2.x - num2;
			float num4 = localPosition.x - num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v343 @ rsi_v8 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
			if (0f > interpolant || interpolant > 1f)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rbp_v2 (System.Object)+10]");
			bool flag2 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rbp_v2 (System.Object)+10]");
			float value = default(float);
			Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value));
		}
	}

	private void CancelZoom()
	{
		_zoomAmount = 0f;
		_prevZoomAmount = 0f;
	}

	private void RestoreFollowSmoothness()
	{
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.HorizontalFollowSmoothness = _origFollowSmoothnessX;
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		proCamera2D2.VerticalFollowSmoothness = _origFollowSmoothnessY;
	}

	private void RemoveFollowSmoothness()
	{
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.HorizontalFollowSmoothness = 0f;
		ProCamera2D proCamera2D2 = base.ProCamera2D;
		proCamera2D2.VerticalFollowSmoothness = 0f;
	}

	private bool InsideDraggableArea(Vector2 normalizedInput)
	{
		//IL_0100: Invalid comparison between O and F4
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_016d: Invalid comparison between F4 and O
		//IL_0079: Invalid comparison between I and F4
		//IL_01cb: Invalid comparison between O and F4
		//IL_00a1: Invalid comparison between I and F4
		//IL_0217: Expected O, but got I
		//IL_023e: Invalid comparison between F4 and O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851BA4E3h\"");
		if ((object)DraggableAreaRect == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851BA4E3h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+C8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851BA4E3h\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+CC]");
				if (0f == 1f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+D0]");
					bool flag = 0f == 1f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001851BA4E3h\"");
					if (flag)
					{
						goto IL_0255;
					}
				}
			}
		}
		float num = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+CC]");
		float num2 = num - 0f;
		float num3 = num2 * 0.5f;
		float num4 = num3 + (float)DraggableAreaRect;
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref normalizedInput) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4))
		{
			float num5 = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+CC]");
			float num6 = num5 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+CC]");
			object obj = 0 + DraggableAreaRect;
			float num7 = num6 * 0.5f;
			float num8 = (float)obj + num7;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref normalizedInput))
			{
				float num9 = 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+D0]");
				float num10 = num9 - 0f;
				float num11 = num10 * 0.5f;
				float num12 = num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+C8]");
				float num13 = num12 + 0f;
				object obj2 = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num13))
				{
					float num14 = 1f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+D0]");
					float num15 = num14 - 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+D0]");
					nint num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Com.LuisPedroFonseca.ProCamera2D.ProCamera2DPanAndZoom)+C8]");
					object obj3 = num16 + 0;
					float num17 = num15 * 0.5f;
					float num18 = (float)obj3 + num17;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num18) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						goto IL_0255;
					}
				}
			}
		}
		return false;
		IL_0255:
		return true;
	}

	public ProCamera2DPanAndZoom()
	{
		//IL_0012: Expected O, but got I
		//IL_008b: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_00ee: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
		DraggableAreaRect = (Rect)0;
		AutomaticInputDetection = true;
		DisableOverUGUI = true;
		MouseZoomSpeed = 10f;
		PinchZoomSpeed = 50f;
		ZoomSmoothness = 0.2f;
		MaxZoomInAmount = 2f;
		MaxZoomOutAmount = 2f;
		ZoomToInputCenter = true;
		AllowPan = true;
		StopSpeedOnDragStart = 0.95f;
		DragPanSpeedMultiplier = (Vector2)1065353216;
		_ = 1065353216;
		EdgesPanSpeed = (Vector2)1073741824;
		_ = 1073741824;
		TopPanEdge = 0.9f;
		BottomPanEdge = 0.9f;
		LeftPanEdge = 0.9f;
		RightPanEdge = 0.9f;
		MinPanAmount = 0.05f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
