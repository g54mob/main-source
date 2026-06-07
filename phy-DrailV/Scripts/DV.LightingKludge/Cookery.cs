using UnityEngine;

public class Cookery : MonoBehaviour
{
	public enum MSAAMode
	{
		Disabled = 0,
		MSAA2x = 2,
		MSAA4x = 4,
		MSAA8x = 8
	}

	public const string OUTPUT_SLICE_TAG = "NoStreaming";

	public const string OUTPUT_VOLUME_TAG = "NoStreaming";

	public const string OUTPUT_MATERIAL_TAG = "";

	public const string IGNORE_OBJECT_TAG = "SkipLightBake";

	private const string COOKERY_BASE_DIR = "Packages/com.derailvalley.cookery/Runtime/";

	public Bounds bounds = new Bounds(Vector3.zero, Vector3.one);

	[Header("Volume parameters")]
	[Range(16f, 2048f)]
	public int resX = 256;

	[Range(1f, 16f)]
	public int resY = 4;

	[Range(16f, 2048f)]
	public int resZ = 256;

	[Range(0f, 1f)]
	public float linearity;

	public Vector2 verticalPadding = Vector2.up;

	[Tooltip("Eligible for selection for components that require a single large/semi-global volume")]
	public bool largeScale = true;

	[Tooltip("Objects and sub-objects from this list will not contribute light nor occlusion")]
	public GameObject[] exclusionList;

	[Tooltip("Only objects and sub-objects from this list will contribute light and occlusion")]
	public GameObject[] inclusionList;

	[Header("Lighting parameters")]
	[Range(1f, 1000f)]
	public float intensityScale = 500f;

	[Range(0f, 2f)]
	public float directionalityScale = 1f;

	[Range(0f, 2f)]
	public float emissiveScale = 0.5f;

	[Range(0.1f, 1f)]
	public float fadeRange = 0.25f;

	public bool excludeShadowCasters = true;

	[Header("Quality")]
	[Range(8f, 128f)]
	public int probeResolution = 64;

	public MSAAMode MSAA = MSAAMode.MSAA8x;

	[Header("Denoising")]
	[Range(0f, 1f)]
	public float denoisingBlend = 1f;

	[Range(0.1f, 16f)]
	public float denoisingRadius = 3f;

	[Range(0f, 1f)]
	public float colorDenoisingStrength = 0.075f;

	[Range(0f, 1f)]
	public float normalDenoisingStrength = 0.05f;

	private Vector3 center;

	private Vector3 bottomAA;

	private Vector3 sizeX;

	private Vector3 sizeY;

	private Vector3 sizeZ;

	private float[] layerPositions;

	private string lightingDataPath = "";

	private bool batchMode;

	private static readonly int sp_ViewMatrix = Shader.PropertyToID("_COOKERY_viewMatrix");

	private static readonly int sp_ProjectionMatrix = Shader.PropertyToID("_COOKERY_projectionMatrix");

	private void ComputeBounds()
	{
		center = bounds.center;
		bottomAA = center - bounds.size * 0.5f;
		sizeX = Vector3.right * bounds.size.x;
		sizeY = Vector3.up * bounds.size.y;
		sizeZ = Vector3.forward * bounds.size.z;
		center = base.transform.TransformPoint(center);
		bottomAA = base.transform.TransformPoint(bottomAA);
		sizeX = base.transform.TransformDirection(sizeX);
		sizeY = base.transform.TransformDirection(sizeY);
		sizeZ = base.transform.TransformDirection(sizeZ);
		if (layerPositions == null || layerPositions.Length != resY)
		{
			layerPositions = new float[resY];
		}
		float x = verticalPadding.x;
		float num = verticalPadding.y - verticalPadding.x;
		if (resY > 1)
		{
			for (int i = 0; i < resY; i++)
			{
				float num2 = ((float)i + 0.5f) / (float)resY;
				num2 = Mathf.Lerp(num2 * num2, num2, linearity);
				layerPositions[i] = x + num2 * num;
			}
		}
		else
		{
			resY = 1;
			layerPositions[0] = x;
		}
	}

	private void OnDrawGizmosSelected()
	{
		ComputeBounds();
		for (int i = 0; i < resY; i++)
		{
			Vector3 vector = bottomAA + sizeY * layerPositions[i];
			Gizmos.color = Color.Lerp(Color.red, Color.green, layerPositions[i]);
			for (int j = 0; j <= 10; j++)
			{
				Vector3 vector2 = vector + (float)j / 10f * sizeX;
				Vector3 to = vector2 + sizeZ;
				Gizmos.DrawLine(vector2, to);
			}
			for (int k = 0; k <= 10; k++)
			{
				Vector3 vector3 = vector + (float)k / 10f * sizeZ;
				Vector3 to2 = vector3 + sizeX;
				Gizmos.DrawLine(vector3, to2);
			}
		}
	}
}
