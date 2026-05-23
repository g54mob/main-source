using System.Collections.Generic;
using UnityEngine;

namespace Libs
{
	[CreateAssetMenu(fileName = "SpriteAnimationData", menuName = "Animation/SpriteAnimationData")]
	public class SpriteAnimationData : ScriptableObject
	{
		[SerializeField]
		private List<Sprite> sprites;

		public List<Sprite> Sprites => null;

		public int Count => 0;

		public void SetSprites(List<Sprite> newSprites)
		{
		}

		public void AddSprite(Sprite sprite)
		{
		}

		public void RemoveSprite(Sprite sprite)
		{
		}

		public void ClearSprites()
		{
		}

		public Sprite GetSprite(int index)
		{
			return null;
		}
	}
}
