using System;

public interface IQuestObjective : ICloneable
{
	public interface IPersistentData
	{
		int ObjectiveHashCode { get; }

		bool TryRestore(IQuestObjective objective);
	}

	Quest Quest { get; }

	bool IsOptional { get; }

	bool IsHidden { get; }

	int DaysTimeLimit { get; }

	ushort UniqueID { get; }

	void OnValidate();

	bool IsCompleted();

	void Initialize();

	void Uninitialize();

	void SetActive(bool active);

	void InitializeDialogueTriggers();

	void UninitializeDialogueTriggers();

	void AssignUniqueID(ushort id);

	void SetOwningQuest(Quest owningQuest);

	void TriggerObjectivesGroupCompleted();

	void TriggerShownToPlayer();

	void TriggerTimeOut();

	bool TryFindDialogueTrigger(ushort uniqueID, out DialogueTrigger dialogueTrigger);

	IPersistentData GetPersistentData();
}
