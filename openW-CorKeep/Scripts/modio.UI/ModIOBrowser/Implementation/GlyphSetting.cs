using UnityEngine;

namespace ModIOBrowser.Implementation
{
	[CreateAssetMenu(fileName = "GlyphSetting.asset", menuName = "ModIo/GlyphSetting")]
	internal class GlyphSetting : ScriptableObject
	{
		public Glyph glyph;

		public ColorSetterType color;

		public Sprite PC;

		public Sprite Xbox;

		public Sprite Steamdeck;

		public Sprite Playstation4;

		public Sprite Playstation5;

		public Sprite NintendoSwitch;

		public Sprite NintendoSwitchSingleJoyCon;
	}
}
