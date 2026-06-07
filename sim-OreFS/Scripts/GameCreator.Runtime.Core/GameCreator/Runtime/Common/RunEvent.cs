using System;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class RunEvent
	{
		[SerializeReference]
		private Event m_Event;

		[NonSerialized]
		private GameObject m_Template;

		public RunEvent()
		{
			m_Event = new EventOnStart();
		}

		public RunEvent(Event eventCall)
		{
			m_Event = eventCall;
		}

		public Trigger Start(string name, InstructionList instructionList)
		{
			if (m_Template == null)
			{
				m_Template = new GameObject
				{
					name = name,
					hideFlags = HideFlags.HideAndDontSave
				};
				m_Template.SetActive(value: false);
				m_Template.Add<Trigger>();
			}
			Trigger.Reconfigure(m_Template.Get<Trigger>(), m_Event, instructionList);
			GameObject gameObject = UnityEngine.Object.Instantiate(m_Template);
			gameObject.hideFlags = HideFlags.None;
			gameObject.SetActive(value: true);
			return gameObject.Get<Trigger>();
		}
	}
}
