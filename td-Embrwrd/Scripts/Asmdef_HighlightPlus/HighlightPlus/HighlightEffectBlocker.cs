using UnityEngine;
using UnityEngine.Rendering;

namespace HighlightPlus
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(100)]
	public class HighlightEffectBlocker : MonoBehaviour
	{
		private Renderer thisRenderer;

		public bool blockOutlineAndGlow;

		public bool blockOverlay;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void BuildCommandBuffer(CommandBuffer cmd, Material mat)
		{
		}
	}
}
