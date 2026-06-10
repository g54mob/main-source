using NSMedieval.Model;
using NSMedieval.UI.Utils;
using Social;

namespace NSEipix.Repository
{
	public class ConversationLogDataRepository : DynamicJsonRepository<ConversationLogDataRepository, PersonalLogData>
	{
		public string GetRandomVariantLocalized(string id, string variantId = "default")
		{
			LocKeys[] variantLocKeys = GetByID(id).GetVariantLocKeys(variantId);
			if (variantLocKeys != null && LocKeyUtils.GetRandomVariation(variantLocKeys, out var randomVariant))
			{
				return UiUtils.Localize.GetText(randomVariant);
			}
			return null;
		}

		protected override string JsonFile()
		{
			return "SocialInteraction/ConversationLogData.json";
		}
	}
}
