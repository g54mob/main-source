using UnityEngine;

public class UnarmedInventoryItem : MonoBehaviour
{
	public HoldAnimationType holdAnimationType;

	public UseAnimationType useAnimationType;

	public bool isLeftHand;

	public bool isLockedRunningAnimation;

	public CollectableItemData itemData;

	[HideInInspector]
	public int useAnimationKey;

	[HideInInspector]
	public int holdAnimationKey;

	private void Awake()
	{
		InitializeAnimationKeys();
	}

	private void InitializeAnimationKeys()
	{
		switch (holdAnimationType)
		{
		case HoldAnimationType.HoldBottle:
			holdAnimationKey = AnimationKeys.HoldBottle;
			break;
		case HoldAnimationType.HoldFruit:
			holdAnimationKey = AnimationKeys.HoldFruit;
			break;
		case HoldAnimationType.HoldBigEat:
			holdAnimationKey = AnimationKeys.HoldBigEat;
			break;
		case HoldAnimationType.HoldGasLamp:
			holdAnimationKey = AnimationKeys.HoldGasLamp;
			break;
		case HoldAnimationType.HoldFishingRod:
			holdAnimationKey = AnimationKeys.HoldFishingRod;
			break;
		default:
			holdAnimationKey = 0;
			break;
		}
		switch (useAnimationType)
		{
		case UseAnimationType.BottleUse:
			useAnimationKey = AnimationKeys.BottleUse;
			break;
		case UseAnimationType.EatingFruit:
			useAnimationKey = AnimationKeys.EatingFruit;
			break;
		case UseAnimationType.EatingBig:
			useAnimationKey = AnimationKeys.EatingBig;
			break;
		case UseAnimationType.FishingThrow:
			useAnimationKey = AnimationKeys.FishingThrow;
			break;
		default:
			useAnimationKey = 0;
			break;
		}
	}
}
