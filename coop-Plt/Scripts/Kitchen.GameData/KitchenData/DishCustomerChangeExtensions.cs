namespace KitchenData
{
	public static class DishCustomerChangeExtensions
	{
		public static int Value(this DishCustomerChange dcc)
		{
			return dcc switch
			{
				DishCustomerChange.None => 0, 
				DishCustomerChange.SmallIncrease => -1, 
				DishCustomerChange.LargeIncrease => -2, 
				DishCustomerChange.SmallDecrease => 1, 
				DishCustomerChange.LargeDecrease => 2, 
				DishCustomerChange.FranchiseTier => -2, 
				_ => 0, 
			};
		}
	}
}
