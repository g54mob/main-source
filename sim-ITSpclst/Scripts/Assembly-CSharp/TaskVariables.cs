using System;
using System.Collections.Generic;

[Serializable]
public class TaskVariables
{
	public List<TaskVariable> variables;

	private TaskVariable GetVariable(string key)
	{
		return null;
	}

	private TaskVariable GetOrCreate(string key, string typeName)
	{
		return null;
	}

	public void SetString(string key, string value)
	{
	}

	public void SetInt(string key, int value)
	{
	}

	public void SetFloat(string key, float value)
	{
	}

	public void SetBool(string key, bool value)
	{
	}

	public string GetString(string key, string defaultValue = "")
	{
		return null;
	}

	public int GetInt(string key, int defaultValue = 0)
	{
		return 0;
	}

	public float GetFloat(string key, float defaultValue = 0f)
	{
		return 0f;
	}

	public bool GetBool(string key, bool defaultValue = false)
	{
		return false;
	}
}
