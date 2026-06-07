using Shapes;
using UnityEngine;

public class ShapeGroupFader : MonoBehaviour
{
	public ShapeGroup target;

	public float fadeTime = 1f;

	public AnimationCurve fadeCurve;

	private Color groupColor = Color.white;

	private float clock;

	private bool running = true;

	private void Update()
	{
		if (running)
		{
			clock += Time.deltaTime;
			groupColor.a = fadeCurve.Evaluate(Mathf.InverseLerp(0f, fadeTime, clock));
			target.Color = groupColor;
			if (clock >= fadeTime)
			{
				running = false;
			}
		}
	}
}
