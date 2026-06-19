using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class Portal : EntityMonoBehaviour
{
	[Serializable]
	public class LoadPointSpriteRendererPair
	{
		public SpriteRenderer point1;

		public SpriteRenderer point2;
	}

	public Transform spawnLocation;

	internal bool wasActivePreviousFrame;

	public SpriteRenderer sr;

	public SpriteRenderer portalEffectSR;

	public List<LoadPointSpriteRendererPair> loadPoints;

	private static readonly int LoadingMul = Shader.PropertyToID("_loadingMul");

	private static readonly int EmissiveStrengthMul = Shader.PropertyToID("_emissiveStrengthMul");

	public virtual bool isActivated => base.objectData.amount >= 600;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if ((wasActivePreviousFrame = isActivated) && animator != null)
		{
			animator.SetTrigger(-601574123);
		}
	}

	public void Use()
	{
		if (!base.entityExist)
		{
			return;
		}
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return;
		}
		int num = 0;
		using EntityQuery entityQuery = base.world.EntityManager.CreateEntityQuery(typeof(MapMarkerCD));
		using NativeArray<MapMarkerCD> nativeArray = entityQuery.ToComponentDataArray<MapMarkerCD>(Allocator.Temp);
		for (int i = 0; i < nativeArray.Length; i++)
		{
			if (nativeArray[i].mapMarkerType == MapMarkerType.Portal || nativeArray[i].mapMarkerType == MapMarkerType.Waypoint)
			{
				num++;
			}
		}
		if (num <= 1)
		{
			Emote.SpawnEmoteText(player.center, Emote.EmoteType.NoOtherPortals);
			return;
		}
		if (!isActivated)
		{
			Emote.SpawnEmoteText(player.center, Emote.EmoteType.NotFullyCharged);
			return;
		}
		player.currentPortal = this;
		if (!Manager.ui.isShowingMap)
		{
			Manager.ui.OnMapToggle();
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		PlayerController player = Manager.main.player;
		if (!(player == null))
		{
			if (!Manager.ui.isShowingMap && player.currentPortal == this)
			{
				player.currentPortal = null;
			}
			UpdateVisuals();
		}
	}

	protected virtual void UpdateVisuals()
	{
		bool flag = isActivated;
		float value = (flag ? 0f : 1f);
		sr.material.SetFloat(LoadingMul, value);
		float value2 = (flag ? 1f : 0f);
		sr.material.SetFloat(EmissiveStrengthMul, value2);
		if (portalEffectSR.gameObject.activeSelf != flag)
		{
			portalEffectSR.gameObject.SetActive(flag);
		}
		float num = math.clamp((float)base.objectData.amount / 600f, 0f, 1f);
		for (int i = 0; i < loadPoints.Count; i++)
		{
			bool active = (float)(i + 1) / (float)loadPoints.Count <= num;
			if (loadPoints[i].point1 != null)
			{
				loadPoints[i].point1.gameObject.SetActive(active);
			}
			if (loadPoints[i].point2 != null)
			{
				loadPoints[i].point2.gameObject.SetActive(active);
			}
		}
		if (!wasActivePreviousFrame && flag)
		{
			wasActivePreviousFrame = flag;
			if (animator != null)
			{
				animator.SetTrigger(2039883312);
			}
		}
	}

	public void OnLeavePortal()
	{
		PlayerController player = Manager.main.player;
		if (player != null && player.currentPortal == this)
		{
			player.currentPortal = null;
			if (Manager.ui.isShowingMap)
			{
				Manager.ui.OnMapToggle();
			}
		}
	}

	public void TeleportEffects()
	{
		EntityUtility.PlayEffectEventClient(new EffectEventCD
		{
			entity = base.entity,
			effectID = EffectID.PortalTeleport
		});
	}

	public void PlayLocalTeleportEffects()
	{
		if (animator != null)
		{
			animator.SetTrigger(-1518581387);
		}
	}
}
