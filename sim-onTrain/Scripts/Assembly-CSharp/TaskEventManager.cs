using UnityEngine.Events;

public static class TaskEventManager
{
	public static UnityEvent<CollectableItemData, int> OnCollectableEarned = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent<CollectableItemData> OnResearchTaskCompleted = new UnityEvent<CollectableItemData>();

	public static UnityEvent<CollectableItemData, int> OnBuildTaskCompleted = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent<CollectableItemData, int> OnInteractTaskCompleted = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent<CollectableItemData, int> OnLootTaskCompleted = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent<string> OnReachSomewhereTaskCompleted = new UnityEvent<string>();

	public static UnityEvent<int> OnCombatTaskCompleted = new UnityEvent<int>();

	public static UnityEvent<CollectableItemData, int> OnCraftTaskCompleted = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent<CollectableItemData, int> OnPlaceObjectTaskCompleted = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent<CollectableItemData, int> OnBuildObjectTaskCompleted = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent<int> OnCollectDirtyWaterTaskCompleted = new UnityEvent<int>();

	public static UnityEvent<CollectableItemData, int> OnAddFuelOnWaterPurifierTaskCompleted = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent<int> OnCollectCleanWaterTaskCompleted = new UnityEvent<int>();

	public static UnityEvent<CollectableItemData, int> OnCookTaskCompleted = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent<CollectableItemData, int> OnCollectOreTaskCompleted = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent<CollectableItemData, int> OnMeltOreTaskCompleted = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent<CollectableItemData, int> OnCollectIngotTaskCompleted = new UnityEvent<CollectableItemData, int>();

	public static UnityEvent OnOpenBuildCanvasTaskCompleted = new UnityEvent();

	public static UnityEvent OnAddWaterToTrainTaskCompleted = new UnityEvent();

	public static UnityEvent OnAddFuelToTrainTaskCompleted = new UnityEvent();

	public static UnityEvent OnPressGasPedalTaskCompleted = new UnityEvent();

	public static UnityEvent OnReleaseBrakeTaskCompleted = new UnityEvent();

	public static UnityEvent OnMoveTheTrainTaskCompleted = new UnityEvent();
}
