using System;

namespace MalbersAnimations
{
	[Serializable]
	public class IDEnable<T> where T : IDs
	{
		public T ID;

		public bool enable = true;
	}
}
