using System;
using UnityEngine;

namespace CTS.Utilities
{
	public static class DestroyEventExtensions
	{
		public static void RegisterToDestroy(this GameObject go, Action destroyed)
		{
			if (!(go == null))
			{
				if (!go.TryGetComponent<DestroyEvent>(out var component))
				{
					component = go.AddComponent<DestroyEvent>();
				}
				component.Destroyed += destroyed;
			}
		}

		public static void UnregisterToDestroy(this GameObject go, Action destroyed)
		{
			if (!(go == null) && go.TryGetComponent<DestroyEvent>(out var component))
			{
				component.Destroyed -= destroyed;
			}
		}
	}
}
