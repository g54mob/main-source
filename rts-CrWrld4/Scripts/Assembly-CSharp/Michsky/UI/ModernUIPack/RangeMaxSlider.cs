using TMPro;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class RangeMaxSlider : Slider
	{
		public RangeMinSlider minSlider;

		public TextMeshProUGUI label;

		public string numberFormat;

		public float realValue;

		private bool assignedRealValue;

		protected override void Start()
		{
		}

		protected override void Set(float input, bool sendCallback)
		{
		}

		public void Refresh(float input)
		{
		}
	}
}
