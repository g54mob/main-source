using System;
using System.Collections.Generic;

[Serializable]
public class SaveablePlacedObject
{
	public ulong UID;

	public int rotationValue;

	public float scaleValue = 1f;

	public SerializableVector2Int gridPos;

	public string resourceString;

	public SaveableDogEgg eggA;

	public SaveableDogGene geneA;

	public SaveableThumbSet thumbSetA;

	public SaveableDogProfile profileA;

	public SaveableDogPersonality personalityA;

	public SaveableTaggedObjectNoDepth taggedObjectA;

	public SaveableTree treeRef;

	public List<int> intList = new List<int>();

	public List<int> intListB = new List<int>();

	public List<bool> boolList = new List<bool>();

	public List<float> floatList = new List<float>();

	public List<ulong> ulongList = new List<ulong>();

	public List<string> stringList = new List<string>();

	public List<string> stringListB = new List<string>();

	public List<SaveableTaggedObjectNoDepth> objectList = new List<SaveableTaggedObjectNoDepth>();

	public List<SaveableTaggedObjectNoDepth> objectListB = new List<SaveableTaggedObjectNoDepth>();

	public SaveablePlacedObject GetCopy()
	{
		SaveablePlacedObject saveablePlacedObject = new SaveablePlacedObject();
		saveablePlacedObject.UID = UID;
		saveablePlacedObject.scaleValue = scaleValue;
		saveablePlacedObject.rotationValue = rotationValue;
		if (gridPos != null)
		{
			saveablePlacedObject.gridPos = gridPos.GetCopy();
		}
		saveablePlacedObject.resourceString = resourceString;
		if (eggA != null)
		{
			saveablePlacedObject.eggA = eggA.GetCopy();
		}
		if (geneA != null)
		{
			saveablePlacedObject.geneA = geneA.GetCopy();
		}
		if (profileA != null)
		{
			saveablePlacedObject.profileA = profileA.GetCopy();
		}
		if (thumbSetA != null)
		{
			saveablePlacedObject.thumbSetA = thumbSetA.GetCopy();
		}
		if (personalityA != null)
		{
			saveablePlacedObject.personalityA = personalityA.GetCopy();
		}
		if (taggedObjectA != null)
		{
			saveablePlacedObject.taggedObjectA = taggedObjectA.GetCopy();
		}
		if (treeRef != null)
		{
			saveablePlacedObject.treeRef = treeRef.GetCopy();
		}
		saveablePlacedObject.intList = new List<int>();
		if (intList != null)
		{
			saveablePlacedObject.intList.AddRange(intList);
		}
		saveablePlacedObject.intListB = new List<int>();
		if (intListB != null)
		{
			saveablePlacedObject.intListB.AddRange(intListB);
		}
		saveablePlacedObject.boolList = new List<bool>();
		if (boolList != null)
		{
			saveablePlacedObject.boolList.AddRange(boolList);
		}
		saveablePlacedObject.floatList = new List<float>();
		if (floatList != null)
		{
			saveablePlacedObject.floatList.AddRange(floatList);
		}
		saveablePlacedObject.ulongList = new List<ulong>();
		if (ulongList != null)
		{
			saveablePlacedObject.ulongList.AddRange(ulongList);
		}
		saveablePlacedObject.stringList = new List<string>();
		if (stringList != null)
		{
			saveablePlacedObject.stringList.AddRange(stringList);
		}
		saveablePlacedObject.stringListB = new List<string>();
		if (stringListB != null)
		{
			saveablePlacedObject.stringListB.AddRange(stringListB);
		}
		saveablePlacedObject.objectList = new List<SaveableTaggedObjectNoDepth>();
		if (objectList != null)
		{
			saveablePlacedObject.objectList.AddRange(objectList);
		}
		saveablePlacedObject.objectListB = new List<SaveableTaggedObjectNoDepth>();
		if (objectListB != null)
		{
			saveablePlacedObject.objectListB.AddRange(objectListB);
		}
		return saveablePlacedObject;
	}
}
