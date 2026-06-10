using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandDrawSnow : NodeDrawConsoleCommand
	{
		private bool active;

		private int snowValue;

		private Ray ray;

		private RaycastHit hit;

		public CommandDrawSnow()
		{
			Command = "drawSnow";
			Description = "Draw snow where the cursor is. Right click to disable this debug tool.";
			Help = "Usage: drawSnow <snow:int 0-255>";
		}

		protected override void NodeOperation(MapNode node, float value)
		{
			node.Map.SnowGrassWetnessManager.SetSnow(node.Index, (byte)value);
		}
	}
}
