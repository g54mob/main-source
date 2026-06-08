using Unity.Entities;

namespace Kitchen
{
	public struct SMoney : IComponentData
	{
		public int Amount;

		public static implicit operator int(SMoney m)
		{
			return m.Amount;
		}

		public static implicit operator SMoney(int m)
		{
			return new SMoney
			{
				Amount = m
			};
		}
	}
}
