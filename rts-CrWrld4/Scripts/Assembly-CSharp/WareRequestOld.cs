using System.Collections.Generic;

public class WareRequestOld
{
	public enum PRIORITY
	{
		LOW = 0,
		NORMAL = 1,
		HIGH = 2
	}

	public int wareType;

	public UnitManager requester;

	public bool greedy;

	public PRIORITY priority;

	public int time;

	public Workall assignedWorkall;

	public List<IntPair> wareBias;

	public WareRequestOld(int wareType, UnitManager requester, bool greedy, PRIORITY priority)
	{
	}

	public void ReturnToOwner()
	{
	}
}
