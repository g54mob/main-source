using UnityEngine;

public class UnitSpawnAppear : MonoBehaviour
{
	public AnimationCurve scaleCurve;

	public float animationTime;

	public float initialDelay;

	public Transform target;

	private float timer;

	private float delay;

	private void Awake()
	{
		target.localScale = Vector3.zero;
	}

	private void Update()
	{
		delay += Time.deltaTime;
		if (!(delay < initialDelay))
		{
			timer += Time.deltaTime;
			target.localScale = Vector3.one * scaleCurve.Evaluate(Mathf.InverseLerp(0f, animationTime, timer));
			if (timer > animationTime)
			{
				base.transform.localScale = Vector3.one;
				base.enabled = false;
			}
		}
	}
}
