using UnityEngine.Scripting;

namespace Gh.Tk.Story.GameModifiers
{
	[InitializeOnGameStarted]
	public class AdjustStaffCostsGameModifierNode : GameModifierNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetRaces")]
		public string race;

		public float wageModifier;

		public bool changeExistingHiredStaff;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void AdjustStaff(Staff staff)
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
