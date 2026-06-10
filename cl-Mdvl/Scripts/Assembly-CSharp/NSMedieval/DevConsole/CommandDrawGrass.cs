using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandDrawGrass : NodeDrawConsoleCommand
	{
		private bool active;

		private float grassValue;

		private Ray ray;

		private RaycastHit hit;

		public CommandDrawGrass()
		{
			Command = "drawGrass";
			Description = "Draw grass where the cursor is. Right click to disable this debug tool.";
			Help = "Usage: drawGrass <grassValue:float 0-1>";
		}

		protected override void NodeOperation(MapNode node, float value)
		{
			node.Map.SnowGrassWetnessManager.SetGrassHealth(node.Index, value);
			node.Map.FireSimLogic.ForceRefreshFlammability(node);
		}
	}
}
