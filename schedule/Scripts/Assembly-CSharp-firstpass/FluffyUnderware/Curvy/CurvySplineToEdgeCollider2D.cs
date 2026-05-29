using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[HelpURL("https://curvyeditor.com/doclink/edgecollider2d")]
	[RequireComponent(typeof(EdgeCollider2D))]
	[AddComponentMenu("Curvy/Converters/Curvy Spline To Edge Collider 2D")]
	public class CurvySplineToEdgeCollider2D : SplineProcessor
	{
		public const string ComponentPath = "Curvy/Converters/Curvy Spline To Edge Collider 2D";

		private EdgeCollider2D cachedEdgeCollider2D;

		private EdgeCollider2D EdgeCollider => null;

		public override void Refresh()
		{
		}
	}
}
