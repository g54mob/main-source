using System;

[Serializable]
public class GameModeTableData
{
	public string Key;

	public string Cozy;

	public string Normal;

	public string Nightmare;

	private string[] GetColumns()
	{
		return new string[3] { Cozy, Normal, Nightmare };
	}

	public bool HasKey(string key)
	{
		return Key.ToLower().Contains(key.ToLower());
	}

	public T GetValue<T>(int mode)
	{
		if (typeof(T) == typeof(bool))
		{
			return (T)Convert.ChangeType(GetValueAsBool(mode), typeof(T));
		}
		if (typeof(T) == typeof(int))
		{
			return (T)Convert.ChangeType(GetValueAsInt(mode), typeof(T));
		}
		if (typeof(T) == typeof(float))
		{
			return (T)Convert.ChangeType(GetValueAsFloat(mode), typeof(T));
		}
		return default(T);
	}

	public float GetValueAsFloat(int mode)
	{
		return float.Parse(GetColumns()[mode]);
	}

	public int GetValueAsInt(int mode)
	{
		return int.Parse(GetColumns()[mode]);
	}

	public bool GetValueAsBool(int mode)
	{
		return bool.Parse(GetColumns()[mode].ToLower());
	}
}
