using System;
using System.Collections.Generic;

[Serializable]
public class PolymorphicPropertyDrawerList<T> where T : PolymorphicPropertyDrawerListItem
{
	public List<T> List = new List<T>();

	public int Count => List.Count;

	public bool IsEmpty => List.Count == 0;
}
