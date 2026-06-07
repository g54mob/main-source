using UnityEngine;

namespace Gh.Tk.Story.GameModifiers
{
	public class ToggleRoomSelectionEnabledGameModifierNode : GameModifierNode
	{
		[Tooltip("the last active node's value will be used")]
		public bool setEnabled;

		public static bool IsRoomSelectionEnabled()
		{
			return false;
		}
	}
}
