using System.Collections.Generic;
using UnityEngine;

namespace Placemaker.Props
{
	public class PropAchievements : MonoBehaviour
	{
		public enum Achievement : byte
		{
			None = 0,
			Garden = 1,
			Propeller = 2,
			Lighthouse = 3,
			Spire = 4,
			GardenSculpture = 5,
			Hook = 6,
			ChurchDoor = 7,
			Count = 8
		}

		public List<int> propCounts;

		public void OnStart()
		{
		}

		public void PropEnabled(Achievement achievement)
		{
		}

		public void PropDisabled(Achievement achievement)
		{
		}

		public void TriggerAchievements()
		{
		}
	}
}
