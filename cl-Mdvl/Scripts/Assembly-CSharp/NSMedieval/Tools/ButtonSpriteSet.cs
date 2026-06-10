using System;
using UnityEngine;

namespace NSMedieval.Tools
{
	[Serializable]
	public class ButtonSpriteSet
	{
		[SerializeField]
		private Sprite baseSprite;

		[SerializeField]
		private Sprite highlightetSprite;

		[SerializeField]
		private Sprite pressedSprite;

		[SerializeField]
		private Sprite selectedSprite;

		[SerializeField]
		private Sprite disabledSprite;

		public Sprite BaseSprite => baseSprite;

		public Sprite HighlightetSprite => highlightetSprite;

		public Sprite PressedSprite => pressedSprite;

		public Sprite SelectedSprite => selectedSprite;

		public Sprite DisabledSprite => disabledSprite;
	}
}
