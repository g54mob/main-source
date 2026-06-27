using UnityEngine;

namespace Restory.UI.Presenters
{
	public sealed class GUI_PcWidgets : MonoBehaviour
	{
		[SerializeField]
		private GUI_PcWidget[] widgets = new GUI_PcWidget[0];

		public void ActivateWidgets()
		{
			GUI_PcWidget[] array = widgets;
			foreach (GUI_PcWidget gUI_PcWidget in array)
			{
				if ((bool)gUI_PcWidget)
				{
					gUI_PcWidget.Activate();
				}
			}
		}

		public void DeactivateWidgets()
		{
			GUI_PcWidget[] array = widgets;
			foreach (GUI_PcWidget gUI_PcWidget in array)
			{
				if ((bool)gUI_PcWidget)
				{
					gUI_PcWidget.Deactivate();
				}
			}
		}
	}
}
