using System.Collections.Generic;
using UnityEngine;

namespace Aura2API
{
	public class DirectionalLightsManager
	{
		public static readonly Vector2Int cookieMapSize = new Vector2Int(256, 256);

		private static readonly Vector2Int _shadowMapSizeOneCascade = new Vector2Int(256, 256);

		private static readonly Vector2Int _shadowMapSizeTwoCascades = new Vector2Int(_shadowMapSizeOneCascade.x * 2, _shadowMapSizeOneCascade.y);

		private static readonly Vector2Int _shadowMapSizeFourCascades = new Vector2Int(_shadowMapSizeOneCascade.x * 2, _shadowMapSizeOneCascade.y * 2);

		private DirectionalLightParameters[] _parameters;

		private ComputeBuffer _emptyBuffer;

		public static Vector2Int ShadowMapSize => QualitySettings.shadowCascades switch
		{
			4 => _shadowMapSizeFourCascades, 
			2 => _shadowMapSizeTwoCascades, 
			_ => _shadowMapSizeOneCascade, 
		};

		public List<AuraLight> CandidateLights => AuraCamera.CommonDataManager.LightsCommonDataManager.RegisteredDirectionalLightsList;

		public int CandidateLightsCount => CandidateLights.Count;

		public bool HasCandidateLights => CandidateLightsCount > 0;

		public ComputeBuffer EmptyBuffer
		{
			get
			{
				if (_emptyBuffer == null)
				{
					_emptyBuffer = new ComputeBuffer(1, DirectionalLightParameters.Size);
				}
				return _emptyBuffer;
			}
		}

		public ComputeBuffer DataBuffer { get; private set; }

		public void Dispose()
		{
			ReleaseBuffer();
			if (_emptyBuffer != null)
			{
				_emptyBuffer.Release();
				_emptyBuffer = null;
			}
		}

		private void SetupBuffers()
		{
			if (DataBuffer == null || DataBuffer.count != CandidateLightsCount)
			{
				ReleaseBuffer();
				SetupBuffer();
			}
			if (_parameters == null || _parameters.Length != CandidateLightsCount)
			{
				SetupParametersArray();
			}
		}

		private void SetupParametersArray()
		{
			_parameters = new DirectionalLightParameters[CandidateLightsCount];
		}

		private void ReleaseBuffer()
		{
			if (DataBuffer != null)
			{
				DataBuffer.Release();
				DataBuffer = null;
			}
		}

		private void SetupBuffer()
		{
			if (HasCandidateLights)
			{
				DataBuffer = new ComputeBuffer(CandidateLightsCount, DirectionalLightParameters.Size);
			}
		}

		public void Update()
		{
			SetupBuffers();
			if (HasCandidateLights)
			{
				for (int i = 0; i < CandidateLightsCount; i++)
				{
					_parameters[i] = CandidateLights[i].GetDirectionnalParameters();
				}
				DataBuffer.SetData(_parameters);
			}
		}
	}
}
