using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Events;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class DecalScript : PartModifierScript<DecalData>
	{
		private Texture2D _texture;

		private string _texturePath;

		public void ApplyDecalTexture()
		{
			DecalData data = base.Data;
			bool inFlightScene = Game.InFlightScene;
			string path = base.Data.Path;
			if (path != _texturePath)
			{
				if (_texture != null)
				{
					Game.Instance.PartDecalManager.UnloadDecal(_texturePath);
					_texture = null;
					_texturePath = null;
				}
				if (!string.IsNullOrWhiteSpace(path) && path != "None")
				{
					_texture = Game.Instance.PartDecalManager.LoadDecal(path);
					if (_texture != null)
					{
						_texturePath = path;
					}
					else
					{
						Debug.LogError("Could not load decal texture '" + path + "'");
					}
				}
			}
			foreach (IRendererMaterialMap rendererMap in base.PartScript.PartMaterialScript.RendererMaps)
			{
				rendererMap.DecalTexture = _texture;
				rendererMap.DecalTextureOffsetAndTiling = new Vector4(data.TilingX, data.TilingY, data.OffsetX, data.OffsetY);
				rendererMap.DecalTextureMaterialLevels = new Vector4i((int)data.MaterialR, (int)data.MaterialG, (int)data.MaterialB, (int)(data.UseSourceColor ? data.MaterialSourceColor : ((PartMeshMaterialLevel)(-1))));
				if (!inFlightScene)
				{
					rendererMap.ApplyDecalTexture();
				}
			}
		}

		protected virtual void OnDestroy()
		{
			base.PartScript.PartMaterialScript.RendererAdded -= OnRendererAdded;
			if (_texturePath != null)
			{
				Game.Instance.PartDecalManager.UnloadDecal(_texturePath);
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			base.PartScript.PartMaterialScript.RendererAdded += OnRendererAdded;
			ApplyDecalTexture();
		}

		private void OnRendererAdded(object sender, RendererEventArgs e)
		{
			ApplyDecalTexture();
		}
	}
}
