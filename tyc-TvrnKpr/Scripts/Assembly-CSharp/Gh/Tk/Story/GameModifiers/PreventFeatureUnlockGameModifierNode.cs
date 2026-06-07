namespace Gh.Tk.Story.GameModifiers
{
	public class PreventFeatureUnlockGameModifierNode : GameModifierNode
	{
		[DropDownChoice(typeof(FeatureUnlockKey), "GetAllKeys")]
		public string keyToUnlock;

		public static bool CanUnlock(string key)
		{
			return false;
		}
	}
}
