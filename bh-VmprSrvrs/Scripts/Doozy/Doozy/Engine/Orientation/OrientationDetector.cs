using UnityEngine;

namespace Doozy.Engine.Orientation
{
	[AddComponentMenu("Doozy/Orientation/Orientation Detector", 13)]
	[RequireComponent(typeof(RectTransform), typeof(Canvas))]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-100)]
	public class OrientationDetector : MonoBehaviour
	{
		private static OrientationDetector s_instance;

		public bool DebugMode;

		public OrientationEvent OnOrientationEvent;

		private DetectedOrientation m_currentOrientation;

		private RectTransform m_rectTransform;

		private Canvas m_canvas;

		private int m_deviceOrientationCheckCount;

		public static OrientationDetector Instance => null;

		public static bool ApplicationIsQuitting { get; private set; }

		public RectTransform RectTransform => null;

		public Canvas Canvas => null;

		public DetectedOrientation CurrentOrientation => default(DetectedOrientation);

		private bool DebugComponent => false;

		protected OrientationDetector()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RunOnStart()
		{
		}

		private void Reset()
		{
		}

		private void OnValidate()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void OnRectTransformDimensionsChange()
		{
		}

		private void OnApplicationQuit()
		{
		}

		public void CheckDeviceOrientation(bool forceUpdate = false)
		{
		}

		public void ChangeOrientation(DetectedOrientation newOrientation, bool forceUpdate = false)
		{
		}

		private static OrientationDetector AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
