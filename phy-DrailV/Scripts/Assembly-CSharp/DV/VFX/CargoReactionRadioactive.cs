using DV.Utils;
using UnityEngine;

namespace DV.VFX
{
	public class CargoReactionRadioactive : CargoReactionBase
	{
		public const float RADIATION_AMOUNT = 36000f;

		private const float TIME_BETWEEN_RADIATION = 1f;

		private float lastTimeRadiated = -1f;

		protected override void ManageReaction()
		{
			if (cargoLeak.IsLeaking() && !(Time.time <= lastTimeRadiated + 1f))
			{
				lastTimeRadiated = Time.time;
				SingletonBehaviour<HazmatTileManager>.Instance.GetTileFromPosition(base.transform.position)?.AddRadiation(36000f);
			}
		}

		protected override void CheckTerrainForIgnition()
		{
		}

		protected override void PostExplosionBehavior()
		{
		}
	}
}
