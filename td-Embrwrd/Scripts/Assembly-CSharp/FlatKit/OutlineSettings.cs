using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FlatKit
{
	[CreateAssetMenu(fileName = "OutlineSettings", menuName = "FlatKit/Outline Settings")]
	public class OutlineSettings : ScriptableObject
	{
		public Color edgeColor;

		[Range(0f, 5f)]
		public int thickness;

		[Tooltip("If enabled, the line width will stay constant regardless of the rendering resolution. However, some of the lines may appear blurry.")]
		public bool resolutionInvariant;

		[Space]
		public bool useDepth;

		public bool useNormals;

		public bool useColor;

		[Header("Advanced settings")]
		public float minDepthThreshold;

		public float maxDepthThreshold;

		[Space]
		public float minNormalsThreshold;

		public float maxNormalsThreshold;

		[Space]
		public float minColorThreshold;

		public float maxColorThreshold;

		[Tooltip("The render stage at which the effect is applied. To exclude transparent objects, like water or UI elements, set this to \"Before Transparent\".")]
		[Space]
		public RenderPassEvent renderEvent;

		[Space]
		public bool outlineOnly;

		private void OnValidate()
		{
		}
	}
}
