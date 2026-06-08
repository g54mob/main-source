namespace Rhizomatic
{
	public class ContextContainer : IWithContext, IWithContextDispose
	{
		public Context context { get; set; }

		public virtual void OnContext()
		{
		}

		public virtual void OnContextDispose()
		{
		}
	}
}
