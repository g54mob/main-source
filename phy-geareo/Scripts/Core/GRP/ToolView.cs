using System;
using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;

namespace GRP
{
	public abstract class ToolView : View
	{
		public ProjectView projectView { get; set; }
	}
	[CustomMemberBinding]
	public abstract class ToolView<T> : ToolView where T : ToolViewable
	{
		public Tool tool => null;

		public override Type viewableType => null;

		public new T viewable => null;

		public static void MemberBinder_CustomMemberBinding(MemberBindData bindData)
		{
		}
	}
}
