using System.Collections.Generic;
using System.ComponentModel;
using NSMedieval.Village.Map;
using NodeCanvas.Framework;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Siege")]
	public class SiegeRemoveCurrentNode : CommanderAIBTActionBase
	{
		public BBParameter<List<MapNode>> siegePath;

		protected override void OnStart()
		{
			if (siegePath?.value == null)
			{
				EndAction(success: false);
				return;
			}
			siegePath.value.RemoveAt(siegePath.value.Count - 1);
			EndAction();
		}
	}
}
