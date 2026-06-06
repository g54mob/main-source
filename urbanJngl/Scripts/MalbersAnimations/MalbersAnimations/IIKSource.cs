using UnityEngine;

namespace MalbersAnimations
{
	public interface IIKSource
	{
		Transform Owner { get; }

		void Set_Enable(string set);

		void Set_Enable(string set, bool value);

		void Set_Weight(string set, bool value);

		void Set_Disable(string set);

		void Target_Set(string set, Transform[] targets);

		void Target_Clear(string set);

		void Target_Set(string set, Transform newTarget, int index);

		void Target_Clear(string set, int index);
	}
}
