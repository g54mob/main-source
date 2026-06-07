using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	internal static class ComponentExtensions
	{
		public static T[] GetComponentsInChildren<T>(this Component self, int depth) where T : Component
		{
			return null;
		}

		public static void GetComponentsInChildren<T>(this Component self, List<T> results, int depth) where T : Component
		{
		}

		private static void GetComponentsInChildren_Internal<T>(this Component self, List<T> results, int depth) where T : Component
		{
		}

		public static T GetOrAddComponent<T>(this Component self) where T : Component
		{
			return null;
		}

		public static T GetRootComponent<T>(this Component self) where T : Component
		{
			return null;
		}

		public static T GetComponentInParent<T>(this Component self, bool includeSelf, Transform stopAfter, Predicate<T> valid) where T : Component
		{
			return null;
		}

		public static void AddComponentOnChildren<T>(this Component self, HideFlags hideFlags, bool includeSelf) where T : Component
		{
		}

		public static void AddComponentOnChildren<T>(this Component self, bool includeSelf) where T : Component
		{
		}
	}
}
