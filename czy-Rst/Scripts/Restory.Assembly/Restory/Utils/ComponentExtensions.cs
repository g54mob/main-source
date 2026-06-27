using UnityEngine;

namespace Restory.Utils
{
	public static class ComponentExtensions
	{
		public static bool ValidateComponent<T>(this T component, GameObject owner) where T : Component
		{
			_ = (bool)component;
			return component;
		}
	}
}
