using System;
using UnityEngine;

public class CafeState : FSMState
{
	[SerializeField]
	private float stayAtCafeDurationMin = 120f;

	[SerializeField]
	private float stayAtCafeDurationMax = 120f;

	private CustomerCore customer;

	private CustomerUseableComponent seat;

	private Transform entryPoint;

	private CustomerUIInfo info;

	private bool exitSeat;

	private bool leave;

	private Vector3 colliderCenter = Vector3.zero;

	private float colliderCenterOffset = -0.5f;

	private float colliderRadiusDefault = 0.4f;

	private float colliderRadiusSitting = 0.25f;

	public override void AssignTarget()
	{
		customer = agent.GetComponent<CustomerCore>();
		info = customer.GetCustomerUIInfo();
		info.HideInfo();
		exitSeat = false;
		SetDuration(UnityEngine.Random.Range(stayAtCafeDurationMin, stayAtCafeDurationMax));
		seat = CafeShopManager.GetNextFreeSeat();
		if (seat == null)
		{
			routine.NextRoutine();
			info.PopNoSeat();
		}
		else
		{
			seat.Claim(customer);
			moveTarget = seat.transform;
		}
	}

	public override void OnArrive()
	{
		if (!CafeShopManager.IsCafeOpen())
		{
			TryPlaceCup();
			OnDismiss();
			return;
		}
		leave = false;
		customer.TriggerAnimationState("SitDown");
		entryPoint = new GameObject("entryPoint").transform;
		entryPoint.position = agent.transform.position;
		navAgent.enabled = false;
		colliderCenter = customer.GetComponent<CapsuleCollider>().center;
		colliderRadiusDefault = customer.GetComponent<CapsuleCollider>().radius;
		Action executeOnFinish = delegate
		{
			customer.GetComponent<CapsuleCollider>().center = new Vector3(colliderCenter.x, colliderCenter.y, colliderCenterOffset);
			customer.GetComponent<CapsuleCollider>().radius = colliderRadiusSitting;
		};
		TweenerManager.Tween(name + "_CustomerSeat", agent.transform, entryPoint, seat.GetPointTransform(), 0.5f, TweenerManager.GetDefaultEaseCurve(), executeOnFinish);
	}

	public override void OnUpdate()
	{
		agent.GetComponent<CustomerCore>().TrySpawnDirt();
		if (!CafeShopManager.IsCafeOpen() && !leave)
		{
			SetDuration(UnityEngine.Random.Range(3f, 10f));
			leave = true;
		}
	}

	public override void OnStateDurationOver()
	{
		if (entryPoint != null && !exitSeat)
		{
			TweenerManager.Tween("CustomerSeat", agent.transform, entryPoint, seat.GetPointTransform(), 0.5f, TweenerManager.GetDefaultEaseCurve(), delegate
			{
				UnityEngine.Object.Destroy(entryPoint.gameObject);
			});
			exitSeat = true;
		}
		customer.SetAnimationState("Coffee", state: false);
		customer.SetAnimationLayer(1, 0f);
		TryPlaceCup();
		navAgent.enabled = true;
		int rating = customer.GetRating().GetAverageRating();
		customer.GetComponent<CapsuleCollider>().center = colliderCenter;
		customer.GetComponent<CapsuleCollider>().radius = colliderRadiusDefault;
		TweenerManager.TweenTimeAction("LeaveChair", 1.2f, delegate
		{
			seat.Free();
			routine.NextRoutine();
			if (rating >= CustomerRating.GetGoodMin())
			{
				info.PopHappy();
			}
			else if (rating < CustomerRating.GetMehMax())
			{
				info.PopUnhappy();
			}
		});
	}

	private void TryPlaceCup()
	{
		if (customer.GetCupSocket().IsHoldingItem())
		{
			CupComponent component = agent.GetComponent<CustomerCore>().GetCupSocket().GetItemComponent()
				.GetComponent<CupComponent>();
			if (component != null)
			{
				component.MarkDirty();
			}
			TableComponent nearestTable = CafeShopManager.GetNearestTable(base.transform.position);
			if (nearestTable == null)
			{
				DropCup();
			}
			else
			{
				PlaceCup(nearestTable);
			}
		}
	}

	private void DropCup(TableComponent table = null)
	{
		Vector3 position = seat.transform.position + seat.transform.forward;
		if (table == null)
		{
			position.y = 0.1f;
		}
		else
		{
			position.y = table.GetSocketPlacementHeight();
		}
		position += new Vector3(UnityEngine.Random.Range(-0.2f, 0.2f), 0f, UnityEngine.Random.Range(-0.2f, 0.2f));
		ItemComponent itemComponent = customer.GetCupSocket().GetItemComponent();
		customer.GetCupSocket().Clear();
		Transform dropPoint = new GameObject("Drop Point").transform;
		dropPoint.position = position;
		itemComponent.transform.parent = table.transform;
		itemComponent.ActivateCollision();
		Action executeOnFinish = delegate
		{
			UnityEngine.Object.Destroy(dropPoint.gameObject);
		};
		TweenerManager.Tween("DropCup", itemComponent.transform, customer.GetCupSocket().transform, dropPoint, 0.1f, TweenerManager.GetDefaultEaseCurve(), executeOnFinish);
	}

	private void PlaceCup(TableComponent table)
	{
		ItemSocket nearestFreeSocket = table.GetNearestFreeSocket(base.transform.position);
		if (nearestFreeSocket == null)
		{
			DropCup(table);
			return;
		}
		ItemComponent itemComponent = customer.GetCupSocket().GetItemComponent();
		nearestFreeSocket.PushItem(itemComponent, itemComponent.transform.eulerAngles, reactivateCollision: true);
	}
}
