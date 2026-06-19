using System;

[Serializable]
public class SaveableTaggedObject : SaveableTaggedObjectNoDepth
{
	public SerializableGameObject gameObject;

	public new SaveableTaggedObject GetCopy()
	{
		SaveableTaggedObject saveableTaggedObject = new SaveableTaggedObject();
		saveableTaggedObject.objID = objID;
		saveableTaggedObject.itemPath = itemPath;
		saveableTaggedObject.savedName = savedName;
		if (objectScale != null)
		{
			saveableTaggedObject.objectScale = objectScale.GetCopy();
		}
		if (pill != null)
		{
			saveableTaggedObject.pill = pill.GetCopy();
		}
		if (egg != null)
		{
			saveableTaggedObject.egg = egg.GetCopy();
		}
		if (plant != null)
		{
			saveableTaggedObject.plant = plant.GetCopy();
		}
		if (core != null)
		{
			saveableTaggedObject.core = core.GetCopy();
		}
		if (cocoon != null)
		{
			saveableTaggedObject.cocoon = cocoon.GetCopy();
		}
		if (eatable != null)
		{
			saveableTaggedObject.eatable = eatable.GetCopy();
		}
		if (crackedCore != null)
		{
			saveableTaggedObject.crackedCore = crackedCore.GetCopy();
		}
		if (fertilizedEgg != null)
		{
			saveableTaggedObject.fertilizedEgg = fertilizedEgg.GetCopy();
		}
		if (gameObject != null)
		{
			saveableTaggedObject.gameObject = gameObject.GetCopy();
		}
		return saveableTaggedObject;
	}
}
