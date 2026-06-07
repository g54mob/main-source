using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public float intensity;

	public bool usesDuration;

	public float duration;

	public Vector3 originalPos;

	private bool justFinishedIntensity;

	private void OnEnable()
	{
		originalPos = base.transform.localPosition;
	}

	private void FixedUpdate()
	{
		if (PlayerPrefs.GetInt("CamShake", 1) != 0)
		{
			if (intensity >= 0f)
			{
				base.transform.localPosition = originalPos + Random.insideUnitSphere * intensity;
				intensity -= Time.deltaTime;
				justFinishedIntensity = true;
			}
			else if (justFinishedIntensity)
			{
				justFinishedIntensity = false;
				StartCoroutine(LerpToNormal());
			}
		}
	}

	private IEnumerator LerpToNormal()
	{
		while (true)
		{
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, originalPos, Time.deltaTime);
			if (Vector3.Distance(base.transform.localPosition, originalPos) < 0.01f)
			{
				break;
			}
			yield return null;
		}
	}
}
