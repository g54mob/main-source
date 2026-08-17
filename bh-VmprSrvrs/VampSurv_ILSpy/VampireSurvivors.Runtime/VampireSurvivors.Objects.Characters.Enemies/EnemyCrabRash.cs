using System;
using UnityEngine;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyCrabRash : EnemyCrab
{
	public override void Despawn()
	{
		if (_leftEvent != null)
		{
			_leftEvent.Cancel();
		}
		if (_rightEvent != null)
		{
			_rightEvent.Cancel();
		}
		EnemyPincer leftPincer = _leftPincer;
		if ((object)_leftPincer != null && ((UnityEngine.Object)leftPincer).m_CachedPtr != (IntPtr)0)
		{
			_leftPincer.Disappear();
		}
		EnemyPincer rightPincer = _rightPincer;
		if ((object)_rightPincer != null && ((UnityEngine.Object)rightPincer).m_CachedPtr != (IntPtr)0)
		{
			_rightPincer.Disappear();
		}
		base.Despawn();
	}

	protected override void SummonDrowner()
	{
	}

	public EnemyCrabRash()
	{
		//IL_0026: Expected O, but got I8
		//IL_0037: Expected O, but got I4
		base._freshlySpawned = true;
		base._leftOffset = (Vector2)3196730737L;
		_ = 1049582633;
		base._rightOffset = (Vector2)1049247089;
		_ = 1049582633;
		((EnemyController)this)._002Ector();
	}
}
