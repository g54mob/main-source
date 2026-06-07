using System;
using UnityEngine;
using UnityEngine.UI;

public class OpacitySin : MonoBehaviour
{
	private Color defaultColor;

	private Image image;

	public float frequencyUp;

	public float frequencyDown;

	public float minOp;

	public float maxOp;

	private float delta;

	private Color c;

	private float timer;

	private int skipTicks = 1;

	private int curTick;

	private float curFreq;

	private void Start()
	{
		image = base.gameObject.GetComponent<Image>();
		defaultColor = image.color;
		delta = maxOp - minOp;
		timer = 0f;
		c = defaultColor;
		skipTicks = 2;
	}

	private void Update()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		if (curTick % skipTicks == 0)
		{
			timer = Mathf.Repeat(timer, MathF.PI);
			curFreq = frequencyUp;
			if (timer > MathF.PI / 2f)
			{
				curFreq = frequencyDown;
			}
			timer += Time.unscaledDeltaTime * curFreq * (float)skipTicks;
			c.a = minOp + Mathf.Abs(Mathf.Sin(timer)) * delta;
			image.color = c;
			curTick = 1;
		}
		else
		{
			curTick++;
		}
	}
}
