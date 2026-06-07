namespace Ink.Runtime
{
	public class Divert : Object
	{
		private Path _targetPath;

		private Pointer _targetPointer;

		public PushPopType stackPushType;

		public Path targetPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Pointer targetPointer => default(Pointer);

		public string targetPathString
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string variableDivertName { get; set; }

		public bool hasVariableTarget => false;

		public bool pushesToStack { get; set; }

		public bool isExternal { get; set; }

		public int externalArgs { get; set; }

		public bool isConditional { get; set; }

		public Divert()
		{
		}

		public Divert(PushPopType stackPushType)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
