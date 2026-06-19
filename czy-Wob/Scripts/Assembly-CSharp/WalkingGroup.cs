using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WalkingGroup
{
	public List<GameObject> legs;

	public List<GameObject> groundedRequirements;

	public float offset;

	public Vector3 multiplier = new Vector3(1f, 1f, 1f);

	public bool jiggleTorque;
}
