using System;
using System.Collections.Generic;
using Pug.Sprite;
using UnityEngine;

public class FishingNet : CraftingBuilding, IFishingNetVisual
{
	[Serializable]
	public struct CritterVisualSlot
	{
		public SpriteRenderer SR;

		public ColorReplacer colorReplacer;
	}

	public List<CritterVisualSlot> critterVisualSlots;

	public Transform netTransform;

	public Vector3 netLocalPositionInLava;

	public List<SpriteObject> baseSprites;

	public List<SpriteObject> netSprites;

	public DataBlockRef<SpriteAssetSkin> fishingNetBaseLavaRef;

	public DataBlockRef<SpriteAssetSkin> fishingNetNetLavaRef;

	private bool _wasDisplayingInLava;

	private Vector3 _netLocalPositionInWater;

	private SpriteAssetSkin fishingNetBaseLava => fishingNetBaseLavaRef.Get();

	private SpriteAssetSkin fishingNetNetLava => fishingNetNetLavaRef.Get();

	protected override void Awake()
	{
		base.Awake();
		_netLocalPositionInWater = netTransform.localPosition;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		for (int i = 0; i < critterVisualSlots.Count; i++)
		{
			HideBait(i);
		}
		UpdateShowLavaSprite(force: true);
	}

	public void DisplayBait(int index, ContainedObjectsBuffer containedObject)
	{
		CritterVisualSlot critterVisualSlot = critterVisualSlots[index];
		SpriteRenderer sR = critterVisualSlot.SR;
		ColorReplacer colorReplacer = critterVisualSlot.colorReplacer;
		ObjectID objectID = containedObject.objectID;
		Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(containedObject.objectData, getSmallIcon: true);
		sR.sprite = ((iconOverride != null) ? iconOverride : PugDatabase.GetObjectInfo(objectID, containedObject.variation)?.smallIcon);
		colorReplacer.UpdateColorReplacerFromObjectData(containedObject);
		Manager.ui.ApplyAnyIconGradientMap(containedObject, sR);
	}

	public void HideBait(int index)
	{
		critterVisualSlots[index].SR.sprite = null;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -1878077465)
		{
			AudioManager.Sfx(SfxTableID.fishingNetSplashSfx, base.RenderPosition);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateShowLavaSprite();
	}

	private void UpdateShowLavaSprite(bool force = false)
	{
		EntityUtility.TryGetComponentData<FishingNetVisualCD>(base.entity, base.world, out var value);
		if (!force && value.isInLava == _wasDisplayingInLava)
		{
			return;
		}
		_wasDisplayingInLava = value.isInLava;
		SpriteAssetSkin spriteAssetSkin = (_wasDisplayingInLava ? fishingNetBaseLava : null);
		SpriteAssetSkin spriteAssetSkin2 = (_wasDisplayingInLava ? fishingNetNetLava : null);
		foreach (SpriteObject baseSprite in baseSprites)
		{
			baseSprite.skinRef = spriteAssetSkin;
			baseSprite.ApplyVisualChange();
		}
		foreach (SpriteObject netSprite in netSprites)
		{
			netSprite.skinRef = spriteAssetSkin2;
			netSprite.ApplyVisualChange();
		}
		netTransform.localPosition = (_wasDisplayingInLava ? netLocalPositionInLava : _netLocalPositionInWater);
	}
}
