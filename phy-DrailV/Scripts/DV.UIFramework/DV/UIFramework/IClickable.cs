namespace DV.UIFramework
{
	public interface IClickable : IHoverable
	{
		bool IsPressed { get; }

		event ClickDelegate Clicked;

		event PressChangedDelegate PressChanged;

		void Click();

		void Press();

		void Release();
	}
}
