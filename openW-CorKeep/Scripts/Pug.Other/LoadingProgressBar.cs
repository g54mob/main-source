using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class LoadingProgressBar : MonoBehaviour
{
	public Transform progressBarMaskPivot;

	public int quantizedSteps = 32;

	private List<SpriteRenderer> _allSprites = new List<SpriteRenderer>();

	public void Start()
	{
		GetComponentsInChildren(includeInactive: true, _allSprites);
	}

	public void OnEnable()
	{
		ResetProgress();
	}

	public void ResetProgress()
	{
		SetProgress(0f);
	}

	public void SetProgress(float progress)
	{
		progress = math.clamp(progress, 0f, 1f);
		progress = ExtensionMethods.RoundToMultiple(progress, 1f / (float)quantizedSteps);
		progressBarMaskPivot.localScale = new Vector3(1f, progress, 1f);
	}

	public void SetAlpha(float alpha)
	{
		foreach (SpriteRenderer allSprite in _allSprites)
		{
			allSprite.SetAlpha(alpha);
		}
	}
}
