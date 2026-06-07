using Pathfinding.RVO;
using UnityEngine;

public class ScalePulse : MonoBehaviour
{
	public AnimationCurve scaleCurve;

	public float scaleIncrease = 0.4f;

	public float pulseSpeed = 1f;

	public bool onlyIfMoving;

	public RVOController rvo;

	private float velocitySqrtDeadzone = 0.15f;

	public bool randomizeClock;

	public float clock;

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
			base.transform.localScale = Vector3.one * (1f + scaleIncrease * scaleCurve.Evaluate(clock));
		}
	}
}
