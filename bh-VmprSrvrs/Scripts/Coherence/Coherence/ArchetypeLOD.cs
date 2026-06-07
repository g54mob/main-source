using System;
using System.Collections.Generic;

namespace Coherence
{
	[Serializable]
	public class ArchetypeLOD
	{
		public int level;

		public List<ArchetypeItem> items;

		public float distance;

		public List<string> excludedComponentNames;

		public ArchetypeLOD(int level, float distance)
		{
		}
	}
}
