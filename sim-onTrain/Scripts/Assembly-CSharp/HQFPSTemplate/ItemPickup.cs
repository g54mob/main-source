using HQFPSTemplate.Items;
using UnityEngine;

namespace HQFPSTemplate
{
	public class ItemPickup : InteractiveObject
	{
		public enum PickUpMethod
		{
			TriggerBased = 0,
			InteractionBased = 1
		}

		[BHeader("Item", true, order = 100)]
		[SerializeField]
		[DatabaseItem]
		protected string m_Item = string.Empty;

		[SerializeField]
		[Range(0f, 100f)]
		protected int m_ItemCount = 1;

		[SerializeField]
		[Tooltip("In what container of the Player will the picked up item go")]
		protected ItemContainerFlags m_TargetContainers = ItemContainerFlags.Storage;

		[BHeader("Pick Up", true, order = 2)]
		[SerializeField]
		protected PickUpMethod m_PickUpMethod = PickUpMethod.InteractionBased;

		[SerializeField]
		[ShowIf("m_PickUpMethod", 0, 10f)]
		[Tooltip("The radius of the auto-created trigger.")]
		protected float m_TriggerRadius = 0.5f;

		[Space]
		[SerializeField]
		protected Color m_BaseMessageColor = new Color(1f, 1f, 1f, 0.678f);

		[SerializeField]
		protected Color m_ItemCountColor = new Color(0.976f, 0.6f, 0.129f, 1f);

		[SerializeField]
		protected Color m_InventoryFullColor = Color.red;

		protected Item m_ItemInstance;

		private string m_InitialInteractionText;

		public Item ItemInstance => m_ItemInstance;

		public override void OnInteractionEnd(Humanoid humanoid)
		{
			TryPickUp(humanoid, InteractionProgress.Get());
			base.OnInteractionEnd(humanoid);
		}

		public void SetItem(Item item)
		{
			m_ItemInstance = item;
			if (m_ItemInstance != null)
			{
				m_Item = m_ItemInstance.Name;
				SetInteractionText(item);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			m_InitialInteractionText = InteractionText.Val;
			if (m_PickUpMethod != PickUpMethod.InteractionBased)
			{
				base.InteractionEnabled = false;
			}
			if (ItemDatabase.TryGetItemByName(m_Item, out var itemInfo))
			{
				m_ItemInstance = new Item(itemInfo, m_ItemCount);
				if (m_PickUpMethod == PickUpMethod.TriggerBased)
				{
					SphereCollider sphereCollider = base.gameObject.AddComponent<SphereCollider>();
					sphereCollider.isTrigger = true;
					sphereCollider.radius = m_TriggerRadius;
				}
				if (m_ItemInstance != null)
				{
					SetInteractionText(m_ItemInstance);
				}
			}
			else
			{
				base.InteractionEnabled = false;
			}
		}

		protected virtual void TryPickUp(Humanoid humanoid, float interactProgress)
		{
			if (m_ItemInstance != null)
			{
				if (humanoid.Inventory.AddItem(m_ItemInstance, m_TargetContainers))
				{
					if (m_ItemInstance.Info.StackSize > 1)
					{
						Singleton<UI_MessageDisplayer>.Instance.PushMessage($"Picked up <color={ColorUtils.ColorToHex(m_ItemCountColor)}>{m_ItemInstance.Name}</color> x {m_ItemInstance.CurrentStackSize}", m_BaseMessageColor);
					}
					else
					{
						Singleton<UI_MessageDisplayer>.Instance.PushMessage($"Picked up <color={ColorUtils.ColorToHex(m_ItemCountColor)}>{m_ItemInstance.Name}</color>", m_BaseMessageColor);
					}
					Object.Destroy(base.gameObject);
				}
				else
				{
					Singleton<UI_MessageDisplayer>.Instance.PushMessage($"<color={ColorUtils.ColorToHex(m_InventoryFullColor)}>Inventory Full</color>", m_BaseMessageColor);
				}
			}
			else
			{
				Debug.LogError("Item Instance is null, can't pick up anything.");
			}
		}

		private void SetInteractionText(Item item)
		{
			if (item.CurrentStackSize < 2)
			{
				InteractionText.Set(string.Format(m_InitialInteractionText, item.Name.ToUpper()));
			}
			else
			{
				InteractionText.Set(string.Format(m_InitialInteractionText + " x " + item.CurrentStackSize, item.Name.ToUpper()));
			}
		}

		private void OnTriggerEnter(Collider col)
		{
			if (m_PickUpMethod == PickUpMethod.TriggerBased && col.TryGetComponent<Humanoid>(out var component))
			{
				TryPickUp(component, 0f);
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (m_PickUpMethod == PickUpMethod.TriggerBased)
			{
				Color color = Gizmos.color;
				Gizmos.color = new Color(0.2f, 1f, 0.3f, 0.2f);
				Gizmos.DrawSphere(base.transform.position, m_TriggerRadius);
				Gizmos.color = color;
			}
		}
	}
}
