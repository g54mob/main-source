namespace Kitchen
{
	public interface ISpecificViewData : IViewData, IViewResponseData
	{
		IUpdatableObject GetRelevantSubview(IObjectView view);
	}
}
