using UnityEngine;

public class BreadboardBody : BaseComponent
{
	[Header("TiePoints")]
	public Vector3 E1Pos;

	public Vector3 J1Pos;

	public int col;

	public int row;

	public float spacing;

	public float tiePointSize;

	[Header("Highlight")]
	public Transform highlightTr;

	public QuickOutline highlightOutline;

	public override void Awake()
	{
	}

	public override TiePoint FindTiePoint(int i)
	{
		return null;
	}

	public override TiePoint RaycastTiePoints(Vector3 worldHit, bool display)
	{
		return null;
	}

	public override void EndRaycast()
	{
	}

	public override object[] ReturnSaveData()
	{
		return null;
	}

	public override object[] ReturnXMLSaveData()
	{
		return null;
	}

	public override void ProcessSaveData(object[] data)
	{
	}

	public override object[] VarData()
	{
		return null;
	}

	public override bool ValuesChanged(object[] data)
	{
		return false;
	}

	public override void ProcessVarData(object[] data)
	{
	}

	public override bool PositionValid()
	{
		return false;
	}

	public override void OnTriggerStay(Collider other)
	{
	}

	public override void OnTriggerExit(Collider other)
	{
	}
}
