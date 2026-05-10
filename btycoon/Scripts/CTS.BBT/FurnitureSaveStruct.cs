using System;
using UnityEngine;

[Serializable]
public struct FurnitureSaveStruct
{
	public string furnitureName;

	public Vector3 positionFurnitures;

	public Quaternion rotationFurnitures;

	public SlottedFurnitureSaveStruct[] slotedFurniture;
}
