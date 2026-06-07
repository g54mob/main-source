using UnityEngine;
using UnityEngine.UI;

public class ScriptSettingsInspectorString : MonoBehaviour
{
	private ScriptSettingsDynamicContainer ssdc;

	public Text propertyNameText;

	public InputField propertyField;

	public string metadata;

	public GameObject resetButton;

	public string propertyValue
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string propertyName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void Init(ScriptSettingsDynamicContainer ssdc)
	{
	}

	public void RefreshDirty()
	{
	}

	public void OnReset()
	{
	}
}
