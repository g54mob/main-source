using Shapes;
using UnityEngine;

public class CorruptKingBlastCircle : MonoBehaviour
{
	public Disc disc;

	public Color targetColor;

	public float animationTime;

	public AnimationCurve scaleCurve;

	public AnimationCurve colorCurve;

	private float clock;

	private Color initcol;

	private void Start()
	{
		initcol = disc.Color;
	}

	private void Update()
	{
		if (!(clock > animationTime))
		{
			clock += Time.deltaTime;
			float time = Mathf.InverseLerp(0f, animationTime, clock);
			disc.transform.localScale = Vector3.one * scaleCurve.Evaluate(time);
			disc.Color = Color.Lerp(initcol, targetColor, colorCurve.Evaluate(time));
		}
	}
}
