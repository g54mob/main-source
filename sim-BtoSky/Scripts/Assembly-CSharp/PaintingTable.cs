using PaintIn3D;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class PaintingTable : Furniture
{
	private Rocket mountedRocket;

	[SerializeField]
	private Transform rocketMount;

	[SerializeField]
	private CinemachineCamera paintCam;

	private bool isUsing;

	private void Start()
	{
		GameManager.S.OnPaintingDone -= S_OnPaintingDone;
		GameManager.S.OnPaintingDone += S_OnPaintingDone;
	}

	private void OnDestroy()
	{
		GameManager.S.OnPaintingDone -= S_OnPaintingDone;
	}

	private void S_OnPaintingDone()
	{
		if (!isUsing)
		{
			return;
		}
		Object.Destroy(GameManager.S.player.GetComponent<CraftingController>());
		MeshColliderPos componentInChildren = mountedRocket.rocketBody.GetComponentInChildren<MeshColliderPos>();
		if (componentInChildren != null)
		{
			MeshCollider componentInChildren2 = componentInChildren.GetComponentInChildren<MeshCollider>();
			if (componentInChildren2 != null)
			{
				Object.Destroy(componentInChildren2);
				mountedRocket.GetComponentInChildren<CapsuleCollider>().enabled = true;
			}
		}
		mountedRocket.Interact();
		mountedRocket = null;
		paintCam.Priority = 0;
		GameManager.S.player.canControl = true;
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Player");
		Cursor.visible = false;
		isUsing = false;
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
				GameManager.S.player.AddComponent<CraftingController>().rocket = rocketMount.gameObject;
				Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
				Cursor.visible = true;
				GameManager.S.OffPlayerUI();
				GameManager.S.InteractingWithPaintingTable(component);
				paintCam.Priority = 2;
				GameManager.S.player.canControl = false;
				AudioManager.S.PlaySFX(AudioManager.S.craftingTableInteract);
				rocketMount.transform.localRotation = Quaternion.Euler(-90f, 180f, 0f);
				ReplaceColliderWithMeshCollider(mountedRocket);
				isUsing = true;
				StoreAllRocketStates(component);
				AudioManager.S.PlaySFX(AudioManager.S.craftingTableInteract);
			}
			else
			{
				GameManager.S.GrainRocketNeeded();
			}
		}
		else
		{
			GameManager.S.GrainRocketNeeded();
		}
	}

	public void StoreAllRocketStates(Rocket rocket)
	{
		CwPaintableMeshTexture[] componentsInChildren = rocket.GetComponentsInChildren<CwPaintableMeshTexture>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].StoreState();
		}
	}

	private void ReplaceColliderWithMeshCollider(Rocket mountedRocket)
	{
		if (!mountedRocket.rocketBody.scene.IsValid())
		{
			Debug.LogError("mountedRocket is a prefab asset, not a scene instance.");
			return;
		}
		MeshColliderPos componentInChildren = mountedRocket.rocketBody.gameObject.GetComponentInChildren<MeshColliderPos>();
		if (!(componentInChildren == null))
		{
			MeshFilter component = componentInChildren.GetComponent<MeshFilter>();
			component.gameObject.AddComponent<MeshCollider>().sharedMesh = component.sharedMesh;
			mountedRocket.rocketBody.GetComponent<CapsuleCollider>().enabled = false;
		}
	}
}
