using Unity.Entities;

namespace Pug.Automation
{
	public struct MoverFilterCD : IComponentData, IQueryTypeParameter
	{
		public FilterType filterType;

		public ObjectID filterObject;

		public int filterVariation;

		public ObjectCategoryTag filterCategory;
	}
}
