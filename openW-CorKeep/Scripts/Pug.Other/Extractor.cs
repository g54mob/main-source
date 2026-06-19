using System.Collections.Generic;
using I2.Loc;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class Extractor : CraftingBuilding
{
	public List<ParticleEffectSpawner> activeParticles;

	public Sprite overrideOutputSprite;

	public Sprite recipeSprite;

	public LocalizedString recipeUITitle;

	public LocalizedString recipeUIHoverDesc;

	private static readonly int ActiveAnimation = SpriteAsset.StringToHash("active");

	private static readonly int InactiveAnimation = SpriteAsset.StringToHash("inactive");

	private bool _updateOffState;

	[SerializeField]
	private SFXTableIDField sfxTableElement;

	private List<AudioManager.RunningSfxReference> loopingSfx = new List<AudioManager.RunningSfxReference>();

	protected bool IsActive { get; private set; }

	public override void OnOccupied()
	{
		for (int i = 0; i < activeParticles.Count; i++)
		{
			activeParticles[i].enabled = false;
		}
		base.OnOccupied();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!IsActive && _updateOffState)
		{
			SetOffState();
			_updateOffState = false;
		}
	}

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	private void SetOffState()
	{
		spriteObjects[0].PlayAnimation(InactiveAnimation);
		for (int i = 0; i < activeParticles.Count; i++)
		{
			activeParticles[i].enabled = false;
		}
	}

	private void SetActiveState()
	{
		spriteObjects[0].PlayAnimation(ActiveAnimation);
		for (int i = 0; i < activeParticles.Count; i++)
		{
			activeParticles[i].enabled = true;
		}
	}

	protected override void OnActive()
	{
		base.OnActive();
		SetActiveState();
		IsActive = true;
		if (sfxTableElement.value != 0)
		{
			AudioManager.Sfx(sfxTableElement.value, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, loopingSfx);
		}
	}

	protected override void OnInactive()
	{
		base.OnInactive();
		_updateOffState = true;
		IsActive = false;
		if (loopingSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
		loopingSfx.Clear();
	}
}
