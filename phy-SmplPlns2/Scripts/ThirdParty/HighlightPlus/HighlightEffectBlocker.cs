using UnityEngine;
using UnityEngine.Rendering;

namespace HighlightPlus
{
	[DefaultExecutionOrder(100)]
	[ExecuteInEditMode]
	public class HighlightEffectBlocker : MonoBehaviour
	{
		private Renderer thisRenderer;

		public bool blockOutlineAndGlow;

		public bool blockOverlay;

		private void OnEnable()
		{
			thisRenderer = GetComponentInChildren<Renderer>();
			HighlightPlusRenderPassFeature.RegisterBlocker(this);
		}

		private void OnDisable()
		{
			HighlightPlusRenderPassFeature.UnregisterBlocker(this);
		}

		public void BuildCommandBuffer(CommandBuffer cmd, Material mat)
		{
			if (!(thisRenderer == null))
			{
				cmd.DrawRenderer(thisRenderer, mat);
			}
		}
	}
}
