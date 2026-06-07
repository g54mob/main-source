using TMPro;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class RangeMinSlider : Slider
	{
		public RangeMaxSlider maxSlider;

		public TextMeshProUGUI label;

		public string numberFormat;

		protected override void Set(float input, bool sendCallback)
		{
		}

		public void Refresh(float input)
		{
		}
	}
}
