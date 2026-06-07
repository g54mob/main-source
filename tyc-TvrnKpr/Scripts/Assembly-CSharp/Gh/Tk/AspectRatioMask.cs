using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class AspectRatioMask : MonoBehaviour
	{
		public List<Camera> cameras;

		private bool _isDirty;

		[SerializeField]
		private Color _maskColor;

		public const float ASPECT_RATIO = 1.7777778f;

		private static Texture2D _maskTexture;

		private static GUIStyle _style;

		public static float ScreenRatio => 0f;

		public static int CachedWindowWidth { get; private set; }

		public static int CachedWindowHeight { get; private set; }

		public static float ViewportInsetHeight => 0f;

		public static int InsetHeight => 0;

		private Rect TopMask { get; set; }

		private Rect BottomMask { get; set; }

		private Rect CameraViewport { get; set; }

		private void Awake()
		{
		}

		public void RegisterCameras(GameObject tavernCameraGameObject)
		{
		}

		public void RegisterCamera(Camera cam)
		{
		}

		public void UnregisterCamera(Camera cam)
		{
		}

		private void OnScreenSizeChanged(object sender, EventArgs e)
		{
		}

		public static Vector3 ClampToAspectScreenSize(Vector3 screensize)
		{
			return default(Vector3);
		}

		public void UpdateMask()
		{
		}

		private void Update()
		{
		}

		private void OnGUI()
		{
		}

		private void OnEnable()
		{
		}

		private void DrawMask()
		{
		}

		private void ResetMask()
		{
		}

		private void OnDisable()
		{
		}
	}
}
