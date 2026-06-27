using UnityEngine;

namespace Restory.Utils
{
	public static class MonoBehaviourExtensions
	{
		public static bool MonoShellExists(this MonoBehaviour monoBehaviour)
		{
			if ((object)monoBehaviour == null)
			{
				return false;
			}
			return monoBehaviour;
		}
	}
}
