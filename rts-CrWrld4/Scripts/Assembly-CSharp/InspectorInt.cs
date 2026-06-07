using UnityEngine;
using UnityEngine.UI;

public class InspectorInt : MonoBehaviour
{
	public Text propertyNameText;

	public InputField propertyField;

	public string metadata;

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

	public void OnValueSet(string val)
	{
	}
}
