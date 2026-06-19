using System;

[Serializable]
public class SaveableTaggedObjectNoDepth
{
	public ulong objID;

	public string itemPath;

	public string savedName;

	public SerializableVector3 objectScale;

	public SaveablePill pill;

	public SaveableDogEgg egg;

	public SaveablePlant plant;

	public SaveableDogCore core;

	public SaveableCocoon cocoon;

	public SaveableEatable eatable;

	public SaveableCrackedCore crackedCore;

	public SaveableFertilizedDogEgg fertilizedEgg;

	public SaveableTaggedObjectNoDepth GetCopy()
	{
		SaveableTaggedObjectNoDepth saveableTaggedObjectNoDepth = new SaveableTaggedObjectNoDepth();
		saveableTaggedObjectNoDepth.objID = objID;
		saveableTaggedObjectNoDepth.itemPath = itemPath;
		saveableTaggedObjectNoDepth.savedName = savedName;
		if (objectScale != null)
		{
			saveableTaggedObjectNoDepth.objectScale = objectScale.GetCopy();
		}
		if (pill != null)
		{
			saveableTaggedObjectNoDepth.pill = pill.GetCopy();
		}
		if (egg != null)
		{
			saveableTaggedObjectNoDepth.egg = egg.GetCopy();
		}
		if (plant != null)
		{
			saveableTaggedObjectNoDepth.plant = plant.GetCopy();
		}
		if (core != null)
		{
			saveableTaggedObjectNoDepth.core = core.GetCopy();
		}
		if (cocoon != null)
		{
			saveableTaggedObjectNoDepth.cocoon = cocoon.GetCopy();
		}
		if (eatable != null)
		{
			saveableTaggedObjectNoDepth.eatable = eatable.GetCopy();
		}
		if (crackedCore != null)
		{
			saveableTaggedObjectNoDepth.crackedCore = crackedCore.GetCopy();
		}
		if (fertilizedEgg != null)
		{
			saveableTaggedObjectNoDepth.fertilizedEgg = fertilizedEgg.GetCopy();
		}
		return saveableTaggedObjectNoDepth;
	}
}
