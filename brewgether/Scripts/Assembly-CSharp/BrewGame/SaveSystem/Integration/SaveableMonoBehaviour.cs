using System.Collections.Generic;
using UnityEngine;

namespace BrewGame.SaveSystem.Integration
{
	public abstract class SaveableMonoBehaviour : MonoBehaviour, ISaveable
	{
		public abstract string SaveableId { get; }

		public virtual int SavePriority => 0;

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		public abstract Dictionary<string, object> CaptureState();

		public abstract void RestoreState(Dictionary<string, object> state);
	}
}
