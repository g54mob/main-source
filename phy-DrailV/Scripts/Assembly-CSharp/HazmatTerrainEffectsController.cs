using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HazmatTerrainEffectsController : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem[] particles;

	[SerializeField]
	private float removalDelay = 13f;

	[SerializeField]
	private PostProcessVolume volume;

	private float elapsedRemovalTime;

	private bool exists = true;

	private bool isRemovingEffects;

	private Coroutine fadePPCoro;

	private void Awake()
	{
		if ((particles == null || particles.Length == 0) && volume == null)
		{
			Debug.LogError("Invalid terrain effects for " + base.gameObject.name + ". Destroying self.");
			exists = false;
			Object.Destroy(base.gameObject);
		}
		else
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!isRemovingEffects)
		{
			base.enabled = false;
			return;
		}
		elapsedRemovalTime += Time.deltaTime;
		if (elapsedRemovalTime >= removalDelay)
		{
			exists = false;
			Object.Destroy(base.gameObject);
		}
	}

	public void RemoveEffects()
	{
		if (isRemovingEffects)
		{
			return;
		}
		base.enabled = (isRemovingEffects = true);
		if (particles != null)
		{
			ParticleSystem[] array = particles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Stop();
			}
		}
		if ((bool)volume)
		{
			if (fadePPCoro != null)
			{
				StopCoroutine(fadePPCoro);
			}
			fadePPCoro = StartCoroutine(FadePostProcessing());
		}
	}

	private IEnumerator FadePostProcessing()
	{
		float initialWeight = volume.weight;
		while (elapsedRemovalTime < removalDelay)
		{
			volume.weight = initialWeight * (1f - elapsedRemovalTime / removalDelay);
			yield return null;
		}
		fadePPCoro = null;
	}

	public bool RestartEffects()
	{
		if (!exists)
		{
			return false;
		}
		if (!isRemovingEffects)
		{
			return true;
		}
		base.enabled = (isRemovingEffects = false);
		elapsedRemovalTime = 0f;
		if (particles != null)
		{
			ParticleSystem[] array = particles;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Play();
			}
		}
		if ((bool)volume)
		{
			if (fadePPCoro != null)
			{
				StopCoroutine(fadePPCoro);
			}
			volume.weight = 1f;
			volume.enabled = true;
		}
		return true;
	}
}
