using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Components
{
	[AddComponentMenu("Curvy/Converters/Curvy Line Renderer")]
	[HelpURL("https://curvyeditor.com/doclink/curvylinerenderer")]
	[RequireComponent(typeof(LineRenderer))]
	public class CurvyLineRenderer : SplineProcessor
	{
		public const string ComponentPath = "Curvy/Converters/Curvy Line Renderer";

		private LineRenderer cachedLineRenderer;

		private LineRenderer LineRenderer => null;

		[UsedImplicitly]
		private void Update()
		{
		}

		private void EnforceWorldSpaceUsage()
		{
		}

		public override void Refresh()
		{
		}
	}
}
