using System.Collections.Generic;
using UnityEngine;

public static class RuntimePreviewGenerator
{
	private struct ProjectionPlane
	{
		private readonly Vector3 m_Normal;

		private readonly float m_Distance;

		public ProjectionPlane(Vector3 inNormal, Vector3 inPoint)
		{
			m_Normal = default(Vector3);
			m_Distance = 0f;
		}

		public Vector3 ClosestPointOnPlane(Vector3 point)
		{
			return default(Vector3);
		}

		public float GetDistanceToPoint(Vector3 point)
		{
			return 0f;
		}
	}

	private class CameraSetup
	{
		private Vector3 position;

		private Quaternion rotation;

		private RenderTexture targetTexture;

		private Color backgroundColor;

		private bool orthographic;

		private float orthographicSize;

		private float nearClipPlane;

		private float farClipPlane;

		private float aspect;

		private CameraClearFlags clearFlags;

		public void GetSetup(Camera camera)
		{
		}

		public void ApplySetup(Camera camera)
		{
		}
	}

	private const int PREVIEW_LAYER = 22;

	private static Vector3 PREVIEW_POSITION;

	private static Camera renderCamera;

	private static CameraSetup cameraSetup;

	private static List<Renderer> renderersList;

	private static List<int> layersList;

	private static float aspect;

	private static float minX;

	private static float maxX;

	private static float minY;

	private static float maxY;

	private static float maxDistance;

	private static Vector3 boundsCenter;

	private static ProjectionPlane projectionPlaneHorizontal;

	private static ProjectionPlane projectionPlaneVertical;

	private static Camera m_internalCamera;

	private static Camera m_previewRenderCamera;

	private static Vector3 m_previewDirection;

	private static float m_padding;

	private static Color m_backgroundColor;

	private static bool m_orthographicMode;

	private static bool m_transparentBackground;

	public static bool setMaterialOnClonedObject;

	public static float forcedAspect;

	private static Camera InternalCamera => null;

	public static Camera PreviewRenderCamera
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public static Vector3 PreviewDirection
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public static float Padding
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public static Color BackgroundColor
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public static bool OrthographicMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool TransparentBackground
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	static RuntimePreviewGenerator()
	{
	}

	public static Texture2D GenerateMaterialPreview(Material material, PrimitiveType previewObject, int width = 64, int height = 64)
	{
		return null;
	}

	public static Texture2D GenerateMaterialPreviewWithShader(Material material, PrimitiveType previewPrimitive, Shader shader, string replacementTag, int width = 64, int height = 64)
	{
		return null;
	}

	public static Texture2D GenerateModelPreview(Transform model, int width = 64, int height = 64, bool shouldCloneModel = false)
	{
		return null;
	}

	public static Texture2D GenerateModelPreviewWithShader(Transform model, Shader shader, string replacementTag, int width = 64, int height = 64, bool shouldCloneModel = false)
	{
		return null;
	}

	private static void SetupCamera()
	{
	}

	private static void ProjectBoundingBoxMinMax(Vector3 point)
	{
	}

	private static void CalculateMaxDistance(Vector3 point)
	{
	}

	private static bool IsStatic(Transform obj)
	{
		return false;
	}

	private static void SetLayerRecursively(Transform obj)
	{
	}

	private static void GetLayerRecursively(Transform obj)
	{
	}

	private static void SetLayerRecursively(Transform obj, ref int index)
	{
	}
}
