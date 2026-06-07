using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.ClimateZone.DataGenerators.Values
{
	public class GetPixel : NimbatusDataGenerator
	{
		public int Index;

		public override float GetValue(Vector2 worldPosition, float previousValue)
		{
			int num = (int)Mathf.Clamp(worldPosition.x + 540f, 0f, 1100f);
			int num2 = (int)Mathf.Clamp(worldPosition.y + 540f, 0f, 1100f);
			if (Zone.TexturePixels != null && Zone.TexturePixels.Count > Index)
			{
				return Zone.TexturePixels[Index][num2 * 1100 + num].r;
			}
			return 0f;
		}
	}
}
