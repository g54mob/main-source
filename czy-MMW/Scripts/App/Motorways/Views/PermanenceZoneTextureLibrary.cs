using System;
using Factory;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Motorways.Views
{
	public class PermanenceZoneTextureLibrary : MonoBehaviour, ICreatedInScopeHandler
	{
		private const int PermanenceTextureResolution = 512;

		[SerializeField]
		private Shader _permanenceZoneIndexShader;

		[SerializeField]
		private Shader _permanenceZoneFadeShader;

		[Dependency]
		private VisualConstantsData _visualConstantsData;

		[Dependency]
		private PermanenceTextureMappingDatabase _permanenceTextureMappingDatabase;

		private static readonly int FadeLength = Shader.PropertyToID("_FadeSize");

		private static readonly int PermanenceIndexToZoneId = Shader.PropertyToID("_PermanenceIndexToZoneId");

		private static readonly int ZoneIdToFadeIds = Shader.PropertyToID("_ZoneIdToFadeIds");

		public RenderTexture PermanenceIndexTexture { get; private set; }

		public RenderTexture PermanenceFadeTexture { get; private set; }

		public event Action OnTexturesRecreated;

		public void OnCreatedInScope(IScope scope)
		{
			CreatePermanenceTextures();
			_visualConstantsData.OnExpertPermanentRoadFadeLengthChanged += RecreateTextures;
			_permanenceTextureMappingDatabase.OnTextureMappingsUpdated += RecreateTextures;
		}

		private void CreatePermanenceTextures()
		{
			PermanenceIndexTexture = new RenderTexture(512, 512, 1, GraphicsFormat.R32G32B32A32_SFloat, 0)
			{
				useMipMap = false,
				filterMode = FilterMode.Point,
				wrapMode = TextureWrapMode.Mirror
			};
			PermanenceFadeTexture = new RenderTexture(512, 512, 1, GraphicsFormat.R32G32_SFloat, 0)
			{
				useMipMap = false,
				filterMode = FilterMode.Point,
				wrapMode = TextureWrapMode.Mirror
			};
			UpdateShaderPropertyReferences();
		}

		private void RecreateTextures()
		{
			Diagnostics.Log.Info("PermanenceTextureLibrary", "Recreating textures...");
			CreatePermanenceTextures();
			this.OnTexturesRecreated?.Invoke();
		}

		private void UpdateShaderPropertyReferences()
		{
			Material material = new Material(_permanenceZoneIndexShader);
			material.SetFloat(FadeLength, _visualConstantsData.ExpertPermanentRoadsFadeLength);
			material.SetFloatArray(PermanenceIndexToZoneId, _permanenceTextureMappingDatabase.shaderIndexToZoneIndex);
			material.SetVectorArray(ZoneIdToFadeIds, _permanenceTextureMappingDatabase.zoneIndexToFadeIndices);
			RenderTexture temporary = RenderTexture.GetTemporary(PermanenceIndexTexture.descriptor);
			Graphics.Blit(PermanenceIndexTexture, temporary, material, 0);
			Graphics.Blit(temporary, PermanenceIndexTexture);
			RenderTexture.ReleaseTemporary(temporary);
			Material material2 = new Material(_permanenceZoneFadeShader);
			material2.SetFloat(FadeLength, _visualConstantsData.ExpertPermanentRoadsFadeLength);
			material2.SetFloatArray(PermanenceIndexToZoneId, _permanenceTextureMappingDatabase.shaderIndexToZoneIndex);
			material2.SetVectorArray(ZoneIdToFadeIds, _permanenceTextureMappingDatabase.zoneIndexToFadeIndices);
			RenderTexture temporary2 = RenderTexture.GetTemporary(PermanenceFadeTexture.descriptor);
			Graphics.Blit(PermanenceFadeTexture, temporary2, material2, 0);
			Graphics.Blit(temporary2, PermanenceFadeTexture);
			RenderTexture.ReleaseTemporary(temporary2);
		}
	}
}
