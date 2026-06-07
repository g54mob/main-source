using UnityEngine;
using UnityEngine.UI;

public class ScriptSettingsInspectorFloat : MonoBehaviour
{
	private ScriptSettingsDynamicContainer ssdc;

	public Text propertyNameText;

	public InputField propertyField;

	public string metadata;

	public GameObject resetButton;

	public float propertyValue
	{
		get
		{
			return 0f;
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
