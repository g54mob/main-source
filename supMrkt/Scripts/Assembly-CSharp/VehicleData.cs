using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

[Serializable]
public class VehicleData
{
	public int Level;

	public TransformData TransformData;

	public List<BoxData> Boxes;

	[FormerlySerializedAs("OrderPaperBag")]
	public List<OrderPaperBagData> OrderPaperBags;

	public float GasLevel;
}
