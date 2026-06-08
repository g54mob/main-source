using Unity.Entities;

namespace Kitchen
{
	public struct CDrinkProvider : IComponentData
	{
		public DrinkData Drink;

		public bool IsVisible;

		public static implicit operator DrinkData(CDrinkProvider d)
		{
			return d.Drink;
		}

		public static implicit operator CDrinkProvider(DrinkData d)
		{
			return new CDrinkProvider
			{
				Drink = d
			};
		}
	}
}
