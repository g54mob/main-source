using System.Collections;
using TMPro;
using UnityEngine;

public class ConstructionPriceIndicator : MonoBehaviour
{
	public TextMeshPro textRef;

	public Color positiveCashColor;

	public Color negativeCashColor;

	public void SetPriceText(int price)
	{
		if (price >= 0)
		{
			FormatPositiveCashText(price);
		}
		else
		{
			FormatNegativeCashText(price);
		}
		StartCoroutine(PriceRoutine());
	}

	private void FormatPositiveCashText(int price)
	{
		textRef.color = positiveCashColor;
		textRef.text = "+$" + price;
	}

	private void FormatNegativeCashText(int price)
	{
		textRef.color = negativeCashColor;
		textRef.text = "-$" + Mathf.Abs(price);
	}

	private IEnumerator PriceRoutine()
	{
		float inTime = 0.1f;
		float outTime = 0.5f;
		float holdTime = 0.5f;
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		float timer;
		for (timer = 0f; timer < inTime; timer += Time.deltaTime)
		{
			textRef.color = new Color(textRef.color.r, textRef.color.g, textRef.color.b, timer / inTime);
			yield return frameWait;
		}
		textRef.color = new Color(textRef.color.r, textRef.color.g, textRef.color.b, 1f);
		float riseSpeed = 5f;
		timer = 0f;
		while (timer < holdTime)
		{
			yield return frameWait;
			timer += Time.deltaTime;
			base.transform.position += new Vector3(0f, riseSpeed * Time.deltaTime, 0f);
		}
		timer = 0f;
		while (timer < outTime)
		{
			textRef.color = new Color(textRef.color.r, textRef.color.g, textRef.color.b, 1f - timer / outTime);
			yield return frameWait;
			timer += Time.deltaTime;
			base.transform.position += new Vector3(0f, riseSpeed * Time.deltaTime, 0f);
		}
		Object.Destroy(base.gameObject);
	}
}
