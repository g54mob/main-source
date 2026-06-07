using Assets.Scripts.Flight.WorldObjects.Combat;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land
{
	public class ApcGroundVehicleScript : SimpleGroundVehicleScript
	{
		[SerializeField]
		private ApcTurretScript _turret;

		public override bool IsHostile
		{
			get
			{
				if (!base.IsHostile)
				{
					if (!(_turret == null))
					{
						return _turret.IsHostile;
					}
					return false;
				}
				return true;
			}
			set
			{
				base.IsHostile = value;
				if (_turret != null)
				{
					_turret.IsHostile = value;
				}
			}
		}

		protected override void Die()
		{
			base.Die();
			if (_turret != null)
			{
				_turret.Die();
			}
		}
	}
}
