using System;
using System.Collections.Generic;

namespace Coherence;

[Serializable]
public class ArchetypeLOD
{
	public int level;

	public List<ArchetypeItem> items;

	public float distance;

	public List<string> excludedComponentNames;

	public ArchetypeLOD(int level, float distance)
	{
		this.distance = distance;
		this.level = level;
		List<ArchetypeItem> list = new List<ArchetypeItem>();
		items = list;
		List<string> list2 = new List<string>();
		excludedComponentNames = list2;
	}
}
