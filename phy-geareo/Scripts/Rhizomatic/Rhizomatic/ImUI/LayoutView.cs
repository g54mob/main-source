namespace Rhizomatic.ImUI
{
	public class LayoutView : ImUIView<LayoutViewState>
	{
		public void _LoadView(ImUIView view)
		{
		}

		protected virtual void LoadView(ImUIView view)
		{
		}
	}
	public class LayoutView<T> : LayoutView where T : LayoutViewState
	{
		public new T state => null;

		protected sealed override void LoadState(LayoutViewState state)
		{
		}

		protected virtual void LoadState(T state)
		{
		}
	}
}
