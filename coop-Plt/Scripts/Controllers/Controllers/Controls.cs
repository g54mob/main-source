using System.Collections.Generic;

namespace Controllers
{
	public static class Controls
	{
		public static string Interact1 = "Interact1";

		public static string Interact2 = "Interact2";

		public static string Interact3 = "Interact3";

		public static string Interact4 = "Interact4";

		public static string Interact1Crane = "Interact1Crane";

		public static string Interact2Crane = "Interact2Crane";

		public static string Movement = "Movement";

		public static string Stick2 = "Stick2";

		public static string StopMoving = "StopMoving";

		public static string MenuTrigger = "Settings";

		public static string MenuUp = "MenuUp";

		public static string MenuDown = "MenuDown";

		public static string MenuLeft = "MenuLeft";

		public static string MenuRight = "MenuRight";

		public static string MenuSelect = "MenuSelect";

		public static string MenuCancel = "MenuCancel";

		public static List<string> RebindableControls { get; } = new List<string> { Interact1, Interact2, Interact3, Interact4, StopMoving };

		public static List<string> GameplayControls { get; } = new List<string> { Interact1, Interact2, Interact3, Interact4, Movement };

		public static string Get(Button button)
		{
			return button switch
			{
				Button.Interact1 => "Interact1", 
				Button.Interact2 => "Interact2", 
				Button.Interact3 => "Interact3", 
				Button.Interact4 => "Interact4", 
				Button.Settings => "Settings", 
				_ => "", 
			};
		}
	}
}
