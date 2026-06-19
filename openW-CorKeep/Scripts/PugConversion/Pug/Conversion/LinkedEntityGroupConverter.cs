using Unity.Entities;
using Unity.Entities.Hybrid.Baking;

namespace Pug.Conversion
{
	public class LinkedEntityGroupConverter : SingleAuthoringComponentConverter<LinkedEntityGroupAuthoring>
	{
		protected override void Convert(LinkedEntityGroupAuthoring authoring)
		{
			EnsureHasBuffer<LinkedEntityGroup>();
		}
	}
}
