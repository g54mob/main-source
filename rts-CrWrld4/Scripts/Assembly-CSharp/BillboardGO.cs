using UnityEngine;

public class BillboardGO : MonoBehaviour
{
	public enum AllignmentAxis
	{
		X = 0,
		Y = 1,
		Z = 2,
		custom = 3
	}

	public AllignmentAxis alignmentAxis;

	public Vector3 customAxis;

	private void Update()
	{
	}
}
