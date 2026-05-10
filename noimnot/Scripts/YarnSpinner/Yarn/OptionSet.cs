namespace Yarn
{
	public struct OptionSet
	{
		public struct Option
		{
			public Line Line { get; private set; }

			public int ID { get; private set; }

			public string DestinationNode { get; private set; }

			public bool IsAvailable { get; private set; }

			internal Option(Line line, int id, string destinationNode, bool isAvailable)
			{
				Line = default(Line);
				ID = 0;
				DestinationNode = null;
				IsAvailable = false;
			}
		}

		public Option[] Options { get; private set; }

		internal OptionSet(Option[] options)
		{
			Options = null;
		}
	}
}
