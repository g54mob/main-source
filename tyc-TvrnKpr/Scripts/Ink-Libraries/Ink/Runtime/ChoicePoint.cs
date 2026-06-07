namespace Ink.Runtime
{
	public class ChoicePoint : Object
	{
		private Path _pathOnChoice;

		public Path pathOnChoice
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Container choiceTarget => null;

		public string pathStringOnChoice
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool hasCondition { get; set; }

		public bool hasStartContent { get; set; }

		public bool hasChoiceOnlyContent { get; set; }

		public bool onceOnly { get; set; }

		public bool isInvisibleDefault { get; set; }

		public int flags
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ChoicePoint(bool onceOnly)
		{
		}

		public ChoicePoint()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
