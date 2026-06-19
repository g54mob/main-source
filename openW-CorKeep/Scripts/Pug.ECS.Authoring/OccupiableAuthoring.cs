using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class OccupiableAuthoring : MonoBehaviour
{
	[Serializable]
	public struct OccupiableSlot
	{
		public float3 offsetForward;

		public float3 offsetRight;

		public float3 offsetBack;

		public float3 offsetLeft;
	}

	public List<OccupiableSlot> occupiableSlots = new List<OccupiableSlot>();
}
