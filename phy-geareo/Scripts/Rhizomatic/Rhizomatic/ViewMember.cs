using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public class ViewMember<T> : Member<T>, ICrewRenderer where T : View
	{
		public void Render(IViewable viewable)
		{
		}

		public void OpenView(IViewable viewable)
		{
		}

		public void CrewRender(object value)
		{
		}
	}
}
