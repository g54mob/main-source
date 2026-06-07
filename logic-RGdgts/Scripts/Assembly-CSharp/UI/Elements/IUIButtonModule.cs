namespace UI.Elements
{
	public interface IUIButtonModule
	{
		void Init(UIButton uibutton);

		void ResetButton();

		void OnSelected();

		void OnUnselected();

		void OnEnabled();

		void OnDisabled();
	}
}
