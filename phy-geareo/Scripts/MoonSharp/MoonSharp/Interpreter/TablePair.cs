namespace MoonSharp.Interpreter
{
	public struct TablePair
	{
		private static TablePair s_NilNode;

		private DynValue key;

		private DynValue value;

		public DynValue Key
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public DynValue Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static TablePair Nil => default(TablePair);

		public TablePair(DynValue key, DynValue val)
		{
			this.key = null;
			value = null;
		}
	}
}
