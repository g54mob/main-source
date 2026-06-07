using UnityEngine;

namespace WaveHarmonic.Crest.Editor
{
	[AddComponentMenu("")]
	internal sealed class RenderPipelineSettingsPatcher : RenderPipelinePatcher
	{
		[SerializeField]
		private Material _SkyBox;
	}
}
