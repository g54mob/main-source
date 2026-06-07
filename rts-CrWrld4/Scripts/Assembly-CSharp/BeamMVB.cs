using System;
using UnityEngine;

public class BeamMVB : MonoBehaviour
{
	[NonSerialized]
	public LineRenderer lr;

	private bool dead;

	public void Awake()
	{
	}

	public void DestroyBeam()
	{
	}

	public void SetBeamVisible(bool visible)
	{
	}

	public void SetBeamColorMat(string colorMat)
	{
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
}
