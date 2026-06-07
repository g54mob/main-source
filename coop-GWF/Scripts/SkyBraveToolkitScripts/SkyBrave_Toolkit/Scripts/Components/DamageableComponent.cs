using System;
using UnityEngine;

namespace SkyBrave_Toolkit.Scripts.Components
{
	[RequireComponent(typeof(HealthComponent))]
	public class DamageableComponent : MonoBehaviour
	{
		private HealthComponent _healthComponent;

		private void Awake()
		{
			_healthComponent = GetComponent<HealthComponent>();
		}

		public void DealDamage(float damageAmount)
		{
			_healthComponent.ChangeHealthPoints(0f - MathF.Abs(damageAmount));
		}
	}
}
