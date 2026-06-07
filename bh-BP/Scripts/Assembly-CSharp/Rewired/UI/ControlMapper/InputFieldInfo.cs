using Rewired.Glyphs.UnityUI;
using UnityEngine;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class InputFieldInfo : UIElementInfo
	{
		private int _actionElementMapId;

		private AxisRange _axisRange;

		public UnityUIControllerElementGlyph glyphOrText { get; set; }

		public int actionId { get; set; }

		public AxisRange axisRange
		{
			get
			{
				return default(AxisRange);
			}
			set
			{
			}
		}

		public int actionElementMapId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ControllerType controllerType { get; set; }

		public int controllerId { get; set; }
	}
}
