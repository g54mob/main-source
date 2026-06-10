using UnityEngine;

namespace Aura2API
{
	public class ShadowmapsCollector : Texture2DArrayComposer
	{
		public ShadowmapsCollector(int sizeX, int sizeY)
			: base(sizeX, sizeY, TextureFormat.RGBAFloat, bypassSrgb: true)
		{
			alwaysGenerateOnUpdate = true;
		}
	}
}
