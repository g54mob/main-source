using System;

namespace MalbersAnimations
{
	[Flags]
	public enum UpdateMode
	{
		Update = 1,
		FixedUpdate = 2,
		LateUpdate = 4
	}
}
