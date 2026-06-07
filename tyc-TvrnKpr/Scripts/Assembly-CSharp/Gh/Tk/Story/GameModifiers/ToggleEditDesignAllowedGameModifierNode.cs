using UnityEngine;

namespace Gh.Tk.Story.GameModifiers
{
	public class ToggleEditDesignAllowedGameModifierNode : GameModifierNode
	{
		[Tooltip("the last active node's value will be used")]
		public bool setAllowed;

		public static bool IsEditingDesignAllowed()
		{
			return false;
		}
	}
}
