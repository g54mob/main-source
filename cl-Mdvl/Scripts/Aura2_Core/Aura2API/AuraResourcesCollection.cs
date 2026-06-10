using UnityEngine;

namespace Aura2API
{
	public class AuraResourcesCollection : ScriptableObject
	{
		[Header("Compute Shaders")]
		public ComputeShader computeMaximumDepthComputeShader;

		public ComputeShader computeVisibleCellsComputeShader;

		public ComputeShader computeDataComputeShader;

		public ComputeShader computeAccumulationComputeShader;

		public ComputeShader renderLightProbesTextureComputeShader;

		public ComputeShader applyDenoisingFilterComputeShader;

		public ComputeShader applyBlurFilterComputeShader;

		[Header("Shaders")]
		public Shader processOcclusionMapShader;

		public Shader postProcessShader;

		public Shader storeDirectionalShadowDataShader;

		public Shader storeDirectionalSpotCookieMapShader;

		public Shader storePointShadowMapShader;

		public Shader storePointCookieMapShader;

		public Shader spriteLitShader;

		public Shader spriteUnlitShader;

		[Header("Textures")]
		public Texture2DArray blueNoiseTextureArray;

		public Texture2D dummyTexture;

		public RenderTexture _dummyTextureUAV;

		public Texture2DArray dummyTextureArray;

		public Texture3D dummyTexture3D;

		public Sprite defaultSprite;

		[Header("Meshes")]
		public Mesh storePointShadowMapMesh;

		public RenderTexture DummyTextureUAV
		{
			get
			{
				if (_dummyTextureUAV == null)
				{
					_dummyTextureUAV = new RenderTexture(2, 2, 0, RenderTextureFormat.R8, RenderTextureReadWrite.Linear);
					_dummyTextureUAV.enableRandomWrite = true;
					_dummyTextureUAV.Create();
				}
				return _dummyTextureUAV;
			}
		}
	}
}
