using ManagementScripts;
using UnityEngine;

namespace UIScripts.UIPanels
{
	public abstract class BibitePanel : UIPanel
	{
		internal GameObject bibite;

		public abstract BibitePanels PanelIndex { get; }

		public void SetTarget(GameObject newTarget)
		{
			Initialize();
			if (bibite != null)
			{
				ResetState();
			}
			bibite = newTarget;
			if (bibite != null)
			{
				FillPanel();
			}
		}

		protected override void OnPanelEscape()
		{
			GUIManager.Instance.ResetPanelToNone();
		}
	}
}
