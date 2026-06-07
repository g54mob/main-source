using DV.RenderTextureSystem.BookletRender;
using UnityEngine;

namespace DV.Booklets.Rendered
{
	public class RuntimeRenderedStaticMaterialTexture : RenderedTexturesBase
	{
		public Renderer[] renderers;

		public string materialTextureName;

		public bool useSameTextureForRenderers;

		public bool worldSpecific;

		public string renderPrefabName;

		public LevelInfo.WorldSpecificPrefabs worldSpecificPrefab;

		private void Awake()
		{
			if (worldSpecific)
			{
				GameObject gameObject = LevelInfo.GetWorldSpecificPrefab(worldSpecificPrefab);
				renderPrefabName = ((gameObject == null) ? null : gameObject.name);
			}
			if (string.IsNullOrEmpty(renderPrefabName))
			{
				Debug.LogError("RuntimeRenderedStaticMaterialTexture: Unexpected state: :renderPrefabName not set. Destroying self.", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				BookletCreator_StaticRenderBooklet.Render(base.gameObject, renderPrefabName);
			}
		}

		protected override void OnBookletTexturesGenerated(Texture[] generatedTextures, BookletTextureRender _)
		{
			base.OnBookletTexturesGenerated(generatedTextures, _);
			int num = (useSameTextureForRenderers ? 1 : renderers.Length);
			if (generatedTextures.Length < num)
			{
				Debug.LogError(string.Format("{0} array contains only {1} textures, but we need {2}", "generatedTextures", generatedTextures.Length, num));
				return;
			}
			for (int i = 0; i < renderers.Length; i++)
			{
				renderers[i].material.SetTexture(materialTextureName, generatedTextures[(!useSameTextureForRenderers) ? i : 0]);
			}
		}
	}
}
