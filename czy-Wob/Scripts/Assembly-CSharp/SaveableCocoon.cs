using System;

[Serializable]
public class SaveableCocoon
{
	public SerializableVector3 anchorPos;

	public SerializableVector3 attachmentPoint;

	public bool attachedToDog;

	public bool attachedToWorldObject;

	public ulong attachedObjectID;

	public string attachedTransformName = "";

	public bool hasString;

	public float hatchTimerCurrent;

	public bool isAscending;

	public float ascensionDist;

	public float ascensionWaitTimer;

	public float ascensionLinearLimit;

	public bool goopMixed;

	public ulong associatedDogID;

	public SaveableCocoon()
	{
	}

	public SaveableCocoon(Cocoon c)
	{
		c.SaveCocoon(this);
	}

	public void Load(Cocoon c)
	{
		c.LoadSaveableCocoon(this);
	}

	public SaveableCocoon GetCopy()
	{
		SaveableCocoon saveableCocoon = new SaveableCocoon();
		if (anchorPos != null)
		{
			saveableCocoon.anchorPos = anchorPos.GetCopy();
		}
		if (attachmentPoint != null)
		{
			saveableCocoon.attachmentPoint = attachmentPoint.GetCopy();
		}
		saveableCocoon.attachedToDog = attachedToDog;
		saveableCocoon.attachedToWorldObject = attachedToWorldObject;
		saveableCocoon.attachedObjectID = attachedObjectID;
		saveableCocoon.attachedTransformName = attachedTransformName;
		saveableCocoon.hasString = hasString;
		saveableCocoon.hatchTimerCurrent = hatchTimerCurrent;
		saveableCocoon.isAscending = isAscending;
		saveableCocoon.ascensionDist = ascensionDist;
		saveableCocoon.ascensionWaitTimer = ascensionWaitTimer;
		saveableCocoon.ascensionLinearLimit = ascensionLinearLimit;
		saveableCocoon.goopMixed = goopMixed;
		saveableCocoon.associatedDogID = associatedDogID;
		return saveableCocoon;
	}
}
