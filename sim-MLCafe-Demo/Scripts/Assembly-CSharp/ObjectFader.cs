using UnityEngine;

public class ObjectFader : MonoBehaviour
{
	public float fadeSpeed = 1.5f;

	public float fadeAmount = 0.5f;

	public bool doFade;

	public MeshRenderer meshRenderer;

	private Material[] materials;

	private void Start()
	{
		materials = meshRenderer.materials;
	}

	private void Update()
	{
		if (doFade)
		{
			FadeNow();
		}
		else
		{
			ResetFade();
		}
	}

	private void FadeNow()
	{
		Material[] array = materials;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetFloat("_Fade", Mathf.Lerp(1f, fadeAmount, fadeSpeed * Time.deltaTime));
		}
	}

	private void ResetFade()
	{
		Material[] array = materials;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetFloat("_Fade", Mathf.Lerp(fadeAmount, 1f, fadeSpeed * Time.deltaTime));
		}
	}
}
