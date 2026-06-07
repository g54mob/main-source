using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour
{
	public enum MouseAction
	{
		None = 0,
		Cancels = 1,
		MovesMap = 2,
		RotatesMap = 3
	}

	public enum WheelAction
	{
		None = 0,
		Zooms = 1
	}

	public class KeyData
	{
		public string title;

		public KeyCode primaryKey;

		public KeyCode primaryModifier;

		public KeyCode secondaryKey;

		public KeyCode secondaryModifier;

		public KeyRow keyRow;
	}

	public class KeyMapping
	{
		public KeyCode primaryKey;

		public KeyCode primaryModifier;

		public KeyCode secondaryKey;

		public KeyCode secondaryModifier;
	}

	public GameObject keysContainer;

	public GameObject keyRowPrefab;

	public ControlsGeneralSettings controlsGeneralSettings;

	public ControlsKeyGrabberPanel controlsKeyGrabberPanel;

	public static Dictionary<string, KeyMapping> keyMappings;

	public static MouseAction rightClick;

	public static MouseAction middleClick;

	public static WheelAction wheel;

	public static bool contextSensitive;

	public static float keyboardScroll;

	public static float bumpScroll;

	private static Toggle.ToggleEvent emptyToggleEvent;

	private static readonly Dictionary<string, KeyData> keysList;

	private static Dictionary<string, int> fireCounter;

	private static Dictionary<string, int> fireCount;

	public static bool catchKeySecondary;

	private static string _catchKey;

	public static string catchKey
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void KeyRowClicked(int button, KeyRow keyRow)
	{
	}

	public void ApplyCaughtKey()
	{
	}

	public void CancelCaughtKey()
	{
	}

	public void OnSaveKeysToFile()
	{
	}

	public void OnDefaultData()
	{
	}

	public static void SetToggleValue(Toggle instance, bool value)
	{
	}

	public void SetGUI()
	{
	}

	public static bool IsModifierKey(KeyCode key)
	{
		return false;
	}

	private static bool GetModifierKey()
	{
		return false;
	}

	private static bool GetModifierKeyDown()
	{
		return false;
	}

	private static bool GetModifierKeyUp()
	{
		return false;
	}

	private static bool GetAmbidextrousModifierKey(KeyCode key)
	{
		return false;
	}

	private static bool GetAmbidextrousModifierKeyDown(KeyCode key)
	{
		return false;
	}

	private static bool GetAmbidextrousModifierKeyUp(KeyCode key)
	{
		return false;
	}

	private static bool CheckKey(KeyCode key, KeyCode modifier)
	{
		return false;
	}

	private static bool CheckKeyDown(KeyCode key, KeyCode modifier)
	{
		return false;
	}

	private static bool CheckKeyUp(KeyCode key, KeyCode modifier)
	{
		return false;
	}

	public static bool GetKey(string keyName)
	{
		return false;
	}

	public static bool GetKeyDownRepeat(string key)
	{
		return false;
	}

	public static bool GetKeyDown(string keyName)
	{
		return false;
	}

	public static bool GetKeyDownPrimary(string keyName)
	{
		return false;
	}

	public static bool GetKeyDownSecondary(string keyName)
	{
		return false;
	}

	public static bool GetKeyUp(string keyName)
	{
		return false;
	}

	public static void SetKeyMappingPrimary(string keyName, KeyCode primaryKey, KeyCode primaryModifier)
	{
	}

	public static void SetKeyMappingSecondary(string keyName, KeyCode secondaryKey, KeyCode secondaryModifier)
	{
	}

	public static void SetKeyMapping(string keyName, KeyCode primaryKey, KeyCode primaryModifier, KeyCode secondaryKey, KeyCode secondaryModifier)
	{
	}

	public static KeyMapping GetKeyMapping(string keyName)
	{
		return null;
	}

	public static void RemovePrimaryKeyMappingByKey(string keyName, KeyCode key, KeyCode modifier)
	{
	}

	public static void RemoveSecondaryKeyMappingByKey(string keyName, KeyCode key, KeyCode modifier)
	{
	}

	public static string GetKeyNameFromKey(KeyCode key, KeyCode modifier, bool secondaryOnly = false)
	{
		return null;
	}

	public static bool AreContextRelated(string key1, string key2)
	{
		return false;
	}

	public static bool CanDup(string key1)
	{
		return false;
	}

	private static string GetModifierText(KeyCode kc)
	{
		return null;
	}

	public static string GetKeyText(KeyCode modifier, KeyCode key)
	{
		return null;
	}

	public static string GetKeyText(string keyName)
	{
		return null;
	}

	private static string PadString(string s, int len)
	{
		return null;
	}

	public static void Read()
	{
	}

	public static void Write()
	{
	}

	private static void DefaultData()
	{
	}
}
