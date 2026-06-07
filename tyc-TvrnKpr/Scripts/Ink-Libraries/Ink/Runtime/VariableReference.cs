namespace Ink.Runtime
{
	public class VariableReference : Object
	{
		public string name { get; set; }

		public Path pathForCount { get; set; }

		public Container containerForCount => null;

		public string pathStringForCount
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public VariableReference(string name)
		{
		}

		public VariableReference()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
