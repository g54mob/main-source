using System;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Tools
{
	public static class GameObjectExtensions
	{
		private static List<Component> m_ComponentCache;

		public static Component MMGetComponentNoAlloc(this GameObject @this, Type componentType)
		{
			return null;
		}

		public static T MMGetComponentNoAlloc<T>(this GameObject @this) where T : Component
		{
			return null;
		}

		public static T MMGetComponentAroundOrAdd<T>(this GameObject @this) where T : Component
		{
			return null;
		}
	}
}
