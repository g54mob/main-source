using System;
using Affixes.Authoring;
using Affixes.Components;
using Pug.Conversion;

namespace Affixes.Converters
{
	public class SupportAffixConverter : SingleAuthoringComponentConverter<SupportAffixesAuthoring>
	{
		private static Array _affixIDValues;

		protected override void Convert(SupportAffixesAuthoring authoring)
		{
			((Converter)this).EnsureHasBuffer<ActiveAffixConditionsBuffer>();
			((Converter)this).EnsureHasBuffer<ActiveAffixStateBuffer>();
			((Converter)this).EnsureHasBuffer<DefaultSupportedAffixesBuffer>();
			((Converter)this).EnsureHasComponent<InitializedAffixesCD>(true);
			if (_affixIDValues == null)
			{
				_affixIDValues = Enum.GetValues(typeof(AffixID));
			}
			foreach (AffixID affixIDValue in _affixIDValues)
			{
				((Converter)this).AddToBuffer<DefaultSupportedAffixesBuffer>(new DefaultSupportedAffixesBuffer
				{
					affixID = affixIDValue
				});
			}
		}
	}
}
