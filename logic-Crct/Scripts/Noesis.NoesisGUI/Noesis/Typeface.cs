namespace Noesis
{
	public struct Typeface
	{
		private byte[] _familyName;

		private int _weight;

		private int _style;

		private int _stretch;

		public string FamilyName => null;

		public FontWeight Weight => default(FontWeight);

		public FontStyle Style => default(FontStyle);

		public FontStretch Stretch => default(FontStretch);
	}
}
