using Aggro.Core;
using UnityEngine;

public class TipTapNotificationManager : AggroManagerBase<TipTapNotificationManager>
{
	public struct NotificationData
	{
		public string username;

		public Color playerColor;

		public TipTapObject tipTapObject;
	}

	public GameObject notificationPrefab;

	public Transform container;

	public void SpawnNotification(Entity sharerEntity, TipTapObject tiptap)
	{
		PoolableEntityReference entityFromPrefabPool = notificationPrefab.GetEntityFromPrefabPool();
		entityFromPrefabPool.entity.transform.SetParentAndReset(container);
		TipTapNotificationUI tipTapNotificationUI = entityFromPrefabPool.entity.GetObject<TipTapNotificationUI>();
		PlayerColorManager playerColorManager = sharerEntity.GetObject<PlayerColorManager>();
		tipTapNotificationUI.SetUp(new NotificationData
		{
			username = sharerEntity.GetObject<NamePlateHandler>().nameText,
			playerColor = playerColorManager.GetPlayerColor(ui: true),
			tipTapObject = tiptap
		});
	}
}
