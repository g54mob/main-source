using System.Collections;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{
	private SpriteRenderer rend;

	private void Start()
	{
		rend = GetComponent<SpriteRenderer>();
		Color color = rend.material.color;
		color.a = 0f;
		rend.material.color = color;
	}

	private IEnumerator FadeIn()
	{
		for (float f = 0.05f; f <= 1f; f += 0.05f)
		{
			Color color = rend.material.color;
			color.a = f;
			rend.material.color = color;
			yield return new WaitForSeconds(0.05f);
		}
	}

	private IEnumerator FadeOut()
	{
		float f = 1f;
		while ((double)f >= 0.05)
		{
			Color color = rend.material.color;
			color.a = f;
			rend.material.color = color;
			yield return new WaitForSeconds(0.05f);
			f -= 0.05f;
		}
	}

	private void OnEnable()
	{
		StartCoroutine("FadeIn");
	}

	private void OnDisable()
	{
		StartCoroutine("FadeOut");
	}
}
