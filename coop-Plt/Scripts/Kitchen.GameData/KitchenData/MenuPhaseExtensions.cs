namespace KitchenData
{
	public static class MenuPhaseExtensions
	{
		public static MenuPhase Next(this MenuPhase phase)
		{
			return phase switch
			{
				MenuPhase.Starter => MenuPhase.Main, 
				MenuPhase.Main => MenuPhase.Dessert, 
				MenuPhase.Dessert => MenuPhase.Complete, 
				MenuPhase.Complete => MenuPhase.Complete, 
				_ => MenuPhase.Complete, 
			};
		}
	}
}
