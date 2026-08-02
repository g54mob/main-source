using System;
using Rhizomatic;
using Rhizomatic.MemberBinding;

namespace GRP
{
	public abstract class ProjectFramePageView : PageView
	{
		public virtual bool noDuplicate { get; }

		public virtual bool noClipboard { get; }

		protected override void Update()
		{
		}

		[Member]
		public void DeleteGlues()
		{
		}

		[Member]
		public void File()
		{
		}
	}
	[CustomMemberBinding]
	public abstract class ProjectFramePageView<T> : ProjectFramePageView where T : Page
	{
		public override Type viewableType => null;

		public new T viewable => null;

		public static void MemberBinder_CustomMemberBinding(MemberBindData bindData)
		{
		}
	}
}
