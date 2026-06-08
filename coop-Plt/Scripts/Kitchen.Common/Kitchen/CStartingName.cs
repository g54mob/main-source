using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public struct CStartingName : IComponentData
	{
		public FixedString32 Name;
	}
}
