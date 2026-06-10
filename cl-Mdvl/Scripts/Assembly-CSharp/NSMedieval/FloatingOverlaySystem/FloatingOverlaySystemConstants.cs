namespace NSMedieval.FloatingOverlaySystem
{
	internal static class FloatingOverlaySystemConstants
	{
		internal static readonly string[] ElementHolderPrefabName = new string[4] { "None", "DefaultFloatingOverlayHolder", "NoGridFloatingOverlayHolder", "AdditionalMenuElementHolder" };

		internal static readonly string[] ProgressBarPrefabNames = new string[5] { "None", "ProgressBarLineRed", "ProgressBarLineGreen", "ProgressBarCircle", "ProgressBarCombatCircle" };

		internal static readonly string[] TextElementPrefabs = new string[7] { "None", "DefaultTextGameplayOverlay", "WorkerNameGameplayOverlay", "EnemyNameGameplayOverlay", "TraderNameGameplayOverlay", "TraderBodyguardNameGameplayOverlay", "AnimalNameGameplayOverlay" };

		public static readonly string[] CircleIconPrefabNames = new string[3] { "None", "IconCombatCoverVulnerability", "IconHasFlammableProjectile" };

		internal static readonly string DamagePopupPrefab = "DamagePopupGameplayOverlay";

		internal static readonly string XpPopupPrefab = "XpPopupGameplayOverlay";

		internal static readonly string ThoughtBubblePrefab = "ThoughtBubbleGameplayOverlay";

		internal static readonly string AdditionalMenuPrefab = "AdditionalMenuOverlay";
	}
}
