using UnityEngine;
using UnityEngine.Rendering;

namespace Aura2API
{
	public class TextureBuffers
	{
		private Vector3Int _volumetricBuffersResolution;

		private SwappableRenderTexture _dataVolumeTexture;

		private RenderTexture _fogVolumeTexture;

		private SwappableRenderTexture _occlusionTexture;

		private SwappableRenderTexture _sliceTexture;

		private static readonly Vector3Int _lightProbesCoefficientsTextureResolution = new Vector3Int(32, 18, 16);

		private RenderTexture _lightProbesCoefficientsTexture;

		private SphericalHarmonicsFirstBandCoefficients[] _lightProbesCoefficients;

		private ComputeBuffer _lightProbesCoefficientsBuffer;

		public Vector3Int VolumetricBuffersResolution
		{
			get
			{
				return _volumetricBuffersResolution;
			}
			set
			{
				ReleaseVolumeTextureBuffers();
				ReleaseOcclusionTextureBuffer();
				ReleaseSliceTextureBuffer();
				_volumetricBuffersResolution = value;
			}
		}

		public bool VolumetricBuffersResolutionIsValid => VolumetricBuffersResolution != Vector3Int.zero;

		public Vector3Int LightProbesCoefficientsTextureResolution => _lightProbesCoefficientsTextureResolution;

		public bool LightProbesCoefficientsTextureResolutionIsValid => LightProbesCoefficientsTextureResolution != Vector3Int.zero;

		public SwappableRenderTexture DataVolumeTexture
		{
			get
			{
				if (!VolumetricBuffersResolutionIsValid)
				{
					Debug.LogError("Error while creating DataVolumeTextures buffer in \"" + this?.ToString() + "\". The resolution parameter seems not set.");
					return null;
				}
				if (_dataVolumeTexture == null)
				{
					_dataVolumeTexture = new SwappableRenderTexture(VolumetricBuffersResolution.x, VolumetricBuffersResolution.y, VolumetricBuffersResolution.z, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear, TextureWrapMode.Clamp, FilterMode.Bilinear);
				}
				return _dataVolumeTexture;
			}
		}

		public RenderTexture FogVolumeTexture
		{
			get
			{
				if (!VolumetricBuffersResolutionIsValid)
				{
					Debug.LogError("Error while creating FogVolumeTexture buffer in \"" + this?.ToString() + "\". The resolution parameter seems not set.");
					return null;
				}
				if (_fogVolumeTexture == null)
				{
					_fogVolumeTexture = new RenderTexture(VolumetricBuffersResolution.x, VolumetricBuffersResolution.y, 0, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
					_fogVolumeTexture.dimension = TextureDimension.Tex3D;
					_fogVolumeTexture.volumeDepth = VolumetricBuffersResolution.z;
					_fogVolumeTexture.wrapMode = TextureWrapMode.Clamp;
					_fogVolumeTexture.filterMode = FilterMode.Bilinear;
					_fogVolumeTexture.enableRandomWrite = true;
					_fogVolumeTexture.Create();
				}
				return _fogVolumeTexture;
			}
		}

		public SwappableRenderTexture OcclusionTexture
		{
			get
			{
				if (!VolumetricBuffersResolutionIsValid)
				{
					Debug.LogError("Error while creating OcclusionTexture buffer in \"" + this?.ToString() + "\". The resolution parameter seems not set.");
					return null;
				}
				if (_occlusionTexture == null)
				{
					_occlusionTexture = new SwappableRenderTexture(VolumetricBuffersResolution.x, VolumetricBuffersResolution.y, RenderTextureFormat.RHalf, RenderTextureReadWrite.Linear, TextureWrapMode.Clamp, FilterMode.Point);
				}
				return _occlusionTexture;
			}
		}

		public SwappableRenderTexture SliceTexture
		{
			get
			{
				if (!VolumetricBuffersResolutionIsValid)
				{
					Debug.LogError("Error while creating OcclusionTexture buffer in \"" + this?.ToString() + "\". The resolution parameter seems not set.");
					return null;
				}
				if (_sliceTexture == null)
				{
					_sliceTexture = new SwappableRenderTexture(VolumetricBuffersResolution.x, VolumetricBuffersResolution.y, RenderTextureFormat.RInt, RenderTextureReadWrite.Linear, TextureWrapMode.Clamp, FilterMode.Point);
				}
				return _sliceTexture;
			}
		}

		public RenderTexture LightProbesCoefficientsTexture
		{
			get
			{
				if (!LightProbesCoefficientsTextureResolutionIsValid)
				{
					Debug.LogError("Error while creating LightProbesCoefficientsTexture buffer in \"" + this?.ToString() + "\". The resolution parameter seems not set.");
					return null;
				}
				if (_lightProbesCoefficientsTexture == null)
				{
					_lightProbesCoefficientsTexture = new RenderTexture(LightProbesCoefficientsTextureResolution.x * 3, LightProbesCoefficientsTextureResolution.y, 0, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
					_lightProbesCoefficientsTexture.dimension = TextureDimension.Tex3D;
					_lightProbesCoefficientsTexture.volumeDepth = LightProbesCoefficientsTextureResolution.z;
					_lightProbesCoefficientsTexture.wrapMode = TextureWrapMode.Clamp;
					_lightProbesCoefficientsTexture.filterMode = FilterMode.Bilinear;
					_lightProbesCoefficientsTexture.enableRandomWrite = true;
					_lightProbesCoefficientsTexture.Create();
				}
				return _lightProbesCoefficientsTexture;
			}
		}

		public SphericalHarmonicsFirstBandCoefficients[] LightProbesCoefficients
		{
			get
			{
				if (!LightProbesCoefficientsTextureResolutionIsValid)
				{
					Debug.LogError("Error while creating LightProbesCoefficients array buffer in \"" + this?.ToString() + "\". The resolution parameter seems not set.");
					return null;
				}
				if (_lightProbesCoefficients == null)
				{
					_lightProbesCoefficients = new SphericalHarmonicsFirstBandCoefficients[LightProbesCoefficientsTextureResolution.x * LightProbesCoefficientsTextureResolution.y * LightProbesCoefficientsTextureResolution.z];
				}
				return _lightProbesCoefficients;
			}
		}

		public ComputeBuffer LightProbesCoefficientsComputeBuffer
		{
			get
			{
				if (!LightProbesCoefficientsTextureResolutionIsValid)
				{
					Debug.LogError("Error while creating LightProbesCoefficientsBuffer computeBuffer in \"" + this?.ToString() + "\". The resolution parameter seems not set.");
					return null;
				}
				if (_lightProbesCoefficientsBuffer == null)
				{
					_lightProbesCoefficientsBuffer = new ComputeBuffer(LightProbesCoefficients.Length, SphericalHarmonicsFirstBandCoefficients.Size);
				}
				return _lightProbesCoefficientsBuffer;
			}
		}

		public void ReleaseAllBuffers()
		{
			ReleaseVolumeTextureBuffers();
			ReleaseOcclusionTextureBuffer();
			ReleaseSliceTextureBuffer();
			ReleaseAllLightProbesBuffers();
		}

		public void ReleaseVolumeTextureBuffers()
		{
			if (_dataVolumeTexture != null)
			{
				_dataVolumeTexture.Release();
				_dataVolumeTexture = null;
			}
			if (_fogVolumeTexture != null)
			{
				_fogVolumeTexture.Release();
				_fogVolumeTexture.Destroy();
				_fogVolumeTexture = null;
			}
		}

		public void ReleaseOcclusionTextureBuffer()
		{
			if (_occlusionTexture != null)
			{
				_occlusionTexture.Release();
				_occlusionTexture = null;
			}
		}

		public void ReleaseSliceTextureBuffer()
		{
			if (_sliceTexture != null)
			{
				_sliceTexture.Release();
				_sliceTexture = null;
			}
		}

		public void ReleaseAllLightProbesBuffers()
		{
			ReleaseLightProbesCoefficientsTextureBuffer();
			ReleaseLightProbesCoefficientsBuffer();
		}

		public void ReleaseLightProbesCoefficientsTextureBuffer()
		{
			if (_lightProbesCoefficientsTexture != null)
			{
				_lightProbesCoefficientsTexture.Release();
				_lightProbesCoefficientsTexture.Destroy();
				_lightProbesCoefficientsTexture = null;
			}
		}

		public void ReleaseLightProbesCoefficientsBuffer()
		{
			if (_lightProbesCoefficientsBuffer != null)
			{
				_lightProbesCoefficientsBuffer.Release();
				_lightProbesCoefficientsBuffer = null;
			}
		}
	}
}
