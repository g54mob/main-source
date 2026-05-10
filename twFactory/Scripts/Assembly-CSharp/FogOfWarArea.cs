using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class FogOfWarArea : MonoBehaviour
{
	[SerializeField]
	private bool updateFogOfWarOnEnable;

	[SerializeField]
	private float fogOfWarExpandAnimationTime = 1f;

	private void OnEnable()
	{
		if (updateFogOfWarOnEnable)
		{
			StartCoroutine(DelayedOnEnable());
		}
	}

	private IEnumerator DelayedOnEnable()
	{
		yield return new WaitForEndOfFrame();
		if (fogOfWarExpandAnimationTime > 0f)
		{
			Vector3 localScale = base.transform.localScale;
			base.transform.localScale = Vector3.zero;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = base.transform.DOScale(localScale, fogOfWarExpandAnimationTime).SetEase(Ease.OutCubic);
			tweenerCore.onUpdate = (TweenCallback)Delegate.Combine(tweenerCore.onUpdate, (TweenCallback)delegate
			{
				LTFunctionLibrary.GetFogOfWarController()?.UpdateFogOfWar(importantUpdate: false);
			});
			tweenerCore.onComplete = (TweenCallback)Delegate.Combine(tweenerCore.onComplete, (TweenCallback)delegate
			{
				LTFunctionLibrary.GetFogOfWarController()?.UpdateFogOfWar();
			});
		}
		else
		{
			LTFunctionLibrary.GetFogOfWarController()?.UpdateFogOfWar();
		}
	}
}
