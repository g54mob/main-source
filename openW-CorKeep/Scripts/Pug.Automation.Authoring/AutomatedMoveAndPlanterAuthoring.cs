using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(AutomatedMoverSharedAuthoring))]
public class AutomatedMoveAndPlanterAuthoring : MonoBehaviour
{
	[Serializable]
	public struct AffectedPositions
	{
		public int2 position;

		public int2 moveVector;
	}

	[InfoBox("Should be added in respect to default rotation forward", EInfoBoxType.Normal)]
	public List<AffectedPositions> affectedPositions;
}
