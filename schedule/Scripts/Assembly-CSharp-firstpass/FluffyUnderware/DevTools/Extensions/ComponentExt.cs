using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools.Extensions
{
	public static class ComponentExt
	{
		public static void StripComponents(this Component c, params Type[] toKeep)
		{
		}

		[UsedImplicitly]
		[Obsolete]
		public static GameObject AddChildGameObject(this Component c, string name)
		{
			return null;
		}

		[Obsolete]
		[UsedImplicitly]
		public static T AddChildGameObject<T>(this Component c, string name) where T : Component
		{
			return null;
		}

		[NotNull]
		public static T DuplicateGameObject<T>([NotNull] this Component source, [CanBeNull] Transform newParent) where T : Component
		{
			return null;
		}

		[Obsolete("Use the other DuplicateGameObject method instead")]
		[UsedImplicitly]
		[CanBeNull]
		public static T DuplicateGameObject<T>(this Component source, Transform newParent, bool keepPrefabConnection) where T : Component
		{
			return null;
		}

		[Obsolete("Use the other DuplicateGameObject method instead")]
		[UsedImplicitly]
		public static Component DuplicateGameObject(this Component source, Transform newParent, bool keepPrefabConnection = false)
		{
			return null;
		}
	}
}
