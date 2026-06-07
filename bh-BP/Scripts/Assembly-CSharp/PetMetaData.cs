using System;
using System.Collections.Generic;

[Serializable]
public class PetMetaData
{
	public int NumNamesTaken;

	[NonSerialized]
	public List<string> ShuffledNameList;
}
