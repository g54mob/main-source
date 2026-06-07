using Data.Variables;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	public abstract class AbstractTechTreeNodeBehaviour : ScriptableObject
	{
		public abstract void Unlock();

		public abstract void RefunableReUnlock();

		public abstract bool TryGetRefunableVariable(out VariableSO variable);
	}
}
