using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Cattle : EntityMonoBehaviour
{
	public LeashPoints leashPoints;

	public ObjectNameTag nameTag;

	public bool isBaby;

	private Leash leash;

	private bool canBeLeashed;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	public List<ContainedObjectsBuffer> eatsFoods { get; private set; }

	public Vector3 GetLeashPoint()
	{
		return leashPoints.GetLeashPoint(GetAnimOrientationVec3());
	}

	public ContainedObjectsBuffer GetFood(int index)
	{
		return default(ContainedObjectsBuffer);
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		eatsFoods = new List<ContainedObjectsBuffer>();
		canBeLeashed = EntityUtility.HasComponentData<LeashedCD>(base.entity, base.world);
	}

	public override void OnFree()
	{
		OnPlayerLeft();
		base.OnFree();
		FreeLeash();
	}

	protected override void OnShow()
	{
		nameTag.gameObject.SetActive(value: true);
		base.OnShow();
	}

	protected override void OnHide()
	{
		nameTag.gameObject.SetActive(value: false);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateName();
		UpdateLeash();
	}

	public bool IsBreedingAvailable()
	{
		return EntityUtility.HasComponentData<BreedToggleCD>(base.entity, base.world);
	}

	public bool IsBreedingDisabled()
	{
		return EntityUtility.GetComponentData<BreedToggleCD>(base.entity, base.world).breedingDisabled;
	}

	private void UpdateName()
	{
		if (EntityUtility.IsComponentEnabled<EntityDestroyedCD>(base.entity, Manager.ecs.ClientWorld))
		{
			nameTag.gameObject.SetActive(value: false);
			return;
		}
		string text = GetName();
		if (text != null)
		{
			nameTag.gameObject.SetActive(value: true);
			nameTag.text.Render(text);
		}
		else
		{
			nameTag.gameObject.SetActive(value: false);
		}
	}

	private void UpdateLeash()
	{
		EntityMonoBehaviour entityMonoBehaviour = null;
		LeashedCD leashedCD = default(LeashedCD);
		if (canBeLeashed && !EntityUtility.IsComponentEnabled<EntityDestroyedCD>(base.entity, base.world))
		{
			leashedCD = EntityUtility.GetComponentData<LeashedCD>(base.entity, base.world);
			if (leashedCD.leashedToEntity != Entity.Null)
			{
				entityMonoBehaviour = Manager.memory.GetEntityMono(leashedCD.leashedToEntity);
			}
		}
		if (entityMonoBehaviour != null)
		{
			PlayerController playerController = entityMonoBehaviour as PlayerController;
			bool flag = true;
			if (!base.isHidden && playerController != null)
			{
				flag = playerController.srContainer.activeInHierarchy;
				XScaler.gameObject.SetActive(flag);
				if (!flag)
				{
					FreeLeash();
				}
			}
			if (leash == null && flag)
			{
				leash = Manager.memory.GetFreeComponent<Leash>();
				leash.leashOwner = entityMonoBehaviour;
				leash.leashTarget = this;
			}
		}
		else
		{
			if (!base.isHidden)
			{
				XScaler.gameObject.SetActive(value: true);
			}
			if (leash != null)
			{
				FreeLeash();
			}
		}
	}

	private void FreeLeash()
	{
		if (leash != null)
		{
			leash.Free();
			leash = null;
		}
	}

	public virtual void Interact()
	{
		Manager.main.player.SetActiveCattle(this);
		Manager.ui.OnCattleWindowOpen();
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		OnPlayerLeft();
	}

	public void OnPlayerLeft()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null) && !(player.activeCattle != this))
		{
			Manager.ui.HideAllInventoryAndCraftingUI();
			player.SetActiveCattle(null);
		}
	}

	public string GetName()
	{
		if (EntityUtility.HasComponentData<NameCD>(base.entity, base.world))
		{
			return EntityUtility.GetComponentData<NameCD>(base.entity, base.world).Value.ToString();
		}
		return null;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(base.transform.TransformPoint(leashPoints.behind), 0.05f);
		Gizmos.DrawSphere(base.transform.TransformPoint(leashPoints.infront), 0.05f);
		Gizmos.DrawSphere(base.transform.TransformPoint(leashPoints.left), 0.05f);
		Gizmos.DrawSphere(base.transform.TransformPoint(leashPoints.right), 0.05f);
	}
}
