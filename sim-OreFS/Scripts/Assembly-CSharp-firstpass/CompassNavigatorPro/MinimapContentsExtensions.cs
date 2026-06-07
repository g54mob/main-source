namespace CompassNavigatorPro
{
	public static class MinimapContentsExtensions
	{
		public static bool usesTexture(this MiniMapContents contents)
		{
			if (contents != MiniMapContents.UITexture)
			{
				return contents == MiniMapContents.Radar;
			}
			return true;
		}
	}
}
