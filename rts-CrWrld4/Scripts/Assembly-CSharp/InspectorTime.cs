using UnityEngine;
using UnityEngine.UI;

public class InspectorTime : MonoBehaviour
{
	public Text propertyNameText;

	public InputField propertyFieldInt;

	public InputField propertyFieldFloat;

	public Button buttonFrames;

	public Button buttonSecs;

	private int _propertyValue;

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

	public float propertyValueSec
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

	public void SetValueInt(string val)
	{
	}

	public void SetValueFloat(string val)
	{
	}

	private void UpdateFields()
	{
	}

	public void OnSecClicked()
	{
	}

	public void OnFramesClicked()
	{
	}
}
