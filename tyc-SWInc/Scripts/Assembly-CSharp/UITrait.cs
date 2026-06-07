using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class UITrait : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler
{
	public enum ToggleState
	{
		None = 0,
		Off = 1,
		On = 2
	}

	[Serializable]
	public class TraitClickEvent : UnityEvent<ToggleState>
	{
	}

	public Image TraitIcon;

	public Image Back;

	public Image Toggle;

	public Text TraitLabel;

	public GUIToolTipper TraitTip;

	public ToggleState State;

	[NonSerialized]
	public Employee.Trait Trait;

	public TraitClickEvent OnToggle;

	public UnityEvent OnToggleFromDisabled;

	public bool CanRightClick = true;

	private bool _disabled;

	public bool Disabled
	{
		get
		{
			return _disabled;
		}
		set
		{
			_disabled = value;
			if (_disabled)
			{
				Back.color = new Color(0.6f, 0.6f, 0.6f);
				TraitIcon.color = new Color(0.1f, 0.1f, 0.1f);
			}
			else
			{
				SetBackColor();
				TraitIcon.color = Color.white;
			}
		}
	}

	public void SetTrait(Employee.Trait t)
	{
		Trait = t;
		TraitIcon.sprite = ObjectDatabase.Instance.GetTrait(t);
		SetBackColor();
		string text = "Trait" + t;
		if (TraitLabel != null)
		{
			TraitLabel.text = text.Loc();
		}
		TraitTip.ToolTipValue = text;
		TraitTip.TooltipDescription = text + "Desc";
	}

	private void SetBackColor()
	{
		if ((Employee.Trait.FastLearner | Employee.Trait.Independant | Employee.Trait.BigBrain | Employee.Trait.Humble | Employee.Trait.Capacitor | Employee.Trait.WalkItOff | Employee.Trait.ThisIsFine | Employee.Trait.Sunshine | Employee.Trait.Skyscraper | Employee.Trait.RGBThumb | Employee.Trait.Clean).HasBits(Trait))
		{
			Back.color = HUD.GetThemeColor(0);
		}
		else if ((Employee.Trait.NightOwl | Employee.Trait.BornLeader | Employee.Trait.FirmwareInc | Employee.Trait.SuperFocus | Employee.Trait.Unphased | Employee.Trait.JustTheFlu | Employee.Trait.Detached | Employee.Trait.Watch | Employee.Trait.FriendMaker).HasBits(Trait))
		{
			Back.color = HUD.GetThemeColor(1);
		}
		else if (Employee.Trait.OldSole.HasBits(Trait))
		{
			Back.color = HUD.GetThemeColor(7);
		}
		else
		{
			Back.color = HUD.GetThemeColor(2);
		}
	}

	public void SetToggle(ToggleState state)
	{
		State = state;
		switch (state)
		{
		case ToggleState.None:
			Toggle.gameObject.SetActive(false);
			break;
		case ToggleState.Off:
			Toggle.gameObject.SetActive(true);
			Toggle.color = HUD.GetThemeColor(2);
			Toggle.sprite = ObjectDatabase.GetIcon("Cross");
			break;
		case ToggleState.On:
			Toggle.gameObject.SetActive(true);
			Toggle.color = HUD.GetThemeColor(0);
			Toggle.sprite = ObjectDatabase.GetIcon("Checkmark");
			break;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (Toggle != null && !Disabled)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				UISoundFX.PlaySFX("ToggleClick");
				SetToggle((State != ToggleState.On) ? ToggleState.On : ToggleState.None);
				OnToggle.Invoke(State);
			}
			else if (eventData.button == PointerEventData.InputButton.Right && CanRightClick)
			{
				UISoundFX.PlaySFX("ToggleClick");
				SelectorController.CanClick = false;
				SetToggle((State != ToggleState.Off) ? ToggleState.Off : ToggleState.None);
				OnToggle.Invoke(State);
			}
		}
		else if (Disabled)
		{
			OnToggleFromDisabled.Invoke();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
