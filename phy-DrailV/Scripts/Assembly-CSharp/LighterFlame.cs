using System.Collections;
using UnityEngine;

public class LighterFlame : ItemFlameBase
{
	private const float IGNITION_DELAY = 0.2f;

	protected override IEnumerator FlameExtinguishCoroutine()
	{
		yield return WaitFor.Seconds(extinguishTime);
		flameLight.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
		FireEvent(ignited: false);
		extinguishCoroutine = null;
	}

	protected override IEnumerator FlameIgniteCoroutine(float intensity)
	{
		base.IsIgniting = true;
		base.transform.localScale = Vector3.zero;
		yield return WaitFor.Seconds(0.2f);
		float elapsedIgnitionTime = 0f;
		flameLight.intensity = 0f;
		flameLight.range = 0f;
		flameLight.gameObject.SetActive(value: true);
		flameCurrentScale = Vector3.zero;
		flameRequestedScale = flameMaxScale;
		lightRange = lightRangeMax;
		lightIntensity = intensity;
		currentFlameIntensity = (requestedFlameIntensity = intensity);
		while (elapsedIgnitionTime < ignitionTime)
		{
			elapsedIgnitionTime += Time.deltaTime;
			float num = Mathf.Clamp01(elapsedIgnitionTime / ignitionTime);
			flameCurrentScale = flameRequestedScale * num;
			base.transform.localScale = flameCurrentScale;
			flameLight.intensity = lightIntensity * num;
			flameLight.range = lightRange * num;
			yield return null;
		}
		flameCurrentScale = flameRequestedScale;
		base.transform.localScale = flameCurrentScale;
		flameLight.intensity = lightIntensity;
		flameLight.range = lightRange;
		base.IsIgniting = false;
		FireEvent(ignited: true);
		ignitionCoroutine = null;
	}
}
