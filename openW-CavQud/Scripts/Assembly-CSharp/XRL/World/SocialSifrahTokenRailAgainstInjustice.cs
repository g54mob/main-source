using System;

namespace XRL.World
{
	[Serializable]
	public class SocialSifrahTokenRailAgainstInjustice : SifrahToken
	{
		public SocialSifrahTokenRailAgainstInjustice()
		{
			Description = "rail against injustice";
			Tile = "Items/sw_gianthands.bmp";
			RenderString = "í";
			ColorString = "&w";
			TileColor = "&w";
			DetailColor = 'r';
		}
	}
}
