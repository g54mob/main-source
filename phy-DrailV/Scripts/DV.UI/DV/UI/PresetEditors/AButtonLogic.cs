using DV.UIFramework;

namespace DV.UI.PresetEditors
{
	public abstract class AButtonLogic : NullCheckingMonoBehaviour
	{
		[NullCheck]
		public ButtonDV button;

		protected virtual void OnEnable()
		{
			button.Clicked += OnClick;
		}

		protected virtual void OnDisable()
		{
			button.Clicked -= OnClick;
		}

		protected abstract void OnClick(IClickable thisButton);
	}
}
