using System;
using UnityEngine;
using UnityEngine.Events;

namespace UI.ThreeDimensional
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class UIObject3D : MonoBehaviour
	{
		[SerializeField]
		private Transform _ObjectPrefab;

		public bool UseTargetRotation;

		[SerializeField]
		private Vector3 _TargetRotation;

		[SerializeField]
		private float _TargetOffsetX;

		[SerializeField]
		private float _TargetOffsetY;

		[SerializeField]
		private bool _OverrideCalculatedTargetScale;

		[SerializeField]
		private float _CalculatedTargetScaleOverride;

		[SerializeField]
		private float _CameraFOV;

		[SerializeField]
		private float _CameraDistance;

		[SerializeField]
		private bool _AlwaysLookAtTarget;

		[SerializeField]
		[HideInInspector]
		private Vector2 _textureSize;

		[SerializeField]
		private Color _BackgroundColor;

		[SerializeField]
		public bool ClearGLBufferBeforeRendering;

		[SerializeField]
		public bool LimitFrameRate;

		[SerializeField]
		public float FrameRateLimit;

		public bool RenderConstantly;

		[SerializeField]
		private float _RenderScale;

		private float timeSinceLastRender;

		[SerializeField]
		private bool _EnableCameraLight;

		[SerializeField]
		private Color _LightColor;

		[SerializeField]
		private float _LightIntensity;

		[SerializeField]
		public UnityEvent OnUpdateTarget;

		[NonSerialized]
		private bool started;

		[NonSerialized]
		private bool hardUpdateQueued;

		[NonSerialized]
		private bool renderQueued;

		[NonSerialized]
		private Bounds targetBounds;

		private static bool copyTextureSupportedPopulated;

		private static bool _copyTextureSupported;

		private RectTransform _rectTransform;

		[SerializeField]
		[HideInInspector]
		private UIObject3DImage _imageComponent;

		private Texture2D _texture2D;

		private Sprite _sprite;

		private RenderTexture _renderTexture;

		private static Transform _parentContainer;

		private Transform _container;

		private Transform _targetContainer;

		private Transform _target;

		private Camera _targetCamera;

		private Light _cameraLight;

		private static int _objectLayer;

		public Transform ObjectPrefab
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 TargetRotation
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		[SerializeField]
		public Vector2 TargetOffset
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public bool OverrideCalculatedTargetScale
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float CalculatedTargetScaleOverride
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CameraFOV
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CameraDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool AlwaysLookAtTarget
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector2 TextureSize => default(Vector2);

		public Color BackgroundColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float RenderScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal float timeBetweenFrames => 0f;

		public bool EnableCameraLight
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Color LightColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float LightIntensity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private static bool copyTextureSupported => false;

		protected RectTransform rectTransform => null;

		public UIObject3DImage imageComponent => null;

		protected Texture2D texture2D => null;

		protected Sprite sprite => null;

		protected RenderTexture renderTexture => null;

		private static Transform parentContainer => null;

		internal Transform container => null;

		internal Transform targetContainer => null;

		protected Transform target => null;

		protected Camera targetCamera => null;

		protected Light cameraLight => null;

		internal static int objectLayer => 0;

		private void DestroyResources()
		{
		}

		public void HardUpdateDisplay()
		{
		}

		private void _Destroy(UnityEngine.Object o)
		{
		}

		private void Start()
		{
		}

		public void SetStarted()
		{
		}

		public void UpdateDisplay(bool instantRender = false)
		{
		}

		private void OnEnable()
		{
		}

		private void ClearObjectLayerFromCameras()
		{
		}

		private void ClearObjectLayerFromLights()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Prepare()
		{
		}

		public void Cleanup()
		{
		}

		public Transform GetTargetInstance()
		{
			return null;
		}

		internal void Render(bool instant = false)
		{
		}

		private void Update()
		{
		}

		private void SetupTarget()
		{
		}

		public void RefreshTarget()
		{
		}

		private void UpdateTargetPositioningAndScale()
		{
		}

		private void SetLayerRecursively(Transform transform, int layer)
		{
		}

		private void SetupTargetCamera()
		{
		}

		private void SetupCameraLight()
		{
		}

		private void UpdateTargetCameraPositioningEtc()
		{
		}
	}
}
