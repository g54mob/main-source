namespace Febucci.TextAnimatorForUnity.Parsing
{
	internal struct UITkTagInfo
	{
		public readonly string tagOpening;

		public readonly bool increasesTextLength;

		public UITkTagInfo(string tagOpening, bool increasesTextLength = false)
		{
			this.tagOpening = tagOpening;
			this.increasesTextLength = increasesTextLength;
		}
	}
}
