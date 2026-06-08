using System;
using UnityEngine;

public class ParallaxSyncedLayers : ParallaxLayer
{
	[Serializable]
	public class AdditionalLayer
	{
		public TilingAsciiSprite sprite;

		public float ratio = 1f;
	}

	public AdditionalLayer[] additionalLayers;

	protected override void UpdateParallaxX()
	{
		base.UpdateParallaxX();
		int num = base.sprite.scrollX;
		for (int i = 0; i < additionalLayers.Length; i++)
		{
			float ratio = additionalLayers[i].ratio;
			num -= Mathf.FloorToInt((float)base.sprite.scrollX * ratio);
			additionalLayers[i].sprite.scrollX = num;
		}
	}
}
