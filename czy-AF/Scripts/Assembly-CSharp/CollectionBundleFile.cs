using System;
using System.Collections.Generic;

[Serializable]
public class CollectionBundleFile
{
	public string name;

	public List<CollectionBundleFragment> fragments = new List<CollectionBundleFragment>();
}
