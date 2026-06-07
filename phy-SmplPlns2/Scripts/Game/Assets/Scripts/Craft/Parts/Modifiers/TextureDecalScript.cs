using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class TextureDecalScript : DecalScript
	{
		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			TextureDecalData obj = (TextureDecalData)base.Data;
			Vector2 textureTiling = obj.TextureTiling;
			textureTiling.x = 0f - textureTiling.x;
			obj.TextureTiling = textureTiling;
		}
	}
}
