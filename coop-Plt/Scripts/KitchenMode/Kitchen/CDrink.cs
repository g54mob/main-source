using Unity.Entities;

namespace Kitchen
{
	public struct CDrink : IComponentData
	{
		public DrinkData Data;

		public static implicit operator DrinkData(CDrink d)
		{
			return d.Data;
		}

		public static implicit operator CDrink(DrinkData d)
		{
			return new CDrink
			{
				Data = d
			};
		}
	}
}
