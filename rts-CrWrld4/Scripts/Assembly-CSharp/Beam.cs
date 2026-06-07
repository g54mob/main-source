using System;
using NBT.Tags;
using UnityEngine;

public class Beam : MonoBehaviour
{
	[NonSerialized]
	public int beamUID;

	[NonSerialized]
	public LineRenderer lr;

	[NonSerialized]
	public UnitManager attachedToUnit;

	[NonSerialized]
	public string attachedToObj;

	private Transform attachedToTransform;

	private bool forceLocalEnd;

	private Vector3 end;

	private string colorMat;

	private float hdr;

	private bool visible;

	private bool dead;

	private Vector3 lastUnitPos;

	public void Awake()
	{
	}

	public void DestroyBeam()
	{
	}

	public void LateUpdate()
	{
	}

	public void Attach(CModUnitManager unit, string objName)
	{
	}

	public void SetBeamVisible(bool visible)
	{
	}

	public void SetForceLocalEnd(bool force)
	{
	}

	public string GetBeamColorMat()
	{
		return null;
	}

	public void SetBeamColorMat(string colorMat)
	{
	}

	public float GetBeamHDR()
	{
		return 0f;
	}

	public void SetBeamHDR(float hdr)
	{
	}

	public void SetBeamWidth(float width)
	{
	}

	public void SetBeamStartPos(Vector3 start)
	{
	}

	public void SetBeamEndPos(Vector3 end)
	{
	}

	public void SetBeamPos(Vector3 start, Vector3 end)
	{
	}

	public static Material GetBeamMaterial(string colorMat)
	{
		return null;
	}

	public void ReadData(Tag t)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}
