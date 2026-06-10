using UnityEngine;

[CreateAssetMenu(fileName = "stairwell_data", menuName = "Database/Stairwell Preset")]
public class StairwellPreset : SoCustomComparison
{
	[Header("Setup")]
	public GameObject spawnObject;

	public GameObject objectTop;

	public GameObject centralSteps;

	[Header("Elevator")]
	[Tooltip("Does this stairwell feature an elevator?")]
	public bool featuresElevator;

	[Tooltip("The elevator object to spawn")]
	public GameObject elevatorObject;

	[Tooltip("How fast the elevator can travel")]
	public float elevatorMaxSpeed;

	[Tooltip("How fast the elevator can accelerate")]
	public float elevatorAcceleration;

	[Tooltip("The elevator accelerates if further away than this from its destination")]
	public float accelerateWhileThisFarAway;

	[Tooltip("How long the lift stays at a destination when there is somewhere else to go")]
	public float liftDelay;

	[Tooltip("How long the lift stays put after a new call when beginning movement")]
	public float movementDelay;
}
