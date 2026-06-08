using Rhizomatic.Reactive;

namespace GRP
{
	public abstract class PartViewable : Viewable, IListItemView<Part>
	{
		public Part part;

		public Part model => null;

		public void _Setup(Part part)
		{
		}

		protected virtual void Setup()
		{
		}
	}
	public class PartViewable<TPart> : PartViewable where TPart : Part
	{
		public new TPart part => null;
	}
}
