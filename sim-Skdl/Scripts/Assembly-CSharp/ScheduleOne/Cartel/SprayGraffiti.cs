using ScheduleOne.Graffiti;
using ScheduleOne.Map;
using UnityEngine;

namespace ScheduleOne.Cartel
{
	public class SprayGraffiti : CartelActivity
	{
		[SerializeField]
		[Header("Settings")]
		private float _minimumDistanceFromPlayers;

		private WorldSpraySurface _validSpraySurface;

		public override bool IsRegionValidForActivity(EMapRegion region)
		{
			return false;
		}

		public void SetSpraySurface(EMapRegion region, bool overrideExisting = true)
		{
		}

		public override void Activate(EMapRegion region)
		{
		}
	}
}
