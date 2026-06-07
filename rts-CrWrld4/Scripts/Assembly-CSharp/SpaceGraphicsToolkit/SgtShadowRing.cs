using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtShadowRing : SgtShadow
	{
		public Texture Texture;

		public float RadiusMin;

		public float RadiusMax;

		public override Texture GetTexture()
		{
			return null;
		}

		public override void CalculateShadow(SgtLight light)
		{
		}
	}
}
