using UnityEngine;

namespace Assets.Scripts.Craft.Decals
{
	public interface ICraftTextureDecal : ICraftDecal
	{
		CraftDecalData CraftDecalData { get; set; }

		Texture2D Texture { get; }

		Vector2 TextureOffset { get; set; }

		Vector2 TextureTiling { get; set; }

		void ReleaseDecalMaterial(Material material);

		Material RequestDecalMaterial();
	}
}
