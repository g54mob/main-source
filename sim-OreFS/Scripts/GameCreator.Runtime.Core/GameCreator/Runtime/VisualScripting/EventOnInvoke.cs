using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Invoke")]
	[Category("Lifecycle/On Invoke")]
	[Description("Executed only when calling its Invoke() method")]
	[Image(typeof(IconCode), ColorTheme.Type.TextNormal)]
	[Keywords(new string[] { "Script", "Manual" })]
	public class EventOnInvoke : Event
	{
		public void Invoke()
		{
			Invoke(base.Self);
		}

		public void Invoke(GameObject source)
		{
			if (base.IsActive)
			{
				m_Trigger.Execute(source);
			}
		}
	}
}
