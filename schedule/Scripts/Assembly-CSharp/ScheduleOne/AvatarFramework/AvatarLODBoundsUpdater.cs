using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.AvatarFramework
{
	public class AvatarLODBoundsUpdater : MonoBehaviour
	{
		public const float CHECK_RATE_SECONDS = 1f;

		public const float HIP_OFFSET_THRESHOLD = 5f;

		public Avatar Avatar;

		private List<LODGroup> lodGroups;

		private Vector3 hipOffsetOnLastRefresh;

		private void Awake()
		{
		}

		private void InfrequentUpdate()
		{
		}

		private void GetLODGroups()
		{
		}

		private void Recalculate()
		{
		}
	}
}
