using System;
using UnityEngine;

namespace NSMedieval.Tools
{
	[Serializable]
	public class ResearchButtonSet : ButtonSpriteSet
	{
		[SerializeField]
		private Sprite iconSprite;

		[SerializeField]
		private Color textColor;

		public Sprite IconSprite => iconSprite;

		public Color TextColor => textColor;

		public void SetIconSprite(Sprite sprite)
		{
			iconSprite = sprite;
		}
	}
}
