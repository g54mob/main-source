namespace Ink
{
	public class StringParserState
	{
		public class Element
		{
			public int characterIndex;

			public int lineIndex;

			public bool reportedErrorInScope;

			public int uniqueId;

			public uint customFlags;

			private static int _uniqueIdCounter;

			public void CopyFrom(Element fromElement)
			{
			}

			public void SquashFrom(Element fromElement)
			{
			}
		}

		private Element[] _stack;

		private int _numElements;

		public int lineIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int characterIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public uint customFlags
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public bool errorReportedAlreadyInScope => false;

		public int stackHeight => 0;

		protected Element currentElement => null;

		public int Push()
		{
			return 0;
		}

		public void Pop(int expectedRuleId)
		{
		}

		public Element Peek(int expectedRuleId)
		{
			return null;
		}

		public Element PeekPenultimate()
		{
			return null;
		}

		public void Squash()
		{
		}

		public void NoteErrorReported()
		{
		}
	}
}
