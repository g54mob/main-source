using UnityEngine;

namespace AmazingAssets.AdvancedDissolve
{
	[ExecuteAlways]
	public class AdvancedDissolveKeywordsController : AdvancedDissolveController
	{
		public AdvancedDissolveKeywords.State state;

		private int previousState;

		public AdvancedDissolveKeywords.CutoutStandardSource cutoutStandardSource;

		private int previousCutoutStandardSource;

		public AdvancedDissolveKeywords.CutoutStandardSourceMapsMappingType cutoutStandardSourceMapsMappingType;

		private int previousCutoutStandardSourceMapsMappingType;

		public AdvancedDissolveKeywords.CutoutGeometricType cutoutGeometricType;

		private int previousCutoutGeometricType;

		public AdvancedDissolveKeywords.CutoutGeometricCount cutoutGeometricCount;

		private int previousCutoutGeometricCount;

		public AdvancedDissolveKeywords.EdgeBaseSource edgeBaseSource;

		private int previousEdgeBaseSource;

		public AdvancedDissolveKeywords.EdgeAdditionalColorSource edgeAdditionalColorSource;

		private int previousEdgeAdditionalColorSource;

		public AdvancedDissolveKeywords.EdgeUVDistortionSource edgeUVDistortionSource;

		private int previousEdgeUVDistortionSource;

		private int previousGlobalControlID;

		protected override void Awake()
		{
		}

		protected override void Update()
		{
		}

		[ContextMenu("Force Update Keywords Controller")]
		public override void ForceUpdateShaderData()
		{
		}

		[ContextMenu("Reset Keywords Controller")]
		public override void ResetShaderData()
		{
		}
	}
}
