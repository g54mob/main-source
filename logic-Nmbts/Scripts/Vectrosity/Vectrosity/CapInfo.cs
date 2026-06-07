using UnityEngine;

namespace Vectrosity
{
	public class CapInfo
	{
		public EndCap capType;

		public Material material;

		public Texture2D texture;

		public float ratio1;

		public float ratio2;

		public CapInfo(EndCap capType, Material material, Texture2D texture, float ratio1, float ratio2)
		{
			this.capType = capType;
			this.material = material;
			this.texture = texture;
			this.ratio1 = ratio1;
			this.ratio2 = ratio2;
		}
	}
}
