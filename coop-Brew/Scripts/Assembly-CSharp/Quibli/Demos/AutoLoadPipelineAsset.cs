using UnityEngine;
using UnityEngine.Rendering;

namespace Quibli.Demos
{
	[ExecuteAlways]
	public class AutoLoadPipelineAsset : MonoBehaviour
	{
		[SerializeField]
		private RenderPipelineAsset pipelineAsset;

		private RenderPipelineAsset _previousPipelineAsset;

		private bool _overrodeQualitySettings;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnValidate()
		{
		}

		private void UpdatePipeline()
		{
		}

		private void ResetPipeline()
		{
		}
	}
}
