using System;
using Rhizomatic;
using Rhizomatic.ImUI;

namespace GRP
{
	public class SettingsPageView : PageView<SettingsPage>
	{
		public ImUIManager imUI;

		protected override void OnViewCreated()
		{
		}

		protected override void OnViewDestroyed()
		{
		}

		private T Row<T>(ImUIBuilder ui, string label, T defaultValue, Func<ViewParam[], T> render)
		{
			return default(T);
		}

		protected override void OnRender()
		{
		}
	}
}
