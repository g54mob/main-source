namespace Libs.PS5
{
	public class PSNManager : SingletonMonoBehaviour<PSNManager>
	{
		public static void UnlockTrophy_(int trophyID)
		{
		}

		public static void UnlockTrophy(int trophyID)
		{
		}

		public static void InvokeActivity(string activityEventName, params string[] args)
		{
		}

		public static void ActivityEnd(string activityID, string outcome = "completed")
		{
		}

		public static void ActivityStart(string activityID)
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public static void MainModeActivityEnd(eWriterId battleDataWriterId, bool finalLastBattle)
		{
		}

		public static void MainModeActivityStart(eWriterId battleDataWriterId, bool finalLastBattle)
		{
		}

		private static string GetActivityId(eWriterId battleDataWriterId, bool finalLastBattle)
		{
			return null;
		}
	}
}
