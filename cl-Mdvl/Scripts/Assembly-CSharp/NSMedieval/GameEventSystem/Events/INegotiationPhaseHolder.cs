using System;
using NSMedieval.Dialogs.Data;
using NSMedieval.State;

namespace NSMedieval.GameEventSystem.Events
{
	public interface INegotiationPhaseHolder
	{
		Action<NegotiationEndResult> NegotiationFinishedEvent { get; set; }

		HumanoidInstance Negotiator { get; set; }

		void FormatChatDialogContent(string dialogName, DialogContent dialogContent, CreatureBase chatInitiator, CreatureBase chatTarget);

		void OnNegotiationChatOptionChosen(string dialogName, int optionIndex, CreatureBase chatInitiator, CreatureBase chatTarget);

		bool TickShouldCancelNegotiations()
		{
			return false;
		}

		void OnNegotiatorLeaveMap();
	}
}
