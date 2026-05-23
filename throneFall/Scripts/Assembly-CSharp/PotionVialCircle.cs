using Shapes;
using UnityEngine;

public class PotionVialCircle : MonoBehaviour
{
	public Disc disc;

	public float animTime;

	public float activateAt;

	public Color targetColor;

	private float clock;

	private Color originalColor;

	private void Start()
	{
		disc.enabled = false;
		originalColor = disc.Color;
	}

	private void Update()
	{
		clock += Time.deltaTime;
		float t = Mathf.InverseLerp(0f, animTime, clock);
		if (clock > activateAt && !disc.enabled)
		{
			disc.enabled = true;
		}
		disc.Color = Color.Lerp(originalColor, targetColor, t);
	}
}
