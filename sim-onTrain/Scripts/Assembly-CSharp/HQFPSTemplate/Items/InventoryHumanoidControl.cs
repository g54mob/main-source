using System.Collections;
using UnityEngine;

namespace HQFPSTemplate.Items
{
	[RequireComponent(typeof(Inventory))]
	public class InventoryHumanoidControl : HumanoidComponent
	{
		[SerializeField]
		private LayerMask m_WallsLayer;

		[SerializeField]
		private bool m_DropItemsOnDeath = true;

		[Space]
		[SerializeField]
		private Vector3 m_DropOffset = new Vector3(0f, 0f, 0.8f);

		[SerializeField]
		[Range(0.01f, 1f)]
		private float m_CrouchHeightDropMod = 0.5f;

		[SerializeField]
		private float m_DropAngularFactor = 150f;

		[SerializeField]
		private float m_DropSpeed = 8f;

		[Space]
		[SerializeField]
		[Group]
		private SoundPlayer m_DropSounds;

		private Inventory m_Inventory;

		public override void OnEntityStart()
		{
			m_Inventory = GetComponent<Inventory>();
			base.Humanoid.DropItem.SetTryer(TryDropItem);
			base.Entity.Death.AddListener(OnEntityDeath);
		}

		public bool TryDropItem(Item item)
		{
			if (item != null && item.Info.Pickup != null && base.Humanoid.DropItem.LastExecutionTime + 0.5f < Time.time && base.Humanoid.EquipItem.LastExecutionTime + 0.5f < Time.time && m_Inventory.RemoveItem(item))
			{
				float heightDropMultiplier = 1f;
				if (base.Humanoid.Crouch.Active)
				{
					heightDropMultiplier = m_CrouchHeightDropMod;
				}
				StartCoroutine(C_Drop(item, heightDropMultiplier));
				return true;
			}
			return false;
		}

		private IEnumerator C_Drop(Item item, float heightDropMultiplier)
		{
			if (item == null)
			{
				yield return null;
			}
			bool flag = false;
			Vector3 position;
			Quaternion rotation;
			if (Physics.Raycast(base.transform.position, base.transform.InverseTransformDirection(Vector3.forward) * 1.5f, m_DropOffset.z, m_WallsLayer))
			{
				position = base.transform.position + base.transform.TransformVector(new Vector3(0f, m_DropOffset.y * heightDropMultiplier, -0.2f));
				rotation = Quaternion.LookRotation(base.Entity.LookDirection.Get());
				flag = true;
			}
			else
			{
				position = base.transform.position + base.transform.TransformVector(new Vector3(m_DropOffset.x, m_DropOffset.y * heightDropMultiplier, m_DropOffset.z));
				rotation = Random.rotationUniform;
			}
			GameObject obj = Object.Instantiate(item.Info.Pickup, position, rotation);
			Rigidbody component = obj.GetComponent<Rigidbody>();
			Collider component2 = obj.GetComponent<Collider>();
			if (component != null)
			{
				Physics.IgnoreCollision(base.Entity.GetComponent<Collider>(), component2);
				component.isKinematic = false;
				if (component != null && !flag)
				{
					component.AddTorque(Random.rotation.eulerAngles * m_DropAngularFactor);
					component.AddForce(base.Entity.LookDirection.Get() * m_DropSpeed, ForceMode.VelocityChange);
				}
			}
			m_DropSounds.Play2D();
			ItemPickup component3 = obj.GetComponent<ItemPickup>();
			if (component3 != null)
			{
				component3.SetItem(item);
			}
		}

		private void OnEntityDeath()
		{
			if (!m_DropItemsOnDeath)
			{
				return;
			}
			for (int i = 0; i < m_Inventory.Containers.Count; i++)
			{
				for (int j = 0; j < m_Inventory.Containers[i].Slots.Length; j++)
				{
					ItemSlot itemSlot = m_Inventory.Containers[i].Slots[j];
					if ((bool)itemSlot.Item)
					{
						TryDropItem(itemSlot.Item);
						itemSlot.SetItem(null);
					}
				}
			}
		}
	}
}
