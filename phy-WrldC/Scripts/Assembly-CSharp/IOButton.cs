using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IOButton : MonoBehaviour
{
	private Button ioButton;

	private TMP_Text ioButtonLabel;

	private NormalTooltipTrigger ioButtonTooltip;

	private LogicIO logicIO;

	public event Action OnButtonClickedEvent;

	public event Action<bool> OnBlockHighlightChangedEvent;

	private void Awake()
	{
		ioButton = GetComponent<Button>();
		ioButtonLabel = GetComponentInChildren<TMP_Text>();
		ioButtonTooltip = GetComponent<NormalTooltipTrigger>();
		ioButton.onClick.AddListener(delegate
		{
			this.OnButtonClickedEvent?.Invoke();
		});
		ComponentEventTrigger component = GetComponent<ComponentEventTrigger>();
		component.OnPointerEnterEvent += delegate
		{
			BlockHighlightChangedHandler(isHighlighted: true);
		};
		component.OnPointerExitEvent += delegate
		{
			BlockHighlightChangedHandler(isHighlighted: false);
		};
	}

	private void BlockHighlightChangedHandler(bool isHighlighted)
	{
		if (logicIO != null)
		{
			this.OnBlockHighlightChangedEvent?.Invoke(isHighlighted);
		}
	}

	public void SetLogicIO(LogicIO logicIO, bool isOnlyInput)
	{
		this.logicIO = logicIO;
		var (sourceText, helpText) = GetIOButtonLabel(logicIO, isOnlyInput);
		ioButtonLabel.SetText(sourceText);
		ioButtonTooltip.HelpText = helpText;
	}

	private (string label, string tooltip) GetIOButtonLabel(LogicIO logicIO, bool isOnlyInput)
	{
		string text = string.Empty;
		string empty = string.Empty;
		if (logicIO != null)
		{
			if (logicIO.ParentHingeJointView != null)
			{
				if (logicIO.ParentHingeJointView.MotorJointView != null)
				{
					text = LanguagesManager.Instance.GetText("label.text.transmission.continuous", "Continuous Spin");
				}
				else if (logicIO.ParentHingeJointView.SteerableJointView != null)
				{
					text = LanguagesManager.Instance.GetText("label.text.transmission.steerable", "Steerable Spin");
				}
				else if (logicIO.ParentHingeJointView.StepperJointView != null)
				{
					text = LanguagesManager.Instance.GetText("label.text.transmission.stepper", "Stepper Spin");
				}
			}
			else
			{
				text = GameManager.Instance.MainCreationController.model.GetBlockModel(logicIO.BlockId).Schematic.Name;
			}
			string text2 = LanguagesManager.Instance.GetText(logicIO.Name, logicIO.Name);
			empty = text + " - " + text2;
			text = text + "\n" + text2;
		}
		else if (isOnlyInput)
		{
			text = LanguagesManager.Instance.GetText("button.text.logic.addinput", "Add Input");
			empty = LanguagesManager.Instance.GetText("button.tooltip.logic.addinput", "Add Input");
		}
		else
		{
			text = LanguagesManager.Instance.GetText("button.text.logic.addio", "Add IO");
			empty = LanguagesManager.Instance.GetText("button.tooltip.logic.addio", "Add IO");
		}
		return (label: text, tooltip: empty);
	}
}
