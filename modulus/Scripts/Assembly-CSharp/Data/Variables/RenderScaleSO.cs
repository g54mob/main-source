using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/Settings/RenderScale", fileName = "RenderScale", order = 0)]
	public class RenderScaleSO : VariableSO<int>
	{
		private List<float> _renderScales = new List<float> { 0.5f, 1f, 1.5f, 2f };

		public override void SetValue(int index)
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (universalRenderPipelineAsset != null && index != Value)
			{
				float renderScale = _renderScales[index];
				universalRenderPipelineAsset.renderScale = renderScale;
			}
			base.SetValue(index);
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
