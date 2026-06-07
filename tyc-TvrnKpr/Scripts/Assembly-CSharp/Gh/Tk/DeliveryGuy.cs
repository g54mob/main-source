using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class DeliveryGuy : Actor
	{
		protected SpawnArcToPosition SpawnScript;

		[PersistenceOptIn]
		public List<GameItem> Items;

		protected List<GameItem> ItemsInProgress;

		public static HashSet<DeliveryGuy> AllDeliveryGuys;

		[PersistenceOptIn]
		protected int CurrentItemsSpawning;

		[PersistenceOptIn]
		public bool IsAllowedToMerge;

		public string SpawnBone;

		[PersistenceOptIn]
		public bool FirstItemFinishedSpawning;

		protected string _eventCameraVisual;

		[PersistenceOptIn]
		private bool _isEventCameraTriggered;

		[PersistenceOptIn]
		public string OriginShopName { get; set; }

		public override void Awake()
		{
		}

		public override void Init()
		{
		}

		private void OnAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		protected override void AddDefaultComponents()
		{
		}

		protected override Job GetNextJob()
		{
			return null;
		}

		public override void AddHighlight(Color? color = null)
		{
		}

		public override void RemoveHighlight()
		{
		}

		public override void Start()
		{
		}

		public void TriggerEventCamera()
		{
		}

		public void CreateItemAndSpawn(GameItem item)
		{
		}

		private void SpawnItem(GameItem item, GameObject wrapperVisual)
		{
		}

		protected virtual void OnItemSpawned()
		{
		}

		public override void OnDestroy()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}
	}
}
