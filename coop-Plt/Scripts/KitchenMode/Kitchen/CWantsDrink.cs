using Unity.Entities;

namespace Kitchen
{
	public struct CWantsDrink : IComponentData
	{
		public DrinkData Drink;

		public float TimeToNextDrink;

		public static implicit operator DrinkData(CWantsDrink d)
		{
			return d.Drink;
		}

		public static implicit operator CWantsDrink(DrinkData d)
		{
			return new CWantsDrink
			{
				Drink = d
			};
		}
	}
}
