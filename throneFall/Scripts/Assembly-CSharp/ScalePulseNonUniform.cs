using Pathfinding.RVO;
using UnityEngine;

public class ScalePulseNonUniform : MonoBehaviour
{
	public AnimationCurve scaleCurve;

	public float scaleIncrease = 0.4f;

	public float pulseSpeed = 1f;

	public bool onlyIfMoving;

	public RVOController rvo;

	private float velocitySqrtDeadzone = 0.15f;

	public bool x;

	public bool y;

	public bool z;

	public bool randomizeClock;

	public float clock;

	private Vector3 newScaleVector = new Vector3(1f, 1f, 1f);

	private float desiredScale = 1f;

	private void Start()
	{
		if (randomizeClock)
		{
			clock = Random.value;
		}
	}

	private void Update()
	{
		if (!onlyIfMoving || rvo.velocity.sqrMagnitude > velocitySqrtDeadzone)
		{
			clock += Time.deltaTime * pulseSpeed;
		}
		desiredScale = 1f * (1f + scaleIncrease * scaleCurve.Evaluate(clock));
		if (x)
		{
			newScaleVector.x = desiredScale;
		}
		else
		{
			newScaleVector.x = 1f;
		}
		if (y)
		{
			newScaleVector.y = desiredScale;
		}
		else
		{
			newScaleVector.y = 1f;
		}
		if (z)
		{
			newScaleVector.z = desiredScale;
		}
		else
		{
			newScaleVector.z = 1f;
		}
		base.transform.localScale = newScaleVector;
	}
}
