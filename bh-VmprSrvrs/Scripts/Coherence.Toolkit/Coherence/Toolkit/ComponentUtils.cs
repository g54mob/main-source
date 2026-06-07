using UnityEngine;

namespace Coherence.Toolkit
{
	internal static class ComponentUtils
	{
		public static T SelfOrNull<T>(this T self) where T : Object
		{
			return null;
		}
	}
}
