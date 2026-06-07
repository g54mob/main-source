namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class FileAttributes
	{
		public static AttributeSet Set { get; private set; }

		static FileAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddBool("autoRefresh", delegate(FileWidget w, bool x)
			{
				w.AutoRefresh = x;
			});
			set.AddString("path", delegate(FileWidget w, string x)
			{
				w.Path = x;
			});
			set.AddBool("inline", delegate(FileWidget w, bool x)
			{
				w.Inline = x;
			});
		}
	}
}
