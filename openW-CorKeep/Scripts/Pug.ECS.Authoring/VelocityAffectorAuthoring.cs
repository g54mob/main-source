using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(DirectionBasedOnVariationAuthoring))]
public class VelocityAffectorAuthoring : MonoBehaviour
{
	[Serializable]
	public struct MoveForceOption
	{
		public int2 moveForce;
	}

	[InfoBox("Should be added in respect to default rotation forward", EInfoBoxType.Normal)]
	public List<MoveForceOption> moveForceOptions;

	public int priority;

	public bool requiresElectricity;
}
