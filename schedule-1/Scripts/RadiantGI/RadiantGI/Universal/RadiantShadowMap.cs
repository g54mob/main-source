using UnityEngine;

namespace RadiantGI.Universal
{
	[ExecuteInEditMode]
	public class RadiantShadowMap : MonoBehaviour
	{
		private static class ShaderParams
		{
			public static int RadiantShadowMapColors;

			public static int RadiantShadowMapNormals;

			public static int RadiantShadowMapWorldPos;

			public static int RadiantWorldToShadowMap;

			public static int ClipToWorld;

			public static int ClipDir;

			public static int FarClipPlane;
		}

		public enum ShadowMapResolution
		{
			[InspectorName("64")]
			_64 = 0,
			[InspectorName("128")]
			_128 = 1,
			[InspectorName("256")]
			_256 = 2,
			[InspectorName("512")]
			_512 = 3,
			[InspectorName("1024")]
			_1024 = 4,
			[InspectorName("2048")]
			_2048 = 5
		}

		private const string RADIANT_GO_NAME = "RadiantGI Capture Camera";

		public static bool installed;

		public Transform target;

		[Tooltip("The capture extents around target")]
		public float targetCaptureSize;

		public ShadowMapResolution resolution;

		private Light thisLight;

		public Camera captureCamera;

		private Material captureMat;

		private Quaternion lastRotation;

		private Vector3 lastTargetPos;

		private float lastCaptureSize;

		public RenderTexture rtColors;

		public RenderTexture rtWorldPos;

		public RenderTexture rtNormals;

		private bool needShoot;

		private void OnEnable()
		{
		}

		private void OnValidate()
		{
		}

		private void OnDestroy()
		{
		}

		private void Remove()
		{
		}

		private void SetupCamera()
		{
		}

		private void LateUpdate()
		{
		}

		private void CaptureScene()
		{
		}

		private void DestroyRT(RenderTexture rt)
		{
		}
	}
}
