using Pug.Sprite;
using UnityEngine;

public class Furnace : CraftingBuilding
{
	private static readonly int ActiveAnimation = SpriteAsset.StringToHash("active");

	private static readonly int DoneAnimation = SpriteAsset.StringToHash("done");

	public SpriteRenderer[] activeGlow;

	public SpriteRenderer[] postGlow;

	public ParticleSystem[] particleSystems;

	public SpriteObject furnaceFire;

	private bool _updateOffState;

	private int _previousBarAmount;

	protected bool IsActive { get; private set; }

	protected int CurrentBarAmount { get; private set; }

	public override void OnOccupied()
	{
		base.OnOccupied();
		_previousBarAmount = 0;
		if (furnaceFire != null)
		{
			furnaceFire.PlayAnimation(ActiveAnimation, furnaceFire.currentVariantHash);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		CurrentBarAmount = craftingHandler.outputInventoryHandler.GetObjectData(0).amount;
		if (CurrentBarAmount < _previousBarAmount)
		{
			_updateOffState = true;
		}
		else if (CurrentBarAmount > _previousBarAmount && Manager.main.player != null && craftingHandler == Manager.main.player.activeCraftingHandler && Manager.ui.isCraftingUIShowing)
		{
			AudioManager.Sfx(SfxID.ore, base.transform.position, 0.5f, 0.9f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: false);
		}
		_previousBarAmount = CurrentBarAmount;
		if (!IsActive && _updateOffState)
		{
			SetOffState();
			_updateOffState = false;
		}
	}

	private void SetOffState()
	{
		ParticleSystem[] array = particleSystems;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop();
		}
		SpriteRenderer[] array2 = activeGlow;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].gameObject.SetActive(value: false);
		}
		array2 = postGlow;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].gameObject.SetActive(CurrentBarAmount > 0);
		}
		if (!(furnaceFire == null))
		{
			if (CurrentBarAmount > 0)
			{
				furnaceFire.color = new Color(1f, 1f, 1f, 1f);
				furnaceFire.PlayAnimation(DoneAnimation, furnaceFire.currentVariantHash);
			}
			else
			{
				furnaceFire.color = new Color(1f, 1f, 1f, 0f);
			}
		}
	}

	private void SetActiveState()
	{
		ParticleSystem[] array = particleSystems;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Play();
		}
		SpriteRenderer[] array2 = activeGlow;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].gameObject.SetActive(value: true);
		}
		array2 = postGlow;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].gameObject.SetActive(value: false);
		}
		if (!(furnaceFire == null))
		{
			furnaceFire.color = new Color(1f, 1f, 1f, 1f);
			furnaceFire.PlayAnimation(ActiveAnimation, furnaceFire.currentVariantHash);
		}
	}

	protected override void OnActive()
	{
		base.OnActive();
		SetActiveState();
		IsActive = true;
	}

	protected override void OnInactive()
	{
		base.OnInactive();
		_updateOffState = true;
		IsActive = false;
	}
}
