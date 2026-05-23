using UnityEngine;

public class PhysicalCoinAnimator : MonoBehaviour
{
	public float animationTime = 0.5f;

	public AnimationCurve animationCurve;

	private float clock;

	private void Awake()
	{
		base.transform.localScale = Vector3.zero;
	}

	private void Update()
	{
		clock += Time.deltaTime;
		base.transform.localScale = Vector3.one * animationCurve.Evaluate(clock / animationTime);
		if (clock >= animationTime)
		{
			base.transform.localScale = Vector3.one;
			Object.Destroy(this);
		}
	}
}
