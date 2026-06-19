using System;
using UnityEngine;

[CreateAssetMenu(fileName = "VertexColorBakeConfig", menuName = "Rendering/Vertex Color Bake Config", order = 1)]
public class VertexColorBakeConfig : ScriptableObject
{
	[Serializable]
	public enum OutputType
	{
		Keep = 0,
		Curvature = 1,
		Occlusion = 2
	}

	public GameObject targetObject;

	[Space(10f)]
	[Range(16f, 512f)]
	public int sampleCount = 64;

	[Min(0f)]
	public float surfaceBias = 1E-06f;

	[Header("Channel Output")]
	public OutputType redChannel = OutputType.Curvature;

	public OutputType greenChannel = OutputType.Occlusion;

	public OutputType blueChannel;

	public OutputType alphaChannel;

	[Header("Curvature Parameters")]
	[Min(0f)]
	public float curvatureMaxDist = 0.01f;

	public Vector2 curvatureRange = new Vector2(0f, 1f);

	[Header("Occlusion Parameters")]
	[Min(0f)]
	public float occlusionMaxDist = 1f;

	[Range(0f, 1f)]
	public float occlusionRayBias = 0.01f;

	[Range(0f, 10f)]
	public float occlusionExponent = 2f;

	public bool explicitOutput => true;

	public Vector4 curvatureChannels => new Vector4((redChannel == OutputType.Curvature) ? 1 : 0, (greenChannel == OutputType.Curvature) ? 1 : 0, (blueChannel == OutputType.Curvature) ? 1 : 0, (alphaChannel == OutputType.Curvature) ? 1 : 0);

	public Vector4 occlusionChannels => new Vector4((redChannel == OutputType.Occlusion) ? 1 : 0, (greenChannel == OutputType.Occlusion) ? 1 : 0, (blueChannel == OutputType.Occlusion) ? 1 : 0, (alphaChannel == OutputType.Occlusion) ? 1 : 0);

	private void OnValidate()
	{
		curvatureRange.x = Mathf.Clamp01(curvatureRange.x);
		curvatureRange.y = Mathf.Clamp01(curvatureRange.y);
	}
}
