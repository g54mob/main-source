namespace Restory.Data.GUIControllerElements
{
	public interface IGuiMouseTemplate : IGuiControllerTemplate
	{
		IGuiControllerTemplateAxisElement Horizontal { get; }

		IGuiControllerTemplateAxisElement Vertical { get; }

		IGuiControllerTemplateWheelElement Wheel { get; }

		IGuiControllerTemplateButtonElement LeftButton { get; }

		IGuiControllerTemplateButtonElement RightButton { get; }
	}
}
