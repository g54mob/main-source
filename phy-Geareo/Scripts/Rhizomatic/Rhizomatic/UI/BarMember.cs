using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;

namespace Rhizomatic.UI
{
	public class BarMember : Member<IBar>, ICrewRenderer
	{
		public float progress
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public void CrewRender(object v)
		{
		}
	}
}
