using Ink.Parsed;

namespace Ink
{
	public struct Stats
	{
		public int words;

		public int knots;

		public int stitches;

		public int functions;

		public int choices;

		public int gathers;

		public int diverts;

		public static Stats Generate(Story story)
		{
			return default(Stats);
		}
	}
}
