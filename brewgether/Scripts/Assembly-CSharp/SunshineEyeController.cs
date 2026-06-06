using UnityEngine;

public class SunshineEyeController : MonoBehaviour
{
	[Header("Ride Controls")]
	public float rotationSpeed;

	public float rockingSpeed;

	public float rockingAmplitude;

	public Transform[] Compartments;

	public Transform[] wheelsForward;

	public Transform[] wheelsReverse;

	private float timeCounter;

	private void Update()
	{
	}
}
