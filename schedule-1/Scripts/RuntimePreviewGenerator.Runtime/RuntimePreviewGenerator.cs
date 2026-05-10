using System;
using System.Collections.Generic;
using UnityEngine;

public static class RuntimePreviewGenerator
{
	private class CameraSetup
	{
		private Vector3 position;

		private Quaternion rotation;

		private Color backgroundColor;

		private bool orthographic;

		private float orthographicSize;

		private float nearClipPlane;

		private float farClipPlane;

		private float aspect;

		private int cullingMask;

		private CameraClearFlags clearFlags;

		private RenderTexture targetTexture;

		public void GetSetup(Camera camera)
		{
		}

		public void ApplySetup(Camera camera)
		{
		}
	}

	private const int PREVIEW_LAYER = 20;

	private static Vector3 PREVIEW_POSITION;

	private static Camera renderCamera;

	private static readonly CameraSetup cameraSetup;

	private static readonly Vector3[] boundingBoxPoints;

	private static readonly Vector3[] localBoundsMinMax;

	private static readonly List<Renderer> renderersList;

	private static readonly List<int> layersList;

	private static Camera m_internalCamera;

	public static Vector3 CamPos;

	public static Quaternion CamRot;

	private static Camera m_previewRenderCamera;

	private static Vector3 m_previewDirection;

	private static float m_padding;

	private static Color m_backgroundColor;

	private static bool m_orthographicMode;

	private static bool m_useLocalBounds;

	private static float m_renderSupersampling;

	private static bool m_markTextureNonReadable;

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

	public static bool UseLocalBounds
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static float RenderSupersampling
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public static bool MarkTextureNonReadable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static Texture2D GenerateMaterialPreview(Material material, PrimitiveType previewPrimitive, int width = 64, int height = 64)
	{
		return null;
	}

	public static Texture2D GenerateMaterialPreviewWithShader(Material material, PrimitiveType previewPrimitive, Shader shader, string replacementTag, int width = 64, int height = 64)
	{
		return null;
	}

	public static void GenerateMaterialPreviewAsync(Action<Texture2D> callback, Material material, PrimitiveType previewPrimitive, int width = 64, int height = 64)
	{
	}

	public static void GenerateMaterialPreviewWithShaderAsync(Action<Texture2D> callback, Material material, PrimitiveType previewPrimitive, Shader shader, string replacementTag, int width = 64, int height = 64)
	{
	}

	private static Texture2D GenerateMaterialPreviewInternal(Material material, PrimitiveType previewPrimitive, Shader shader, string replacementTag, int width, int height, Action<Texture2D> asyncCallback = null)
	{
		return null;
	}

	public static Texture2D GenerateModelPreview(Transform model, int width = 64, int height = 64, bool shouldCloneModel = false, bool shouldIgnoreParticleSystems = true)
	{
		return null;
	}

	public static Texture2D GenerateModelPreviewWithShader(Transform model, Shader shader, string replacementTag, int width = 64, int height = 64, bool shouldCloneModel = false, bool shouldIgnoreParticleSystems = true)
	{
		return null;
	}

	public static void GenerateModelPreviewAsync(Action<Texture2D> callback, Transform model, int width = 64, int height = 64, bool shouldCloneModel = false, bool shouldIgnoreParticleSystems = true)
	{
	}

	public static void GenerateModelPreviewWithShaderAsync(Action<Texture2D> callback, Transform model, Shader shader, string replacementTag, int width = 64, int height = 64, bool shouldCloneModel = false, bool shouldIgnoreParticleSystems = true)
	{
	}

	private static Texture2D GenerateModelPreviewInternal(Transform model, Shader shader, string replacementTag, int width, int height, bool shouldCloneModel, bool shouldIgnoreParticleSystems, Action<Texture2D> asyncCallback = null)
	{
		return null;
	}

	public static bool CalculateBounds(Transform target, bool shouldIgnoreParticleSystems, Quaternion cameraRotation, out Bounds bounds)
	{
		bounds = default(Bounds);
		return false;
	}

	public static void CalculateCameraPosition(Camera camera, Bounds bounds, float padding = 0f)
	{
	}

	private static bool IsOutermostPointInDirection(int pointIndex, Vector3 direction)
	{
		return false;
	}

	private static Ray GetPlanesIntersection(Plane p1, Plane p2)
	{
		return default(Ray);
	}

	private static void FindClosestPointsOnTwoLines(Ray line1, Ray line2, out Vector3 closestPointLine1, out Vector3 closestPointLine2)
	{
		closestPointLine1 = default(Vector3);
		closestPointLine2 = default(Vector3);
	}

	private static void SetupCamera()
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
