using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cinemachine;
using LeTai.Asset.TranslucentImage;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
	[Serializable]
	public class VCamDictionary : SerializableDictionary<eVirtualCameraType, CinemachineVirtualCamera>
	{
	}

	public enum eCameraType
	{
		MAIN_CAMERA = 0,
		UI_CAMERA = 1
	}

	public enum eVirtualCameraType
	{
		NONE = 0,
		TITLE = 1,
		LEVEL_UP = 2,
		INGAME = 3
	}

	public enum eCameraShakeStrength
	{
		Weak = 0,
		Normal = 1,
		Strong = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_ShakeCamera_003Ed__53 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CameraManager _003C_003E4__this;

		public float delay;

		public float intensity;

		public float decay;

		private Camera _003Ccamera_003E5__2;

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
		public _003CCR_ShakeCamera_003Ed__53(int _003C_003E1__state)
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

	[SerializeField]
	private Camera mainCamera;

	[SerializeField]
	private Camera uiCamera;

	[SerializeField]
	private Camera fogOfWarCamera;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private Camera photoCamera;

	[SerializeField]
	private PhotoCameraController photoCameraController;

	[SerializeField]
	private VCamDictionary dic_VCameras;

	[SerializeField]
	private CameraController mainCameraController;

	[SerializeField]
	private TranslucentImageSource translucentImageSource;

	private CinemachineVirtualCamera currentCamera;

	private ShakeCamera shakeCamera_Main;

	private float cameraShakeIntensitySetting;

	public Camera MainCamera => null;

	public Camera UICamera => null;

	public Camera FogOfWarCamera => null;

	public Canvas Canvas => null;

	public Camera PhotoCamera => null;

	public CameraController MainCameraController => null;

	public TranslucentImageSource TranslucentImageSource => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRegisterCameraFollowTarget(Transform transform)
	{
	}

	private void OnUnregisterCameraFollowTarget(Transform transform)
	{
	}

	private void OnSetCameraFov(float fov)
	{
	}

	private void OnMoveCameraToOffset(Vector3 offset, bool isImmediate)
	{
	}

	private void OnInitializeEnvSceneBindings(GameSceneReferenceHandler refHandler)
	{
	}

	private void OnRequestCameraShake(eCameraShakeStrength strength)
	{
	}

	private void OnDestroy()
	{
	}

	public void OverrideCamera(eCameraType type, Camera camera)
	{
	}

	public static void SwitchCamera(eVirtualCameraType type)
	{
	}

	private void switchCamera(eVirtualCameraType type)
	{
	}

	public Vector3 Calculate2DPosFrom3DPos(Vector3 worldPos)
	{
		return default(Vector3);
	}

	public Vector3 WorldPosToScreenPos(Vector3 worldPos)
	{
		return default(Vector3);
	}

	public Vector3 ScreenPosToUIPos(Vector3 screenPos)
	{
		return default(Vector3);
	}

	public Vector3 WorldPosToUIPos(Vector3 worldPos)
	{
		return default(Vector3);
	}

	public Vector3 CalculateViewportPos(Vector3 worldPos)
	{
		return default(Vector3);
	}

	public Vector3 EnsureUIStaysInLRBorder(Vector3 worldPos, float width)
	{
		return default(Vector3);
	}

	public bool IsInScreen(Vector3 worldPos, float marginOffset = 0f)
	{
		return false;
	}

	public bool IsUIInCameraView(Transform uiTransform)
	{
		return false;
	}

	public Vector3 GetMouseWorldPos()
	{
		return default(Vector3);
	}

	public Vector3 MousePosToWorldPos(Vector3 mousePos)
	{
		return default(Vector3);
	}

	public void ShakeCamera(float intensity, float decay, float delay = 0f)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_ShakeCamera_003Ed__53))]
	private IEnumerator CR_ShakeCamera(float intensity, float decay, float delay)
	{
		return null;
	}

	public void BindWeatherEffectToCamera(Transform item, Transform baseItem)
	{
	}

	public void TakePhoto()
	{
	}

	public int GetPhotoCount()
	{
		return 0;
	}

	public void ClearPhotos()
	{
	}

	public RenderTexture GetPhoto(int index)
	{
		return null;
	}
}
