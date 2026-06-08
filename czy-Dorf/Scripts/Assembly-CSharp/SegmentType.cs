using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;

public class SegmentType : ScriptableObject
{
	public SegmentTypeId id;

	public int primaryVariant;

	public int SubVariant;

	public Vector3 centerPos;

	public List<int> edges;

	public Instanceable segmentGroundInstanceable;
}
