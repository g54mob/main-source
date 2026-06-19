using System;
using System.Collections.Generic;
using Pug.RP;
using Pug.Sprite;
using UnityEngine;

public class Gate : EntityMonoBehaviour
{
	[Serializable]
	public class ObjectIdMaterial
	{
		public ObjectID objectID;

		public Material material;
	}

	public SpriteObject horizontalRenderer;

	public SpriteObject shadowRenderer;

	public GameObject shadowCaster;

	public SpriteObject verticalRenderer;

	public SpriteObject verticalRendererSide;

	public SpriteObject verticalRendererOpen;

	public SpriteObject verticalRendererOpen1;

	public SpriteObject verticalRendererOpen2;

	private int activeVariation;

	public List<SpriteObject> renderersAffectedByMaterialChange;

	public Material defaultMaterial;

	public List<ObjectIdMaterial> materialOverrides;

	private bool hasUpdatedMaterial;

	public override void OnOccupied()
	{
		base.OnOccupied();
		activeVariation = -1;
		hasUpdatedMaterial = false;
		UpdateGraphics(base.objectInfo);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (activeVariation != base.variation)
		{
			AudioManager.Sfx(SfxID.shoop, base.transform.position, 1f, 1f, 0.1f);
		}
		UpdateGraphics(base.objectInfo);
	}

	public override void UpdateGraphicsFromObjectInfo(ObjectInfo info)
	{
		UpdateGraphics(info);
	}

	private void UpdateGraphics(ObjectInfo info)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		int num = base.variation;
		if (activeVariation != num)
		{
			horizontalRenderer.gameObject.SetActive(value: false);
			verticalRenderer.gameObject.SetActive(value: false);
			verticalRendererOpen.gameObject.SetActive(value: false);
			if (shadowRenderer != null)
			{
				shadowRenderer.SetVariantByIndex(num);
			}
			switch (num)
			{
			case 0:
				horizontalRenderer.gameObject.SetActive(value: true);
				horizontalRenderer.SetVariantByIndex(1);
				horizontalRenderer.ApplyVisualChange();
				if (shadowCaster != null)
				{
					shadowCaster.gameObject.SetActive(value: true);
				}
				break;
			case 1:
				horizontalRenderer.gameObject.SetActive(value: true);
				horizontalRenderer.SetVariantByIndex(2);
				if (shadowCaster != null)
				{
					shadowCaster.gameObject.SetActive(value: false);
				}
				break;
			case 2:
				verticalRenderer.gameObject.SetActive(value: true);
				verticalRenderer.ApplyVisualChange();
				if (verticalRendererSide != null)
				{
					verticalRendererSide.ApplyVisualChange();
				}
				break;
			case 3:
				verticalRendererOpen.gameObject.SetActive(value: true);
				verticalRendererOpen.ApplyVisualChange();
				verticalRendererOpen1.ApplyVisualChange();
				if (verticalRendererOpen2 != null)
				{
					verticalRendererOpen2.ApplyVisualChange();
				}
				break;
			case 4:
				horizontalRenderer.gameObject.SetActive(value: true);
				horizontalRenderer.SetVariantByIndex(7);
				horizontalRenderer.ApplyVisualChange();
				if (shadowCaster != null)
				{
					shadowCaster.gameObject.SetActive(value: true);
				}
				break;
			case 5:
				horizontalRenderer.gameObject.SetActive(value: true);
				verticalRenderer.ApplyVisualChange();
				if (shadowCaster != null)
				{
					shadowCaster.gameObject.SetActive(value: false);
				}
				break;
			}
			Shadows.MarkAreaDirty(new Bounds(base.transform.position, Vector3.one), allowAmortization: false);
			activeVariation = num;
		}
		if (!hasUpdatedMaterial)
		{
			ObjectIdMaterial objectIdMaterial = null;
			foreach (ObjectIdMaterial materialOverride in materialOverrides)
			{
				if (base.objectData.objectID == materialOverride.objectID)
				{
					objectIdMaterial = materialOverride;
					break;
				}
			}
			bool flag = objectIdMaterial != null;
			foreach (SpriteObject item in renderersAffectedByMaterialChange)
			{
				item.material = ((flag && objectIdMaterial.material != null) ? objectIdMaterial.material : defaultMaterial);
			}
			hasUpdatedMaterial = true;
		}
		base.UpdateGraphicsFromObjectInfo(info);
	}

	protected override void OnTakeDamage()
	{
		base.OnTakeDamage();
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(EntityUtility.GetObjectID(base.entity, base.world));
		if (objectInfo.objectID == ObjectID.GleamWoodFenceGate || objectInfo.objectID == ObjectID.GleamWoodDoor)
		{
			AudioManager.Sfx(SfxTableID.woodGleamTileDamage, base.transform.position);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(EntityUtility.GetObjectID(base.entity, base.world));
		if (objectInfo.objectID == ObjectID.GleamWoodFenceGate || objectInfo.objectID == ObjectID.GleamWoodDoor)
		{
			AudioManager.Sfx(SfxTableID.woodGleamTileDestroy, base.transform.position);
		}
		else
		{
			Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 6);
		}
	}
}
