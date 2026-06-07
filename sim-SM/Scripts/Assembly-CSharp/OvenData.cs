using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OvenData : MonoBehaviour
{
	public int FurnitureID;

	public TransformData Transform;

	public List<ItemQuantity> DisplaySlots;
}
