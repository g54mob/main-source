using System.Collections.Generic;
using UnityEngine;

public class PhysicalWire : MonoBehaviour
{
	[Header("Physics")]
	public Transform anchorTransform;

	public Transform root;

	[Header("Rendering")]
	public WireRenderer internalRenderer;

	public WireRenderer sheathRenderer;

	public int wireCol;

	[Header("Params")]
	public float cornerRadius;

	public float wireRadius;

	public float sheathRadius;

	public float cornerDegreeFactor;

	public float wireDepth;

	public float wireHeight;

	public List<Vector3> wirePoints;

	private List<Vector3> cornerPoints;

	private Vector3[] cPoints;

	private TiePoint tiePoint;

	public bool finished;

	private void Awake()
	{
	}

	public void SetAnchorPosition(Vector3 pos)
	{
	}

	public void FinishPlacement(TiePoint tp)
	{
	}

	public void UpdatePlacement()
	{
	}

	private void Update()
	{
	}

	public virtual void GenerateCurvePoints(bool finish)
	{
	}
}
