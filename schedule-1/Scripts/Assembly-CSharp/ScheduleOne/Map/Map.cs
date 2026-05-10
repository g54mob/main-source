using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Levelling;
using UnityEngine;

namespace ScheduleOne.Map
{
	public class Map : Singleton<Map>
	{
		public const EMapRegion FINAL_REGION = EMapRegion.Uptown;

		public bool UNLOCK_ALL_REGIONS;

		public MapRegionData[] Regions;

		[Header("References")]
		public PoliceStation PoliceStation;

		public MedicalCentre MedicalCentre;

		public Transform TreeBounds;

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void OnRankUp(FullRank old, FullRank newRank)
		{
		}

		public MapRegionData GetRegionData(EMapRegion region)
		{
			return null;
		}

		public List<EMapRegion> GetUnlockedRegions()
		{
			return null;
		}

		public EMapRegion GetRegionFromPosition(Vector3 position)
		{
			return default(EMapRegion);
		}
	}
}
