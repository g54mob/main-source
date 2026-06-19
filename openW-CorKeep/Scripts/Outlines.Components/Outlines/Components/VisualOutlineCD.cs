using Unity.Entities;

namespace Outlines.Components
{
	public struct VisualOutlineCD : IComponentData, IQueryTypeParameter
	{
		public OutlineType outlineType;
	}
}
