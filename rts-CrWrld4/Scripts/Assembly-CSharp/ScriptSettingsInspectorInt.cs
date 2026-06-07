using UnityEngine;
using UnityEngine.UI;

public class ScriptSettingsInspectorInt : MonoBehaviour
{
	private ScriptSettingsDynamicContainer ssdc;

	public Text propertyNameText;

	public InputField propertyField;

	public string metadata;

	public GameObject resetButton;

	public int minValue;

	public int maxValue;

	public int propertyValue
	{
		get
		{
			return 0;
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

	public void OnValueSet(string val)
	{
	}

	public void OnReset()
	{
	}
}
