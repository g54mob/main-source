using UnityEngine;

public class FadeoutLight : PoolableSimple
{
	public Light fadeoutLight;

	public float fadeOutTime = 0.15f;

	public bool interpolate = true;

	public Transform followTransform;

	private float timeElapsed;

	private float startIntensity;

	public override void OnOccupied()
	{
		base.OnOccupied();
		startIntensity = fadeoutLight.intensity;
		timeElapsed = 0f;
	}

	private void LateUpdate()
	{
		if (fadeoutLight == null)
		{
			return;
		}
		timeElapsed += Time.deltaTime;
		if (timeElapsed < fadeOutTime)
		{
			UpdateLightIntensity(timeElapsed / fadeOutTime);
			if (followTransform != null)
			{
				base.transform.position = followTransform.position;
			}
		}
		else
		{
			timeElapsed = 0f;
			UpdateLightIntensity(1f);
			Free();
		}
	}

	private void UpdateLightIntensity(float lerpValue)
	{
		fadeoutLight.intensity = Mathf.Lerp(startIntensity, 0f, interpolate ? lerpValue : ((float)Mathf.RoundToInt(lerpValue)));
	}
}
