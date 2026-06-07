using System;
using UnityEngine;

namespace Brewery.Map.V2
{
	[Serializable]
	public class TerrainSurfaceStyle
	{
		[Tooltip("Terrain layer indices for this group")]
		public int[] layerIndices;

		[Header("Fill")]
		[Tooltip("Fill color on the cartographic map")]
		public Color fillColor;

		[Tooltip("Fill opacity (0 = invisible, 1 = solid)")]
		[Range(0f, 1f)]
		public float fillStrength;

		[Tooltip("How much to suppress contour lines (0 = keep, 1 = erase)")]
		[Range(0f, 1f)]
		public float contourSuppression;

		[Header("Edge Outlines")]
		[Tooltip("Edge outline color at the splatmap boundary")]
		public Color edgeColor;

		[Tooltip("Where in the splatmap blend the edge line appears (higher = thicker)")]
		[Range(0.01f, 0.5f)]
		public float edgeThreshold;

		[Header("Dashed Center Line")]
		[Tooltip("Draw a dashed line through the center of the surface area")]
		public bool dashedLine;

		[Tooltip("Dash line color")]
		public Color dashColor;

		[Tooltip("Dash length in world units")]
		[Range(0.5f, 20f)]
		public float dashLength;

		[Tooltip("Gap between dashes in world units")]
		[Range(0.1f, 10f)]
		public float dashGap;

		[Tooltip("Dash direction angle in degrees (0 = east, 90 = north)")]
		[Range(0f, 180f)]
		public float dashAngle;

		[Header("Hatching")]
		[Tooltip("Draw parallel hatch lines inside the area")]
		public bool hatching;

		[Tooltip("Hatch line color")]
		public Color hatchColor;

		[Tooltip("Spacing between hatch lines in world units")]
		[Range(0.5f, 30f)]
		public float hatchSpacing;

		[Tooltip("Hatch line angle in degrees (0 = east, 90 = north)")]
		[Range(0f, 180f)]
		public float hatchAngle;

		[Tooltip("Hatch line thickness (fraction of spacing)")]
		[Range(0.01f, 0.2f)]
		public float hatchThickness;
	}
}
