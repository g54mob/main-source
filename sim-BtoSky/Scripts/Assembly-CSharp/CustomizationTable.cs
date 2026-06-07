using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CustomizationTable : Furniture
{
	[SerializeField]
	private CinemachineCamera craftCam;

	[SerializeField]
	private GameObject rocketMount;

	private Rocket mountedRocket;

	private bool isUsing;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public override void Interact()
	{
		base.Interact();
		FirstPersonController player = GameManager.S.player;
		if (player.itemOnHand != null)
		{
			if (player.itemOnHand.TryGetComponent<Rocket>(out var component))
			{
				mountedRocket = component;
				component.transform.parent = rocketMount.transform;
				component.transform.localPosition = Vector3.zero;
				component.transform.localRotation = Quaternion.identity;
				component.transform.localPosition = -component.rocketVisualPos.localPosition;
				player.itemOnHand = null;
				Collider[] componentsInChildren = component.GetComponentsInChildren<Collider>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = true;
				}
				MeshCollider componentInChildren = component.rocketBody.GetComponentInChildren<MeshCollider>();
				if (componentInChildren != null)
				{
					componentInChildren.enabled = true;
					component.rocketBody.GetComponentInChildren<CapsuleCollider>().enabled = false;
				}
				GameManager.S.player.AddComponent<CustomizationController>().rocket = rocketMount;
				Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
				Cursor.visible = true;
				GameManager.S.InteractingWithCraftingTable(component);
				craftCam.Priority = 2;
				GameManager.S.player.canControl = false;
				AudioManager.S.PlaySFX(AudioManager.S.craftingTableInteract);
				rocketMount.transform.localRotation = Quaternion.Euler(-90f, 180f, 0f);
				isUsing = true;
			}
			else
			{
				AudioManager.S.PlaySFX(AudioManager.S.doorLocked);
			}
		}
		else
		{
			AudioManager.S.PlaySFX(AudioManager.S.doorLocked);
		}
	}
}
