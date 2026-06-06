using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[AddComponentMenu("Malbers/Utilities/Managers/Scritable Var to Player Pref (Save|Load)")]
	public class ScriptableVarToPlayerPref : MonoBehaviour
	{
		[Tooltip("Set of Scriptable variables you want to save on Player Pref")]
		public ScriptableVar[] userPreferences;

		[CreateScriptableAsset]
		[Tooltip("Restore the Array of Variables to their default Options")]
		public ResetScriptableVarsAsset defaultUserOptions;

		[Tooltip("All values will be save to <PlayerPref> On Disable")]
		public bool SaveOnExit = true;

		public bool debug = true;

		private void Start()
		{
			if (PlayerPrefs.GetInt("GameInitalized") == 0)
			{
				PlayerPrefs.SetInt("GameInitalized", 1);
				defaultUserOptions?.Restart();
				SaveUserPreferences();
			}
			else
			{
				GetUserPreferences();
			}
			base.transform.parent = null;
			Object.DontDestroyOnLoad(base.transform);
		}

		private void OnDisable()
		{
			if (SaveOnExit)
			{
				SaveUserPreferences();
			}
		}

		public void RestoreToDefault()
		{
			defaultUserOptions.Restart();
		}

		public void GetUserPreferences()
		{
			ScriptableVar[] array = userPreferences;
			foreach (ScriptableVar scriptableVar in array)
			{
				string text = "";
				if (scriptableVar is IntVar)
				{
					text = ((scriptableVar as IntVar).Value = PlayerPrefs.GetInt(scriptableVar.name)).ToString();
				}
				else if (scriptableVar is BoolVar)
				{
					text = ((scriptableVar as BoolVar).Value = StringToBool(PlayerPrefs.GetString(scriptableVar.name))).ToString();
				}
				else if (scriptableVar is FloatVar)
				{
					text = ((scriptableVar as FloatVar).Value = PlayerPrefs.GetFloat(scriptableVar.name)).ToString();
				}
				else if (scriptableVar is StringVar)
				{
					string text2 = ((scriptableVar as StringVar).Value = PlayerPrefs.GetString(scriptableVar.name));
					text = text2.ToString();
				}
				else
				{
					Debug.LogError("Unacceptable ScriptableVar used: " + scriptableVar.name);
				}
				if (debug)
				{
					Debug.Log("Get Value From Player Pref: " + scriptableVar.name + " -> [" + text + "]", this);
				}
			}
		}

		public void SaveUserPreferences()
		{
			ScriptableVar[] array = userPreferences;
			foreach (ScriptableVar scriptableVar in array)
			{
				string text = "";
				if (scriptableVar is IntVar)
				{
					int value = (scriptableVar as IntVar).Value;
					PlayerPrefs.SetInt(scriptableVar.name, value);
					text = value.ToString();
				}
				else if (scriptableVar is BoolVar)
				{
					string text2 = (scriptableVar as BoolVar).Value.ToString();
					PlayerPrefs.SetString(scriptableVar.name, text2);
					text = text2;
				}
				else if (scriptableVar is FloatVar)
				{
					float value2 = (scriptableVar as FloatVar).Value;
					PlayerPrefs.SetFloat(scriptableVar.name, value2);
					text = value2.ToString();
				}
				else if (scriptableVar is StringVar)
				{
					string value3 = (scriptableVar as StringVar).Value;
					PlayerPrefs.SetString(scriptableVar.name, value3);
					text = value3;
				}
				else
				{
					Debug.LogError("Unacceptable ScriptableVar used: " + scriptableVar.name);
				}
				if (debug)
				{
					Debug.Log("Set Value to Player Pref: " + scriptableVar.name + " -> [" + text + "]", this);
				}
			}
			PlayerPrefs.Save();
		}

		public void DeleteAllPreferences()
		{
			PlayerPrefs.DeleteAll();
		}

		private bool StringToBool(string value)
		{
			if (value.ToLower() == "true")
			{
				return true;
			}
			if (value.ToLower() == "false")
			{
				return false;
			}
			Debug.Log("A string is neither 'true' nor 'false', returning false");
			return false;
		}
	}
}
