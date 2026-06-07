using System;
using GameCreator.Runtime.Common;
using UnityEngine.UI;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Select")]
	[Category("UI/On Select")]
	[Description("Executed when the UI element is selected")]
	[Image(typeof(IconRadioOn), ColorTheme.Type.Green)]
	[Keywords(new string[] { "Mouse", "Choose", "Focus", "Pick", "Pointer" })]
	public class EventUIOnSelect : Event
	{
		public override Type RequiresComponent => typeof(Selectable);

		protected internal override void OnSelect(Trigger trigger)
		{
			base.OnSelect(trigger);
			if (base.IsActive)
			{
				trigger.Execute(base.Self);
			}
		}
	}
}
