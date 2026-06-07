using UnityEngine;

namespace Data.Objectives.Validators
{
	public abstract class AbstractObjectiveValidator : ScriptableObject
	{
		public abstract bool IsValid();
	}
}
