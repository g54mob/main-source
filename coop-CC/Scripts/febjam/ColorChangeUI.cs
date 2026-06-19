using Aggro.Core;
using FMODUnity;
using UnityEngine.EventSystems;

public class ColorChangeUI : EntityBehaviourBase, ISelectHandler, IEventSystemHandler, IDeselectHandler
{
	public bool selected;

	public StudioEventEmitter changeColorSFX;

	public void Cycle(int dir)
	{
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			changeColorSFX.Play();
			player.GetObject<PlayerColorManagerNetwork>().CycleToNextPlayerColor(dir);
		}
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

	public void OnSelect(BaseEventData eventData)
	{
		selected = true;
	}

	public void OnDeselect(BaseEventData eventData)
	{
		selected = false;
	}
}
