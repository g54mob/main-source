using System;

[Serializable]
public class BaseTask
{
	public int CurSecs;

	public int TgtSecs;

	public BaseTask(int tgtSecs)
	{
	}

	public bool AddSecs(int secs)
	{
		return false;
	}
}
