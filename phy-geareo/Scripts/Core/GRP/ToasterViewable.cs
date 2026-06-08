using Rhizomatic;
using Rhizomatic.Reactive;

namespace GRP
{
	public class ToasterViewable : Viewable
	{
		[ListLoaderCrew]
		public StateList<ToasterItemViewable> items;

		public void Toast(string message)
		{
		}

		public void Toast(string message, float duration)
		{
		}

		public void Tick()
		{
		}
	}
}
