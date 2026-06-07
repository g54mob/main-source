using System;
using System.ComponentModel;
using UnityEngine;

public abstract class ModBehaviour : MonoBehaviour
{
	public enum MessageTarget
	{
		Everyone = 0,
		EveryoneButMe = 1,
		EveryoneExcept = 2,
		Specifically = 3,
		Host = 4
	}

	public ModController.DLLMod ParentMod;

	public abstract void OnDeactivate();

	public abstract void OnActivate();

	public void SaveSetting(string settingName, string value)
	{
		if (ParentMod == null)
		{
			ModController.HandleException(null, new Exception("Tried to write setting " + settingName + " before mod was fully loaded"));
		}
		else
		{
			ParentMod.SaveSetting(settingName, value);
		}
	}

	public void SaveSetting<T>(string settingName, T value)
	{
		if (ParentMod == null)
		{
			ModController.HandleException(null, new Exception("Tried to write setting " + settingName + " before mod was fully loaded"));
		}
		else
		{
			ParentMod.SaveSetting(settingName, value.ToString());
		}
	}

	public void DeleteSetting(string settingName)
	{
		if (ParentMod == null)
		{
			ModController.HandleException(null, new Exception("Tried to delete setting " + settingName + " before mod was fully loaded"));
		}
		else
		{
			ParentMod.DeleteSetting(settingName);
		}
	}

	public string LoadSetting(string settingName, string defaultValue = null)
	{
		if (ParentMod == null)
		{
			ModController.HandleException(null, new Exception("Tried to load setting " + settingName + " before mod was fully loaded"));
			return defaultValue;
		}
		string value;
		if (!ParentMod.Settings.TryGetValue(settingName, out value))
		{
			return defaultValue;
		}
		return value.ToString();
	}

	public T LoadSetting<T>(string settingName, T defaultValue = default(T))
	{
		if (ParentMod == null)
		{
			ModController.HandleException(null, new Exception("Tried to load setting " + settingName + " before mod was fully loaded"));
			return defaultValue;
		}
		string value;
		if (ParentMod.Settings.TryGetValue(settingName, out value))
		{
			try
			{
				return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value);
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}
		return defaultValue;
	}

	public bool TryLoadSetting<T>(string settingName, out T value)
	{
		value = default(T);
		if (ParentMod == null)
		{
			ModController.HandleException(null, new Exception("Tried to load setting " + settingName + " before mod was fully loaded"));
			return false;
		}
		string value2;
		if (ParentMod.Settings.TryGetValue(settingName, out value2))
		{
			try
			{
				value = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value2);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		return false;
	}

	public virtual void Serialize(WriteDictionary data, GameReader.LoadMode mode)
	{
	}

	public virtual void Deserialize(WriteDictionary data, GameReader.LoadMode mode)
	{
	}
}
