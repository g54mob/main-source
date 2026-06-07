using System;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.UI;
using Assets.Scripts.UI;

namespace Assets.Scripts.Design.Demo
{
	public static class DemoMessages
	{
		public const string AddPart = "Adding parts is not available in the demo version of the game.";

		public const string DefaultMessage = "This functionality is not available in the demo version of the game.";

		public const string DefaultMessageDialogTitle = "Not Available In Demo";

		public const string ExportCraft = "Exporting crafts is not available in the demo version of the game.";

		public const string NewCraft = "Creating new crafts is not available in the demo version of the game.";

		public const string PartProperties = "The part properties are read-only in the demo version of the game.";

		public const string ReconnectSelectedPart = "This functionality is not available in the demo version of the game.";

		public const string RotatePart = "Rotating craft parts is not available in the demo version of the game.";

		public const string ShareCraft = "Sharing crafts is not available in the demo version of the game. This is used for uploading your designs the the SimplePlanes.com website where the entire community can download, fly, upvote, and discuss your creations.";

		public const string Symmetry = "Symmetry functionality is not available in the demo version of the game.";

		public const string ToolNotAvailableDialogTitle = "Not Available In Demo";

		public const string TranslatePart = "Moving craft parts is not available in the demo version of the game.";

		public const string VariableOutputs = "The variable outputs dialog is not available in the demo version of the game.";

		public const string VariableSetters = "The variable setters dialog is not available in the demo version of the game.";

		public static string FlyoutNotAvailable(IFlyout flyout)
		{
			IDesignerFlyouts flyouts = Designer.Instance.DesignerScript.DesignerUI.Flyouts;
			if (flyout == flyouts.Blueprints)
			{
				return "The blueprints utility is unavailable in the demo version of the game. This utility is used for loading and viewing images as references to build with.";
			}
			if (flyout == flyouts.PartConnections)
			{
				return "The part connections utility is unavailable in the demo version of the game. This utility is used for viewing and modifying how parts of your craft are connected to each other.";
			}
			if (flyout == flyouts.TransformPart)
			{
				return "The transform part utility is unavailable in the demo version of the game. This utility is used for fine tuning the exact position and rotation of parts of your craft.";
			}
			return "This functionality is not available in the demo version of the game.";
		}

		public static string ToolNotAvailable(Func<DesignerTools, DesignerTool> toolSelector)
		{
			return ToolNotAvailable(toolSelector(Designer.Instance.Tools));
		}

		public static string ToolNotAvailable(DesignerTool tool)
		{
			if (!(tool is MovePartTool))
			{
				if (!(tool is RotateTool))
				{
					if (tool is TranslateTool)
					{
						return "The translate part tool is unavailable in the demo version of the game. This tool is used for quickly tweaking the exact positioning of parts of your craft.";
					}
					return "This tool is not available in the demo version of the game.";
				}
				return "The rotate part tool is unavailable in the demo version of the game. This tool is used for rotating parts of your craft.";
			}
			return "The move part tool is unavailable in the demo version of the game. This tool is used for moving, adding, deleting, and modifying parts of your craft.";
		}
	}
}
