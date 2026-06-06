public interface IDialogueEvent
{
	bool ShouldTriggerOnDialogueRepeat => true;

	void TriggerEvent(Dialogue dialogue);
}
