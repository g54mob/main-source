using System;
using System.Collections.Generic;

[Serializable]
public class SaveableTaggedObjects
{
	public List<SaveableTaggedObject> objects = new List<SaveableTaggedObject>();

	public List<SaveableTaggedObject> cocoons = new List<SaveableTaggedObject>();
}
