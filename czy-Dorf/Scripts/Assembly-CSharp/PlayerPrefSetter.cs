using Dorfromantik;
using UnityEngine;

public class PlayerPrefSetter : MonoBehaviour
{
	private void SetInt(string key, int value)
	{
		PlayerPrefsAccessor.SetInt(key, value);
		Debug.Log($"Set PlayerPrefs Key {key} to {value}");
	}

	private void ClearKey(string key)
	{
		PlayerPrefsAccessor.DeleteKey(key);
		Debug.Log("Deleted PlayerPrefs Key " + key);
	}

	private void GetInt(string key)
	{
		PlayerPrefsAccessor.GetInt(key, -1);
		Debug.Log($"PlayerPrefs Key {key}: {PlayerPrefsAccessor.GetInt(key, -1)}");
	}
}
