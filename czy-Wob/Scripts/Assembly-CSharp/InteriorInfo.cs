using UnityEngine;

public struct InteriorInfo
{
	public int index;

	public GameObject obj;

	public ulong associatedDenUID;

	public BoundingBoxComponent bbcRef;

	public InteriorInfo(int newIndex, GameObject newObj, ulong denUID)
	{
		obj = newObj;
		index = newIndex;
		associatedDenUID = denUID;
		bbcRef = newObj.GetComponent<BoundingBoxComponent>();
	}
}
