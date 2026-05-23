using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Muna;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VideoKit.Internal;

namespace VideoKit.UI
{
	[Tooltip("VideoKit UI component for displaying the camera preview from a camera manager.")]
	[RequireComponent(typeof(RawImage), typeof(AspectRatioFitter), typeof(EventTrigger))]
	[HelpURL("https://videokit.ai/reference/videokitcameraview")]
	[DisallowMultipleComponent]
	public sealed class VideoKitCameraView : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler
	{
		public enum ViewMode
		{
			CameraTexture = 0,
			HumanTexture = 1
		}

		public enum GestureMode
		{
			None = 0,
			Tap = 1,
			Pinch = 2,
			Drag = 3
		}

		[Header("Configuration")]
		[Tooltip("VideoKit camera manager.")]
		public VideoKitCameraManager? cameraManager;

		[Tooltip("Desired camera facing to display.")]
		public VideoKitCameraManager.Facing facing = VideoKitCameraManager.Facing.User | VideoKitCameraManager.Facing.World;

		[Tooltip("View mode of the view.")]
		public ViewMode viewMode;

		[Header("Gestures")]
		[Tooltip("Focus gesture.")]
		[FormerlySerializedAs("focusMode")]
		public GestureMode focusGesture;

		[Tooltip("Exposure gesture.")]
		[FormerlySerializedAs("exposureMode")]
		public GestureMode exposureGesture;

		[Tooltip("Zoom gesture.")]
		[FormerlySerializedAs("zoomMode")]
		public GestureMode zoomGesture;

		[Header("Events")]
		[Tooltip("Event raised when a new camera frame is available.")]
		public UnityEvent? OnCameraFrame;

		private PixelBuffer pixelBuffer;

		private RawImage rawImage;

		private AspectRatioFitter aspectFitter;

		private readonly object fence = new object();

		private static readonly List<RuntimePlatform> OrientationSupport = new List<RuntimePlatform>
		{
			RuntimePlatform.Android,
			RuntimePlatform.IPhonePlayer
		};

		internal CameraDevice? device => VideoKitCameraManager.EnumerateCameraDevices(cameraManager?.device).FirstOrDefault((CameraDevice device) => facing.HasFlag(VideoKitCameraManager.GetCameraFacing(device)));

		public Texture2D? texture { get; private set; }

		public PixelBuffer.Rotation rotation { get; set; }

		public event Action<PixelBuffer>? OnPixelBuffer;

		private void Reset()
		{
			cameraManager = UnityEngine.Object.FindFirstObjectByType<VideoKitCameraManager>();
		}

		private void Awake()
		{
			rawImage = GetComponent<RawImage>();
			aspectFitter = GetComponent<AspectRatioFitter>();
		}

		private void OnEnable()
		{
			rotation = GetPreviewRotation(Screen.orientation);
			if (cameraManager != null)
			{
				cameraManager.OnPixelBuffer += OnCameraBuffer;
			}
		}

		private unsafe void Update()
		{
			bool flag = false;
			lock (fence)
			{
				if (pixelBuffer == IntPtr.Zero)
				{
					return;
				}
				if (texture != null && (texture.width != pixelBuffer.width || texture.height != pixelBuffer.height))
				{
					UnityEngine.Object.Destroy(texture);
					texture = null;
				}
				if (texture == null)
				{
					texture = new Texture2D(pixelBuffer.width, pixelBuffer.height, TextureFormat.RGBA32, mipChain: false);
				}
				if (viewMode == ViewMode.CameraTexture)
				{
					using PixelBuffer destination = new PixelBuffer(texture, 0L);
					pixelBuffer.CopyTo(destination);
					flag = true;
				}
				else if (viewMode == ViewMode.HumanTexture)
				{
					((Muna.Image)VideoKitClient.Instance.muna.Predictions.Create("@videokit/human-texture-2", new Dictionary<string, object> { ["image"] = new Muna.Image((byte*)pixelBuffer.data.GetUnsafePtr(), pixelBuffer.width, pixelBuffer.height, 4) }, Acceleration.Auto, (IntPtr)0).Throw().Result.results[0]).ToTexture(texture);
					flag = true;
				}
			}
			if (flag)
			{
				texture.Apply();
			}
			rawImage.texture = texture;
			aspectFitter.aspectRatio = (float)texture.width / (float)texture.height;
			OnCameraFrame?.Invoke();
		}

		private void OnCameraBuffer(CameraDevice cameraDevice, PixelBuffer cameraBuffer)
		{
			if ((VideoKitCameraManager.GetCameraFacing(cameraDevice) & facing) == 0)
			{
				return;
			}
			var (num, num2) = GetPreviewTextureSize(cameraBuffer.width, cameraBuffer.height, rotation);
			lock (fence)
			{
				if (pixelBuffer != IntPtr.Zero && (pixelBuffer.width != num || pixelBuffer.height != num2))
				{
					pixelBuffer.Dispose();
					pixelBuffer = default(PixelBuffer);
				}
				if (pixelBuffer == IntPtr.Zero)
				{
					pixelBuffer = new PixelBuffer(num, num2, PixelBuffer.Format.RGBA8888, 0, 0L, mirrored: true);
				}
				cameraBuffer.CopyTo(pixelBuffer, rotation);
			}
			this.OnPixelBuffer?.Invoke(pixelBuffer);
		}

		private void OnDisable()
		{
			if (cameraManager != null)
			{
				cameraManager.OnPixelBuffer -= OnCameraBuffer;
			}
		}

		private void OnDestroy()
		{
			pixelBuffer.Dispose();
			pixelBuffer = default(PixelBuffer);
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData data)
		{
			CameraDevice cameraDevice = device;
			if (cameraDevice == null || (focusGesture != GestureMode.Tap && exposureGesture != GestureMode.Tap))
			{
				return;
			}
			RectTransform rectTransform = base.transform as RectTransform;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, data.position, data.pressEventCamera, out var localPoint))
			{
				Vector2 vector = Rect.PointToNormalized(rectTransform.rect, localPoint);
				if (cameraDevice.focusPointSupported && focusGesture == GestureMode.Tap)
				{
					cameraDevice.SetFocusPoint(vector.x, vector.y);
				}
				if (cameraDevice.exposurePointSupported && exposureGesture == GestureMode.Tap)
				{
					cameraDevice.SetExposurePoint(vector.x, vector.y);
				}
			}
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData data)
		{
		}

		void IDragHandler.OnDrag(PointerEventData data)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static PixelBuffer.Rotation GetPreviewRotation(ScreenOrientation orientation)
		{
			if (OrientationSupport.Contains(Application.platform))
			{
				return orientation switch
				{
					ScreenOrientation.LandscapeLeft => PixelBuffer.Rotation._0, 
					ScreenOrientation.Portrait => PixelBuffer.Rotation._90, 
					ScreenOrientation.LandscapeRight => PixelBuffer.Rotation._180, 
					ScreenOrientation.PortraitUpsideDown => PixelBuffer.Rotation._270, 
					_ => PixelBuffer.Rotation._0, 
				};
			}
			return PixelBuffer.Rotation._0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static (int width, int height) GetPreviewTextureSize(int width, int height, PixelBuffer.Rotation rotation)
		{
			if (rotation != PixelBuffer.Rotation._90 && rotation != PixelBuffer.Rotation._270)
			{
				return (width: width, height: height);
			}
			return (width: height, height: width);
		}
	}
}
