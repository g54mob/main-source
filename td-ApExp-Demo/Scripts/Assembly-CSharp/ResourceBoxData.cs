using UnityEngine;

public class ResourceBoxData
{
	public Vector2 ResourcePosition;

	public float ResourceAmount;

	public ResourceTypes ResourceType;

	public ResourceBoxData(Vector2 position, float amount, ResourceTypes type)
	{
		ResourcePosition = position;
		ResourceAmount = amount;
		ResourceType = type;
	}
}
