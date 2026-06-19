using System;

namespace TH20
{
	[Serializable]
	public class LogChannel
	{
		public string Name { get; private set; }

		public LogChannel(string name)
		{
			Name = name;
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
