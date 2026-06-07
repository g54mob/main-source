using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.InventorySystem
{
	public class InventorySounds : MonoBehaviour
	{
		private readonly struct SoundRequest
		{
			public readonly int priority;

			public readonly AudioClip clip;

			public SoundRequest(int priority, AudioClip clip)
			{
				this.priority = priority;
				this.clip = clip;
			}

			public bool Equals(SoundRequest other)
			{
				if (priority == other.priority)
				{
					return object.Equals(clip, other.clip);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (priority * 397) ^ ((clip != null) ? clip.GetHashCode() : 0);
			}
		}

		[SerializeField]
		private AudioClip itemTakenOutSound;

		[SerializeField]
		private AudioClip itemPutInSound;

		[SerializeField]
		private AudioClip itemMovedSound;

		[SerializeField]
		private AudioClip itemsSwappedSound;

		[SerializeField]
		private AudioClip itemDroppedSound;

		[SerializeField]
		private AudioClip inventoryOpenedSound;

		[SerializeField]
		private AudioClip inventoryClosedSound;

		private HashSet<SoundRequest> hackRequests = new HashSet<SoundRequest>();

		private void Awake()
		{
			base.enabled = false;
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void OnEnable()
		{
			if (hackRequests.Count <= 0)
			{
				Debug.LogWarning("InventorySounds got enabled but has no sound requests. Disabling self.", this);
				base.enabled = false;
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged += OnInventoryStatusChanged;
				SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainerDataChanged += OnActiveContainerDataChanged;
				SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainerItemDropped += OnActiveContainerItemDropped;
			}
			else if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged -= OnInventoryStatusChanged;
				SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainerDataChanged -= OnActiveContainerDataChanged;
				SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainerItemDropped -= OnActiveContainerItemDropped;
			}
		}

		public void PlayInventoryOpenOrCloseSound(bool isOpen)
		{
			AudioClip audioClip = (isOpen ? inventoryOpenedSound : inventoryClosedSound);
			if (!(audioClip == null))
			{
				audioClip.Play2D();
			}
		}

		private void OnActiveContainerItemDropped(GameObject item)
		{
			RequestSound(1, itemDroppedSound);
		}

		private void OnActiveContainerDataChanged(AItemContainer container, int sourceIndex, int destinationIndex)
		{
			bool flag = sourceIndex != -1;
			bool flag2 = destinationIndex != -1;
			if (flag && flag2)
			{
				RequestSound(0, itemsSwappedSound);
			}
			else if (flag)
			{
				RequestSound(0, itemPutInSound);
			}
			else if (flag2)
			{
				RequestSound(0, itemPutInSound);
			}
		}

		private void OnInventoryStatusChanged(InventorySlotState primarySlotState, InventoryActionType primaryActionType, InventorySlotState secondarySlotState, InventoryActionType secondaryActionType)
		{
			if (primaryActionType.HasAnyIntFlag(InventoryActionType.Add))
			{
				AudioClip clip = TryGetMoneyClip(primarySlotState.item) ?? itemPutInSound;
				RequestSound(0, clip);
			}
			else if (secondaryActionType.HasAnyIntFlag(InventoryActionType.Move))
			{
				RequestSound(0, itemMovedSound);
			}
			else if (secondaryActionType.HasAnyIntFlag(InventoryActionType.Swap))
			{
				RequestSound(0, itemsSwappedSound);
			}
			else if (primaryActionType.HasAnyIntFlag(InventoryActionType.Equip))
			{
				RequestSound(1, itemTakenOutSound);
			}
			else if (primaryActionType.HasAnyIntFlag(InventoryActionType.Drop))
			{
				RequestSound(0, itemDroppedSound);
			}
			else if (primaryActionType.HasAnyIntFlag(InventoryActionType.Unequip) && SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer != null)
			{
				RequestSound(1, itemMovedSound);
			}
		}

		public AudioClip TryGetMoneyClip(GameObject item)
		{
			IMoney money = ((item != null) ? item.GetComponent<IMoney>() : null);
			if (money is Component && money.ShouldDestroyOnUse)
			{
				return money.AddToInventorySound;
			}
			return null;
		}

		private void RequestSound(int priority, AudioClip clip)
		{
			if (!(clip == null))
			{
				SoundRequest item = new SoundRequest(priority, clip);
				hackRequests.Add(item);
				base.enabled = true;
			}
		}

		private void LateUpdate()
		{
			int num = -1;
			SoundRequest soundRequest = new SoundRequest(-1, null);
			foreach (SoundRequest hackRequest in hackRequests)
			{
				int priority = hackRequest.priority;
				if (priority > num)
				{
					num = priority;
					soundRequest = hackRequest;
				}
			}
			if (num >= 0 && soundRequest.clip != null)
			{
				soundRequest.clip.Play2D(1f, playDuringPause: true);
			}
			hackRequests.Clear();
			base.enabled = false;
		}

		public void RequestAddSound()
		{
			RequestSound(1, itemPutInSound);
		}
	}
}
