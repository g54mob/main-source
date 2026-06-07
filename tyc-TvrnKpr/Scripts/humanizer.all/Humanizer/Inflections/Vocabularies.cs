using System;

namespace Humanizer.Inflections
{
	public static class Vocabularies
	{
		private static readonly Lazy<Vocabulary> Instance;

		public static Vocabulary Default => null;

		static Vocabularies()
		{
		}

		private static Vocabulary BuildDefault()
		{
			return null;
		}
	}
}
