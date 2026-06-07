using System.Collections.Generic;

namespace PhEngine.ThaiTextCare
{
	public class PhTokenizer
	{
		private class TrieNode
		{
			public Dictionary<char, TrieNode> Children;

			public bool IsEndOfWord;
		}

		private TrieNode m_Root;

		public PhTokenizer(IEnumerable<string> dictionary)
		{
		}

		private void AddWord(string word)
		{
		}

		public List<string> Tokenize(string input, bool isSupportRichTextTags)
		{
			return null;
		}

		private static bool HasNoFollower(string input, int currentIndex)
		{
			return false;
		}

		private static bool IsShouldNotTokenize(char c)
		{
			return false;
		}

		private static bool IsOpenBracket(char c)
		{
			return false;
		}

		private static bool IsCloseBracket(char c)
		{
			return false;
		}

		private static bool IsFollowingThaiGlyph(char c)
		{
			return false;
		}

		private static bool IsThaiEndCharacter(char c)
		{
			return false;
		}
	}
}
