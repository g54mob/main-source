using System;
using System.Collections;
using DV.Utils;
using UnityEngine;

public class Page : MonoBehaviour
{
	private static readonly int Speed = Animator.StringToHash("speed");

	public SkinnedMeshRenderer renderer;

	public Animator animator;

	[NonSerialized]
	public float startOffset;

	[NonSerialized]
	public float endOffset;

	[NonSerialized]
	public Material pageMaterial;

	private Coroutine lerpCoro;

	private int flippingDirection;

	public float AnimationLength => animator.GetCurrentAnimatorStateInfo(0).length;

	public float AnimationNormalizedTime => animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

	public float AnimationClampedTime => Mathf.Clamp01(AnimationNormalizedTime);

	private void Start()
	{
		animator.keepAnimatorControllerStateOnDisable = true;
		animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			if (lerpCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(lerpCoro);
			}
			lerpCoro = null;
		}
	}

	public void Flip(float speedMult)
	{
		animator.enabled = true;
		animator.SetFloat(Speed, speedMult);
		if (speedMult >= 0f)
		{
			if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0f)
			{
				animator.Play("flip", 0, 0f);
			}
		}
		else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
		{
			animator.Play("flip", 0, 1f);
		}
		flippingDirection = (int)Mathf.Sign(speedMult);
		if (lerpCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(lerpCoro);
		}
		lerpCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(LerpOffsetCo());
	}

	private IEnumerator LerpOffsetCo()
	{
		while (IsFlipping())
		{
			base.transform.localPosition = GetTargetPosition();
			yield return null;
		}
		base.transform.localPosition = GetTargetPosition();
		flippingDirection = 0;
		animator.enabled = false;
		renderer.updateWhenOffscreen = false;
		lerpCoro = null;
	}

	private Vector3 GetTargetPosition()
	{
		float num = Mathf.Lerp(startOffset, endOffset, Smoothstepped(AnimationClampedTime));
		return Vector3.up * num;
	}

	private float Smoothstepped(float x)
	{
		return x * x * x * (x * (x * 6f - 15f) + 10f);
	}

	public bool IsFlipping()
	{
		float animationNormalizedTime = AnimationNormalizedTime;
		if (flippingDirection <= 0 || !(animationNormalizedTime < 1f))
		{
			if (flippingDirection < 0)
			{
				return animationNormalizedTime > 0f;
			}
			return false;
		}
		return true;
	}

	public void ForceEndAnimation()
	{
		if (flippingDirection != 0)
		{
			base.transform.localPosition = Vector3.up * ((flippingDirection > 0) ? endOffset : startOffset);
			if (lerpCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(lerpCoro);
				lerpCoro = null;
			}
			Transform parent = base.transform.parent;
			base.transform.SetParent(null);
			renderer.updateWhenOffscreen = true;
			animator.enabled = true;
			animator.SetFloat(Speed, flippingDirection);
			animator.Play("flip", 0, flippingDirection);
			animator.Update(1E-05f);
			renderer.updateWhenOffscreen = false;
			animator.enabled = false;
			flippingDirection = 0;
			base.transform.SetParent(parent);
		}
	}
}
