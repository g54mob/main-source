using Unity.Entities;

namespace Pug.Automation
{
	public struct ElectricitySourceCD : IComponentData, IQueryTypeParameter
	{
		public int sourceEnergy;

		public int sourceUpdate;
	}
}
