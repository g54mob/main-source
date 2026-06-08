using System;
using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;

namespace GRP.Pages.NSProjectFrame
{
	public abstract class ToolItemView : View
	{
	}
	[CustomMemberBinding]
	public abstract class ToolItemView<T> : ToolItemView where T : Viewable
	{
		public override Type viewableType => null;

		public new T viewable => null;

		public static void MemberBinder_CustomMemberBinding(MemberBindData bindData)
		{
		}
	}
}
