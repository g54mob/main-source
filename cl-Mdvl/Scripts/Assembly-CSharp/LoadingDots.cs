using TMPro;
using UnityEngine;

public class LoadingDots : MonoBehaviour
{
	private TextMeshProUGUI dots;

	private readonly string[] dotsString = new string[4]
	{
		".",
		"..",
		"...",
		string.Empty
	};

	private int index;

	private float timer;

	private void Start()
	{
		dots = GetComponent<TextMeshProUGUI>();
	}

	private void LateUpdate()
	{
		timer += Time.unscaledDeltaTime;
		if (!(timer < 1f))
		{
			if (index >= dotsString.Length)
			{
				index = 0;
			}
			dots.SetText(dotsString[index]);
			index++;
			timer = 0f;
		}
	}
}
