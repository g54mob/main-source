using System;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Global Name Variable Change")]
	[Category("Variables/On Global Name Variable Change")]
	[Description("Executed when the Global Name Variable is modified")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	public class EventOnVariableGlobalNameChange : Event
	{
		[SerializeField]
		private DetectorGlobalNameVariable m_Variable = new DetectorGlobalNameVariable();

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			m_Variable.StartListening(OnChange);
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			m_Variable.StopListening(OnChange);
		}

		private void OnChange(string name)
		{
			m_Trigger.Execute(base.Self);
		}
	}
}
