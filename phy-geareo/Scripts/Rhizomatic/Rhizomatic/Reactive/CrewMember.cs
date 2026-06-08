using System;
using Rhizomatic.MemberBinding;

namespace Rhizomatic.Reactive
{
	public class CrewMember
	{
		public Member member;

		public ICrewRenderer renderer;

		public ICrewView view;

		public Func<object, object> getValue;

		public Func<object, object[]> call;

		public void Render(object value)
		{
		}

		public void Open(State state)
		{
		}

		public void Close(State state)
		{
		}
	}
}
