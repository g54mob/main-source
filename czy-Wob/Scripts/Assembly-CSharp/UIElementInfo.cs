using UnityEngine;

public static class UIElementInfo
{
	public static GameObject GetObjectForElementType(GraphicType type)
	{
		switch (type)
		{
		case GraphicType.SQUARE:
			return SquareElement();
		case GraphicType.ROUNDED_SQUARE:
			return RoundedSquareElement();
		case GraphicType.CIRCLE:
			return CircleElement();
		default:
			Debug.LogError("Invalid element type: " + type);
			return null;
		}
	}

	private static GameObject SquareElement()
	{
		return ConfigureStandardElement(GameObject.CreatePrimitive(PrimitiveType.Cube));
	}

	private static GameObject RoundedSquareElement()
	{
		return ConfigureStandardElement(GameObject.CreatePrimitive(PrimitiveType.Cube));
	}

	private static GameObject CircleElement()
	{
		return ConfigureStandardElement(GameObject.CreatePrimitive(PrimitiveType.Sphere));
	}

	private static GameObject ConfigureStandardElement(GameObject element)
	{
		element.layer = LayerMask.NameToLayer("UI");
		Object.Destroy(element.GetComponent<Collider>());
		return element;
	}
}
