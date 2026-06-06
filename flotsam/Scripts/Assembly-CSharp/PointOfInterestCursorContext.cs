using System;
using PajamaLlama.UI;
using UnityEngine;
using UnityEngine.PajamaLlama;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Contexts/PointOfInterestCursorContext")]
public class PointOfInterestCursorContext : CursorContext
{
	[Serializable]
	public struct ItemTagSettings
	{
		public Item.Tags ItemTag;

		public Sprite Sprite;

		public CursorState CursorState;
	}

	[SerializeField]
	private float _range = 10f;

	[SerializeField]
	private MarkerAction[] _actions;

	[SerializeField]
	private InputFlags _interactableInputs = InputFlags.Joystick;

	[SerializeField]
	[NamedArrayElement(new string[] { "ItemTag" })]
	private ItemTagSettings[] _settings;

	[SerializeField]
	private RewiredAction _interactAction = new RewiredAction(93, null);

	private Sprite _crosshairSprite;

	public override bool Interactable => FlotsamInputManager.HasActiveInput(_interactableInputs);

	public override Sprite CrosshairIcon => _crosshairSprite;

	public override SelectionLink SelectionLink => null;

	public override ActionBase[] Actions => _actions;

	public override void EnableRadialMenu()
	{
		if (_interactAction.GetButtonDown())
		{
			if (FlotsamInputManager.HasActiveInput(InputFlags.Joystick))
			{
				EnableJoystickRadialMenu();
			}
			else if (FlotsamInputManager.HasActiveInput(InputFlags.MouseAndKeyboard))
			{
				EnableMouseAndKeybiardRadialMenu();
			}
		}
	}

	public override bool TryActivate(CursorManager cursorManager)
	{
		if (Interactable && WorldManager.TryReturnClosestFlotsamItemProperties(CursorManager.BuildingPosition, _range, out var itemProperties))
		{
			GetSettings(_settings, itemProperties, out _crosshairSprite, out var cursorState);
			CursorManager.SetCursorState(cursorState);
			UIManager.AddRewiredActionInfoToContext(this, _interactAction);
			return true;
		}
		Deactivate();
		return false;
	}

	public override void Deactivate()
	{
		UIManager.DisableRewiredActionInfoContext(this);
		_crosshairSprite = null;
	}

	private void EnableJoystickRadialMenu()
	{
		RadialMenu.Enable(this);
	}

	private void EnableMouseAndKeybiardRadialMenu()
	{
		throw new NotImplementedException();
	}

	private void GetSettings(ItemTagSettings[] settingsList, ItemProperties itemProperties, out Sprite sprite, out CursorState cursorState)
	{
		for (int i = 0; i < settingsList.Length; i++)
		{
			ItemTagSettings itemTagSettings = settingsList[i];
			if ((itemTagSettings.ItemTag & itemProperties.Tags) != Item.Tags.None)
			{
				sprite = itemTagSettings.Sprite;
				cursorState = itemTagSettings.CursorState;
				return;
			}
		}
		sprite = null;
		cursorState = CursorState.Normal;
	}
}
