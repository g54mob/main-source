using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class HighlightRenderer : MonoBehaviour, IHighlightReconnect
	{
		public GameObject[] layers;

		public Renderer[] renderers;

		private Highlightable highlightable;

		private LayerMask[] defaultLayers;

		private Renderer[] layersRenderers;

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

		public bool ActivateRenderers(List<Highlight> highlights)
		{
			return false;
		}
	}
}
