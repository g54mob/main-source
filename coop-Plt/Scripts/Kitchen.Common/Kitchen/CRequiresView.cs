using Unity.Entities;

namespace Kitchen
{
	public struct CRequiresView : IComponentData
	{
		public ViewType Type;

		public bool PhysicsDriven;

		public ViewMode ViewMode;

		public static implicit operator ViewType(CRequiresView a)
		{
			return a.Type;
		}

		public static implicit operator CRequiresView(ViewType a)
		{
			return new CRequiresView
			{
				Type = a
			};
		}
	}
}
