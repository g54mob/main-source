using System;
using System.Collections.Generic;

namespace Gh.Tk.UI
{
	public class TraitsContainer3DUIView : Container3DUIView
	{
		public bool showStick;

		private List<Action> _onHiddenCleanUpActions;

		public void UpdateAiComponentVisualInfos(GameObjectX gox)
		{
		}

		public void UpdateAiComponentVisualInfos(GameItem gameItem)
		{
		}

		public void UpdateAiComponentVisualInfos(IEnumerable<IAiComponentVisualInfo> behaviorVisualInfos)
		{
		}

		public override void Clear()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void CallCleanUpActions()
		{
		}

		private void OnHiddenChanged(object sender, EventArgs<bool> e)
		{
		}
	}
}
