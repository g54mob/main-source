using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	private struct LightRaycastData
	{
		public float MaxRange;

		public float LightMultiplier;

		public int Phase;

		public bool IsReverseCheck;

		public LightRaycastData(float maxRange, float lightMultiplier, int phase, bool isReverseCheck)
		{
			MaxRange = 0f;
			LightMultiplier = 0f;
			Phase = 0;
			IsReverseCheck = false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCameraFade_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool fade;

		public CameraController _003C_003E4__this;

		private float _003CsnapProgress_003E5__2;

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
		public _003CCameraFade_003Ed__34(int _003C_003E1__state)
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

	[Header("References")]
	public GameObject cameraObj;

	public GameObject container;

	public Camera cam;

	public HDAdditionalCameraData hdrpCam;

	[Header("Fade")]
	public bool fadeActive;

	public Image fadeImage;

	[Header("Editor Movement Settings")]
	public Vector2 camHeightLimit;

	public float heightRatio;

	public Vector3 defaultCameraEuler;

	[Space(5f)]
	public float scrollSensitivity;

	public float camScrollHeightModifier;

	[Space(5f)]
	public float rotateSensitivity;

	[Space(5f)]
	public float zoomSensitivity;

	[Header("Smoothing Speeds")]
	public float smoothRotateSpeed;

	public float smoothZoomSpeed;

	public float highlightScrollSpeed;

	[Header("Camera Boundary")]
	public float isoCamBoundaryMultiplier;

	public float topCamBoundaryMultiplier;

	[Header("Highlight scroll")]
	public bool highlightScrollActive;

	public bool highlightScrollCancelFlag;

	public Vector3 originalCameraPosition;

	public Vector3 highlightScroll;

	public GameObject highlightScrollMarker;

	public float highlightTileHeight;

	private static CameraController _instance;

	private List<LightRaycastData> lightRaycastDataCollection;

	private List<RaycastCommand> raycastCommands;

	private NativeArray<RaycastHit> results;

	private NativeArray<RaycastCommand> commands;

	private JobHandle handle;

	private bool isLightLevelJobInProgress;

	private float lightLevel;

	public static CameraController Instance => null;

	private void Awake()
	{
	}

	public void NewHighlightScroll(Vector2 newScrollPosPathmap)
	{
	}

	public void CancelHighlightScroll()
	{
	}

	public void ImmediateCancelHighlightScroll()
	{
	}

	public void SetupFPS()
	{
	}

	public void FadeCamera(float fadeSpeed)
	{
	}

	public void UnFadeCamera(float fadeSpeed)
	{
	}

	[IteratorStateMachine(typeof(_003CCameraFade_003Ed__34))]
	private IEnumerator CameraFade(bool fade = true, float fadeSpeed = 1f)
	{
		return null;
	}

	public float GetPlayerLightLevel()
	{
		return 0f;
	}

	private void OnDestroy()
	{
	}

	private void LateUpdate()
	{
	}
}
