using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.Cargo
{
	public class CargoReactionToDamageChecker : SingletonBehaviour<CargoReactionToDamageChecker>
	{
		private const float SQR_IDLE_PROCESSING_RANGE = 40000f;

		private List<CargoReactionToDamage> processingList = new List<CargoReactionToDamage>();

		private int roundRobinIndex;

		public new static string AllowAutoCreate()
		{
			return "[CargoReactionToDamageChecker]";
		}

		public void Register(CargoReactionToDamage crtd)
		{
			processingList.Add(crtd);
		}

		public void Unregister(CargoReactionToDamage crtd)
		{
			processingList.Remove(crtd);
		}

		private void Update()
		{
			int count = processingList.Count;
			if (count == 0)
			{
				return;
			}
			Camera activeCamera = PlayerManager.ActiveCamera;
			if (!(activeCamera == null))
			{
				roundRobinIndex = (roundRobinIndex + 1) % count;
				CargoReactionToDamage cargoReactionToDamage = processingList[roundRobinIndex];
				if (cargoReactionToDamage == null)
				{
					Debug.LogWarning("Null found, skipping entry for CargoReactionToDamage");
					processingList.RemoveAt(roundRobinIndex);
				}
				else if (Vector3.SqrMagnitude(activeCamera.transform.position - cargoReactionToDamage.transform.position) < 40000f)
				{
					cargoReactionToDamage.TickIdleAudio();
				}
				else
				{
					cargoReactionToDamage.SetPlayerNotNear();
				}
			}
		}
	}
}
