using System.Collections.Generic;
using Pug.RP;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using UnityEngine;

public class ElectricalDoor : EntityMonoBehaviour
{
	private float openValue;

	private static readonly int OpenValue = Animator.StringToHash("openValue");

	public GameObject horizontalRenderer;

	public GameObject verticalRenderer;

	private int activeVariation = -1;

	public List<MeshRenderer> shadowRenderers;

	public override void OnOccupied()
	{
		base.OnOccupied();
		openValue = 0f;
	}

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 34, TileType.thinWall, 0);
		for (int i = 41; i < 52; i++)
		{
			Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), i, TileType.thinWall, 0);
		}
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.thinWall);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateGraphics();
		if (openValue > 0f && openValue < 1f && shadowRenderers != null && shadowRenderers.Count > 0)
		{
			Bounds bounds = shadowRenderers[0].bounds;
			for (int i = 1; i < shadowRenderers.Count; i++)
			{
				bounds.Encapsulate(shadowRenderers[i].bounds);
			}
			Shadows.MarkAreaDirty(bounds, allowAmortization: true);
		}
		if (EntityUtility.GetComponentData<SwapColliderCD>(base.entity, base.world).swap)
		{
			openValue += Time.deltaTime * 2f;
		}
		else
		{
			openValue -= Time.deltaTime * 2f;
		}
		openValue = Mathf.Clamp01(openValue);
		animator.SetFloat(OpenValue, openValue);
		Color emissiveColor = ((openValue > 0f) ? Color.white : Color.black);
		if (base.variation == 0)
		{
			spriteObjects[0].emissiveColor = emissiveColor;
			spriteObjects[1].emissiveColor = emissiveColor;
		}
		else
		{
			spriteObjects[3].emissiveColor = emissiveColor;
			spriteObjects[5].emissiveColor = emissiveColor;
		}
	}

	public override void UpdateGraphicsFromObjectInfo(ObjectInfo info)
	{
		UpdateGraphics();
	}

	private void UpdateGraphics()
	{
		if (base.entity == Entity.Null)
		{
			return;
		}
		int num = base.variation;
		if (activeVariation != num)
		{
			horizontalRenderer.SetActive(value: false);
			verticalRenderer.SetActive(value: false);
			switch (num)
			{
			case 0:
				horizontalRenderer.SetActive(value: true);
				break;
			case 1:
				verticalRenderer.SetActive(value: true);
				break;
			}
			activeVariation = num;
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 6);
	}
}
