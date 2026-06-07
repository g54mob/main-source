using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class MapUnlock : CTSBehaviour
	{
		[SerializeField]
		private CareerProfileMethods _profileMethods;

		protected override void OnDisabled()
		{
			MapInfoSO.MapWinScore -= OnMapWinScore;
		}

		protected override void OnEnabled()
		{
			MapInfoSO.MapWinScore += OnMapWinScore;
		}

		private void OnMapWinScore(MapInfoSO map)
		{
			if (map.GetScoreInProfile() != 0 && !(map.MapToUnlock == null))
			{
				_profileMethods.UnlockLevel(map.MapToUnlock);
			}
		}
	}
}
