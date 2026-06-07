using System.Collections.Generic;
using Gh.Tk.Story.Structure;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class StaffRequirementXRequirementNode : StaffRequirement, IStaffFilterNode
	{
		[Range(1f, 3f)]
		public int minTier;

		public Gender gender;

		public bool excludeStoryStaff;

		[DropDownChoice(new string[] { "healthy", "sick", "any" })]
		public string sickState;

		[DropDownChoice(new string[] { "awake", "asleep", "any" })]
		public string sleepState;

		[DropDownChoice(new string[] { "atWork", "offWork", "any" })]
		public string workState;

		[DropDownChoice(typeof(StoryHelper), "GetStaffTraits")]
		public string[] mustHaveTraits;

		[DropDownChoice(typeof(StoryHelper), "GetStaffTraits")]
		public string[] cannotHaveTraits;

		[Range(0f, 100f)]
		[HideInInspector]
		public int minHappiness;

		[Range(0f, 100f)]
		[HideInInspector]
		public int maxHappiness;

		string IStaffFilterNode.race => null;

		int IStaffFilterNode.minTier => 0;

		Gender IStaffFilterNode.gender => default(Gender);

		bool IStaffFilterNode.excludeStoryStaff => false;

		string IStaffFilterNode.sickState => null;

		string IStaffFilterNode.sleepState => null;

		string IStaffFilterNode.workState => null;

		string[] IStaffFilterNode.mustHaveTraits => null;

		string[] IStaffFilterNode.cannotHaveTraits => null;

		int IStaffFilterNode.minHappiness => 0;

		int IStaffFilterNode.maxHappiness => 0;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void AiComponentChanged(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		protected override IEnumerable<Staff> GetStaff(ActiveStory story)
		{
			return null;
		}
	}
}
