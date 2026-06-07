using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public abstract class PersistentLod : Lod
	{
		private new static class ShaderIDs
		{
			public static readonly int s_SimDeltaTime = Shader.PropertyToID("_Crest_SimDeltaTime");

			public static readonly int s_TemporaryPersistentTarget = Shader.PropertyToID("_Crest_TemporaryPersistentTarget");
		}

		private sealed class AdditionalCameraData
		{
			public RenderTexture _PersistentData;

			public float _TimeToSimulate;
		}

		[Tooltip("Frequency to run the simulation, in updates per second.\n\nLower frequencies are more efficient but may lead to visible jitter or slowness.")]
		[SerializeField]
		private protected int _SimulationFrequency = 60;

		private protected bool _NeedsPrewarmingThisStep = true;

		private protected float _TimeToSimulate;

		private protected RenderTexture _PersistentDataTexture;

		private readonly Dictionary<Camera, AdditionalCameraData> _AdditionalCameraData = new Dictionary<Camera, AdditionalCameraData>();

		private protected override bool NeedToReadWriteTextureData => true;

		internal override int BufferCount => 2;

		internal int LastUpdateSubstepCount { get; private set; }

		private protected virtual int Kernel => 0;

		private protected virtual bool SkipFlipBuffers => false;

		private protected abstract ComputeShader SimulationShader { get; }

		public int SimulationFrequency
		{
			get
			{
				return _SimulationFrequency;
			}
			set
			{
				_SimulationFrequency = value;
			}
		}

		internal override void Initialize()
		{
			if (SimulationShader == null)
			{
				_Valid = false;
				return;
			}
			base.Initialize();
			_NeedsPrewarmingThisStep = true;
		}

		private protected override void Allocate()
		{
			base.Allocate();
			if (_Water.IsSingleViewpointMode && base.Blur)
			{
				_PersistentDataTexture = CreateLodDataTextures("_Source");
			}
		}

		internal override void Destroy()
		{
			base.Destroy();
			if (_PersistentDataTexture != null)
			{
				_PersistentDataTexture.Release();
			}
			Helpers.Destroy(_PersistentDataTexture);
			foreach (AdditionalCameraData value in _AdditionalCameraData.Values)
			{
				RenderTexture persistentData = value._PersistentData;
				if (persistentData != null)
				{
					persistentData.Release();
				}
				Helpers.Destroy(persistentData);
			}
			_AdditionalCameraData.Clear();
		}

		internal override void BuildCommandBuffer(WaterRenderer water, CommandBuffer buffer)
		{
			buffer.BeginSample(ID);
			FlipBuffers(buffer);
			_TimeToSimulate += water.DeltaTime;
			int num = Mathf.FloorToInt(_TimeToSimulate * (float)_SimulationFrequency);
			float num2 = ((num > 0) ? (1f / (float)_SimulationFrequency) : 0f);
			LastUpdateSubstepCount = num;
			if (num == 0)
			{
				num = 1;
				num2 = 0f;
			}
			bool flag = _Water.IsSingleViewpointMode && !base.Blur;
			if (flag)
			{
				buffer.GetTemporaryRT(ShaderIDs.s_TemporaryPersistentTarget, base.DataTexture.descriptor);
				CoreUtils.SetRenderTarget(buffer, ShaderIDs.s_TemporaryPersistentTarget, ClearFlag.Color, ClearColor);
			}
			RenderTargetIdentifier renderTargetIdentifier = new RenderTargetIdentifier(base.DataTexture);
			RenderTargetIdentifier renderTargetIdentifier2 = (flag ? new RenderTargetIdentifier(ShaderIDs.s_TemporaryPersistentTarget) : renderTargetIdentifier);
			RenderTargetIdentifier renderTargetIdentifier3 = (flag ? renderTargetIdentifier : new RenderTargetIdentifier(_PersistentDataTexture));
			PropertyWrapperCompute additionalSimulationParameters = new PropertyWrapperCompute(buffer, SimulationShader, Kernel);
			for (int i = 0; i < num; i++)
			{
				bool flag2 = i == 0;
				int framesBack = (flag2 ? 1 : 0);
				_TimeToSimulate -= num2;
				if (!flag2)
				{
					RenderTargetIdentifier renderTargetIdentifier4 = renderTargetIdentifier2;
					RenderTargetIdentifier renderTargetIdentifier5 = renderTargetIdentifier3;
					renderTargetIdentifier3 = renderTargetIdentifier4;
					renderTargetIdentifier2 = renderTargetIdentifier5;
				}
				else
				{
					_NeedsPrewarmingThisStep = _NeedsPrewarmingThisStep || _Water._HasTeleportedThisFrame;
				}
				buffer.SetGlobalFloat(ShaderIDs.s_SimDeltaTime, num2);
				additionalSimulationParameters.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Source, renderTargetIdentifier3);
				additionalSimulationParameters.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, renderTargetIdentifier2);
				additionalSimulationParameters.SetFloat(Lod.ShaderIDs.s_LodChange, flag2 ? _Water.ScaleDifferencePower2 : 0);
				additionalSimulationParameters.SetVectorArray(WaterRenderer.ShaderIDs.s_CascadeDataSource, _Water.CascadeData.Previous(framesBack));
				additionalSimulationParameters.SetVectorArray(_SamplingParametersCascadeSourceShaderID, _SamplingParameters.Previous(framesBack));
				SetAdditionalSimulationParameters(additionalSimulationParameters);
				int num3 = base.Resolution / 8;
				additionalSimulationParameters.Dispatch(num3, num3, base.Slices);
				if (num2 > 0f)
				{
					SubmitDraws(buffer, Inputs, renderTargetIdentifier2);
				}
				_NeedsPrewarmingThisStep = false;
			}
			if (renderTargetIdentifier2 != renderTargetIdentifier)
			{
				buffer.CopyTexture(renderTargetIdentifier2, renderTargetIdentifier);
			}
			else if (!flag)
			{
				buffer.CopyTexture(renderTargetIdentifier2, renderTargetIdentifier3);
			}
			if (flag)
			{
				buffer.ReleaseTemporaryRT(ShaderIDs.s_TemporaryPersistentTarget);
			}
			TryBlur(buffer);
			buffer.EndSample(ID);
		}

		private protected virtual void SetAdditionalSimulationParameters(PropertyWrapperCompute properties)
		{
		}

		private protected override void ReAllocate()
		{
			base.ReAllocate();
			if (!base.Enabled)
			{
				return;
			}
			RenderTextureDescriptor descriptor = base.DataTexture.descriptor;
			if (_Water.IsMultipleViewpointMode)
			{
				foreach (KeyValuePair<Camera, AdditionalCameraData> additionalCameraDatum in _AdditionalCameraData)
				{
					additionalCameraDatum.Deconstruct(out var _, out var value);
					RenderTexture persistentData = value._PersistentData;
					persistentData.Release();
					persistentData.descriptor = descriptor;
					persistentData.Create();
				}
				return;
			}
			if (_PersistentDataTexture != null)
			{
				_PersistentDataTexture.Release();
				if (base.Blur)
				{
					_PersistentDataTexture.descriptor = descriptor;
					_PersistentDataTexture.Create();
				}
				else
				{
					Helpers.Destroy(_PersistentDataTexture);
				}
			}
			else if (base.Blur)
			{
				_PersistentDataTexture = CreateLodDataTextures("_Source");
			}
		}

		internal override void LoadCameraData(Camera camera)
		{
			base.LoadCameraData(camera);
			AdditionalCameraData additionalCameraData;
			if (!_AdditionalCameraData.ContainsKey(camera))
			{
				additionalCameraData = new AdditionalCameraData
				{
					_PersistentData = CreateLodDataTextures("_Source"),
					_TimeToSimulate = _TimeToSimulate
				};
				_AdditionalCameraData.Add(camera, additionalCameraData);
			}
			else
			{
				additionalCameraData = _AdditionalCameraData[camera];
			}
			_PersistentDataTexture = additionalCameraData._PersistentData;
			_TimeToSimulate = additionalCameraData._TimeToSimulate;
		}

		internal override void StoreCameraData(Camera camera)
		{
			base.StoreCameraData(camera);
			if (_AdditionalCameraData.ContainsKey(camera))
			{
				_AdditionalCameraData[camera]._TimeToSimulate = _TimeToSimulate;
			}
		}

		internal override void RemoveCameraData(Camera camera)
		{
			base.RemoveCameraData(camera);
			if (_AdditionalCameraData.ContainsKey(camera))
			{
				RenderTexture persistentData = _AdditionalCameraData[camera]._PersistentData;
				if (persistentData != null)
				{
					persistentData.Release();
				}
				Helpers.Destroy(persistentData);
				_AdditionalCameraData.Remove(camera);
			}
		}
	}
}
