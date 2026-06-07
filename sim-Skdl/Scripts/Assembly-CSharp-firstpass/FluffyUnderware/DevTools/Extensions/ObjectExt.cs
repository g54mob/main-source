using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools.Extensions
{
	public static class ObjectExt
	{
		[Obsolete("Use the other overload of this method")]
		[UsedImplicitly]
		public static bool Destroy(this UnityEngine.Object @object)
		{
			return false;
		}

		public static bool Destroy(this UnityEngine.Object @object, bool isUndoable, bool doPrefabCheck)
		{
			return false;
		}

		public static string ToDumpString(this object o)
		{
			return null;
		}
	}
}
