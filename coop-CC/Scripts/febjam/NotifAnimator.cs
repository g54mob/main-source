using System.Collections;
using Aggro.Core;
using FMODUnity;
using UnityEngine;

public class NotifAnimator : EntityBehaviourBase
{
	public float lifeTimeSeconds = 2.5f;

	public float easeInTimeSeconds = 1f;

	public float easeOutTimeSeconds = 1f;

	public EasingFunction.Ease easeIn = EasingFunction.Ease.Linear;

	public EasingFunction.Ease easeOut = EasingFunction.Ease.Linear;

	private float _timeAlive;

	public float delay;

	public bool animate = true;

	public EventReference sfx;

	protected override void OnEntityCreated()
	{
		_timeAlive = 0f;
		if (animate)
		{
			base.transform.localScale = Vector3.zero;
		}
		StartCoroutine(AnimateCo());
	}

	private IEnumerator AnimateCo()
	{
		yield return new WaitForSeconds(delay);
		if (!sfx.IsNull)
		{
			AudioManager.PlaySfx(sfx);
		}
		while (_timeAlive < lifeTimeSeconds && animate)
		{
			_timeAlive += Time.deltaTime;
			float num = 1f;
			if (_timeAlive < easeInTimeSeconds)
			{
				float value = _timeAlive / easeInTimeSeconds;
				num = EasingFunction.Evaluate(easeIn, value);
			}
			if (_timeAlive > lifeTimeSeconds - easeOutTimeSeconds)
			{
				float value = 1f - (_timeAlive - (lifeTimeSeconds - easeOutTimeSeconds)) / easeOutTimeSeconds;
				num = EasingFunction.Evaluate(easeOut, value);
			}
			base.transform.localScale = Vector3.one * num;
			yield return null;
		}
		base.entity.GetStruct<PoolableEntityReference>().Release();
	}
}
