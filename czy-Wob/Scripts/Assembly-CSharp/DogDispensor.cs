using UnityEngine;

public class DogDispensor : ClickableObject
{
	public Transform dispenseTransform;

	public GameObject bounceBoy;

	public GameObject smokeParticles;

	private Segment bounceSegment;

	protected float bounceTime = 0.5f;

	protected Vector3 bounceScaleStart = new Vector3(1f, 1f, 0.5f);

	protected float expelForce = 50f;

	protected float expelTorque = 50f;

	private bool needsHide;

	protected DogHome dogHomeRef;

	protected Inchworm inchwormRef;

	protected ObjectRegistration regRef;

	private void Start()
	{
		regRef = ObjectRegistration.GetRegistrationScript();
		dogHomeRef = regRef.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		inchwormRef = regRef.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		base.gameObject.SetActive(value: false);
	}

	public void ShowDispensor()
	{
		base.gameObject.SetActive(value: true);
		Object.Instantiate(smokeParticles, dispenseTransform.position, Quaternion.identity);
	}

	public void HideDispensor()
	{
		if (bounceSegment != null)
		{
			needsHide = true;
			return;
		}
		needsHide = false;
		base.gameObject.SetActive(value: false);
		Object.Instantiate(smokeParticles, base.transform.position, Quaternion.identity);
	}

	public void DispenseDog(GameObject dog)
	{
		if (bounceSegment != null)
		{
			inchwormRef.CancelAndFinishEase(ref bounceSegment);
		}
		dog.transform.rotation = Random.rotation;
		dog.transform.position = dispenseTransform.position;
		Rigidbody component = dog.GetComponent<LegController>().bodyBack.GetComponent<Rigidbody>();
		Rigidbody component2 = dog.GetComponent<LegController>().bodyFront.GetComponent<Rigidbody>();
		Vector3 force = expelForce * dispenseTransform.right;
		Vector3 torque = expelTorque * Random.rotation.eulerAngles;
		component.AddForce(force, ForceMode.VelocityChange);
		component2.AddForce(force, ForceMode.VelocityChange);
		component.AddRelativeTorque(torque, ForceMode.VelocityChange);
		component2.AddRelativeTorque(torque, ForceMode.VelocityChange);
		bounceBoy.transform.localScale = bounceScaleStart;
		bounceSegment = inchwormRef.RequestEaseToScale(bounceBoy, Vector3.one, bounceTime, Inchworm.EaseStyle.ElasticOut, BounceCallback);
	}

	private void BounceCallback()
	{
		bounceSegment = null;
		if (needsHide)
		{
			HideDispensor();
		}
	}
}
