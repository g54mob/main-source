namespace Gh.Tk.Story.GameModifiers
{
	public class GameBalanceSettingModifierNode : GameModifierNode
	{
		[DropDownChoice(typeof(GameBalanceSettingModifierNode), "GetAllPropertyNames")]
		public string propertyName;

		public int modifierValue;

		protected GameBalanceSettingModifierNode()
		{
		}

		public static string[] GetAllPropertyNames()
		{
			return null;
		}

		public override string GetGroupKey()
		{
			return null;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void Complete(ActiveStory story)
		{
		}

		public override string GetAlertTextKey()
		{
			return null;
		}

		public int GetModifierValue()
		{
			return 0;
		}
	}
}
