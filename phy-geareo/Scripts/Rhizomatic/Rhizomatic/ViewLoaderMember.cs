using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public class ViewLoaderMember<T> : Member<T>, ICrewRenderer where T : ViewLoader
	{
		public void Open(IViewable viewable)
		{
		}

		public virtual void CrewRender(object value)
		{
		}
	}
	public class ViewLoaderMember : ViewLoaderMember<ViewLoader>
	{
	}
}
