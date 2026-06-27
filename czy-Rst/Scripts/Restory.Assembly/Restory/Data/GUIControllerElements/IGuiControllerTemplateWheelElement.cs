namespace Restory.Data.GUIControllerElements
{
	public interface IGuiControllerTemplateWheelElement : IGuiControllerTemplateElement
	{
		IGuiControllerTemplateAxisElement Horizontal { get; }

		IGuiControllerTemplateAxisElement Vertical { get; }

		IGuiControllerTemplateButtonElement Press { get; }
	}
}
