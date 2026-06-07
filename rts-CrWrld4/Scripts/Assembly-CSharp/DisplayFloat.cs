using UnityEngine;
using UnityEngine.UI;

public class DisplayFloat : MonoBehaviour
{
	public Text propertyNameText;

	public Text propertyField;

	private float actualValue;

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
