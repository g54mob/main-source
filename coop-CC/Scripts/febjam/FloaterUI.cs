using System.Collections.Generic;
using Aggro.Core;
using UnityEngine;

public class FloaterUI : EntityBehaviourBase
{
	public Vector3 targetWorldPosition = Vector3.zero;

	public bool onScreen;

	public Transform arrow;

	public Vector3 offset = Vector3.zero;

	public EasingFunction.Ease orderEase = EasingFunction.Ease.EaseOutBack;

	public float floaterScaleSpeed = 1f;

	private float _floaterScale;

	private float _orderScale;

	private float _extrasScale;

	public bool visible;

	public bool hideByDefault;

	public List<Transform> visibleOnScreenTransforms = new List<Transform>();

	public List<Transform> visibleOffScreenTransforms = new List<Transform>();

	public List<Transform> extraTransforms = new List<Transform>();

	private bool _destroyOnceHidden;

	public bool useLifeTime;

	public float lifeTimeSeconds = 4f;

	private float _lifeTime;

	public float scaleMultiplier = 1f;

	public bool extrasVisible;

	public bool alwaysVisible;

	protected override void OnEntityCreated()
	{
		visible = !hideByDefault;
	}

	public void SetVisibleThisFrame()
	{
		visible = true;
	}

	public void HideAndRemove()
	{
		_destroyOnceHidden = true;
	}

	protected override void OnUpdatePresentation()
	{
		if (alwaysVisible)
		{
			visible = true;
		}
	}

	protected override void OnUpdatePresentationLate()
	{
		_lifeTime += Time.deltaTime;
		if (_lifeTime >= lifeTimeSeconds && useLifeTime)
		{
			HideAndRemove();
		}
		if (_destroyOnceHidden)
		{
			visible = false;
		}
		float num = (visible ? 1f : (-1f));
		_floaterScale += num * floaterScaleSpeed * Time.deltaTime;
		if (_destroyOnceHidden && _floaterScale <= 0f)
		{
			AggroManagerBase<FloaterManagerUI>.instance.RemoveFloater(this);
		}
		_floaterScale = Mathf.Clamp01(_floaterScale);
		float num2 = EasingFunction.Evaluate(orderEase, _floaterScale);
		num2 *= scaleMultiplier;
		base.transform.localScale = Vector3.one * num2;
		float num3 = (onScreen ? 1f : (-1f));
		_orderScale += num3 * floaterScaleSpeed * Time.deltaTime;
		_orderScale = Mathf.Clamp(_orderScale, 0f, 1f);
		float num4 = EasingFunction.Evaluate(orderEase, _orderScale);
		float num5 = EasingFunction.Evaluate(orderEase, 1f - _orderScale);
		foreach (Transform visibleOnScreenTransform in visibleOnScreenTransforms)
		{
			visibleOnScreenTransform.localScale = Vector3.one * num4;
		}
		foreach (Transform visibleOffScreenTransform in visibleOffScreenTransforms)
		{
			visibleOffScreenTransform.localScale = Vector3.one * num5;
		}
		num3 = (extrasVisible ? 1f : (-1f));
		_extrasScale += num3 * floaterScaleSpeed * Time.deltaTime;
		_extrasScale = Mathf.Clamp(_extrasScale, 0f, 1f);
		num4 = EasingFunction.Evaluate(orderEase, _extrasScale);
		foreach (Transform extraTransform in extraTransforms)
		{
			extraTransform.localScale = Vector3.one * num4;
		}
		if (hideByDefault)
		{
			visible = false;
		}
	}
}
