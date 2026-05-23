using UnityEngine;

namespace Data.Objectives.Events
{
	public abstract class AbstractObjectiveEvent : ScriptableObject
	{
		public abstract void Execute();
	}
}
