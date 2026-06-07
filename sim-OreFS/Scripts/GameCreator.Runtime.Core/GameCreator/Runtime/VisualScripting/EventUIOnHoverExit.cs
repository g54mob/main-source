using System;
using GameCreator.Runtime.Common;
using UnityEngine.UI;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Hover Exit")]
	[Category("UI/On Hover Exit")]
	[Description("Executed when the pointer exits the hovered UI element")]
	[Image(typeof(IconUIHoverExit), ColorTheme.Type.Red)]
	[Keywords(new string[] { "Mouse", "Over", "Pointer" })]
	public class EventUIOnHoverExit : Event
	{
		public override Type RequiresComponent => typeof(Graphic);

		protected internal override void OnPointerExit(Trigger trigger)
		{
			base.OnPointerExit(trigger);
			if (base.IsActive)
			{
				trigger.Execute(base.Self);
			}
		}
	}
}
