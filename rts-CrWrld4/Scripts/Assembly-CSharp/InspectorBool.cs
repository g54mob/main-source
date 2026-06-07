using UnityEngine;
using UnityEngine.UI;

public class InspectorBool : MonoBehaviour
{
	public Text propertyNameText;

	public Toggle propertyToggle;

	public bool propertyValue
	{
		get
		{
			return false;
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
}
