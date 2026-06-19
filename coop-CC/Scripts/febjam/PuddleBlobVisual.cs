using Aggro.Core;
using UnityEngine;

public class PuddleBlobVisual : EntityBehaviourBase
{
	public AnimationCurve animationCurve = new AnimationCurve();

	private float _lifetime;

	public float animationLengthSeconds = 1f;

	protected override void OnUpdatePresentation()
	{
		_lifetime += Time.deltaTime;
		base.transform.localScale = Vector3.one * animationCurve.Evaluate(Mathf.Clamp01(_lifetime / animationLengthSeconds));
	}
}
