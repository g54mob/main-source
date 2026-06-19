using System;
using System.Collections.Generic;
using UnityEngine;

public class SequenceExplosiveAuthoring : MonoBehaviour
{
	[Serializable]
	public struct SequenceCharge
	{
		public ObjectID explosionID;

		public int variation;

		public float delayFromPrevious;

		public float spreadFromPreviousDistance;

		public float offsetDegrees;

		public int amountToSpawn;

		public SequenceExplosionChargeDirectionType directionType;
	}

	public float initialDelay;

	public float animationInitialDelay;

	public bool triggerOnDeath;

	public bool useDirection;

	public ConditionID consumesConditionForMaxExplosions;

	public bool useFirstItemSettingForAllCharges;

	public List<SequenceCharge> chargeSettings;
}
