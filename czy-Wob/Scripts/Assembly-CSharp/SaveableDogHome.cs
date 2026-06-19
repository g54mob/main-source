using System;
using System.Collections.Generic;

[Serializable]
public class SaveableDogHome
{
	public bool freshHome = true;

	public ulong IDCounter;

	public ulong lastFocusedRoomUID;

	public ulong placedPlantsIDCounter;

	public ulong placedPuddlesIDCounter;

	public ulong placedObjectsIDCounter;

	public List<SavedRoom> rooms = new List<SavedRoom>();

	public List<SavedPipe> pipes = new List<SavedPipe>();

	public int allowedPens = 1;
}
