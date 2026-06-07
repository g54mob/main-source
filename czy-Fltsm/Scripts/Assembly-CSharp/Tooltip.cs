using I2.Loc;
using PajamaLlama.Debugs;
using UnityEngine;

[DisallowMultipleComponent]
public class Tooltip : TooltipTriggerBase, ITooltipProvider
{
	[Tooltip("Localized text to display in tooltip.")]
	public LocalizedString LocalizedText = "";

	[SerializeField]
	[Tooltip("This should be used for development only! If no localization key is provided, this will be used instead.")]
	private string _fallbackText = "";

	[Tooltip("Prevents the tooltip from showing")]
	public bool IsEnabled = true;

	[HideInInspector]
	public Bird Bird;

	private UIInteractable _uiInteractable;

	private AgentPanel _agentPanel;

	private BuildablePanel _buildablePanel;

	private DecorationPanel _decorationPanel;

	private void Start()
	{
		_uiInteractable = GetComponent<UIInteractable>();
		_agentPanel = GetComponentInParent<AgentPanel>();
		_buildablePanel = GetComponentInParent<BuildablePanel>();
		_decorationPanel = GetComponentInParent<DecorationPanel>();
		if (string.IsNullOrEmpty(LocalizedText) && LocalizedText.mTerm == null && _fallbackText.IsNullOrEmpty())
		{
			Debugger.Error(base.gameObject.name + " does not have a localized string set on its tooltip.", this);
		}
	}

	protected override void OnPointerEnter()
	{
		if (IsEnabled && !(LocalizedText == " "))
		{
			TooltipPanel.ShowTooltip(this);
		}
	}

	protected override void OnPointerExit()
	{
		TooltipPanel.HideTooltip(this);
	}

	public virtual string ParsedText()
	{
		string tooltipText = GetTooltipText();
		int actionId = ((_uiInteractable == null) ? (-1) : _uiInteractable.RewiredAction);
		tooltipText = TextManager.ReplaceVariables(tooltipText, FlotsamInputManager.RewiredPlayer.controllers.maps.GetFirstButtonMapWithAction(actionId, skipDisabledMaps: true));
		if (_agentPanel != null)
		{
			tooltipText = TextManager.ReplaceVariables(tooltipText, _agentPanel.AgentReference.Vitals);
		}
		if (Bird != null)
		{
			tooltipText = TextManager.ReplaceVariables(tooltipText, Bird);
		}
		if (_buildablePanel != null)
		{
			tooltipText = TextManager.ReplaceVariables(tooltipText, _buildablePanel.Buildable);
		}
		else if (_decorationPanel != null)
		{
			tooltipText = TextManager.ReplaceVariables(tooltipText, _decorationPanel.Decoration);
		}
		return tooltipText;
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return ParsedText();
	}

	public void ShowTooltip(GameObject trigger = null)
	{
		Debug.LogError("NotImplementedException");
	}

	public void HideTooltip()
	{
		Debug.LogError("NotImplementedException");
	}

	public Vector2 GetPosition()
	{
		if (FlotsamInputManager.IsJoystick)
		{
			return base.transform.position;
		}
		return FlotsamInputManager.MousePosition;
	}

	private string GetTooltipText()
	{
		if ((string)LocalizedText == null)
		{
			return _fallbackText;
		}
		return LocalizedText.ToString().GetOrDefault(_fallbackText);
	}
}
