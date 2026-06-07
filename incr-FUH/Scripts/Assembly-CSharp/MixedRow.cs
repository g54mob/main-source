using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MixedRow : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public enum StateEnum
	{
		NoButton = 0,
		NoValue = 1,
		Full = 2
	}

	public GameObject Parent;

	private TMP_Text _rowLabel;

	private TMP_Text _rowValueLabel;

	private Button _rowButton;

	private TMP_Text _rowButtonText;

	private string _tooltipTitle = "";

	private string _tooltipText = "";

	private Func<TooltipPanel.TooltipInfo, TooltipPanel.TooltipInfo> _dynamicTooltip;

	private StateEnum _state = StateEnum.Full;

	private bool _isHover;

	private static Color _lightGray = new Color(35f / 51f, 35f / 51f, 35f / 51f);

	private static Color _lightYellow = new Color(1f, 1f, 0.5294118f);

	public event EventHandler ButtonPressEvent;

	private void Awake()
	{
		_rowLabel = base.transform.Find("RowLabel").GetComponent<TMP_Text>();
		_rowValueLabel = base.transform.Find("RowValueLabel").GetComponent<TMP_Text>();
		_rowButton = base.transform.Find("RowButton").GetComponent<Button>();
		_rowButtonText = _rowButton.transform.Find("ButtonText").GetComponent<TMP_Text>();
		_rowLabel.text = "";
		_rowValueLabel.text = "";
		_rowButtonText.text = "";
		_rowButton.onClick.AddListener(RowButtonClick);
	}

	public void Initialize(GameObject parent, StateEnum newState, string label, string tooltip = "")
	{
		Parent = parent;
		SetState(newState);
		SetLabel(label);
		SetTooltip(tooltip);
	}

	public void SetForLevelUp(BaseBuilding levelInfo)
	{
		SetValue(levelInfo.GetLevel().ToString());
		if (levelInfo.GetLevel() >= 10)
		{
			SetState(StateEnum.NoButton);
			return;
		}
		int increaseLevelCost = levelInfo.GetIncreaseLevelCost();
		SetState(StateEnum.Full);
		SetButton(increaseLevelCost.ToNumber() + "$");
		SetButtonColor(increaseLevelCost < GameController.Instance.Money.Amount);
	}

	public void SetForStability(float stability)
	{
		SetValue((int)(stability * 100f) + "%");
	}

	public void SetForTraining(string name, BaseTrainingAttribute attribute, bool isTraining, bool isMax)
	{
		SetLabel(PanelTitle.GetTitle(name, attribute.Level + 1));
		if (attribute.CanDisplay())
		{
			if (isMax)
			{
				SetState(StateEnum.Full);
				SetValue("Max");
				if (isTraining)
				{
					SetButton("On");
				}
				else
				{
					SetButton("Off");
				}
			}
			else
			{
				SetState(StateEnum.Full);
				SetValue(attribute.Amount + "/" + attribute.GetCost());
				if (isTraining)
				{
					SetButton("On");
				}
				else
				{
					SetButton("Off");
				}
			}
			base.gameObject.SetActive(value: true);
		}
		else
		{
			SetState(StateEnum.NoButton);
			SetValue("");
			base.gameObject.SetActive(value: false);
		}
	}

	public void SetForLevelUpgrade(BaseBuilding building, BaseMoneyLevelAttribute attribute)
	{
		int cost = building.ReduceWithTrainingPeon(attribute.GetCost());
		if (building != null)
		{
			cost = building.ReduceWithTrainingPeon(cost);
		}
		SetForLevelUpgrade(attribute.CanDisplay(), attribute.Level, attribute.GetMaxLevel(), cost);
	}

	public void SetForLevelUpgrade(bool canHave, int level, int maxLevel, int cost)
	{
		if (canHave)
		{
			if (level < maxLevel)
			{
				SetState(StateEnum.Full);
				SetButton(cost.ToNumber() + "$");
				SetButtonColor(cost < GameController.Instance.Money.Amount);
			}
			else
			{
				SetState(StateEnum.NoButton);
			}
			SetValue(level + "/" + maxLevel);
			base.gameObject.SetActive(value: true);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void SetForUpgrade(BaseBuilding building, BaseMoneyAttribute attribute)
	{
		int cost = attribute.GetCost();
		if (building != null)
		{
			cost = building.ReduceWithTrainingPeon(cost);
		}
		SetForUpgrade(attribute.CanDisplay(), attribute.IsEnabled, cost);
	}

	public void SetForUpgrade(bool canHave, bool isEnabled, int cost)
	{
		if (canHave)
		{
			if (!isEnabled)
			{
				SetState(StateEnum.NoValue);
				SetButton(cost.ToNumber() + "$");
				SetButtonColor(cost < GameController.Instance.Money.Amount);
			}
			else
			{
				SetState(StateEnum.NoButton);
				SetValue("Enabled");
			}
			base.gameObject.SetActive(value: true);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void SetForResearch(BaseResearchAttribute attribute)
	{
		SetForResearch(attribute.CanDisplay(), attribute.IsEnabled, attribute.GetCost());
	}

	public void SetForResearch(bool canHave, bool isEnabled, int cost)
	{
		if (canHave)
		{
			base.gameObject.SetActive(value: true);
			if (!isEnabled)
			{
				SetState(StateEnum.NoValue);
				SetButton(cost + " RP");
				SetButtonColor(cost < GameController.Instance.ResearchPoint.Amount);
			}
			else
			{
				SetState(StateEnum.NoButton);
				SetValue("Enabled");
			}
			base.gameObject.SetActive(value: true);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void SetState(StateEnum newState)
	{
		if (_state != newState)
		{
			_state = newState;
			switch (_state)
			{
			case StateEnum.NoButton:
				_rowLabel.gameObject.SetActive(value: true);
				_rowValueLabel.gameObject.SetActive(value: true);
				_rowButton.gameObject.SetActive(value: false);
				break;
			case StateEnum.NoValue:
				_rowLabel.gameObject.SetActive(value: true);
				_rowValueLabel.gameObject.SetActive(value: false);
				_rowButton.gameObject.SetActive(value: true);
				break;
			case StateEnum.Full:
				_rowLabel.gameObject.SetActive(value: true);
				_rowValueLabel.gameObject.SetActive(value: true);
				_rowButton.gameObject.SetActive(value: true);
				break;
			}
		}
	}

	public void SetLabel(string text)
	{
		_rowLabel.text = text;
	}

	public void SetValue(string text)
	{
		_rowValueLabel.text = text;
	}

	public void SetButton(string text)
	{
		_rowButtonText.text = text;
	}

	public void SetButtonColor(bool isOn)
	{
		if (isOn)
		{
			_rowButtonText.color = Color.white;
		}
		else
		{
			_rowButtonText.color = _lightGray;
		}
	}

	public void SetTooltip(string text)
	{
		SetTooltip("", text);
	}

	public void SetTooltip(string title, string text)
	{
		_tooltipTitle = title;
		_tooltipText = text;
		_dynamicTooltip = null;
		if (_isHover)
		{
			TooltipPanel.Instance.ShowTooltip(Parent, base.gameObject, _tooltipTitle, _tooltipText);
		}
	}

	public void SetDynamicTooltip(Func<TooltipPanel.TooltipInfo, TooltipPanel.TooltipInfo> tooltipInfo)
	{
		_tooltipText = "";
		_dynamicTooltip = tooltipInfo;
	}

	private void RowButtonClick()
	{
		this.ButtonPressEvent?.Invoke(this, EventArgs.Empty);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		GlobalSfx2Controller.Instance.PlayOneWithPitch(SoundManager.SoundTypeEnum.ui_button2_hover);
		if (!string.IsNullOrEmpty(_tooltipText) || _dynamicTooltip != null)
		{
			if (_dynamicTooltip == null)
			{
				TooltipPanel.Instance.ShowTooltip(Parent, base.gameObject, _tooltipTitle, _tooltipText);
			}
			else
			{
				TooltipPanel.Instance.ShowDynamicTooltip(Parent, base.gameObject, _dynamicTooltip);
			}
			_isHover = true;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_isHover = false;
		TooltipPanel.Instance.HideTooltip();
	}
}
