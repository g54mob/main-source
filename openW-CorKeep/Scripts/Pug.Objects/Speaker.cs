using Pug.Automation;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class Speaker : EntityMonoBehaviour
{
	private enum SpeakerState
	{
		FromOccupied = 0,
		SoundAlreadyPlayed = 1,
		ReadyToPlaySoundWhenPowered = 2
	}

	private SpeakerState state;

	private int _electricalState = -1;

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

	public override void OnOccupied()
	{
		base.OnOccupied();
		state = SpeakerState.FromOccupied;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		ElectricityCD componentData = EntityUtility.GetComponentData<ElectricityCD>(base.entity, base.world);
		int num = 0;
		if (componentData.hasEnoughElectricityToPowerStuff)
		{
			num = 1;
		}
		if (num != _electricalState)
		{
			_electricalState = num;
			if (_electricalState == 1)
			{
				spriteObjects[0].emissiveColor = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				spriteObjects[0].emissiveColor = new Color(0f, 0f, 0f, 1f);
			}
		}
		if (state == SpeakerState.SoundAlreadyPlayed && !componentData.hasEnoughElectricityToPowerStuff)
		{
			state = SpeakerState.ReadyToPlaySoundWhenPowered;
		}
		else if (state == SpeakerState.FromOccupied)
		{
			if (!componentData.hasEnoughElectricityToPowerStuff)
			{
				state = SpeakerState.ReadyToPlaySoundWhenPowered;
			}
			else
			{
				state = SpeakerState.SoundAlreadyPlayed;
			}
		}
		else if (state == SpeakerState.ReadyToPlaySoundWhenPowered && componentData.hasEnoughElectricityToPowerStuff)
		{
			state = SpeakerState.SoundAlreadyPlayed;
			AudioManager.Sfx(SfxTableID.explodingWallBlockCountDown, base.RenderPosition);
		}
	}
}
