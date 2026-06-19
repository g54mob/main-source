using UnityEngine;

public class AutoFeeder : ClickableObject
{
	public Transform dispenseTransform;

	public InventoryItem foodType;

	public GameObject bounceBoy;

	public int simultaneousFoodBits = 25;

	public GameObject feederControlGUIPrefab;

	public Animator dispenseAnimator;

	private string dispenseAnimation = "Dispense";

	private int minValue;

	private int maxValue = 25;

	private Segment bounceSegment;

	protected float bounceTime = 0.5f;

	protected Vector3 bounceScaleStart = new Vector3(1.25f, 0.25f, 1.25f);

	protected float expenseRate = 0.25f;

	private float currentExpenseTimer;

	protected float expelForce = 25f;

	protected float expelTorque = 25f;

	private bool isPaused;

	private string dispenseSound = "foodDispenser";

	protected DogHome dogHomeRef;

	protected Inchworm inchwormRef;

	protected ObjectRegistration regRef;

	protected InventoryManager invManagerRef;

	private void Start()
	{
		regRef = ObjectRegistration.GetRegistrationScript();
		dogHomeRef = regRef.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		inchwormRef = regRef.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		invManagerRef = regRef.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
	}

	private void Update()
	{
		if (currentExpenseTimer > 0f)
		{
			currentExpenseTimer -= Time.deltaTime;
		}
	}

	public void Pause()
	{
		isPaused = true;
	}

	public void Unpause()
	{
		isPaused = false;
	}

	protected override void OnClickInternal()
	{
		DispenseFoodIfNeeded();
	}

	public string GetFoodTypeResourcePath()
	{
		return invManagerRef.GetPathForItem(foodType);
	}

	public void UpdateAmount(int updateValue)
	{
		simultaneousFoodBits = Mathf.Clamp(simultaneousFoodBits + updateValue, minValue, maxValue);
	}

	public void UpdateItem(InventoryItem newItem)
	{
		foodType = newItem;
	}

	private void DispenseFoodIfNeeded()
	{
		if (!isPaused)
		{
			if (currentExpenseTimer > 0f)
			{
				currentExpenseTimer -= Time.deltaTime;
			}
			else
			{
				DispenseFood();
			}
		}
	}

	public void DispenseFood()
	{
		GameObject gameObject = dogHomeRef.TrySpawnItem(foodType, dispenseTransform.position, null, moveToGoodLocation: false);
		if (!(gameObject == null))
		{
			if (bounceSegment != null)
			{
				inchwormRef.CancelAndFinishEase(ref bounceSegment);
			}
			currentExpenseTimer = expenseRate;
			gameObject.transform.rotation = dispenseTransform.transform.rotation;
			Vector3 boxSize = gameObject.GetComponent<BoundingBoxComponent>().GetBoxSize();
			gameObject.transform.position += boxSize.y * -Vector3.up;
			gameObject.GetComponentInChildren<Rigidbody>().AddForce(expelForce * -Vector3.up, ForceMode.VelocityChange);
			gameObject.GetComponentInChildren<Rigidbody>().AddRelativeTorque(expelTorque * Random.rotation.eulerAngles, ForceMode.VelocityChange);
			if (bounceBoy != null)
			{
				bounceBoy.transform.localScale = bounceScaleStart;
				bounceSegment = inchwormRef.RequestEaseToScale(bounceBoy, Vector3.one, bounceTime, Inchworm.EaseStyle.ElasticOut, BounceCallback);
			}
			if (dispenseAnimator != null)
			{
				dispenseAnimator.Play(dispenseAnimation);
			}
			AudioController.Play(dispenseSound, dispenseTransform.position);
			if (TutorialController.IsTutorialActive())
			{
				TutorialController.OnFoodDispensed(gameObject);
			}
		}
	}

	private void BounceCallback()
	{
		bounceSegment = null;
	}
}
