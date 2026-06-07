using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks
{
	[Serializable]
	public class DronePerkManagerData
	{
		public string ActivePerkId { get; set; }

		public List<DroneEffect> ActiveEffects { get; set; }
	}
}
