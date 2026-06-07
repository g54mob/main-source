using Shapes;
using UnityEngine;

public class CorruptKingJumpMarker : MonoBehaviour
{
	public Disc innerDisc;

	public Disc outerDisc;

	public float overallTime;

	public float scaleUpTime;

	public AnimationCurve scaleUpCurve;

	public AnimationCurve fadeCurve;

	public Color fadeColor;

	private float initialRadius;

	private float clock;

	private Color initColor;

	private void Start()
	{
		initialRadius = innerDisc.Radius;
		innerDisc.transform.localScale = Vector3.zero;
		outerDisc.transform.localScale = Vector3.zero;
		initColor = outerDisc.Color;
	}

	private void Update()
	{
		clock += Time.deltaTime;
		Vector3 localScale = Vector3.one * scaleUpCurve.Evaluate(Mathf.InverseLerp(0f, scaleUpTime, clock));
		innerDisc.transform.localScale = localScale;
		outerDisc.transform.localScale = localScale;
		float t = Mathf.InverseLerp(0f, overallTime, clock);
		innerDisc.Radius = Mathf.Lerp(initialRadius, 0f, t);
		outerDisc.Color = Color.Lerp(initColor, fadeColor, t);
		if (clock > overallTime)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
