using UnityEngine;
using UnityEngine.UI;

public class InspectorFloat : MonoBehaviour
{
	public Text propertyNameText;

	public InputField propertyField;

	public string metadata;

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
}
