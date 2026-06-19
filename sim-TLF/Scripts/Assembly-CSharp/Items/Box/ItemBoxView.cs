using System;
using System.Collections.Generic;
using AssembleSystem;
using AssembleSystem.FallenItems;
using AssembleSystem.Utils;
using Cysharp.Threading.Tasks;
using Data.Save;
using JSAM;
using Services.Missions;
using Services.Save;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Items.Box
{
	public class ItemBoxView : MonoBehaviour, IUsable, IInventoryManagable, ISmoothMovable, IMoveable
	{
		public bool Opened;

		public List<AssetReference> ContentRefs = new List<AssetReference>();

		[SerializeField]
		private ParticleSystem _openParticles;

		[SerializeField]
		private ParticleSystem _flashParticles;

		[Space(5f)]
		[SerializeField]
		private GameObject _openedBox;

		[SerializeField]
		private GameObject _closedBox;

		[SerializeField]
		private Collider _collider;

		[SerializeField]
		private PartConfig _itemConfig;

		[SerializeField]
		private float _upForce = 5f;

		[SerializeField]
		private float _partsDelay = 0.1f;

		[Tooltip("When true the box is tracked by the fall-rescue service and teleported back onto the dumpster if it drops below the fall threshold. World-spawned loot crates set this to false so they stay where they land instead of being yanked to the dumpster.")]
		[SerializeField]
		private bool _rescueWhenFallen = true;

		[Inject]
		private DiContainer _diContainer;

		[Inject]
		private MissionEventBus _missionEventBus;

		[Inject]
		private IFallenItemsService _fallenItemsService;

		private bool _interactable = true;

		string IInventoryManagable.ID
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		PartConfig IInventoryManagable.ItemConfig => _itemConfig;

		float ISmoothMovable.Smooth => 5f;

		public event Action OnBoxOpened;

		private void Start()
		{
			if (_openedBox != null && _closedBox != null)
			{
				_closedBox.SetActive(!Opened);
				_openedBox.SetActive(Opened);
			}
			OnBoxOpened += CheckForTutorialGoodsOpen;
			if (_rescueWhenFallen)
			{
				_fallenItemsService?.Register(this);
			}
		}

		private void OnDestroy()
		{
			_fallenItemsService?.Unregister(this);
		}

		public void SetRescueWhenFallen(bool value)
		{
			_rescueWhenFallen = value;
		}

		private void CheckForTutorialGoodsOpen()
		{
			_missionEventBus.Emit("interact", "collectGoods");
		}

		public void Init(List<AssetReference> contentRefs)
		{
			ContentRefs = contentRefs;
		}

		public void ApplyState(BoxSaveData data, List<AssetReference> contentRefs)
		{
			Opened = data.IsOpen;
			ContentRefs = contentRefs;
			if (Opened)
			{
				ApplyOpenVisuals();
			}
		}

		private void ApplyOpenVisuals()
		{
			if (_openedBox == null || _closedBox == null)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			_openedBox.gameObject.SetActive(value: true);
			_closedBox.gameObject.SetActive(value: false);
		}

		void IUsable.UnUse()
		{
		}

		public void SetInteractable(bool interactable)
		{
			_interactable = interactable;
		}

		void IUsable.Use()
		{
			if (_interactable && !Opened)
			{
				AudioManager.PlaySound(InteractionLibrarySounds.CrateUnbox);
				AudioManager.PlaySound(InteractionLibrarySounds.CrateUnboxAdd);
				ApplyOpenVisuals();
				Opened = true;
				SpawnContents().Forget();
				this.OnBoxOpened?.Invoke();
			}
		}

		private async UniTaskVoid SpawnContents()
		{
			_openParticles.Play();
			foreach (AssetReference assetRef in ContentRefs)
			{
				GameObject prefab = await assetRef.LoadAssetAsync<GameObject>();
				GameObject go = _diContainer.InstantiatePrefab(prefab, base.transform.position + Vector3.up * 0.5f, Quaternion.identity, null);
				string instanceId = Guid.NewGuid().ToString();
				SpawnedItemSaveInitializer.Init(go, instanceId, assetRef.AssetGUID, _diContainer);
				AudioManager.PlaySound(InteractionLibrarySounds.CrateItemJump);
				await UniTask.WaitForSeconds(_partsDelay);
			}
		}

		void IInventoryManagable.PickupItem()
		{
			UnityEngine.Object.Instantiate(_flashParticles, base.transform.position, Quaternion.identity);
		}

		void IInventoryManagable.RemoveItem()
		{
		}

		void IMoveable.Move(Vector3 targetPos)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, targetPos, ((ISmoothMovable)this).Smooth * Time.deltaTime);
		}
	}
}
