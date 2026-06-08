using System;
using System.Collections.Generic;

namespace Dorfromantik
{
	[Serializable]
	public class ComponentCountInfo
	{
		public string componentType;

		public int count;

		public List<NameFrequency> nameFrequencies = new List<NameFrequency>();

		public Dictionary<string, NameFrequency> nameFrequencyByName = new Dictionary<string, NameFrequency>();
	}
}
