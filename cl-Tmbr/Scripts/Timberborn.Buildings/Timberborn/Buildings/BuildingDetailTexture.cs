using Timberborn.BaseComponentSystem;
using UnityEngine;

namespace Timberborn.Buildings
{
	internal class BuildingDetailTexture : BaseComponent, IStartableComponent
	{
		private static readonly int TextureProperty = Shader.PropertyToID("_DetailAlbedoMap2");

		private static readonly int ColorProperty = Shader.PropertyToID("_DetailAlbedoUV2Color");

		public void Start()
		{
			BuildingDetailTextureSpec component = GetComponent<BuildingDetailTextureSpec>();
			MeshRenderer[] componentsInChildren = GetComponent<BuildingModel>().FinishedModel.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Material[] materials = componentsInChildren[i].materials;
				foreach (Material obj in materials)
				{
					obj.SetTexture(TextureProperty, component.Texture.Asset);
					obj.SetColor(ColorProperty, component.Color);
				}
			}
		}
	}
}
