using Pug.UnityExtensions;
using UnityEngine;

public class TorchHalo : MonoBehaviour
{
	public SpriteRenderer sr;

	private Vector3 basePos;

	private float baseAlpha;

	private TimerSimple ac = new TimerSimple(1f / 15f, unscaled: true);

	private void Awake()
	{
		basePos = base.transform.localPosition;
		baseAlpha = sr.color.a;
	}

	private void Start()
	{
		ac.Start();
	}

	private void LateUpdate()
	{
		if (ac.isTimerElapsed)
		{
			ac.Start();
			sr.transform.localPosition = basePos + new Vector3(0.0625f * Random.Range(-1f, 1f), 0.0625f * Random.Range(-1f, 1f), 0f);
			sr.color = sr.color.ColorWithNewAlpha(Mathf.Clamp01(Random.Range(baseAlpha * 0.8f, baseAlpha * 1.2f)));
			sr.flipX = Random.value > 0.5f;
			sr.flipY = Random.value > 0.5f;
		}
	}
}
