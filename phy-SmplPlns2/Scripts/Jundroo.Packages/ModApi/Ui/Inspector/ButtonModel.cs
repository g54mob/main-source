using System;

namespace ModApi.Ui.Inspector
{
	public abstract class ButtonModel : ItemModel, IValueChanged
	{
		public enum ButtonStyle
		{
			Default = 0,
			Primary = 1,
			Warning = 2
		}

		public ButtonStyle Style { get; set; }

		public event ValueChangedDelegate ValueChangedByUserInput;

		public ButtonModel(Action<ItemModel> updateAction = null)
		{
			base.UpdateAction = updateAction;
		}

		public virtual void OnClicked()
		{
		}

		public void RaiseValueChangedByUserInput(string name)
		{
			this.ValueChangedByUserInput?.Invoke(this, name, finished: true);
		}
	}
}
