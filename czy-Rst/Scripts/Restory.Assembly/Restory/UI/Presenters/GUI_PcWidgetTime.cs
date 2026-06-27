using UnityEngine;

namespace Restory.UI.Presenters
{
	public sealed class GUI_PcWidgetTime : GUI_PcWidget
	{
		[SerializeField]
		private GameObject clockDisplay;

		public override void Activate()
		{
			clockDisplay.SetActive(value: true);
		}

		public override void Deactivate()
		{
			clockDisplay.SetActive(value: false);
		}
	}
}
