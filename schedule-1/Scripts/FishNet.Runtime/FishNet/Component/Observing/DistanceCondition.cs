using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Observing;
using UnityEngine;

namespace FishNet.Component.Observing
{
	[CreateAssetMenu(menuName = "FishNet/Observers/Distance Condition", fileName = "New Distance Condition")]
	public class DistanceCondition : ObserverCondition
	{
		[Tooltip("Maximum distance a client must be within this object to see it.")]
		[SerializeField]
		private float _maximumDistance;

		[Tooltip("Additional percent of distance client must be until this object is hidden. For example, if distance was 100f and percent was 0.5f the client must be 150f units away before this object is hidden again. This can be useful for keeping objects from regularly appearing and disappearing.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float _hideDistancePercent;

		[Obsolete("UpdateFrequency is no longer used.")]
		[HideInInspector]
		public float UpdateFrequency;

		private Dictionary<NetworkConnection, float> _timedUpdates;

		public float MaximumDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public void ConditionConstructor(float maximumDistance)
		{
		}

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
