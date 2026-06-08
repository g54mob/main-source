using Unity.Entities;

namespace Kitchen
{
	public struct COrderAcceptance : IComponentData
	{
		public int OrderIndex;

		public int MemberIndex;

		public int ProvidedSide;

		public int MaxSharers;

		public int Sharers;

		public int DeliveredItem;

		public int CreditDish;

		public Entity TableSet;

		public Entity Group;

		public Entity Source;

		public CItem OrderedItem;

		public bool IsSide;

		public bool AlwaysSatisfyAnything;

		public Entity Leftovers;

		public bool IsExtraSatisfaction;
	}
}
