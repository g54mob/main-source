using System.Collections;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ChangeTemperatureOverTime : NimbatusAction
	{
		public bool CustomHealthPool;

		[ShowIf("CustomHealthPool", true)]
		public HealthPool HealthPool;

		public float Delay;

		public float Rate;

		public float Target;

		public bool StopOnInfluence;

		private float _tempDelta;

		private float _tempShould;

		private bool _up;

		public override void Execute()
		{
			HealthPool = HealthPool ?? OwnWorldObject.HealthPool;
			_tempDelta = 0f;
			if (HealthPool.CurrentTemperature < Target)
			{
				_up = true;
				OwnWorldObject.StartCoroutine(ChangeTemperature());
			}
			else if (HealthPool.CurrentTemperature > Target)
			{
				_up = false;
				OwnWorldObject.StartCoroutine(ChangeTemperature());
			}
		}

		private IEnumerator ChangeTemperature()
		{
			if (Delay > 0f)
			{
				yield return new WaitForSeconds(Delay);
			}
			_tempShould = HealthPool.CurrentTemperature;
			if (_up)
			{
				while (HealthPool.CurrentTemperature < Target)
				{
					HealthPool.ChangeTemperatureBy(Mathf.Abs(_tempDelta));
					if (_checkTemp())
					{
						break;
					}
					_tempShould = HealthPool.CurrentTemperature + Mathf.Abs(Rate) * Time.fixedDeltaTime;
					_tempDelta = _tempShould - HealthPool.CurrentTemperature;
					yield return null;
				}
				yield break;
			}
			while (HealthPool.CurrentTemperature > Target)
			{
				HealthPool.ChangeTemperatureBy(0f - Mathf.Abs(_tempDelta));
				if (_checkTemp())
				{
					break;
				}
				_tempShould = HealthPool.CurrentTemperature - Mathf.Abs(Rate) * Time.fixedDeltaTime;
				_tempDelta = HealthPool.CurrentTemperature - _tempShould;
				yield return null;
			}
		}

		private bool _checkTemp()
		{
			if (!StopOnInfluence)
			{
				return false;
			}
			if (Mathf.Abs(HealthPool.CurrentTemperature - _tempShould) > 0.1f)
			{
				return true;
			}
			return false;
		}
	}
}
