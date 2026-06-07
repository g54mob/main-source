using System;
using UnityEngine;

public class EyeScript : MonoBehaviour
{
	public float Energy = 1f;

	public float blink;

	public bool Happy;

	public bool blinkNow;

	public bool sleep;

	public float NextBlink;

	[NonSerialized]
	public Material Face;

	public void UpdateMe()
	{
		if (GameSettings.GameSpeed == 0f)
		{
			return;
		}
		if (sleep)
		{
			if (Face != null)
			{
				Face.SetInt("_EyeNum", 0);
			}
			return;
		}
		Face.SetFloat("_EyeNum", Mathf.Abs(blink - 1f));
		NextBlink -= Time.deltaTime;
		if (NextBlink <= 0f)
		{
			blinkNow = true;
			NextBlink = UnityEngine.Random.Range(1f, 6f);
		}
		if (blinkNow)
		{
			blink = Mathf.Min(blink + Time.deltaTime * 10f, 2f);
			if (blink == 2f)
			{
				blink = 0f;
				blinkNow = false;
			}
		}
	}
}
