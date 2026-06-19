using ClockStone;
using UnityEngine;

public class IndustrialFan : MonoBehaviour
{
	public GameObject spinny;

	public ParticleSystem windParticles;

	public AnimationCurve windForceCurve;

	public Transform positionReferenceTransformStart;

	public Transform positionReferenceTransformEnd;

	private string fanTurnOnSound = "fan_turn_on";

	private string fanTurnOffSound = "fan_turn_off";

	private string fanLoopSound = "fan_loop";

	private AudioObject fanLoopAudioObject;

	private float spinSpeedHigh = 1500f;

	private Vector3 spinAxis = new Vector3(1f, 0f, 0f);

	private float fanForce = 150f;

	private bool turnedOn;

	private float windForceDistance;

	private void Awake()
	{
		windForceDistance = Vector3.Distance(positionReferenceTransformStart.position, positionReferenceTransformEnd.position);
		TurnOff(fromLoad: true);
	}

	private void OnEnable()
	{
		if (!IsCurrentlyOn())
		{
			windParticles.Stop();
		}
	}

	private void OnDestroy()
	{
		if (fanLoopAudioObject != null)
		{
			fanLoopAudioObject.Stop();
			fanLoopAudioObject = null;
		}
	}

	public void Save(SaveablePlacedObject saveableObject)
	{
		saveableObject.boolList.Add(turnedOn);
	}

	public void Load(SaveablePlacedObject saveableObject)
	{
		if (saveableObject.boolList.Count != 0)
		{
			if (saveableObject.boolList[0])
			{
				TurnOn(fromLoad: true);
			}
			else
			{
				TurnOff(fromLoad: true);
			}
		}
	}

	private void Update()
	{
		if (IsCurrentlyOn())
		{
			Spin();
		}
	}

	public bool IsCurrentlyOn()
	{
		return turnedOn;
	}

	public void TurnOn(bool fromLoad = false)
	{
		turnedOn = true;
		windParticles.Play();
		if (!fromLoad)
		{
			AudioController.Play(fanTurnOnSound, base.transform.position);
			fanLoopAudioObject = AudioController.Play(fanLoopSound, base.transform.position);
			if (fanLoopAudioObject != null)
			{
				fanLoopAudioObject.FadeIn(0.7f);
			}
		}
		else
		{
			fanLoopAudioObject = AudioController.Play(fanLoopSound, base.transform.position);
		}
	}

	public void TurnOff(bool fromLoad = false)
	{
		turnedOn = false;
		windParticles.Stop();
		if (fanLoopAudioObject != null)
		{
			fanLoopAudioObject.Stop();
			fanLoopAudioObject = null;
		}
		if (!fromLoad)
		{
			AudioController.Play(fanTurnOffSound, base.transform.position);
		}
	}

	public void OnColliderInTriggerArea(Collider collider)
	{
		if (turnedOn)
		{
			string text = collider.transform.root.gameObject.tag;
			if (text == Tags.DOG || ObjectGrabber.IsTagDraggable(text))
			{
				LaunchObject(collider.gameObject);
			}
		}
	}

	private void LaunchObject(GameObject obj)
	{
		float num = 1f;
		Gravboost component = obj.GetComponent<Gravboost>();
		Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
		if (rigidbody == null)
		{
			rigidbody = obj.transform.root.gameObject.GetComponentInChildren<Rigidbody>();
			if (rigidbody == null)
			{
				Debug.LogError("Attempting to launch an object without an easily accessible rigidbody.");
				return;
			}
		}
		if (component != null)
		{
			num = 2f;
		}
		Vector3 position = rigidbody.transform.position;
		Vector3 b = MathUtil.NearestPointOnLine(positionReferenceTransformStart.position, positionReferenceTransformEnd.position, position);
		float time = Vector3.Distance(positionReferenceTransformStart.position, b) / windForceDistance;
		float num2 = windForceCurve.Evaluate(time);
		Vector3 vector = fanForce * -base.transform.forward * num;
		rigidbody.AddForce(vector * num2, ForceMode.Force);
	}

	private void Spin()
	{
		spinny.transform.Rotate(spinAxis, spinSpeedHigh * Time.deltaTime);
	}
}
