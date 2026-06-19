using TMPEffects.ObjectChanged;
using UnityEngine;

namespace TMPEffects.Databases
{
	public abstract class TMPEffectDatabase<T> : ScriptableObject, ITMPEffectDatabase<T>, ITMPEffectDatabase, INotifyObjectChanged
	{
		public event ObjectChangedEventHandler ObjectChanged;

		public abstract bool ContainsEffect(string name);

		public abstract T GetEffect(string name);

		protected virtual void OnValidate()
		{
			RaiseDatabaseChanged();
		}

		protected virtual void OnDestroy()
		{
			RaiseDatabaseChanged();
		}

		protected void RaiseDatabaseChanged()
		{
			this.ObjectChanged?.Invoke(this);
		}
	}
}
