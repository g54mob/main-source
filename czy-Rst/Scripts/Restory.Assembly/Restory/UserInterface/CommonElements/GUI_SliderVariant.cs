using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_SliderVariant : GUI_BaseSlider
	{
		[SerializeField]
		private string valueFormat = "P0";

		[SerializeField]
		private Text valueText;

		protected override void Awake()
		{
			base.Awake();
		}

		protected override void UpdateVisuals()
		{
			base.UpdateVisuals();
			if (valueText != null)
			{
				valueText.text = base.Value.ToString(valueFormat);
			}
		}
	}
}
