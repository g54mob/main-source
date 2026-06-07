using UnityEngine;

namespace WaveHarmonic.Crest.Editor
{
	[AddComponentMenu("")]
	internal sealed class RenderPipelineTerrainPatcher : RenderPipelinePatcher
	{
		[SerializeField]
		private Material _Material;

		[SerializeField]
		private Material _MaterialHDRP;

		[SerializeField]
		private Material _MaterialURP;
	}
}
