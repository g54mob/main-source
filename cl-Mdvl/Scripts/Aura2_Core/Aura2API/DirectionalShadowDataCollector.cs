using UnityEngine;

namespace Aura2API
{
	public class DirectionalShadowDataCollector : Texture2DArrayComposer
	{
		public DirectionalShadowDataCollector()
			: base(32, 1, TextureFormat.RGBAFloat, bypassSrgb: true)
		{
			alwaysGenerateOnUpdate = true;
		}
	}
}
