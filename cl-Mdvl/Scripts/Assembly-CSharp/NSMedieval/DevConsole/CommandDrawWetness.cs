using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandDrawWetness : NodeDrawConsoleCommand
	{
		private bool active;

		private int wetnessValue;

		private Ray ray;

		private RaycastHit hit;

		public CommandDrawWetness()
		{
			Command = "drawWetness";
			Description = "Draw wetness where the cursor is. Right click to disable this debug tool.";
			Help = "Usage: drawWetness <wetness:int 0-255> Use mouse+lmb to draw, lshift to fill whole region, lshift+lctrl to fill the whole map";
		}

		protected override void NodeOperation(MapNode node, float value)
		{
			node.Map.SnowGrassWetnessManager.SetWetness(node.Index, (byte)value);
		}
	}
}
