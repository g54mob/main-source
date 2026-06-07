using System.Collections.Generic;

namespace Ink
{
	public sealed class CharacterRange
	{
		private char _start;

		private char _end;

		private ICollection<char> _excludes;

		private CharacterSet _correspondingCharSet;

		public char start => '\0';

		public char end => '\0';

		public static CharacterRange Define(char start, char end, IEnumerable<char> excludes = null)
		{
			return null;
		}

		public CharacterSet ToCharacterSet()
		{
			return null;
		}

		private CharacterRange(char start, char end, IEnumerable<char> excludes)
		{
		}
	}
}
