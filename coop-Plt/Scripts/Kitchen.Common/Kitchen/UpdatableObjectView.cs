namespace Kitchen
{
	public abstract class UpdatableObjectView<T> : GenericObjectView, IUpdatableObject where T : IViewData
	{
		protected abstract void UpdateData(T data);

		public virtual void UpdateData(IViewData data)
		{
			if (data is T data2)
			{
				UpdateData(data2);
			}
		}
	}
}
