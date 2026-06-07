using System;
using JetBrains.Annotations;

namespace FluffyUnderware.DevTools
{
	public static class DTTime
	{
		[UsedImplicitly]
		[Obsolete("Will get removed since it is not used by Curvy, and needs maintenance to be compatible with Unity's Enter Play Mode Settings")]
		private static float _EditorDeltaTime;

		[Obsolete("Will get removed since it is not used by Curvy, and needs maintenance to be compatible with Unity's Enter Play Mode Settings")]
		[UsedImplicitly]
		private static float _EditorLastTime;

		public static double TimeSinceStartup => 0.0;

		[Obsolete("Seems to me that this is not working properly. Probably because InitializeEditorTime and UpdateEditorTime are never called. Fix this before using it")]
		[UsedImplicitly]
		public static float deltaTime => 0f;

		[UsedImplicitly]
		[Obsolete("Will get removed since it is not used by Curvy, and needs maintenance to be compatible with Unity's Enter Play Mode Settings")]
		public static void InitializeEditorTime()
		{
		}

		[UsedImplicitly]
		[Obsolete("Will get removed since it is not used by Curvy, and needs maintenance to be compatible with Unity's Enter Play Mode Settings")]
		public static void UpdateEditorTime()
		{
		}
	}
}
