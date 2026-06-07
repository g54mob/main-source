using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class IsOutsideRadius : NimbatusCondition
	{
		public float RadiusMultiplicator = 2f;

		private bool _isPlanet;

		protected override void OnInit()
		{
			base.OnInit();
			_isPlanet = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone != null;
		}

		public override bool IsTrue()
		{
			float num = ((!_isPlanet) ? 1 : SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.SelectedSettings.PlanetSize);
			num *= RadiusMultiplicator;
			Vector3 position = OwnWorldObject.transform.position;
			return Vector3.Distance(Vector3.zero, position) >= num;
		}
	}
}
