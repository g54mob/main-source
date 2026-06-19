using Aggro.Core;
using UnityEngine;

public struct EvInboundArrived : IEntityEvent, IEntityTyped
{
	public Vector3 worldPosition;
}
