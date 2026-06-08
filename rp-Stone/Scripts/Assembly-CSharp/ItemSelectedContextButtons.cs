using System;

public class ItemSelectedContextButtons : AsciiObject
{
	public enum State
	{
		Disabled = 0,
		In = 1,
		Idle = 2,
		Out = 3
	}

	public AsciiAnimation bgSelectedDouble;

	public AsciiAnimation bgSelectedSingle;

	public AsciiAnimation bgSelectedDoubleEdge;

	public AsciiAnimation bgUnselectedDouble;

	public AsciiAnimation bgUnselectedSingle;

	public AsciiAnimation bgUnselectedDoubleEdge;

	public AsciiAnimation bgSelectedSmall;

	public AsciiAnimation bgSelectedSmallEdge;

	public DialogButton detailsButtonDouble;

	public DialogButton detailsButtonSingle;

	public DialogButton equipButton;

	private AsciiAnimation activeBgAnimation;

	private ItemSlot nextSelectedSlot;

	public ItemSlot selectedItemSlot { get; private set; }

	public State currentState { get; private set; }

	public int stateElapsedTics { get; private set; }

	public bool isShowing => currentState != State.Disabled;

	public ItemScreen.Mode mode { get; set; }

	public bool isEquipmentSlot { get; set; }

	public event Action<ItemSlot> OnDetails;

	public event Action<ItemSlot> OnEquip;

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.In:
		{
			bool flag = selectedItemSlot.lastDrawX - bgSelectedDouble.Sprite.pivotX + Width >= GameStates.Singleton.asciiRenderer.width;
			Weapon weapon = selectedItemSlot.item as Weapon;
			if (weapon != null && (weapon.handType != Weapon.HandType.CannotEquip || mode == ItemScreen.Mode.Anvil))
			{
				if (flag)
				{
					if (isEquipmentSlot)
					{
						activeBgAnimation = bgSelectedSmallEdge;
					}
					else
					{
						activeBgAnimation = bgSelectedDoubleEdge;
					}
				}
				else if (isEquipmentSlot)
				{
					activeBgAnimation = bgSelectedSmall;
				}
				else
				{
					activeBgAnimation = bgSelectedDouble;
				}
			}
			else if (selectedItemSlot.item is TreasureItem && Inventory.Singleton.HasMultipleTreasures())
			{
				if (flag)
				{
					activeBgAnimation = bgSelectedDoubleEdge;
				}
				else
				{
					activeBgAnimation = bgSelectedDouble;
				}
			}
			else
			{
				activeBgAnimation = bgSelectedSingle;
			}
			activeBgAnimation.Stop();
			activeBgAnimation.Play();
			UpdateLabels();
			break;
		}
		case State.Out:
			if (activeBgAnimation == bgSelectedDouble || activeBgAnimation == bgSelectedSmall)
			{
				activeBgAnimation = bgUnselectedDouble;
			}
			else if (activeBgAnimation == bgSelectedDoubleEdge || activeBgAnimation == bgSelectedSmallEdge)
			{
				activeBgAnimation = bgUnselectedDoubleEdge;
			}
			else
			{
				activeBgAnimation = bgUnselectedSingle;
			}
			activeBgAnimation.Stop();
			activeBgAnimation.Play();
			break;
		case State.Disabled:
			selectedItemSlot = null;
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public void Show(ItemSlot slot)
	{
		if (currentState == State.In || currentState == State.Idle)
		{
			if (nextSelectedSlot == null)
			{
				if (slot == selectedItemSlot)
				{
					Hide();
					return;
				}
				nextSelectedSlot = slot;
				SetState(State.Out);
			}
		}
		else if (currentState == State.Out)
		{
			if (nextSelectedSlot == null)
			{
				nextSelectedSlot = slot;
			}
		}
		else
		{
			selectedItemSlot = slot;
			SetState(State.In);
		}
	}

	public void Hide()
	{
		if (currentState == State.In || currentState == State.Idle)
		{
			SetState(State.Out);
		}
		nextSelectedSlot = null;
	}

	public override void UpdateTic()
	{
		stateElapsedTics++;
		if (currentState == State.In && stateElapsedTics >= 5)
		{
			SetState(State.Idle);
		}
		else if (currentState == State.Out && stateElapsedTics >= 6)
		{
			if (nextSelectedSlot != null)
			{
				selectedItemSlot = nextSelectedSlot;
				nextSelectedSlot = null;
				SetState(State.In);
			}
			else
			{
				SetState(State.Disabled);
			}
		}
		if (currentState == State.In || currentState == State.Idle)
		{
			if (activeBgAnimation == bgSelectedSingle)
			{
				detailsButtonSingle.UpdateTic();
			}
			else
			{
				detailsButtonDouble.UpdateTic();
			}
			if (activeBgAnimation != bgSelectedSingle)
			{
				equipButton.UpdateTic();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (!(selectedItemSlot != null) || !(activeBgAnimation != null))
		{
			return;
		}
		offsetX = selectedItemSlot.lastDrawX;
		offsetY = selectedItemSlot.lastDrawY;
		if (isEquipmentSlot)
		{
			offsetX--;
			offsetY--;
		}
		activeBgAnimation.Sprite.Draw(r, offsetX, offsetY, ColorConstants.grey, ColorConstants.black);
		if (currentState == State.Idle)
		{
			if (activeBgAnimation == bgSelectedSingle)
			{
				detailsButtonSingle.Draw(r, offsetX, offsetY);
			}
			else if (activeBgAnimation == bgSelectedDouble || activeBgAnimation == bgSelectedSmall)
			{
				detailsButtonDouble.Draw(r, offsetX, offsetY);
				equipButton.Draw(r, offsetX, offsetY);
			}
			else if (activeBgAnimation == bgSelectedDoubleEdge || activeBgAnimation == bgSelectedSmallEdge)
			{
				detailsButtonDouble.Draw(r, offsetX - 3, offsetY);
				equipButton.Draw(r, offsetX - 3, offsetY);
			}
		}
	}

	private void UpdateLabels()
	{
		if (selectedItemSlot == null || selectedItemSlot.item == null)
		{
			detailsButtonSingle.label.SetValue("?");
			detailsButtonDouble.label.SetValue("?");
			equipButton.label.SetValue("?");
			return;
		}
		if (selectedItemSlot.item is TreasureItem)
		{
			detailsButtonSingle.label.SetValue(Te.xt("Open!"));
			detailsButtonDouble.label.SetValue(Te.xt("Open!"));
			equipButton.label.SetValue(Te.xt("Open All!"));
			return;
		}
		detailsButtonSingle.label.SetValue(Te.xt("Details"));
		detailsButtonDouble.label.SetValue(Te.xt("Details"));
		if (isEquipmentSlot)
		{
			equipButton.label.SetValue(Te.xt("Remove"));
		}
		else
		{
			equipButton.label.SetValue(Te.xt("Use"));
		}
	}

	private void HandleOnDetailsPressed(DialogButton button)
	{
		if (this.OnDetails != null)
		{
			this.OnDetails(selectedItemSlot);
		}
	}

	private void HandleOnEquipPressed(DialogButton button)
	{
		if (this.OnEquip != null)
		{
			this.OnEquip(selectedItemSlot);
		}
	}

	private void Start()
	{
		detailsButtonDouble.OnPressed += HandleOnDetailsPressed;
		detailsButtonSingle.OnPressed += HandleOnDetailsPressed;
		equipButton.OnPressed += HandleOnEquipPressed;
	}

	private void OnDestroy()
	{
		if (detailsButtonDouble != null)
		{
			detailsButtonDouble.OnPressed -= HandleOnDetailsPressed;
		}
		if (detailsButtonSingle != null)
		{
			detailsButtonSingle.OnPressed -= HandleOnDetailsPressed;
		}
		if (equipButton != null)
		{
			equipButton.OnPressed -= HandleOnEquipPressed;
		}
	}
}
