using System;
using Data.Quests.QuestViews;
using UnityEngine;

namespace Data.Quests.QuestData
{
	[Serializable]
	public struct HologramPlacementData
	{
		public Vector3Int Position;

		public int Rotation;

		public bool RotationRequired;

		public OnboardingHologramView OnboardingHologramView;
	}
}
