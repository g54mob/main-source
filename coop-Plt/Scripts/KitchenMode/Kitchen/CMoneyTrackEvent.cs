using Unity.Entities;

namespace Kitchen
{
	public struct CMoneyTrackEvent : IComponentData
	{
		public int Identifier;

		public int Amount;
	}
}
