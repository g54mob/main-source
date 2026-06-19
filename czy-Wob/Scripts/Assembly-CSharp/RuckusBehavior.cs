using UnityEngine;

public class RuckusBehavior : MonoBehaviour
{
	public delegate void RuckusFinishedCallback();

	private float baseTorque = 500f;

	private float jiggleTorque = 500f;

	private float startTorqueTime = 0.1f;

	private float currentTorqueTime;

	private LegController controllerRef;

	private bool isMakingRuckus;

	private void Awake()
	{
		controllerRef = base.gameObject.GetComponent<LegController>();
	}

	private void FixedUpdate()
	{
		if (isMakingRuckus && currentTorqueTime < startTorqueTime)
		{
			InitializeRuckus();
		}
	}

	public void RequestRuckus(RuckusFinishedCallback callback = null)
	{
		if (!isMakingRuckus)
		{
			StartRuckus();
			callback?.Invoke();
		}
	}

	public void RequestRuckusEnd()
	{
		if (isMakingRuckus)
		{
			StopRuckus();
		}
	}

	private void StartRuckus()
	{
		isMakingRuckus = true;
		currentTorqueTime = 0f;
		foreach (GameObject allLeg in controllerRef.GetAllLegs())
		{
			allLeg.GetComponent<Stabilizer>().RequestRuckus();
		}
	}

	private void StopRuckus()
	{
		isMakingRuckus = false;
		foreach (GameObject allLeg in controllerRef.GetAllLegs())
		{
			allLeg.GetComponent<Stabilizer>().RequestRuckusEnd();
		}
	}

	private void InitializeRuckus()
	{
		Vector3 finalTorque = new Vector3(baseTorque + Random.Range(0f - jiggleTorque, jiggleTorque), baseTorque + Random.Range(0f - jiggleTorque, jiggleTorque), baseTorque + Random.Range(0f - jiggleTorque, jiggleTorque));
		Vector3 finalTorque2 = new Vector3(baseTorque + Random.Range(0f - jiggleTorque, jiggleTorque), baseTorque + Random.Range(0f - jiggleTorque, jiggleTorque), baseTorque + Random.Range(0f - jiggleTorque, jiggleTorque));
		controllerRef.AddCalculatedTorque(controllerRef.bodyBack.GetComponent<Rigidbody>(), finalTorque);
		controllerRef.AddCalculatedTorque(controllerRef.bodyFront.GetComponent<Rigidbody>(), finalTorque2);
		currentTorqueTime += Time.fixedDeltaTime;
	}
}
