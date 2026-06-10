using NSEipix.Model;
using NSEipix.Repository;
using TMPro;

namespace NSMedieval.Repository
{
	public class StyleSheetRepository : MonoRepository<StyleSheetRepository, KeyStyleSheetPair>
	{
		public TMP_StyleSheet GeStyleSheet(string language)
		{
			KeyStyleSheetPair byID = GetByID(language);
			if (!(byID == null))
			{
				return byID.Value;
			}
			return null;
		}
	}
}
