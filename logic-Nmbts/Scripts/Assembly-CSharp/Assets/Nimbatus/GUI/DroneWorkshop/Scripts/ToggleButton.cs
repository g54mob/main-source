using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public abstract class ToggleButton : MonoBehaviour
	{
		public UITexture Image;

		public UILabel Label;

		public bool ResetToDefaultOnDisable;

		public Color SelectedColor;

		public Color NormalColor;

		public Color HoverColor;

		private bool _toggled;

		private bool _hover;

		private bool _startValue;

		public void OnDisable()
		{
			if (ResetToDefaultOnDisable)
			{
				Toggle(_startValue);
			}
		}

		public virtual void Start()
		{
			_toggled = IsToggled();
			_startValue = _toggled;
		}

		protected abstract bool IsToggled();

		public void OnClick()
		{
			_toggled = !_toggled;
			Toggle(_toggled);
		}

		protected abstract void Toggle(bool toggle);

		public void Update()
		{
			if (_toggled)
			{
				Image.color = SelectedColor;
				Label.color = SelectedColor;
			}
			else
			{
				Image.color = (_hover ? HoverColor : NormalColor);
				Label.color = NormalColor;
			}
		}

		protected virtual void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
