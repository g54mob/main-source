using UnityEngine;
using UnityEngine.UI;

public class DisplayInt : MonoBehaviour
{
	public Text propertyNameText;

	public Text propertyField;

	private int actualValue;

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
}
