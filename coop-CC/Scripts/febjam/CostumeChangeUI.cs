using Aggro.Core;
using FMODUnity;
using UnityEngine.EventSystems;

public class CostumeChangeUI : EntityBehaviourBase, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	private bool selected;

	public StudioEventEmitter changeCostumeSFX;

	private int[] _unlockedCostumeIndicies;

	protected override void OnEntityCreated()
	{
	}

	protected override void OnUpdatePresentation()
	{
		if (selected)
		{
			if (AggroInputManager.input.Lobby.ChooseLeft.WasPressedThisFrame())
			{
				Cycle(-1);
			}
			if (AggroInputManager.input.Lobby.ChooseRight.WasPressedThisFrame())
			{
				Cycle(1);
			}
		}
	}

	public void Cycle(int dir)
	{
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			changeCostumeSFX.Play();
			PlayerCostumeManager playerCostumeManager = player.GetObject<PlayerCostumeManager>();
			PlayerCostumeManagerNetwork playerCostumeManagerNetwork = player.GetObject<PlayerCostumeManagerNetwork>();
			if (playerCostumeManager.currentUnlockedCostumeIndex + dir < 0)
			{
				playerCostumeManager.currentUnlockedCostumeIndex = playerCostumeManager.unlockedCostumeIndicies.Length - 1;
			}
			else if (playerCostumeManager.currentUnlockedCostumeIndex + dir > playerCostumeManager.unlockedCostumeIndicies.Length - 1)
			{
				playerCostumeManager.currentUnlockedCostumeIndex = 0;
			}
			else
			{
				playerCostumeManager.currentUnlockedCostumeIndex += dir;
			}
			playerCostumeManagerNetwork.SetCostumeIndex(playerCostumeManager.unlockedCostumeIndicies[playerCostumeManager.currentUnlockedCostumeIndex]);
			playerCostumeManager.ResetAllCostumes();
			SaveManager.data.SetCurrentCostume(playerCostumeManager.costumes[playerCostumeManagerNetwork.currentCostumeID].costumeObject);
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		selected = true;
	}

	public void OnDeselect(BaseEventData eventData)
	{
		selected = false;
	}
}
