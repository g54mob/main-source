using System.Collections.Generic;
using UnityEngine;

public class WireComponent : BaseComponent
{
	[Header("Wire Variables")]
	public Vector3[] wirePoints;

	public float wireDepth;

	public float wireHeight;

	public float cornerRadius;

	public float cornerDegreeFactor;

	private readonly int COMPMASK;

	private LocalWirePoint[] localWps;

	private Ray ray;

	private RaycastHit hit;

	protected List<Vector3> cornerPoints;

	protected List<Vector3> actualWirePoints;

	protected void GenerateLocalWirePoints()
	{
	}

	public virtual void GenerateWire(bool finish)
	{
	}

	public virtual Vector3[] GenerateCornerPoints(Vector3[] points)
	{
		return null;
	}

	public override void Awake()
	{
	}

	public override object[] VarData()
	{
		return null;
	}

	public override void ProcessVarData(object[] data)
	{
	}

	public override object[] ReturnSaveData()
	{
		return null;
	}

	public override void ProcessSaveData(object[] data)
	{
	}

	public override void ParentCalledUpdate(params object[] args)
	{
	}

	public override void Clear()
	{
	}

	public override void FinishPlacement()
	{
	}
}
