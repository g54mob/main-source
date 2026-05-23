using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFlasherFX : MonoBehaviour
{
	public class RendererMaterialPair
	{
		public Renderer renderer;

		public Material originalMaterial;

		public RendererMaterialPair(Renderer targetRenderer)
		{
			renderer = targetRenderer;
			originalMaterial = renderer.sharedMaterial;
		}
	}

	public List<Renderer> targetRenderers;

	public Material flashMaterial;

	public Material specialFlashMaterial;

	public Material unitSelectedMaterial;

	private bool unitSelected;

	private List<RendererMaterialPair> targetRendererMaterialPairs = new List<RendererMaterialPair>();

	public void SetSelected(bool _selected)
	{
		unitSelected = _selected;
		foreach (RendererMaterialPair targetRendererMaterialPair in targetRendererMaterialPairs)
		{
			targetRendererMaterialPair.renderer.sharedMaterial = (unitSelected ? unitSelectedMaterial : targetRendererMaterialPair.originalMaterial);
		}
	}

	private void Start()
	{
		foreach (Renderer targetRenderer in targetRenderers)
		{
			if (!(targetRenderer == null))
			{
				targetRendererMaterialPairs.Add(new RendererMaterialPair(targetRenderer));
			}
		}
	}

	private IEnumerator FlashAnimation(float flashTime, Material mat)
	{
		foreach (RendererMaterialPair targetRendererMaterialPair in targetRendererMaterialPairs)
		{
			targetRendererMaterialPair.renderer.sharedMaterial = mat;
		}
		yield return new WaitForSeconds(flashTime);
		foreach (RendererMaterialPair targetRendererMaterialPair2 in targetRendererMaterialPairs)
		{
			targetRendererMaterialPair2.renderer.sharedMaterial = (unitSelected ? unitSelectedMaterial : targetRendererMaterialPair2.originalMaterial);
		}
	}

	public void TriggerFlash(bool special, float flashTime = 0.25f)
	{
		StopAllCoroutines();
		if (special)
		{
			StartCoroutine(FlashAnimation(flashTime, specialFlashMaterial));
		}
		else
		{
			StartCoroutine(FlashAnimation(flashTime, flashMaterial));
		}
	}
}
