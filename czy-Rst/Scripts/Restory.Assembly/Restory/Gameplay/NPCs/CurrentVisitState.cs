namespace Restory.Gameplay.NPCs
{
	public enum CurrentVisitState
	{
		NoVisitInProgress = 0,
		VisitWithInteraction_Starting = 10,
		VisitWithInteraction_WaitingForInteraction = 15,
		VisitWithInteraction_InteractionInProgress = 20,
		VisitWithInteraction_Ending = 30,
		VisitWithNoInteraction_Starting = 40,
		VisitWithNoInteraction_Ending = 50
	}
}
