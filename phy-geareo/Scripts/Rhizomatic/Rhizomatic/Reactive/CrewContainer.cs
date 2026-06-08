using System;
using System.Collections.Generic;
using Rhizomatic.MemberBinding;

namespace Rhizomatic.Reactive
{
	public class CrewContainer
	{
		public Dictionary<string, CrewMember> crewMembers;

		public void Open(IViewable viewable)
		{
		}

		public void Close(IViewable viewable)
		{
		}

		public void Render(IViewable viewable)
		{
		}

		private void Iterate(IViewable viewable, Action<CrewMember, object> action)
		{
		}

		public static void CustomMemberBinding(MemberBindData bindData, Type viewableType)
		{
		}
	}
}
