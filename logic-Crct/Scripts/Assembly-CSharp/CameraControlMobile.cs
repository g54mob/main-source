using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class CameraControlMobile : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWaitApplicationLoad_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CameraControlMobile _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CWaitApplicationLoad_003Ed__15(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("Viewport Clipping")]
	public bool clipViewport;

	public float clipTop;

	public bool desktop;

	[Header("Debug")]
	public GameObject notchObject;

	public bool displayNotch;

	private Resolution baseResolution;

	private float renderT;

	public float renderPeriod;

	public bool overrideRender;

	public bool requireRender;

	private Vector3 prevPos;

	private static List<RaycastResult> results;

	private static PointerEventData eventDataCurrentPosition;

	public AudioSource clickAudio;

	public static bool HighFrameRate;

	public static bool MidFrameRate;

	public float HighFrameRateT;

	private bool focus;

	[Header("Components")]
	public Transform pivot;

	public Transform cam;

	[Header("Move Pivot Variables")]
	public float moveSpeed;

	public float touchMoveSpeed;

	public float moveZoomMultiplier;

	public Vector4 moveLimits;

	[Header("Orbit Pivot Variables")]
	public float orbitSpeed;

	[Header("Zoom Variables")]
	public float zoomSpeed;

	public float touchZoomSpeed;

	public float maxZoom;

	public float minZoom;

	[Header("Reset View")]
	public Vector3 homeRotation;

	public Vector3 homeZoom;

	public float homeTime;

	private float homeT;

	private bool movingHome;

	private Quaternion homeStartRotation;

	private Vector3 homeStartZoom;

	private Vector3 homeStartPosition;

	private float homeStartOrthoSize;

	private Vector3 basePivotPosition;

	private Vector3 baseTouchPosition;

	private Vector3 deltaTouchPosition;

	private Vector3 deltaPosition;

	private Vector3 baseOrbitRotation;

	private Vector3 deltaOrbitRotation;

	private Vector3 deltaZoomPosition;

	private float deltaZoomOrtho;

	private Vector2 basePivotTouchPosition;

	private Vector2 baseOrbitTouchPosition;

	private float startTouchDelta;

	private float zoomTouchDelta;

	private Vector3 prevZoomPos;

	private float prevOrthoZoom;

	public bool initTouchZoom;

	public float zoomSensitivity;

	private float prevZ;

	[Header("Viewport Settings")]
	public GameObject viewportSettingsGameObject;

	public PostProcessLayer ppl;

	[Header("Shadow Quality")]
	public Light sceneLight;

	public Toggle[] togglesShadowQuality;

	[Header("AO")]
	public PostProcessProfile ppProfile;

	public Toggle toggleAO;

	private bool AO;

	[Header("Bloom")]
	public Toggle toggleBloom;

	private bool bloom;

	[Header("Projection Mode")]
	public Toggle[] projectionToggles;

	public bool orthographic;

	[Header("Render Scale")]
	public RenderScale renderScale;

	public Toggle toggleRenderScale;

	private bool downSample;

	[Header("Other Cameras")]
	public Camera handleCamera;

	public Camera snapshotCamera;

	[Header("AA")]
	public bool AA;

	private static CameraControlMobile inst { get; set; }

	public static Vector3 PivotPosition => default(Vector3);

	public static bool Orthographic => false;

	private void Awake()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitApplicationLoad_003Ed__15))]
	private IEnumerator WaitApplicationLoad()
	{
		return null;
	}

	public static void RequireRender()
	{
	}

	public static void RequireRender(float t)
	{
	}

	public static void HighFrameRateRequired()
	{
	}

	public static void MidFrameRateRequired()
	{
	}

	private void Update()
	{
	}

	public static void ClickHomeView()
	{
	}

	public void BeginPivotDrag(BaseEventData data)
	{
	}

	public void BeginTouchPivotDrag(Touch touch)
	{
	}

	public void PivotDrag(BaseEventData data)
	{
	}

	public static void KeyboardMovePivot(Vector3 dir)
	{
	}

	public void TouchPivotDrag()
	{
	}

	public void BeginTouchOrbitDrag(Touch touch)
	{
	}

	public void BeginOrbitDrag(BaseEventData data)
	{
	}

	public void TouchOrbitDrag(Touch touch)
	{
	}

	public void OrbitDrag(BaseEventData data)
	{
	}

	public void BeginZoomDrag(BaseEventData data)
	{
	}

	public void ZoomDrag(BaseEventData data)
	{
	}

	public void ScrollZoom()
	{
	}

	public void BeginTouchZoomDrag()
	{
	}

	public void TouchZoomDrag()
	{
	}

	public void OpenViewportSettings()
	{
	}

	public void CloseViewportSettings()
	{
	}

	public static void SetShadow(int n)
	{
	}

	public void ShadowQuality(int n)
	{
	}

	public static void SetAO(bool on)
	{
	}

	public void ToggleAO()
	{
	}

	public static void SetBloom(bool on)
	{
	}

	public void ToggleBloom()
	{
	}

	public static void SetProjection(int n)
	{
	}

	public void ToggleProjection(int n)
	{
	}

	public void ToggleRenderScale()
	{
	}

	public static void SetAA(bool on)
	{
	}

	private void UpdateOtherCameras()
	{
	}

	public static void IPC_Settings(CRUMB_IPC.IPCData data)
	{
	}
}
