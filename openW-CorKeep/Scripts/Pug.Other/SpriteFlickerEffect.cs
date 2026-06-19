using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class SpriteFlickerEffect : MonoBehaviour, IManagedUpdate
{
	public List<SpriteRenderer> SRs;

	[Tooltip("Minimum random light intensity")]
	public float minIntensity;

	[Tooltip("Maximum random light intensity")]
	public float maxIntensity = 1f;

	[Tooltip("If 0 or less then it updates every frame")]
	public float minTimeBetweenUpdates;

	public float maxTimeBetweenUpdates;

	private float timeBetweenUpdates;

	public bool interpolate = true;

	private float timeElapsed;

	private float targetIntensity;

	private float previousIntensity;

	private Unity.Mathematics.Random rnd;

	private void Start()
	{
		rnd = PugRandom.GetRng();
		if (maxTimeBetweenUpdates > 0f)
		{
			timeBetweenUpdates = rnd.NextFloat(minTimeBetweenUpdates, maxTimeBetweenUpdates);
		}
		targetIntensity = ((SRs.Count > 0) ? SRs[0].color.a : 1f);
		previousIntensity = targetIntensity;
	}

	private void OnEnable()
	{
		Manager.update.AddToUpdate(this);
	}

	private void OnDisable()
	{
		Manager.update.RemoveFromUpdate(this);
	}

	public void ManagedUpdate()
	{
		if (timeBetweenUpdates > 0f)
		{
			timeElapsed += Time.deltaTime;
			if (timeElapsed < timeBetweenUpdates)
			{
				UpdateIntensity(timeElapsed / timeBetweenUpdates);
				return;
			}
			timeBetweenUpdates = rnd.NextFloat(minTimeBetweenUpdates, maxTimeBetweenUpdates);
			timeElapsed = 0f;
		}
		UpdateIntensity(1f);
		SetNewTargetIntensity();
	}

	private void SetNewTargetIntensity()
	{
		float num = rnd.NextFloat(minIntensity, maxIntensity);
		previousIntensity = targetIntensity;
		targetIntensity = num;
	}

	private void UpdateIntensity(float lerpValue)
	{
		foreach (SpriteRenderer sR in SRs)
		{
			sR.SetAlpha(Mathf.Lerp(previousIntensity, targetIntensity, interpolate ? lerpValue : ((float)Mathf.RoundToInt(lerpValue))));
		}
	}
}
