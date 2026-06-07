using System;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation]
	public abstract class CustomControllerElementTargetSet
	{
		internal abstract int targetCount { get; }

		internal abstract CustomControllerElementTarget Item { get; }

		internal abstract void ClearElementCaches();
	}
}
