using System.Collections;
using UnityEngine;

public class LightningLightAnimator : MonoBehaviour
{
	public Light _lhtLightingLight;

	public float _fMaxFlashLight;

	public float _fMinFlashLight;

	public float _fNonFlashLight;

	public int _iMaxFlashes;

	public int _iMinFlashes;

	public float _fMinTimeBetweenLighting;

	public float _fMaxTimeBetweenLightning;

	public float _fMinTimeBetweenLightningFlashes;

	public float _fMaxTimeBetweenLightningFlashes;

	public float _fMinFlashLength;

	public float _fMaxFlashLength;

	public float _fFlashLerpTime;

	public IEnumerator Flash()
	{
		float flashLength = Random.Range(_fMinFlashLength, _fMaxFlashLength);
		float fFlashBrightness = Random.Range(_fMinFlashLight, _fMaxFlashLight);
		float flerpTimeLeft = _fFlashLerpTime;
		while (flerpTimeLeft > 0f)
		{
			flerpTimeLeft -= Time.deltaTime;
			_lhtLightingLight.intensity = Mathf.Lerp(fFlashBrightness, _fNonFlashLight, Mathf.Clamp01(flerpTimeLeft / _fFlashLerpTime));
			yield return null;
		}
		yield return new WaitForSeconds(flashLength);
		flerpTimeLeft = _fFlashLerpTime;
		while (flerpTimeLeft > 0f)
		{
			flerpTimeLeft -= Time.deltaTime;
			_lhtLightingLight.intensity = Mathf.Lerp(_fNonFlashLight, fFlashBrightness, Mathf.Clamp01(flerpTimeLeft / _fFlashLerpTime));
			yield return null;
		}
	}

	public IEnumerator FlashSequence()
	{
		int iFlashesInSequence = Random.Range(_iMinFlashes, _iMaxFlashes);
		for (int i = 0; i < iFlashesInSequence; i++)
		{
			yield return StartCoroutine(Flash());
			yield return new WaitForSeconds(Random.Range(_fMinTimeBetweenLightningFlashes, _fMaxTimeBetweenLightningFlashes));
		}
	}

	public IEnumerator LightningManager()
	{
		while (Application.isPlaying)
		{
			yield return new WaitForSeconds(Random.Range(_fMinTimeBetweenLighting, _fMaxTimeBetweenLightning));
			yield return StartCoroutine(FlashSequence());
		}
	}

	private void Start()
	{
		StartCoroutine(LightningManager());
	}
}
