using UnityEngine;

namespace Gh.Tk.Story.GameModifiers
{
	public class ToggleGameObjectSelectionGameModifierNode : GameModifierNode
	{
		[Tooltip("the last active node's value will be used")]
		public bool allowSelection;

		public static bool IsSelectionAllowed()
		{
			return false;
		}
	}
}
