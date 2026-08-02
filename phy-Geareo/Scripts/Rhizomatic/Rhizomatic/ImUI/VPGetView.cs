using System;

namespace Rhizomatic.ImUI
{
	public class VPGetView : ViewParam
	{
		public Action<ImUIView> getView;

		public VPGetView(Action<ImUIView> getView)
		{
		}

		public override void Apply()
		{
		}

		public override void Clear()
		{
		}
	}
}
