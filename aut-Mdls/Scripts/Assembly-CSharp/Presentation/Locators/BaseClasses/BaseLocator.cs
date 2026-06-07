using UnityEngine;

namespace Presentation.Locators.BaseClasses
{
	public abstract class BaseLocator : ScriptableObject
	{
		public abstract void Assign(MonoBehaviour monoBehaviour);

		public abstract bool ValueIsOfCorrectType(MonoBehaviour monoBehaviour);
	}
}
