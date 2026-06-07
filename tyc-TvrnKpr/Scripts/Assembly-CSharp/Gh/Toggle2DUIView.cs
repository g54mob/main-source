using UnityEngine.UI;

namespace Gh
{
	public class Toggle2DUIView : Interactable2DUIView
	{
		public Toggle.ToggleEvent onValueChanged;

		public bool IsOn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void SetIsOnWithoutNotify(bool value)
		{
		}

		protected override void OnClickedInternal()
		{
		}
	}
}
