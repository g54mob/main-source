using System;

[Serializable]
public class ResultPing
{
	public string Description;

	public string DetailedDescription;

	public bool isError;

	public string networkTree;

	public ResultPing(string _des, bool _error, string _det_des = "")
	{
	}

	public string GetDescription()
	{
		return null;
	}
}
