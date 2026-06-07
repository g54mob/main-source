using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.CombatArena
{
	public class CombatHealthBar : MonoBehaviour
	{
		public UITexture HealthBar;

		private HealthPool _healthPool;

		private bool _initialized;

		public void Init(NimbatusDrone drone)
		{
			_healthPool = drone.RootDronePart.HealthPool;
			_initialized = true;
		}

		public void Update()
		{
			if (_initialized)
			{
				float fillAmount = _healthPool.CurrentHealth / _healthPool.ActiveMaxHealth;
				HealthBar.fillAmount = fillAmount;
			}
		}
	}
}
