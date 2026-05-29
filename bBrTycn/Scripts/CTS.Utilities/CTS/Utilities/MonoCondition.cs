using CTS.Core;

namespace CTS.Utilities
{
	public abstract class MonoCondition : CTSBehaviour, ICondition
	{
		public abstract bool IsConditionValid();
	}
}
