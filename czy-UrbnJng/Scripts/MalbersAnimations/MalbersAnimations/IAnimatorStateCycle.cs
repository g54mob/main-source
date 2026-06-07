using System;

namespace MalbersAnimations
{
	public interface IAnimatorStateCycle
	{
		Action<int> StateCycle { get; set; }
	}
}
