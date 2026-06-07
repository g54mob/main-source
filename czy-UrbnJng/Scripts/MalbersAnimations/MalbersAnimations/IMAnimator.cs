using System;

namespace MalbersAnimations
{
	public interface IMAnimator
	{
		Action<int, bool> SetBoolParameter { get; set; }

		Action<int, float> SetFloatParameter { get; set; }

		Action<int, int> SetIntParameter { get; set; }

		Action<int> SetTriggerParameter { get; set; }

		void SetAnimParameter(int hash, int value);

		void SetAnimParameter(int hash, float value);

		void SetAnimParameter(int hash, bool value);

		void SetAnimParameter(int hash);
	}
}
