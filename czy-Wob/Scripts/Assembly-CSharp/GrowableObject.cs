using UnityEngine;

[CreateAssetMenu(fileName = "GrowableObject", menuName = "GrowableObject/Growable", order = 1)]
public class GrowableObject : ScriptableObject
{
	public float growTime;

	public InventoryItem finalObject;

	public bool startUnlocked;
}
