using System;
using System.Collections.Generic;

[Serializable]
public class LACPGroupSaveData
{
	public int groupId;

	public string deviceA;

	public string deviceB;

	public List<int> cableIds;
}
