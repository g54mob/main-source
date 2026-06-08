using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.Buildings;
using Timberborn.Coordinates;

namespace Timberborn.ConstructionSites
{
	public class ConstructionFactory
	{
		private readonly BlockObjectFactory _blockObjectFactory;

		public ConstructionFactory(BlockObjectFactory blockObjectFactory)
		{
			_blockObjectFactory = blockObjectFactory;
		}

		public ConstructionSite CreateAsUnfinished(BuildingSpec template, Placement placement)
		{
			return _blockObjectFactory.CreateUnfinished(template.GetSpec<BlockObjectSpec>(), placement).GetComponent<ConstructionSite>();
		}

		public BaseComponent CreateAsFinished(BuildingSpec template, Placement placement)
		{
			ConstructionSite constructionSite = CreateAsUnfinished(template, placement);
			constructionSite.FinishNow();
			return constructionSite;
		}
	}
}
