using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class TriggerableRadioMessage : ScenarioTriggerableBase
	{
		[Header("Radio Message")]
		[SerializeField]
		[Tooltip("The radio message that will be triggered")]
		private RadioMessageProperties _radioMessage;

		protected override bool Trigger(AgentDescriptor actor = null)
		{
			RadioMessageEvent.DispatchReceived(new RadioMessage(_radioMessage));
			return true;
		}
	}
}
