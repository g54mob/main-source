using UnityEngine;

public class ThrusterRotator : MonoBehaviour
{
	[SerializeField]
	private Vector3 rotationAxis = Vector3.right;

	[SerializeField]
	private float maxRPM = 400f;

	private Thruster thruster;

	private void Awake()
	{
		thruster = GetComponentInParent<Thruster>();
		base.transform.Rotate(rotationAxis, Random.Range(0, 360), Space.Self);
	}

	private void Update()
	{
		float num = thruster.CurrentThrust / thruster.MaxThrust * maxRPM * 6f;
		base.transform.Rotate(rotationAxis, Time.deltaTime * num, Space.Self);
	}
}
