using Aggro.Core;
using UnityEngine;

public class NotificationManagerUI : EntityBehaviourBase
{
	public GameObject shiftStartNotifPrefab;

	public GameObject shiftWonNotifPrefab;

	public GameObject shiftLostNotifPrefab;

	public GameObject orderIncorrectNotifPrefab;

	public GameObject organizationPeriodStartNotifPrefab;

	public GameObject transactionNotificaionPrefab;

	public GameObject valueLostPrefab;

	public GameObject playerJoinedNotifPrefab;

	public RectTransform pushNotificationContainer;

	public int testInt;

	protected override void OnEntityCreated()
	{
		base.eventManager.AddGlobalListener<EvOrganizationPeriodStart>(OnOrganizationStart);
		base.eventManager.AddGlobalListener<EvShiftStart>(OnShiftStart);
		base.eventManager.AddGlobalListener<EvIncorrectOrderSent>(OnIncorrectOrderSent);
		base.eventManager.AddGlobalListener<EvShiftWon>(OnShiftWon);
		base.eventManager.AddGlobalListener<EvShiftLost>(OnShiftLost);
		base.eventManager.AddGlobalListener<ShiftManager.EvMoneyTransaction>(OnMoneyTransaction);
		base.eventManager.AddGlobalListener<EvPlayerJoined>(OnPlayerJoined);
		base.eventManager.AddGlobalListener<EvPlayerLeft>(OnPlayerLeft);
	}

	protected override void OnEntityDestroyed()
	{
		base.eventManager.RemoveGlobalListener<EvOrganizationPeriodStart>(OnOrganizationStart);
		base.eventManager.RemoveGlobalListener<EvShiftStart>(OnShiftStart);
		base.eventManager.RemoveGlobalListener<EvIncorrectOrderSent>(OnIncorrectOrderSent);
		base.eventManager.RemoveGlobalListener<EvShiftWon>(OnShiftWon);
		base.eventManager.RemoveGlobalListener<EvShiftLost>(OnShiftLost);
		base.eventManager.RemoveGlobalListener<ShiftManager.EvMoneyTransaction>(OnMoneyTransaction);
		base.eventManager.RemoveGlobalListener<EvPlayerJoined>(OnPlayerJoined);
		base.eventManager.RemoveGlobalListener<EvPlayerLeft>(OnPlayerLeft);
	}

	private void OnPlayerJoined(EvPlayerJoined ev)
	{
		RunNotif(playerJoinedNotifPrefab, pushNotificationContainer).gameObject.GetComponent<PushNotificationUI>().text.text = ev.playerName + " has joined the game!";
	}

	private void OnPlayerLeft(EvPlayerLeft ev)
	{
		RunNotif(playerJoinedNotifPrefab, pushNotificationContainer).GetComponent<PushNotificationUI>().text.text = ev.playerName + " has left the game!";
	}

	private void OnMoneyTransaction(ShiftManager.EvMoneyTransaction evMoneyTransaction)
	{
		RunNotif(transactionNotificaionPrefab, base.transform).GetComponent<EntityBehaviour>().entity.GetObject<TransactionUI>().amount = evMoneyTransaction.amount;
	}

	private void OnShiftWon(EvShiftWon ev)
	{
		RunNotif(shiftWonNotifPrefab, base.transform).GetComponent<ShiftFinishedNotifUI>().SetUp(ev.shift);
	}

	private void OnShiftLost(EvShiftLost ev)
	{
		RunNotif(shiftLostNotifPrefab, base.transform).GetComponent<ShiftFinishedNotifUI>().SetUp(ev.shift);
	}

	private void OnOrganizationStart(EvOrganizationPeriodStart ev)
	{
		RunNotif(organizationPeriodStartNotifPrefab, base.transform);
	}

	private void OnIncorrectOrderSent(EvIncorrectOrderSent ev)
	{
		RunNotif(orderIncorrectNotifPrefab, base.transform);
	}

	private void OnShiftStart(EvShiftStart evShiftStart)
	{
		RunNotif(shiftStartNotifPrefab, base.transform);
	}

	public GameObject RunNotif(GameObject notif, Transform parent)
	{
		PoolableEntityReference entityFromPrefabPool = notif.GetEntityFromPrefabPool();
		entityFromPrefabPool.gameObject.transform.SetParent(parent, worldPositionStays: false);
		((RectTransform)entityFromPrefabPool.gameObject.transform).anchoredPosition = Vector2.zero;
		return entityFromPrefabPool.gameObject;
	}

	public void Test()
	{
		ShiftManager.EvMoneyTransaction ev = new ShiftManager.EvMoneyTransaction
		{
			amount = testInt
		};
		base.eventManager.QueueGlobalEvent(ev);
	}
}
