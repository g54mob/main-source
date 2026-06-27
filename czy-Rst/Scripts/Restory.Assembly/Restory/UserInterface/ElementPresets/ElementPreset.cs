using System;

namespace Restory.UserInterface.ElementPresets
{
	[Serializable]
	public class ElementPreset
	{
		private const string AllRules = "All Rules";

		public PresetName Name;

		public GameObjectActivationRules GameObjectRules;

		public MonoBehaviourActivationRules ComponentRules;

		public ScaleRules ScaleRules;

		public RectSizeRules RectSizeRules;

		public CanvasGroupRules CanvasGroupRules;

		public SpriteOverrideRules SpriteOverrideRules;

		public ImageColorRules ImageColorRules;

		public ButtonInteractionRules ButtonInteractionRules;

		public TextGroupRules TextGroupRules;

		public CursorStateSetterRules CursorStateSetterRules;

		public GUI_LocalisedTextRules LocalisedTextRules;

		public void Apply()
		{
			GameObjectRules.Apply();
			CanvasGroupRules.Apply();
			SpriteOverrideRules.Apply();
			ImageColorRules.Apply();
			ButtonInteractionRules.Apply();
			TextGroupRules.Apply();
			ScaleRules.Apply();
			RectSizeRules.Apply();
			ComponentRules.Apply();
			LocalisedTextRules.Apply();
			CursorStateSetterRules.Apply();
		}

		public void Revert()
		{
			GameObjectRules.Revert();
			CanvasGroupRules.Revert();
			SpriteOverrideRules.Revert();
			ImageColorRules.Revert();
			ButtonInteractionRules.Revert();
			TextGroupRules.Revert();
			ScaleRules.Revert();
			RectSizeRules.Revert();
			ComponentRules.Revert();
			LocalisedTextRules.Revert();
			CursorStateSetterRules.Revert();
		}
	}
}
