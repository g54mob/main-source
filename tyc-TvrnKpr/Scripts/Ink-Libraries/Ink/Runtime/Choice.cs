namespace Ink.Runtime
{
	public class Choice : Object
	{
		public string sourcePath;

		public Path targetPath;

		public int originalThreadIndex;

		public bool isInvisibleDefault;

		public string text { get; set; }

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

		public int index { get; set; }

		public CallStack.Thread threadAtGeneration { get; set; }
	}
}
