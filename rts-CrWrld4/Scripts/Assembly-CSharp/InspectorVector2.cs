using UnityEngine;
using UnityEngine.UI;

public class InspectorVector2 : MonoBehaviour
{
	public Text propertyNameText;

	public InputField propertyFieldX;

	public InputField propertyFieldY;

	public Vector2 propertyValue
	{
		get
		{
			return default(Vector2);
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
