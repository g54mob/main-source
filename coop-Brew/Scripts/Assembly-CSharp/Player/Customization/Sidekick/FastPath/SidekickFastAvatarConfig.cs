using UnityEngine;

namespace Player.Customization.Sidekick.FastPath
{
	[CreateAssetMenu(fileName = "SidekickFastAvatarConfig", menuName = "Sidekick/Fast Avatar Config", order = 0)]
	public class SidekickFastAvatarConfig : ScriptableObject
	{
		public const string RESOURCES_PATH = "SidekickFastAvatarConfig";

		[Header("Kill switch")]
		[Tooltip("Master toggle. When false, SidekickFastAvatar components are inert and the legacy SidekickCharacterCustomizer rebuild path runs exactly as before. Toggle to false at any time to instantly revert.")]
		public bool enableFastPath;

		[Header("Frame budget (applies globally across ALL remote avatars)")]
		[Tooltip("Hard ceiling on main-thread ms spent per frame on fast-avatar build work. Lower = smoother but slower visual completion. 2ms is a safe default that keeps 60fps headroom; raise only if avatars take too long to finish appearing.")]
		[Range(0.25f, 8f)]
		public float msBudgetPerFrame;

		[Tooltip("Max number of fast-avatar build jobs that may be active concurrently. Extra joiners queue up behind the first ones. 1 = strict serial, smoothest. Higher values fan out but still obey the global ms budget.")]
		[Range(1f, 8f)]
		public int maxConcurrentJobs;

		[Header("Per-step cadence")]
		[Tooltip("Minimum frames between each streamed part attachment. Adds breathing room regardless of budget. Raise if you see cumulative hitches from other systems during avatar stream-in.")]
		[Range(0f, 10f)]
		public int framesBetweenSteps;

		[Header("Rendering")]
		[Tooltip("When true, remote avatars start invisible and fade in as their parts finish streaming. When false, the base skeleton shows immediately and parts pop in one by one.")]
		public bool hideUntilReady;

		[Header("Legacy rebuild interception")]
		[Tooltip("Use reflection to flip SidekickCharacterCustomizer's private _isRebuilding flag on non-owner spawns, preventing the expensive legacy rebuild. If reflection fails (e.g. the field was renamed), fast path falls back to additive mode — you get the fast avatar AND the legacy work still runs. A warning is logged so you notice.")]
		public bool interceptLegacyRebuild;

		[Header("Diagnostics")]
		public bool verboseLogs;

		private static SidekickFastAvatarConfig _cached;

		public static SidekickFastAvatarConfig Get()
		{
			return null;
		}

		public static void InvalidateCache()
		{
		}
	}
}
