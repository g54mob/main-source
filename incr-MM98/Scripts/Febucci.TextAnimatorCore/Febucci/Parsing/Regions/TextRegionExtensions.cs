namespace Febucci.Parsing.Regions
{
	public static class TextRegionExtensions
	{
		public static bool DoesAnyRegionContainCharacter<TTagProvider>(this TextRegion<TTagProvider>[] regions, int charIndex) where TTagProvider : ITagProvider
		{
			foreach (TextRegion<TTagProvider> textRegion in regions)
			{
				TagRange[] ranges = textRegion.ranges;
				for (int j = 0; j < ranges.Length; j++)
				{
					TagRange tagRange = ranges[j];
					if (charIndex >= tagRange.indexes.X && (tagRange.indexes.Y == int.MaxValue || charIndex < tagRange.indexes.Y))
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
