using System.Collections;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class SituationalBarkManager : MonoSingleton<SituationalBarkManager>
	{
		[SerializeField]
		private float _globalCooldown = 8f;

		private bool _isGlobalCooldownActive;

		public bool IsCDActive()
		{
			return _isGlobalCooldownActive;
		}

		protected override void SingletonAwake()
		{
			SituationnalBarks.ActiveCD += StartGlobalCooldown;
		}

		protected override void OnSingletonDestroy()
		{
			SituationnalBarks.ActiveCD -= StartGlobalCooldown;
		}

		public void StartGlobalCooldown()
		{
			if (!_isGlobalCooldownActive)
			{
				_isGlobalCooldownActive = true;
				StartCoroutine(CooldownRoutine());
			}
		}

		private IEnumerator CooldownRoutine()
		{
			yield return new WaitForSeconds(_globalCooldown);
			_isGlobalCooldownActive = false;
		}
	}
}
