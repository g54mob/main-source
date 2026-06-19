using FireSpreading.Authoring;
using Pug.Conversion;

namespace FireSpreading.Converters
{
	public class IgnitableConverter : SingleAuthoringComponentConverter<IgnitableAuthoring>
	{
		protected override void Convert(IgnitableAuthoring authoring)
		{
			((Converter)this).AddComponentData<IgnitableCD>(new IgnitableCD
			{
				spawnOnIgnitedObjectID = authoring.spawnOnIgnitedObjectID,
				spawnOnIgnitedVariation = authoring.spawnOnIgnitedVariation
			});
		}
	}
}
