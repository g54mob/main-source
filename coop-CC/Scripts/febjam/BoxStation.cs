using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using UnityEngine;

public class BoxStation : NetworkEntityBehaviourBase
{
	public enum RotationStrategy
	{
		CameraFacing = 0,
		FourDirections = 1,
		EightDirections = 2
	}

	public RotationStrategy rotationStrategy;

	public GameObject stationPrefab;

	public GameObject previewPrefab;

	[Space]
	[Min(0f)]
	public float stationCheckSizeX = 1f;

	[Min(0f)]
	public float stationCheckSizeZ = 1f;

	public bool checkForBoxesAndPlayers = true;

	[Space]
	public string warehousePlacedAchievement;

	public EventReference placementSFXEvent;

	private static readonly float[] CAMERA_FACING_ANGLES = new float[3] { 180f, 135f, 225f };

	private static readonly float[] FOUR_FACING_ANGLES = new float[4] { 0f, 90f, 180f, 270f };

	private static readonly float[] EIGHT_FACING_ANGLES = new float[8] { 0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f };

	public float[] GetAngles()
	{
		return rotationStrategy switch
		{
			RotationStrategy.CameraFacing => CAMERA_FACING_ANGLES, 
			RotationStrategy.FourDirections => FOUR_FACING_ANGLES, 
			RotationStrategy.EightDirections => EIGHT_FACING_ANGLES, 
			_ => throw new InvalidEnumException(), 
		};
	}

	public int GetDefaultAngleIndex()
	{
		return rotationStrategy switch
		{
			RotationStrategy.CameraFacing => 0, 
			RotationStrategy.FourDirections => 2, 
			RotationStrategy.EightDirections => 4, 
			_ => throw new InvalidEnumException(), 
		};
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(base.transform.position, new Vector3(stationCheckSizeX, 1f, stationCheckSizeZ));
	}

	public override bool Weaved()
	{
		return true;
	}
}
