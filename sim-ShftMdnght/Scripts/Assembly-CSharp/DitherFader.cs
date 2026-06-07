using System.Collections;
using UnityEngine;

public class DitherFader : MonoBehaviour
{
	private Material _material;

	private static readonly int Transparency = Shader.PropertyToID("_Transparency");

	public float startFadeInSpeed = 1f;

	private void Awake()
	{
		_material = GetComponent<Renderer>().material;
		_material.SetFloat(Transparency, 0f);
	}

	private void Start()
	{
		StartCoroutine(FadeIn(startFadeInSpeed));
	}

	public IEnumerator FadeIn(float duration)
	{
		float start = _material.GetFloat(Transparency);
		float end = 1f;
		float time = 0f;
		while (time < duration)
		{
			time += Time.deltaTime;
			float t = Mathf.Clamp01(time / duration);
			_material.SetFloat(Transparency, Mathf.Lerp(start, end, t));
			yield return null;
		}
		_material.SetFloat(Transparency, end);
	}

	public IEnumerator FadeOut(float duration)
	{
		float start = _material.GetFloat(Transparency);
		float end = 0f;
		float time = 0f;
		while (time < duration)
		{
			time += Time.deltaTime;
			float t = Mathf.Clamp01(time / duration);
			_material.SetFloat(Transparency, Mathf.Lerp(start, end, t));
			yield return null;
		}
		_material.SetFloat(Transparency, end);
	}
}
