using UnityEngine;

public class WigglerVelocity : MonoBehaviour
{
	[SerializeField]
	private int stateCondition = -1;

	[SerializeField]
	private Vector3 direction;

	private Wiggler wiggler;

	private float time;

	private WigglerAnimationState wigglerAnimState;

	private void Start()
	{
		wiggler = GetComponent<Wiggler>();
		wigglerAnimState = wiggler.parentOverride.GetComponentInParent<WigglerAnimationState>();
		time = Random.Range(0f, 1000f);
	}

	private void Update()
	{
		if (stateCondition == -1)
		{
			PerformUpdate();
		}
		else if ((bool)wigglerAnimState && wigglerAnimState.animationState == stateCondition)
		{
			PerformUpdate();
		}
	}

	private void PerformUpdate()
	{
		wiggler.velocity += wiggler.parentOverride.rotation * direction * Time.deltaTime;
	}
}
