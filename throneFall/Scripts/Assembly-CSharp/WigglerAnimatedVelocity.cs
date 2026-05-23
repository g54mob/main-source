using UnityEngine;

public class WigglerAnimatedVelocity : MonoBehaviour
{
	[SerializeField]
	private int stateCondition = -1;

	[SerializeField]
	private Vector3 direction;

	[SerializeField]
	private float timeSpeed = 1f;

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
		time += Time.deltaTime * timeSpeed;
		float num = Mathf.Sin(time) * Time.deltaTime;
		wiggler.velocity += wiggler.parentOverride.rotation * direction * num;
	}
}
