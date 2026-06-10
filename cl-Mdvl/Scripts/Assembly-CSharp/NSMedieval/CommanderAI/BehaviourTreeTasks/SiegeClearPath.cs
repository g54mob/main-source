using System.Collections.Generic;
using System.ComponentModel;
using NSMedieval.Village.Map;
using NodeCanvas.Framework;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Siege")]
	public class SiegeClearPath : CommanderAIBTActionBase
	{
		public BBParameter<List<MapNode>> siegePath;

		protected override void OnStart()
		{
			if (siegePath?.value == null)
			{
				EndAction();
				return;
			}
			siegePath.value.Clear();
			siegePath.value = null;
			EndAction();
		}
	}
}
