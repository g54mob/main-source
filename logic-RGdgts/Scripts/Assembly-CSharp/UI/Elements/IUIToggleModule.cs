namespace UI.Elements
{
	public interface IUIToggleModule
	{
		void Init(UIToggle uitoggle);

		void ResetToggle();

		void OnEnabled();

		void OnDisabled();
	}
}
