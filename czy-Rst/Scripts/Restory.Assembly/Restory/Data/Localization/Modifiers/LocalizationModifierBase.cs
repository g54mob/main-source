using UnityEngine;

namespace Restory.Data.Localization.Modifiers
{
	public abstract class LocalizationModifierBase : ScriptableObject
	{
		public abstract string Execute(string originalMessage);
	}
}
