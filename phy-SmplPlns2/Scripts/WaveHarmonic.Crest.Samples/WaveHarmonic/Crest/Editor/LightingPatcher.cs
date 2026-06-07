using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Editor
{
	[AddComponentMenu("")]
	[DefaultExecutionOrder(-1000)]
	[ExecuteAlways]
	internal sealed class LightingPatcher : CustomBehaviour
	{
		[HideInInspector]
		[SerializeField]
		private bool _LightsUseLinearIntensity;

		[HideInInspector]
		[SerializeField]
		private bool _LightsUseColorTemperature;

		private bool _CurrentLightsUseLinearIntensity;

		private bool _CurrentLightsUseColorTemperature;

		private protected override void OnEnable()
		{
			base.OnEnable();
			if (RenderPipelineHelper.IsLegacy)
			{
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(OnBeginRendering));
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(OnBeginRendering));
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(OnEndRendering));
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(OnEndRendering));
			}
			else
			{
				RenderPipelineManager.beginContextRendering -= OnBeginContextRendering;
				RenderPipelineManager.beginContextRendering += OnBeginContextRendering;
				RenderPipelineManager.endContextRendering -= OnEndContextRendering;
				RenderPipelineManager.endContextRendering += OnEndContextRendering;
			}
			_CurrentLightsUseLinearIntensity = GraphicsSettings.lightsUseLinearIntensity;
			_CurrentLightsUseColorTemperature = GraphicsSettings.lightsUseColorTemperature;
		}

		private void OnDisable()
		{
			if (RenderPipelineHelper.IsLegacy)
			{
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(OnBeginRendering));
				Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(OnEndRendering));
			}
			else
			{
				RenderPipelineManager.beginContextRendering -= OnBeginContextRendering;
				RenderPipelineManager.endContextRendering -= OnEndContextRendering;
			}
		}

		private void OnBeginContextRendering(ScriptableRenderContext context, List<Camera> cameras)
		{
			ChangeLighting();
		}

		private void OnEndContextRendering(ScriptableRenderContext context, List<Camera> cameras)
		{
			RestoreLighting();
		}

		private void OnBeginRendering(Camera camera)
		{
			ChangeLighting();
		}

		private void OnEndRendering(Camera camera)
		{
			RestoreLighting();
		}

		private void ChangeLighting()
		{
			_CurrentLightsUseLinearIntensity = GraphicsSettings.lightsUseLinearIntensity;
			_CurrentLightsUseColorTemperature = GraphicsSettings.lightsUseColorTemperature;
			GraphicsSettings.lightsUseLinearIntensity = true;
			GraphicsSettings.lightsUseColorTemperature = true;
		}

		private void RestoreLighting()
		{
			GraphicsSettings.lightsUseLinearIntensity = _CurrentLightsUseLinearIntensity;
			GraphicsSettings.lightsUseColorTemperature = _CurrentLightsUseColorTemperature;
		}
	}
}
