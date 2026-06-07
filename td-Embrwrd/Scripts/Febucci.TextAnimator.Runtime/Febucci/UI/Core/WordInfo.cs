namespace Febucci.UI.Core
{
	public struct WordInfo
	{
		public readonly int firstCharacterIndex;

		public readonly int lastCharacterIndex;

		public readonly string text;

		public WordInfo(int firstCharacterIndex, int lastCharacterIndex, string text)
		{
			this.firstCharacterIndex = 0;
			this.lastCharacterIndex = 0;
			this.text = null;
		}
	}
}
