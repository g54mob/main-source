public interface IModification
{
	ModificationStorageIdEnum ModificationStorageId { get; }

	string DisplayName { get; }

	string Description { get; }

	int ScrapCost { get; }

	string TargetName { get; }

	int MaxAllowed { get; }

	void SetTarget(object itemToReceiveMod);

	bool CanApplyModToTarget();

	void ApplyModToTarget();

	IModification CopyModification();
}
