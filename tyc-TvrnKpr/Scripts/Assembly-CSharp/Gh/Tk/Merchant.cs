using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public class Merchant : Actor
	{
		public static HashSet<Merchant> AllMerchants;

		[PersistenceOptIn]
		[JsonAlias("IsReadyForSelling", false)]
		private bool _isReadyForSelling;

		[PersistenceOptIn]
		private int _merchantSeed;

		[PersistenceOptIn]
		private string _merchantTemplateId;

		private MerchantData _merchantData;

		[PersistenceOptIn]
		private int _eventCameraEventId;

		[PersistenceOptIn]
		private List<UIController.PickableStock> _stock;

		private const int DEFAULT_MIN_STOCK = 1;

		private const int DEFAULT_MAX_STOCK = 5;

		private const int DRINK_MIN_STOCK = 1;

		private const int DRINK_MAX_STOCK = 3;

		[PersistenceOptIn]
		private int _amountOfItemsToSpawnAtOnce;

		private bool _isSpawning;

		private List<GameItem> _itemsInProgress;

		[PersistenceOptIn]
		private int _currentItemsSpawning;

		public string spawnPoint;

		public bool IsReadyForSelling
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MerchantData MerchantData => null;

		public static event EventHandler MerchantSpawned
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler MerchantDespawned
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler IsReadyForSellingChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		protected override void UpdateInternal()
		{
		}

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		public override void Init()
		{
		}

		public void Init(string merchantTemplateId)
		{
		}

		protected override void AddDefaultComponents()
		{
		}

		public void ShowEventCamera()
		{
		}

		public void KillEventCamera()
		{
		}

		public override PrimaryClickAction GetPrimaryClickAction()
		{
			return null;
		}

		protected override Job GetNextJob()
		{
			return null;
		}

		public void OpenMerchantDialog(bool isDeselectClick)
		{
		}

		private void FillSaleItems()
		{
		}

		private float GetMerchantCarryChance(GameItemTemplate item)
		{
			return 0f;
		}

		private void BuyItems(IEnumerable<Tuple<UIController.PickableStock, int>> items)
		{
		}

		private GameItem CreateItem(GameItemTemplate template)
		{
			return null;
		}

		private void StartSpawningItems()
		{
		}

		public void Spawn()
		{
		}

		public void CreateItemAndSpawn(GameItem item)
		{
		}

		private void SpawnItem(GameItem item, GameObject wrapperVisual)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public override void AddHighlight(Color? color = null)
		{
		}

		public override void RemoveHighlight()
		{
		}

		public override void OnDestroy()
		{
		}

		public override Vector3 GetStatusIconPosition(bool worldSpace = false)
		{
			return default(Vector3);
		}

		protected override void FillAnimationParameters()
		{
		}
	}
}
