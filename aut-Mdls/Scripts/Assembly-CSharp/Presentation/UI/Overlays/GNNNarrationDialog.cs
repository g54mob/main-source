using System.Collections.Generic;
using Events.UI.Overlays;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Utils;

namespace Presentation.UI.Overlays
{
	public class GNNNarrationDialog : NarrationDialog
	{
		private static readonly int GNNGlitchStartTime = Shader.PropertyToID("_startTime");

		[Header("GNN specific")]
		[SerializeField]
		private Material _gnnTalking;

		[SerializeField]
		private Material _gnnNarratorBackground;

		[SerializeField]
		private RenderFeatureRetriever _renderFeatureRetriever;

		private List<ScriptableRendererFeature> _gnnPostProcess = new List<ScriptableRendererFeature>();

		private const string GNN_GLITCH_POST_PROCESS_NAME = "GNNGlitchPostProcess";

		protected override void UnInitialize()
		{
			base.UnInitialize();
			_gnnTalking.SetFloat(GNNGlitchStartTime, float.MaxValue);
			_gnnNarratorBackground.SetFloat(GNNGlitchStartTime, float.MaxValue);
		}

		protected override void PrepareShow(NarrationDto dto)
		{
			base.PrepareShow(dto);
			EnablePostProcess();
		}

		protected override void Hide()
		{
			DisablePostProcess();
			base.Hide();
		}

		private void EnablePostProcess()
		{
			if (_gnnPostProcess.Count == 0)
			{
				_gnnPostProcess = _renderFeatureRetriever.GetRenderFeaturesFromName("GNNGlitchPostProcess");
			}
			foreach (ScriptableRendererFeature item in _gnnPostProcess)
			{
				item.SetActive(active: true);
			}
		}

		private void DisablePostProcess()
		{
			foreach (ScriptableRendererFeature item in _gnnPostProcess)
			{
				item.SetActive(active: false);
			}
		}

		protected override void StartNarrationAnim()
		{
			base.StartNarrationAnim();
			_gnnTalking.SetFloat(GNNGlitchStartTime, Time.time);
			_gnnNarratorBackground.SetFloat(GNNGlitchStartTime, Time.time);
			_audioManagerLocator?.AudioManager.StartGNNTalkLoop();
		}

		protected override bool CanShow(NarrationDto dto)
		{
			return dto.NarratorType == NarrationDto.Narrators.GNN;
		}
	}
}
