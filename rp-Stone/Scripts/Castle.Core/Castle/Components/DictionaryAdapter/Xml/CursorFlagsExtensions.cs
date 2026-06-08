namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class CursorFlagsExtensions
	{
		public static CursorFlags MutableIf(this CursorFlags flags, bool mutable)
		{
			if (!mutable)
			{
				return flags;
			}
			return flags | CursorFlags.Mutable;
		}

		public static bool IncludesElements(this CursorFlags flags)
		{
			return (flags & CursorFlags.Elements) != 0;
		}

		public static bool IncludesAttributes(this CursorFlags flags)
		{
			return (flags & CursorFlags.Attributes) != 0;
		}

		public static bool AllowsMultipleItems(this CursorFlags flags)
		{
			return (flags & CursorFlags.Multiple) != 0;
		}

		public static bool SupportsMutation(this CursorFlags flags)
		{
			return (flags & CursorFlags.Mutable) != 0;
		}
	}
}
