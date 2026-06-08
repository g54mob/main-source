namespace Rhizomatic.ImUI
{
	public abstract class ViewParam
	{
		public ImUIView view;

		public void Setup(ImUIView view)
		{
		}

		public abstract void Apply();

		public abstract void Clear();
	}
}
