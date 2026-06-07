using System;
using GameCreator.Runtime.Common;
using UnityEngine.UI;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Hover Enter")]
	[Category("UI/On Hover Enter")]
	[Description("Executed when the pointer hovers the UI element")]
	[Image(typeof(IconUIHoverEnter), ColorTheme.Type.Green)]
	[Keywords(new string[] { "Mouse", "Over", "Pointer" })]
	public class EventUIOnHoverEnter : Event
	{
		public override Type RequiresComponent => typeof(Graphic);

		protected internal override void OnPointerEnter(Trigger trigger)
		{
			base.OnPointerEnter(trigger);
			if (base.IsActive)
			{
				trigger.Execute(base.Self);
			}
		}
	}
}
