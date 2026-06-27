using UnityEngine;

namespace Mandragora.ResourceUtils
{
	public class SpriteLinkBank : LinkBank<Sprite>
	{
		public virtual Sprite GetSpriteByPath(string pathToSprite)
		{
			return FindResourceByPath(pathToSprite);
		}

		public virtual Sprite GetSpriteByName(string name)
		{
			return FindResourceByName(name);
		}
	}
}
