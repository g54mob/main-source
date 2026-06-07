using UnityEngine;

namespace DG.Tweening.Timeline.Core
{
	public class DOTweenTimelineSettings : ScriptableObject
	{
		public const string Version = "0.9.756";

		public const string ResourcePath = "DOTweenTimelineSettings";

		public bool foo_debugLogs;

		private static DOTweenTimelineSettings _instance;

		private static bool _foo_isApplicationPlaying;

		private static bool _foo_isApplicationPlayingSet;

		private static bool _foo_addTargetToNestedTweens;

		private static bool _foo_addTargetToNestedTweensSet;

		public static DOTweenTimelineSettings I => null;

		public bool debugLogs => false;

		public static bool isApplicationPlaying => false;

		public static bool addTargetToNestedTweens => false;
	}
}
