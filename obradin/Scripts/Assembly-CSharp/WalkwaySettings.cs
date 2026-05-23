using UnityEngine;

public class WalkwaySettings : ScriptableObject
{
	public float browHeight = 1.5f;

	public float kneeHeight = 0.5f;

	public float shapeExpand = 0.1f;

	public float simplificationDist = 0.03f;

	public float minShapeArea = 20f;

	public string ToCacheString()
	{
		return string.Format("{0} {1} {2} {3} {4}", browHeight, kneeHeight, shapeExpand, simplificationDist, minShapeArea);
	}
}
