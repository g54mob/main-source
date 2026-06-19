using I2.Loc;

namespace PugMod
{
	public class ModAPILocalization : ILocalization
	{
		public string GetLocalizedTerm(string term)
		{
			return LocalizationManager.GetTranslation(term);
		}
	}
}
