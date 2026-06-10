using System.Collections.Generic;
using NSMedieval.Goap;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval")]
	[Description("Prepare world objects of interest to be guarded")]
	public class PrepareArtilleryObjectsToGuardBTAction : CommanderAIBTActionBase
	{
		public BBParameter<List<CommanderAIUnit>> artillerySquad;

		public BBParameter<List<IGoapTargetable>> saveTargetsAs;

		protected override string info => $"{saveTargetsAs} = artillery POIs to guard";

		protected override void OnStart()
		{
			if (artillerySquad.value == null || artillerySquad.value.Count == 0)
			{
				EndAction(success: false);
				return;
			}
			BBParameter<List<IGoapTargetable>> bBParameter = saveTargetsAs;
			if (bBParameter.value == null)
			{
				List<IGoapTargetable> list = (bBParameter.value = new List<IGoapTargetable>());
			}
			saveTargetsAs.value.Clear();
			foreach (CommanderAIUnit item in artillerySquad.value)
			{
				saveTargetsAs.value.Add(item.Humanoid);
			}
			EndAction();
		}
	}
}
