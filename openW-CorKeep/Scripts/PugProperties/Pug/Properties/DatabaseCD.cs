using Unity.Entities;

namespace Pug.Properties
{
	public struct DatabaseCD : IComponentData, IQueryTypeParameter
	{
		public PropertyLookup ObjectPropertyLookup;
	}
}
