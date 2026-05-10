using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools.Extensions
{
	public static class TransformExt
	{
		public static void UndoableSetParent([NotNull] this Transform child, [NotNull] Transform newParent, bool worldPositionStays, [NotNull] string undoOperationName)
		{
		}

		public static void DeleteChildren([NotNull] this Transform transform, bool isUndoable, bool doPrefabCheck)
		{
		}
	}
}
