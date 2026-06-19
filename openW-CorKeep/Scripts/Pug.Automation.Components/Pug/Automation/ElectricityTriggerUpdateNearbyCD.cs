using Unity.Entities;
using Unity.Mathematics;

namespace Pug.Automation
{
	public struct ElectricityTriggerUpdateNearbyCD : IComponentData, IQueryTypeParameter
	{
		public int2 position;

		public bool useDoubleRange;
	}
}
