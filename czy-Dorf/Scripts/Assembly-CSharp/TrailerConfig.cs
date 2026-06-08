using System;
using UnityEngine;

[Serializable]
public class TrailerConfig
{
	public Vector3 trailerCamStartPos;

	public Vector3 trailerCamStartRot;

	public Vector3 trailerCamEndPos;

	public Vector3 trailerCamEndRot;

	public float trailerCamDuration;

	public int trailerCamLoopType = 2;

	public float automaticallyStartExtraRotationAfterSeconds = -1f;

	public Vector3 extraRotation;

	public float extraRotationDuration;

	public int biomeSe;

	public int biomeSw;

	public int biomeNe;

	public int biomeNw;

	public string loadGameName;
}
