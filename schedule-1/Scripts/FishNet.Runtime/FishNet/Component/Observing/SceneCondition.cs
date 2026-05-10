using FishNet.Connection;
using FishNet.Observing;
using UnityEngine;

namespace FishNet.Component.Observing
{
	[CreateAssetMenu(menuName = "FishNet/Observers/Scene Condition", fileName = "New Scene Condition")]
	public class SceneCondition : ObserverCondition
	{
		public void ConditionConstructor()
		{
		}

		public override bool ConditionMet(NetworkConnection connection, bool currentlyAdded, out bool notProcessed)
		{
			notProcessed = default(bool);
			return false;
		}

		public override ObserverConditionType GetConditionType()
		{
			return default(ObserverConditionType);
		}

		public override ObserverCondition Clone()
		{
			return null;
		}
	}
}
