using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.Health
{
	public class ChemicalManager : BaseSingleton<ChemicalManager>
	{
		private List<HealthPool> _healthPools = new List<HealthPool>();

		public void Start()
		{
			bool num = RunningModeSpecifics.Has(ERunningModeSpecific.ChemicalReactions);
			if (_healthPools == null)
			{
				_healthPools = new List<HealthPool>();
			}
			if (num)
			{
				StartCoroutine(UpdateTemperatures());
			}
		}

		public void Register(HealthPool pool)
		{
			if (!_healthPools.Contains(pool))
			{
				_healthPools.Add(pool);
			}
		}

		public void Unregister(HealthPool pool)
		{
			_healthPools.Remove(pool);
		}

		private IEnumerator UpdateTemperatures()
		{
			while (true)
			{
				float startTime = Time.time;
				int count = 0;
				foreach (HealthPool item in _healthPools.ToList())
				{
					if (item != null)
					{
						item.SpreadTemperature();
						count++;
					}
					if (count >= 100)
					{
						count = 0;
						yield return true;
					}
				}
				float time = Time.time;
				float seconds = Mathf.Abs(1f - (time - startTime));
				yield return new WaitForSeconds(seconds);
			}
		}
	}
}
