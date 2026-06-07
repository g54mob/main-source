using UnityEngine.Scripting;
using XNode;

namespace Gh.Tk.Story.SpecialUseCase
{
	[InitializeOnGameStarted]
	[NodeTint("#9d9d9d")]
	public class ActScheduleNode : BaseInkNode
	{
		public EntertainerConfig entertainerConfig;

		protected const string ActProfileId_Key = "actProfileId";

		protected const string EntertainerId_Key = "entertainerId";

		protected const string IsEntertainerPlaying_Key = "isEntertainerPlaying";

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		private static void Entertainer_StartedEntertaining(object sender, EventArgs<Entertainer> eventArgs)
		{
		}

		public override void OnUpdate(ActiveStory story)
		{
		}

		private static void Entertainer_FinishedEntertaining(object sender, EventArgs<Entertainer> eventArgs)
		{
		}
	}
}
