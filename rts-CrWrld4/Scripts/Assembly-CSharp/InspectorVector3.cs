using UnityEngine;
using UnityEngine.UI;

public class InspectorVector3 : MonoBehaviour
{
	public Text propertyNameText;

	public InputField propertyFieldX;

	public InputField propertyFieldY;

	public InputField propertyFieldZ;

	public Vector3 propertyValue
	{
		get
		{
			return default(Vector3);
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
