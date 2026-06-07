using System;
using GameCreator.Runtime.Common;
using UnityEngine.UI;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Deselect")]
	[Category("UI/On Deselect")]
	[Description("Executed when the UI element is deselected")]
	[Image(typeof(IconRadioOff), ColorTheme.Type.Red)]
	[Keywords(new string[] { "Mouse", "Choose", "Focus", "Pick", "Pointer" })]
	public class EventUIOnDeselect : Event
	{
		public override Type RequiresComponent => typeof(Selectable);

		protected internal override void OnDeselect(Trigger trigger)
		{
			base.OnDeselect(trigger);
			if (base.IsActive)
			{
				trigger.Execute(base.Self);
			}
		}
	}
}
