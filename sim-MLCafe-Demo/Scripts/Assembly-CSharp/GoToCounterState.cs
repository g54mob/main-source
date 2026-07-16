using UnityEngine;

public class GoToCounterState : FSMState
{
	[SerializeField]
	private WaitForServiceState waitForService;

	private bool tooExpensive;

	private CustomerCore customer;

	private ProductListingElement productElement;

	public override void AssignTarget()
	{
		customer = agent.GetComponent<CustomerCore>();
		productElement = ProductManager.GetSellingProduct(customer.GetCustomerNeeds().sellingProductId);
		if (productElement == null)
		{
			customer.Dismiss();
			return;
		}
		int basePrice = productElement.basePrice;
		int num = productElement.priceRating.maxPrice * 2;
		if (basePrice > num)
		{
			tooExpensive = true;
			moveTarget = CafeShopManager.GetEntrancePointInside();
			return;
		}
		ServiceCounterComponent nextFreeServiceCounter = CafeShopManager.GetNextFreeServiceCounter();
		if (nextFreeServiceCounter == null || !nextFreeServiceCounter.HasFreeQuelinePoint())
		{
			routine.ChangeRoutineTo(routine.manager.dismissRoutine);
			return;
		}
		QuelinePoint quelinePoint = nextFreeServiceCounter.GetLastQuelinePoint(agent.transform);
		if (quelinePoint.IsTaken())
		{
			ReEnterState();
			return;
		}
		QuelinePoint nextBestPoint = nextFreeServiceCounter.GetNextBestPoint(quelinePoint);
		if (nextBestPoint != null)
		{
			quelinePoint = nextBestPoint;
		}
		quelinePoint.BookPoint(agent.transform);
		moveTarget = quelinePoint.GetPoint();
		waitForService.assignedCounter = nextFreeServiceCounter;
		waitForService.assignedPoint = quelinePoint;
	}

	public override void OnArrive()
	{
		if (tooExpensive)
		{
			customer.GetCustomerUIInfo().PopTooExpensive(2f, delegate
			{
				routine.ChangeRoutineTo(routine.manager.dismissRoutine);
			});
			customer.GetRating().product = 64;
			customer.GetRating().service = 96;
			customer.GetRating().cleanness = CustomerManager.GetCleanupRating();
			DialogSequence dialogSequence = DialogManager.GetCustomerDialogReactions().Find((DialogSequence x) => x.IsTag("TooExpensiveToEnter"));
			string text = PopupMessageManager.GetHighlightBegin() + productElement.productName + PopupMessageManager.GetHighlightEnd() + dialogSequence.GetRandomDialog();
			DialogSequenceManager.PlayDialogSequence(new Dialog(customer.GetNameTag(), new string[1] { text }, dialogSequence.sound, autoProceed: true, isLocalized: true), customer.GetCustomerUIInfo().GetLocalDialogBoxComponent());
		}
		else
		{
			Vector3 vector = waitForService.assignedCounter.transform.position - navAgent.transform.position;
			vector.Normalize();
			vector = new Vector3(vector.x, 0f, vector.z);
			Quaternion rotation = navAgent.transform.rotation;
			TweenerManager.TweenRotation("RotateToCounter", navAgent.transform, rotation, Quaternion.LookRotation(vector, Vector3.up), 1f, TweenerManager.GetDefaultEaseCurve());
			routine.ChangeState(waitForService);
		}
	}

	public override void OnUpdate()
	{
	}
}
