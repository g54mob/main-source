using System;
using UnityEngine;

public class MVerseMoveGhost : MonoBehaviour
{
	[NonSerialized]
	public MVerseUnit mverseUnit;

	private Vector2 deployedPosition;

	private UnitManager.ORIENTATION deployedOrientation;

	public void DestroyMVerseMoveGhost()
	{
	}

	public void SetPosition(Vector2 position)
	{
	}

	public void UndeployFootprint()
	{
	}

	public void DeployFootprint(bool deploy, int gsx, int gsy, UnitManager.ORIENTATION orient)
	{
	}
}
