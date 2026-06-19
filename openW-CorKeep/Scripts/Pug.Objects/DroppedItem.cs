using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class DroppedItem : EntityMonoBehaviour
{
	public SpriteRenderer SR;

	public SpriteRenderer overlaySR;

	public SpriteRenderer underlaySR;

	public PugText amountNumber;

	public PugText amountNumberOutline;

	public ColorReplacer colorReplacer;

	public GameObject LegendaryEffects;

	public AnimationCurve yPosSpawnCurve;

	public AnimationCurve xScaleSpawnCurve;

	public AnimationCurve yScaleSpawnCurve;

	public AnimationCurve yPosBounceLoopCurve;

	private const float SPRITE_MAX_OFFSET = 0.0625f;

	private ObjectID currentlyShowingObject;

	private int currentlyShowingObjectAmount;

	private bool amountIsHidden;

	private bool isSpawning;

	private float animationTime;

	private float spawnDuration = 0.5838f;

	protected override bool updateAnimOrientation => false;

	public override void OnOccupied()
	{
		animationTime = 0f;
		isSpawning = false;
		base.OnOccupied();
		Hide();
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		XScaler.localPosition = new Vector3(0f, 0f, rng.NextFloat(-0.0625f, 0.0625f));
	}

	protected override void OnShow()
	{
		base.OnShow();
		HandleAnimationTrigger(-1878077465);
		if (currentlyShowingObject == ObjectID.None)
		{
			shadow.SetActive(value: false);
		}
	}

	protected override void OnHide()
	{
		base.OnHide();
		Hide();
	}

	private void UpdateAndShow(ContainedObjectsBuffer containedObject)
	{
		ObjectID objectID = containedObject.objectID;
		Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(containedObject.objectData, getSmallIcon: true);
		SR.sprite = ((iconOverride != null) ? iconOverride : PugDatabase.GetObjectInfo(objectID, containedObject.variation)?.smallIcon);
		bool active = Manager.ui.ShouldShowCageOverlay(containedObject);
		overlaySR.gameObject.SetActive(active);
		underlaySR.gameObject.SetActive(active);
		shadow.SetActive(value: true);
		colorReplacer.UpdateColorReplacerFromObjectData(containedObject);
		Manager.ui.ApplyAnyIconGradientMap(containedObject, SR);
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(objectID, containedObject.variation);
		int amount = containedObject.amount;
		string text = "";
		amountIsHidden = Manager.prefs.hideInGameUI;
		if (!amountIsHidden && amount > 1 && objectInfo != null && objectInfo.isStackable)
		{
			text = amount.ToString();
		}
		if (text != amountNumber.displayedTextString)
		{
			amountNumber.Render(text);
			amountNumberOutline.Render(text);
		}
		currentlyShowingObject = objectID;
		currentlyShowingObjectAmount = amount;
		if (objectInfo != null && objectInfo.rarity == Rarity.Legendary)
		{
			LegendaryEffects.SetActive(value: true);
		}
	}

	private void Hide()
	{
		SR.sprite = null;
		overlaySR.gameObject.SetActive(value: false);
		underlaySR.gameObject.SetActive(value: false);
		LegendaryEffects.SetActive(value: false);
		shadow.SetActive(value: false);
		amountNumber.Render("");
		amountNumberOutline.Render("");
		currentlyShowingObject = ObjectID.None;
		currentlyShowingObjectAmount = 0;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (base.isHidden || !EntityUtility.HasComponentData<ContainedObjectsBuffer>(base.entity, base.world))
		{
			return;
		}
		DynamicBuffer<ContainedObjectsBuffer> buffer = EntityUtility.GetBuffer<ContainedObjectsBuffer>(base.entity, base.world);
		ContainedObjectsBuffer containedObject = ((buffer.Length > 0) ? buffer[0] : default(ContainedObjectsBuffer));
		if (containedObject.objectID != ObjectID.None && (containedObject.objectID != currentlyShowingObject || containedObject.amount != currentlyShowingObjectAmount || Manager.prefs.hideInGameUI != amountIsHidden))
		{
			UpdateAndShow(containedObject);
		}
		else if (containedObject.objectID == ObjectID.None && SR.sprite != null && currentlyShowingObject != ObjectID.None && !Manager.load.IsSceneTransitionOrLoading())
		{
			if (EntityUtility.TryGetComponentData<PickUpItemCD>(base.entity, base.world, out var value) && EntityUtility.TryGetComponentData<LocalToWorld>(value.targetEntity, base.world, out var value2) && EntityUtility.TryGetComponentData<LocalToWorld>(base.entity, base.world, out var value3) && math.lengthsq(value2.Position - value3.Position) < 10f)
			{
				AudioManager.Sfx(SfxID.twitch, base.transform.position, 0.2f, 0.7f, 0.1f, reuse: true);
			}
			Hide();
		}
		UpdateAnimation();
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == -1878077465)
		{
			if (EntityUtility.IsNewlyCreatedObject(base.entity, base.world))
			{
				DropSound();
				isSpawning = true;
				animationTime = 0f;
				SR.transform.localPosition = new Vector3(0f, yPosSpawnCurve.Evaluate(0f), 0f);
				SR.transform.localScale = new Vector3(xScaleSpawnCurve.Evaluate(0f), yScaleSpawnCurve.Evaluate(0f), 1f);
			}
			else
			{
				SR.transform.localScale = Vector3.one;
			}
		}
	}

	private void UpdateAnimation()
	{
		if (!isSpawning)
		{
			animationTime = (animationTime + Time.deltaTime) % 1.67f;
			SR.transform.localPosition = new Vector3(0f, yPosBounceLoopCurve.Evaluate(animationTime), 0f);
		}
		else if (animationTime < spawnDuration)
		{
			animationTime += Time.deltaTime;
			float time = animationTime / spawnDuration;
			SR.transform.localPosition = new Vector3(0f, yPosSpawnCurve.Evaluate(time), 0f);
			Vector3 localScale = new Vector3(xScaleSpawnCurve.Evaluate(time), yScaleSpawnCurve.Evaluate(time), 1f);
			SR.transform.localScale = localScale;
		}
		else
		{
			SR.transform.localScale = Vector3.one;
			animationTime = 0f;
			isSpawning = false;
		}
	}

	private void DropSound()
	{
		if (IsLegendary())
		{
			LegendaryItemEffects();
		}
	}

	private bool IsLegendary()
	{
		if (!base.entityExist)
		{
			return false;
		}
		if (!EntityUtility.HasComponentData<ContainedObjectsBuffer>(base.entity, base.world))
		{
			return false;
		}
		DynamicBuffer<ContainedObjectsBuffer> buffer = EntityUtility.GetBuffer<ContainedObjectsBuffer>(base.entity, base.world);
		if (buffer.IsEmpty)
		{
			return false;
		}
		ContainedObjectsBuffer containedObjectsBuffer = buffer[0];
		if (containedObjectsBuffer.objectID != ObjectID.None)
		{
			ObjectInfo objectInfo = PugDatabase.GetObjectInfo(containedObjectsBuffer.objectID);
			if (objectInfo != null && objectInfo.rarity == Rarity.Legendary)
			{
				return true;
			}
		}
		return false;
	}

	private void LegendaryItemEffects()
	{
		AudioManager.SfxFollowTransform(SfxID.spoonget, base.transform, 0.4f, 0.9f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 30f);
	}
}
