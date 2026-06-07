using UnityEngine;

namespace DV
{
	public static class OptionExtensions
	{
		public static Option<T> GetOptionalComponent<T>(this GameObject gameObject) where T : Component
		{
			if (!gameObject.TryGetComponent<T>(out var component))
			{
				return Option<T>.None;
			}
			return Option<T>.Some(component);
		}

		public static Option<T> GetOptionalComponent<T>(this Component component) where T : Component
		{
			if (!component.TryGetComponent<T>(out var component2))
			{
				return Option<T>.None;
			}
			return Option<T>.Some(component2);
		}
	}
}
