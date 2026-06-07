using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[AddComponentMenu("Curvy/Converters/Curvy Spline To Edge Collider 2D")]
	[RequireComponent(typeof(EdgeCollider2D))]
	[HelpURL("https://curvyeditor.com/doclink/edgecollider2d")]
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
