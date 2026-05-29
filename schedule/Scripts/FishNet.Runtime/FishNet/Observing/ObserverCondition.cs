using System;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Observing
{
	public abstract class ObserverCondition : ScriptableObject
	{
		[HideInInspector]
		public NetworkObject NetworkObject;

		private bool _isEnabled;

		public bool GetIsEnabled()
		{
			return false;
		}

		public void SetIsEnabled(bool value)
		{
		}

		public virtual void Initialize(NetworkObject networkObject)
		{
		}

		public virtual void Deinitialize(bool destroyed)
		{
		}

		public abstract bool ConditionMet(NetworkConnection connection, bool currentlyAdded, out bool notProcessed);

		[Obsolete("Use GetConditionType()")]
		public virtual bool Timed()
		{
			return false;
		}

		public virtual ObserverConditionType GetConditionType()
		{
			return default(ObserverConditionType);
		}

		public abstract ObserverCondition Clone();
	}
}
