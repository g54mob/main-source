using DV.Interaction.Inputs;
using UnityEngine;

public class InteractionInput
{
	public bool UseKeyDown => InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionPrimary);

	public bool UseKeyUp => InputManager.NewPlayer.GetButtonUp(InputManager.Actions.InteractionPrimary);

	public bool Throw => InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Drop);

	public bool PlacementDown => InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Place);

	public bool PlacementUp => InputManager.NewPlayer.GetButtonUp(InputManager.Actions.Place);

	public bool MouseWheel => MouseScroll != 0;

	public int MouseScroll => InputManager.GetScrollValue();

	public int? SlotKey => TryGetSlotKey();

	public bool HotbarAccessPressed => InputManager.NewPlayer.GetButton(InputManager.Actions.Hotbar);

	public bool HotbarAccessReleased => InputManager.NewPlayer.GetButtonUp(InputManager.Actions.Hotbar);

	public bool InventoryOpenPressed => InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventoryOpen);

	public bool InventoryClosePressed => InventoryOpenPressed;

	public Vector2 GetMouseAxis()
	{
		return InterpretMouseInput();
	}

	private int? TryGetSlotKey()
	{
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot1))
		{
			return 0;
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot2))
		{
			return 1;
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot3))
		{
			return 2;
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot4))
		{
			return 3;
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot5))
		{
			return 4;
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot6))
		{
			return 5;
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot7))
		{
			return 6;
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot8))
		{
			return 7;
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot9))
		{
			return 8;
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot10))
		{
			return 9;
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot11))
		{
			return 10;
		}
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventorySlot12))
		{
			return 11;
		}
		return null;
	}

	private Vector2 InterpretMouseInput()
	{
		Vector2 mouseAxisInput = InputManager.GetMouseAxisInput();
		if (Mathf.Abs(mouseAxisInput.x) >= Mathf.Abs(mouseAxisInput.y))
		{
			mouseAxisInput.y = 0f;
		}
		else
		{
			mouseAxisInput.x = 0f;
		}
		return mouseAxisInput;
	}
}
