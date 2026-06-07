using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(MetaFade(0.005f));
	}

	private void Update()
	{
	}

	private IEnumerator MetaFade(float waitTime)
	{
		Image image = GetComponent<Image>();
		if (image.color.a == 1f)
		{
			yield return new WaitForSeconds(waitTime);
		}
		if (image.color.a < 0f)
		{
			yield return null;
		}
		else
		{
			StartCoroutine(Fade(waitTime));
		}
		yield return null;
	}

	private IEnumerator Fade(float waitTime)
	{
		Image component = GetComponent<Image>();
		float a = component.color.a;
		component.color = new Color(0f, 0f, 0f, a - 0.01f);
		yield return new WaitForSeconds(waitTime);
		StartCoroutine(MetaFade(waitTime));
	}
}
