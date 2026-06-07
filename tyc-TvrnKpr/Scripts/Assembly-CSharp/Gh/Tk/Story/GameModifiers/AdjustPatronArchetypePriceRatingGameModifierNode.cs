namespace Gh.Tk.Story.GameModifiers
{
	public class AdjustPatronArchetypePriceRatingGameModifierNode : GameModifierNode
	{
		public PatronArchetypeRatingModifierConfig[] config;

		public static (int, string) GetModifier(string race, int tier, bool includeReason)
		{
			return default((int, string));
		}
	}
}
