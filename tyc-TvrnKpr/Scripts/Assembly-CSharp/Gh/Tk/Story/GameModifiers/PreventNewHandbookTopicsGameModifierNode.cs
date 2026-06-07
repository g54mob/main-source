namespace Gh.Tk.Story.GameModifiers
{
	public class PreventNewHandbookTopicsGameModifierNode : GameModifierNode
	{
		private void Awake()
		{
		}

		public static bool CanUnlockHandbookTopic()
		{
			return false;
		}
	}
}
