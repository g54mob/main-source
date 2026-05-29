namespace Rewired.UI.ControlMapper
{
	public class InputFieldInfo : UIElementInfo
	{
		public int actionId { get; set; }

		public AxisRange axisRange { get; set; }

		public int actionElementMapId { get; set; }

		public ControllerType controllerType { get; set; }

		public int controllerId { get; set; }
	}
}
