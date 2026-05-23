using Pathfinding.RVO;
using UnityEngine;
using UnityEngine.Events;

public class SimpleWalk : MonoBehaviour
{
	public RVOController rvo;

	public Transform animationRoot;

	public float bounceHeight = 0.5f;

	public AnimationCurve bounceCurve;

	public float bounceSpeed = 1f;

	private float bounceClock;

	private float clockDelta;

	private float velocitySqrtDeadzone = 0.15f;

	[HideInInspector]
	public UnityEvent onGroundContact = new UnityEvent();

	private float lastGroundContactTimeStamp;

	private Vector3 initialRootPos;

	private void Start()
	{
		initialRootPos = animationRoot.localPosition;
		bounceClock = Random.value;
	}

	private void Update()
	{
		if (rvo.velocity.sqrMagnitude > velocitySqrtDeadzone)
		{
			clockDelta = Time.deltaTime * bounceSpeed;
			bounceClock += clockDelta;
			animationRoot.transform.localPosition = Vector3.Lerp(initialRootPos, initialRootPos + Vector3.up * bounceHeight, bounceCurve.Evaluate(bounceClock));
			if (bounceClock % 1f <= clockDelta && Mathf.Abs(bounceClock - lastGroundContactTimeStamp) > 0.5f)
			{
				lastGroundContactTimeStamp = bounceClock;
				onGroundContact.Invoke();
			}
		}
		else
		{
			animationRoot.transform.localPosition = initialRootPos;
			bounceClock = 0f;
		}
	}
}
