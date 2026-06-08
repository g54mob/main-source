using UnityEngine;

namespace GRP
{
	public class HighlightOverlayRenderer : MonoBehaviour, IHighlightReconnect
	{
		public Renderer[] renderers;

		private Highlightable highlightable;

		private LayerMask[] defaultLayers;

		private MaterialPropertyBlock block;

		private void Awake()
		{
		}

		public void HighlightReconnect()
		{
		}

		public void Render()
		{
		}

		public void CheckHighlight(Highlight highlight)
		{
		}

		private void Reset()
		{
		}
	}
}
