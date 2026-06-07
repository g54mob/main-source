using UnityEngine.Scripting;

namespace Gh.Tk.Story.GameModifiers
{
	[InitializeOnGameStarted]
	public class AllowOnlySkeletonStaffHiresGameModifierNode : GameModifierNode
	{
		private static bool IsActive => false;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void GameHooks_StaffGenerated(object sender, EventArgs<Staff> e)
		{
		}

		private static void GameHooks_BeforeGeneratingStaff(object sender, EventArgs<StaffData> e)
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
