using System.Runtime.CompilerServices;
using TMPEffects.ObjectChanged;
using UnityEngine;

namespace TMPEffects.Databases
{
	public abstract class TMPEffectDatabase<T> : ScriptableObject, ITMPEffectDatabase<T>, ITMPEffectDatabase, INotifyObjectChanged
	{
		public event ObjectChangedEventHandler ObjectChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public abstract bool ContainsEffect(string name);

		public abstract T GetEffect(string name);

		protected virtual void OnValidate()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected void RaiseDatabaseChanged()
		{
		}
	}
}
