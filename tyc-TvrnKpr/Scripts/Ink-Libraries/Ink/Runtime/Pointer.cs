namespace Ink.Runtime
{
	public struct Pointer
	{
		public Container container;

		public int index;

		public static Pointer Null;

		public bool isNull => false;

		public Path path => null;

		public Pointer(Container container, int index)
		{
			this.container = null;
			this.index = 0;
		}

		public Object Resolve()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public static Pointer StartOf(Container container)
		{
			return default(Pointer);
		}
	}
}
