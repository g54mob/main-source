using System;

namespace TMPEffects.Components.Animator
{
	[Serializable]
	public enum UpdateFrom
	{
		Update = 0,
		LateUpdate = 5,
		FixedUpdate = 10,
		Script = 15
	}
}
