using System;
using System.Collections.Generic;

[Serializable]
public class SavedPipe : SavedBuildObject
{
	public ulong roomIDEnd;

	public ulong roomIDStart;

	public WallDirection endingWall;

	public WallDirection startingWall;

	public ConnectorLabel endingLabel;

	public ConnectorLabel startingLabel;

	public List<SerializableVector3> pipePath = new List<SerializableVector3>();
}
