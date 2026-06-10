using System;
using NSEipix.Model;
using TMPro;

namespace NSMedieval.Model
{
	[Serializable]
	public class KeySpriteAssetPair : Pair<TMP_SpriteAsset>
	{
		public KeySpriteAssetPair(string id, TMP_SpriteAsset value)
			: base(id, value)
		{
		}
	}
}
