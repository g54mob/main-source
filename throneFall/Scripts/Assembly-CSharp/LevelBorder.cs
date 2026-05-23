using System.Collections;
using Shapes;
using UnityEngine;

public class LevelBorder : MonoBehaviour
{
	public float fadeInDistance;

	public BoxCollider boxCol;

	public Line line;

	public BoxCollider[] boxColArray;

	public Line[] lineArray;

	private readonly float tickTime = 0.5f;

	private readonly float fadeTime = 0.75f;

	private float timer;

	private bool fadedIn;

	private Transform target;

	private Color defaultColor;

	private Color fadeOutColor;

	public bool arrayMode;

	private Coroutine currentFade;

	private bool notInArrayMode => !arrayMode;

	private void Start()
	{
		target = TagManager.instance.Players[0].transform;
		defaultColor = line.Color;
		fadeOutColor = defaultColor;
		fadeOutColor.a = 0f;
		if (!arrayMode)
		{
			line.Color = fadeOutColor;
			return;
		}
		Line[] array = lineArray;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Color = fadeOutColor;
		}
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (!(timer >= tickTime))
		{
			return;
		}
		timer = 0f;
		if (!arrayMode)
		{
			float num = Vector3.Distance(target.position, boxCol.ClosestPoint(target.position));
			if (fadedIn && num > fadeInDistance)
			{
				if (currentFade == null)
				{
					currentFade = StartCoroutine(FadeOut());
				}
				fadedIn = false;
			}
			else if (!fadedIn && num <= fadeInDistance)
			{
				if (currentFade == null)
				{
					currentFade = StartCoroutine(FadeIn());
				}
				fadedIn = true;
			}
			return;
		}
		float num2 = float.PositiveInfinity;
		BoxCollider[] array = boxColArray;
		foreach (BoxCollider boxCollider in array)
		{
			float num3 = Vector3.Distance(target.position, boxCollider.ClosestPoint(target.position));
			if (num3 < num2)
			{
				num2 = num3;
			}
		}
		if (fadedIn && num2 > fadeInDistance)
		{
			if (currentFade == null)
			{
				currentFade = StartCoroutine(FadeOut());
			}
			fadedIn = false;
		}
		else if (!fadedIn && num2 <= fadeInDistance)
		{
			if (currentFade == null)
			{
				currentFade = StartCoroutine(FadeIn());
			}
			fadedIn = true;
		}
	}

	private IEnumerator FadeIn()
	{
		float timer = 0f;
		while (timer <= fadeTime)
		{
			timer += Time.deltaTime;
			if (!arrayMode)
			{
				line.Color = Color.Lerp(fadeOutColor, defaultColor, timer / fadeTime);
			}
			else
			{
				Color color = Color.Lerp(fadeOutColor, defaultColor, timer / fadeTime);
				Line[] array = lineArray;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Color = color;
				}
			}
			yield return null;
		}
		if (!arrayMode)
		{
			line.Color = defaultColor;
		}
		else
		{
			Line[] array = lineArray;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Color = defaultColor;
			}
		}
		currentFade = null;
		if (!fadedIn)
		{
			currentFade = StartCoroutine(FadeOut());
		}
	}

	private IEnumerator FadeOut()
	{
		float timer = 0f;
		while (timer <= fadeTime)
		{
			timer += Time.deltaTime;
			if (!arrayMode)
			{
				line.Color = Color.Lerp(defaultColor, fadeOutColor, timer / fadeTime);
			}
			else
			{
				Color color = Color.Lerp(defaultColor, fadeOutColor, timer / fadeTime);
				Line[] array = lineArray;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Color = color;
				}
			}
			yield return null;
		}
		if (!arrayMode)
		{
			line.Color = fadeOutColor;
		}
		else
		{
			Line[] array = lineArray;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Color = fadeOutColor;
			}
		}
		currentFade = null;
		if (fadedIn)
		{
			currentFade = StartCoroutine(FadeIn());
		}
	}
}
