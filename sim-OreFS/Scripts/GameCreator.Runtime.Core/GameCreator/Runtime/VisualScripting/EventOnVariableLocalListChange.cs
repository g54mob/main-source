using System;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Local List Variable Change")]
	[Category("Variables/On Local List Variable Change")]
	[Description("Executed when the Local List Variable is modified")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class EventOnVariableLocalListChange : Event
	{
		[SerializeField]
		private DetectorLocalListVariable m_Variable = new DetectorLocalListVariable();

		[NonSerialized]
		private Args m_Args;

		protected internal override void OnAwake(Trigger trigger)
		{
			base.OnAwake(trigger);
			m_Args = new Args(trigger);
		}

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			m_Variable.StartListening(OnChange, m_Args);
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			m_Variable.StopListening(OnChange, m_Args);
		}

		private void OnChange()
		{
			m_Trigger.Execute(base.Self);
		}
	}
}
