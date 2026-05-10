using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Observing;
using UnityEngine;

namespace FishNet.Component.Observing
{
	[CreateAssetMenu(menuName = "FishNet/Observers/Grid Condition", fileName = "New Grid Condition")]
	public class GridCondition : ObserverCondition
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
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
