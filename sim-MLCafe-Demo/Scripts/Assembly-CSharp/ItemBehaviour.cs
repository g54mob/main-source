using System;

[Serializable]
public class ItemBehaviour
{
	public enum BehaviourType
	{
		Consumable = 0,
		Placeable = 1,
		Resource = 2,
		CraftedResource = 3,
		GridPlaceable = 4,
		Buildable = 5
	}

	public BehaviourType behaviourType;

	private static ItemBehaviour[] behaviours = new ItemBehaviour[5]
	{
		new ConsumableItem(),
		new PlaceableItem(),
		new ResourceItem(),
		new GridPlaceableItem(),
		new BuildableItem()
	};

	public static T GetBehaviourAs<T>(BehaviourType behaviourType) where T : ItemBehaviour
	{
		return (T)behaviours[(int)behaviourType];
	}

	public static IItemBehavior GetBehaviourAsIBehaviour(BehaviourType behaviourType)
	{
		return (IItemBehavior)behaviours[(int)behaviourType];
	}
}
