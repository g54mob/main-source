using KitchenData;

namespace Kitchen
{
	public abstract class GameViewSystemBase<T> : IncrementalViewSystemBase<T> where T : IViewData, IViewData.ICheckForChanges<T>
	{
		protected bool HasStatus(RestaurantStatus status)
		{
			return GetOrCreate<SGlobalStatusList>().Has(status);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
