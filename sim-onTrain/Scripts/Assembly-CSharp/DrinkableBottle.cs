using UnityEngine;

public class DrinkableBottle : MonoBehaviour
{
	public bool isAnimatorTrigger;

	private TsPlayerAnimationController tsPlayerAnimationController;

	private TSPlayerStatusHolder statusHolder;

	[SerializeField]
	private float waterCapacity = 50f;

	[SerializeField]
	private float currentWater = 50f;

	[SerializeField]
	private float waterDrinkDecrease = 25f;

	[SerializeField]
	private float drinkingCompletionTime = 1f;

	private float drinkingTimer;

	private void Start()
	{
		statusHolder = GetComponentInParent<TSPlayerStatusHolder>();
		tsPlayerAnimationController = GetComponentInParent<TsPlayerAnimationController>();
	}

	private void Update()
	{
		if (currentWater <= 0f)
		{
			currentWater = 0f;
			return;
		}
		if (Input.GetMouseButtonDown(0))
		{
			tsPlayerAnimationController.DrinkWater();
		}
		else
		{
			if (Input.GetMouseButton(0))
			{
				drinkingTimer += Time.deltaTime;
				if (drinkingTimer > drinkingCompletionTime)
				{
					tsPlayerAnimationController.StopDrinking();
					statusHolder.DrinkWater(waterDrinkDecrease);
					drinkingTimer = 0f;
					currentWater -= waterDrinkDecrease;
				}
				return;
			}
			if (Input.GetMouseButtonUp(0))
			{
				tsPlayerAnimationController.StopDrinking();
			}
		}
		drinkingTimer = 0f;
	}

	private void OnDisable()
	{
		if (!(tsPlayerAnimationController == null))
		{
			tsPlayerAnimationController.StopDrinking();
		}
	}
}
