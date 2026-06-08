using Unity.Entities;

namespace Kitchen
{
	public struct CAppliesEffect : IComponentData
	{
		public bool IsActive;

		public static implicit operator bool(CAppliesEffect a)
		{
			return a.IsActive;
		}

		public static implicit operator CAppliesEffect(bool a)
		{
			return new CAppliesEffect
			{
				IsActive = a
			};
		}
	}
}
