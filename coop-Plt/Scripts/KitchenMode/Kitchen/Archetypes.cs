namespace Kitchen
{
	public static class Archetypes
	{
		public static KitchenArchetype StaticAppliance = new KitchenArchetype(typeof(CAppliance), typeof(CPosition), typeof(CRequiresView));

		public static KitchenArchetype Appliance = new KitchenArchetype(StaticAppliance, typeof(CIsInteractive));

		public static KitchenArchetype Item = new KitchenArchetype(typeof(CItem), typeof(CPosition), typeof(CRequiresView), typeof(CHeldBy));
	}
}
