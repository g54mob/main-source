using Affixes.Authoring;
using Affixes.Components;
using Pug.Conversion;

namespace Affixes.Converters
{
	public class AffixConverter : SingleAuthoringComponentConverter<AffixAuthoring>
	{
		protected override void Convert(AffixAuthoring authoring)
		{
			((Converter)this).AddComponentData<AffixCD>(new AffixCD
			{
				dispalyConnectionToOwner = true
			});
		}
	}
}
